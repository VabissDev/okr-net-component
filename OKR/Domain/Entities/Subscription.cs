using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Entities
{
    [Table("Subscription")]
    public class Subscription
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public DateTime StartTime { get; set; }
        [Column]
        public DateTime EndTime { get; set; }
        [Column]
        public bool Active { get; set; }
    }
}
