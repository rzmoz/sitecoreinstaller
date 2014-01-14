namespace SitecoreInstaller.Tests.Framework.Linguistics
{
    using NUnit.Framework;
    using SitecoreInstaller.Framework.Linguistics;
    using FluentAssertions;

    [TestFixture]
    public class WordUT
    {
        [Test]
        //just add ing
        [TestCase("Add", "Adding")]
        [TestCase("Attach", "Attaching")]
        [TestCase("Clean", "Cleaning")]
        [TestCase("Copy", "Copying")]
        [TestCase("Do", "Doing")]
        [TestCase("Grant", "Granting")]
        [TestCase("Install", "Installing")]

        //delete last vowel and add ing
        [TestCase("Create", "Creating")]
        [TestCase("Delete", "Deleting")]
        [TestCase("Execute", "Executing")]
        [TestCase("Update", "Updating")]
        [TestCase("Move", "Moving")]
        [TestCase("Make", "Making")]

        //duplicate last consonant and add ing
        [TestCase("Set", "Setting")]
        [TestCase("Stop", "Stopping")]
        [TestCase("Zip", "Zipping")]
        [TestCase("Run", "Running")]
        public void ActiveForm_ToActive_WordIsInActiveForm(string imperativeForm, string activeForm)
        {
            var word = new Word(imperativeForm);
            word.Activeform.Should().Be(activeForm);
        }
    }
}