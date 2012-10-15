namespace SitecoreInstaller.Domain.Test.WebServer
{
    using System.IO;

    using FluentAssertions;

    using NUnit.Framework;

    using SitecoreInstaller.Domain.WebServer;

    [TestFixture]
    public class HostFileUT
    {
        private HostFile _hostFile;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _hostFile = new HostFile();
        }

        [TestCase("test", "127.0.0.1\ttest")]//tab separated
        [TestCase("test", "127.0.0.1  test")]//multiple space between ip address and host name
        [TestCase("test","127.0.0.1 test")]//ideal match
        public void LineIsHostFileName_HostNameMatch_IsMatch(string hostFileIisSiteName, string line)
        {
            var lineIsNotHostFileName = _hostFile.LineIsHostFileName(hostFileIisSiteName, line);

            Assert.IsTrue(lineIsNotHostFileName);
        }
        
        [TestCase("test","127.0.0.1 testX")]//has additional suffix
        [TestCase("test", "127.0.0.1 Xtest")]//has additional prefix
        [TestCase("test", "127.0.0.1 XtestX")]//has additional pre- and suffix
        [TestCase("test", "")]//empty line
        [TestCase("test", "127.0.0.1 ")]//no host name
        public void LineIsHostFileName_HostNameMatch_IsNotMatch(string hostFileIisSiteName, string line)
        {
            var lineIsNotHostFileName = _hostFile.LineIsHostFileName(hostFileIisSiteName, line);

            Assert.IsFalse(lineIsNotHostFileName);
        }

        [Test]
        public void LineIsHostFileName_HostNameMatchFromProductionSample_IsNotMatch()
        {
            using(var reader = new StringReader(Production_Sample_HostFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var result = _hostFile.LineIsHostFileName("NicamWithPeal", line);
                    result.Should().BeFalse("Line was:" + line);
                }
            }
        }


        private const string Production_Sample_HostFile = @"# Copyright (c) 1993-2009 Microsoft Corp.
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
# For example:
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host
# localhost name resolution is handled within DNS itself.
#             127.0.0.1       localhost
#             ::1             localhost
# 85.235.243.207 Innocore server
127.0.0.1              localhost.com
127.0.0.1              sitecore65update3          tm
127.0.0.1              Nicam   nicam.com
127.0.0.1              dealer.Nicam150
127.0.0.1              sitecoreum
127.0.0.1              sitecorefoundrykk           sitecorefoundrykk1.test1             sitecorefoundrykk1.test2
85.235.243.207  sitecoreeditor.sitecoredk.dk
127.0.0.1              Nicam151
127.0.0.1              dealer.Nicam151
127.0.0.1              Sitecore65Ecommerce
#8.145.201.237  feocorporate.eurorscg.com.sg
58.145.201.232  feocorporate.eurorscg.com.sg
127.0.0.1              SitecoreIntranetDemo
127.0.0.1              SitecoreIntranet
127.0.0.1              SitecoreEF
127.0.0.1              SitecoreTraining
127.0.0.1              SitecoreVTBPOC
127.0.0.1              SitecoreDemoCBABank
85.235.243.207  dms2.sitecoredk.dk
127.0.0.1              Nicam151Update1
127.0.0.1              dealer.Nicam151Update1
127.0.0.1              RenameItemModule
127.0.0.1 sitecore64azure
127.0.0.1 sitecoreavis
83.222.237.51     newweb.bang-olufsen.dk
83.222.236.247  beoweb.www.peer1.prod2
127.0.0.1 sitecoremaersk
127.0.0.1 Maersk
127.0.0.1              Sitecore651RTI
127.0.0.1              site1.Sitecore651RTI
127.0.0.1 sitecorekone
127.0.0.1              Jetstream
127.0.0.1 sitecorefoundry4          test.foundry4    test2.foundry4
127.0.0.1 sitecoreseating
127.0.0.1 sitecore65azure
127.0.0.1 sitesetter

217.145.56.2       markedsinformation.um.dk
";

    }
}
