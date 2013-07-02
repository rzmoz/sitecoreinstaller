using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Linguistics
{
  using SitecoreInstaller.Framework.System;

  public class Sentence
  {
    private readonly IList<Word> _words;

    public Sentence(string sentence)
    {
      if (string.IsNullOrEmpty(sentence))
        _words = new List<Word>();
      else
        _words = sentence.TokenizeWhenCharIsUpper().Select(str => new Word(str)).ToList();

      ParseToActiveForm();
    }

    private void ParseToActiveForm()
    {
      var activeSentence = new List<string>();

      if (_words.Any())
      {
        var lastWordWasAnd = true;
        var lastWordWasMadeActive = false;
        foreach (var word in _words)
        {
          if (lastWordWasAnd)
          {
            activeSentence.Add(word.Activeform);
            lastWordWasAnd = false;
            lastWordWasMadeActive = true;
          }
          else
          {
            activeSentence.Add(word.Original);
            if (lastWordWasMadeActive)
              lastWordWasAnd = word.Original.ToLower() == "and";
            lastWordWasMadeActive = false;
          }
        }
      }

      ActiveForm = activeSentence.ToDelimiteredString();
    }

    public string ActiveForm { get; private set; }

    public override string ToString()
    {
      return _words.ToDelimiteredString();
    }
  }
}
