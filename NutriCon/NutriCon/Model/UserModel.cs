using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriCon.Model
{
    class UserModel
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        string oib;
        public string Oib
        {
            get { return oib; }
            set { oib = value; }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
