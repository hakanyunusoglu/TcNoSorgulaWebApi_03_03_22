using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TcNoSorgulaWebApi_03_03_22.Models
{
    public class DataContext:DbContext
    {


        public DbSet<Person> Persons { get; set; }
    }
}