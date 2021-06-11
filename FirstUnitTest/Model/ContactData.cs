using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class ContactData : IComparable<ContactData>
    {
        public ContactData()
        {
            Name = "";
            Surname = "";
            Address = "";
        }
        public ContactData(string name, string surname, string address)
        {
            Name = name;
            Surname = surname;
            Address = address;
        }
        public ContactData(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }

        int IComparable<ContactData>.CompareTo(ContactData other)
        {
            return Id.CompareTo(other.Id);
        }
        public override bool Equals(object contact)
        {
            var toCompareWith = contact as ContactData;
            if (toCompareWith == null)
                return false;
            return
                this.Id == toCompareWith.Id &&
                this.Name == toCompareWith.Name &&
                this.Surname == toCompareWith.Surname &&
                this.Address == toCompareWith.Address;
        }
    }
}
