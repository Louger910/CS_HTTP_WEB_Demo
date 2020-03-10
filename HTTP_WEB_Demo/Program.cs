using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_WEB_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest reqw =
                (HttpWebRequest)HttpWebRequest.Create("https://www.fxclub.org/markets/index/nq/");
            HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse(); //создаем объект отклика
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            //создаем поток для чтения отклика
            Console.WriteLine(sr.ReadToEnd());
            //вывести на экран все, что читается
            sr.Close();
        }
    }
}
