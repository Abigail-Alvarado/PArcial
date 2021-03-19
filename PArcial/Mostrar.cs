using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PArcial
{
    public partial class Mostrar : Form
    {

        List<total> mostrargrid = new List<total>();
        string archivo3 = "mostrar.txt";

        public Mostrar()
        {
            InitializeComponent();
        }
        void leer_datos()
        {
            FileStream stream3 = new FileStream(archivo3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                total temp = new total();
                temp.Nombre = (reader3.ReadLine());
                temp.Temperatura = (reader3.ReadLine());
                mostrargrid.Add(temp);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader3.Close();
        }
        void mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mostrargrid;
            dataGridView1.Refresh();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Mostrar_Load(object sender, EventArgs e)
        {
            leer_datos();
            mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 vmenu = new Form1();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mostrargrid = mostrargrid.OrderBy(cuota => cuota.Temperatura).ToList();
            mostrar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string mayorprom = mostrargrid.Average(p => Temperatura);
            label1.Text = (mayorprom).ToString();
        }
    }
}
