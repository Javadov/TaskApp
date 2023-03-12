using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskApp.MVVM.Entities;

namespace TaskApp.MVVM.Models
{
    internal class Issue
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime DateTime { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public string DisplayName => $"{FirstName} {LastName}";
    }   
}
