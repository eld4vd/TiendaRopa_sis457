using CadTiendaRopa;
using ClnTiendaRopa;
using MaterialSkin;
using MaterialSkin.Controls;

namespace CpTiendaRopa
{
    public partial class FrmAutenticacion : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        public FrmAutenticacion()
        {
            InitializeComponent();

            // Configurar Material Design
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            
            // Esquema de colores para tienda de ropa (elegante)
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,      // Azul oscuro elegante
                Primary.Blue900,      // Azul más oscuro
                Primary.Blue500,      // Azul medio
                Accent.LightBlue200,  // Acento claro
                TextShade.WHITE       // Texto blanco en controles
            );
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MaterialMessageBox.Show("Por favor ingrese su usuario", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MaterialMessageBox.Show("Por favor ingrese su contraseña", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Focus();
                return;
            }

            // Validar credenciales
            var empleado = EmpleadoCln.validar(txtUsuario.Text.Trim(), txtContraseña.Text);

            if (empleado == null)
            {
                MaterialMessageBox.Show("Usuario y/o contraseña incorrectos", "Acceso Denegado", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtUsuario.Focus();
                return;
            }

            // Login exitoso
            MaterialMessageBox.Show($"¡Bienvenido(a) {empleado.Nombre}!", "Acceso Correcto", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 🔥 CAMBIO: Usar FrmDashboard en lugar de FrmPrincipal
            var frmDashboard = new FrmDashboard(empleado);
            this.Hide();
            frmDashboard.ShowDialog();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmAutenticacion_Load(object sender, EventArgs e)
        {
            // Foco en el campo de usuario al cargar
            txtUsuario.Focus();
        }
    }
}