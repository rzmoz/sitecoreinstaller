﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPipeline
    {
        IEnumerable<IPrecondition> Preconditions { get; }
        void Init();
    }
}
