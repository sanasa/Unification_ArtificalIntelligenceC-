using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unification.Impl
{
    public static class ExpressionHandler
    {


        public static bool estAtome(List<string> expression)
        {
            if (expression != null && (expression.Count() == 1))
            {
                return true;
            }

            return false;
        }

        public static List<string> changerExpression(List<string> expression, string z1)
        {
           
           String[] z = z1.Split('/');
           for (int i =0;i<expression.Count;i++)
            {
                for (int j = 0; j < z.Length - 1; j += 2)
                {
                    expression[i] = expression[i].Replace(z[j], z[j + 1]);
                }
            }

            return expression;
        }

        public static List<string> extractExpression(string e)
        {
            List<string> m = expressionIntoList(e);
            m.RemoveAt(0);
            return m;


        }

        public static List<string> expressionIntoList(String e)
        {
            List<string> l = new List<string>();
            string j = e[0].ToString();
            string jj = e[1].ToString();
            String a = String.Concat(j, jj);
            l.Add(a);
            int i = 2;
            string ch = "";
            bool test = false;
            int t = 0;
            #region splitExpressionintoList
            while (i < e.Length)
            {

                if (test)
                {
                    ch = ch + e[i].ToString();
                    if (e[i] == '(')
                    { t++; }
                    else if (e[i] == ')')
                    { t--; }
                    if (e[i] == ')' && t == 0)
                    { test = false; }
                    i++;

                }
                else
                if (!test && ch != "")
                {
                    l.Add(ch);
                    ch = "";
                }
                else
                if (!test)
                {


                    if ((e[i] != '(') && (e[i] != ',') && (e[i] != ')') && (e[i] != '?'))
                    {

                        if (e[i + 1] == '(')
                        {
                            ch = ch + e[i].ToString();
                            test = true;
                            i++;

                        }
                        else
                        {
                            l.Add(e[i].ToString());
                            i++;

                        }
                    }
                    else if (e[i] == ',') { i++; }
                    else if (e[i] == '?') { l.Add("?" + e[i + 1]); i += 2; }
                    else if (e[i] == ')') { i += 1; }






                }


            }
            #endregion
            return l;
        }
    }
    
}
