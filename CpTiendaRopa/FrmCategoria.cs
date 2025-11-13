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
    public partial class FrmCategoria : Form
    {
        private bool esNuevo = false;
        private List<Categoria> categoriasCompleto = new List<Categoria>();
        private int paginaActual = 1;
        private const int REGISTROS_POR_PAGINA = 10;
        private int categoriaEditandoId = 0;

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            listar();
            configurarControles(false);
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW CON ESTILO PREMIUM
        private void ConfigurarDataGridView()
        {
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.Columns.Clear();
            dgvCategorias.AllowUserToResizeColumns = false;
            dgvCategorias.RowTemplate.Height = 50;
            
            // Configuración visual moderna
            dgvCategorias.BorderStyle = BorderStyle.None;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCategorias.GridColor = Color.FromArgb(240, 240, 240);
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.EnableHeadersVisualStyles = false;
            
            // Estilo del header
            dgvCategorias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvCategorias.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvCategorias.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dgvCategorias.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            dgvCategorias.ColumnHeadersHeight = 48;
            
            // Estilo de las filas
            dgvCategorias.DefaultCellStyle.BackColor = Color.White;
            dgvCategorias.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvCategorias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvCategorias.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dgvCategorias.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            
            // Alternar colores de filas
            dgvCategorias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvCategorias.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvCategorias.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);

            // Columna ID con badge
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 70,
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
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "🏷️ Categoría",
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

            // Columna Descripción
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "📝 Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    Padding = new Padding(12, 5, 5, 5)
                }
            });

            // COLUMNA DE ACCIONES
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
            dgvCategorias.Columns.Add(colAcciones);

            // Eventos
            dgvCategorias.CellPainting += DgvCategorias_CellPainting;
            dgvCategorias.CellClick += DgvCategorias_CellClick;
            dgvCategorias.CellMouseMove += DgvCategorias_CellMouseMove;
        }

        // 🔥 DIBUJAR BOTONES
        private void DgvCategorias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvCategorias.Columns["Acciones"].Index && e.RowIndex >= 0)
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

        private void DgvCategorias_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvCategorias.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                dgvCategorias.Cursor = Cursors.Hand;
            }
            else
            {
                dgvCategorias.Cursor = Cursors.Default;
            }
        }

        private void DgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCategorias.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                var categoria = (Categoria)dgvCategorias.Rows[e.RowIndex].DataBoundItem;
                Rectangle cellRect = dgvCategorias.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point mousePos = dgvCategorias.PointToClient(Control.MousePosition);
                int relativeX = mousePos.X - cellRect.X;
                
                Rectangle btnEditar = new Rectangle(15, 0, 70, cellRect.Height);
                Rectangle btnEliminar = new Rectangle(95, 0, 70, cellRect.Height);
                
                if (relativeX >= btnEditar.X && relativeX <= (btnEditar.X + btnEditar.Width))
                {
                    EditarCategoria(categoria);
                }
                else if (relativeX >= btnEliminar.X && relativeX <= (btnEliminar.X + btnEliminar.Width))
                {
                    EliminarCategoria(categoria);
                }
            }
        }

        private void EditarCategoria(Categoria categoria)
        {
            esNuevo = false;
            categoriaEditandoId = categoria.Id;

            txtNombre.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;

            configurarControles(true);
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
            txtNombre.Focus();
        }

        private void EliminarCategoria(Categoria categoria)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar la categoría?\n\n" +
                $"🏷️ Nombre: {categoria.Nombre}\n" +
                $"📝 Descripción: {categoria.Descripcion}",
                "⚠️ Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                CategoriaCln.eliminar(categoria.Id);
                MessageBox.Show($"✅ Categoría eliminada correctamente\n\n🏷️ {categoria.Nombre}", 
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                int registrosEnPaginaActual = categoriasCompleto
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
            categoriasCompleto = CategoriaCln.listar().OrderByDescending(c => c.Id).ToList();
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            var categoriasPaginadas = categoriasCompleto
                .Skip((paginaActual - 1) * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            dgvCategorias.DataSource = categoriasPaginadas;
            ActualizarInfoPaginacion();
        }

        private void ActualizarInfoPaginacion()
        {
            int totalPaginas = (int)Math.Ceiling((double)categoriasCompleto.Count / REGISTROS_POR_PAGINA);
            if (totalPaginas == 0) totalPaginas = 1;
            
            lblPaginacion.Text = $"📄 Página {paginaActual} de {totalPaginas} | 🏷️ Total: {categoriasCompleto.Count} categorías";

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
            int totalPaginas = (int)Math.Ceiling((double)categoriasCompleto.Count / REGISTROS_POR_PAGINA);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnBuscar.Enabled = !habilitar;
            dgvCategorias.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnAnterior.Enabled = !habilitar && paginaActual > 1;
            btnSiguiente.Enabled = !habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            categoriaEditandoId = 0;
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
                MessageBox.Show("⚠️ El nombre de la categoría es obligatorio", "Validación", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var categoria = new Categoria
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim()
            };

            if (esNuevo)
            {
                CategoriaCln.crear(categoria);
                MessageBox.Show("✅ Categoría registrada correctamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                categoria.Id = categoriaEditandoId;
                CategoriaCln.actualizar(categoria);
                MessageBox.Show("✅ Categoría actualizada correctamente", "Éxito", 
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
                categoriasCompleto = CategoriaCln.buscar(txtBuscar.Text.Trim())
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
    }
}