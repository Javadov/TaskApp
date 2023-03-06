using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Models
{
    internal class IssueModel
    {
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public CommentModel Comment { get; set; } = new CommentModel();
    }
}