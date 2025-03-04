using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoDev.Controller;
using TecnoDev.Model;
using TecnoDev.View;

namespace TecnoDev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSistema_Click(object sender, EventArgs e)
        {
            //Instancia de LoginUsuarios
            LoginSistema ventana1 = new LoginSistema();
            //Mostramos la primera ventana con .Show()
            ventana1.Show();

           
        }
    }
}