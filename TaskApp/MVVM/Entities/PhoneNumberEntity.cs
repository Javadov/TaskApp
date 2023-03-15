using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Entities
{
    internal class PhoneNumberEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }
    }
}
