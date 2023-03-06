using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Models
{
    internal class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}
