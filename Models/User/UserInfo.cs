using System;

namespace Models.User
{
    public class UserInfo
    {
        private string _id;
        private string _name;
        private string _phone;
        private string _address;

        public UserInfo()
        {
        }

        public UserInfo(string id, string name, string phone, string address)
        {
            this._id = id;
            this._name = name;
            this._phone = phone;
            this._address = address;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
    }
}
