using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoAdatKapcsolat.Models
{
    public class LottoSzam
    {
        public int Id { get; set; }
        public int Szam1 { get; set; }
        
        public int Szam2 { get; set; }

        public int Szam3 { get; set; }

        public int Szam4 { get; set; }

        public int Szam5 { get; set; }

        public int Szam6 { get; set; }

        public int Szam7 { get; set; }


        public LottoSzam()
        {
        }

        public LottoSzam(string sor)
        {
            string[] tombSzoveg = sor.Trim().Split(";");
            if (tombSzoveg.Length == 7)  
            {
                int[] tombSzam = new int[14]; 
                for (int i = 0; i < 7; i++) 
                {
                    try
                    {
                        tombSzam[i] = Convert.ToInt32(tombSzoveg[i].Trim());  
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Nem Konvertálható számmá", "sor"); 
                    }
                    if ((tombSzam[i] < 1) || (tombSzam[i] > 35))
                    
                        throw new ArgumentException("A szám nagysága nem oké", "sor");

                }


                HashSet<int> set = new HashSet<int>(tombSzam);
                if(set.Count()!=7) new ArgumentException("Ismétlődés", "sor");

                Szam1 = tombSzam[0];
                Szam2 = tombSzam[1];
                Szam3 = tombSzam[2];
                Szam4 = tombSzam[3];
                Szam5 = tombSzam[4];
                Szam6 = tombSzam[5];
                Szam7 = tombSzam[6];

            }
            else
            {
                throw new ArgumentException("Hibás elemszám","sor");
            }

        }

    }
}
