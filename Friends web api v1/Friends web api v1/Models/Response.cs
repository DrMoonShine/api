using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Friends_web_api_v1.Models
{
    public class Response
    {
        public int Id { get; set; }
        public int UserEventId { get; set; }
        [ForeignKey("UserEventId")]
        public UserEvent? UserEvent { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public string Type { get; set; }
    }
}
