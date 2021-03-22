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
    public partial class temperaturas : Form
    {
        List<departamentos> deptos = new List<departamentos>();
        string archivoC = "RegistroDepartamentos.txt";

        List<datos> tempe = new List<datos>();
        string archivo2 = "RegistroTemperaturas.txt";

        List<total> mostrargrid = new List<total>();
        string archivo3 = "mostrar.txt";
        public temperaturas()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            button3.Visible = true;
        }
        void guardar()
        {
            FileStream stream = new FileStream(archivoC, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < deptos.Count; i++)
            {
                writer.WriteLine(deptos[i].Nombre);
                writer.WriteLine(deptos[i].Numeroidentificacion);
            }
            writer.Close();

            FileStream stream2 = new FileStream(archivo2, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer2 = new StreamWriter(stream2);

            for (int i = 0; i < tempe.Count; i++)
            {
                writer2.WriteLine(tempe[i].Nombre);
                writer2.WriteLine(tempe[i].Temperatura);
                writer2.WriteLine(tempe[i].Fecha);
            }
            writer2.Close();

            FileStream stream3 = new FileStream(archivo3, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer3 = new StreamWriter(stream3);

            for (int i = 0; i < mostrargrid.Count; i++)
            {
                writer3.WriteLine(mostrargrid[i].Nombre);
                writer3.WriteLine(mostrargrid[i].Temperatura);
                
            }
            writer3.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                datos temppropiedades = new datos();
                temppropiedades.Nombre = reader.ReadLine();
                temppropiedades.Temperatura = reader.ReadLine();
                temppropiedades.Fecha = Convert.ToDateTime(reader.ReadLine());
                tempe.Add(temppropiedades);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();


            FileStream stream2 = new FileStream(archivoC, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                departamentos temppropietarios = new departamentos();
                temppropietarios.Nombre = reader2.ReadLine();
                temppropietarios.Numeroidentificacion = reader2.ReadLine();
                deptos.Add(temppropietarios);

            }
            reader2.Close();

            FileStream stream3 = new FileStream(archivo3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                total temppropietarios = new total();
                temppropietarios.Nombre = reader3.ReadLine();
                temppropietarios.Temperatura = reader3.ReadLine();
                mostrargrid.Add(temppropietarios);

            }
            reader3.Close();
        }
        void limpiar()
        {
            textBox2.Text = null;
            comboBox1.Text = null;
        }
        void mostrar()
        {
            comboBox1.Text = null;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Nombre";
            comboBox1.DataSource = deptos;
            comboBox1.Refresh();
        }
        void desbloquear()
        {
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            button3.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            datos temppriedades = new datos();
            total temp = new total();

            temppriedades.Temperatura = textBox2.Text;
            temppriedades.Nombre = comboBox1.Text;
            string tempnombre = "";
            string tempc = "";

            comboBox1.ValueMember = "Nombre";
            comboBox1.DataSource = deptos;
            tempnombre = comboBox1.SelectedValue.ToString();
            comboBox1.ValueMember = "Nombre";
            comboBox1.DataSource = deptos;
            tempc = comboBox1.SelectedValue.ToString();

            temp.Nombre = comboBox1.Text;
            temp.Temperatura = textBox2.Text;
            



            tempe.Add(temppriedades);
            mostrargrid.Add(temp);

            guardar();
            limpiar();
            MessageBox.Show("Temperatura agregada correctamente");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 vmenu = new Form1();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void temperaturas_Load(object sender, EventArgs e)
        {
            leer_datos();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrar();
            desbloquear();
        }
    }
}
