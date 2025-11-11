namespace CpTiendaRopa
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlMenuTransacciones = new Panel();
            btnCompras = new MaterialSkin.Controls.MaterialButton();
            btnVentas = new MaterialSkin.Controls.MaterialButton();
            lblTransacciones = new MaterialSkin.Controls.MaterialLabel();
            pnlMenuCatalogos = new Panel();
            btnProveedores = new MaterialSkin.Controls.MaterialButton();
            btnClientes = new MaterialSkin.Controls.MaterialButton();
            btnProductos = new MaterialSkin.Controls.MaterialButton();
            btnCategorias = new MaterialSkin.Controls.MaterialButton();
            lblCatalogos = new MaterialSkin.Controls.MaterialLabel();
            pnlLogo = new Panel();
            lblSubtitulo = new MaterialSkin.Controls.MaterialLabel();
            lblTituloSistema = new MaterialSkin.Controls.MaterialLabel();
            pnlSuperior = new Panel();
            btnSalir = new MaterialSkin.Controls.MaterialButton();
            lblUsuario = new MaterialSkin.Controls.MaterialLabel();
            pnlContenedor = new Panel();
            pnlSidebar.SuspendLayout();
            pnlMenuTransacciones.SuspendLayout();
            pnlMenuCatalogos.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 39, 56);
            pnlSidebar.Controls.Add(pnlMenuTransacciones);
            pnlSidebar.Controls.Add(pnlMenuCatalogos);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 720);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlMenuTransacciones
            // 
            pnlMenuTransacciones.Controls.Add(btnCompras);
            pnlMenuTransacciones.Controls.Add(btnVentas);
            pnlMenuTransacciones.Controls.Add(lblTransacciones);
            pnlMenuTransacciones.Dock = DockStyle.Top;
            pnlMenuTransacciones.Location = new Point(0, 360);
            pnlMenuTransacciones.Name = "pnlMenuTransacciones";
            pnlMenuTransacciones.Padding = new Padding(12, 5, 12, 15);
            pnlMenuTransacciones.Size = new Size(260, 145);
            pnlMenuTransacciones.TabIndex = 2;
            // 
            // btnCompras
            // 
            btnCompras.AutoSize = false;
            btnCompras.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCompras.BackColor = Color.Transparent;
            btnCompras.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCompras.Depth = 0;
            btnCompras.Dock = DockStyle.Top;
            btnCompras.HighEmphasis = false;
            btnCompras.Icon = null;
            btnCompras.Location = new Point(12, 70);
            btnCompras.Margin = new Padding(0, 3, 0, 3);
            btnCompras.MouseState = MaterialSkin.MouseState.HOVER;
            btnCompras.Name = "btnCompras";
            btnCompras.NoAccentTextColor = Color.Empty;
            btnCompras.Size = new Size(236, 48);
            btnCompras.TabIndex = 2;
            btnCompras.Text = "   📥  Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnCompras.UseAccentColor = false;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // btnVentas
            // 
            btnVentas.AutoSize = false;
            btnVentas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVentas.BackColor = Color.Transparent;
            btnVentas.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVentas.Depth = 0;
            btnVentas.Dock = DockStyle.Top;
            btnVentas.HighEmphasis = false;
            btnVentas.Icon = null;
            btnVentas.Location = new Point(12, 22);
            btnVentas.Margin = new Padding(0, 3, 0, 3);
            btnVentas.MouseState = MaterialSkin.MouseState.HOVER;
            btnVentas.Name = "btnVentas";
            btnVentas.NoAccentTextColor = Color.Empty;
            btnVentas.Size = new Size(236, 48);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "   \U0001f6d2  Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnVentas.UseAccentColor = false;
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // lblTransacciones
            // 
            lblTransacciones.AutoSize = true;
            lblTransacciones.Depth = 0;
            lblTransacciones.Dock = DockStyle.Top;
            lblTransacciones.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTransacciones.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblTransacciones.ForeColor = Color.FromArgb(150, 170, 200);
            lblTransacciones.Location = new Point(12, 5);
            lblTransacciones.MouseState = MaterialSkin.MouseState.HOVER;
            lblTransacciones.Name = "lblTransacciones";
            lblTransacciones.Padding = new Padding(8, 12, 0, 10);
            lblTransacciones.Size = new Size(113, 17);
            lblTransacciones.TabIndex = 0;
            lblTransacciones.Text = "TRANSACCIONES";
            // 
            // pnlMenuCatalogos
            // 
            pnlMenuCatalogos.Controls.Add(btnProveedores);
            pnlMenuCatalogos.Controls.Add(btnClientes);
            pnlMenuCatalogos.Controls.Add(btnProductos);
            pnlMenuCatalogos.Controls.Add(btnCategorias);
            pnlMenuCatalogos.Controls.Add(lblCatalogos);
            pnlMenuCatalogos.Dock = DockStyle.Top;
            pnlMenuCatalogos.Location = new Point(0, 120);
            pnlMenuCatalogos.Name = "pnlMenuCatalogos";
            pnlMenuCatalogos.Padding = new Padding(12, 5, 12, 15);
            pnlMenuCatalogos.Size = new Size(260, 240);
            pnlMenuCatalogos.TabIndex = 1;
            // 
            // btnProveedores
            // 
            btnProveedores.AutoSize = false;
            btnProveedores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProveedores.BackColor = Color.Transparent;
            btnProveedores.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnProveedores.Depth = 0;
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.HighEmphasis = false;
            btnProveedores.Icon = null;
            btnProveedores.Location = new Point(12, 166);
            btnProveedores.Margin = new Padding(0, 3, 0, 3);
            btnProveedores.MouseState = MaterialSkin.MouseState.HOVER;
            btnProveedores.Name = "btnProveedores";
            btnProveedores.NoAccentTextColor = Color.Empty;
            btnProveedores.Size = new Size(236, 48);
            btnProveedores.TabIndex = 4;
            btnProveedores.Text = "   🏢  Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnProveedores.UseAccentColor = false;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnClientes
            // 
            btnClientes.AutoSize = false;
            btnClientes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClientes.BackColor = Color.Transparent;
            btnClientes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClientes.Depth = 0;
            btnClientes.Dock = DockStyle.Top;
            btnClientes.HighEmphasis = false;
            btnClientes.Icon = null;
            btnClientes.Location = new Point(12, 118);
            btnClientes.Margin = new Padding(0, 3, 0, 3);
            btnClientes.MouseState = MaterialSkin.MouseState.HOVER;
            btnClientes.Name = "btnClientes";
            btnClientes.NoAccentTextColor = Color.Empty;
            btnClientes.Size = new Size(236, 48);
            btnClientes.TabIndex = 3;
            btnClientes.Text = "   👥  Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnClientes.UseAccentColor = false;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProductos
            // 
            btnProductos.AutoSize = false;
            btnProductos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProductos.BackColor = Color.Transparent;
            btnProductos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnProductos.Depth = 0;
            btnProductos.Dock = DockStyle.Top;
            btnProductos.HighEmphasis = false;
            btnProductos.Icon = null;
            btnProductos.Location = new Point(12, 70);
            btnProductos.Margin = new Padding(0, 3, 0, 3);
            btnProductos.MouseState = MaterialSkin.MouseState.HOVER;
            btnProductos.Name = "btnProductos";
            btnProductos.NoAccentTextColor = Color.Empty;
            btnProductos.Size = new Size(236, 48);
            btnProductos.TabIndex = 2;
            btnProductos.Text = "   📦  Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnProductos.UseAccentColor = false;
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.AutoSize = false;
            btnCategorias.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCategorias.BackColor = Color.Transparent;
            btnCategorias.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCategorias.Depth = 0;
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.HighEmphasis = false;
            btnCategorias.Icon = null;
            btnCategorias.Location = new Point(12, 22);
            btnCategorias.Margin = new Padding(0, 3, 0, 3);
            btnCategorias.MouseState = MaterialSkin.MouseState.HOVER;
            btnCategorias.Name = "btnCategorias";
            btnCategorias.NoAccentTextColor = Color.Empty;
            btnCategorias.Size = new Size(236, 48);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "   📑  Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnCategorias.UseAccentColor = false;
            btnCategorias.UseVisualStyleBackColor = false;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // lblCatalogos
            // 
            lblCatalogos.AutoSize = true;
            lblCatalogos.Depth = 0;
            lblCatalogos.Dock = DockStyle.Top;
            lblCatalogos.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblCatalogos.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblCatalogos.ForeColor = Color.FromArgb(150, 170, 200);
            lblCatalogos.Location = new Point(12, 5);
            lblCatalogos.MouseState = MaterialSkin.MouseState.HOVER;
            lblCatalogos.Name = "lblCatalogos";
            lblCatalogos.Padding = new Padding(8, 12, 0, 10);
            lblCatalogos.Size = new Size(83, 17);
            lblCatalogos.TabIndex = 0;
            lblCatalogos.Text = "CATÁLOGOS";
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(33, 150, 243);
            pnlLogo.Controls.Add(lblSubtitulo);
            pnlLogo.Controls.Add(lblTituloSistema);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(20, 15, 20, 15);
            pnlLogo.Size = new Size(260, 120);
            pnlLogo.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Depth = 0;
            lblSubtitulo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 255);
            lblSubtitulo.Location = new Point(25, 62);
            lblSubtitulo.MouseState = MaterialSkin.MouseState.HOVER;
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(138, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión";
            // 
            // lblTituloSistema
            // 
            lblTituloSistema.AutoSize = true;
            lblTituloSistema.Depth = 0;
            lblTituloSistema.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTituloSistema.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblTituloSistema.ForeColor = Color.White;
            lblTituloSistema.Location = new Point(12, 19);
            lblTituloSistema.MouseState = MaterialSkin.MouseState.HOVER;
            lblTituloSistema.Name = "lblTituloSistema";
            lblTituloSistema.Size = new Size(231, 41);
            lblTituloSistema.TabIndex = 0;
            lblTituloSistema.Text = "👕 TiendaRopa";
            // 
            // pnlSuperior
            // 
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(btnSalir);
            pnlSuperior.Controls.Add(lblUsuario);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(260, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Padding = new Padding(25, 12, 25, 12);
            pnlSuperior.Size = new Size(1020, 60);
            pnlSuperior.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.AutoSize = false;
            btnSalir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSalir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSalir.Depth = 0;
            btnSalir.Dock = DockStyle.Right;
            btnSalir.HighEmphasis = true;
            btnSalir.Icon = null;
            btnSalir.Location = new Point(865, 12);
            btnSalir.Margin = new Padding(4, 6, 4, 6);
            btnSalir.MouseState = MaterialSkin.MouseState.HOVER;
            btnSalir.Name = "btnSalir";
            btnSalir.NoAccentTextColor = Color.Empty;
            btnSalir.Size = new Size(130, 36);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "🚪 Cerrar Sesión";
            btnSalir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSalir.UseAccentColor = false;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Depth = 0;
            lblUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsuario.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblUsuario.Location = new Point(25, 20);
            lblUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(251, 19);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario: Admin | 10/11/2025 23:00";
            // 
            // pnlContenedor
            // 
            pnlContenedor.BackColor = Color.FromArgb(245, 247, 250);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(260, 60);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Padding = new Padding(12);
            pnlContenedor.Size = new Size(1020, 660);
            pnlContenedor.TabIndex = 2;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlContenedor);
            Controls.Add(pnlSuperior);
            Controls.Add(pnlSidebar);
            DoubleBuffered = true;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Tienda de Ropa";
            WindowState = FormWindowState.Maximized;
            Load += FrmPrincipal_Load;
            pnlSidebar.ResumeLayout(false);
            pnlMenuTransacciones.ResumeLayout(false);
            pnlMenuTransacciones.PerformLayout();
            pnlMenuCatalogos.ResumeLayout(false);
            pnlMenuCatalogos.PerformLayout();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private MaterialSkin.Controls.MaterialLabel lblTituloSistema;
        private MaterialSkin.Controls.MaterialLabel lblSubtitulo;
        private System.Windows.Forms.Panel pnlMenuCatalogos;
        private MaterialSkin.Controls.MaterialLabel lblCatalogos;
        private MaterialSkin.Controls.MaterialButton btnCategorias;
        private MaterialSkin.Controls.MaterialButton btnProductos;
        private MaterialSkin.Controls.MaterialButton btnClientes;
        private MaterialSkin.Controls.MaterialButton btnProveedores;
        private System.Windows.Forms.Panel pnlMenuTransacciones;
        private MaterialSkin.Controls.MaterialLabel lblTransacciones;
        private MaterialSkin.Controls.MaterialButton btnVentas;
        private MaterialSkin.Controls.MaterialButton btnCompras;
        private System.Windows.Forms.Panel pnlSuperior;
        private MaterialSkin.Controls.MaterialLabel lblUsuario;
        private MaterialSkin.Controls.MaterialButton btnSalir;
        private System.Windows.Forms.Panel pnlContenedor;
    }
}