using CadTiendaRopa;
using ClnTiendaRopa;

namespace CpTiendaRopa
{
    public partial class FrmProducto : Form
    {
        private bool esNuevo = false;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
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
            var productos = ProductoCln.listar();
            dgvProductos.DataSource = productos;

            if (dgvProductos.Columns.Count > 0)
            {
                dgvProductos.Columns["Id"].HeaderText = "ID";
                dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["Talla"].HeaderText = "Talla";
                dgvProductos.Columns["Color"].HeaderText = "Color";
                dgvProductos.Columns["Precio"].HeaderText = "Precio";
                dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgvProductos.Columns["Stock"].HeaderText = "Stock";
                dgvProductos.Columns["Categoria"].HeaderText = "Categoría";
                
                // Mostrar checkbox para identificar productos del proveedor
                if (dgvProductos.Columns.Contains("EsDeProveedor"))
                {
                    dgvProductos.Columns["EsDeProveedor"].HeaderText = "¿Del Proveedor?";
                    dgvProductos.Columns["EsDeProveedor"].Visible = true;
                    dgvProductos.Columns["EsDeProveedor"].Width = 120;
                }
                
                if (dgvProductos.Columns.Contains("Eliminado"))
                    dgvProductos.Columns["Eliminado"].Visible = false;
                
                // Ocultar CategoriaId ya que se muestra el nombre en "Categoria"
                if (dgvProductos.Columns.Contains("CategoriaId"))
                    dgvProductos.Columns["CategoriaId"].Visible = false;
            }
        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtTalla.Enabled = habilitar;
            txtColor.Enabled = habilitar;
            nudPrecio.Enabled = habilitar;
            nudStock.Enabled = habilitar;
            cboCategoria.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            btnBuscar.Enabled = !habilitar;
            dgvProductos.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtTalla.Clear();
            txtColor.Clear();
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;
            txtImagenUrl.Clear();
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
                MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            esNuevo = false;
            var producto = (Producto)dgvProductos.SelectedRows[0].DataBoundItem;

            txtNombre.Text = producto.Nombre;
            txtTalla.Text = producto.Talla;
            txtColor.Text = producto.Color;
            nudPrecio.Value = producto.Precio;
            nudStock.Value = producto.Stock;
            txtImagenUrl.Text = producto.ImagenUrl ?? ""; // 🔥 NUEVO

            var categorias = (List<Categoria>)cboCategoria.DataSource;
            var categoriaSeleccionada = categorias.FirstOrDefault(c => c.Nombre == producto.Categoria);
            if (categoriaSeleccionada != null)
                cboCategoria.SelectedValue = categoriaSeleccionada.Id;

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

            if (string.IsNullOrWhiteSpace(txtTalla.Text))
            {
                MessageBox.Show("La talla es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTalla.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("El color es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtColor.Focus();
                return;
            }

            if (nudPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudPrecio.Focus();
                return;
            }

            var producto = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Talla = txtTalla.Text.Trim(),
                Color = txtColor.Text.Trim(),
                Precio = nudPrecio.Value,
                Stock = (int)nudStock.Value,
                Categoria = cboCategoria.Text,
                EsDeProveedor = false,
                ImagenUrl = txtImagenUrl.Text.Trim()
            };

            int resultado;

            if (esNuevo)
            {
                resultado = ProductoCln.crear(producto);
                MessageBox.Show("Producto creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                producto.Id = ((Producto)dgvProductos.SelectedRows[0].DataBoundItem).Id;
                // Mantener el valor original de EsDeProveedor al editar
                producto.EsDeProveedor = ((Producto)dgvProductos.SelectedRows[0].DataBoundItem).EsDeProveedor;
                resultado = ProductoCln.actualizar(producto);
                MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                var producto = (Producto)dgvProductos.SelectedRows[0].DataBoundItem;
                ProductoCln.eliminar(producto.Id);
                MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                listar();
            }
            else
            {
                var productos = ProductoCln.buscar(txtBuscar.Text.Trim());
                dgvProductos.DataSource = productos;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }
    }
}