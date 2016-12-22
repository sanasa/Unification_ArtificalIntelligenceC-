using Resolution_Probleme.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace Resolution_Probleme.Business
{
   public class ResolutionProbleme
    {

        public List<Regle> genereOperateursApplicables(List<Regle> baseRegles, Fait etatcourant)
        {
            List<Regle> resultat = new List<Regle>();
            Regle regleDec;
            StringBuilder modif = new StringBuilder("");
            foreach (var regle in baseRegles)
            {
                if (regle.premisses.Count() == 0)
                {
                    int i = 0;
                    bool test = true;
                    while (i < regle.contraintes.Count() && test)
                    {
                        int x1Res = 0;
                        Operateur op = regle.contraintes[i];
                        #region firstArguement
                        string x1 = op.x;
                        if (x1.Contains("?x")) { x1=x1.Replace("?x", etatcourant.x); modif.Append("?x/" + etatcourant.x+" ");


                        }
                        if (x1.Contains("?y")) { x1=x1.Replace("?y", etatcourant.y); modif.Append("?y/" + etatcourant.y + " ");
                        }

                        #region add

                        if (x1.Contains("+"))
                        {
                            string[] res = x1.Split('+');
                            int a = Int32.Parse(res[0]);
                            int b = Int32.Parse(res[1]);

                            x1Res = a + b;

                        }
                        #endregion
                        else
                        #region substract
                        if (x1.Contains("-"))
                        {
                            string[] res = x1.Split('-');
                            int a = Int32.Parse(res[0]);
                            int b = Int32.Parse(res[1]);

                            x1Res = a - b;

                        }
                        else x1Res = Int32.Parse(x1);
                        #endregion

                        #endregion


                        #region secondArgument
                        int x2Res = 0;
                        string x2 = op.y;

                        if (x2.Contains("?x")) { x2=x2.Replace("?x", etatcourant.x); modif.Append("?x/" + etatcourant.x + " ");

                        }
                        if (x2.Contains("?y")) { x2=x2.Replace("?y", etatcourant.y); modif.Append("?y/" + etatcourant.y + " ");
                           
                        }
                        #region add

                        if (x2.Contains("+"))
                        {
                            string[] res = x2.Split('+');
                            int a = Int32.Parse(res[0]);
                            int b = Int32.Parse(res[1]);

                            x2Res = a + b;

                        }
                        #endregion
                        else
                        #region substract
                        if (x2.Contains("-"))
                        {
                            string[] res = x2.Split('-');
                            int a = Int32.Parse(res[0]);
                            int b = Int32.Parse(res[1]);

                            x2Res = a - b;

                        }
                        else x2Res = Int32.Parse(x2);
                        #endregion

                        switch (regle.contraintes[i].operateur)
                        {
                            case "<": { test = x1Res < x2Res; break; }


                            case ">": { test = x1Res > x2Res; break; }
                            case "<=": { test = x1Res <= x2Res; break; }

                            case ">=": { test = x1Res >= x2Res; break; }
                            case "=": { test = x1Res == x2Res; break; }
                        }
                        #endregion
                        i++;

                    }

                    if (test)
                    {
                        regleDec = new Regle();
                        regleDec.numero = regle.numero;
                        regleDec.modification.Append(modif);
                        //
                        regle.conclusions.x = regle.conclusions.x.Replace("?x", etatcourant.x);
                        regle.conclusions.x = regle.conclusions.x.Replace("?y", etatcourant.y);
                        regle.conclusions.y = regle.conclusions.y.Replace("?x", etatcourant.x);
                        regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y);
                        regleDec.conclusions = changeConclusion(regle);
                        resultat.Add(regleDec);
                    }
                    else if (!test) { Console.WriteLine("R" + regle.numero + " n'est pas declenchable"); }
                }
                else
                {
                    Fait premisee = regle.premisses.First();


                    if (premisee.x == "?x")
                    {
                        modif.Append("?x/" + etatcourant.x+" ");
                        regle.conclusions.x = regle.conclusions.x.Replace("?x", etatcourant.x);

                        if (premisee.y == etatcourant.y)
                        {
                            regleDec = new Regle();
                            regleDec.numero = regle.numero;
                            regleDec.modification.Append(modif);
                            regle.conclusions.x = regle.conclusions.x.Replace("?x", etatcourant.x);
                            regle.conclusions.x = regle.conclusions.x.Replace("?y", etatcourant.y);
                            regle.conclusions.y = regle.conclusions.y.Replace("?x", etatcourant.x);
                            regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y);
                            //
                            regleDec.conclusions = changeConclusion(regle);
                            resultat.Add(regleDec);
                        }
                        else if (premisee.y == "?y")
                        {
                            modif.Append("?y/" + etatcourant.y + " ");
                            regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y); regleDec = new Regle();
                            regleDec.numero = regle.numero;
                            regleDec.modification.Append(modif);
                            regle.conclusions.x = regle.conclusions.x.Replace("?x", etatcourant.x);
                            regle.conclusions.x = regle.conclusions.x.Replace("?y", etatcourant.y);
                            regle.conclusions.y = regle.conclusions.y.Replace("?x", etatcourant.x);
                            regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y);
                            //
                            regleDec.conclusions = changeConclusion(regle);
                            resultat.Add(regleDec);
                        }

                    }
                    else if (premisee.x == etatcourant.x)
                    {
                        if (premisee.y == etatcourant.y)
                        {
                            regleDec = new Regle();
                            regleDec.numero = regle.numero;
                            regleDec.modification.Append(modif);
                            regle.conclusions.x = regle.conclusions.x.Replace("?x", etatcourant.x);
                            regle.conclusions.x = regle.conclusions.x.Replace("?y", etatcourant.y);
                            regle.conclusions.y = regle.conclusions.y.Replace("?x", etatcourant.x);
                            regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y);

                            regleDec.conclusions = changeConclusion(regle);
                            resultat.Add(regleDec);
                        }
                        else if (premisee.y == "?y")
                        {
                            modif.Append("?y/" + etatcourant.y + " ");
                            regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y); regleDec = new Regle();
                            regleDec.numero = regle.numero;
                            regleDec.modification.Append(modif);
                            regle.conclusions.x = regle.conclusions.x.Replace("?x", etatcourant.x);
                            regle.conclusions.x = regle.conclusions.x.Replace("?y", etatcourant.y);
                            regle.conclusions.y = regle.conclusions.y.Replace("?x", etatcourant.x);
                            regle.conclusions.y = regle.conclusions.y.Replace("?y", etatcourant.y);
                            //
                            regleDec.conclusions = changeConclusion(regle);
                            
                            resultat.Add(regleDec);
                        }
                    }
                }


                
                modif.Clear();

            }


            return resultat;

        }

        private Fait changeConclusion(Regle regle)
        {
            Fait fait = new Fait();
            Expression e = new Expression(regle.conclusions.x);
            fait.x= e.Evaluate().ToString();
            Expression r = new Expression(regle.conclusions.y);
           fait.y=r.Evaluate().ToString();






            return fait;
        }
    }
}
