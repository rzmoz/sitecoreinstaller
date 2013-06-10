﻿namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps.SqlSettings;
  using SitecoreInstaller.Domain.Pipelines;

  public class TestSqlSettingsPipeline : Pipeline
  {
    public TestSqlSettingsPipeline()
    {
      AddStep<VerifySqlConnection>();
    }
  }
}
