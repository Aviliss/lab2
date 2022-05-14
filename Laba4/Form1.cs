// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
 using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        String originaltext, shifrtext, decodtext;
        int multInv = -1;
        int g = -1;
        int p;
        int y, k;
        int a;
        int x;
      
       
      
        int b;

        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();


        


        }

        private static void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            originaltext = null;
            shifrtext = null;
            decodtext = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ") return;

          
            originaltext = null;
            shifrtext = null;
            decodtext = null;
            textBox3.Text = null;
            textBox4.Text = null;

            try
            {
                x = Convert.ToInt32(textBox1.Text);
                originaltext = textBox2.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            p = P();

            if (x >= p)
            {
                MessageBox.Show("Неправильно выбрано число x.");
                return;
            }

            y = powmod(g, x, p);

            Console.WriteLine("p = " + p);
            Console.WriteLine("g = " + g);
            Console.WriteLine("y = " + y);

            if (originaltext.Length > 0)
            {
                char[] temp = new char[originaltext.Length - 1];
                temp = originaltext.ToCharArray();

                for (int i = 0; i <= originaltext.Length - 1; i++)
                {
                    int m = (int)temp[i];
                    if (m > 0)
                    {
                        k = rand.Next() % (p - 1);
                        
                        Console.WriteLine((i + 1) + " k = " + k);
                        a = powmod(g, k, p);
                        b = Proizved(powmod(y, k, p), m, p);
                        shifrtext = shifrtext + a + ' ' + b + ' ';
                    }

                }
                textBox3.Text = shifrtext;
            }
 
            string[] string1 = shifrtext.Split(' ');

            if (string1.Length > 0)
            {
              
                
                


                for (int i = 0; i < string1.Length - 1; i += 2)
                {
                    a = Convert.ToInt32(string1[i]);
                    b = Convert.ToInt32(string1[i + 1]);

                    if ((a != 0) && (b != 0))
                    {

                        multi(powmod(a, x, p), p);
                        int decod = Proizved(b, multInv, p);
                        char m = (char)decod;
                        decodtext = decodtext + m;

                    }
                }
                textBox4.Text = decodtext;

            }
      
    
            }

            public int P()
 {
 Random random = new Random();
 int p = 0;
 bool flag = false;

 do
 {
 p = random.Next(1000, 2000);

 for (int i = 2; i != p; i++)
 {
 if (i == p - 1)
 {
                        flag = G(p, p - 1);
 break;
 }

 if (p % i == 0)
 {
 break;
 }
 }
 }
 while (flag == false) ;
 return p;
 }

 public bool G(int p, int g_)
 {
 bool flag = false;

List < BigInteger > number = new List<BigInteger>();

BigInteger integer = ((BigInteger.Pow(g_, 1)) % p);
    number.Add(integer);
            //integer
            for (int i = 2; i != p; i++)
     {
       integer = BigInteger.Pow(g_, i) % p;
      for (int j = 0; j != i - 1; j++)
            {
            if (number[j] == number[j])
               {
              g_--;
               number.Clear();
               i = 1;
             integer = BigInteger.Pow(g_, 1) % p;
               number.Add(integer);
                break;
                }
            
             if ((j == i - 2) && (number[j] != integer))
            {
               number.Add(integer);
                }
           }
       }
g = g_;
            flag = true;
    return flag;
   }
        int powmod(int a, int x, int m, int z)
        {

            int b, result = 1;
            b = a % m;

            while (x > 0)
            {
                if ((x & 1) == 1)
                {
                    result = result * b;
                    result = result % m;
                }
                b = b * b;
              //  b = b % m;
                b = b;
                x = x >> 1;

            }
            return result;
        }

        int Proizved(int a, int b, int n)
        {

            int sum =0;
            for (int i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                {
                    sum -= n;
                }
            }
            return sum;

        }
        bool multi(int n, int m)
        {
            int v1 = 0, v2 = m;
            int p1 = 1, p2 = n;
            int q = v2 / p2;


            while (p2 != 1)
            {
                int temp1 = p1;
                int temp2 = p2;

                p1 = v1 - p1 * q;
                p2 = v2 - p2 * q;

                v1 = temp1;
                v2 = temp2;

                q = v2 / p2;
            }

            int z = p1;

            if (z < 0)
            {
                z = z + m;
            }

            multInv = z;
            return true;
        }
    }
}
