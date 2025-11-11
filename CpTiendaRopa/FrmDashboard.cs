using CadTiendaRopa;
using ClnTiendaRopa;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CpTiendaRopa
{
    public partial class FrmDashboard : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private Empleado empleadoActual;
        private Form formularioActivo;
        private IconButton botonActivo;
        private bool sidebarColapsado = false;
        private const int SIDEBAR_WIDTH_FULL = 280;
        private const int SIDEBAR_WIDTH_COLLAPSED = 70;

        public FrmDashboard(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
            
            ConfigurarHoverBotones();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            lblUsuarioNombre.Text = empleadoActual.Nombre;
            lblUsuarioRol.Text = "Empleado";
            lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM yyyy");
            
            CrearAvatarUsuario();
            AgregarBotonToggleSidebar(); // 🔥 TOGGLE RESTAURADO
            MostrarInicio();
            MarcarBotonActivo(btnInicio);
        }

        // 🔥 BOTÓN TOGGLE SIDEBAR
        private void AgregarBotonToggleSidebar()
        {
            var btnToggle = new IconButton
            {
                Size = new Size(50, 50),
                Location = new Point(10, 35),
                IconChar = IconChar.Bars,
                IconColor = Color.White,
                IconSize = 24,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.Click += BtnToggle_Click;
            pnlLogo.Controls.Add(btnToggle);
            btnToggle.BringToFront();
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            sidebarColapsado = !sidebarColapsado;
            
            if (sidebarColapsado)
            {
                // 🔥 COLAPSAR - Ajustar padding para no cortar iconos
                pnlSidebar.Width = SIDEBAR_WIDTH_COLLAPSED;
                
                // Ajustar padding del logo para centrar el botón toggle
                pnlLogo.Padding = new Padding(10, 20, 10, 15);
                
                lblLogo.Visible = false;
                lblSubtitulo.Visible = false;
                lblCatalogos.Visible = false;
                lblTransacciones.Visible = false;
                
                // Ocultar todo el texto
                btnInicio.Text = "";
                btnCategorias.Text = "";
                btnProductos.Text = "";
                btnClientes.Text = "";
                btnProveedores.Text = "";
                btnVentas.Text = "";
                btnCompras.Text = "";
                btnSalir.Text = "";
                
                // Centrar iconos y ajustar padding para evitar recorte
                btnInicio.ImageAlign = ContentAlignment.MiddleCenter;
                btnInicio.Padding = new Padding(0); // Sin padding extra
        
                btnCategorias.ImageAlign = ContentAlignment.MiddleCenter;
                btnCategorias.Padding = new Padding(0);
        
                btnProductos.ImageAlign = ContentAlignment.MiddleCenter;
                btnProductos.Padding = new Padding(0);
        
                btnClientes.ImageAlign = ContentAlignment.MiddleCenter;
                btnClientes.Padding = new Padding(0);
        
                btnProveedores.ImageAlign = ContentAlignment.MiddleCenter;
                btnProveedores.Padding = new Padding(0);
        
                btnVentas.ImageAlign = ContentAlignment.MiddleCenter;
                btnVentas.Padding = new Padding(0);
        
                btnCompras.ImageAlign = ContentAlignment.MiddleCenter;
                btnCompras.Padding = new Padding(0);
        
                btnSalir.ImageAlign = ContentAlignment.MiddleCenter;
                btnSalir.Padding = new Padding(0);
            }
            else
            {
                // 🔥 EXPANDIR - Restaurar padding normal
                pnlSidebar.Width = SIDEBAR_WIDTH_FULL;
        
                // Restaurar padding del logo
                pnlLogo.Padding = new Padding(20, 20, 20, 15);
        
                lblLogo.Visible = true;
                lblSubtitulo.Visible = true;
                lblCatalogos.Visible = true;
                lblTransacciones.Visible = true;
                
                // Restaurar texto
                btnInicio.Text = "  Dashboard";
                btnCategorias.Text = "  Categorías";
                btnProductos.Text = "  Productos";
                btnClientes.Text = "  Clientes";
                btnProveedores.Text = "  Proveedores";
                btnVentas.Text = "  Ventas";
                btnCompras.Text = "  Compras";
                btnSalir.Text = "  Cerrar Sesión";
        
                // Alinear a la izquierda with padding
                btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
                btnInicio.Padding = new Padding(15, 0, 0, 0);
        
                btnCategorias.ImageAlign = ContentAlignment.MiddleLeft;
                btnCategorias.Padding = new Padding(15, 0, 0, 0);
        
                btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
                btnProductos.Padding = new Padding(15, 0, 0, 0);
        
                btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
                btnClientes.Padding = new Padding(15, 0, 0, 0);
        
                btnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
                btnProveedores.Padding = new Padding(15, 0, 0, 0);
        
                btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
                btnVentas.Padding = new Padding(15, 0, 0, 0);
        
                btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
                btnCompras.Padding = new Padding(15, 0, 0, 0);
        
                btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
                btnSalir.Padding = new Padding(15, 0, 0, 0);
            }
        }

        private void ConfigurarHoverBotones()
        {
            foreach (Control control in pnlSidebar.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control btn in panel.Controls)
                    {
                        if (btn is IconButton iconBtn)
                        {
                            ConfigurarHoverBoton(iconBtn);
                        }
                    }
                }
                else if (control is IconButton iconBtn)
                {
                    ConfigurarHoverBoton(iconBtn);
                }
            }
        }

        private void ConfigurarHoverBoton(IconButton btn)
        {
            if (btn == btnSalir || btn == btnInicio) return;

            btn.MouseEnter += (s, e) =>
            {
                if (btn != botonActivo)
                {
                    btn.BackColor = Color.FromArgb(31, 41, 55);
                    btn.ForeColor = Color.White;
                    btn.IconColor = Color.White;
                }
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != botonActivo)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(156, 163, 175);
                    btn.IconColor = Color.FromArgb(156, 163, 175);
                }
            };
        }

        private void MarcarBotonActivo(IconButton btn)
        {
            if (botonActivo != null && botonActivo != btnInicio)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = Color.FromArgb(156, 163, 175);
                botonActivo.IconColor = Color.FromArgb(156, 163, 175);
            }

            if (btn != btnInicio)
            {
                botonActivo = btn;
                btn.BackColor = Color.FromArgb(37, 99, 235);
                btn.ForeColor = Color.White;
                btn.IconColor = Color.White;
            }
        }

        private void CrearAvatarUsuario()
        {
            Bitmap bmp = new Bitmap(45, 45);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(59, 130, 246));
                
                string inicial = empleadoActual.Nombre.Length > 0 ? 
                    empleadoActual.Nombre.Substring(0, 1).ToUpper() : "U";
                
                using (Font font = new Font("Segoe UI", 18, FontStyle.Bold))
                {
                    SizeF size = g.MeasureString(inicial, font);
                    PointF point = new PointF((45 - size.Width) / 2, (45 - size.Height) / 2);
                    g.DrawString(inicial, font, Brushes.White, point);
                }
            }
            picUsuario.Image = bmp;
        }

        private void MostrarFormularioEnPanel(Form formulario)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo.Dispose();
            }

            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            pnlContenido.Controls.Clear();
            pnlContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void MostrarInicio()
        {
            pnlContenido.Controls.Clear();

            var pnlPrincipal = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(249, 250, 251)
            };

            var lblTitulo = new Label
            {
                Text = "🛍️ Catálogo de Productos",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                AutoSize = true,
                Location = new Point(30, 20)
            };
            pnlPrincipal.Controls.Add(lblTitulo);

            var lblSubtitulo = new Label
            {
                Text = "Explore nuestra colección completa",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(107, 114, 128),
                AutoSize = true,
                Location = new Point(30, 65)
            };
            pnlPrincipal.Controls.Add(lblSubtitulo);

            var flowPanel = new FlowLayoutPanel
            {
                Location = new Point(20, 110),
                Width = pnlContenido.Width - 40,
                Height = pnlContenido.Height - 130,
                AutoScroll = true,
                Padding = new Padding(10),
                BackColor = Color.Transparent,
                WrapContents = true
            };

            try
            {
                var productos = ProductoCln.listar();

                if (productos.Count == 0)
                {
                    var lblSinProductos = new Label
                    {
                        Text = "📦 No hay productos disponibles",
                        Font = new Font("Segoe UI", 14, FontStyle.Regular),
                        ForeColor = Color.FromArgb(107, 114, 128),
                        AutoSize = true,
                        Location = new Point(30, 150)
                    };
                    pnlPrincipal.Controls.Add(lblSinProductos);
                }
                else
                {
                    foreach (var producto in productos)
                    {
                        var card = new ProductoCard(producto);
                        card.VerDetalleClick += Card_VerDetalleClick;
                        flowPanel.Controls.Add(card);
                    }
                    pnlPrincipal.Controls.Add(flowPanel);
                }
            }
            catch (Exception ex)
            {
                var lblError = new Label
                {
                    Text = $"❌ Error al cargar productos: {ex.Message}",
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    ForeColor = Color.FromArgb(239, 68, 68),
                    AutoSize = true,
                    Location = new Point(30, 150)
                };
                pnlPrincipal.Controls.Add(lblError);
            }

            pnlContenido.Controls.Add(pnlPrincipal);
        }

        private void Card_VerDetalleClick(object sender, Producto producto)
        {
            string detalle = $"📦 DETALLES DEL PRODUCTO\n\n";
            detalle += $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n";
            detalle += $"🏷️  Nombre: {producto.Nombre}\n\n";
            detalle += $"📏  Talla: {producto.Talla}\n";
            detalle += $"🎨  Color: {producto.Color}\n\n";
            detalle += $"💰  Precio: Bs. {producto.Precio:N2}\n";
            detalle += $"📦  Stock: {producto.Stock} unidades\n\n";
            detalle += $"📂  Categoría: {producto.Categoria}\n";
            detalle += $"🏭  Del Proveedor: {(producto.EsDeProveedor ? "Sí" : "No")}\n\n";
            
            if (!string.IsNullOrEmpty(producto.ImagenUrl))
            {
                detalle += $"🌐  Imagen: {producto.ImagenUrl}\n\n";
            }
            
            detalle += $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";

            MessageBox.Show(detalle, "Información del Producto", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== EVENTOS DEL SIDEBAR ====================

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
            MarcarBotonActivo(btnInicio);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FrmProducto());
            MarcarBotonActivo((IconButton)sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FrmCliente());
            MarcarBotonActivo((IconButton)sender);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FrmProveedor());
            MarcarBotonActivo((IconButton)sender);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FrmCategoria());
            MarcarBotonActivo((IconButton)sender);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FrmVenta(empleadoActual));
            MarcarBotonActivo((IconButton)sender);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            MostrarFormularioEnPanel(new FrmCompra(empleadoActual));
            MarcarBotonActivo((IconButton)sender);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Está seguro de cerrar sesión?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}