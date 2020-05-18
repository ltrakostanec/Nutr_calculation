using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriCon.Model
{
    class MesurmentModel
    {
        public virtual UserModel UserModel { get; set; }

        public int UserId { get; set; }
        public int tezina { get; set; }

        public int MesurmentId { get; set; }
        public int visina { get; set; }

        public int dnevnaAktivnost { get; set; }

        public int opsegStruka { get; set; }

        public int opsegBokova { get; set; }

        public DateTime datumMjerenja { get; set; }

        public double itm { get; set; }

        public double eer { get; set; }

        public double whr { get; set; }

        public double idelnaTjelesnaMasa { get; set; }


    }
}
