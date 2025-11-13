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
    public partial class FrmProducto : Form
    {
        private bool esNuevo = false;
        private List<Producto> productosCompleto = new List<Producto>();
        private int paginaActual = 1;
        private const int REGISTROS_POR_PAGINA = 10;
        private int productoEditandoId = 0;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarCategorias();
            listar();
            configurarControles(false);
        }

        // 🔥 CARGAR CATEGORÍAS EN EL COMBOBOX
        private void CargarCategorias()
        {
            try
            {
                var categorias = ProductoCln.listarCategorias();

                cboCategoria.DataSource = null;
                cboCategoria.DataSource = categorias;
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.ValueMember = "Id";
                cboCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW CON ESTILO PREMIUM
        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.RowTemplate.Height = 50;
            dgvProductos.ScrollBars = ScrollBars.Both; // 🔥 AGREGAR SCROLL HORIZONTAL

            // Configuración visual moderna
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.GridColor = Color.FromArgb(240, 240, 240);
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.EnableHeadersVisualStyles = false;

            // Estilo del header
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvProductos.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dgvProductos.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            dgvProductos.ColumnHeadersHeight = 48;

            // Estilo de las filas
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dgvProductos.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

            // Alternar colores de filas
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvProductos.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvProductos.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);

            // 🔥 ANCHOS FIJOS PARA TODAS LAS COLUMNAS (permite scroll horizontal)
            // Columna ID
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(99, 102, 241),
                    BackColor = Color.FromArgb(238, 242, 255),
                    SelectionBackColor = Color.FromArgb(224, 231, 255),
                    SelectionForeColor = Color.FromArgb(79, 70, 229),
                    Padding = new Padding(8, 5, 8, 5)
                }
            });

            // Columna Nombre
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "📦 Producto",
                Width = 200, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Padding = new Padding(12, 5, 5, 5)
                }
            });

            // Columna Categoría
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoriaNombre",
                HeaderText = "🏷️ Categoría",
                Width = 150, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(55, 65, 81)
                }
            });

            // Columna Talla
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Talla",
                HeaderText = "📏 Talla",
                Width = 80, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                }
            });

            // Columna Color
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Color",
                HeaderText = "🎨 Color",
                Width = 100, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F)
                }
            });

            // Columna Precio
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "💰 Precio",
                Width = 100, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Consolas", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(34, 197, 94),
                    Format = "C2",
                    Padding = new Padding(5, 5, 12, 5)
                }
            });

            // Columna Stock
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Stock",
                HeaderText = "📊 Stock",
                Width = 90, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                }
            });

            // 🔥 COLUMNA CHECKBOX "ES DE PROVEEDOR"
            dgvProductos.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "EsDeProveedor",
                HeaderText = "🏢 Proveedor",
                Width = 100, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    NullValue = false
                }
            });

            // COLUMNA DE ACCIONES
            var colAcciones = new DataGridViewTextBoxColumn
            {
                Name = "Acciones",
                HeaderText = "⚙️ Acciones",
                Width = 180, // 🔥 ANCHO FIJO
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    SelectionBackColor = Color.White
                }
            };
            dgvProductos.Columns.Add(colAcciones);

            // Eventos
            dgvProductos.CellPainting += DgvProductos_CellPainting;
            dgvProductos.CellClick += DgvProductos_CellClick;
            dgvProductos.CellMouseMove += DgvProductos_CellMouseMove;
        }

        // Continúa en la siguiente parte...        
        // 🔥 DIBUJAR BOTONES
        private void DgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvProductos.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle btnEditar = new Rectangle(e.CellBounds.X + 15, e.CellBounds.Y + 10, 70, 32);
                Rectangle btnEliminar = new Rectangle(e.CellBounds.X + 95, e.CellBounds.Y + 10, 70, 32);

                // Dibujar Editar
                using (GraphicsPath path = GetRoundedRectPath(btnEditar, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnEditar, Color.FromArgb(59, 130, 246), Color.FromArgb(37, 99, 235), LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(29, 78, 216), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("✎ Editar", font, textBrush, btnEditar, sf);
                }

                // Dibujar Eliminar
                using (GraphicsPath path = GetRoundedRectPath(btnEliminar, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnEliminar, Color.FromArgb(239, 68, 68), Color.FromArgb(220, 38, 38), LinearGradientMode.Vertical))
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
                    e.Graphics.DrawString("✗ Eliminar", font, textBrush, btnEliminar, sf);
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

        private void DgvProductos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvProductos.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                dgvProductos.Cursor = Cursors.Hand;
            }
            else
            {
                dgvProductos.Cursor = Cursors.Default;
            }
        }

        private void DgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProductos.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                var producto = (Producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                Rectangle cellRect = dgvProductos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point mousePos = dgvProductos.PointToClient(Control.MousePosition);
                int relativeX = mousePos.X - cellRect.X;

                Rectangle btnEditar = new Rectangle(15, 0, 70, cellRect.Height);
                Rectangle btnEliminar = new Rectangle(95, 0, 70, cellRect.Height);

                if (relativeX >= btnEditar.X && relativeX <= (btnEditar.X + btnEditar.Width))
                {
                    EditarProducto(producto);
                }
                else if (relativeX >= btnEliminar.X && relativeX <= (btnEliminar.X + btnEliminar.Width))
                {
                    EliminarProducto(producto);
                }
            }
        }

        // 🔥 EDITAR PRODUCTO - AGREGAR ImagenUrl
        private void EditarProducto(Producto producto)
        {
            esNuevo = false;
            productoEditandoId = producto.Id;

            txtNombre.Text = producto.Nombre;
            txtTalla.Text = producto.Talla;
            txtColor.Text = producto.Color;
            txtPrecio.Text = producto.Precio.ToString("N2");
            txtStock.Text = producto.Stock.ToString();
            txtImagenUrl.Text = producto.ImagenUrl ?? ""; // 🔥 AGREGAR

            if (producto.CategoriaId.HasValue)
            {
                cboCategoria.SelectedValue = producto.CategoriaId.Value;
            }
            else
            {
                cboCategoria.SelectedIndex = -1;
            }

            configurarControles(true);
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
            txtNombre.Focus();
        }

        // 🔥 ELIMINAR PRODUCTO
        private void EliminarProducto(Producto producto)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar el producto?\n\n" +
                $"📦 Nombre: {producto.Nombre}\n" +
                $"🏷️ Categoría: {producto.Categoria}\n" +
                $"📏 Talla: {producto.Talla}\n" +
                $"🎨 Color: {producto.Color}\n" +
                $"💰 Precio: {producto.Precio:C2}\n" +
                $"📊 Stock: {producto.Stock}",
                "⚠️ Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                ProductoCln.eliminar(producto.Id);
                MessageBox.Show($"✅ Producto eliminado correctamente\n\n📦 {producto.Nombre}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int registrosEnPaginaActual = productosCompleto
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
            productosCompleto = ProductoCln.listar().OrderByDescending(p => p.Id).ToList();
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            var productosPaginados = productosCompleto
                .Skip((paginaActual - 1) * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            dgvProductos.DataSource = productosPaginados;
            ActualizarInfoPaginacion();
        }

        private void ActualizarInfoPaginacion()
        {
            int totalPaginas = (int)Math.Ceiling((double)productosCompleto.Count / REGISTROS_POR_PAGINA);
            if (totalPaginas == 0) totalPaginas = 1;

            lblPaginacion.Text = $"📄 Página {paginaActual} de {totalPaginas} | 📦 Total: {productosCompleto.Count} productos";

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
            int totalPaginas = (int)Math.Ceiling((double)productosCompleto.Count / REGISTROS_POR_PAGINA);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        // 🔥 GUARDAR PRODUCTO - AGREGAR ImagenUrl
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("⚠️ El nombre del producto es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTalla.Text))
            {
                MessageBox.Show("⚠️ La talla es obligatoria", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTalla.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("⚠️ El color es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtColor.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("⚠️ Ingrese un precio válido mayor a 0", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("⚠️ Ingrese un stock válido (0 o mayor)", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return;
            }

            var producto = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Talla = txtTalla.Text.Trim(),
                Color = txtColor.Text.Trim(),
                Precio = precio,
                Stock = stock,
                CategoriaId = cboCategoria.SelectedValue != null ? (int?)cboCategoria.SelectedValue : null,
                ImagenUrl = string.IsNullOrWhiteSpace(txtImagenUrl.Text) ? null : txtImagenUrl.Text.Trim() // 🔥 AGREGAR
            };

            if (esNuevo)
            {
                ProductoCln.crear(producto);
                MessageBox.Show("✅ Producto registrado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                producto.Id = productoEditandoId;
                ProductoCln.actualizar(producto);
                MessageBox.Show("✅ Producto actualizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiarControles();
            configurarControles(false);
            listar();
        }

        // 🔥 LIMPIAR CONTROLES - AGREGAR ImagenUrl
        private void limpiarControles()
        {
            txtNombre.Clear();
            txtTalla.Clear();
            txtColor.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtImagenUrl.Clear(); // 🔥 AGREGAR
            cboCategoria.SelectedIndex = -1;
            productoEditandoId = 0;
        }

        // 🔥 CONFIGURAR CONTROLES - AGREGAR ImagenUrl
        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtTalla.Enabled = habilitar;
            txtColor.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtStock.Enabled = habilitar;
            txtImagenUrl.Enabled = habilitar; // 🔥 AGREGAR
            cboCategoria.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnBuscar.Enabled = !habilitar;
            dgvProductos.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnAnterior.Enabled = !habilitar && paginaActual > 1;
            btnSiguiente.Enabled = !habilitar;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            limpiarControles();
            configurarControles(true);
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("💡 Use los botones ✎ Editar en la columna Acciones",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            configurarControles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("💡 Use los botones ✗ Eliminar en la columna Acciones",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                productosCompleto = ProductoCln.buscar(txtBuscar.Text.Trim())
                    .OrderByDescending(p => p.Id)
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

        // 🔥 VALIDAR SOLO NÚMEROS CON DECIMALES EN PRECIO
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Solo un punto decimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.IndexOfAny(new char[] { '.', ',' }) > -1)
            {
                e.Handled = true;
            }
        }

        // 🔥 VALIDAR SOLO NÚMEROS EN STOCK
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}