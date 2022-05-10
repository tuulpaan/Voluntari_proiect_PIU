using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieVoluntari;
using AdministrareVoluntari;
using LibrarieDate;
using AdministrareDate;
namespace Korina
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisier = ConfigurationManager.AppSettings.Get("numeFisier");
            AdmVol admVol = new AdmVol(numeFisier);
      
            int nrVoluntari = 0;
            int idVoluntari = 0;
            int nrDate = 0;
            int idDate = 0;
            string nume, prenume, varsta;
            string ore, loc, post;

            string optiune;
            do
            {
                Console.WriteLine("F. Afisare voluntari din fisier");
                Console.WriteLine("S. Salvare voluntari in fisier");
                Console.WriteLine("C. Citire date de la tastatura");
                Console.WriteLine("L. Cauta voluntari dupa nume.");
                Console.WriteLine("X. Inchidere program");
                Console.Write("Alegeti o optiune: ");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "F":
                        Voluntari[] voluntari = admVol.GetVoluntari(out nrVoluntari);
                        afisareVoluntari(voluntari, nrVoluntari);
                        break;
                    case "S":
                        idVoluntari = nrVoluntari + 1;
                        nrVoluntari += 1;

                        Voluntari voluntari_ = new Voluntari(idVoluntari, "Mariana", "Andrei", "18");
                        admVol.AddVoluntar(voluntari_);
                        break;
                    case "C":
                        idVoluntari = nrVoluntari + 1;
                        nrVoluntari += 1;

                        Console.Write("Dati nume: ");
                        nume = Console.ReadLine();
                        Console.Write("Dati prenume: ");
                        prenume = Console.ReadLine();
                        Console.Write("Dati varsta: ");
                        varsta = Console.ReadLine();


                        Voluntari voluntari_tastatura = new Voluntari(idVoluntari, nume, prenume, varsta);
                        admVol.AddVoluntar(voluntari_tastatura);
                        break;
                    case "L":
                        Console.Write("Dati nume: ");
                        nume = Console.ReadLine();
                        Console.Write("Dati prenume: ");
                        prenume = Console.ReadLine();
                        Console.Write("Dati varsta: ");
                        varsta = Console.ReadLine();

                        Voluntari voluntar_cautat = admVol.GetVoluntar(nume, prenume, varsta);
                        if(string.IsNullOrEmpty(voluntar_cautat.GetNumeVoluntar()) && string.IsNullOrEmpty(voluntar_cautat.GetPrenumeVoluntar()) && string.IsNullOrEmpty(voluntar_cautat.GetVarstaVoluntar()))
                        {
                            Console.WriteLine("Nu exista voluntarul in baza de date\n");
                        }
                        else
                        {

                            string info_voluntar_cautat = string.Format("Voluntarul cu numele {2}  {3} si varsta {1} are id-ul {0}\n",
                                voluntar_cautat.GetIDVoluntar(), voluntar_cautat.GetNumeVoluntar(), voluntar_cautat.GetPrenumeVoluntar(), voluntar_cautat.GetVarstaVoluntar());
                            Console.WriteLine(info_voluntar_cautat);
                        }
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Nu exista aceasta optiune, va rug selectati o optiune valida\n");
                        break;
                }
            }
            while (optiune.ToUpper() != "X");
        }
        public static void afisareVoluntari(Voluntari[] voluntari, int nrVoluntari)
        {

            Console.WriteLine("Voluntarii sunt:");
            for (int contor = 0; contor < nrVoluntari; contor++)
            {
                string infoVoluntar = string.Format("Voluntarul cu id-ul #{0} si numele {2}  {3} are varsta {1}",
                    voluntari[contor].GetIDVoluntar(),
                    voluntari[contor].GetNumeVoluntar(),
                    voluntari[contor].GetPrenumeVoluntar(),
                     voluntari[contor].GetVarstaVoluntar());
                Console.WriteLine(infoVoluntar);

            }
        }
    }
}
