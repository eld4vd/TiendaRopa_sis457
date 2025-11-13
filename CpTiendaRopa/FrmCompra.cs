using CadTiendaRopa;
using ClnTiendaRopa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CpTiendaRopa
{
    public partial class FrmCompra : Form
    {
        private Empleado empleadoActual;
        private List<DetalleCompra> detallesCompra;

        private List<Compra> comprasCompleto = new List<Compra>();
        private int paginaActual = 1;
        private const int REGISTROS_POR_PAGINA = 10;

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

            ConfigurarDataGridView();
            listar();
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW CON ESTILO PREMIUM
        private void ConfigurarDataGridView()
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.Columns.Clear();
            dgvCompras.AllowUserToResizeColumns = false;
            dgvCompras.RowTemplate.Height = 50;

            // Configuración visual moderna
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCompras.GridColor = Color.FromArgb(240, 240, 240);
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.MultiSelect = false;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.EnableHeadersVisualStyles = false;

            // Estilo del header
            dgvCompras.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvCompras.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvCompras.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dgvCompras.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            dgvCompras.ColumnHeadersHeight = 48;

            // Estilo de las filas
            dgvCompras.DefaultCellStyle.BackColor = Color.White;
            dgvCompras.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvCompras.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvCompras.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dgvCompras.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

            // Alternar colores de filas
            dgvCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvCompras.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvCompras.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);

            // Columna ID
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "N° Compra",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(99, 102, 241),
                    BackColor = Color.FromArgb(238, 242, 255),
                    SelectionBackColor = Color.FromArgb(224, 231, 255),
                    SelectionForeColor = Color.FromArgb(79, 70, 229),
                    Padding = new Padding(8, 5, 8, 5)
                }
            });

            // Columna Fecha
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "📅 Fecha",
                Width = 180,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F),
                    Format = "dd/MM/yyyy HH:mm",
                    ForeColor = Color.FromArgb(55, 65, 81)
                }
            });

            // Columna Proveedor
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProveedorNombre",
                HeaderText = "🏢 Proveedor",
                Width = 200,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Padding = new Padding(12, 5, 5, 5)
                }
            });

            // Columna Empleado
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmpleadoNombre",
                HeaderText = "👨‍💼 Comprador",
                Width = 180,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    BackColor = Color.FromArgb(249, 250, 251),
                    SelectionBackColor = Color.FromArgb(239, 246, 255)
                }
            });

            // Columna Total
            dgvCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "💰 Total",
                Width = 150,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Consolas", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(220, 38, 38),
                    Format = "C2",
                    Padding = new Padding(5, 5, 12, 5)
                }
            });

            // COLUMNA DE ACCIONES (Ver Detalle + Anular)
            var colAcciones = new DataGridViewTextBoxColumn
            {
                Name = "Acciones",
                HeaderText = "⚙️ Acciones",
                Width = 180,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    SelectionBackColor = Color.White
                }
            };
            dgvCompras.Columns.Add(colAcciones);

            // Eventos
            dgvCompras.CellPainting += DgvCompras_CellPainting;
            dgvCompras.CellClick += DgvCompras_CellClick;
            dgvCompras.CellMouseMove += DgvCompras_CellMouseMove;
        }

        // 🔥 DIBUJAR BOTONES (Ver Detalle + Anular)
        private void DgvCompras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvCompras.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle btnVer = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y + 10, 70, 32);
                Rectangle btnAnular = new Rectangle(e.CellBounds.X + 95, e.CellBounds.Y + 10, 70, 32);

                // Dibujar Ver Detalle (verde)
                using (GraphicsPath path = GetRoundedRectPath(btnVer, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnVer, Color.FromArgb(34, 197, 94), Color.FromArgb(22, 163, 74), LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(21, 128, 61), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("👁 Ver", font, textBrush, btnVer, sf);
                }

                // Dibujar Anular
                using (GraphicsPath path = GetRoundedRectPath(btnAnular, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnAnular, Color.FromArgb(239, 68, 68), Color.FromArgb(220, 38, 38), LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(185, 28, 28), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("✗ Anular", font, textBrush, btnAnular, sf);
                }

                e.Handled = true;
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void DgvCompras_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvCompras.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                dgvCompras.Cursor = Cursors.Hand;
            }
            else
            {
                dgvCompras.Cursor = Cursors.Default;
            }
        }

        private void DgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCompras.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                var compra = (Compra)dgvCompras.Rows[e.RowIndex].DataBoundItem;
                Rectangle cellRect = dgvCompras.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point mousePos = dgvCompras.PointToClient(Control.MousePosition);
                int relativeX = mousePos.X - cellRect.X;

                Rectangle btnVer = new Rectangle(15, 0, 70, cellRect.Height);
                Rectangle btnAnular = new Rectangle(95, 0, 70, cellRect.Height);

                if (relativeX >= btnVer.X && relativeX <= (btnVer.X + btnVer.Width))
                {
                    VerDetalleCompra(compra);
                }
                else if (relativeX >= btnAnular.X && relativeX <= (btnAnular.X + btnAnular.Width))
                {
                    AnularCompra(compra);
                }
            }
        }

        // 🔥 VER DETALLE DE COMPRA
        private void VerDetalleCompra(Compra compra)
        {
            var compraCompleta = CompraCln.obtenerPorId(compra.Id);

            if (compraCompleta == null || compraCompleta.Detalles == null || compraCompleta.Detalles.Count == 0)
            {
                MessageBox.Show("⚠️ No se encontraron detalles para esta compra", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje = $"📋 DETALLE DE COMPRA #{compra.Id}\n\n";
            mensaje += $"📅 Fecha: {compra.Fecha:dd/MM/yyyy HH:mm}\n";
            mensaje += $"🏢 Proveedor: {compra.ProveedorNombre}\n";
            mensaje += $"👨‍💼 Comprador: {compra.EmpleadoNombre}\n";
            mensaje += $"\n{'─',60}\n";
            mensaje += $"PRODUCTOS:\n";
            mensaje += $"{'─',60}\n\n";

            decimal subtotalGeneral = 0;
            foreach (var detalle in compraCompleta.Detalles)
            {
                mensaje += $"📦 {detalle.ProductoNombre}\n";
                mensaje += $"   📏 Talla: {detalle.ProductoTalla}  |  🎨 Color: {detalle.ProductoColor}\n";
                mensaje += $"   💰 {detalle.PrecioUnitario:C2} x {detalle.Cantidad} = {detalle.Subtotal:C2}\n\n";
                subtotalGeneral += detalle.Subtotal;
            }

            mensaje += $"{'─',60}\n";
            mensaje += $"💵 TOTAL: {compra.Total:C2}\n";
            mensaje += $"{'─',60}";

            MessageBox.Show(mensaje, "📦 Detalle de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 🔥 ANULAR COMPRA
        private void AnularCompra(Compra compra)
        {
            var confirmacion = MessageBox.Show(
                $"⚠️ ¿Está seguro de ANULAR esta compra?\n\n" +
                $"📋 Compra #: {compra.Id}\n" +
                $"📅 Fecha: {compra.Fecha:dd/MM/yyyy HH:mm}\n" +
                $"🏢 Proveedor: {compra.ProveedorNombre}\n" +
                $"💰 Total: {compra.Total:C2}\n\n" +
                $"⚠️ Esta acción no se puede deshacer.",
                "⚠️ Confirmar Anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                CompraCln.eliminar(compra.Id);
                MessageBox.Show(
                    $"✅ Compra anulada correctamente\n\n📋 Compra #{compra.Id}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                int registrosEnPaginaActual = comprasCompleto
                    .Skip((paginaActual - 1) * REGISTROS_POR_PAGINA)
                    .Take(REGISTROS_POR_PAGINA)
                    .Count();

                if (registrosEnPaginaActual == 1 && paginaActual > 1)
                {
                    paginaActual--;
                }

                listar();
            }
        }

        private void listar()
        {
            comprasCompleto = CompraCln.listar().OrderByDescending(c => c.Id).ToList();
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            var comprasPaginadas = comprasCompleto
                .Skip((paginaActual - 1) * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            dgvCompras.DataSource = comprasPaginadas;
            ActualizarInfoPaginacion();
        }

        private void ActualizarInfoPaginacion()
        {
            int totalPaginas = (int)Math.Ceiling((double)comprasCompleto.Count / REGISTROS_POR_PAGINA);
            if (totalPaginas == 0) totalPaginas = 1;

            decimal totalCompras = comprasCompleto.Sum(c => c.Total);
            lblPaginacion.Text = $"📄 Página {paginaActual} de {totalPaginas} | 💰 Total compras: {totalCompras:C2} | 📊 {comprasCompleto.Count} registros";

            btnAnterior.Enabled = paginaActual > 1;
            btnSiguiente.Enabled = paginaActual < totalPaginas;
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                MostrarPagina();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int totalPaginas = (int)Math.Ceiling((double)comprasCompleto.Count / REGISTROS_POR_PAGINA);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                paginaActual = 1;
                listar();
            }
            else
            {
                comprasCompleto = CompraCln.buscar(txtBuscar.Text.Trim())
                    .OrderByDescending(c => c.Id)
                    .ToList();
                paginaActual = 1;
                MostrarPagina();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        // 🔥 BOTÓN NUEVA COMPRA
        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "💡 Esta funcionalidad abrirá el formulario de:\n\n" +
                "📦 REGISTRO DE COMPRAS\n\n" +
                "Donde podrás:\n" +
                "• Seleccionar proveedor\n" +
                "• Agregar productos al inventario\n" +
                "• Calcular total\n" +
                "• Registrar la compra\n\n" +
                "✨ Será implementado próximamente",
                "Nueva Compra",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
    }
}