
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NunitExtentReport.ReportsLib;

namespace NunitExtentReport;

public class BaseTest
{
 
    [OneTimeSetUp]
    protected void ExtentStart()
    {
        ExtentTestManager.CreateParentTest(GetType().Name);
    }
    
    [SetUp]
    public void Setup()
    {
        Console.WriteLine("setup");
        ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
    }
    
    [TearDown]
    public void TearDown()
    {
        try
        {
            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : $"<pre>{TestContext.CurrentContext.Result.Message}</pre>";
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : $"<pre>{TestContext.CurrentContext.Result.StackTrace}</pre>";
            Status logstatus = Status.Pass;

            Console.WriteLine("TearDown");
 
            DateTime time = DateTime.Now;
            //fileName = "Screenshot_" + time.ToString("h_mm_ss") + TC_Name + ".png";
 
            switch (exec_status)
            {
                case TestStatus.Failed:
                    ReportLog.Fail("Test Failed:" + errorMessage + stacktrace);
                    /* The older way of capturing screenshots */
                   // screenShotPath = Capture(driver.Value, fileName);
                    /* Capturing Screenshots using built-in methods in ExtentReports 4 */
                    //var mediaEntity = CaptureScreenShot(driver.Value, fileName);
                    //_test.Log(Status.Fail, "Fail");
                    /* Usage of MediaEntityBuilder for capturing screenshots */  
                    //_test.Fail("ExtentReport 4 Capture: Test Failed", mediaEntity);
                    /* Usage of traditional approach for capturing screenshots */
                    ///_test.Log(Status.Fail, "Traditional Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Passed:
                    ReportLog.Pass("Test Passed");
                    /* The older way of capturing screenshots */
                    //screenShotPath = Capture(driver.Value, fileName);
                    /* Capturing Screenshots using built-in methods in ExtentReports 4 */
                    //mediaEntity = CaptureScreenShot(driver.Value, fileName);
                    //_test.Log(Status.Pass, "Pass");
                    /* Usage of MediaEntityBuilder for capturing screenshots */
                    //_test.Pass("ExtentReport 4 Capture: Test Passed", mediaEntity);
                    /* Usage of traditional approach for capturing screenshots */
                    //_test.Log(Status.Pass, "Traditional Snapshot below: " + _test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    break;
            }
            ReportLog.Info("Execution completed suceesfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Exceptio:" + e.Message);
        }
            
    }
    
    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        Console.WriteLine("Issue here");
        ExtentService.GetExtent().Flush();
    }

}