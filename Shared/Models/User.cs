using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared.Models
{
    public class User
    {
        public int Userid { get; set; }
        public string DateAdded { get; set; }
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
        public string Username { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City {get; set;} = null!;
        public string State {get; set;} = null!;
        public string Zip {get; set;} = null!;
        public string Cellnumber { get; set; } = null!;
        public string Emailid { get; set; } = null!;
    }
}