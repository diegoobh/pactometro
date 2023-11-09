using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pactometro
{
    public partial class FormularioEleccion : Form
    {
        public FormularioEleccion()
        {
            InitializeComponent();
        }

        public string Texto1 { get; private set; }
        public string Texto2 { get; private set; }

        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnAceptar;
        private Button btnCancelar;

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox1.Location = new Point(80, 20);
            textBox1.Size = new Size(150, 20);

            textBox2 = new TextBox();
            textBox2.Location = new Point(80, 60);
            textBox2.Size = new Size(150, 20);

            btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new Point(30, 100);
            btnAceptar.Click += btnAceptar_Click;

            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(120, 100);
            btnCancelar.Click += btnCancelar_Click;

            Controls.Add(textBox1);
            Controls.Add(textBox2);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Texto1 = textBox1.Text;
            Texto2 = textBox2.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void formularioEleccion_Load(object sender, EventArgs e)
        {
        }
    }
}
