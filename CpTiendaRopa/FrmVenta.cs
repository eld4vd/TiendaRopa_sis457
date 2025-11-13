using CadTiendaRopa;
using ClnTiendaRopa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpTiendaRopa
{
    public partial class FrmVenta : Form
    {
        private List<Producto> productosDisponibles = new List<Producto>();
        private DataTable dtCarrito = new DataTable();
        private int empleadoId = 1; // 🔥 OBTENER DEL USUARIO LOGUEADO

        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridProductos();
            ConfigurarDataGridCarrito();
            CargarClientes();
            CargarProductos();
            InicializarCarrito();
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW DE PRODUCTOS
        private void ConfigurarDataGridProductos()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(99, 102, 241)
                }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "📦 Producto",
                Width = 250,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(31, 41, 55)
                }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoriaNombre",
                HeaderText = "🏷️ Categoría",
                Width = 120
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Talla",
                HeaderText = "📏 Talla",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Color",
                HeaderText = "🎨 Color",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "💰 Precio",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Consolas", 9.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(34, 197, 94)
                }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "📊 Stock",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            });

            // Estilo
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 64, 175);
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW DEL CARRITO
        private void ConfigurarDataGridCarrito()
        {
            dgvCarrito.AutoGenerateColumns = false;

            // Estilo
            dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 197, 94);
            dgvCarrito.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCarrito.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            dgvCarrito.DefaultCellStyle.SelectionForeColor = Color.FromArgb(22, 101, 52);
            dgvCarrito.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
        }

        // 🔥 INICIALIZAR DATATABLE DEL CARRITO
        private void InicializarCarrito()
        {
            dtCarrito.Columns.Add("ProductoId", typeof(int));
            dtCarrito.Columns.Add("Producto", typeof(string));
            dtCarrito.Columns.Add("Talla", typeof(string));
            dtCarrito.Columns.Add("Color", typeof(string));
            dtCarrito.Columns.Add("Cantidad", typeof(int));
            dtCarrito.Columns.Add("PrecioUnitario", typeof(decimal));
            dtCarrito.Columns.Add("Subtotal", typeof(decimal));
            dtCarrito.Columns.Add("StockDisponible", typeof(int));

            dgvCarrito.DataSource = dtCarrito;

            // Configurar columnas
            dgvCarrito.Columns["ProductoId"].Visible = false;
            dgvCarrito.Columns["StockDisponible"].Visible = false;

            dgvCarrito.Columns["Producto"].HeaderText = "📦 Producto";
            dgvCarrito.Columns["Producto"].Width = 250;
            dgvCarrito.Columns["Producto"].ReadOnly = true;

            dgvCarrito.Columns["Talla"].HeaderText = "📏 Talla";
            dgvCarrito.Columns["Talla"].Width = 80;
            dgvCarrito.Columns["Talla"].ReadOnly = true;
            dgvCarrito.Columns["Talla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCarrito.Columns["Color"].HeaderText = "🎨 Color";
            dgvCarrito.Columns["Color"].Width = 100;
            dgvCarrito.Columns["Color"].ReadOnly = true;
            dgvCarrito.Columns["Color"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCarrito.Columns["Cantidad"].HeaderText = "🔢 Cantidad";
            dgvCarrito.Columns["Cantidad"].Width = 100;
            dgvCarrito.Columns["Cantidad"].ReadOnly = false; // ✅ EDITABLE
            dgvCarrito.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCarrito.Columns["Cantidad"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvCarrito.Columns["PrecioUnitario"].HeaderText = "💵 Precio Unit.";
            dgvCarrito.Columns["PrecioUnitario"].Width = 120;
            dgvCarrito.Columns["PrecioUnitario"].ReadOnly = true;
            dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCarrito.Columns["Subtotal"].HeaderText = "💰 Subtotal";
            dgvCarrito.Columns["Subtotal"].Width = 130;
            dgvCarrito.Columns["Subtotal"].ReadOnly = true;
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Font = new Font("Consolas", 10F, FontStyle.Bold);
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.ForeColor = Color.FromArgb(34, 197, 94);
        }

        // 🔥 CARGAR CLIENTES
        private void CargarClientes()
        {
            try
            {
                var clientes = ClienteCln.listar();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "Nombre";
                cboCliente.ValueMember = "Id";
                cboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔥 CARGAR PRODUCTOS
        private void CargarProductos()
        {
            try
            {
                productosDisponibles = ProductoCln.listar()
                    .Where(p => p.Stock > 0)
                    .OrderBy(p => p.Nombre)
                    .ToList();

                dgvProductos.DataSource = productosDisponibles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔥 BUSCAR PRODUCTOS
        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string criterio = txtBuscarProducto.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(criterio))
            {
                dgvProductos.DataSource = productosDisponibles;
            }
            else
            {
                var productosFiltrados = productosDisponibles.Where(p =>
                    p.Nombre.ToLower().Contains(criterio) ||
                    (p.CategoriaNombre != null && p.CategoriaNombre.ToLower().Contains(criterio)) ||
                    (p.Talla != null && p.Talla.ToLower().Contains(criterio)) ||
                    (p.Color != null && p.Color.ToLower().Contains(criterio))
                ).ToList();

                dgvProductos.DataSource = productosFiltrados;
            }
        }

        // 🔥 AGREGAR PRODUCTO AL CARRITO (DOBLE CLIC)
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var producto = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;

            if (producto.Stock <= 0)
            {
                MessageBox.Show("⚠️ Este producto no tiene stock disponible", "Sin Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si ya existe en el carrito
            var filaExistente = dtCarrito.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("ProductoId") == producto.Id);

            if (filaExistente != null)
            {
                int cantidadActual = filaExistente.Field<int>("Cantidad");
                int stockDisponible = filaExistente.Field<int>("StockDisponible");

                if (cantidadActual < stockDisponible)
                {
                    filaExistente["Cantidad"] = cantidadActual + 1;
                    filaExistente["Subtotal"] = (cantidadActual + 1) * filaExistente.Field<decimal>("PrecioUnitario");
                }
                else
                {
                    MessageBox.Show($"⚠️ Stock insuficiente\n\nStock disponible: {stockDisponible} unidades",
                        "Stock Agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                dtCarrito.Rows.Add(
                    producto.Id,
                    producto.Nombre,
                    producto.Talla,
                    producto.Color,
                    1, // Cantidad inicial
                    producto.Precio,
                    producto.Precio, // Subtotal
                    producto.Stock // Stock disponible
                );
            }

            CalcularTotal();
            MessageBox.Show($"✅ Producto agregado al carrito\n\n📦 {producto.Nombre}\n💰 {producto.Precio:C2}",
                "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 🔥 ACTUALIZAR SUBTOTAL AL EDITAR CANTIDAD
        private void dgvCarrito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCarrito.Columns["Cantidad"].Index)
            {
                var row = dgvCarrito.Rows[e.RowIndex];

                if (int.TryParse(row.Cells["Cantidad"].Value?.ToString(), out int cantidad))
                {
                    int stockDisponible = Convert.ToInt32(dtCarrito.Rows[e.RowIndex]["StockDisponible"]);

                    if (cantidad <= 0)
                    {
                        MessageBox.Show("⚠️ La cantidad debe ser mayor a 0", "Cantidad Inválida",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtCarrito.Rows[e.RowIndex]["Cantidad"] = 1;
                        return;
                    }

                    if (cantidad > stockDisponible)
                    {
                        MessageBox.Show($"⚠️ Stock insuficiente\n\nStock disponible: {stockDisponible} unidades",
                            "Stock Agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtCarrito.Rows[e.RowIndex]["Cantidad"] = stockDisponible;
                        cantidad = stockDisponible;
                    }

                    decimal precioUnitario = Convert.ToDecimal(dtCarrito.Rows[e.RowIndex]["PrecioUnitario"]);
                    dtCarrito.Rows[e.RowIndex]["Subtotal"] = cantidad * precioUnitario;

                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show("⚠️ Ingrese una cantidad válida", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtCarrito.Rows[e.RowIndex]["Cantidad"] = 1;
                }
            }
        }

        // 🔥 ELIMINAR PRODUCTO DEL CARRITO (TECLA DELETE)
        private void dgvCarrito_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var confirmacion = MessageBox.Show(
                $"¿Eliminar este producto del carrito?\n\n📦 {e.Row.Cells["Producto"].Value}",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                CalcularTotal();
            }
        }

        // 🔥 CALCULAR TOTAL
        private void CalcularTotal()
        {
            decimal total = dtCarrito.AsEnumerable()
                .Sum(row => row.Field<decimal>("Subtotal"));

            lblTotal.Text = total.ToString("N2");
            lblTotal.ForeColor = total > 0 ? Color.FromArgb(34, 197, 94) : Color.FromArgb(107, 114, 128);
        }

        // 🔥 PROCESAR VENTA
        private void btnProcesarVenta_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cboCliente.SelectedValue == null)
            {
                MessageBox.Show("⚠️ Seleccione un cliente para continuar", "Cliente Requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return;
            }

            if (dtCarrito.Rows.Count == 0)
            {
                MessageBox.Show("⚠️ Agregue productos al carrito para continuar", "Carrito Vacío",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscarProducto.Focus();
                return;
            }

            // Crear objeto Venta
            var venta = new Venta
            {
                Fecha = DateTime.Now,
                ClienteId = (int)cboCliente.SelectedValue,
                EmpleadoId = empleadoId,
                Total = dtCarrito.AsEnumerable().Sum(row => row.Field<decimal>("Subtotal")),
                Detalles = new List<DetalleVenta>()
            };

            // Agregar detalles
            foreach (DataRow row in dtCarrito.Rows)
            {
                venta.Detalles.Add(new DetalleVenta
                {
                    ProductoId = Convert.ToInt32(row["ProductoId"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"])
                });
            }

            // Confirmación
            var confirmacion = MessageBox.Show(
                $"🛒 CONFIRMAR VENTA\n\n" +
                $"👤 Cliente: {cboCliente.Text}\n" +
                $"📦 Productos: {venta.Detalles.Count}\n" +
                $"💰 Total: {venta.Total:C2}\n\n" +
                $"¿Desea procesar esta venta?",
                "Confirmar Venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    int ventaId = VentaCln.crear(venta);

                    MessageBox.Show(
                        $"✅ ¡VENTA PROCESADA EXITOSAMENTE!\n\n" +
                        $"🧾 Ticket Nº: {ventaId}\n" +
                        $"👤 Cliente: {cboCliente.Text}\n" +
                        $"💰 Total: {venta.Total:C2}\n" +
                        $"📅 Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}",
                        "Venta Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Limpiar formulario
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error al procesar la venta:\n\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 🔥 LIMPIAR FORMULARIO
        private void LimpiarFormulario()
        {
            cboCliente.SelectedIndex = -1;
            dtCarrito.Clear();
            txtBuscarProducto.Clear();
            lblTotal.Text = "0.00";
            lblTotal.ForeColor = Color.FromArgb(107, 114, 128);
            CargarProductos(); // Recargar para actualizar stock
            cboCliente.Focus();
        }
    }
}