using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoDev.Controller;
using TecnoDev.Model;

namespace TecnoDev.View
{
    public partial class FormularioSuperUsuario : Form
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
       
        //Instancia de VentaController para controlar las operaciones CRUD de Venta
        public VentaController controlador3;
        public LoginSistema login;
        public UsuarioController controlador4;
        public FormularioSuperUsuario()
        {
            InitializeComponent();
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
            //Inicializamos los controladores para traer las operaciones CRUD de cada clase
            controlador4 = new UsuarioController();
            controlador3 = new VentaController();
            login = new LoginSistema();
            //Invocamos los Métodos Mostrar
    
            MostrarVentas();
        }
       
        
       
        //Botón Salir
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        //Botón Limpiar
       
        //Método para validar el formato del email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //Botón Agregar
        
        //Botón Eliminar
       
        //Botón Salir
        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        //Botón Limpiar
        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            
        }
        //Pestaña Ventas
        public void MostrarVentas()
        {
            var ventas = dbContext.Venta.ToList();
            dataGridViewVenta.DataSource = ventas;
        }
        private void LimpiarCamposVenta()
        {
            txtNombre3.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtCantidad2.Text = string.Empty;
            comboBoxAsistencia.Text = string.Empty;
        }
        //Botón Agregar
        private void btnAgregar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre3.Text) ||
                    string.IsNullOrEmpty(txtCodigo.Text) ||
                    string.IsNullOrEmpty(txtCantidad2.Text) ||
                    string.IsNullOrEmpty(comboBoxAsistencia.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtCodigo.Text, out int codigoProducto) || codigoProducto <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un código de producto válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtCantidad2.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(comboBoxAsistencia.Text, out int total) || total <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un total válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Venta nuevaVenta = new Venta
                {
                    Hora = int.Parse(txtNombre3.Text),
                    Minutos = codigoProducto,
                    Dia = cantidad,
                    Mes = total.ToString(),
                    
                };
                controlador3.AgregarVenta(nuevaVenta);
                MostrarVentas();
                MessageBox.Show("Venta agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCamposVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Botón Modificar
        private void btnModificar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewVenta.SelectedRows.Count > 0)
                {
                    var venta = dataGridViewVenta.SelectedRows[0].DataBoundItem as Venta;
                    if (venta != null)
                    {
                        if (string.IsNullOrEmpty(txtNombre3.Text) ||
                            string.IsNullOrEmpty(txtCodigo.Text) ||
                            string.IsNullOrEmpty(txtCantidad2.Text) ||
                            string.IsNullOrEmpty(comboBoxAsistencia.Text))
                        {
                            MessageBox.Show("Por favor, complete todos los campos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(txtCodigo.Text, out int codigoProducto) || codigoProducto <= 0)
                        {
                            MessageBox.Show("Por favor, ingrese un código de producto válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(txtCantidad2.Text, out int cantidad) || cantidad <= 0)
                        {
                            MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(comboBoxAsistencia.Text, out int total) || total < 0)
                        {
                            MessageBox.Show("Por favor, ingrese un total válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        venta.Hora = int.Parse(txtNombre3.Text);
                        venta.Minutos = codigoProducto;
                        venta.Dia= cantidad;
                        venta.Mes = total.ToString();
                        controlador3.ModificarVenta(venta);
                        MostrarVentas();
                        MessageBox.Show("Venta modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCamposVenta();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, complete los campos y seleccione la fila a modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Botón Eliminar
        private void btnEliminar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewVenta.SelectedRows.Count > 0)
                {
                    var venta = dataGridViewVenta.SelectedRows[0].DataBoundItem as Venta;
                    if (venta != null)
                    {
                        var confirmResult = MessageBox.Show(
                            $"¿Estás seguro de que deseas eliminar la venta de '{venta.Hora}'?",
                            "Confirmar Eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (confirmResult == DialogResult.Yes)
                        {
                            controlador3.EliminarVenta(venta.AsistenciaId);
                            MostrarVentas();
                            MessageBox.Show("Venta eliminada correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, presione en el costado izquierdo de la fila que desea eliminar y luego seleccione el boton eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Botón Limpiar
        private void btnLimpiar3_Click(object sender, EventArgs e)
        {
            txtNombre3.Text = "";
            txtCodigo.Text = "";
            txtCantidad2.Text = "";
            comboBoxAsistencia.Text = "";
        }
        //Botón Salir
        private void btnSalir3_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                // Lista de usuarios que no tienen asistencia registrada
                var usuariosSinAsistencia = dbContext.Usuario
                    .Where(u => !dbContext.Venta.Any(a => a.UsuarioId == u.UsuarioId))
                    .ToList();

                // Mostrar los usuarios sin asistencia
                foreach (var usuario in usuariosSinAsistencia)
                {
                    Console.WriteLine($"Usuario sin asistencia: {usuario.nombreUsuario}, ID: {usuario.UsuarioId}");
                }

                // Si estás usando un DataGridView para mostrar los usuarios
                dataGridViewProducto.DataSource = usuariosSinAsistencia;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Venta> ventasFiltradas = new List<Venta>();
            var ventas = dbContext.Venta;
            // Recorrer todas las ventas y aplicar los filtros
            foreach (var venta in ventas)
            {
                string concat = venta.Hora.ToString() + venta.Minutos.ToString();

                int entero = int.Parse(concat);
                Console.WriteLine("Este es la hora de ingreso "  + concat);
                // Asumimos que los filtros son opcionales, y agregamos solo si se cumplen los criterios
                if (entero>930 && venta.Asistencia=="Entrada")
                {
                    ventasFiltradas.Add(venta); // Agregar venta que cumple los filtros
                }
            }

            // Asignar la lista filtrada al DataGridView
            dataGridViewProducto.DataSource = ventasFiltradas;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Venta> ventasFiltradas = new List<Venta>();
            var ventas = dbContext.Venta;
            // Recorrer todas las ventas y aplicar los filtros
            foreach (var venta in ventas)
            {
                string concat = venta.Hora.ToString() + venta.Minutos.ToString();

                int entero = int.Parse(concat);
                Console.WriteLine("Este es la hora de salida " + concat);
                // Asumimos que los filtros son opcionales, y agregamos solo si se cumplen los criterios
                if (entero < 1730 && venta.Asistencia=="Salida")
                {
                    ventasFiltradas.Add(venta); // Agregar venta que cumple los filtros
                }
            }

            // Asignar la lista filtrada al DataGridView
            dataGridViewProducto.DataSource = ventasFiltradas;
        }

        private void btnSalir7_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar5_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar5_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar4_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void MostrarUsuarios()
        {
            var usuarios = dbContext.Usuario.ToList();
            dataGridView1.DataSource = usuarios;

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"UsuarioId: {usuario.nombreUsuario}");

            }

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Crear el nuevo usuario
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                nombreUsuario = txtUsuario.Text,
                Contrasena = txtContraseña.Text,
                tipoUsuario = comboBox1.Text
            };
            // Agregar el nuevo usuario al controlador
            try
            {
                controlador4.AgregarUsuario(nuevoUsuario);
            } 
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            // Actualizar la lista de usuarios
            MostrarUsuarios();
            // Mostrar mensaje de confirmación
            MessageBox.Show("Usuario agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var usuario = dataGridView1.SelectedRows[0].DataBoundItem as Usuario;
            if (usuario == null)
            {
                MessageBox.Show("No se pudo obtener el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Actualizar los datos del usuario
            usuario.Nombre = txtNombre.Text;
            usuario.nombreUsuario = txtUsuario.Text;
            usuario.Contrasena = txtContraseña.Text;
            usuario.tipoUsuario = comboBox1.Text;
            // Modificar el usuario en el controlador
            controlador4.ModificarUsuario(usuario);
            // Actualizar la lista de usuarios
            MostrarUsuarios();
            // Mostrar mensaje de confirmación
            MessageBox.Show("Usuario modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var usuario = dataGridView1.SelectedRows[0].DataBoundItem as Usuario;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            comboBox1.Text = "";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExcelReader exportar = new ExcelReader();
            exportar.ExportarDataGridViewAExcel(dataGridViewVenta);  // Pasa tu DataGridView
        }
    }
}