using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieVoluntari
{
    public class Voluntari
    {

        private const char SEP_Principal_fisier = ';';

        private const int ID = 0;
        private const int VARSTA = 1;
        private const int NUME = 2;
        private const int PRENUME = 3;


        private int idVoluntar;
        private string varsta;
        private string nume;
        private string prenume;

        public Voluntari()
        {

            this.nume = this.prenume = this.varsta =  string.Empty;
            
        }

        public Voluntari(int idVoluntar, string varsta, string nume, string prenume)
        {

            this.idVoluntar = idVoluntar;
            this.varsta = varsta;
            this.nume = nume;
            this.prenume = prenume;

        }

        public Voluntari(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEP_Principal_fisier);
            this.idVoluntar = Convert.ToInt32(dateFisier[ID]);
            this.nume = dateFisier[NUME];
            this.prenume = dateFisier[PRENUME];
            this.varsta = dateFisier[VARSTA];
        }

        public string ConversieFisierText()
        {

            string format_fisierText = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SEP_Principal_fisier,
                idVoluntar.ToString(),
                (nume ?? "NECUNOSCUT"),
                (prenume ?? "NECUNOSCUT"),
                (varsta ?? "NECUNOSCUT"));
            return format_fisierText;

        }

        public int GetIDVoluntar()
        {
            return idVoluntar;
        }
        
        public string  GetNumeVoluntar()
        {

            return nume;

        }

        public string  GetPrenumeVoluntar()
        {

            return prenume;

        }

        public string GetVarstaVoluntar()
        {

            return varsta ;

        }
    }
}
