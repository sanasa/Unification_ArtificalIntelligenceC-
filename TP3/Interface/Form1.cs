using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Resolution_Probleme.Business;
using Resolution_Probleme.Entities;

namespace Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Base_Connaisance basee = new Base_Connaisance();
            //il faut ici changer le chemin des fichiers car il ne prend pas de chemin relatif(pour la base des regles,fits)
            basee.creerBaseDeConnaisance(@"C:\Users\Sana\Documents\Visual Studio 2015\Projects\SanaTests\TP3\Regles.txt", @"C:\Users\Sana\Documents\Visual Studio 2015\Projects\SanaTests\TP3\Faits.txt");
            ResolutionProbleme res = new ResolutionProbleme();
            Fait fait = new Fait();
            fait.x = textBox1.Text;
            fait.y = textBox2.Text;

            List<Regle> l = res.genereOperateursApplicables(basee.baseREGLES, fait);
            StringBuilder ress = new StringBuilder("");
            foreach (var item in l)
            {
                String m = item.modification.ToString();
                string[] s = m.Split(' ');
                string p;
                if ((s.Count() >= 2))
                { p = s[0] + " " + s[1]; }
                else p = s[0];

                ress.Append("R" + item.numero + " " +p+"("+item.conclusions.x+","+item.conclusions.y+")"+"\n");
                
            }
            label2.Text = ress.ToString(); 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox2.Clear(); label2.ResetText();
        }
    }
}
