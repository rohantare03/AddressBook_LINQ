using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinq
{
    public class AddressBook
    {
        DataTable dataTable = new DataTable();
        public AddressBook()
        {          
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));
        }
        public void AddContact()
        {
            dataTable.Rows.Add("Rohan", "Tare", "Virar", "Mumbai", "Maharashtra", 401305, 9845798243, "rohan@gmail.com");
            dataTable.Rows.Add("Kylie", "Jenner", "Vasai", "Mumbai", "Maharashtra", 387235, 9487536343, "kylie@gmail.com");
            dataTable.Rows.Add("Hades", "Wrath", "Street707", "Miami", "Florida", 387544, 3985748965, "hades@gmail.com");
            dataTable.Rows.Add("Steve", "Jobbs", "Beverlyhills", "Sanfransico", "Newyork", 598489, 8379345945, "jobbs@gmail.com");
            dataTable.Rows.Add("Kenny", "Jenner", "Bandra", "Mumbai", "Maharashtra", 736826, 9458944446, "kenny@gmail.com");
            Console.WriteLine("Contact is Added");
        }
        public void DisplayContacts()
        {
            foreach (var contact in dataTable.AsEnumerable())
            {
                Console.WriteLine("FirstName:" + contact.Field<string>("FirstName"));
                Console.WriteLine("LastName:" + contact.Field<string>("LastName"));
                Console.WriteLine("Address:" + contact.Field<string>("Address"));
                Console.WriteLine("City:" + contact.Field<string>("City"));
                Console.WriteLine("State:" + contact.Field<string>("State"));
                Console.WriteLine("ZipCode:" + contact.Field<int>("Zip"));
                Console.WriteLine("PhoneNumber:" + contact.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:" + contact.Field<string>("Email"));
            }
        }
        public string EditContact()
        {
            string details = "";
            AddContact();
            var contacts = dataTable.AsEnumerable().Where(r => r.Field<string>("FirstName") == "Hades");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var contact in contacts)
                {
                    details += contact.Field<string>("FirstName");
                    contact.SetField("LastName", "Death");
                    contact.SetField("City", "Noida");
                    contact.SetField("State", "Delhi");
                    contact.SetField("Zip", 400002);
                }
                Console.WriteLine("Contact is Updated");
                DisplayContacts();
            }
            else
            {
                Console.WriteLine("Contact not Found.");
            }
            return details;
        }
    }
}
