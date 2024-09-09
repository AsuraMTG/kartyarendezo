using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kartyarendezo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string SzinSzamol(int x)
        {
            int a = x / 13;

            if (a <= 1)
            {
                return $"black spades (♠)";
            }

            if ((1 < a) && (a <= 2))
            {
                return $"red hearts (♥)";
            }

            if ((2 < a) && (a <= 3))
            {
                return $"blue diamonds (♦)";
            }

            if ((3 < a) && (a <= 4))
            {
                return $"green clubs (♣)";
            }

            return "error";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int[] lapok = new int[52];

            for (int i = 0; i < lapok.Length; i++)
            {
                lapok[i] = i;
            }
            
            for (int i = 0; i < 150; i++)
            {
                int a = random.Next(0, 52);
                int b = random.Next(0, 52);

                int s = lapok[a];
                lapok[a] = lapok[b];
                lapok[b] = s;
            }
            
            for (int i = 0; i < lapok.Length; i++)
            {
                label1.Text += $"{lapok[i]},";
            }

            for (int i = 0; i < 5; i++)
            {
                label2.Text += $"{i + 1}: {lapok[i]} | {SzinSzamol(lapok[i])}\n";
            }


        }
    }
}
