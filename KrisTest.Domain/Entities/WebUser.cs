using KrisTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class WebUser
    {
        public int login_id { get; set; }
        public string password { get; set; }
        public UserState state { get; set; }
    }
}
