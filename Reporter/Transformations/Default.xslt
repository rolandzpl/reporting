<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version = "1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match = "/">
    <html>
      <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <title>Test Report</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
      </head>
      <body>
        <div class="container">
          <xsl:for-each select="tests">
            <div>
              <xsl:apply-templates select="testCase" />
            </div>
          </xsl:for-each>
        </div>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="testCase">
    <h2 class="h2">
      <small>
        [<xsl:value-of select="@result" />]
      </small>
      <xsl:value-of select="@name" />
    </h2>
    <div>
      <xsl:value-of select="description" />
    </div>
    <table class="table">
      <tr>
        <th>Result</th>
        <th>Expected Result</th>
        <th>Actual Result</th>
        <th>Description</th>
      </tr>
      <xsl:for-each select="assertions">
        <xsl:apply-templates />
      </xsl:for-each>
    </table>
  </xsl:template>

  <xsl:template match="assertion">
    <tr>
      <td>
        <xsl:value-of select="@result" />
      </td>
      <td>
        <xsl:value-of select="@expectedResult" />
      </td>
      <td>
        <xsl:value-of select="@actualResult" />
      </td>
      <td>
        <xsl:value-of select="description" />
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>