using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoSFService.Model
{
    [Table("ContactTbl", Schema = "dbo")]
    public class Contact
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public byte gender
        {
            get;
            set;
        }
        public DateTime? birth
        {
            get;
            set;
        }
        public string techno
        {
            get;
            set;
        }
        public string message
        {
            get;
            set;
        }
    }
}
