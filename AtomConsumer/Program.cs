using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AtomConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Atom10FeedFormatter formatter = new Atom10FeedFormatter();
            using (XmlReader reader = XmlReader.Create("http://improveandrepeat.com/feed/atom/"))
            {
                formatter.ReadFrom(reader);
            }

            foreach (SyndicationItem item in formatter.Feed.Items)
            {
                Console.WriteLine("[{0}][{1}] {2}", item.PublishDate, item.Title.Text, item.Links.First().Uri);
            }

            Console.ReadLine();
        }
    }
}
