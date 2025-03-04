
using RegistroAsistencia.View;


namespace RegistroAsistencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instancia de LoginUsuarios
            LoginSistema ventana1 = new LoginSistema();
            //Mostramos la primera ventana con .Show()
            ventana1.Show();
        }
    }
}
