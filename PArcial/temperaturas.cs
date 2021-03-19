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
        public temperaturas()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            button3.Visible = true;
        }
        void guardar()
        {
            FileStream stream = new FileStream(archivo2, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < tempe.Count; i++)
            {
                writer.WriteLine(tempe[i].Nombre);
                writer.WriteLine(tempe[i].Temperatura);
                writer.WriteLine(tempe[i].Fecha);
            }
            writer.Close();
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
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader2.Close();
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
            total tempmostrar = new total();
            datos temppriedades = new datos();
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

            tempmostrar.Nombre = tempnombre + " " + tempc;

            tempe.Add(temppriedades);
            
            guardar();
            limpiar();
            MessageBox.Show("Propiedad agregado correctamente");

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
