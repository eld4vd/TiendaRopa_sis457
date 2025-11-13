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
    public partial class FrmProveedor : Form
    {
        private bool esNuevo = false;
        private List<Proveedor> proveedoresCompleto = new List<Proveedor>();
        private int paginaActual = 1;
        private const int REGISTROS_POR_PAGINA = 10;
        private int proveedorEditandoId = 0;

        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            listar();
            configurarControles(false); // ✅ Esto debería habilitar btnNuevo
            
            // 🔥 AGREGAR ESTA LÍNEA PARA ASEGURAR:
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW CON ESTILO PREMIUM
        private void ConfigurarDataGridView()
        {
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.Columns.Clear();
            dgvProveedores.AllowUserToResizeColumns = false;
            dgvProveedores.RowTemplate.Height = 50;

            // Configuración visual moderna
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProveedores.GridColor = Color.FromArgb(240, 240, 240);
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect = false;
            dgvProveedores.RowHeadersVisible = false;
            dgvProveedores.EnableHeadersVisualStyles = false;

            // Estilo del header
            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvProveedores.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dgvProveedores.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            dgvProveedores.ColumnHeadersHeight = 48;

            // Estilo de las filas
            dgvProveedores.DefaultCellStyle.BackColor = Color.White;
            dgvProveedores.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvProveedores.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvProveedores.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dgvProveedores.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

            // Alternar colores de filas
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvProveedores.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvProveedores.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);

            // Columna ID
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 60,
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
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "🏢 Empresa",
                Width = 250,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Padding = new Padding(12, 5, 5, 5)
                }
            });

            // Columna Contacto
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Contacto",
                HeaderText = "👤 Contacto",
                Width = 200,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(55, 65, 81)
                }
            });

            // Columna Teléfono
            dgvProveedores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "📞 Teléfono",
                Width = 130,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Consolas", 9.5F),
                    ForeColor = Color.FromArgb(55, 65, 81)
                }
            });

            // COLUMNA DE ACCIONES
            var colAcciones = new DataGridViewTextBoxColumn
            {
                Name = "Acciones",
                HeaderText = "⚙️ Acciones",
                Width = 250,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    SelectionBackColor = Color.White
                }
            };
            dgvProveedores.Columns.Add(colAcciones);

            // Eventos
            dgvProveedores.CellPainting += DgvProveedores_CellPainting;
            dgvProveedores.CellClick += DgvProveedores_CellClick;
            dgvProveedores.CellMouseMove += DgvProveedores_CellMouseMove;
        }

        // 🔥 DIBUJAR 3 BOTONES: Editar, Productos, Eliminar
        private void DgvProveedores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvProveedores.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle btnEditar = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, 65, 30);
                Rectangle btnProductos = new Rectangle(e.CellBounds.X + 85, e.CellBounds.Y + 10, 85, 30);
                Rectangle btnEliminar = new Rectangle(e.CellBounds.X + 180, e.CellBounds.Y + 10, 60, 30);

                // Dibujar Editar (azul)
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
                using (Font font = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("✎ Editar", font, textBrush, btnEditar, sf);
                }

                // Dibujar Productos (verde)
                using (GraphicsPath path = GetRoundedRectPath(btnProductos, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnProductos, Color.FromArgb(34, 197, 94), Color.FromArgb(22, 163, 74), LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(21, 128, 61), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
                using (Font font = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("📦 Productos", font, textBrush, btnProductos, sf);
                }

                // Dibujar Eliminar (rojo)
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
                using (Font font = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    e.Graphics.DrawString("✗", font, textBrush, btnEliminar, sf);
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

        private void DgvProveedores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvProveedores.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                dgvProveedores.Cursor = Cursors.Hand;
            }
            else
            {
                dgvProveedores.Cursor = Cursors.Default;
            }
        }

        private void DgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProveedores.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                var proveedor = (Proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
                Rectangle cellRect = dgvProveedores.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point mousePos = dgvProveedores.PointToClient(Control.MousePosition);
                int relativeX = mousePos.X - cellRect.X;

                Rectangle btnEditar = new Rectangle(10, 0, 65, cellRect.Height);
                Rectangle btnProductos = new Rectangle(85, 0, 85, cellRect.Height);
                Rectangle btnEliminar = new Rectangle(180, 0, 60, cellRect.Height);

                if (relativeX >= btnEditar.X && relativeX <= (btnEditar.X + btnEditar.Width))
                {
                    EditarProveedor(proveedor);
                }
                else if (relativeX >= btnProductos.X && relativeX <= (btnProductos.X + btnProductos.Width))
                {
                    GestionarProductosProveedor(proveedor);
                }
                else if (relativeX >= btnEliminar.X && relativeX <= (btnEliminar.X + btnEliminar.Width))
                {
                    EliminarProveedor(proveedor);
                }
            }
        }

        private void EditarProveedor(Proveedor proveedor)
        {
            esNuevo = false;
            proveedorEditandoId = proveedor.Id;

            txtNombre.Text = proveedor.Nombre;
            txtContacto.Text = proveedor.Contacto;
            txtTelefono.Text = proveedor.Telefono;

            configurarControles(true);
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
            txtNombre.Focus();
        }

        private void EliminarProveedor(Proveedor proveedor)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar al proveedor?\n\n" +
                $"🏢 Empresa: {proveedor.Nombre}\n" +
                $"👤 Contacto: {proveedor.Contacto}\n" +
                $"📞 Teléfono: {proveedor.Telefono}",
                "⚠️ Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                ProveedorCln.eliminar(proveedor.Id);
                MessageBox.Show($"✅ Proveedor eliminado correctamente\n\n🏢 {proveedor.Nombre}",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int registrosEnPaginaActual = proveedoresCompleto
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

        // 🔥 GESTIONAR PRODUCTOS DEL PROVEEDOR (VERSIÓN CORREGIDA)
        private void GestionarProductosProveedor(Proveedor proveedor)
        {
            var frmProductos = new Form
            {
                Text = $"📦 Productos de {proveedor.Nombre}",
                Size = new Size(900, 650), // 🔥 AUMENTAR ALTURA
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(249, 250, 251)
            };

            var pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(249, 250, 251),
                Padding = new Padding(20)
            };
            frmProductos.Controls.Add(pnlMain);

            // 🔥 TÍTULO DEL MODAL
            var lblTituloModal = new Label
            {
                Text = $"📦 Gestión de Productos - {proveedor.Nombre}",
                Location = new Point(20, 10),
                Size = new Size(840, 30),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55)
            };
            pnlMain.Controls.Add(lblTituloModal);

            var cardForm = new MaterialSkin.Controls.MaterialCard
            {
                Location = new Point(20, 50),
                Size = new Size(840, 220),
                Padding = new Padding(20)
            };
            pnlMain.Controls.Add(cardForm);

            var lblTitulo = new MaterialSkin.Controls.MaterialLabel
            {
                Text = "➕ Agregar Nuevo Producto al Proveedor",
                Location = new Point(20, 15),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoSize = true
            };
            cardForm.Controls.Add(lblTitulo);

            var txtNombreProd = new MaterialSkin.Controls.MaterialTextBox
            {
                Location = new Point(20, 50),
                Size = new Size(380, 50),
                Hint = "📦 Nombre del producto"
            };
            cardForm.Controls.Add(txtNombreProd);

            var txtDescripcionProd = new MaterialSkin.Controls.MaterialTextBox
            {
                Location = new Point(420, 50),
                Size = new Size(380, 50),
                Hint = "📝 Descripción"
            };
            cardForm.Controls.Add(txtDescripcionProd);

            var cboCatProd = new MaterialSkin.Controls.MaterialComboBox
            {
                Location = new Point(20, 110),
                Size = new Size(280, 49),
                Hint = "🏷️ Categoría"
            };
            cboCatProd.DataSource = CategoriaCln.listar();
            cboCatProd.DisplayMember = "Nombre";
            cboCatProd.ValueMember = "Id";
            cboCatProd.SelectedIndex = -1;
            cardForm.Controls.Add(cboCatProd);

            var lblPrecio = new Label
            {
                Text = "💰 Precio del Proveedor (Bs):",
                Location = new Point(320, 115),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(75, 85, 99)
            };
            cardForm.Controls.Add(lblPrecio);

            var nudPrecio = new NumericUpDown
            {
                Location = new Point(320, 135),
                Size = new Size(180, 30),
                DecimalPlaces = 2,
                Maximum = 100000,
                Minimum = 0,
                Value = 0,
                Font = new Font("Segoe UI", 11F)
            };
            cardForm.Controls.Add(nudPrecio);

            var btnAgregar = new MaterialSkin.Controls.MaterialButton
            {
                Location = new Point(520, 125),
                Size = new Size(280, 42),
                Text = "➕ Agregar Producto al Proveedor",
                Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained,
                UseAccentColor = true
            };
            cardForm.Controls.Add(btnAgregar);

            // 🔥 DATAGRIDVIEW DE PRODUCTOS DEL PROVEEDOR
            var dgvProductosProv = new DataGridView
            {
                Location = new Point(20, 290),
                Size = new Size(840, 280),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 40,
                RowTemplate = { Height = 38 },
                EnableHeadersVisualStyles = false
            };
            pnlMain.Controls.Add(dgvProductosProv);

            // Estilo del header
            dgvProductosProv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgvProductosProv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductosProv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvProductosProv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

            dgvProductosProv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductosProv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "📦 Producto",
                Width = 250
            });

            dgvProductosProv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "📝 Descripción",
                Width = 200
            });

            dgvProductosProv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoriaNombre",
                HeaderText = "🏷️ Categoría",
                Width = 120
            });

            dgvProductosProv.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioProveedor",
                HeaderText = "💰 Precio",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            var colEliminar = new DataGridViewButtonColumn
            {
                Text = "🗑️ Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 100
            };
            dgvProductosProv.Columns.Add(colEliminar);

            void CargarProductosProveedor()
            {
                try
                {
                    var productos = ProductoProveedorCln.listarPorProveedor(proveedor.Id);
                    dgvProductosProv.DataSource = productos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CargarProductosProveedor();

            // 🔥 EVENTO AGREGAR PRODUCTO
            btnAgregar.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtNombreProd.Text))
                {
                    MessageBox.Show("⚠️ El nombre del producto es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreProd.Focus();
                    return;
                }

                if (nudPrecio.Value <= 0)
                {
                    MessageBox.Show("⚠️ El precio debe ser mayor a 0", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPrecio.Focus();
                    return;
                }

                if (cboCatProd.SelectedValue == null)
                {
                    MessageBox.Show("⚠️ Seleccione una categoría", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCatProd.Focus();
                    return;
                }

                var producto = new ProductoProveedor
                {
                    Nombre = txtNombreProd.Text.Trim(),
                    Descripcion = txtDescripcionProd.Text.Trim(),
                    PrecioProveedor = nudPrecio.Value,
                    ProveedorId = proveedor.Id,
                    CategoriaId = (int)cboCatProd.SelectedValue
                };

                try
                {
                    ProductoProveedorCln.crear(producto);
                    MessageBox.Show("✅ Producto agregado correctamente al proveedor", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombreProd.Clear();
                    txtDescripcionProd.Clear();
                    nudPrecio.Value = 0;
                    cboCatProd.SelectedIndex = -1;
                    txtNombreProd.Focus();
                    CargarProductosProveedor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // 🔥 EVENTO ELIMINAR PRODUCTO
            dgvProductosProv.CellClick += (s, ev) =>
            {
                if (ev.ColumnIndex == 5 && ev.RowIndex >= 0)
                {
                    var prod = (ProductoProveedor)dgvProductosProv.Rows[ev.RowIndex].DataBoundItem;
                    var confirmacion = MessageBox.Show(
                        $"¿Eliminar este producto del proveedor?\n\n📦 {prod.Nombre}\n💰 {prod.PrecioProveedor:C2}",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            ProductoProveedorCln.eliminar(prod.Id);
                            MessageBox.Show("✅ Producto eliminado del proveedor", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarProductosProveedor();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            frmProductos.ShowDialog();
        }

        private void listar()
        {
            proveedoresCompleto = ProveedorCln.listar().OrderByDescending(p => p.Id).ToList();
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            var proveedoresPaginados = proveedoresCompleto
                .Skip((paginaActual - 1) * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            dgvProveedores.DataSource = proveedoresPaginados;
            ActualizarInfoPaginacion();
        }

        private void ActualizarInfoPaginacion()
        {
            int totalPaginas = (int)Math.Ceiling((double)proveedoresCompleto.Count / REGISTROS_POR_PAGINA);
            if (totalPaginas == 0) totalPaginas = 1;

            lblPaginacion.Text = $"📄 Página {paginaActual} de {totalPaginas} | 🏢 Total: {proveedoresCompleto.Count} proveedores";

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
            int totalPaginas = (int)Math.Ceiling((double)proveedoresCompleto.Count / REGISTROS_POR_PAGINA);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtContacto.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnBuscar.Enabled = !habilitar;
            dgvProveedores.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnAnterior.Enabled = !habilitar && paginaActual > 1;
            btnSiguiente.Enabled = !habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtContacto.Clear();
            txtTelefono.Clear();
            proveedorEditandoId = 0;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("⚠️ El nombre de la empresa es obligatorio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("✅ Proveedor registrado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                proveedor.Id = proveedorEditandoId;
                ProveedorCln.actualizar(proveedor);
                MessageBox.Show("✅ Proveedor actualizado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                proveedoresCompleto = ProveedorCln.buscar(txtBuscar.Text.Trim())
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
    }
}