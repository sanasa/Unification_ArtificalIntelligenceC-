using Resolution_Probleme.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Resolution_Probleme.Business
{
   public class Base_Connaisance
    {
         

       public  List<Regle> baseREGLES {  get;  set; }
         public List<Fait> baseFAITS {  get; set; }

       
        public Base_Connaisance()
        {
            baseFAITS = new List<Fait>();
            baseREGLES = new List<Regle>();
        }

        public  void creerBaseDeConnaisance(string fileRegles,string fileFait)
        {

           CreerBaseRegles(fileRegles);
           CreerBaseFaits(fileFait);
            Console.WriteLine("ok base de connaince rempli");
            //base de connaisance peuplé

       }

        private  void CreerBaseFaits(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Fait fait;
            foreach (var item in lines)
            {
               String[] l= item.Split(',');
                fait = new Fait() { x = l[0], y = l[1] };
                baseFAITS.Add(fait);

            }

        }

        private  void CreerBaseRegles(string filePath)
        {
            Operateur o;
            Regle regle;
            string[] lines = File.ReadAllLines(filePath);
            string[] ligne;
            String[] l;
            #region 
            foreach (var item in lines)
            {
                regle = new Regle();
                ligne = item.Split(':');
                regle.numero = Int32.Parse(ligne[0]);
                string[] j = new string[2];
                Fait fait;
                String[] m;
                
                //ligne[1]
                foreach (var i in ligne[1].Split(' '))
                {
                    if (i.Contains(','))
                    {
                        m = i.Split(',');
                        fait = new Fait() { x = m[0], y = m[1] };
                        regle.premisses.Add(fait);
                    }
                    else
                    {
                        o = new Operateur();
                         if (i.Contains("<=")) { j = i.Split(new[] { "<=" }, StringSplitOptions.None); o.operateur = "<="; }
                        else if (i.Contains(">=")) { j = i.Split(new[] { ">=" }, StringSplitOptions.None); o.operateur = ">="; }
                        else if (i.Contains("<")) { j = i.Split('<'); o.operateur = "<"; }
                        else if (i.Contains(">")) { j = i.Split('>'); o.operateur = ">"; }
                       
                        else if (i.Contains("=")) { j = i.Split('='); o.operateur = "="; }
                        o.x = j[0];
                        o.y = j[1];
                        regle.contraintes.Add(o);
                    }

                }
                //ligne[2]
               l= ligne[2].Split(',');
                fait = new Fait() { x = l[0], y = l[1] };
                regle.conclusions = fait;

                baseREGLES.Add(regle);
            }
            #endregion
        }

    }
}
