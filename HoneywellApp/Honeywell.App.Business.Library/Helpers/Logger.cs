using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Honeywell.App.Business.Library.Helpers
{
    public class Logger
    {
		private static string logFileName = string.Empty;
		private static bool isStarting = true;
		private static string applicatioName = string.Empty;


		public static void Log(string message, [CallerLineNumber] int callerline = 0)
		{
			string logFileLineFormat = "{0} | ClassName: {1} | MethodName:{2} | Line Number: {3} | Message: {4}";
			using (StreamWriter writer = File.AppendText(logFileName))
			{
				if (isStarting)
				{
					writer.WriteLine("====================================================================================");
					writer.WriteLine(DateTime.Now.ToString() + "| ---> Starting " + applicatioName);
					writer.WriteLine("====================================================================================");

					isStarting = false;
				}

				var stackFrame = new StackFrame(1);
				writer.WriteLine(string.Format(logFileLineFormat, DateTime.Now.ToString(),
																	stackFrame.GetMethod().DeclaringType.Name,
																	stackFrame.GetMethod().Name,
																	callerline,
																	message));

			}
		}

		public static void InitiateLogger(string ApplicationName)
		{
			applicatioName = ApplicationName;
			logFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + applicatioName + ".log";
		}
	}
}
