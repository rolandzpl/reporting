using NUnit.Framework;
using System.IO;

namespace Reporting
{
    [TestFixture]
    class ReportGeneratorTests
    {
        [Test]
        public void GenerateReport_GivenInput_GeneratesIndexFile()
        {
            var input = new StringReader(Input.TestReport);

            generator.GenerateReport(input, "index.html");

            Assert.That(fileSystem.Files, Does.ContainKey("index.html"));
        }

        [Test]
        public void GenerateReport_GivenInput_IndexFileContainsListOfTestCases()
        {
            var input = new StringReader(Input.TestReport);

            generator.GenerateReport(input, "index.html");

            Assert.That(fileSystem.Files["index.html"],
                Does.Match(@".*<li>\s*Test1\s*</li>.*") &
                Does.Match(@".*<li>\s*Test2\s*</li>.*") &
                Does.Match(@".*<li>\s*Test3\s*</li>.*") &
                Does.Match(@".*<li>\s*Test4\s*</li>.*"));
        }

        [SetUp]
        protected void SetUp()
        {
            fileSystem = new FakeFileSystem();
            templateProvider = new FakeTemplateProvider(new StringReader(Xslt.ReportTemplate));
            generator = new ReportGenerator(fileSystem, templateProvider);
        }

        private FakeFileSystem fileSystem;
        private FakeTemplateProvider templateProvider;
        private ReportGenerator generator;
    }

    class Input
    {
        public const string TestReport = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<tests>
  <testCase name = ""Test1"" result=""Failed"" />
  <testCase name = ""Test2"" result=""Pass"" />
  <testCase name = ""Test3"" result=""Pass"">
    <description>Some another test...</description>
  </testCase>
  <testCase name = ""Test4"" result=""Pass"">
    <description>Some test description...</description>
    <assertions>
      <assertion result = ""Failed"" expectedResult=""Ala ma kota..."" actualResult=""Ala ma kota"">
        <description>This is assertion description...</description>
      </assertion>
      <assertion result = ""Passed"" expectedResult= ""Ala ma kota..."" actualResult= ""Ala ma kota..."" >
        <description> This is assertion description...</description>
      </assertion>
    </assertions>
  </testCase>
</tests>
";
    }

    class Xslt
    {
        public const string ReportTemplate = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xsl:stylesheet version = ""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
  <xsl:template match = ""/"">
    <html>
        <head>
            <meta charset=""utf-8"" />
            <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
            <title>Test Report</title>
            <link href=""css/bootstrap.min.css"" rel=""stylesheet"" />
        </head>
        <body>
            <ol>
                <xsl:for-each select=""tests/testCase"">
                <li>
                    <xsl:value-of select=""@name"" />
                </li>
                </xsl:for-each>
            </ol>
        </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
";
    }
}
