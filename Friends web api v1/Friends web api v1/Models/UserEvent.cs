using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//модель описывающая таблицу "События"
namespace Friends_web_api_v1.Models
{
    public class UserEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DateStart { get; set; }
        public string Creator { get; set; }
        public string Status { get; set; }
        public int? SumUsers { get; set; }
        public int? Age { get; set; }
        public List<Tag>? tags { get; set; }
        
    }
}
