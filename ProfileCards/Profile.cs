using System;
namespace ProfileCards
{
    public class Profile
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }

        public Profile(string name, string mail, string phone, string picture)
        {
            Name = name;
            Mail = mail;
            Phone = phone;
            Picture = picture;
        }
    }
}
