using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Setting()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = "ayshen";
        }
    }
}
