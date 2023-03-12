using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Models
{
    internal class Comment
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public DateTime DateTime { get; set; }
        public string _Comment { get; set; } = string.Empty;
    }
}
