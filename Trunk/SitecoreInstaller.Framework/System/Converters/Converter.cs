﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.System.Converters
{
  public abstract class Converter
  {
    public abstract T Convert<T>(object value);
  }
}
