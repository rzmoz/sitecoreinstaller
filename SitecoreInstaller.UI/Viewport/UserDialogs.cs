using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.Viewport
{
    public class UserDialogs
    {
        public void MakeFullPublishDialog(PipelineApplicationEventArgs args)
        {
            args.AbortPipeline = !UserAccept("Do you want to publish the site?\r\nThis will initiate a full publish for all items in all languages from Master to Web");
            args.AbortReason = "Users decided not to do a full publish";
        }

        public void DeleteProjectDialog(CleanupEventArgs args)
        {
            args.DeepClean = !UserAccept("Do you want to keep the files for '{0}'? Saying no will delete everything permanently.", args.ProjectSettings.ProjectName);
        }

        public void SetArchiveName(ArchiveEventArgs args)
        {
            var defaultName = args.ProjectSettings.ProjectName + "_" + DateTime.Now.ToString("yyyyMMdd");
            args.ArchiveName = this.InputBox("Archive name", "Please enter archive name", defaultName);
        }

        public bool ChooseFolder(out string selectedFolder, string startPath = "")
        {
            var folderBrowser = new FolderBrowserDialog
            {
                SelectedPath = startPath
            };

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = folderBrowser.SelectedPath;
                return true;
            }

            selectedFolder = string.Empty;
            return false;
        }

        public bool RemoveBuildLibraryResources(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
        {
            if (sourceEntries == null)
                return false;

            var keysString = sourceEntries.ToDelimiteredString(';');
            keysString = Environment.NewLine + keysString.Replace(";", Environment.NewLine);

            return UserAccept("Do you want to remove {0}?", keysString);
        }

        public bool RemoveBuildLibraryResource(SourceEntry sourceEntry)
        {
            if (sourceEntry == null) { throw new ArgumentNullException("sourceEntry"); }
            return UserAccept("Do you want to remove {0}?", sourceEntry.Key);
        }

        public bool ChooseFile(out string fileName, string filter = "All files (*.*)|*.*")
        {
            var licenseFileDialog = new OpenFileDialog
            {
                Filter = filter,
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (licenseFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = licenseFileDialog.FileName;
                return true;
            }

            fileName = string.Empty;
            return false;
        }
        public bool UserAccept(string question, params string[] arguments)
        {
            var result = MessageBox.Show(string.Format(question, arguments), "Are you sure?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        public void ModalDialog(DialogIcons dialogIcons, string text, string title)
        {
            MessageBox.Show(text, title,
                                MessageBoxButtons.OK,
                                dialogIcons.ToMessageBoxIcon());
        }

        public void Information(string text, params object[] arguments)
        {
            MessageBox.Show(string.Format(text, arguments), string.Empty,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        public void About()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductVersion;

            MessageBox.Show("You are running SitecoreInstaller v" + version, "About SitecoreInstaller",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }
        public void OnlineHelp()
        {
            Process.Start("http://sitecoreinstaller.bitbucket.org/");
        }

        public string InputBox(string title, string promptText, string value = "")
        {
            var form = new Form();
            var label = new Label();
            var textBox = new TextBox();
            var buttonOk = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.ShowDialog();
            return textBox.Text;
        }


    }
    public static class DialogIconsExtensions
    {
        public static MessageBoxIcon ToMessageBoxIcon(this DialogIcons dialogIcons)
        {
            switch (dialogIcons)
            {
                case DialogIcons.Error:
                    return MessageBoxIcon.Error;
                case DialogIcons.Information:
                    return MessageBoxIcon.Information;
            }
            throw new ArgumentException(dialogIcons + " not recognized");
        }
    }
}
