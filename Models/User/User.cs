using System;
using System.Collections.Generic;
using System.Data;

namespace Models.User
{
    public class User
    {
        private string _id;
        private string _pw;

        public User()
        {
        }

        public User(string id, string pw)
        {
            this._id = id;
            this._pw = pw;
        }

        public string Id { get => _id; set => _id = value; }
        public string Pw { get => _pw; set => _pw = value; }

        public static List<User> GenerateUsers(DataTable dt)
        {
            List<User> result = new List<User>();
            try
            {
                foreach (DataRow item in dt.Rows)
                {
                    result.Add(new User(item["id"].ToString(), item["pw"].ToString()));
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
