using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceModel.Syndication;
using System.Web;

namespace AtomProducer.Models
{
    public class PersonChange : SyndicationItem
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        public PersonChange()
        {
            
        }
    }
}