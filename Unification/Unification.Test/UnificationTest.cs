using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unification.Test
{
    [TestClass]
  public  class UnificationTest
    {
        private Facade.Unification unification = new Impl.UnifierPredicat();

        [TestMethod]
        public void shouldReturnExpression1()
        {
            //Arrange
            string expected = "?y/B ?z/C ?x/B  ?w/f(A,C,B)";
            string e1 = "p(B,C,?x,?z,f(A,?z,B))";
            List<string> expression1 = new List<string>();
            expression1.Add(e1);
            string e2 = "p(?y,?z?y,C,?w)";
            List<string> expression2 = new List<string>();
            expression2.Add(e2);

            //Act 
            string actual = unification.unifier(expression1, expression2);

            //Assert 

            Assert.AreEqual(expected, actual);



        }


        [TestMethod]
        public void shouldReturnExpression2()
        {
           //Arrange
            string expected = "?x/b ?y/f(g(b)) ?z/a";

            string e1 = "P(?x,f(g(?x)),a)";
            List<string> expression1 = new List<string>();
            expression1.Add(e1);
            string e2 = "P(b,?y,?z)";
            List<string> expression2 = new List<string>();
            expression2.Add(e2);

            //Act 
            string actual = unification.unifier(expression1, expression2);

            //Assert 

            Assert.AreEqual(expected, actual);



        }

        [TestMethod]
        public void shouldReturnEchec1()
        {
            //Arrange
            string expected = "echec";

            string e1 = "q(f(A,?x),?x)";
            List<string> expression1 = new List<string>();
            expression1.Add(e1);
            string e2 = "q(f(?z,f(?z,D)),?z))";
            List<string> expression2 = new List<string>();
            expression2.Add(e2);

            //Act 
            string actual = unification.unifier(expression1, expression2);

            //Assert 

            Assert.AreEqual(expected, actual);



        }


        [TestMethod]
        public void shouldReturnEchec2()
        {
            //Arrange
            string expected = "echec";

            string e1 = "?x";
            List<string> expression1 = new List<string>();
            expression1.Add(e1);
            string e2 = "g(?x)";
            List<string> expression2 = new List<string>();
            expression2.Add(e2);

            //Act 
            string actual = unification.unifier(expression1, expression2);

            //Assert 

            Assert.AreEqual(expected, actual);



        }






    }
}
