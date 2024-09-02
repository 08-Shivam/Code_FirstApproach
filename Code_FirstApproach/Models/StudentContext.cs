using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code_FirstApproach.Models
{
    public class StudentContext : DbContext
    {
       public DbSet<Student> Students { get; set; }
    }
}