using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Xamarin.Forms;

namespace SkDemo1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime ProjectDate { get; set; }

    }
}
