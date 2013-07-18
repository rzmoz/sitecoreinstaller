using System.Collections.Generic;

namespace SitecoreInstaller.App
{
  using SitecoreInstaller.Domain.BuildLibrary;

  public interface IDialogs
  {
    bool ChooseFolder(out string selectedFolder, string startPath = "");
    bool RemoveBuildLibraryResources(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType);
    bool RemoveBuildLibraryResource(SourceEntry sourceEntry);
    bool AddSitecore(out string fileName);
    bool AddModule(out string fileName);
    bool AddLicense(out string fileName);
    bool ChooseFile(out string fileName, string filter = "All files (*.*)|*.*");
    bool UserAccept(string question, params string[] arguments);
    void ModalDialog(DialogIcons messageBoxIcon, string text, string title);
    void Information(string text, params object[] arguments);
    void About();
    void OnlineHelp();
    bool InputBox(string title, string promptText, ref string value);
  }
}
