using System;

namespace SitecoreInstaller.Framework.Sys
{
    public class GenericEventArgs<T> : EventArgs
    {
        public GenericEventArgs(T arg)
        {
            Arg = arg;
        }

        public T Arg { get; private set; }
    }
}
