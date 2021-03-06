using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContext: DbContext
    {
        public DBContext() : base("DrugProj6")
        {

        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

    
    }
}
