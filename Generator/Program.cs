using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            if (type == "groups")
            {
                GenerateForGroups(count, filename, format);
            }
            else if (type == "contacts")
            {
                GenerateForContacts(count, filename, format);
            }
            else
            {
                System.Console.Out.Write("Unrecognized type of data" + type);
            }
        }
        public static Random rnd = new Random();
        //здесь определяется правило, по которому будет генерироваться строка, можно ее редактировать, как хотите
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                //builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
                builder.Append(letters[rnd.Next(0, letters.Length - 1)]);
            }
            return builder.ToString();
        }

        static void GenerateForGroups(int count, string filename, string format)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(10))
                {
                    Header = GenerateRandomString(20),
                    Footer = GenerateRandomString(20)
                });
            }
            StreamWriter writer = new StreamWriter(filename);
            if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);

            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void GenerateForContacts(int count, string filename, string format)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    Address = GenerateRandomString(20)
                });
            }
            StreamWriter writer = new StreamWriter(filename);
            if (format == "xml")
                WriteContactsToXmlFile(contacts, writer);
            else
                System.Console.Out.Write("Unrecognized format " + format);
            writer.Close();
        }
        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}
