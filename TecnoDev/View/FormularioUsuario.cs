using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TecnoDev.Controller;
using TecnoDev.Model;

namespace TecnoDev.View
{
    public partial class FormularioUsuario : Form
    {
        //Traemos la conexion de Base de Datos
        public ApplicationDbContext dbContext;
        //Instancia de VentasController para controlar las operaciones CRUD de ventas
        public VentaController controlador;
        public UsuarioController usuarioController;
        public LoginSistema login;
        
        public FormularioUsuario()
        {
            InitializeComponent();
            //Inicializamos el contexto de la Base de Datos
            dbContext = new ApplicationDbContext();
            //Inicializamos el controlador3 para traer las operaciones CRUD de Venta
            controlador = new VentaController();
            login = new LoginSistema();
            //Invocamos los Métodos Mostrar
           
            MostrarVentas();
           
         

        }
       
       
        public void MostrarVentas()
        {
            var ventas = dbContext.Venta.ToList();
            dataGridViewVenta.DataSource = ventas;
           


        }
        private void LimpiarCamposVenta()
        {
            txtNombre.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            
        }
        //Pestaña Ventas
        //Botón Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(comboBoxMes.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Intentar crear una nueva venta con validación de entradas numéricas
            try
            {
                Venta nuevaVenta = new Venta
                {
                    // Enlazamos los atributos de la clase con los campos del formulario
                    Hora = int.Parse(txtNombre.Text),
                    Minutos = int.Parse(txtCodigo.Text),
                    Dia = int.Parse(txtCantidad.Text),
                    Mes = comboBoxMes.SelectedItem.ToString(),
                    Asistencia = "Entrada",
                    UsuarioId = int.Parse(txtID.Text)
                

                };
                // Llamamos al Método AgregarVenta del controlador
                controlador.AgregarVenta(nuevaVenta);
                // Actualizamos la vista
                MostrarVentas();
                // Mostrar mensaje de éxito
                MessageBox.Show("Venta agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Limpiar los campos del formulario después de agregar
                LimpiarCamposVenta();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos de código, cantidad y total.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Botón Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtCantidad.Text = "";
            txtNombreUsuario.Text = "";

        }
        //Botón Salir Productos
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        //Botón Salir Proveedores
        private void btnSalir2_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        //Botón Salir Ventas
        private void btnSalir3_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void FormularioUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(comboBoxMes.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Intentar crear una nueva venta con validación de entradas numéricas
            try
            {
                Venta nuevaVenta = new Venta
                {
                    // Enlazamos los atributos de la clase con los campos del formulario
                    Hora = int.Parse(txtNombre.Text),
                    Minutos = int.Parse(txtCodigo.Text),
                    Dia = int.Parse(txtCantidad.Text),
                    Mes = comboBoxMes.SelectedItem.ToString(),
                    Asistencia = "Salida",
                    UsuarioId = int.Parse(txtID.Text)

                };
                // Llamamos al Método AgregarVenta del controlador
                controlador.AgregarVenta(nuevaVenta);
                // Actualizamos la vista
                MostrarVentas();
                // Mostrar mensaje de éxito
                MessageBox.Show("Venta agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Limpiar los campos del formulario después de agregar
                LimpiarCamposVenta();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en los campos de código, cantidad y total.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al agregar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            // Al cerrar este formulario, también cerramos la aplicación
            Application.Exit();
        }

        public void RegistrarUsuario()
        {
            var usuarios = dbContext.Usuario.ToList();
            string nombreBuscado = txtNombreUsuario.Text;

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Usuario buscado: {nombreBuscado}");
                if (usuario.nombreUsuario.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    // Si hay coincidencia, mostramos o almacenamos el UsuarioId
                    int usuarioIdEncontrado = usuario.UsuarioId;
                    Console.WriteLine($"Usuario buscado: {nombreBuscado}");
                    Console.WriteLine($"Usuario encontrado. Nombre: {usuario.nombreUsuario}, UsuarioId: {usuarioIdEncontrado}");

                    // Aquí puedes usar el usuarioIdEncontrado como lo necesites
                    Console.WriteLine(usuarioIdEncontrado);
                    txtID.Text = usuarioIdEncontrado.ToString();

                    // Salimos del bucle si ya hemos encontrado el usuario
                    break;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarUsuario();
            
        }

        private void tabVentas2_Click(object sender, EventArgs e)
        {

        }
    }
}