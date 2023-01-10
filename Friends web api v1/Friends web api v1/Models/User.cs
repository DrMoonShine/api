
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends_web_api_v1.Models
{
    public class User 
    {
        public int Id { get; set; } 
        public string NickName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PhoneNumber{ get; set; }
        public string Email { get; set; }   
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string? VkLink { get; set; }
        public string? TgLink { get; set; }
        public string? Discription { get; set; }
       
    }
}
