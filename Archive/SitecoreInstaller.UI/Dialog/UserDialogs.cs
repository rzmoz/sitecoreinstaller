﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.App.Pipelines.Steps.Nothing;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.Dialog
{
    public class UserDialogs
    {
        public UserDialog UserDialog { get; private set; }

        public UserDialogs(Control.ControlCollection controlCollection)
        {
            UserDialog = new UserDialog();
            UserDialog.Init();
            UserDialog.Dock = DockStyle.Fill;
            UserDialog.TabStop = false;
            UiServices.ViewportStack.Register(UserDialog);
            if (controlCollection == null)
                return;
            controlCollection.Add(UserDialog);
        }

        public bool UserAccept(string question, params object[] arguments)
        {
            var accept = UserAcceptAsync(question, arguments);
            Task.WaitAll(accept);
            return accept.Result;
        }

        public Task<bool> UserAcceptAsync(string question, params object[] arguments)
        {
            return UserDialog.UserAcceptAsync(question, arguments);
        }

        public void ModalDialog(DialogIcon dialogIcon, string title, string textFormat, params object[] arguments)
        {
            Task.WaitAll(UserDialog.MessageAsync(dialogIcon, title, textFormat, arguments));
        }

        public void Information(string title, string textFormat = "", params object[] arguments)
        {
            Task.WaitAll(UserDialog.MessageAsync(DialogIcon.Information, title, textFormat, arguments));
        }

        public Task UserAcceptAsync(DoNothingEventArgs args)
        {
            return Task.Factory.StartNew(() =>
            {
                var accept = UserDialog.UserAcceptAsync("Yes or No - sdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdfsdfsdhfo shdfsiodfh sdf");
                Task.WaitAll(accept);
                args.UserAccepted = accept.Result;
            });
        }

        public Task MakeFullPublishAsync(PipelineApplicationEventArgs args)
        {
            return Task.Factory.StartNew(() =>
            {
                var accept = UserAcceptAsync("Do you want to publish the site?\r\nThis will initiate a full publish for all items in all languages from Master to Web");
                Task.WaitAll(accept);
                args.AbortPipeline = !accept.Result;
                args.AbortReason = "Users decided not to do a full publish";
            });
        }

        public Task DeleteProjectAsync(CleanupEventArgs args)
        {
            return Task.Factory.StartNew(() =>
            {
                var accept = UserAcceptAsync("Do you want to keep the files for '{0}'? Saying no will delete everything permanently.", args.ProjectSettings.ProjectName);
                Task.WaitAll(accept);
                args.DeepClean = !accept.Result;
            });
        }


        public Task SetArchiveName(ArchiveEventArgs args)
        {
            return Task.Factory.StartNew(() =>
            {
                var defaultName = args.ProjectSettings.ProjectName + "_" + DateTime.Now.ToString("yyyyMMdd");
                args.ArchiveName = this.InputBox("Archive name", "Please enter archive name", defaultName);
            });
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
            var accept = UserAcceptAsync("Do you want to remove {0}?", keysString);
            Task.WaitAll(accept);
            return accept.Result;
        }

        public bool RemoveBuildLibraryResource(SourceEntry sourceEntry)
        {
            if (sourceEntry == null) { throw new ArgumentNullException("sourceEntry"); }
            var accept = UserAcceptAsync("Do you want to remove {0}?", sourceEntry.Key);
            Task.WaitAll(accept);
            return accept.Result;
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

        public void About()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductVersion;

            Information("You are running SitecoreInstaller v" + version, "About SitecoreInstaller");
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
}
