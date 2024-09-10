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
        public static int[] kever(int keveresSzama, int[] lapok) 
        {
            Random random = new Random();

            for (int i = 0; i < keveresSzama; i++)
            {
                int a = random.Next(0, 52);
                int b = random.Next(0, 52);

                int s = lapok[a];
                lapok[a] = lapok[b];
                lapok[b] = s;
            }

            return lapok;
        }
        public static string dupplaPar(int[] lapok)
        {
            int[] otLap = new int[5];
            bool dupplaE = false;

            for (int i = 0; i < 5; i++)
                otLap[i] = lapok[i] % 13;

            Array.Sort(otLap);

            if ((otLap[0] == otLap[1]) && ((otLap[2] == otLap[3]) | (otLap[3] == otLap[4])))
                dupplaE = true;

            if ((otLap[1] == otLap[2]) && (otLap[3] == otLap[4]))
                dupplaE = true;

            if ((otLap[2] == otLap[3]) && (otLap[0] == otLap[1]))
                dupplaE = true;

            if ((otLap[3] == otLap[4]) && ((otLap[0] == otLap[1]) | (otLap[2] == otLap[3])))
                dupplaE = true;

            if (dupplaE == true)
                return "Duppla Pár!";
            else
                return "Nem Duppla Pár!";
        }
        public static string SzinSzamol(int lap)
        {
            int a = lap / 13;

            if (a < 1)
                return $"[♠{lap % 13}]";

            if ((a >= 1) && (a < 2))
                return $"[♥{lap % 13}]";

            if ((a >= 2) && (a < 3))
                return $"[♦{lap % 13}]";

            if ((a >= 3) && (a < 4))
                return $"[♣{lap % 13}]";

            return "error";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            Random random = new Random();
            int[] lapok = new int[52];
            int keveresSzama = 150;

            for (int i = 0; i < lapok.Length; i++)
            {
                lapok[i] = i;
            }
            
            kever(keveresSzama, lapok);
            
            for (int i = 0; i < lapok.Length; i++)
            {
                label1.Text += $"{lapok[i]},";
            }

            for (int i = 0; i < 5; i++)
            {
                label2.Text += $"{i + 1}: {SzinSzamol(lapok[i])}\n";
            }

            label3.Text = dupplaPar(lapok);
        }
    }
}
