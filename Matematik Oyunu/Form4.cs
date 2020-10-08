using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Random r = new Random();
        Random r2 = new Random();
        int s1, s2, çarp, sonuc;
        int doğru = 0, yanlış = 0;
        int skor = 0, soru = 1;
        int ip_ucu = 3;
        int süre = 90;
        int say = 0;

        private void Timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            label7.Text = "%" + progressBar1.Value.ToString();
            if (progressBar1.Value == 50)
            {
                label7.BackColor = Color.MediumSeaGreen;
            }
            if (progressBar1.Value == 100)
            {
                timer2.Stop();
                MessageBox.Show("Oyun Başlamıştır İyi Şanslar");
                s1 = r.Next(3, 10);
                s2 = r2.Next(2, 9);
                label1.Text = s1.ToString();
                label2.Text = s2.ToString();
                çarp = s1 * s2;
                label12.Text = "Soru " + soru.ToString();
                timer1.Start();
                timer1.Interval = 1000;
                button1.Visible = true;
                button3.Visible = true;
                listBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label12.Visible = true;
                textBox1.Visible = true;
                progressBar1.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            say++;
            if (say % 9 == 1)
            {
                label8.Text = "Oyun Yükleniyor.";
            }
            else if (say % 2 == 1)
            {
                label8.Text = "Oyun Yükleniyor..";
            }
            else if (say % 3 == 0)
            {
                label8.Text = "Oyun Yükleniyor...";
            }
            if (say == 100)
            {
                timer3.Stop();
                label8.Text = " Oyun Yüklendi ".ToString();
            }
            if (progressBar1.Value == 25)
            {
                label9.Text = "Rastgele Sayılar Üretiliyor";
            }
            if (progressBar1.Value == 50)
            {
                label9.Text = "Oyundaki Araçlar Hazır \nHale Getiriliyor";
            }
            if (progressBar1.Value == 75)
            {
                label9.Text = "Oyun Kontrol Ediliyor";
            }
            if (progressBar1.Value == 99)
            {
                label9.Text = "Oyun Hazırlandı \nArtık Oynayabilirsiniz.";
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Oyunumuz Şu Şekilde Oynanmaktadır.\n" + "90 Saniye İçerisinde Sürekli Bilgisayar \n" + "Tarafından Belli Aralıklarla Üretilen Sayıları \n" +
                "Çarparak Doğru Sonuçlara Ulaşmaktır. Her Doğru Sonuç, \n" + "Size 100 Puan Ekleyecektir. Onun Dışında Her \n" +
                "Her Yanlış Sonuç, Puanınızdan 10 Puan Kesecektir. \n" + "Bol Şans. :)", "Yönetici Tarafından Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label9.Text = "Oyun Hazırlanılıyor";
            timer2.Enabled = true;
            progressBar1.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            button1.Visible = false;
            button3.Visible = false;
            listBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label12.Visible = false;
            textBox1.Visible = false;
            timer3.Start();
            pictureBox1.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt16(button3.Text) >= 0)
                {
                    ip_ucu--;
                    button3.Text = ip_ucu.ToString();
                    textBox1.Text = çarp.ToString();
                }
                if (ip_ucu == 0)
                {
                    button3.Text = "İp Ucu Hakkınız Kalmadı!!!";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İp ucu Hakkınız Kalmadı..");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            süre--;
            if (süre == -1)
            {
                timer1.Stop();
                MessageBox.Show("Süre Doldu...");
                MessageBox.Show("Doğru Sayınız : " + doğru + "\n\n" + "Yanlış Sayınız :" + yanlış + "\n\n" + "Puanınız : " + ((doğru * 100) - (yanlış * 10)));
                DialogResult secenek = MessageBox.Show("Yeniden Oynamak İstiyormusunz ?", "Microsoft Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (secenek == DialogResult.No)
                {
                    this.Close();
                    Application.Exit();
                }
            }
            label5.Text = süre + "sn".ToString();
        }

        
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                sonuc = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("İşlemsel Sonuç İçeren Cevaplara Karakter Giremessin !!!");
                yanlış = -1;
                skor = +10;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Aralık Dışında Sayı Giremessinz !!!");
                yanlış = -1;
                skor = +10;
            }
            textBox1.Text = "";
            if (sonuc == çarp)
            {
                soru++;
                doğru++;
                listBox1.Items.Add(s1 + " X " + s2 + " = " + sonuc + " ✔");
                s1 = r.Next(3, 10);
                s2 = r2.Next(2, 9);
                label1.Text = s1.ToString();
                label2.Text = s2.ToString();
                çarp = s1 * s2;
                label12.Text = "Soru " + soru.ToString();
                if (soru >= 5)
                {
                    s1 = r.Next(10, 100);
                    s2 = r2.Next(1, 10);
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
                if (soru >= 10)
                {
                    s1 = r.Next(100, 900);
                    s2 = r2.Next(1, 10);
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
                if (soru >= 20)
                {
                    s1 = r.Next(20, 50);
                    s2 = r2.Next(10, 40);
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
                if (soru >= 30)
                {
                    s1 = r.Next(100, 900);
                    s2 = r2.Next(10, 40);
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
            }
            else if (sonuc != çarp)
            {
                yanlış++;
                listBox1.Items.Add(s1 + " x " + s2 + " = " + sonuc + " X");
                //listBox1.Items.Add("Doğrusu = " + s1 + " x " + s2 + " = " + çarp);
                label1.Text = s1.ToString();
                label2.Text = s2.ToString();
                çarp = s1 * s2;
                label12.Text = "Soru " + soru.ToString();
                if (soru >= 5)
                {
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
                if (soru >= 10)
                {
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
                if (soru >= 20)
                {
                    label1.Text = s1.ToString();
                    label2.Text = s2.ToString();
                    çarp = s1 * s2;
                }
            }
        }
    }
}
