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
    public partial class Depto : Form
    {
        List<departamentos> deptos = new List<departamentos>();
        string archivoD = "RegistroDepartamentos.txt";
        public Depto()
        {
            InitializeComponent();
        }
        public void guardar()
        {
            FileStream stream = new FileStream(archivoD, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < deptos.Count; i++)
            {
                writer.WriteLine(deptos[i].Nombre);
                writer.WriteLine(deptos[i].Numeroidentificacion);

            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivoD, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                departamentos tempcliente = new departamentos();
                tempcliente.Nombre = reader.ReadLine();
                tempcliente.Numeroidentificacion = reader.ReadLine();
                deptos.Add(tempcliente);

            }
            reader.Close();
        }
        private void Depto_Load(object sender, EventArgs e)
        {
            leer_datos();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            departamentos tempcliente = new departamentos();
            tempcliente.Nombre = textBox1.Text;
            tempcliente.Numeroidentificacion = textBox2.Text;
            //para asignarle los datos leidos del archivo
            deptos
                .Add(tempcliente);
            //luego guardar el tempcliente en la lista de clienters
            guardar();

            limpiar();
            MessageBox.Show("Departamento agregado correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 vmenu = new Form1();
            vmenu.Show();
            this.SetVisibleCore(false);
        }
        void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}

