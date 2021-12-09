using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace loteria
{
    public partial class Form1 : Form
    {
        //
        Stack<int> cartas = new Stack<int>();
        Random rndm = new Random();
        int j = 0;

        bool vertical = false;
        bool diagonal = false;
        bool Horizontal = false;
        bool PollaG = false;
        bool DosDiagonales = false;

        //

        private PictureBox[] tabla;

        public Form1()
        {
            InitializeComponent();


            tabla = new PictureBox[25];
            inicializarTabla();
        }
        private void inicializarTabla()
        {
            int r = 0, c = 0;

            int[] cartas = new int[54];

            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = i + 1;
            }
            Random rnd = new Random();
            int a, aux;
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }

            for (int i = 0; i < tabla.Length; i++)
            {
                tabla[i] = new PictureBox();
                tabla[i].Location = new System.Drawing.Point(100 + (c * 90), 25 + (r * 125));
                tabla[i].Name = "picTabla" + i;
                tabla[i].Size = new System.Drawing.Size(85, 120);
                tabla[i].TabIndex = 0 + i;
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].TabStop = false;
                tabla[i].Image = Image.FromFile(@"cartas\" + (cartas[i]) + ".jpg");
                //
                tabla[i].AllowDrop = true;
                tabla[i].Click += new EventHandler(ponerFicha);
                
                //
                this.Controls.Add(tabla[i]);
                c++;
                if (c == 5)
                {
                    r++;
                    c = 0;
                }
            }
           
        }

        //



        private void ponerFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Image.FromFile(@"C:\Users\angyl\source\repos\loteria\loteria\bin\Debug\Fichas.png");
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;
            ((PictureBox)sender).BackColor = Color.Transparent;
            ((PictureBox)sender).BackgroundImageLayout = ImageLayout.Stretch;
        }
        
        //

        private void Form1_Load(object sender, EventArgs e)
            {
                //
                this.listView1.View = View.LargeIcon;
                this.imageList1.ImageSize = new Size(106, 127);
                this.listView1.LargeImageList = this.imageList1;

            }      

            private void button1_Click_1(object sender, EventArgs e)
            {

                inicializarTabla();
                label1.Text = (54 - cartas.Count()).ToString();
                bool Visible = false;

                while (!Visible)
                {
                    int num = rndm.Next(1, 54);
                    if (!cartas.Contains(num))
                    {
                        pdcarta.Image = Image.FromFile(@"cartas\" + num + ".jpg");
                        pdcarta.SizeMode = PictureBoxSizeMode.StretchImage;
                        cartas.Push(num);
                        this.imageList1.Images.Add(Image.FromFile(@"cartas\" + num + ".jpg"));
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = j;
                        this.listView1.Items.Add(item);
                        Visible = true;
                        j++;
                    }
                }
            }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            cartas.Clear();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            pdcarta.Image = null;
            j = 0;
            label1.Text = "";
        } //

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\angyl\source\repos\loteria\loteria\bin\Debug\Buenas\buenas1.wav");
            player.SoundLocation = (@"C:\Users\angyl\source\repos\loteria\loteria\bin\Debug\Buenas\buenas1.wav");
            player.Play();
        }

       
    }
}
