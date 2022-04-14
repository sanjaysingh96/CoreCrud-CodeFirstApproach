
using CoadFirstWithCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoadFirstWithCore.dbdata
{
    public class mydata: DbContext
    {
       
        public mydata(DbContextOptions<mydata> options):base(options)
        {

        }

        public DbSet<Empmodel> Empmodels { get; set; }
    }
}
