using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Friends_web_api_v1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public List<UserEvent> UserEvent{ get; set; }
        public string Name { get; set; }
    }
}
