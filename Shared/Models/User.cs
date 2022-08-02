using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Shared.Models
{
    public class User
    {
        public int Userid { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
        public string Username { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City {get; set;} = null!;
        public string State {get; set;} = null!;
        public int Zip {get; set;} 
        public Int64 Cellnumber { get; set; }
        public string Emailid { get; set; } = null!;
    }
}