using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;

namespace AtomProducer.Models
{
    public class FeedCreator
    {

        public SyndicationFeed CreateFeed()
        {
            // Add example based on the blog post from Rehan Saeed
            // see: http://rehansaeed.com/building-rssatom-feeds-for-asp-net-mvc/

            SyndicationFeed feed = new SyndicationFeed()
            {
                // id (Required) - The feed universally unique identifier.
                Id = "86DDC9F5-11B1-490A-BF61-340605E245B5",
                // title (Required) - Contains a human readable title for the feed. Often the same as the title of the 
                //                    associated website. This value should not be blank.
                Title = SyndicationContent.CreatePlaintextContent("AtomExchange Demo Feed"),
                // items (Required) - The entries to add to the feed. I'll cover how to do this further on.
                Items = this.GetItems(),
                // subtitle (Recommended) - Contains a human-readable description or subtitle for the feed.
                Description = SyndicationContent.CreatePlaintextContent("A basic example of ATOM"),
                // updated (Optional) - Indicates the last time the feed was modified in a significant way.
                LastUpdatedTime = DateTimeOffset.Now
            };

            // self link (Required) - The URL for the syndication feed.
            feed.Links.Add(SyndicationLink.CreateSelfLink(
                new Uri("http://example.com/feed/"), "application/atom+xml"));

            // alternate link (Recommended) - The URL for the web page showing the same data as the syndication feed.
            feed.Links.Add(SyndicationLink.CreateAlternateLink(
                new Uri("http://example.com"), "text/html"));

            return feed;
        }

        private IEnumerable<SyndicationItem> GetItems()
        {
            var entries = new List<SyndicationItem>();
            entries.Add(new SyndicationItem("A", "Person A aus Bern", new Uri("http://example.com/people/123")));

            return entries;
        }
    }
}