using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace Contract
{
    public static class Retry
    {
        public static object DoFirstLevel<T>(Func<T> action, TimeSpan retryInterval, string cityList, int retryCount = 3)
        {
            try
            {
                return DoSecondLevel(action, retryInterval, cityList, retryCount);
            }
            catch (AggregateException aex)
            {
                using (var w = File.AppendText("ExceptionLog.txt"))
                {
                    var builder = new StringBuilder();
                    foreach (var ex in aex.InnerExceptions)
                    {
                        builder.Append(ex.Message + Environment.NewLine);
                    }
                    Logs.Log(builder.ToString(), w);
                }
                return null;
            }
        }

        public static T DoSecondLevel<T>(Func<T> action, TimeSpan retryInterval, string cityList, int retryCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int retry = 0; retry < retryCount; retry++)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                    Thread.Sleep(retryInterval);
                }
            }
            exceptions.Add(new Exception("Not updated city(ies): " + cityList));
            throw new AggregateException(exceptions);
        }

    }
}
