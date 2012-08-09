﻿namespace SitecoreInstaller.Framework.System
{
    public abstract class EnumClass
    {
        private readonly string _value;
        
        protected EnumClass(string value)
        {
            _value = value ?? string.Empty;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
