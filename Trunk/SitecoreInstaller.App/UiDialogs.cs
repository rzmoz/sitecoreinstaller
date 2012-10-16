using System.IO;
using System.Windows.Forms;
using SitecoreInstaller.Framework.System;
namespace SitecoreInstaller.App
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Drawing;

    using SitecoreInstaller.Domain.BuildLibrary;

    public class UiDialogs
    {
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
            keysString = "\r\n" + keysString.Replace(";", Consts.Newline);

            return UserAccept("Do you want to remove {0}", keysString);
        }

        public bool RemoveBuildLibraryResource(SourceEntry sourceEntry)
        {
            Contract.Requires<ArgumentNullException>(sourceEntry != null);
            return UserAccept("Do you want to remove {0}", sourceEntry.Key);
        }

        public bool AddSitecore(out string fileName)
        {
            return ChooseFile(out fileName, "Sitecore versions (*.zip)|*.zip");
        }
        public bool AddModule(out string fileName)
        {
            return ChooseFile(out fileName, "Sitecore modules (*.zip)|*.zip");
        }
        public bool AddLicense(out string fileName)
        {
            return ChooseFile(out fileName, "Sitecore licenses (*.xml)|*.xml");
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
            var result = MessageBox.Show(string.Format(question, arguments) + "?", "Are you sure?",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        public void ModalDialog(MessageBoxIcon messageBoxIcon, string text, string title)
        {
            MessageBox.Show(text, title,
                                MessageBoxButtons.OK,
                                messageBoxIcon);
        }

        public void Information(string text, params object[] arguments)
        {
            MessageBox.Show(string.Format(text, arguments), string.Empty,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }

        public void About()
        {
            MessageBox.Show("SitecoreInstaller was created by Rasmus Rasmussen", "About SitecoreInstaller",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
        }
        public void OnlineHelp()
        {
            System.Diagnostics.Process.Start("http://sitecoreinstaller.codeplex.com/");
        }

        public DialogResult InputBox(string title, string promptText, ref string value)
        {
            var form = new Form();
            var label = new Label();
            var textBox = new TextBox();
            var buttonOk = new Button();
            var buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
