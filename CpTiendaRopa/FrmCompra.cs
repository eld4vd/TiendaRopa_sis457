using CadTiendaRopa;
using ClnTiendaRopa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CpTiendaRopa
{
    public partial class FrmCompra : Form
    {
        private Empleado empleadoActual;
        private List<DetalleCompra> detallesCompra;

        public FrmCompra(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;
            detallesCompra = new List<DetalleCompra>();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            cargarProveedores();
            configurarControles(false);
            listarCompras();

            lblEmpleado.Text = $"Empleado: {empleadoActual.Nombre}";
            dtpFecha.Value = DateTime.Now;
        }

        private void cargarProveedores()
        {
            var proveedores = ProveedorCln.listar();
            cboProveedor.DataSource = proveedores;
            cboProveedor.DisplayMember = "Nombre";
            cboProveedor.ValueMember = "Id";

            cboProveedor.SelectedIndexChanged += cboProveedor_SelectedIndexChanged;
        }

        private void cargarProductosProveedor(int proveedorId)
        {
            try
            {
                var productosProveedor = ProductoProveedorCln.listarPorProveedor(proveedorId);

                cboProducto.DataSource = null;
                cboProducto.Items.Clear();

                if (productosProveedor != null && productosProveedor.Count > 0)
                {
                    cboProducto.DataSource = productosProveedor;
                    cboProducto.DisplayMember = "Nombre";
                    cboProducto.ValueMember = "Id";
                    cboProducto.Enabled = true;
                    btnAgregarProducto.Enabled = true;
                }
                else
                {
                    cboProducto.Enabled = false;
                    btnAgregarProducto.Enabled = false;
                    MessageBox.Show("Este proveedor no tiene productos registrados.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProveedor.SelectedValue != null)
            {
                int proveedorId;

                if (cboProveedor.SelectedValue is int id)
                {
                    proveedorId = id;
                }
                else if (int.TryParse(cboProveedor.SelectedValue.ToString(), out proveedorId))
                {
                    // OK
                }
                else
                {
                    var proveedor = cboProveedor.SelectedItem as Proveedor;
                    if (proveedor != null)
                    {
                        proveedorId = proveedor.Id;
                    }
                    else
                    {
                        return;
                    }
                }

                cargarProductosProveedor(proveedorId);
            }
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedValue != null)
            {
                int productoProveedorId;

                if (cboProducto.SelectedValue is int id)
                {
                    productoProveedorId = id;
                }
                else if (int.TryParse(cboProducto.SelectedValue.ToString(), out productoProveedorId))
                {
                    // OK
                }
                else
                {
                    return;
                }

                var productoProveedor = ProductoProveedorCln.obtenerPorId(productoProveedorId);
                if (productoProveedor != null)
                {
                    nudPrecioCompra.Value = productoProveedor.PrecioProveedor;
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un producto válido del proveedor", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productoProveedorId;
            if (cboProducto.SelectedValue is int id)
            {
                productoProveedorId = id;
            }
            else if (!int.TryParse(cboProducto.SelectedValue.ToString(), out productoProveedorId))
            {
                MessageBox.Show("Error al obtener el producto seleccionado", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nudPrecioCompra.Value <= 0)
            {
                MessageBox.Show("El precio de compra debe ser mayor a 0", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var prodProv = ProductoProveedorCln.obtenerPorId(productoProveedorId);
            if (prodProv == null)
            {
                MessageBox.Show("Producto del proveedor no encontrado", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var existente = detallesCompra.FirstOrDefault(d => d.ProductoProveedorId == productoProveedorId);
            if (existente != null)
            {
                existente.Cantidad += (int)nudCantidad.Value;
                existente.PrecioUnitario = nudPrecioCompra.Value;
            }
            else
            {
                detallesCompra.Add(new DetalleCompra
                {
                    ProductoProveedorId = productoProveedorId,
                    ProductoNombre = prodProv.Nombre,
                    ProductoTalla = "UNI",
                    ProductoColor = "N/A",
                    Cantidad = (int)nudCantidad.Value,
                    PrecioUnitario = nudPrecioCompra.Value
                });
            }

            actualizarGridDetalle();
            calcularTotal();
            nudCantidad.Value = 1;
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto del detalle", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var det = (DetalleCompra)dgvDetalle.SelectedRows[0].DataBoundItem;
            detallesCompra.Remove(det);
            actualizarGridDetalle();
            calcularTotal();
        }

        private void actualizarGridDetalle()
        {
            dgvDetalle.DataSource = null;
            dgvDetalle.DataSource = detallesCompra.ToList();

            if (dgvDetalle.Columns.Count > 0)
            {
                if (dgvDetalle.Columns.Contains("Id"))
                    dgvDetalle.Columns["Id"].Visible = false;
                if (dgvDetalle.Columns.Contains("CompraId"))
                    dgvDetalle.Columns["CompraId"].Visible = false;
                if (dgvDetalle.Columns.Contains("ProductoProveedorId"))
                    dgvDetalle.Columns["ProductoProveedorId"].Visible = false;
                if (dgvDetalle.Columns.Contains("ProductoNombre"))
                    dgvDetalle.Columns["ProductoNombre"].HeaderText = "Producto";
                if (dgvDetalle.Columns.Contains("ProductoTalla"))
                    dgvDetalle.Columns["ProductoTalla"].HeaderText = "Talla";
                if (dgvDetalle.Columns.Contains("ProductoColor"))
                    dgvDetalle.Columns["ProductoColor"].HeaderText = "Color";
                if (dgvDetalle.Columns.Contains("Cantidad"))
                    dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
                if (dgvDetalle.Columns.Contains("PrecioUnitario"))
                {
                    dgvDetalle.Columns["PrecioUnitario"].HeaderText = "Precio Compra";
                    dgvDetalle.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                }
                if (dgvDetalle.Columns.Contains("Subtotal"))
                {
                    dgvDetalle.Columns["Subtotal"].HeaderText = "Subtotal";
                    dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                }
            }
        }

        private void calcularTotal()
        {
            txtTotal.Text = detallesCompra.Sum(d => d.Subtotal).ToString("N2");
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            configurarControles(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboProveedor.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor válido", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (detallesCompra.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto a la compra", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int proveedorId;
                if (cboProveedor.SelectedValue is int id)
                    proveedorId = id;
                else if (!int.TryParse(cboProveedor.SelectedValue.ToString(), out proveedorId))
                {
                    MessageBox.Show("Error al obtener el proveedor", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var compra = new Compra
                {
                    Fecha = dtpFecha.Value,
                    Total = decimal.Parse(txtTotal.Text),
                    EmpleadoId = empleadoActual.Id,
                    ProveedorId = proveedorId,
                    Detalles = detallesCompra.ToList()
                };

                CompraCln.crear(compra);
                MessageBox.Show("Compra registrada y stock sincronizado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                configurarControles(false);
                listarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la compra: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            configurarControles(false);
        }

        private void configurarControles(bool esNuevo)
        {
            cardDatosCompra.Enabled = esNuevo;
            cardProductos.Enabled = esNuevo;
            btnNueva.Enabled = !esNuevo;
            btnGuardar.Enabled = esNuevo;
            btnCancelar.Enabled = esNuevo;
            dgvCompras.Enabled = !esNuevo;
            btnEliminar.Enabled = !esNuevo;
            btnVerDetalle.Enabled = !esNuevo;

            if (esNuevo)
            {
                limpiarControles();
            }
        }

        private void limpiarControles()
        {
            dtpFecha.Value = DateTime.Now;
            if (cboProveedor.Items.Count > 0) cboProveedor.SelectedIndex = 0;
            nudCantidad.Value = 1;
            nudPrecioCompra.Value = 0;
            txtTotal.Text = "0.00";
            detallesCompra.Clear();
            dgvDetalle.DataSource = null;
        }

        private void listarCompras()
        {
            var compras = CompraCln.listar();
            dgvCompras.DataSource = compras;

            if (dgvCompras.Columns.Count > 0)
            {
                if (dgvCompras.Columns.Contains("Id"))
                    dgvCompras.Columns["Id"].HeaderText = "ID";
                if (dgvCompras.Columns.Contains("Fecha"))
                {
                    dgvCompras.Columns["Fecha"].HeaderText = "Fecha";
                    dgvCompras.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
                if (dgvCompras.Columns.Contains("Total"))
                {
                    dgvCompras.Columns["Total"].HeaderText = "Total";
                    dgvCompras.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
                if (dgvCompras.Columns.Contains("ProveedorNombre"))
                    dgvCompras.Columns["ProveedorNombre"].HeaderText = "Proveedor";
                if (dgvCompras.Columns.Contains("EmpleadoNombre"))
                    dgvCompras.Columns["EmpleadoNombre"].HeaderText = "Empleado";
                if (dgvCompras.Columns.Contains("EmpleadoId"))
                    dgvCompras.Columns["EmpleadoId"].Visible = false;
                if (dgvCompras.Columns.Contains("ProveedorId"))
                    dgvCompras.Columns["ProveedorId"].Visible = false;
                if (dgvCompras.Columns.Contains("Eliminado"))
                    dgvCompras.Columns["Eliminado"].Visible = false;
                if (dgvCompras.Columns.Contains("Detalles"))
                    dgvCompras.Columns["Detalles"].Visible = false;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una compra", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar esta compra?\nSe restará el stock de los productos.",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var compra = (Compra)dgvCompras.SelectedRows[0].DataBoundItem;
                    CompraCln.eliminar(compra.Id);
                    MessageBox.Show("Compra eliminada correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarCompras();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la compra: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvCompras.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una compra", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var compra = (Compra)dgvCompras.SelectedRows[0].DataBoundItem;
            var compraCompleta = CompraCln.obtenerPorId(compra.Id);

            if (compraCompleta != null)
            {
                string detalle = $"COMPRA #{compraCompleta.Id}\n\n";
                detalle += $"Fecha: {compraCompleta.Fecha:dd/MM/yyyy HH:mm}\n";
                detalle += $"Proveedor: {compraCompleta.ProveedorNombre}\n";
                detalle += $"Empleado: {compraCompleta.EmpleadoNombre}\n\n";
                detalle += "DETALLE:\n";
                detalle += new string('-', 60) + "\n";

                foreach (var item in compraCompleta.Detalles)
                {
                    detalle += $"{item.ProductoNombre} ({item.ProductoTalla} - {item.ProductoColor})\n";
                    detalle += $"  Cantidad: {item.Cantidad} x Bs. {item.PrecioUnitario:N2} = Bs. {item.Subtotal:N2}\n";
                }

                detalle += new string('-', 60) + "\n";
                detalle += $"TOTAL: Bs. {compraCompleta.Total:N2}";

                MessageBox.Show(detalle, "Detalle de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ❌ YA NO NECESITAS EL btnCerrar_Click - ESTÁ ELIMINADO
    }
}