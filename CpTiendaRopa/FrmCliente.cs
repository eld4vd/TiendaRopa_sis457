using CadTiendaRopa;
using ClnTiendaRopa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpTiendaRopa
{
    public partial class FrmCliente : Form
    {
        private bool esNuevo = false;
        private List<Cliente> clientesCompleto = new List<Cliente>();
        private int paginaActual = 1;
        private const int REGISTROS_POR_PAGINA = 10;

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            listar();
            configurarControles(false);
        }

        // 🔥 CONFIGURAR DATAGRIDVIEW CON COLUMNA DE ACCIONES
        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            // Columna ID
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Columna Nombre
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre Completo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 50
            });

            // Columna CI
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CI",
                HeaderText = "CI/NIT",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Columna Teléfono
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 🔥 COLUMNA DE ACCIONES
            var colAcciones = new DataGridViewButtonColumn
            {
                Name = "Acciones",
                HeaderText = "Acciones",
                Width = 150,
                Text = "Ver",
                UseColumnTextForButtonValue = false,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(249, 250, 251),
                    SelectionBackColor = Color.FromArgb(249, 250, 251)
                }
            };
            dgvClientes.Columns.Add(colAcciones);

            // Evento CellPainting para dibujar los botones personalizados
            dgvClientes.CellPainting += DgvClientes_CellPainting;
            dgvClientes.CellClick += DgvClientes_CellClick;
        }

        // 🔥 DIBUJAR BOTONES PERSONALIZADOS EN LA COLUMNA ACCIONES
        private void DgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Botón Editar
                var btnEditarRect = new Rectangle(
                    e.CellBounds.X + 10,
                    e.CellBounds.Y + (e.CellBounds.Height - 30) / 2,
                    60,
                    30
                );

                // Botón Eliminar
                var btnEliminarRect = new Rectangle(
                    e.CellBounds.X + 80,
                    e.CellBounds.Y + (e.CellBounds.Height - 30) / 2,
                    60,
                    30
                );

                // Dibujar botón Editar (Azul)
                using (var brush = new SolidBrush(Color.FromArgb(59, 130, 246)))
                using (var pen = new Pen(Color.FromArgb(37, 99, 235), 1))
                {
                    e.Graphics.FillRoundedRectangle(brush, btnEditarRect, 5);
                    e.Graphics.DrawRoundedRectangle(pen, btnEditarRect, 5);
                    
                    using (var font = new Font("Segoe UI", 8, FontStyle.Bold))
                    using (var textBrush = new SolidBrush(Color.White))
                    {
                        var textSize = e.Graphics.MeasureString("✏️ Editar", font);
                        var textX = btnEditarRect.X + (btnEditarRect.Width - textSize.Width) / 2;
                        var textY = btnEditarRect.Y + (btnEditarRect.Height - textSize.Height) / 2;
                        e.Graphics.DrawString("✏️ Editar", font, textBrush, textX, textY);
                    }
                }

                // Dibujar botón Eliminar (Rojo)
                using (var brush = new SolidBrush(Color.FromArgb(239, 68, 68)))
                using (var pen = new Pen(Color.FromArgb(220, 38, 38), 1))
                {
                    e.Graphics.FillRoundedRectangle(brush, btnEliminarRect, 5);
                    e.Graphics.DrawRoundedRectangle(pen, btnEliminarRect, 5);
                    
                    using (var font = new Font("Segoe UI", 8, FontStyle.Bold))
                    using (var textBrush = new SolidBrush(Color.White))
                    {
                        var textSize = e.Graphics.MeasureString("🗑️ Eliminar", font);
                        var textX = btnEliminarRect.X + (btnEliminarRect.Width - textSize.Width) / 2;
                        var textY = btnEliminarRect.Y + (btnEliminarRect.Height - textSize.Height) / 2;
                        e.Graphics.DrawString("🗑️ Eliminar", font, textBrush, textX, textY);
                    }
                }

                e.Handled = true;
            }
        }

        // 🔥 MANEJAR CLICS EN LOS BOTONES DE ACCIONES
        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                var cliente = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                var cellRect = dgvClientes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPoint = dgvClientes.PointToClient(Cursor.Position);
                var relativeX = clickPoint.X - cellRect.X;

                // Detectar qué botón se clickeó
                if (relativeX >= 10 && relativeX <= 70) // Botón Editar
                {
                    EditarCliente(cliente);
                }
                else if (relativeX >= 80 && relativeX <= 140) // Botón Eliminar
                {
                    EliminarCliente(cliente);
                }
            }
        }

        // 🔥 EDITAR CLIENTE (CARGAR DATOS Y HACER SCROLL ARRIBA)
        private void EditarCliente(Cliente cliente)
        {
            esNuevo = false;

            txtNombre.Text = cliente.Nombre;
            txtCI.Text = cliente.CI;
            txtTelefono.Text = cliente.Telefono;

            configurarControles(true);
            txtNombre.Focus();

            // Hacer scroll hacia arriba para mostrar el formulario
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
        }

        // 🔥 ELIMINAR CLIENTE (CON CONFIRMACIÓN)
        private void EliminarCliente(Cliente cliente)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar al cliente:\n\n{cliente.Nombre}?", 
                "⚠️ Confirmar Eliminación", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                ClienteCln.eliminar(cliente.Id);
                MessageBox.Show("Cliente eliminado correctamente", "✅ Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                listar();
            }
        }

        private void listar()
        {
            clientesCompleto = ClienteCln.listar();
            MostrarPagina();
        }

        private void MostrarPagina()
        {
            var clientesPaginados = clientesCompleto
                .Skip((paginaActual - 1) * REGISTROS_POR_PAGINA)
                .Take(REGISTROS_POR_PAGINA)
                .ToList();

            dgvClientes.DataSource = clientesPaginados;
            ActualizarInfoPaginacion();
        }

        private void ActualizarInfoPaginacion()
        {
            int totalPaginas = (int)Math.Ceiling((double)clientesCompleto.Count / REGISTROS_POR_PAGINA);
            lblPaginacion.Text = $"Página {paginaActual} de {totalPaginas} | Total: {clientesCompleto.Count} clientes";

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
            int totalPaginas = (int)Math.Ceiling((double)clientesCompleto.Count / REGISTROS_POR_PAGINA);
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                MostrarPagina();
            }
        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtCI.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = false; // Ya no se usa
            btnEliminar.Enabled = false; // Ya no se usa
            btnBuscar.Enabled = !habilitar;
            dgvClientes.Enabled = !habilitar;

            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;

            btnAnterior.Enabled = !habilitar && paginaActual > 1;
            btnSiguiente.Enabled = !habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtCI.Clear();
            txtTelefono.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            limpiarControles();
            configurarControles(true);
            txtNombre.Focus();
            
            // Hacer scroll hacia arriba
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Ya no se usa - ahora se edita desde la columna de acciones
            MessageBox.Show("Use los botones ✏️ Editar en la columna Acciones", 
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            var cliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                CI = txtCI.Text.Trim(),
                Telefono = txtTelefono.Text.Trim()
            };

            if (esNuevo)
            {
                ClienteCln.crear(cliente);
                MessageBox.Show("Cliente registrado correctamente", "✅ Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Buscar el cliente actual en la lista completa
                var clienteOriginal = clientesCompleto.FirstOrDefault(c => 
                    c.Nombre == txtNombre.Text.Trim() || c.CI == txtCI.Text.Trim());
                
                if (clienteOriginal != null)
                {
                    cliente.Id = clienteOriginal.Id;
                    ClienteCln.actualizar(cliente);
                    MessageBox.Show("Cliente actualizado correctamente", "✅ Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            // Ya no se usa - ahora se elimina desde la columna de acciones
            MessageBox.Show("Use los botones 🗑️ Elim en la columna Acciones", 
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
                clientesCompleto = ClienteCln.buscar(txtBuscar.Text.Trim());
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

    // 🔥 EXTENSIÓN PARA DIBUJAR RECTÁNGULOS REDONDEADOS
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius)
        {
            using (var path = GetRoundedRect(bounds, cornerRadius))
            {
                graphics.FillPath(brush, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            using (var path = GetRoundedRect(bounds, cornerRadius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Top left corner
            path.AddArc(arc, 180, 90);

            // Top right corner
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right corner
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left corner
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}