using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDev.ToolsSys.UserInterface.Windows.Cadastros;

namespace RDev.ToolsSys.UserInterface.Windows
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Janela = new CadastroCliente();
            Janela.MdiParent = this;
            Janela.Show();
        }
    }
}
