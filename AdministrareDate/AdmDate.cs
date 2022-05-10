using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieDate;

namespace AdministrareDate
{
    public class AdmDate
    {
        private const int NR_MAX_DATE = 40;
        private string numeFisierDate;

        public AdmDate(string numeFisierDate)
        {

            this.numeFisierDate = numeFisierDate;
            Stream streamFisierText = File.Open(numeFisierDate, FileMode.OpenOrCreate);
            streamFisierText.Close();


        }

        public void AddVoluntar(Date date)
        {

            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierDate, true))
            {
                streamWriterFisierText.WriteLine(date.ConversieFisierTextDate());
            }

        }
        public Date[] GetDate(out int nrDate)
        {

            Date[] date = new Date[NR_MAX_DATE];
            using (StreamReader streamReader = new StreamReader(numeFisierDate))
            {
                string linieFisierDate;
                nrDate = 0;
                while ((linieFisierDate = streamReader.ReadLine()) != null)
                {
                    date[nrDate++] = new Date(linieFisierDate);
                }
            }
            return date;

        }


 
        public Date  GetData(string ore, string loc, string post)
        {
            Date date;
            using (StreamReader streamReader = new StreamReader(numeFisierDate))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    date = new Date(linieFisier);
                    if (date.GetOreDate() == ore && date.GetLocDate() == loc && date.GetPostDate() == post)
                        return date;
                }
            }
            Date date_invalide = new Date();
            return date_invalide;
        }
    }
 }
