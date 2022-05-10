using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieDate
{
    public class Date
    {

        private const char SEP_Principal_fisier_date = ';';
        private const int ID = 0;
        private const int ORE = 1;
        private const int LOC = 2;
        private const int POST = 3;


        private int idDate;
        private string ore;
        private string loc;
        private string post;

        public Date()
        {

            this.ore = this.loc = this.post = string.Empty;

        }

        public Date(int idDate, string ore, string loc, string post)
        {
            this.idDate = idDate;
            this.ore = ore;
            this.loc = loc;
            this.post = post;
            
        }
        public Date(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEP_Principal_fisier_date);
            this.idDate = Convert.ToInt32(dateFisier[ID]);
            this.ore = dateFisier[ORE];
            this.loc = dateFisier[LOC];
            this.post = dateFisier[POST];
        }

        public string ConversieFisierTextDate()
        {

            string format_fisierTextDate = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SEP_Principal_fisier_date,
                idDate.ToString(),
                (ore ?? "NECUNOSCUT"),
                (loc ?? "NECUNOSCUT"),
                (post ?? "NECUNOSCUT"));
            return format_fisierTextDate;

        }

        public int GetIdDate()
        {
            return idDate;
        }
        public string GetOreDate()
        {
            return ore;
        }

        public string GetLocDate()
        {
            return loc;
        }

        public string GetPostDate()
        {
            return post;
        }
    }
}
