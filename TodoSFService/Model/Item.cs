using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoSFService.Model
{
    [Table("ItemTbl", Schema = "dbo")]
    public class Item
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? id
        {
            get;
            set;
        }
        public string taskName
        {
            get;
            set;
        }
        public string taskDesciption
        {
            get;
            set;
        }
        public bool completedTask
        {
            get;
            set;
        }
    }
}
