using System;
using System.Collections.Generic;

namespace SitecoreInstaller.PreflightChecks
{
    public class PreflightCheckResult
    {
        public PreflightCheckResult()
        {
            Issues = new List<string>();
        }
        public PreflightCheckResult(Action<List<string>> addIssues)
        {
            var issues = new List<string>();
            addIssues(issues);
            Issues = issues;
        }

        public bool IsReady => Issues.Count == 0;
        public IReadOnlyCollection<string> Issues { get; }

    }
}
