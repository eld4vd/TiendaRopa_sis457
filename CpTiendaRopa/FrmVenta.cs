using CadTiendaRopa;
using ClnTiendaRopa;

namespace CpTiendaRopa
{
    public partial class FrmVenta : Form
    {
        private Empleado empleadoActual;
        private List<DetalleVenta> detallesVenta;

        public FrmVenta(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;
            detallesVenta = new List<DetalleVenta>();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            cargarClientes();
            cargarProductos();
            listarVentas();
            configurarControles(false);
            
            lblEmpleado.Text = $"Empleado: {empleadoActual.Nombre}";
            dtpFecha.Value = DateTime.Now;
        }

        private void cargarClientes()
        {
            var clientes = ClienteCln.listar();
            cboCliente.DataSource = clientes;
            cboCliente.DisplayMember = "Nombre";
            cboCliente.ValueMember = "Id";
        }

        private void cargarProductos()
        {
            var productos = ProductoCln.listar().Where(p => p.Stock > 0).ToList();
            
            cboProducto.DataSource = productos;
            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember = "Id";
        }

        private void listarVentas()
        {
            var ventas = VentaCln.listar();
            dgvVentas.DataSource = ventas;
            
            if (dgvVentas.Columns.Count > 0)
            {
                if (dgvVentas.Columns.Contains("Id"))
                    dgvVentas.Columns["Id"].HeaderText = "ID";
                
                if (dgvVentas.Columns.Contains("Fecha"))
                {
                    dgvVentas.Columns["Fecha"].HeaderText = "Fecha";
                    dgvVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                
                if (dgvVentas.Columns.Contains("Total"))
                {
                    dgvVentas.Columns["Total"].HeaderText = "Total";
                    dgvVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                
                if (dgvVentas.Columns.Contains("ClienteNombre"))
                    dgvVentas.Columns["ClienteNombre"].HeaderText = "Cliente";
                
                if (dgvVentas.Columns.Contains("EmpleadoNombre"))
                    dgvVentas.Columns["EmpleadoNombre"].HeaderText = "Empleado";
                
                if (dgvVentas.Columns.Contains("EmpleadoId"))
                    dgvVentas.Columns["EmpleadoId"].Visible = false;
                
                if (dgvVentas.Columns.Contains("ClienteId"))
                    dgvVentas.Columns["ClienteId"].Visible = false;
                
                if (dgvVentas.Columns.Contains("Eliminado"))
                    dgvVentas.Columns["Eliminado"].Visible = false;
                    
                if (dgvVentas.Columns.Contains("Detalles"))
                    dgvVentas.Columns["Detalles"].Visible = false;
            }
        }

        private void configurarControles(bool habilitar)
        {
            dtpFecha.Enabled = habilitar;
            cboCliente.Enabled = habilitar;
            cboProducto.Enabled = habilitar;
            nudCantidad.Enabled = habilitar;
            btnAgregarProducto.Enabled = habilitar;
            btnQuitarProducto.Enabled = habilitar;

            btnNueva.Enabled = !habilitar;
            dgvVentas.Enabled = !habilitar;
            btnVerDetalle.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void limpiarControles()
        {
            dtpFecha.Value = DateTime.Now;
            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            if (cboProducto.Items.Count > 0) cboProducto.SelectedIndex = 0;
            nudCantidad.Value = 1;
            detallesVenta.Clear();
            dgvDetalle.DataSource = null;
            txtTotal.Text = "0.00";
        }

        private void actualizarTotal()
        {
            decimal total = detallesVenta.Sum(d => d.Subtotal);
            txtTotal.Text = total.ToString("N2");
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            limpiarControles();
            configurarControles(true);
            dtpFecha.Focus();
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is Producto producto)
            {
                lblPrecioUnitario.Text = $"Precio: Bs. {producto.Precio:N2}";
                lblStock.Text = $"Stock: {producto.Stock}";
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto", "Advertencia", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var productoId = (int)cboProducto.SelectedValue;
            var producto = ProductoCln.obtenerPorId(productoId);

            if (producto == null) return;

            if (nudCantidad.Value > producto.Stock)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {producto.Stock}", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detalleExistente = detallesVenta.FirstOrDefault(d => d.ProductoId == productoId);

            if (detalleExistente != null)
            {
                detalleExistente.Cantidad += (int)nudCantidad.Value;
                detalleExistente.PrecioUnitario = producto.Precio;
            }
            else
            {
                var detalle = new DetalleVenta
                {
                    ProductoId = productoId,
                    ProductoNombre = producto.Nombre,
                    ProductoTalla = producto.Talla,
                    ProductoColor = producto.Color,
                    Cantidad = (int)nudCantidad.Value,
                    PrecioUnitario = producto.Precio
                };
                detallesVenta.Add(detalle);
            }

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = detallesVenta.ToList();
            actualizarTotal();
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto del detalle", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var detalle = (DetalleVenta)dgvDetalle.SelectedRows[0].DataBoundItem;
            detallesVenta.Remove(detalle);

            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = detallesVenta.ToList();
            actualizarTotal();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var venta = new Venta
                {
                    Fecha = dtpFecha.Value,
                    EmpleadoId = empleadoActual.Id,
                    ClienteId = (int)cboCliente.SelectedValue,
                    Total = detallesVenta.Sum(d => d.Subtotal),
                    Detalles = detallesVenta.ToList()
                };

                VentaCln.crear(venta);
                
                MessageBox.Show("Venta registrada correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiarControles();
                configurarControles(false);
                listarVentas();
                cargarProductos();
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
            if (dgvVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una venta", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar esta venta?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var venta = (Venta)dgvVentas.SelectedRows[0].DataBoundItem;
                    VentaCln.eliminar(venta.Id);
                    MessageBox.Show("Venta eliminada correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarVentas();
                    cargarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una venta", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = (Venta)dgvVentas.SelectedRows[0].DataBoundItem;
            var ventaCompleta = VentaCln.obtenerPorId(venta.Id);

            if (ventaCompleta != null)
            {
                string detalle = $"VENTA #{ventaCompleta.Id}\n\n";
                detalle += $"Fecha: {ventaCompleta.Fecha:dd/MM/yyyy HH:mm}\n";
                detalle += $"Cliente: {ventaCompleta.ClienteNombre}\n";
                detalle += $"Empleado: {ventaCompleta.EmpleadoNombre}\n\n";
                detalle += "DETALLE:\n";
                detalle += new string('-', 60) + "\n";

                foreach (var item in ventaCompleta.Detalles)
                {
                    detalle += $"{item.ProductoNombre} ({item.ProductoTalla} - {item.ProductoColor})\n";
                    detalle += $"  Cantidad: {item.Cantidad} x Bs. {item.PrecioUnitario:N2} = Bs. {item.Subtotal:N2}\n";
                }

                detalle += new string('-', 60) + "\n";
                detalle += $"TOTAL: Bs. {ventaCompleta.Total:N2}";

                MessageBox.Show(detalle, "Detalle de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}