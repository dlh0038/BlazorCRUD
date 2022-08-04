using System.Security.Cryptography;
using System.Text;
using BlazorCRUD.Server.Interfaces;
using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Services
{
    public class UserManager : IUser
    {
        readonly ApplicationDBContext _dbContext = new();
        public UserManager(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all user details
        public List<User> GetUserDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public void AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //add a random user to the DB
        public string AddRandomUser()
        {
            Random rand = new Random();
            User randuser = new();
            string[] firstNames = {"James", "Robert", "John", "Michael", "David", "William", "Richard", "Joseph", "Thomas", "Charles", "Christopher", "Daniel", "Matthew", "Anthony", "Mark", "Donald", "Steven", "Paul", "Andrew", "Joshua", "Kenneth", "Kevin", "Brian", "George", "Timothy", "Ronald", "Edward", "Jason", "Jeffrey", "Ryan", "Jacob", "Gary", "Nicholas", "Eric", "Jonathan", "Stephen", "Larry", "Justin", "Scott", "Brandon", "Benjamin", "Samuel", "Gregory", "Alexander", "Frank", "Patrick", "Raymond", "Jack", "Dennis", "Jerry", "Tyler", "Aaron", "Jose", "Adam", "Nathan", "Henry", "Douglas", "Zachary", "Peter", "Kyle", "Ethan", "Walter", "Noah", "Jeremy", "Christian", "Keith", "Roger", "Terry", "Gerald", "Harold", "Sean", "Austin", "Carl", "Arthur", "Lawrence", "Dylan", "Jesse", "Jordan", "Bryan", "Billy", "Joe", "Bruce", "Gabriel", "Logan", "Albert", "Willie", "Alan", "Juan", "Wayne", "Elijah", "Randy", "Roy", "Vincent", "Ralph", "Eugene", "Russell", "Bobby", "Mason", "Philip", "Louis", "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Barbara", "Susan", "Jessica", "Sarah", "Karen", "Lisa", "Nancy", "Betty", "Margaret", "Sandra", "Ashley", "Kimberly", "Emily", "Donna", "Michelle", "Carol", "Amanda", "Dorothy", "Melissa", "Deborah", "Stephanie", "Rebecca", "Sharon", "Laura", "Cynthia", "Kathleen", "Amy", "Angela", "Shirley", "Anna", "Brenda", "Pamela", "Emma", "Nicole", "Helen", "Samantha", "Katherine", "Christine", "Debra", "Rachel", "Carolyn", "Janet", "Catherine", "Maria", "Heather", "Diane", "Ruth", "Julie", "Olivia", "Joyce", "Virginia", "Victoria", "Kelly", "Lauren", "Christina", "Joan", "Evelyn", "Judith", "Megan", "Andrea", "Cheryl", "Hannah", "Jacqueline", "Martha", "Gloria", "Teresa", "Ann", "Sara", "Madison", "Frances", "Kathryn", "Janice", "Jean", "Abigail", "Alice", "Julia", "Judy", "Sophia", "Grace", "Denise", "Amber", "Doris", "Marilyn", "Danielle", "Beverly", "Isabella", "Theresa", "Diana", "Natalie", "Brittany", "Charlotte", "Marie", "Kayla", "Alexis", "Lori"};
            string[] lastNames = {"Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Hernandez", "Lopez", "Gonzales", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson", "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores", "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts", "Gomez", "Phillips", "Evans", "Turner", "Diaz", "Parker", "Cruz", "Edwards", "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy", "Cook", "Rogers", "Gutierrez", "Ortiz", "Morgan", "Cooper", "Peterson", "Bailey", "Reed", "Kelly", "Howard", "Ramos", "Kim", "Cox", "Ward", "Richardson", "Watson", "Brooks", "Chavez", "Wood", "James", "Bennet", "Gray", "Mendoza", "Ruiz", "Hughes", "Price", "Alvarez", "Castillo", "Sanders", "Patel", "Myers", "Long", "Ross", "Foster", "Jimenez"};
            string[] domains = {"hetnet", "rediffmail", "web", "home", "free", "planet", "comcast", "libero", "live", "uol", "tin", "att", "sky", "zonnet", "sympatico", "virgilio", "centurytel", "wanadoo", "rocketmail", "arcor", "aliceadsl", "mail", "t-online", "freenet", "yahoo", "facebook", "terra", "bigpond", "telenet", "me", "neuf", "hotmail", "rambler", "verizon", "ymail", "club-internet", "mac", "tiscali", "googlemail", "windstream", "laposte", "chello", "gmx", "voila", "optusnet", "qq", "skynet", "gmail", "bellsouth", "msn", "sfr", "ig", "orange", "juno", "bluewin", "aim", "bol", "outlook", "cox", "ntlworld", "blueyonder", "shaw", "frontiernet", "sbcglobal", "alice", "yandex", "optonline", "aol", "earthlink", "charter"};            
            string[] street = {"Carlton Street", "Winter Way", "Conduit Street", "Cambridge Place", "Queen Route", "North Route", "Fletcher Route", "Long Avenue", "Crown Street", "Jewel Passage", "Blessing Avenue", "Parkside Row", "Art Lane", "Steam Avenue", "Anchor Avenue", "Station Avenue", "Hawthorn Avenue", "Princess Lane", "University Boulevard", "Bridgeway Row", "Bury Passage", "Alfred’s Place (Paul’s Alley)", "Campbell Road", "Adams Mews", "Farmer Way", "Fleet Passage", "Ferry Street", "Vine Route", "Crescent Route", "Canning Place", "Water Street", "Carey Street", "Circus Avenue", "Coleherne Court (part)", "Pioneer Lane", "Avenue, The, Rojack Road", "Prospect Avenue", "Royalty Passage", "Corporation Way", "Brewer’s Lane","Knight Lane", "Prospect Passage", "Castle Court", "Alexander Street", "Hazelnut Lane", "Quarry Passage", "Gilded Row", "Cambridge Terrace", "Silver Avenue", "Ember Avenue", "Coleman Street (E. part)", "Willow Way", "Bolton Road", "Champion Street", "Hawthorn Way", "Dew Passage", "Moon Street", "Campus Lane", "Vale Lane", "Coastline Avenue", "Sunshine Way", "Seacoast Lane", "Colonel Street", "Lowland Row", "Guild Street", "Highland Passage", "Bright Avenue", "Theater Street", "Winter Avenue", "Maple Boulevard", "Poplar Avenue", "University Avenue", "Albion Mews", "Starlight Lane", "Claremont Place", "Bedford Street", "Canal Road", "Aurora Passage", "Chester Mews North", "Cherry Route", "Circus Route", "Clayton Street", "Hill Route", "Lowland Lane", "Pioneer Way", "Alfred Cottages", "Abingdon Street", "Ebon Street", "Central Avenue", "School Avenue", "Brewhouse Lane", "Chancellor Road", "Albert Cottages", "Mason Lane", "Claremont Terrace", "Clove Lane", "Revolution Passage", "Paradise Passage", "Lily Avenue", "Bell Court", "Baker Passage", "Innovation Lane", "Gilded Lane", "Honor Lane", "Barton Street", "Grace Street", "Chester Place Mews", "Broadway, The, Walham Green", "Marine Way", "Parkside Avenue"};
            string[] city = {"Dayfield", "Beachfield", "Massport Beach", "Snowness", "Millborough", "Julbury", "North Postkarta", "Griffinmouth", "Hamkarta", "Kettletown", "Rockport", "Passborough", "Foxcester", "Pinestead", "Freegrad", "Stoneborough", "Strongport", "Daygrad", "Westborough", "Springburg", "Fishgrad City", "Hamness", "New Eastcaster", "Waltbury", "Costsdol", "Dodgeby", "Readingcester", "Freeborough", "Clamborough", "Freegrad", "Redford", "North Fayburg", "Great Redcester", "Southingborough", "Masshampton", "Westfolk", "Farmfield", "Jamesville", "Sagegrad", "West Pailfolk", "North Eastburgh", "Windale", "Talltown Falls", "Angerton", "Frostley Beach", "Fauxside", "East Millwich", "East Fortborough", "Hosworth", "Baypool", "Hardhampton", "North Oakwich", "Strongside", "Fairland", "West Winterburg", "Princeley", "Starville", "Sandfolk", "Cruxdol", "Dodgeborough", "Jamesstead", "Passkarta", "Lunaburgh Island", "Postdol", "Parkland", "Tallcaster Falls", "Appleburgh", "Dodgecester", "East Middlefield", "Emerfield", "South Capville", "New Wheelham", "Farmingburgh", "South Dodgeburg", "Backmouth", "Frostness Falls", "Saltstead", "Masskarta", "Westmouth", "South Mayley", "Kettletown", "Fishham", "South Tallville", "Pineham", "East Highby", "Lawdol", "Factville", "Dodgeworth Island", "Waltby", "Passmouth", "Weirpool", "Goldburgh Falls", "Rivertown", "Sugarburg", "Winterford", "Queensfield Hills", "Springport", "Great Snowwich", "Starness", "Medland"};
            string[] state = {"AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY", "DC"};

            try
            {
                randuser.DateAdded = DateTime.Now;
                randuser.FirstName = firstNames[rand.Next(0, firstNames.Length)];
                randuser.LastName = lastNames[rand.Next(0, lastNames.Length)];
                randuser.Username = randuser.FirstName[0].ToString() + randuser.LastName;
                randuser.StreetAddress = $"{rand.Next(10,9999).ToString()} {street[rand.Next(0, street.Length)]}";
                randuser.City = $"{city[rand.Next(0,city.Length)]}";
                randuser.State = $"{state[rand.Next(0,state.Length)]}";
                randuser.Zip = rand.Next(10000,99999);
                randuser.Cellnumber = Convert.ToInt64(rand.Next(1,10).ToString()+string.Join("", Enumerable.Range(0,9).Select(x => rand.Next(0,10))));
                //"(" + rand.Next(100, 999).ToString() + ") " + rand.Next(100, 999).ToString() + "-" + rand.Next(1000, 9999).ToString();
                string[] temp = {randuser.FirstName.ToLower()+"."+randuser.LastName.ToLower(), 
                                 randuser.FirstName[0].ToString().ToLower()+randuser.LastName.ToLower()+rand.Next(1, 99).ToString(), 
                                 randuser.FirstName.ToLower()+"_"+randuser.LastName.ToLower()+rand.Next(1, 99).ToString(),
                                 randuser.LastName.ToLower()+randuser.FirstName[0].ToString().ToLower(),
                                 randuser.FirstName.Substring(0,rand.Next(1,randuser.FirstName.Length)).ToLower()+randuser.LastName.ToLower(),
                                 randuser.LastName.ToLower()+randuser.FirstName[0].ToString().ToLower()+rand.Next(1, 99).ToString()
                                 };

                randuser.Emailid = $"{temp[rand.Next(0,temp.Length)]}@{domains[rand.Next(0, domains.Length)]}.com";
                
                randuser.Password = HashPassword("password");
                _dbContext.Users.Add(randuser);
                _dbContext.SaveChanges();
                return randuser.FirstName+" "+randuser.LastName;
            }
            catch
            {
                throw;
            }
        }
        public String HashPassword(String plaintext)
        {
            MD5 md5 = MD5.Create();
            byte[] hashArr = md5.ComputeHash(Encoding.ASCII.GetBytes(plaintext)); //store encrypted password
            return String.Join("", hashArr.ToList().Select(i => i.ToString("X2")));
        }
        //To Update the records of a particluar user
        public void UpdateUserDetails(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular user
        public User GetUserData(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void DeleteUser(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}