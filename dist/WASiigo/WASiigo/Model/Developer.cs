using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WASiigo.Model
{
    public class Developer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IsActive { get; set; }
    }
}