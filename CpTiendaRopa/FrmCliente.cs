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
    public partial class FrmCliente : Form
    {
        private bool esNuevo = false;
        private List<Cliente> clientesCompleto = new List<Cliente>();
        private int paginaActual = 1;
        private const int REGISTROS_POR_PAGINA = 10;
        private int clienteEditandoId = 0;
        private Rectangle rectBtnEditar;
        private Rectangle rectBtnEliminar;

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

        // 🔥 CONFIGURAR DATAGRIDVIEW CON ESTILO PREMIUM
        private void ConfigurarDataGridView()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();
            dgvClientes.AllowUserToResizeColumns = false;
            dgvClientes.RowTemplate.Height = 50;
            
            // Configuración visual moderna
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.GridColor = Color.FromArgb(240, 240, 240);
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.EnableHeadersVisualStyles = false;
            
            // Estilo del header
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgvClientes.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 8, 10, 8);
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(249, 250, 251);
            dgvClientes.ColumnHeadersHeight = 48;
            
            // Estilo de las filas
            dgvClientes.DefaultCellStyle.BackColor = Color.White;
            dgvClientes.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dgvClientes.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            
            // Alternar colores de filas
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvClientes.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvClientes.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(37, 99, 235);

            // Columna ID con badge
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
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
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "👤 Nombre Completo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Padding = new Padding(12, 5, 5, 5)
                }
            });

            // Columna CI
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CI",
                HeaderText = "🆔 CI/NIT",
                Width = 140,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Consolas", 10F),
                    ForeColor = Color.FromArgb(55, 65, 81),
                    BackColor = Color.FromArgb(249, 250, 251),
                    SelectionBackColor = Color.FromArgb(239, 246, 255)
                }
            });

            // Columna Teléfono
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "📞 Teléfono",
                Width = 150,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Consolas", 10F),
                    ForeColor = Color.FromArgb(55, 65, 81)
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
            dgvClientes.Columns.Add(colAcciones);

            // Eventos
            dgvClientes.CellPainting += DgvClientes_CellPainting;
            dgvClientes.CellClick += DgvClientes_CellClick; // 🔥 CAMBIADO a CellClick
            dgvClientes.CellMouseMove += DgvClientes_CellMouseMove;
        }

        // 🔥 DIBUJAR BOTONES
        private void DgvClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Definir rectángulos de botones
                Rectangle btnEditar = new Rectangle(
                    e.CellBounds.X + 15,
                    e.CellBounds.Y + 10,
                    70,
                    32
                );

                Rectangle btnEliminar = new Rectangle(
                    e.CellBounds.X + 95,
                    e.CellBounds.Y + 10,
                    70,
                    32
                );

                // Dibujar Editar
                using (GraphicsPath path = GetRoundedRectPath(btnEditar, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnEditar, 
                        Color.FromArgb(59, 130, 246), 
                        Color.FromArgb(37, 99, 235), 
                        LinearGradientMode.Vertical))
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
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString("✎ Editar", font, textBrush, btnEditar, sf);
                }

                // Dibujar Eliminar
                using (GraphicsPath path = GetRoundedRectPath(btnEliminar, 6))
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        btnEliminar, 
                        Color.FromArgb(239, 68, 68), 
                        Color.FromArgb(220, 38, 38), 
                        LinearGradientMode.Vertical))
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
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
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

        // 🔥 CAMBIAR CURSOR AL HOVER
        private void DgvClientes_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                dgvClientes.Cursor = Cursors.Hand;
            }
            else
            {
                dgvClientes.Cursor = Cursors.Default;
            }
        }

        // 🔥 MANEJAR CLICS - CORREGIDO
        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Acciones"].Index && e.RowIndex >= 0)
            {
                var cliente = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                
                // Obtener rectángulo de la celda
                Rectangle cellRect = dgvClientes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                
                // Obtener posición del mouse en coordenadas de pantalla
                Point mousePos = dgvClientes.PointToClient(Control.MousePosition);
                
                // Calcular posición relativa dentro de la celda
                int relativeX = mousePos.X - cellRect.X;
                
                // Definir áreas de los botones (igual que en CellPainting)
                Rectangle btnEditar = new Rectangle(15, 0, 70, cellRect.Height);
                Rectangle btnEliminar = new Rectangle(95, 0, 70, cellRect.Height);
                
                if (relativeX >= btnEditar.X && relativeX <= (btnEditar.X + btnEditar.Width))
                {
                    // Clic en Editar
                    EditarCliente(cliente);
                }
                else if (relativeX >= btnEliminar.X && relativeX <= (btnEliminar.X + btnEliminar.Width))
                {
                    // Clic en Eliminar
                    EliminarCliente(cliente);
                }
            }
        }

        private void EditarCliente(Cliente cliente)
        {
            esNuevo = false;
            clienteEditandoId = cliente.Id;

            txtNombre.Text = cliente.Nombre;
            txtCI.Text = cliente.CI;
            txtTelefono.Text = cliente.Telefono;

            configurarControles(true);
            pnlContenedor.AutoScrollPosition = new Point(0, 0);
            txtNombre.Focus();
        }

        private void EliminarCliente(Cliente cliente)
        {
            var confirmacion = MessageBox.Show(
                $"¿Está seguro de eliminar al cliente?\n\n" +
                $"📋 Nombre: {cliente.Nombre}\n" +
                $"🆔 CI: {cliente.CI}\n" +
                $"📞 Teléfono: {cliente.Telefono}",
                "⚠️ Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                ClienteCln.eliminar(cliente.Id);
                MessageBox.Show(
                    $"✅ Cliente eliminado correctamente\n\n📋 {cliente.Nombre}", 
                    "Éxito", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                
                int registrosEnPaginaActual = clientesCompleto
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
            clientesCompleto = ClienteCln.listar().OrderByDescending(c => c.Id).ToList();
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
            if (totalPaginas == 0) totalPaginas = 1;
            
            lblPaginacion.Text = $"📄 Página {paginaActual} de {totalPaginas} | 👥 Total: {clientesCompleto.Count} clientes";

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
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
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
            clienteEditandoId = 0;
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
                MessageBox.Show("⚠️ El nombre es obligatorio", "Validación", 
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
                MessageBox.Show("✅ Cliente registrado correctamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cliente.Id = clienteEditandoId;
                ClienteCln.actualizar(cliente);
                MessageBox.Show("✅ Cliente actualizado correctamente", "Éxito", 
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
                clientesCompleto = ClienteCln.buscar(txtBuscar.Text.Trim())
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