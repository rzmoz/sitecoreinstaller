using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Sys
{
    public interface IUntil
    {
        void Reset();
        Func<bool> WhilePredicate();
        Action LoopBackAction();
    }
}
