using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.Entities
{
    internal class PhoneNumberEntity
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public int ContactId { get; set; }
    }
}
