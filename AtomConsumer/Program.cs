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
            var feedUrl = "http://localhost:7646/Home/Feed/2";
            //var feedUrl = "http://improveandrepeat.com/feed/atom/";

            ReadFeed(feedUrl);

            Console.ReadLine();
        }

        private static void ReadFeed(string feedUrl)
        {
            Atom10FeedFormatter formatter = new Atom10FeedFormatter();
            using (XmlReader reader = XmlReader.Create(feedUrl))
            {
                formatter.ReadFrom(reader);
            }

            foreach (SyndicationItem item in formatter.Feed.Items)
            {
                Console.WriteLine("[{0}][{1}]", item.PublishDate, item.Title.Text);
            }

            var prevArchive = formatter.Feed.Links.FirstOrDefault(l => l.RelationshipType == "prev-archive");
            if (prevArchive != null)
            {
                ReadFeed(prevArchive.Uri.ToString());
            }
        }
    }
}
