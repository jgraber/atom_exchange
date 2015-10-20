using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;
using Newtonsoft.Json;

namespace AtomShared.Models
{
    public class PersonChange : SyndicationItem
    {
        private string _personNamespace = "AtomExchange.Person";
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Person Person { get; set; }
        
        public PersonChange()
        {

        }

        public PersonChange(Person person)
        {
            LastName = person.LastName;
            FirstName = person.FirstName;
            PersonId = person.Id;
            Person = person;
        }

        protected override bool TryParseElement(XmlReader reader, string version)
        {
            if (reader.LocalName.Equals("LastName") &&
                reader.NamespaceURI.Equals(_personNamespace))
            {
                LastName = reader.Value;
                return true;
            }
            if (reader.LocalName.Equals("FirstName") &&
                reader.NamespaceURI.Equals(_personNamespace))
            {
                FirstName = reader.Value;
                return true;
            }
            if (reader.LocalName.Equals("PersonId") &&
                reader.NamespaceURI.Equals(_personNamespace))
            {
                int id;
                Int32.TryParse(reader.Value, out id);
                PersonId = id;
                return true;
            }
            return base.TryParseElement(reader, version);
        }


        protected override void WriteElementExtensions(XmlWriter writer, string version)
        {
            ElementExtensions.Add("PersonId", _personNamespace, PersonId);
            ElementExtensions.Add("LastName", _personNamespace, LastName);
            ElementExtensions.Add("FirstName", _personNamespace, FirstName);
            ElementExtensions.Add("Person", _personNamespace, JsonConvert.SerializeObject(Person));

            base.WriteElementExtensions(writer, version);
        }
    }
}