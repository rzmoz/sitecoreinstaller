namespace SitecoreInstaller.Tests.Framework.Diagnostics
{
    /*
    [TestFixture]
    public class LogUT
    {
        private Log _log;

        [TestFixtureSetUp]
        public void Setup()
        {
            _log = new Log(1000);
        }

        [Test]
        public void Info_Logging_EntriesAreInLog()
        {
            const int _LogTimes = 5;
            for (var i = 0; i < _LogTimes; i++)
                _log.Info("test");

            Assert.AreEqual(_LogTimes, _log.Where(message => message.LogType == LogType.Info).Count());
        }
        [Test]
        public void Info_Filtering_EntriesAreInLog()
        {
            const int _LogTimes = 5;
            for (var i = 0; i < _LogTimes; i++)
                _log.Info("test");

            Assert.AreEqual(_LogTimes, _log.Where(message => message.LogType == LogType.Info).Count());
        }

        [Test]
        public void LogMessage_MaxEntries_NoEntriesInLog()
        {
            _log = new Log();
            const int _LogTimes = 5;
            for (var i = 0; i < _LogTimes; i++)
                _log.Info("test");

            Assert.AreEqual(0, _log.Count);
        }

    }*/
}
