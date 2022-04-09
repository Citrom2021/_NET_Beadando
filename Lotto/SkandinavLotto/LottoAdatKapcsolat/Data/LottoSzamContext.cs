using LottoAdatKapcsolat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoAdatKapcsolat.Data
{
    public class LottoSzamContext :DbContext
    {
        public DbSet<LottoSzam> LottoSzamok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP;Database=SkandinavLotto;Trusted_Connection=true");
        }
    }
}
