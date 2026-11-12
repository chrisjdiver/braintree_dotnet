using System;
using System.Xml;
using NUnit.Framework;

namespace Braintree.Tests
{
    [TestFixture]
    public class AccountUpdaterDailyReportTest
    {
        private NodeWrapper nodeFromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return new NodeWrapper(doc.DocumentElement);
        }

        [Test]
        public void IncludesFields()
        {
            string xml = "<account-updater-daily-report>" +
                "<report-date type=\"date\">2016-01-14</report-date>" +
                "<report-url>https://example.com/report.csv</report-url>" +
            "</account-updater-daily-report>";
            var node = nodeFromXml(xml);

            AccountUpdaterDailyReport report = new AccountUpdaterDailyReport(node);

            Assert.AreEqual("https://example.com/report.csv", report.ReportUrl);
            Assert.AreEqual(new DateTime(2016, 1, 14), report.ReportDate);
        }
    }
}
