using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Entities
{
    internal class CommentEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int IssueId { get; set; }
    }
}
