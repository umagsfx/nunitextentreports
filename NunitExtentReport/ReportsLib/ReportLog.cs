using AventStack.ExtentReports;

namespace NunitExtentReport.ReportsLib;

public class ReportLog
{
    public static void Pass(string message)
    {
        ExtentTestManager.GetTest().Pass(message);
    }
    
    public static void Fail(string message, MediaEntityModelProvider media = null)
    {
        ExtentTestManager.GetTest().Fail(message, media);
    }
    
    public static void Skip(string message)
    {
        ExtentTestManager.GetTest().Skip(message);
    }
    
    public static void Info(string message)
    {
        ExtentTestManager.GetTest().Info(message);
    }
}