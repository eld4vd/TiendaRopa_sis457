namespace CpTiendaRopa
{
    partial class FrmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnSalir = new FontAwesome.Sharp.IconButton();
            pnlMenuTransacciones = new Panel();
            btnCompras = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            lblTransacciones = new MaterialSkin.Controls.MaterialLabel();
            pnlMenuCatalogos = new Panel();
            btnProveedores = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            btnProductos = new FontAwesome.Sharp.IconButton();
            btnCategorias = new FontAwesome.Sharp.IconButton();
            lblCatalogos = new MaterialSkin.Controls.MaterialLabel();
            btnInicio = new FontAwesome.Sharp.IconButton();
            pnlLogo = new Panel();
            picLogo = new PictureBox();
            lblSubtitulo = new Label();
            lblLogo = new Label();
            pnlNavbar = new Panel();
            pnlUserInfo = new Panel();
            lblUsuarioNombre = new Label();
            lblUsuarioRol = new Label();
            picUsuario = new PictureBox();
            lblFecha = new MaterialSkin.Controls.MaterialLabel();
            lblTituloSeccion = new MaterialSkin.Controls.MaterialLabel();
            pnlContenido = new Panel();
            pnlSidebar.SuspendLayout();
            pnlMenuTransacciones.SuspendLayout();
            pnlMenuCatalogos.SuspendLayout();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlNavbar.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUsuario).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(17, 24, 39);
            pnlSidebar.Controls.Add(btnSalir);
            pnlSidebar.Controls.Add(pnlMenuTransacciones);
            pnlSidebar.Controls.Add(pnlMenuCatalogos);
            pnlSidebar.Controls.Add(btnInicio);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(3, 64);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(280, 633);
            pnlSidebar.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSalir.ForeColor = Color.FromArgb(156, 163, 175);
            btnSalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            btnSalir.IconColor = Color.FromArgb(156, 163, 175);
            btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalir.IconSize = 28;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(0, 558);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(15, 0, 0, 0);
            btnSalir.Size = new Size(280, 75);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "  Cerrar Sesión";
            btnSalir.TextAlign = ContentAlignment.MiddleLeft;
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // pnlMenuTransacciones
            // 
            pnlMenuTransacciones.Controls.Add(btnCompras);
            pnlMenuTransacciones.Controls.Add(btnVentas);
            pnlMenuTransacciones.Controls.Add(lblTransacciones);
            pnlMenuTransacciones.Dock = DockStyle.Top;
            pnlMenuTransacciones.Location = new Point(0, 445);
            pnlMenuTransacciones.Name = "pnlMenuTransacciones";
            pnlMenuTransacciones.Padding = new Padding(15, 12, 15, 12);
            pnlMenuTransacciones.Size = new Size(280, 160);
            pnlMenuTransacciones.TabIndex = 4;
            // 
            // btnCompras
            // 
            btnCompras.BackColor = Color.Transparent;
            btnCompras.Dock = DockStyle.Top;
            btnCompras.FlatAppearance.BorderSize = 0;
            btnCompras.FlatStyle = FlatStyle.Flat;
            btnCompras.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCompras.ForeColor = Color.FromArgb(156, 163, 175);
            btnCompras.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            btnCompras.IconColor = Color.FromArgb(156, 163, 175);
            btnCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCompras.IconSize = 24;
            btnCompras.ImageAlign = ContentAlignment.MiddleLeft;
            btnCompras.Location = new Point(15, 81);
            btnCompras.Name = "btnCompras";
            btnCompras.Padding = new Padding(15, 0, 0, 0);
            btnCompras.Size = new Size(250, 52);
            btnCompras.TabIndex = 2;
            btnCompras.Text = "  Compras";
            btnCompras.TextAlign = ContentAlignment.MiddleLeft;
            btnCompras.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCompras.UseVisualStyleBackColor = false;
            btnCompras.Click += btnCompras_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.Transparent;
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnVentas.ForeColor = Color.FromArgb(156, 163, 175);
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            btnVentas.IconColor = Color.FromArgb(156, 163, 175);
            btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas.IconSize = 24;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(15, 29);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(15, 0, 0, 0);
            btnVentas.Size = new Size(250, 52);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "  Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            lblTransacciones.ForeColor = Color.FromArgb(75, 85, 99);
            lblTransacciones.Location = new Point(15, 12);
            lblTransacciones.MouseState = MaterialSkin.MouseState.HOVER;
            lblTransacciones.Name = "lblTransacciones";
            lblTransacciones.Padding = new Padding(8, 8, 0, 12);
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
            pnlMenuCatalogos.Location = new Point(0, 190);
            pnlMenuCatalogos.Name = "pnlMenuCatalogos";
            pnlMenuCatalogos.Padding = new Padding(15, 12, 15, 12);
            pnlMenuCatalogos.Size = new Size(280, 255);
            pnlMenuCatalogos.TabIndex = 3;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.Transparent;
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnProveedores.ForeColor = Color.FromArgb(156, 163, 175);
            btnProveedores.IconChar = FontAwesome.Sharp.IconChar.TruckField;
            btnProveedores.IconColor = Color.FromArgb(156, 163, 175);
            btnProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProveedores.IconSize = 24;
            btnProveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btnProveedores.Location = new Point(15, 185);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(15, 0, 0, 0);
            btnProveedores.Size = new Size(250, 52);
            btnProveedores.TabIndex = 4;
            btnProveedores.Text = "  Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.Transparent;
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnClientes.ForeColor = Color.FromArgb(156, 163, 175);
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnClientes.IconColor = Color.FromArgb(156, 163, 175);
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 24;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(15, 133);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(15, 0, 0, 0);
            btnClientes.Size = new Size(250, 52);
            btnClientes.TabIndex = 3;
            btnClientes.Text = "  Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.Transparent;
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnProductos.ForeColor = Color.FromArgb(156, 163, 175);
            btnProductos.IconChar = FontAwesome.Sharp.IconChar.Box;
            btnProductos.IconColor = Color.FromArgb(156, 163, 175);
            btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProductos.IconSize = 24;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(15, 81);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(15, 0, 0, 0);
            btnProductos.Size = new Size(250, 52);
            btnProductos.TabIndex = 2;
            btnProductos.Text = "  Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = false;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnCategorias
            // 
            btnCategorias.BackColor = Color.Transparent;
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCategorias.ForeColor = Color.FromArgb(156, 163, 175);
            btnCategorias.IconChar = FontAwesome.Sharp.IconChar.Tags;
            btnCategorias.IconColor = Color.FromArgb(156, 163, 175);
            btnCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategorias.IconSize = 24;
            btnCategorias.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategorias.Location = new Point(15, 29);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(15, 0, 0, 0);
            btnCategorias.Size = new Size(250, 52);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "  Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            lblCatalogos.ForeColor = Color.FromArgb(75, 85, 99);
            lblCatalogos.Location = new Point(15, 12);
            lblCatalogos.MouseState = MaterialSkin.MouseState.HOVER;
            lblCatalogos.Name = "lblCatalogos";
            lblCatalogos.Padding = new Padding(8, 8, 0, 12);
            lblCatalogos.Size = new Size(83, 17);
            lblCatalogos.TabIndex = 0;
            lblCatalogos.Text = "CATÁLOGOS";
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(59, 130, 246);
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnInicio.ForeColor = Color.White;
            btnInicio.IconChar = FontAwesome.Sharp.IconChar.House;
            btnInicio.IconColor = Color.White;
            btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInicio.IconSize = 28;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(0, 120);
            btnInicio.Name = "btnInicio";
            btnInicio.Padding = new Padding(15, 0, 0, 0);
            btnInicio.Size = new Size(280, 70);
            btnInicio.TabIndex = 2;
            btnInicio.Text = "  Dashboard";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(31, 41, 55);
            pnlLogo.Controls.Add(picLogo);
            pnlLogo.Controls.Add(lblSubtitulo);
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(20, 20, 20, 15);
            pnlLogo.Size = new Size(280, 120);
            pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(20, 25);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(50, 50);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 8.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(156, 163, 175);
            lblSubtitulo.Location = new Point(75, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(131, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema Punto de Venta";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(73, 25);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(201, 37);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "👕 TiendaPOS";
            // 
            // pnlNavbar
            // 
            pnlNavbar.BackColor = Color.White;
            pnlNavbar.Controls.Add(pnlUserInfo);
            pnlNavbar.Controls.Add(lblFecha);
            pnlNavbar.Controls.Add(lblTituloSeccion);
            pnlNavbar.Dock = DockStyle.Top;
            pnlNavbar.Location = new Point(283, 64);
            pnlNavbar.Name = "pnlNavbar";
            pnlNavbar.Padding = new Padding(30, 12, 30, 12);
            pnlNavbar.Size = new Size(1014, 70);
            pnlNavbar.TabIndex = 1;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.Controls.Add(lblUsuarioNombre);
            pnlUserInfo.Controls.Add(lblUsuarioRol);
            pnlUserInfo.Controls.Add(picUsuario);
            pnlUserInfo.Dock = DockStyle.Right;
            pnlUserInfo.Location = new Point(784, 12);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(200, 46);
            pnlUserInfo.TabIndex = 2;
            // 
            // lblUsuarioNombre
            // 
            lblUsuarioNombre.AutoSize = true;
            lblUsuarioNombre.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblUsuarioNombre.ForeColor = Color.FromArgb(31, 41, 55);
            lblUsuarioNombre.Location = new Point(55, 5);
            lblUsuarioNombre.Name = "lblUsuarioNombre";
            lblUsuarioNombre.Size = new Size(57, 19);
            lblUsuarioNombre.TabIndex = 1;
            lblUsuarioNombre.Text = "Usuario";
            // 
            // lblUsuarioRol
            // 
            lblUsuarioRol.AutoSize = true;
            lblUsuarioRol.Font = new Font("Segoe UI", 8F);
            lblUsuarioRol.ForeColor = Color.FromArgb(107, 114, 128);
            lblUsuarioRol.Location = new Point(55, 26);
            lblUsuarioRol.Name = "lblUsuarioRol";
            lblUsuarioRol.Size = new Size(80, 13);
            lblUsuarioRol.TabIndex = 2;
            lblUsuarioRol.Text = "Administrador";
            // 
            // picUsuario
            // 
            picUsuario.BackColor = Color.FromArgb(59, 130, 246);
            picUsuario.Location = new Point(5, 3);
            picUsuario.Name = "picUsuario";
            picUsuario.Size = new Size(45, 45);
            picUsuario.SizeMode = PictureBoxSizeMode.Zoom;
            picUsuario.TabIndex = 0;
            picUsuario.TabStop = false;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Depth = 0;
            lblFecha.Dock = DockStyle.Left;
            lblFecha.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFecha.ForeColor = Color.FromArgb(107, 114, 128);
            lblFecha.Location = new Point(30, 12);
            lblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            lblFecha.Name = "lblFecha";
            lblFecha.Padding = new Padding(0, 15, 0, 0);
            lblFecha.Size = new Size(230, 19);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "📅 Lunes, 11 de Noviembre 2025";
            // 
            // lblTituloSeccion
            // 
            lblTituloSeccion.AutoSize = true;
            lblTituloSeccion.Depth = 0;
            lblTituloSeccion.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTituloSeccion.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTituloSeccion.Location = new Point(250, 20);
            lblTituloSeccion.MouseState = MaterialSkin.MouseState.HOVER;
            lblTituloSeccion.Name = "lblTituloSeccion";
            lblTituloSeccion.Size = new Size(117, 29);
            lblTituloSeccion.TabIndex = 1;
            lblTituloSeccion.Text = "Dashboard";
            lblTituloSeccion.Visible = false;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.FromArgb(249, 250, 251);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(283, 134);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(20);
            pnlContenido.Size = new Size(1014, 563);
            pnlContenido.TabIndex = 2;
            // 
            // FrmDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 700);
            Controls.Add(pnlContenido);
            Controls.Add(pnlNavbar);
            Controls.Add(pnlSidebar);
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Sistema POS";
            WindowState = FormWindowState.Maximized;
            Load += FrmDashboard_Load;
            pnlSidebar.ResumeLayout(false);
            pnlMenuTransacciones.ResumeLayout(false);
            pnlMenuTransacciones.PerformLayout();
            pnlMenuCatalogos.ResumeLayout(false);
            pnlMenuCatalogos.PerformLayout();
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlNavbar.ResumeLayout(false);
            pnlNavbar.PerformLayout();
            pnlUserInfo.ResumeLayout(false);
            pnlUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUsuario).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlNavbar;
        private Panel pnlContenido;
        private Panel pnlLogo;
        private Label lblLogo;
        private Label lblSubtitulo;
        private PictureBox picLogo;
        private FontAwesome.Sharp.IconButton btnInicio;
        private Panel pnlMenuCatalogos;
        private MaterialSkin.Controls.MaterialLabel lblCatalogos;
        private FontAwesome.Sharp.IconButton btnCategorias;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnProveedores;
        private Panel pnlMenuTransacciones;
        private MaterialSkin.Controls.MaterialLabel lblTransacciones;
        private FontAwesome.Sharp.IconButton btnVentas;
        private FontAwesome.Sharp.IconButton btnCompras;
        private FontAwesome.Sharp.IconButton btnSalir;
        private MaterialSkin.Controls.MaterialLabel lblFecha;
        private MaterialSkin.Controls.MaterialLabel lblTituloSeccion;
        private Panel pnlUserInfo;
        private PictureBox picUsuario;
        private Label lblUsuarioNombre;
        private Label lblUsuarioRol;
    }
}