using LottoAdatKapcsolat.Data;
using LottoAdatKapcsolat.Models;
using System;
using System.IO;


namespace LottoAdatFeltoltes
{
    class Program
    {
        static void Main(string[] args)
        {
            LottoSzamContext db = new LottoSzamContext();
            if (!db.LottoSzamok.Any())
            {
                string[] sorok = File.ReadAllLines(@"C:\Users\Admin\Desktop\JagerStaff\LeadniApr10\Lotto\Szamok\SkandinavLottoSzamok.csv");
                LottoSzam lsz = null;
                foreach (string sor in sorok)
                {
                    bool sikerult = true;
                    try
                    {
                        lsz = new LottoSzam(sor);
                    }
                    catch (Exception)
                    {
                        sikerult = false;
                    }
                    if (sikerult) db.LottoSzamok.Add(lsz);
                }
                db.SaveChanges();
            }
        }
    }
}