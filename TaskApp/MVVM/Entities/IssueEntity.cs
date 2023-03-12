using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Entities
{
    internal class IssueEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Topic { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;

        [Column(TypeName = "char(1)")]
        public int Status { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<CommentEntity> Comments { get; set; }

        public int ContactId { get; set; }
        public ContactEntity Contact { get; set; } = null!;
    }
}
