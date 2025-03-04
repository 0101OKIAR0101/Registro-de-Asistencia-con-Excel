using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using TecnoDev.Controller;
using TecnoDev.Model;
using TecnoDev.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TecnoDev.View
{
    public partial class LoginSistema : Form
    {
        public ApplicationDbContext dbContext;
       
        public LoginSistema()
        {
            InitializeComponent();


            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {



            //Definimos tres variables para almacenar los datos ingresados en el Login
            string nombreusuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            string tipo = comBoxTipo.Text;
            var usuario = dbContext.Usuario.FirstOrDefault(u => u.nombreUsuario == nombreusuario && u.Contrasena == contrasena);

            if (usuario != null && usuario.Contrasena == contrasena)
            {
                MessageBox.Show("Las Credenciales son correctas.");
                if (usuario.tipoUsuario == tipo && tipo == "Super usuario")
                {
                    FormularioSuperUsuario ventana2 = new FormularioSuperUsuario();
                    ventana2.Show();
                    this.Close();

                }
                else if (usuario.tipoUsuario == tipo && tipo == "Usuario común")
                {
                    FormularioUsuario ventana3 = new FormularioUsuario();
                    ventana3.Show();
                    ventana3.txtNombreUsuario.Text = txtUsuario.Text;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El tipo de Usuario seleccionado no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Las Credenciales son incorrectas, verifica los datos ingresados.");
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            comBoxTipo.Text = "";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            LoginRegistro registrarUsuario = new LoginRegistro();
            registrarUsuario.Show();
            this.Close();
        }

        private void LoginSistema_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
            label6.Text = DateTime.Now.ToLongDateString();
        }
    }
}