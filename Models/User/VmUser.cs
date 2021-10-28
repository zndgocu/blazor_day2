using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class VmUser
    {
        private string _id;
        private string _pw;
        private string _name;
        private string _phone;
        private string _address;

        public VmUser()
        {
        }

        public VmUser(string id, string pw, string name, string phone, string address)
        {
            this._id = id;
            this._pw = pw;
            this._name = name;
            this._phone = phone;
            this._address = address;
        }

        public VmUser(User user, UserInfo userInfo)
        {
            this._id = user.Id;
            this._pw = user.Pw;
            this._name = userInfo.Name;
            this._phone = userInfo.Phone;
            this._address = userInfo.Address;
        }


        public string Id { get => _id; set => _id = value; }
        public string Pw { get => _pw; set => _pw = value; }
        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
    }
}
