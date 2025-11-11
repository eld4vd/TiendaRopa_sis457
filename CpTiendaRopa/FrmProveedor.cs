using CadTiendaRopa;
using ClnTiendaRopa;

namespace CpTiendaRopa
{
    public partial class FrmProveedor : Form
    {
        private bool esNuevo = false;

        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            listar();
            configurarControles(false);
        }

        private void listar()
        {
            var proveedores = ProveedorCln.listar();
            dgvProveedores.DataSource = proveedores;
            dgvProveedores.Columns["Eliminado"].Visible = false;

            if (dgvProveedores.Columns.Count > 0)
            {
                dgvProveedores.Columns["Id"].HeaderText = "ID";
                dgvProveedores.Columns["Nombre"].HeaderText = "Nombre";
                dgvProveedores.Columns["Contacto"].HeaderText = "Contacto";
                dgvProveedores.Columns["Telefono"].HeaderText = "Teléfono";
            }

        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtContacto.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            dgvProveedores.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            limpiarControles();
            configurarControles(true);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            esNuevo = false;
            var proveedor = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;

            txtNombre.Text = proveedor.Nombre;
            txtContacto.Text = proveedor.Contacto;
            txtTelefono.Text = proveedor.Telefono;

            configurarControles(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var proveedor = new Proveedor
            {
                Nombre = txtNombre.Text.Trim(),
                Contacto = txtContacto.Text.Trim(),
                Telefono = txtTelefono.Text.Trim()
            };

            if (esNuevo)
            {
                ProveedorCln.crear(proveedor);
                MessageBox.Show("Proveedor registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                proveedor.Id = ((Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem).Id;
                ProveedorCln.actualizar(proveedor);
                MessageBox.Show("Proveedor actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiarControles();
            configurarControles(false);
            listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            configurarControles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                var proveedor = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;
                ProveedorCln.eliminar(proveedor.Id);
                MessageBox.Show("Proveedor eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedor = (Proveedor)dgvProveedores.SelectedRows[0].DataBoundItem;
            var frmProductos = new FrmProductosProveedor(proveedor);
            frmProductos.ShowDialog(); // Modal
        }
    }
}