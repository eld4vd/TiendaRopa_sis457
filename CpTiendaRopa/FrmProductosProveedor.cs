using CadTiendaRopa;
using ClnTiendaRopa;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CpTiendaRopa
{
    public partial class FrmProductosProveedor : Form
    {
        private Proveedor proveedorActual;
        private bool esNuevo = false;

        public FrmProductosProveedor(Proveedor proveedor)
        {
            InitializeComponent();
            proveedorActual = proveedor;
        }

        private void FrmProductosProveedor_Load(object sender, EventArgs e)
        {
            lblProveedor.Text = $"Proveedor: {proveedorActual.Nombre}";
            cargarCategorias();
            listar();
            configurarControles(false);
        }

        private void cargarCategorias()
        {
            var categorias = CategoriaCln.listar();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";
        }

        private void listar()
        {
            var productos = ProductoProveedorCln.listarPorProveedor(proveedorActual.Id);
            dgvProductos.DataSource = productos;

            if (dgvProductos.Columns.Count > 0)
            {
                if (dgvProductos.Columns.Contains("Id"))
                    dgvProductos.Columns["Id"].HeaderText = "ID";
                if (dgvProductos.Columns.Contains("Nombre"))
                    dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvProductos.Columns.Contains("Descripcion"))
                    dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
                if (dgvProductos.Columns.Contains("PrecioProveedor"))
                {
                    dgvProductos.Columns["PrecioProveedor"].HeaderText = "Precio";
                    dgvProductos.Columns["PrecioProveedor"].DefaultCellStyle.Format = "C2";
                }
                if (dgvProductos.Columns.Contains("CategoriaNombre"))
                    dgvProductos.Columns["CategoriaNombre"].HeaderText = "Categoría";

                if (dgvProductos.Columns.Contains("ProveedorId"))
                    dgvProductos.Columns["ProveedorId"].Visible = false;
                if (dgvProductos.Columns.Contains("CategoriaId"))
                    dgvProductos.Columns["CategoriaId"].Visible = false;
                if (dgvProductos.Columns.Contains("ProveedorNombre"))
                    dgvProductos.Columns["ProveedorNombre"].Visible = false;
                if (dgvProductos.Columns.Contains("Eliminado"))
                    dgvProductos.Columns["Eliminado"].Visible = false;
            }

            lblTotal.Text = $"Total Productos: {productos.Count}";
        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            nudPrecio.Enabled = habilitar;
            cboCategoria.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            dgvProductos.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            nudPrecio.Value = 0;
            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;
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
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            esNuevo = false;
            var producto = (ProductoProveedor)dgvProductos.SelectedRows[0].DataBoundItem;

            txtNombre.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            nudPrecio.Value = producto.PrecioProveedor;

            if (producto.CategoriaId.HasValue)
                cboCategoria.SelectedValue = producto.CategoriaId.Value;

            configurarControles(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPrecio.Focus();
                return;
            }

            try
            {
                var producto = new ProductoProveedor
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    PrecioProveedor = nudPrecio.Value,
                    ProveedorId = proveedorActual.Id,
                    CategoriaId = cboCategoria.SelectedValue as int?
                };

                if (esNuevo)
                {
                    ProductoProveedorCln.crear(producto);
                    MessageBox.Show("Producto agregado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    producto.Id = ((ProductoProveedor)dgvProductos.SelectedRows[0].DataBoundItem).Id;
                    ProductoProveedorCln.actualizar(producto);
                    MessageBox.Show("Producto actualizado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                limpiarControles();
                configurarControles(false);
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            configurarControles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro de eliminar este producto del proveedor?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var producto = (ProductoProveedor)dgvProductos.SelectedRows[0].DataBoundItem;
                    ProductoProveedorCln.eliminar(producto.Id);
                    MessageBox.Show("Producto eliminado correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}