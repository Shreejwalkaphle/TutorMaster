    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class My_DBContext : IdentityDbContext<ApplicationUser>
    {
        public My_DBContext(DbContextOptions<My_DBContext> options)
        : base(options)
        {
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//yo method lai override garnaparcha connection string pathauna lai
         {
             base.OnConfiguring(optionsBuilder);
             *//*optionsBuilder.UseSqlServer("TutorMasterDatabaseConnection");*//*//yo method ma connection string pathauni
                                                                                                                  // base.OnConfiguring(optionsBuilder);
         }*/


        public DbSet<Student_tbl> Student_tbl { get; set; }
        public DbSet<RatingViewModel> RatingViewModels { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TeacherAndSubject> TeacherAndSubject { get; set; }
    
       /* public DbSet<Teacher_tbl> Teacher_tbl { get; set; }*/



    }
    public class Student_tbl
    {
        //garnaiparcha key bhanera define natra error aucha
        public String fullname { get; set; }
        public String userName { get; set; }
        public String email { get; set; }
        [Key]
        public String phoneNumber { get; set; }
        public String passwords { get; set; }
        public String confirmpasswords { get; set; }
        public String gender { get; set; }
    }

    public class Teacher_tbl
    {
        public String fullname { get; set; }
        public String userName { get; set; }
        public String email { get; set; }
        [Key]
        public String phoneNumber { get; set; }
        public String password { get; set; }
        public String confirmpassword { get; set; }
        public String gender { get; set; }
    }
}
