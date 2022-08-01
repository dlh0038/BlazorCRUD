using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("userdetails");
                entity.Property(e => e.Userid).HasColumnName("Userid");
                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Cellnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // private List<User> GetUsers()
        // {
        //     return new List<User>
        // {
        //     new User {
        //             Username: "Christine Bailey",
        //             Address: "536 Canal Road",
        //             Cellnumber: "5186063672",
        //             Emailid: "Christine.Bailey@hotmail.com"
        //         },
        //     new User {
        //             Username: "Angela James",
        //             Address: "278 Seacoast Lane",
        //             Cellnumber: "3561116605",
        //             Emailid: "Angela.James@hotmail.com"
        //         },
        //     new User {
        //             Username: "Michelle Edwards",
        //             Address: "491 Hazelnut Lane",
        //             Cellnumber: "7079721503",
        //             Emailid: "Michelle.Edwards@hotmail.com"
        //         },
        //     new User {
        //             Username: "Jacob Cooper",
        //             Address: "184 Revolution Passage",
        //             Cellnumber: "6513669275",
        //             Emailid: "Jacob.Cooper@hotmail.com"
        //         },
        //     new User {
        //             Username: "Sophia Garcia",
        //             Address: "352 Lowland Lane",
        //             Cellnumber: "6120421972",
        //             Emailid: "Sophia.Garcia@hotmail.com"
        //         },
        //     new User {
        //             Username: "Rebecca Carter",
        //             Address: "651 Blessing Avenue",
        //             Cellnumber: "4795876196",
        //             Emailid: "Rebecca.Carter@hotmail.com"
        //         },
        //     new User {
        //             Username: "Eugene Sanchez",
        //             Address: "607 Station Avenue",
        //             Cellnumber: "4112123006",
        //             Emailid: "Eugene.Sanchez@hotmail.com"
        //         },
        //     new User {
        //             Username: "Brandon Wood",
        //             Address: "477 Alfred Cottages",
        //             Cellnumber: "5468157084",
        //             Emailid: "Brandon.Wood@hotmail.com"
        //         },
        //     new User {
        //             Username: "Gabriel Green",
        //             Address: "650 Pioneer Way",
        //             Cellnumber: "1447263557",
        //             Emailid: "Gabriel.Green@hotmail.com"
        //         },
        //     new User {
        //             Username: "Ann Cox",
        //             Address: "712 Prospect Avenue",
        //             Cellnumber: "8690584530",
        //             Emailid: "Ann.Cox@hotmail.com"
        //         }
            
        // };
        // }
    }
}