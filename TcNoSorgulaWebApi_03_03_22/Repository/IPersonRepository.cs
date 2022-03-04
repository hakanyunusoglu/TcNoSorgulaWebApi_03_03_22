using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcNoSorgulaWebApi_03_03_22.Models;

namespace TcNoSorgulaWebApi_03_03_22.Repository
{
    public interface IPersonRepository/*<T> where T : class, new()*/
    { 
        void CreateTcNoHash(string tcNo, out byte[] tcNoHash, out byte[] tcNoSalt);
        void CreatePerson(Person person);
        bool VerifyTcNoHash(string tcNo, byte[] tcNoHash, byte[] tcNoSalt);
    }
}
