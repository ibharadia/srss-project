using System;
using System.IO;
using System.Xml;

namespace srssTitleGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a URL (Ex. https://www.reddit.com/.rss): ");
            string url = Console.ReadLine();

            Console.Write("Please specify a name for the output file (Ex. RSSfeed.txt): ");
            string filename = Console.ReadLine();

            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filepath = Path.Combine(filepath, filename);

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList elements = doc.GetElementsByTagName("title");

            string[] titles = new string[elements.Count];

            for (int i = 0; i < elements.Count; i++)
            {
                titles[i] = elements[i].InnerXml;
            }
            System.IO.File.WriteAllLines(@filepath, titles);
        }
    }
}
