using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pheistel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            Random rand = new Random();
            int[] mas = new int[(textBox21.Text.Length * 16 / 64 + 1) * 64];
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.Unicode.GetBytes(textBox21.Text))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0')).Append(' ');
            string sbstring = sb.ToString();
            int countmas = 0;
            for (int i = 0; i < sbstring.Length; i++)
                if (sbstring[i] != ' ')
                {
                    mas[countmas] = (int)Char.GetNumericValue(sbstring[i]);
                    countmas++;
                }
            for (int i = 0; i < mas.Length; i++)
            {
                //if (mas[i] == null)
                //    mas[i] = 0;
                textBox2.Text += mas[i].ToString();
            }
            int[] k = new int[32];
            int[] k2 = new int[32];
            int[] kstart = new int[32];
            int[] kend = new int[32];
            for (int i = 0; i < k.Length; i++)
            {
                //mas[i] = rand.Next(2); 
                //textBox2.Text += mas[i].ToString(); 
                k[i] = rand.Next(2);
                textBox20.Text += k[i].ToString();
                k2[i] = k[i];
                kstart[i] = k[i];
            }
            //for (int i = 0; i < 64; i++) 
            //{ 
            // if ((i + 1) % 4 != 0) 
            // { 
            // mas[i] = 0; 
            // k[i] = 0; 
            // k2[i] = 0; 
            // } 
            // else 
            // { 
            // mas[i] = 1; 
            // k[i] = 1; 
            // k2[i] = 1; 
            // } 
            // textBox2.Text += mas[i].ToString(); 
            //} 
            int[] left = new int[32];
            int[] left2 = new int[32];
            int[] right = new int[32];
            string sbstring2 = "";
            for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
            {
                for (int i = 0; i < 32; i++)
                {
                    left[i] = mas[m * 64 + i];
                    right[i] = mas[m * 64 + i + 32];
                    k[i] = kstart[i];
                    k2[i] = kstart[i];
                }
                for (int j = 0; j < n; j++)//j
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                            break;
                        k2[(8 + i) % 32] = k[i];
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        textBox3.Text += k2[i].ToString();
                        k[i] = k2[i];
                        kend[i] = k2[i];
                    }

                    for (int i = 0; i < 32; i++)//F 
                    {
                        left2[i] = left[(9 + i) % 32];
                        textBox4.Text += left2[i].ToString();
                        k2[i] = k[(21 + i) % 32];
                        textBox5.Text += k2[i].ToString();
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (k2[i] == left[i])
                            mas[m * 64 + i] = 1;
                        else
                            mas[m * 64 + i] = 0;
                        //mas[i] = k2[i] ^ left[i]; 
                        textBox6.Text += mas[m * 64 + i].ToString();
                        if (mas[m * 64 + i] == 0)
                            mas[m * 64 + i] = 1;
                        else
                            mas[m * 64 + i] = 0;
                        textBox7.Text += mas[m * 64 + i].ToString();
                        left2[i] = left2[i] ^ mas[m * 64 + i];
                        textBox8.Text += left2[i].ToString();//F 
                        left2[i] = left2[i] ^ right[i];
                        textBox9.Text += left2[i].ToString();
                        right[i] = left[i];
                        left[i] = left2[i];
                        mas[m * 64 + i] = right[i];
                        mas[m * 64 + i + 32] = left[i];
                    }

                    for (int i = 0; i < 64; i++)
                        textBox10.Text += mas[m * 64 + i].ToString();
                    textBox3.Text += " | ".ToString();
                    textBox4.Text += " | ".ToString();
                    textBox5.Text += " | ".ToString();
                    textBox6.Text += " | ".ToString();
                    textBox7.Text += " | ".ToString();
                    textBox8.Text += " | ".ToString();
                    textBox9.Text += " | ".ToString();
                    textBox10.Text += " | ".ToString();

                    //for (int i = 0; i < 32; i++)
                    //{
                    //    left[i] = mas[m * 64 + i];
                    //    right[i] = mas[m * 64 + i + 32];
                    //}
                }//j
            }



            //for (int i = 0; i < 64; i++) 
            //{ 
            // textBox3.Text += mas[i].ToString(); 
            // // //textBox2.Text += k[i].ToString(); 
            //} 
            for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
            {
                for (int i = 0; i < 32; i++)
                {
                    left[i] = mas[m * 64 + i];
                    right[i] = mas[m * 64 + i + 32];
                    k[i] = kend[i];
                    k2[i] = kend[i];
                }
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                        {
                            for (int h = 0; h < 32; h++)
                                textBox11.Text += k2[h].ToString();
                            break;
                        }
                        k2[i] = k[(8 + i) % 32];
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                            break;
                        textBox11.Text += k2[i].ToString();
                        k[i] = k2[i];
                    }

                    for (int i = 0; i < 32; i++)//F 
                    {
                        left2[i] = left[(9 + i) % 32];
                        textBox12.Text += left2[i].ToString();
                        k2[i] = k[(21 + i) % 32];
                        textBox13.Text += k2[i].ToString();
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (k2[i] == left[i])
                            mas[m * 64 + i] = 1;
                        else
                            mas[m * 64 + i] = 0;
                        //mas[i] = k2[i] ^ left[i]; 
                        textBox14.Text += mas[m * 64 + i].ToString();
                        if (mas[m * 64 + i] == 0)
                            mas[m * 64 + i] = 1;
                        else
                            mas[m * 64 + i] = 0;
                        textBox15.Text += mas[m * 64 + i].ToString();
                        left2[i] = left2[i] ^ mas[m * 64 + i];
                        textBox16.Text += left2[i].ToString();//F 
                        left2[i] = left2[i] ^ right[i];
                        textBox17.Text += left2[i].ToString();
                        right[i] = left[i];
                        left[i] = left2[i];
                        mas[m * 64 + i] = right[i];
                        mas[m * 64 + i + 32] = left[i];
                    }
                    for (int i = 0; i < 64; i++)
                        textBox18.Text += mas[m * 64 + i].ToString();
                    textBox11.Text += " | ".ToString();
                    textBox12.Text += " | ".ToString();
                    textBox13.Text += " | ".ToString();
                    textBox14.Text += " | ".ToString();
                    textBox15.Text += " | ".ToString();
                    textBox16.Text += " | ".ToString();
                    textBox17.Text += " | ".ToString();
                    textBox18.Text += " | ".ToString();
                }
                for (int i = 0; i < 64; i++)
                {
                    textBox19.Text += mas[m * 64 + i].ToString();
                    sbstring2 += mas[m * 64 + i].ToString();
                }
            }
            var stringArray = Enumerable.Range(0, sbstring2.Length / 8).Select(i => Convert.ToByte(sbstring2.Substring(i * 8, 8), 2)).ToArray();
            var str = Encoding.Unicode.GetString(stringArray);
            textBox22.Text += str.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
                int n = Convert.ToInt32(textBox1.Text);
                Random rand = new Random();
                int[] mas = new int[(textBox21.Text.Length * 16 / 64 + 1) * 64];
                StringBuilder sb = new StringBuilder();
                foreach (byte b in Encoding.Unicode.GetBytes(textBox21.Text))
                    sb.Append(Convert.ToString(b, 2).PadLeft(8, '0')).Append(' ');
                string sbstring = sb.ToString();
                int countmas = 0;
                for (int i = 0; i < sbstring.Length; i++)
                    if (sbstring[i] != ' ')
                    {
                        mas[countmas] = (int)Char.GetNumericValue(sbstring[i]);
                        countmas++;
                    }
                for (int i = 0; i < mas.Length; i++)
                {
                    //if (mas[i] == null)
                    //    mas[i] = 0;
                    textBox2.Text += mas[i].ToString();
                }
                int[] k = new int[32];
                int[] k2 = new int[32];
                int[] kstart = new int[32];
                int[] kend = new int[32];
                int[] vektor_initsializatsii = new int[64];
                for (int i = 0; i < k.Length; i++)
                {
                    //mas[i] = rand.Next(2); 
                    //textBox2.Text += mas[i].ToString(); 
                    k[i] = rand.Next(2);
                    textBox20.Text += k[i].ToString();
                    k2[i] = k[i];
                    kstart[i] = k[i];
                    vektor_initsializatsii[i] = rand.Next(2);
                    vektor_initsializatsii[i + 32] = rand.Next(2);
                }
                for (int i = 0; i < vektor_initsializatsii.Length; i++)
                    textBox23.Text += vektor_initsializatsii[i].ToString();
                //for (int i = 0; i < 64; i++) 
                //{ 
                // if ((i + 1) % 4 != 0) 
                // { 
                // mas[i] = 0; 
                // k[i] = 0; 
                // k2[i] = 0; 
                // } 
                // else 
                // { 
                // mas[i] = 1; 
                // k[i] = 1; 
                // k2[i] = 1; 
                // } 
                // textBox2.Text += mas[i].ToString(); 
                //} 
                int[] left = new int[32];
                int[] left2 = new int[32];
                int[] right = new int[32];
                string sbstring2 = "";
                for (int i = 0; i < 64; i++)
                    mas[i] = mas[i] ^ vektor_initsializatsii[i];
                for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        left[i] = mas[m * 64 + i];
                        right[i] = mas[m * 64 + i + 32];
                        k[i] = kstart[i];
                        k2[i] = kstart[i];
                    }
                    for (int j = 0; j < n; j++)//j
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (j == 0)
                                break;
                            k2[(8 + i) % 32] = k[i];
                        }
                        for (int i = 0; i < 32; i++)
                        {
                            textBox3.Text += k2[i].ToString();
                            k[i] = k2[i];
                            kend[i] = k2[i];
                        }

                        for (int i = 0; i < 32; i++)//F 
                        {
                            left2[i] = left[(9 + i) % 32];
                            textBox4.Text += left2[i].ToString();
                            k2[i] = k[(21 + i) % 32];
                            textBox5.Text += k2[i].ToString();
                        }
                        for (int i = 0; i < 32; i++)
                        {
                            if (k2[i] == left[i])
                                mas[m * 64 + i] = 1;
                            else
                                mas[m * 64 + i] = 0;
                            //mas[i] = k2[i] ^ left[i]; 
                            textBox6.Text += mas[m * 64 + i].ToString();
                            if (mas[m * 64 + i] == 0)
                                mas[m * 64 + i] = 1;
                            else
                                mas[m * 64 + i] = 0;
                            textBox7.Text += mas[m * 64 + i].ToString();
                            left2[i] = left2[i] ^ mas[m * 64 + i];
                            textBox8.Text += left2[i].ToString();//F 
                            left2[i] = left2[i] ^ right[i];
                            textBox9.Text += left2[i].ToString();
                            right[i] = left[i];
                            left[i] = left2[i];
                            mas[m * 64 + i] = right[i];
                            mas[m * 64 + i + 32] = left[i];
                        }

                        for (int i = 0; i < 64; i++)
                            textBox10.Text += mas[m * 64 + i].ToString();
                        textBox3.Text += " | ".ToString();
                        textBox4.Text += " | ".ToString();
                        textBox5.Text += " | ".ToString();
                        textBox6.Text += " | ".ToString();
                        textBox7.Text += " | ".ToString();
                        textBox8.Text += " | ".ToString();
                        textBox9.Text += " | ".ToString();
                        textBox10.Text += " | ".ToString();

                        //for (int i = 0; i < 32; i++)
                        //{
                        //    left[i] = mas[m * 64 + i];
                        //    right[i] = mas[m * 64 + i + 32];
                        //}
                    }//j
                    for (int i = 0; i < 64; i++)
                        if (m + 1 < textBox21.Text.Length * 16 / 64 + 1)
                        {
                            mas[(m + 1) * 64 + i] ^= mas[m * 64 + i];
                            textBox24.Text += mas[(m + 1) * 64 + i];
                        }
                }

                int[] mas2 = new int[(textBox21.Text.Length * 16 / 64 + 1) * 64];
                for (int i = 0; i < mas2.Length; i++)
                    mas2[i] = mas[i];
                //for (int i = 0; i < 64; i++) 
                //{ 
                // textBox3.Text += mas[i].ToString(); 
                // // //textBox2.Text += k[i].ToString(); 
                //} 
                for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        left[i] = mas[m * 64 + i];
                        right[i] = mas[m * 64 + i + 32];
                        k[i] = kend[i];
                        k2[i] = kend[i];
                    }
                    for (int j = 0; j < n; j++)
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            if (j == 0)
                            {
                                for (int h = 0; h < 32; h++)
                                    textBox11.Text += k2[h].ToString();
                                break;
                            }
                            k2[i] = k[(8 + i) % 32];
                        }
                        for (int i = 0; i < 32; i++)
                        {
                            if (j == 0)
                                break;
                            textBox11.Text += k2[i].ToString();
                            k[i] = k2[i];
                        }

                        for (int i = 0; i < 32; i++)//F 
                        {
                            left2[i] = left[(9 + i) % 32];
                            textBox12.Text += left2[i].ToString();
                            k2[i] = k[(21 + i) % 32];
                            textBox13.Text += k2[i].ToString();
                        }
                        for (int i = 0; i < 32; i++)
                        {
                            if (k2[i] == left[i])
                                mas[m * 64 + i] = 1;
                            else
                                mas[m * 64 + i] = 0;
                            //mas[i] = k2[i] ^ left[i]; 
                            textBox14.Text += mas[m * 64 + i].ToString();
                            if (mas[m * 64 + i] == 0)
                                mas[m * 64 + i] = 1;
                            else
                                mas[m * 64 + i] = 0;
                            textBox15.Text += mas[m * 64 + i].ToString();
                            left2[i] = left2[i] ^ mas[m * 64 + i];
                            textBox16.Text += left2[i].ToString();//F 
                            left2[i] = left2[i] ^ right[i];
                            textBox17.Text += left2[i].ToString();
                            right[i] = left[i];
                            left[i] = left2[i];
                            mas[m * 64 + i] = right[i];
                            mas[m * 64 + i + 32] = left[i];
                        }
                        for (int i = 0; i < 64; i++)
                            textBox18.Text += mas[m * 64 + i].ToString();
                        textBox11.Text += " | ".ToString();
                        textBox12.Text += " | ".ToString();
                        textBox13.Text += " | ".ToString();
                        textBox14.Text += " | ".ToString();
                        textBox15.Text += " | ".ToString();
                        textBox16.Text += " | ".ToString();
                        textBox17.Text += " | ".ToString();
                        textBox18.Text += " | ".ToString();
                    }
                    for (int i = 0; i < 64; i++)
                        if (m - 1 >= 0)
                            mas[m * 64 + i] ^= mas2[(m - 1) * 64 + i];
                        else
                            mas[i] ^= vektor_initsializatsii[i];
                    for (int i = 0; i < 64; i++)
                    {
                        textBox19.Text += mas[m * 64 + i].ToString();
                        sbstring2 += mas[m * 64 + i].ToString();
                    }
                }
                var stringArray = Enumerable.Range(0, sbstring2.Length / 8).Select(i => Convert.ToByte(sbstring2.Substring(i * 8, 8), 2)).ToArray();
                var str = Encoding.Unicode.GetString(stringArray);
                textBox22.Text += str.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            Random rand = new Random();
            int[] mas = new int[(textBox21.Text.Length * 16 / 64 + 1) * 64];
            StringBuilder sb = new StringBuilder();
            foreach (byte b in Encoding.Unicode.GetBytes(textBox21.Text))
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0')).Append(' ');
            string sbstring = sb.ToString();
            int countmas = 0;
            for (int i = 0; i < sbstring.Length; i++)
                if (sbstring[i] != ' ')
                {
                    mas[countmas] = (int)Char.GetNumericValue(sbstring[i]);
                    countmas++;
                }
            for (int i = 0; i < mas.Length; i++)
            {
                //if (mas[i] == null)
                //    mas[i] = 0;
                textBox2.Text += mas[i].ToString();
            }
            int[] k = new int[32];
            int[] k2 = new int[32];
            int[] kstart = new int[32];
            int[] kend = new int[32];
            int[] vektor_initsializatsii = new int[64];
            for (int i = 0; i < k.Length; i++)
            {
                //mas[i] = rand.Next(2); 
                //textBox2.Text += mas[i].ToString(); 
                k[i] = rand.Next(2);
                textBox20.Text += k[i].ToString();
                k2[i] = k[i];
                kstart[i] = k[i];
                vektor_initsializatsii[i] = rand.Next(2);
                vektor_initsializatsii[i + 32] = rand.Next(2);
            }
            for (int i = 0; i < vektor_initsializatsii.Length; i++)
                textBox23.Text += vektor_initsializatsii[i].ToString();
            //for (int i = 0; i < 64; i++) 
            //{ 
            // if ((i + 1) % 4 != 0) 
            // { 
            // mas[i] = 0; 
            // k[i] = 0; 
            // k2[i] = 0; 
            // } 
            // else 
            // { 
            // mas[i] = 1; 
            // k[i] = 1; 
            // k2[i] = 1; 
            // } 
            // textBox2.Text += mas[i].ToString(); 
            //} 
            int[] left = new int[32];
            int[] left2 = new int[32];
            int[] right = new int[32];
            string sbstring2 = "";
            int[] mas2 = new int[(textBox21.Text.Length * 16 / 64 + 1) * 64];
            for (int i = 0; i < mas2.Length; i++)
                mas2[i] = mas[i];
            for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (m == 0)
                    {
                        left[i] = vektor_initsializatsii[i];
                        right[i] = vektor_initsializatsii[i + 32];
                    }
                    else
                    {
                        left[i] = mas[(m-1) * 64 + i];
                        right[i] = mas[(m-1) * 64 + i + 32];
                    }
                    k[i] = kstart[i];
                    k2[i] = kstart[i];
                }
                for (int j = 0; j < n; j++)//j
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                            break;
                        k2[(8 + i) % 32] = k[i];
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        textBox3.Text += k2[i].ToString();
                        k[i] = k2[i];
                        kend[i] = k2[i];
                    }

                    for (int i = 0; i < 32; i++)//F 
                    {
                        left2[i] = left[(9 + i) % 32];
                        textBox4.Text += left2[i].ToString();
                        k2[i] = k[(21 + i) % 32];
                        textBox5.Text += k2[i].ToString();
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (k2[i] == left[i])
                            mas2[m * 64 + i] = 1;
                        else
                            mas2[m * 64 + i] = 0;
                        //mas[i] = k2[i] ^ left[i]; 
                        textBox6.Text += mas2[m * 64 + i].ToString();
                        if (mas2[m * 64 + i] == 0)
                            mas2[m * 64 + i] = 1;
                        else
                            mas2[m * 64 + i] = 0;
                        textBox7.Text += mas2[m * 64 + i].ToString();
                        left2[i] = left2[i] ^ mas2[m * 64 + i];
                        textBox8.Text += left2[i].ToString();//F 
                        left2[i] = left2[i] ^ right[i];
                        textBox9.Text += left2[i].ToString();
                        right[i] = left[i];
                        left[i] = left2[i];
                        mas2[m * 64 + i] = right[i];
                        mas2[m * 64 + i + 32] = left[i];
                    }

                    for (int i = 0; i < 64; i++)
                        textBox10.Text += mas2[m * 64 + i].ToString();
                    textBox3.Text += " | ".ToString();
                    textBox4.Text += " | ".ToString();
                    textBox5.Text += " | ".ToString();
                    textBox6.Text += " | ".ToString();
                    textBox7.Text += " | ".ToString();
                    textBox8.Text += " | ".ToString();
                    textBox9.Text += " | ".ToString();
                    textBox10.Text += " | ".ToString();

                    //for (int i = 0; i < 32; i++)
                    //{
                    //    left[i] = mas[m * 64 + i];
                    //    right[i] = mas[m * 64 + i + 32];
                    //}
                }//j
                for (int i = 0; i < 64; i++)
                {
                    mas[m * 64 + i] ^= mas2[m * 64 + i];
                    textBox24.Text += mas[m * 64 + i];
                }
            }
            //расшифровка
            int[] mas3 = new int[mas2.Length];
            for (int i = 0; i < mas.Length; i++)
            {
                mas2[i] = mas[i];
                mas3[i] = mas[i];
            }
            for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (m == 0)
                    {
                        left[i] = vektor_initsializatsii[i];
                        right[i] = vektor_initsializatsii[i + 32];
                    }
                    else
                    {
                        left[i] = mas3[(m-1) * 64 + i];
                        right[i] = mas3[(m-1) * 64 + i + 32];
                    }
                    k[i] = kstart[i];
                    k2[i] = kstart[i];
                }
                for (int j = 0; j < n; j++)//j
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                            break;
                        k2[(8 + i) % 32] = k[i];
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        textBox3.Text += k2[i].ToString();
                        k[i] = k2[i];
                        kend[i] = k2[i];
                    }

                    for (int i = 0; i < 32; i++)//F 
                    {
                        left2[i] = left[(9 + i) % 32];
                        textBox4.Text += left2[i].ToString();
                        k2[i] = k[(21 + i) % 32];
                        textBox5.Text += k2[i].ToString();
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (k2[i] == left[i])
                            mas2[m * 64 + i] = 1;
                        else
                            mas2[m * 64 + i] = 0;
                        //mas[i] = k2[i] ^ left[i]; 
                        textBox6.Text += mas2[m * 64 + i].ToString();
                        if (mas2[m * 64 + i] == 0)
                            mas2[m * 64 + i] = 1;
                        else
                            mas2[m * 64 + i] = 0;
                        textBox7.Text += mas2[m * 64 + i].ToString();
                        left2[i] = left2[i] ^ mas2[m * 64 + i];
                        textBox8.Text += left2[i].ToString();//F 
                        left2[i] = left2[i] ^ right[i];
                        textBox9.Text += left2[i].ToString();
                        right[i] = left[i];
                        left[i] = left2[i];
                        mas2[m * 64 + i] = right[i];
                        mas2[m * 64 + i + 32] = left[i];
                    }

                    for (int i = 0; i < 64; i++)
                        textBox10.Text += mas2[m * 64 + i].ToString();
                    textBox3.Text += " | ".ToString();
                    textBox4.Text += " | ".ToString();
                    textBox5.Text += " | ".ToString();
                    textBox6.Text += " | ".ToString();
                    textBox7.Text += " | ".ToString();
                    textBox8.Text += " | ".ToString();
                    textBox9.Text += " | ".ToString();
                    textBox10.Text += " | ".ToString();

                    //for (int i = 0; i < 32; i++)
                    //{
                    //    left[i] = mas[m * 64 + i];
                    //    right[i] = mas[m * 64 + i + 32];
                    //}
                }//j
                for (int i = 0; i < 64; i++)
                {
                    mas[m * 64 + i] = mas2[m * 64 + i] ^ mas3[m * 64 + i];
                    textBox24.Text += mas[m * 64 + i];
                }
            }
            //for (int i = 0; i < 64; i++) 
            //{ 
            // textBox3.Text += mas[i].ToString(); 
            // // //textBox2.Text += k[i].ToString(); 
            //} 
            ///////////////////////////////////////
            /*
            for (int m = 0; m < textBox21.Text.Length * 16 / 64 + 1; m++)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (m == 0)
                    {
                        left[i] = vektor_initsializatsii[i];
                        right[i] = vektor_initsializatsii[i + 32];
                    }
                    else
                    {
                        left[i] = mas2[(m - 1) * 64 + i];
                        right[i] = mas2[(m - 1) * 64 + i + 32];
                    }
                    k[i] = kend[i];
                    k2[i] = kend[i];
                }
                for (int j = 0; j < n; j++)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                        {
                            for (int h = 0; h < 32; h++)
                                textBox11.Text += k2[h].ToString();
                            break;
                        }
                        k2[i] = k[(8 + i) % 32];
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (j == 0)
                            break;
                        textBox11.Text += k2[i].ToString();
                        k[i] = k2[i];
                    }

                    for (int i = 0; i < 32; i++)//F 
                    {
                        left2[i] = left[(9 + i) % 32];
                        textBox12.Text += left2[i].ToString();
                        k2[i] = k[(21 + i) % 32];
                        textBox13.Text += k2[i].ToString();
                    }
                    for (int i = 0; i < 32; i++)
                    {
                        if (k2[i] == left[i])
                            mas[m * 64 + i] = 1;
                        else
                            mas[m * 64 + i] = 0;
                        //mas[i] = k2[i] ^ left[i]; 
                        textBox14.Text += mas[m * 64 + i].ToString();
                        if (mas[m * 64 + i] == 0)
                            mas[m * 64 + i] = 1;
                        else
                            mas[m * 64 + i] = 0;
                        textBox15.Text += mas[m * 64 + i].ToString();
                        left2[i] = left2[i] ^ mas[m * 64 + i];
                        textBox16.Text += left2[i].ToString();//F 
                        left2[i] = left2[i] ^ right[i];
                        textBox17.Text += left2[i].ToString();
                        right[i] = left[i];
                        left[i] = left2[i];
                        mas[m * 64 + i] = right[i];
                        mas[m * 64 + i + 32] = left[i];
                    }
                    for (int i = 0; i < 64; i++)
                        textBox18.Text += mas[m * 64 + i].ToString();
                    textBox11.Text += " | ".ToString();
                    textBox12.Text += " | ".ToString();
                    textBox13.Text += " | ".ToString();
                    textBox14.Text += " | ".ToString();
                    textBox15.Text += " | ".ToString();
                    textBox16.Text += " | ".ToString();
                    textBox17.Text += " | ".ToString();
                    textBox18.Text += " | ".ToString();
                }
                for (int i = 0; i < 64; i++)
                    if (m - 1 >= 0)
                        mas[m * 64 + i] ^= mas2[(m - 1) * 64 + i];
                    else
                        mas[i] ^= vektor_initsializatsii[i];
                for (int i = 0; i < 64; i++)
                {
                    textBox19.Text += mas[m * 64 + i].ToString();
                    sbstring2 += mas[m * 64 + i].ToString();
                }
            }*/
            /////////////////////////////////////////////////////////////////////
            for (int i = 0; i < mas.Length; i++)
            {
                textBox19.Text += mas[i].ToString();
                sbstring2 += mas[i].ToString();
            }
            var stringArray = Enumerable.Range(0, sbstring2.Length / 8).Select(i => Convert.ToByte(sbstring2.Substring(i * 8, 8), 2)).ToArray();
            var str = Encoding.Unicode.GetString(stringArray);
            textBox22.Text += str.ToString();
        }
    }
}