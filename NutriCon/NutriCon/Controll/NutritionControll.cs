using NutriCon.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriCon.Controll
{
    class NutritionControll
    {
        internal double izracunBMI(MesurmentModel msr)
        {
            double visina = preracunVisineMetre(msr);
            msr.itm = (msr.tezina / (visina * visina));
            return msr.itm;
        }

        private double preracunVisineMetre(MesurmentModel msr)
        {
            return (msr.visina / 100.00);
        }

        internal string dodajBmiKomentar(MesurmentModel msr)
        {
            string ispis = "";
            if (msr.itm < 18.5)
            {
                ispis = "Pothranjeni ste!";
            }
            else if (msr.itm >= 18.5 && msr.itm <= 24.9)
            {
                ispis = "Uravnotežena tjelesna masa!";
            }
            else if (msr.itm >= 25 && msr.itm <= 29.9)
            {
                ispis = "Prekomjerna tjelesna masa!";
            }
            else if (msr.itm >= 30 && msr.itm <= 34.9)
            {
                ispis = "Gojaznost (oblik 1)!";
            }
            else if (msr.itm >= 35 && msr.itm <= 39.9)
            {
                ispis = "Gojaznost (oblik 2)!";
            }
            else if (msr.itm >= 40)
            {
                ispis = "Gojaznost (oblik 3)!";
            }
            return ispis;
        }

        internal double izracunIdealneTjelesneMase(MesurmentModel msr)
        {

            int dob = izracunGodina(msr);
            
            if (msr.UserModel.Gender=="M")
            {
                msr.idelnaTjelesnaMasa = (msr.visina - 100.00) - (msr.visina - 150) / 4 + (dob - 20) / 4;

            }
            else if (msr.UserModel.Gender == "F")
            {
                msr.idelnaTjelesnaMasa = (msr.visina - 100) - (msr.visina - 150) / 2.5 + (dob - 20) / 4;
            }

            return msr.idelnaTjelesnaMasa;
        }

        private int izracunGodina(MesurmentModel msr)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - msr.UserModel.Birthday.Year;
            if (now < msr.UserModel.Birthday.AddYears(age)) age--;
            return age;
        }

        internal double izracunEer(MesurmentModel msr)
        {

            int dob = izracunGodina(msr);
            double pa = 0.00;
            double visina = preracunVisineMetre(msr);

            if (msr.UserModel.Gender == "M")
            {
                if (msr.dnevnaAktivnost==0)
                {
                    pa = 1.0;
                }
                else if (msr.dnevnaAktivnost == 1)
                {
                    pa = 1.11;
                }
                else if (msr.dnevnaAktivnost == 2)
                {
                    pa = 1.25;
                }
                else if (msr.dnevnaAktivnost == 3)
                {
                    pa = 1.48;
                }

                msr.eer = 661.8 - (9.53 * dob) + pa * (15.91 * msr.tezina + 539.6 * visina);

            }
            else if (msr.UserModel.Gender == "F")
            {
                if (msr.dnevnaAktivnost == 0)
                {
                    pa = 1.0;
                }
                else if (msr.dnevnaAktivnost == 1)
                {
                    pa = 1.12;
                }
                else if (msr.dnevnaAktivnost == 2)
                {
                    pa = 1.27;
                }
                else if (msr.dnevnaAktivnost == 3)
                {
                    pa = 1.45;
                }

                msr.eer = 354.1 - (6.91 * dob) + pa * (9.36 * msr.tezina + 726 * visina);
            }
            return msr.eer;
        }

        internal double izracunWhr(MesurmentModel msr)
        {
            msr.whr = ((msr.opsegStruka*1.00) / (msr.opsegBokova*1.00));
            return msr.whr;
        }

        internal string dodajWhrKomentar(MesurmentModel msr)
        {
            string coment = "";
            if (msr.UserModel.Gender == "M")
            {
                if (msr.whr <= 0.95)
                {
                    coment = "Nizak rizik";
                }
                else if (msr.whr > 0.95 && msr.whr < 1)
                {
                    coment = "Umjereni rizik";
                }
                else if (msr.whr >= 1)
                {
                    coment = "Visok rizik";
                }
            }
            else if (msr.UserModel.Gender == "F")
            {
                if (msr.whr <= 0.80)
                {
                    coment = "Nizak rizik";
                }
                else if (msr.whr > 0.80 && msr.whr < 0.84)
                {
                    coment = "Umjereni rizik";
                }
                else if (msr.whr >= 0.84)
                {
                    coment = "Visok rizik";
                }
            }
            return coment;
        }
    }
}
