using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unification.Facade;

 namespace Unification.Impl
{
  public  class UnifierPredicat : Facade.Unification
    {
       public string unifier(List<string> ex1, List<string> ex2)
        {
            if ((ExpressionHandler.estAtome(ex1)) || (ExpressionHandler.estAtome(ex2)))
            {
                return unifierAtome(ex1, ex2);
            }

            string l1 = ex1.First();
            string l2 = ex2.First();

            ex1.RemoveAt(0);
            ex2.RemoveAt(0);

            List<string> expres1 = new List<string>(); expres1.Add(l1);
            List<string> expres2 = new List<string>(); expres2.Add(l2);

           string z1= unifier(expres1, expres2);
            if (z1 == "echec") return "echec";
            ex1=ExpressionHandler.changerExpression(ex1, z1);
            ex2 = ExpressionHandler.changerExpression(ex2, z1);


            string z2 = unifier(ex1, ex2);
            if (z2 == "echec") return "echec";
            return z1 + " " + z2;
        }

        private string unifierAtome(List<string> ex1, List<string> ex2)
        {

            string e1 = ex1.First();
            string e2 = ex2.First();

            #region unification_rules_for_atomes
            if (e1.Equals(e2, StringComparison.OrdinalIgnoreCase))
            {
                return "";
            }
            if (e1.StartsWith("?"))
            {
                if (e2.Contains(e1)) return "echec";
                else return e1 + "/" + e2;
            }
            if (e2.StartsWith("?"))
            {
                if (e1.Contains(e2)) return "echec";
                else return e2 + "/" + e1;

            }

            if (e1.Contains("(") && e2.Contains("("))
            {
                return unifier(ExpressionHandler.extractExpression(e1), ExpressionHandler.extractExpression(e2));
            }
            #endregion

            return "echec";
        }
    }
}
