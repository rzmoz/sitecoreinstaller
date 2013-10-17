namespace SitecoreInstaller.Tests.Framework.Linguistics
{
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Linguistics;
  using FluentAssertions;

  [TestFixture]
  public class SentenceUT
  {
    [Test]
    //just add ing
    [TestCase("AddThis", "Adding As")]

    //delete last vowel and add ing
    [TestCase("CopyThis", "Copying As")]
    [TestCase("CreateThis", "Creating As")]
    
    //duplicate last consonant and add ing
    [TestCase("SetThis", "Setting As")]
    [TestCase("ZipThis", "Zipping As")]

    //dual verbs!
    [TestCase("ZipAndMoveThis", "Zipping And Moving As")]
    public void ActiveForm_ActiveForm_SentenceIsInActiveForm(string passiveSentence, string activeSentence)
    {
      var sentence = new Sentence(passiveSentence);
      sentence.ActiveForm.Should().Be(activeSentence);
    }
    
    [TestCase("DoThis", "Do As")]
    public void Original_MakeSpaceDelimitedString_WordsAreDelimitedBySpace(string passiveSentence, string activeSentence)
    {
      var sentence = new Sentence(passiveSentence);
      sentence.ToString().Should().Be(activeSentence);
    }
  }
}