using System;
using System.Collections.Generic;

namespace SitecoreInstallerConsole
{
  using SitecoreInstaller;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;

  public  class ConsoleDialogs:IDialogs
  {
    public bool ChooseFolder(out string selectedFolder, string startPath = "")
    {
      throw new NotImplementedException();
    }

    public bool RemoveBuildLibraryResources(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
    {
      throw new NotImplementedException();
    }

    public bool RemoveBuildLibraryResource(SourceEntry sourceEntry)
    {
      throw new NotImplementedException();
    }

    public bool AddSitecore(out string fileName)
    {
      throw new NotImplementedException();
    }

    public bool AddModule(out string fileName)
    {
      throw new NotImplementedException();
    }

    public bool AddLicense(out string fileName)
    {
      throw new NotImplementedException();
    }

    public bool ChooseFile(out string fileName, string filter = "All files (*.*)|*.*")
    {
      throw new NotImplementedException();
    }

    public bool UserAccept(string question, params string[] arguments)
    {
      throw new NotImplementedException();
    }

    public void Information(string text, params object[] arguments)
    {
      throw new NotImplementedException();
    }

    public void About()
    {
      throw new NotImplementedException();
    }

    public void OnlineHelp()
    {
      throw new NotImplementedException();
    }

    public bool InputBox(string title, string promptText, ref string value)
    {
      throw new NotImplementedException();
    }

    public void ModalDialog(DialogIcons dialogIcons, string text, string title)
    {
      throw new NotImplementedException();
    }
  }
}
