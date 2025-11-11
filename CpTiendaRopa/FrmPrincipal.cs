using System;
using System.Linq;
using System.Windows.Forms;
using CadTiendaRopa;

namespace CpTiendaRopa
{
    public partial class FrmPrincipal : Form
    {
        private Empleado empleadoActual;
        private MaterialSkin.Controls.MaterialButton botonActivo;

        public FrmPrincipal(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"👤 Usuario: {empleadoActual.Nombre} | 📅 {DateTime.Now:dd/MM/yyyy HH:mm}";
            
            // Mostrar Dashboard por defecto
            AbrirFormulario(() => new FrmDashboard(empleadoActual));
        }

        private void AbrirFormulario<T>(Func<T> factory) where T : Form
        {
            try
            {
                // Cerrar formularios abiertos en el contenedor
                foreach (Control ctrl in pnlContenedor.Controls)
                {
                    if (ctrl is Form frm)
                    {
                        frm.Close();
                        ctrl.Dispose();
                    }
                }
                pnlContenedor.Controls.Clear();

                // Crear y mostrar el nuevo formulario
                var formulario = factory();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                pnlContenedor.Controls.Add(formulario);
                formulario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir {typeof(T).Name}: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarcarActivo(MaterialSkin.Controls.MaterialButton btn)
        {
            // Desactivar botón anterior
            if (botonActivo != null)
            {
                botonActivo.UseAccentColor = false;
                botonActivo.BackColor = System.Drawing.Color.Transparent;
            }
            
            // Activar nuevo botón con efecto visual
            botonActivo = btn;
            botonActivo.UseAccentColor = true;
            botonActivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
        }

        // ==================== CATÁLOGOS ====================

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmCategoria());
            MarcarActivo((MaterialSkin.Controls.MaterialButton)sender);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmProducto());
            MarcarActivo((MaterialSkin.Controls.MaterialButton)sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmCliente());
            MarcarActivo((MaterialSkin.Controls.MaterialButton)sender);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmProveedor());
            MarcarActivo((MaterialSkin.Controls.MaterialButton)sender);
        }

        // ==================== TRANSACCIONES ====================

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmVenta(empleadoActual));
            MarcarActivo((MaterialSkin.Controls.MaterialButton)sender);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(() => new FrmCompra(empleadoActual));
            MarcarActivo((MaterialSkin.Controls.MaterialButton)sender);
        }

        // ==================== SALIR ====================

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro de salir del sistema?", "Confirmar Salida",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}