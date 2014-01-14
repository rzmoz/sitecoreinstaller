using System;

namespace SitecoreInstaller.Framework.Linguistics
{
    public class Word
    {
        public Word(string word)
        {
            Original = word ?? string.Empty;

            SetActiveForm();
        }

        private void SetActiveForm()
        {
            var verb = Original;
            verb = ProcessLastChar(verb);

            Activeform = verb.AddIng();
        }

        private string ProcessLastChar(string verb)
        {
            //we don't consider single character verbs
            if (verb.Length < 2)
                return verb;

            var lastChar = verb[verb.Length - 1];
            var secondLastChar = verb[verb.Length - 2];

            if (verb.ToLowerInvariant() == "run")
                return verb + lastChar;

            switch (lastChar)
            {
                //remove last char
                case 'e':
                    return verb.Substring(0, verb.Length - 1);
                //duplicate last char
                case 't':
                case 'p':
                    if (IsVowel(secondLastChar))
                        return verb + lastChar;
                    break;
            }
            return verb;
        }

        private bool IsVowel(char secondLastChar)
        {
            switch (Char.ToLower(secondLastChar))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'y':
                    return true;
            }
            return false;
        }

        public string Original { get; private set; }
        public string Activeform { get; private set; }

        public override string ToString()
        {
            return Original;
        }
    }
}
