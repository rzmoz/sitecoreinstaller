using NUnit.Framework;
using SitecoreInstaller.Framework.Linguistics;
using FluentAssertions;

namespace SitecoreInstaller.Tests.Framework.Linguistics
{
    [TestFixture]
    public class SentenceUT
    {
        [Test]
        //just add ing
        [TestCase("AddThis", "Adding This")]

        //delete last vowel and add ing
        [TestCase("CopyThis", "Copying This")]
        [TestCase("CreateThis", "Creating This")]

        //duplicate last consonant and add ing
        [TestCase("SetThis", "Setting This")]
        [TestCase("ZipThis", "Zipping This")]
        [TestCase("RunThis", "Running This")]

        //dual verbs!
        [TestCase("ZipAndMoveThis", "Zipping And Moving This")]
        public void ActiveForm_ActiveForm_SentenceIsInActiveForm(string passiveSentence, string activeSentence)
        {
            var sentence = new Sentence(passiveSentence);
            sentence.ActiveForm.Should().Be(activeSentence);
        }

        [TestCase("DoThis", "Do This")]
        public void Original_MakeSpaceDelimitedString_WordsAreDelimitedBySpace(string passiveSentence, string activeSentence)
        {
            var sentence = new Sentence(passiveSentence);
            sentence.ToString().Should().Be(activeSentence);
        }
    }
}