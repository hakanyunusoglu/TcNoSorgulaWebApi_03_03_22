using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TcNoSorgulaWebApi_03_03_22.Models;

namespace TcNoSorgulaWebApi_03_03_22.Repository
{
    public class PersonRepository<T> : IPersonRepository<T> where T : class, new()
    {
        DataContext db = new DataContext();
        public void CreatePerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public void CreateTcNoHash(string tcNo, out byte[] tcNoHash, out byte[] tcNoSalt)
        {
            var hmac = new System.Security.Cryptography.HMACSHA512();
            tcNoSalt = hmac.Key;
            tcNoHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(tcNo));
        }

        public bool VerifyTcNoHash(string tcNo, byte[] tcNoHash, byte[] tcNoSalt)
        {

            if(db.Persons.ToList().Count() != 0)
            {
                
                foreach (var item in db.Persons.ToList())
                {
                    string a1 = "";
                    string b1 = "";
                    string c1 = "";
                    var hmac = new System.Security.Cryptography.HMACSHA512(item.TcNumberSalt);
                    var computehash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(tcNo));
                    for (int i = 0; i < computehash.Length; i++)
                    {
                        a1 += computehash[i].ToString("X2");
                        b1 += tcNoHash[i].ToString("X2");
                        c1 += item.TcNumberHash[i].ToString("X2");

                        if (a1 == c1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return true;
        }
    }
}