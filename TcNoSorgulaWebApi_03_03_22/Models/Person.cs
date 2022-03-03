using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TcNoSorgulaWebApi_03_03_22.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        [DisplayName("TcNo")]
        public byte[] TcNumberHash { get; set; }
        public byte[] TcNumberSalt { get; set; }
    }
}