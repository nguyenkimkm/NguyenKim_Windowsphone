using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    class RootObject
    {
        public Meta meta { get; set; }
        public Response response { get; set; }

    }

    public class Meta
    {
        public int code { get; set; }
    }

    public class Contact
    {
        public string phone { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }

    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string address { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public Icon icon { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public List<Category> categories { get; set; }
    }

    public class Response
    {
        public List<Venue> venues { get; set; }
    }

 
}
