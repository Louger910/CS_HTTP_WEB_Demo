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

        async static void DoTask() {
            HttpWebRequest reqw =
                (HttpWebRequest)HttpWebRequest.Create("https://www.fxclub.org/markets/index/nq/");
            HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse(); //создаем объект отклика
            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default);
            //создаем поток для чтения отклика
            // Console.WriteLine(sr.ReadToEnd());
            string html = sr.ReadToEnd();
            //var parser = new HtmlParser();
            //var document = parser.ParseDocument(resp.GetResponseStream());
            /* foreach (IElement element in document.QuerySelectorAll(".grid-7"))
            {
                Console.WriteLine(element);
            } */

            var config = Configuration.Default.WithJavaScript();
            //Create a new context for evaluating webpages with the given config
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(req => req.Content(html));

            Console.WriteLine(document.DocumentElement.OuterHtml);

            // 1
            /*IElement tableElement =
                document.QuerySelector(".grid-7 > .fx-live-quotes-list");
            Console.WriteLine(tableElement.InnerHtml);*/
            /* foreach (var item in tableElement.ChildNodes)
            {
                Console.WriteLine(item);
            } */


            // 2
            /*IHtmlCollection<IElement> rowElements =
                document.QuerySelectorAll(".grid-7 > .fx-live-quotes-list");
            foreach (IElement rowElement in rowElements)
            {
                Console.WriteLine(rowElement);
            }*/

            /* foreach (IElement rowElement in tableElement.ChildNodes)
            {
                Console.WriteLine(rowElement);
            } */
            /* foreach (IElement rowElement in tableElement.QuerySelectorAll("div.style__row___3vaBm"))
            {
                Console.WriteLine(rowElement);
            } */
            //(".style__row___3vaBm")
            //вывести на экран все, что читается
            //sr.Close();
        }
    }
}
