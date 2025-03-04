using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoDev.Model;

namespace TecnoDev.View
{
    public partial class LoginRegistro : Form
    {
        public ApplicationDbContext dbContext;
        public LoginRegistro()
        {
            InitializeComponent();
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Definimos 4 variables para almacenar los datos ingresados en los campos del Login
            string nombreUsuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;
            string tipo = comBoxTipo.Text;
            string clave = txtClaveregistro.Text;
            var usuario = dbContext.Usuario.FirstOrDefault(u => u.nombreUsuario == nombreUsuario && u.Contrasena == contrasena);
            //Validaciones para ingresar al FormularioRegistroUsuarios
            if (usuario != null && usuario.Contrasena == contrasena)
            {
                if (usuario.tipoUsuario == tipo && tipo == "Super usuario")
                {
                    if (clave == "SJKZ1")
                    {
                        FormularioRegistroUsuarios registrar = new FormularioRegistroUsuarios();
                        registrar.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("La Clave de registro es incorrecta.");
                    }
                }
                else
                {
                    MessageBox.Show("El Usuario seleccionado no tiene los permisos para realizar esta acción.");
                }
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña son incorrectos.");
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            comBoxTipo.Text = "";
            txtClaveregistro.Text = "";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}