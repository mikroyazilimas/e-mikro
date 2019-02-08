using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace E_Mikro.Library
{
    public class LogProcess
    {
        public Exception Exception { get; set; }
        public string page { get; set; }
        private static readonly object locker = new object();

        public void Create(Exception e)
        {
            WriteLog(e.ToString() + " - " + DateTime.Now.ToString());
        }

        public void WriteLog(string log)
        {
            string path = HttpContext.Current.Server.MapPath("~/App_Data/Logs/log" + DateTime.Now.Date.ToString("MM-dd-yyyy") + ".txt");
            if (!File.Exists(path))
            {
                FileStream stream = File.Create(path);
                using (var tw = new StreamWriter(stream))
                {
                    tw.WriteLine(log);
                    tw.Close();
                }

            }
            else if (File.Exists(path))
            {
                lock (locker)
                {
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(log);
                        tw.Close();
                    }
                }
            }
        }
    }
}