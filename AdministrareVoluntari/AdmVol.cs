using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieVoluntari;

namespace AdministrareVoluntari
{
    public class AdmVol
    {
        private const int NR_MAX_VOLUNTARI = 40;
        private string numeFisier;
    
    
        public AdmVol(string numeFisier)
        {

            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();


        }

        public void AddVoluntar(Voluntari voluntari)
        {

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(voluntari.ConversieFisierText());
            }

        }

        public Voluntari[] GetVoluntari(out int nrVoluntari)
        {

            Voluntari[] voluntari = new Voluntari[NR_MAX_VOLUNTARI];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrVoluntari = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    voluntari[nrVoluntari++] = new Voluntari(linieFisier);
                }
            }
            return voluntari;

        }

        public Voluntari GetVoluntar(string nume, string prenume,string varsta)
        {
            Voluntari voluntari;
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    voluntari = new Voluntari(linieFisier);
                    if (voluntari.GetNumeVoluntar() == nume && voluntari.GetPrenumeVoluntar() == prenume && voluntari.GetVarstaVoluntar() == varsta)
                        return voluntari;
                }
            }
            Voluntari voluntar_invalid = new Voluntari();
            return voluntar_invalid;
        }

    }


}
