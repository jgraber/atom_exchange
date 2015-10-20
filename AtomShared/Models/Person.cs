using System.ServiceModel;

namespace AtomShared.Models
{
    public class Person
    {   
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}