using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTTP_WEB_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DoTask();
            Thread.Sleep(5000);
        }

        async static void DoTask()
        {

            HttpWebRequest reqw =
                (HttpWebRequest)HttpWebRequest.Create("https://ru.wikipedia.org/wiki/%D0%92%D1%81%D0%BF%D1%8B%D1%88%D0%BA%D0%B0_COVID-19");
            HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse(); //создаем объект отклика
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(resp.GetResponseStream());
            //Console.WriteLine(document.DocumentElement.OuterHtml);
            IElement tableElement =
                document.QuerySelector("h3:has(> span#Распространение_по_странам_и_территориям) + table > tbody");
            //Console.WriteLine(tableElement.QuerySelector("tbody").InnerHtml);
            int count = 0;
            int totalInfected = 0;
            int totalDead = 0;
            int totalRecovered = 0;
            var rows = tableElement.QuerySelectorAll("tr");
            foreach (var item in rows)
            {
                if (count != 0 && count != rows.Count() - 1)
                {
                    try
                    {
                        //if (!item.Children[0].InnerHtml.Contains("Макао"))
                        //{
                        //    totalInfected +=
                        //    (item.Children[1].InnerHtml != "") ? Int32.Parse(item.Children[1].InnerHtml) : 0;
                        //    totalDead +=
                        //        (item.Children[3].InnerHtml != "") ? Int32.Parse(item.Children[3].InnerHtml) : 0;
                        //    totalRecovered +=
                        //        (item.Children[4].InnerHtml != "") ? Int32.Parse(item.Children[4].InnerHtml) : 0;
                        //}

                        if (count <= 10)
                        {
                            Console.WriteLine(item.Children[1].InnerHtml);
                            totalInfected +=
                                (item.Children[1].InnerHtml != "") ? Int32.Parse(item.Children[1].InnerHtml) : 0;
                            totalDead +=
                                    (item.Children[3].InnerHtml != "") ? Int32.Parse(item.Children[3].InnerHtml) : 0;
                            totalRecovered +=
                                (item.Children[4].InnerHtml != "") ? Int32.Parse(item.Children[4].InnerHtml) : 0;
                        }

                    }
                    catch (Exception)
                    {
                        // throw;
                    }

                    

                    //Console.WriteLine();
                }

                count++;
            }
            Console.WriteLine();
            //Console.WriteLine(totalInfected);
            //Console.WriteLine(totalDead);
            //Console.WriteLine(totalRecovered);

            Console.WriteLine(((double)totalDead / (double)totalInfected) * 100d + " %");
            Console.WriteLine(((double)totalRecovered / (double)totalInfected) * 100d + " %");

            sr.Close();

            /*
            // https://www.fxclub.org/markets/index/nq/
            HttpWebRequest reqw =
                (HttpWebRequest)HttpWebRequest.Create("https://ru.wikipedia.org/wiki/%D0%92%D1%81%D0%BF%D1%8B%D1%88%D0%BA%D0%B0_COVID-19");
            HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse(); //создаем объект отклика
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            //создаем поток для чтения отклика
            // Console.WriteLine(sr.ReadToEnd());
            //string html = sr.ReadToEnd();

            var parser = new HtmlParser();
            var document = parser.ParseDocument(resp.GetResponseStream());
            //Console.WriteLine(document.DocumentElement.OuterHtml);
            IElement tableElement =
                document.QuerySelector("h3:has(> span#Распространение_по_странам_и_территориям) + table");
            Console.WriteLine(tableElement.InnerHtml);

            sr.Close();
             
             */

            // 1
            /*IElement tableElement =
                // document.QuerySelector(".grid-7 > .fx-live-quotes-list");
                document.QuerySelector(".grid-7");
            Console.WriteLine(tableElement.InnerHtml);*/
            /* foreach (var item in tableElement.ChildNodes)
            {
                Console.WriteLine(item);
            } */
        }
    }
}
