using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Model
{
    [DataContract]
    public class CustomerPartial
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public double Balance { get; private set; }

        [DataMember]
        public string Password { get; set; }

       public CustomerPartial(string username)
        {
            Username = username;
            Password = PasswordGenerator();
        }

        public CustomerPartial(string username, double balance)
        {
            Username = username;
            Password = PasswordGenerator();
            Balance = balance;
        }

        private string PasswordGenerator()
        {
            var pwd = new Password().LengthRequired(8);
            var result = pwd.Next();
            return result;

        }

   
    }
}
