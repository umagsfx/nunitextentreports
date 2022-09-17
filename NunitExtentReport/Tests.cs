using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NunitExtentReport.ReportsLib;

namespace NunitExtentReport;

[TestFixture]
public class Tests : BaseTest
{
    [Test]
    public void Test()
    {
        try
        {
            Assert.AreEqual("test", "test");
            ReportLog.Pass("Test Passed");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
  
    }
    
    [Test]
    public void Test1()
    {
        try
        {
            Assert.AreEqual("test", "test1");
            ReportLog.Pass("Test Passed");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
  
    }
    
    [Test]
    public void Test2()
    {
        try
        {
            Assert.AreEqual("test", "test");
            ReportLog.Pass("Test Passed");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
  
    }

}