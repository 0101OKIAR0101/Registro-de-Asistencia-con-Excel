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

namespace TecnoDev.View
{
    public partial class FormularioRegistroUsuarios : Form
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Instancia de UsuarioController para controlar las operaciones CRUD de usuario
        public UsuarioController controlador4;
        public LoginSistema login;
        public FormularioRegistroUsuarios()
        {
            InitializeComponent();
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
            //Inicializamos el controlador para traer las operaciones CRUD de usuario
            controlador4 = new UsuarioController();
            login = new LoginSistema();
            //Invocamos el Método Mostrar
            MostrarUsuarios();
           
     
        }
        //Pestaña Usuarios
        //Método MostrarUsuarios
        public void MostrarUsuarios()
        {
            var usuarios = dbContext.Usuario.ToList();
            dataGridViewUsuarios.DataSource = usuarios;

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"UsuarioId: {usuario.nombreUsuario}");
               
            }

        }

        
        //Botón Agregar
        private void btnAgregar5_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre4.Text) ||
                string.IsNullOrWhiteSpace(txtNombreusuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasenausuario.Text) ||
                string.IsNullOrWhiteSpace(comBoxTipousuario.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Crear el nuevo usuario
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre4.Text,
                nombreUsuario = txtNombreusuario.Text,
                Contrasena = txtContrasenausuario.Text,
                tipoUsuario = comBoxTipousuario.Text
            };
            // Agregar el nuevo usuario al controlador
            controlador4.AgregarUsuario(nuevoUsuario);
            // Actualizar la lista de usuarios
            MostrarUsuarios();
            // Mostrar mensaje de confirmación
            MessageBox.Show("Usuario agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Botón Modificar
        private void btnModificar4_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var usuario = dataGridViewUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (usuario == null)
            {
                MessageBox.Show("No se pudo obtener el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre4.Text) ||
                string.IsNullOrWhiteSpace(txtNombreusuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasenausuario.Text) ||
                string.IsNullOrWhiteSpace(comBoxTipousuario.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Actualizar los datos del usuario
            usuario.Nombre = txtNombre4.Text;
            usuario.nombreUsuario = txtNombreusuario.Text;
            usuario.Contrasena = txtContrasenausuario.Text;
            usuario.tipoUsuario = comBoxTipousuario.Text;
            // Modificar el usuario en el controlador
            controlador4.ModificarUsuario(usuario);
            // Actualizar la lista de usuarios
            MostrarUsuarios();
            // Mostrar mensaje de confirmación
            MessageBox.Show("Usuario modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Botón Eliminar
        private void btnEliminar4_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var usuario = dataGridViewUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (usuario == null)
            {
                MessageBox.Show("No se pudo obtener el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?",
                                                "Confirmar eliminación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                controlador4.EliminarUsuario(usuario.UsuarioId);
                MostrarUsuarios();
                MessageBox.Show("Usuario eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Botón Limpiar
        private void btnLimpiar5_Click(object sender, EventArgs e)
        {
            txtNombre4.Text = "";
            txtNombreusuario.Text = "";
            txtContrasenausuario.Text = "";
            comBoxTipousuario.Text = "";
        }
        //Botón Salir
        private void btnSalir7_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void tabUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void textBoxRecibido_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}