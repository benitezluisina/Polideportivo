using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polideportivo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Nro equipo";
            label2.Text = "Nombre del equipo";
            Enlazar();
        }

        void Enlazar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Equipo.Listar();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Equipo equipo = (Equipo)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            textBox1.Text = equipo.Id_equipo.ToString();
            textBox2.Text = equipo.Nombre_equipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo();
            equipo.Id_equipo = int.Parse(textBox1.Text);
            equipo.Nombre_equipo = textBox2.Text;
            equipo.Insertar();
            Enlazar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo();
            equipo.Id_equipo = int.Parse(textBox1.Text);
            equipo.Nombre_equipo = textBox2.Text;
            equipo.Editar();
            Enlazar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo();
            equipo.Id_equipo = int.Parse(textBox1.Text);
            equipo.Borrar();
            Enlazar();
        }
    }
}
