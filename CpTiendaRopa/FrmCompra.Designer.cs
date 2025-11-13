namespace CpTiendaRopa
{
    partial class FrmCompra
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

        private void InitializeComponent()
        {
            pnlContenedor = new Panel();
            pnlGrid = new Panel();
            dgvCompras = new DataGridView();
            pnlPaginacion = new Panel();
            btnSiguiente = new MaterialSkin.Controls.MaterialButton();
            lblPaginacion = new Label();
            btnAnterior = new MaterialSkin.Controls.MaterialButton();
            pnlBusqueda = new Panel();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            txtBuscar = new MaterialSkin.Controls.MaterialTextBox();
            lblSubtitulo = new Label();
            pnlFormulario = new Panel();
            cardProductos = new MaterialSkin.Controls.MaterialCard();
            dgvDetalle = new DataGridView();
            pnlBotonesDetalle = new Panel();
            btnQuitarProducto = new MaterialSkin.Controls.MaterialButton();
            btnAgregarProducto = new MaterialSkin.Controls.MaterialButton();
            txtTotal = new MaterialSkin.Controls.MaterialTextBox();
            nudPrecioCompra = new NumericUpDown();
            nudCantidad = new NumericUpDown();
            cboProducto = new MaterialSkin.Controls.MaterialComboBox();
            lblProductos = new MaterialSkin.Controls.MaterialLabel();
            cardDatosCompra = new MaterialSkin.Controls.MaterialCard();
            pnlBotones = new Panel();
            btnGuardar = new MaterialSkin.Controls.MaterialButton();
            btnCancelar = new MaterialSkin.Controls.MaterialButton();
            btnNueva = new MaterialSkin.Controls.MaterialButton();
            btnEliminar = new MaterialSkin.Controls.MaterialButton();
            btnVerDetalle = new MaterialSkin.Controls.MaterialButton();
            cboProveedor = new MaterialSkin.Controls.MaterialComboBox();
            dtpFecha = new DateTimePicker();
            lblEmpleado = new Label();
            pnlSuperior = new Panel();
            lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            pnlContenedor.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            pnlPaginacion.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            pnlFormulario.SuspendLayout();
            cardProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            pnlBotonesDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            cardDatosCompra.SuspendLayout();
            pnlBotones.SuspendLayout();
            pnlSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContenedor
            // 
            pnlContenedor.AutoScroll = true;
            pnlContenedor.BackColor = Color.FromArgb(249, 250, 251);
            pnlContenedor.Controls.Add(pnlGrid);
            pnlContenedor.Controls.Add(pnlBusqueda);
            pnlContenedor.Controls.Add(pnlFormulario);
            pnlContenedor.Controls.Add(pnlSuperior);
            pnlContenedor.Dock = DockStyle.Fill;
            pnlContenedor.Location = new Point(0, 0);
            pnlContenedor.Name = "pnlContenedor";
            pnlContenedor.Size = new Size(1060, 576);
            pnlContenedor.TabIndex = 0;
            // 
            // pnlSuperior
            // 
            pnlSuperior.BackColor = Color.White;
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Padding = new Padding(20, 15, 20, 15);
            pnlSuperior.Size = new Size(1043, 65);
            pnlSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Depth = 0;
            lblTitulo.Dock = DockStyle.Left;
            lblTitulo.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitulo.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(254, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "📦 Gestión de Compras";
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.FromArgb(249, 250, 251);
            pnlFormulario.Controls.Add(cardProductos);
            pnlFormulario.Controls.Add(cardDatosCompra);
            pnlFormulario.Dock = DockStyle.Top;
            pnlFormulario.Location = new Point(0, 65);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Padding = new Padding(20, 15, 20, 15);
            pnlFormulario.Size = new Size(1043, 480);
            pnlFormulario.TabIndex = 1;
            // 
            // cardDatosCompra
            // 
            cardDatosCompra.BackColor = Color.White;
            cardDatosCompra.Controls.Add(pnlBotones);
            cardDatosCompra.Controls.Add(lblEmpleado);
            cardDatosCompra.Controls.Add(dtpFecha);
            cardDatosCompra.Controls.Add(cboProveedor);
            cardDatosCompra.Depth = 0;
            cardDatosCompra.Dock = DockStyle.Top;
            cardDatosCompra.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardDatosCompra.Location = new Point(20, 15);
            cardDatosCompra.Margin = new Padding(14);
            cardDatosCompra.MouseState = MaterialSkin.MouseState.HOVER;
            cardDatosCompra.Name = "cardDatosCompra";
            cardDatosCompra.Padding = new Padding(25, 20, 25, 20);
            cardDatosCompra.Size = new Size(1003, 140);
            cardDatosCompra.TabIndex = 0;
            // 
            // cboProveedor
            // 
            cboProveedor.AutoResize = false;
            cboProveedor.BackColor = Color.FromArgb(255, 255, 255);
            cboProveedor.Depth = 0;
            cboProveedor.DrawMode = DrawMode.OwnerDrawVariable;
            cboProveedor.DropDownHeight = 174;
            cboProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProveedor.DropDownWidth = 121;
            cboProveedor.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboProveedor.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboProveedor.FormattingEnabled = true;
            cboProveedor.Hint = "🏢 Proveedor";
            cboProveedor.IntegralHeight = false;
            cboProveedor.ItemHeight = 43;
            cboProveedor.Location = new Point(25, 15);
            cboProveedor.MaxDropDownItems = 4;
            cboProveedor.MouseState = MaterialSkin.MouseState.OUT;
            cboProveedor.Name = "cboProveedor";
            cboProveedor.Size = new Size(350, 49);
            cboProveedor.StartIndex = 0;
            cboProveedor.TabIndex = 0;
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 10F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(25, 75);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 25);
            dtpFecha.TabIndex = 1;
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmpleado.ForeColor = Color.FromArgb(75, 85, 99);
            lblEmpleado.Location = new Point(240, 78);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(150, 19);
            lblEmpleado.TabIndex = 2;
            lblEmpleado.Text = "👨‍💼 Empleado: ----";
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnNueva);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnVerDetalle);
            pnlBotones.Dock = DockStyle.Right;
            pnlBotones.Location = new Point(618, 20);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Padding = new Padding(20, 0, 0, 0);
            pnlBotones.Size = new Size(360, 100);
            pnlBotones.TabIndex = 3;
            // 
            // btnNueva
            // 
            btnNueva.AutoSize = false;
            btnNueva.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNueva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNueva.Depth = 0;
            btnNueva.HighEmphasis = true;
            btnNueva.Icon = null;
            btnNueva.Location = new Point(20, 10);
            btnNueva.Margin = new Padding(4, 6, 4, 6);
            btnNueva.MouseState = MaterialSkin.MouseState.HOVER;
            btnNueva.Name = "btnNueva";
            btnNueva.NoAccentTextColor = Color.Empty;
            btnNueva.Size = new Size(100, 38);
            btnNueva.TabIndex = 0;
            btnNueva.Text = "➕ Nueva";
            btnNueva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNueva.UseAccentColor = false;
            btnNueva.UseVisualStyleBackColor = true;
            btnNueva.Click += btnNueva_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.AutoSize = false;
            btnEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEliminar.Depth = 0;
            btnEliminar.HighEmphasis = true;
            btnEliminar.Icon = null;
            btnEliminar.Location = new Point(130, 10);
            btnEliminar.Margin = new Padding(4, 6, 4, 6);
            btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.NoAccentTextColor = Color.Empty;
            btnEliminar.Size = new Size(100, 38);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "🗑️ Anular";
            btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEliminar.UseAccentColor = false;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.AutoSize = false;
            btnVerDetalle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVerDetalle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnVerDetalle.Depth = 0;
            btnVerDetalle.HighEmphasis = true;
            btnVerDetalle.Icon = null;
            btnVerDetalle.Location = new Point(240, 10);
            btnVerDetalle.Margin = new Padding(4, 6, 4, 6);
            btnVerDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.NoAccentTextColor = Color.Empty;
            btnVerDetalle.Size = new Size(100, 38);
            btnVerDetalle.TabIndex = 2;
            btnVerDetalle.Text = "👁 Ver";
            btnVerDetalle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnVerDetalle.UseAccentColor = false;
            btnVerDetalle.UseVisualStyleBackColor = true;
            btnVerDetalle.Click += btnVerDetalle_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.AutoSize = false;
            btnGuardar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardar.Depth = 0;
            btnGuardar.HighEmphasis = true;
            btnGuardar.Icon = null;
            btnGuardar.Location = new Point(20, 55);
            btnGuardar.Margin = new Padding(4, 6, 4, 6);
            btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.NoAccentTextColor = Color.Empty;
            btnGuardar.Size = new Size(150, 42);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGuardar.UseAccentColor = true;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSize = false;
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = false;
            btnCancelar.Icon = null;
            btnCancelar.Location = new Point(190, 55);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(150, 42);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cardProductos
            // 
            cardProductos.BackColor = Color.White;
            cardProductos.Controls.Add(txtTotal);
            cardProductos.Controls.Add(dgvDetalle);
            cardProductos.Controls.Add(pnlBotonesDetalle);
            cardProductos.Controls.Add(nudPrecioCompra);
            cardProductos.Controls.Add(nudCantidad);
            cardProductos.Controls.Add(cboProducto);
            cardProductos.Controls.Add(lblProductos);
            cardProductos.Depth = 0;
            cardProductos.Dock = DockStyle.Top;
            cardProductos.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardProductos.Location = new Point(20, 155);
            cardProductos.Margin = new Padding(14);
            cardProductos.MouseState = MaterialSkin.MouseState.HOVER;
            cardProductos.Name = "cardProductos";
            cardProductos.Padding = new Padding(25, 20, 25, 20);
            cardProductos.Size = new Size(1003, 310);
            cardProductos.TabIndex = 1;
            // 
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Depth = 0;
            lblProductos.Dock = DockStyle.Top;
            lblProductos.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblProductos.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblProductos.ForeColor = Color.FromArgb(75, 85, 99);
            lblProductos.Location = new Point(25, 20);
            lblProductos.MouseState = MaterialSkin.MouseState.HOVER;
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(148, 14);
            lblProductos.TabIndex = 0;
            lblProductos.Text = "📦 AGREGAR PRODUCTOS";
            // 
            // cboProducto
            // 
            cboProducto.AutoResize = false;
            cboProducto.BackColor = Color.FromArgb(255, 255, 255);
            cboProducto.Depth = 0;
            cboProducto.DrawMode = DrawMode.OwnerDrawVariable;
            cboProducto.DropDownHeight = 174;
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducto.DropDownWidth = 121;
            cboProducto.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboProducto.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboProducto.FormattingEnabled = true;
            cboProducto.Hint = "📦 Producto";
            cboProducto.IntegralHeight = false;
            cboProducto.ItemHeight = 43;
            cboProducto.Location = new Point(25, 45);
            cboProducto.MaxDropDownItems = 4;
            cboProducto.MouseState = MaterialSkin.MouseState.OUT;
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(400, 49);
            cboProducto.StartIndex = 0;
            cboProducto.TabIndex = 1;
            cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Segoe UI", 12F);
            nudCantidad.Location = new Point(435, 55);
            nudCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(100, 29);
            nudCantidad.TabIndex = 2;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudPrecioCompra
            // 
            nudPrecioCompra.DecimalPlaces = 2;
            nudPrecioCompra.Font = new Font("Segoe UI", 12F);
            nudPrecioCompra.Location = new Point(545, 55);
            nudPrecioCompra.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudPrecioCompra.Name = "nudPrecioCompra";
            nudPrecioCompra.Size = new Size(130, 29);
            nudPrecioCompra.TabIndex = 3;
            // 
            // pnlBotonesDetalle
            // 
            pnlBotonesDetalle.Controls.Add(btnAgregarProducto);
            pnlBotonesDetalle.Controls.Add(btnQuitarProducto);
            pnlBotonesDetalle.Location = new Point(685, 45);
            pnlBotonesDetalle.Name = "pnlBotonesDetalle";
            pnlBotonesDetalle.Size = new Size(290, 49);
            pnlBotonesDetalle.TabIndex = 4;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.AutoSize = false;
            btnAgregarProducto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAgregarProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAgregarProducto.Depth = 0;
            btnAgregarProducto.HighEmphasis = true;
            btnAgregarProducto.Icon = null;
            btnAgregarProducto.Location = new Point(5, 5);
            btnAgregarProducto.Margin = new Padding(4, 6, 4, 6);
            btnAgregarProducto.MouseState = MaterialSkin.MouseState.HOVER;
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.NoAccentTextColor = Color.Empty;
            btnAgregarProducto.Size = new Size(130, 40);
            btnAgregarProducto.TabIndex = 0;
            btnAgregarProducto.Text = "➕ Agregar";
            btnAgregarProducto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAgregarProducto.UseAccentColor = true;
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.AutoSize = false;
            btnQuitarProducto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQuitarProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQuitarProducto.Depth = 0;
            btnQuitarProducto.HighEmphasis = false;
            btnQuitarProducto.Icon = null;
            btnQuitarProducto.Location = new Point(145, 5);
            btnQuitarProducto.Margin = new Padding(4, 6, 4, 6);
            btnQuitarProducto.MouseState = MaterialSkin.MouseState.HOVER;
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.NoAccentTextColor = Color.Empty;
            btnQuitarProducto.Size = new Size(130, 40);
            btnQuitarProducto.TabIndex = 1;
            btnQuitarProducto.Text = "➖ Quitar";
            btnQuitarProducto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnQuitarProducto.UseAccentColor = false;
            btnQuitarProducto.UseVisualStyleBackColor = true;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.BackgroundColor = Color.White;
            dgvDetalle.BorderStyle = BorderStyle.None;
            dgvDetalle.ColumnHeadersHeight = 40;
            dgvDetalle.Location = new Point(25, 105);
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(950, 140);
            dgvDetalle.TabIndex = 5;
            // 
            // txtTotal
            // 
            txtTotal.AnimateReadOnly = false;
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Depth = 0;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTotal.Hint = "💰 TOTAL (Bs)";
            txtTotal.LeadingIcon = null;
            txtTotal.Location = new Point(25, 250);
            txtTotal.MaxLength = 50;
            txtTotal.MouseState = MaterialSkin.MouseState.OUT;
            txtTotal.Multiline = false;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(400, 50);
            txtTotal.TabIndex = 6;
            txtTotal.Text = "0.00";
            txtTotal.TrailingIcon = null;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.BackColor = Color.White;
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Controls.Add(lblSubtitulo);
            pnlBusqueda.Dock = DockStyle.Top;
            pnlBusqueda.Location = new Point(0, 545);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Padding = new Padding(20, 10, 20, 10);
            pnlBusqueda.Size = new Size(1043, 70);
            pnlBusqueda.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.AutoSize = false;
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.Dock = DockStyle.Right;
            btnBuscar.HighEmphasis = true;
            btnBuscar.Icon = null;
            btnBuscar.Location = new Point(903, 10);
            btnBuscar.Margin = new Padding(4, 6, 4, 6);
            btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NoAccentTextColor = Color.Empty;
            btnBuscar.Size = new Size(120, 50);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar.UseAccentColor = false;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.AnimateReadOnly = false;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Depth = 0;
            txtBuscar.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscar.Hint = "Buscar por N° Compra, Proveedor o Empleado...";
            txtBuscar.LeadingIcon = null;
            txtBuscar.Location = new Point(230, 10);
            txtBuscar.MaxLength = 50;
            txtBuscar.MouseState = MaterialSkin.MouseState.OUT;
            txtBuscar.Multiline = false;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(663, 50);
            txtBuscar.TabIndex = 1;
            txtBuscar.Text = "";
            txtBuscar.TrailingIcon = null;
            txtBuscar.KeyPress += txtBuscar_KeyPress;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblSubtitulo.ForeColor = Color.FromArgb(31, 41, 55);
            lblSubtitulo.Location = new Point(20, 25);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(181, 21);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "📋 Historial de Compras";
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.FromArgb(249, 250, 251);
            pnlGrid.Controls.Add(dgvCompras);
            pnlGrid.Controls.Add(pnlPaginacion);
            pnlGrid.Dock = DockStyle.Top;
            pnlGrid.Location = new Point(0, 615);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(20, 10, 20, 10);
            pnlGrid.Size = new Size(1043, 550);
            pnlGrid.TabIndex = 3;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = Color.White;
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.ColumnHeadersHeight = 45;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.Location = new Point(20, 10);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.RowTemplate.Height = 45;
            dgvCompras.ScrollBars = ScrollBars.Vertical;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(1003, 470);
            dgvCompras.TabIndex = 0;
            // 
            // pnlPaginacion
            // 
            pnlPaginacion.BackColor = Color.White;
            pnlPaginacion.Controls.Add(btnSiguiente);
            pnlPaginacion.Controls.Add(lblPaginacion);
            pnlPaginacion.Controls.Add(btnAnterior);
            pnlPaginacion.Dock = DockStyle.Bottom;
            pnlPaginacion.Location = new Point(20, 480);
            pnlPaginacion.Name = "pnlPaginacion";
            pnlPaginacion.Padding = new Padding(15, 8, 15, 8);
            pnlPaginacion.Size = new Size(1003, 60);
            pnlPaginacion.TabIndex = 1;
            // 
            // btnSiguiente
            // 
            btnSiguiente.AutoSize = false;
            btnSiguiente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSiguiente.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSiguiente.Depth = 0;
            btnSiguiente.Dock = DockStyle.Right;
            btnSiguiente.HighEmphasis = false;
            btnSiguiente.Icon = null;
            btnSiguiente.Location = new Point(868, 8);
            btnSiguiente.Margin = new Padding(4, 6, 4, 6);
            btnSiguiente.MouseState = MaterialSkin.MouseState.HOVER;
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.NoAccentTextColor = Color.Empty;
            btnSiguiente.Size = new Size(120, 44);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente ▶";
            btnSiguiente.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSiguiente.UseAccentColor = false;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.AutoSize = false;
            btnAnterior.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAnterior.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAnterior.Depth = 0;
            btnAnterior.Dock = DockStyle.Left;
            btnAnterior.HighEmphasis = false;
            btnAnterior.Icon = null;
            btnAnterior.Location = new Point(15, 8);
            btnAnterior.Margin = new Padding(4, 6, 4, 6);
            btnAnterior.MouseState = MaterialSkin.MouseState.HOVER;
            btnAnterior.Name = "btnAnterior";
            btnAnterior.NoAccentTextColor = Color.Empty;
            btnAnterior.Size = new Size(120, 44);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "◀ Anterior";
            btnAnterior.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnAnterior.UseAccentColor = false;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // lblPaginacion
            // 
            lblPaginacion.Dock = DockStyle.Fill;
            lblPaginacion.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblPaginacion.ForeColor = Color.FromArgb(75, 85, 99);
            lblPaginacion.Location = new Point(135, 8);
            lblPaginacion.Name = "lblPaginacion";
            lblPaginacion.Size = new Size(733, 44);
            lblPaginacion.TabIndex = 0;
            lblPaginacion.Text = "Página 1 de 1 | Total compras: Bs. 0.00 | 0 registros";
            lblPaginacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1060, 576);
            Controls.Add(pnlContenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCompra";
            Text = "Gestión de Compras";
            Load += FrmCompra_Load;
            pnlContenedor.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            pnlPaginacion.ResumeLayout(false);
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            cardProductos.ResumeLayout(false);
            cardProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            pnlBotonesDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudPrecioCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            cardDatosCompra.ResumeLayout(false);
            cardDatosCompra.PerformLayout();
            pnlBotones.ResumeLayout(false);
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlContenedor;
        private Panel pnlSuperior;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private Panel pnlFormulario;
        private MaterialSkin.Controls.MaterialCard cardDatosCompra;
        private MaterialSkin.Controls.MaterialComboBox cboProveedor;
        private DateTimePicker dtpFecha;
        private Label lblEmpleado;
        private Panel pnlBotones;
        private MaterialSkin.Controls.MaterialButton btnNueva;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
        private MaterialSkin.Controls.MaterialButton btnVerDetalle;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private MaterialSkin.Controls.MaterialCard cardProductos;
        private MaterialSkin.Controls.MaterialLabel lblProductos;
        private MaterialSkin.Controls.MaterialComboBox cboProducto;
        private NumericUpDown nudCantidad;
        private NumericUpDown nudPrecioCompra;
        private Panel pnlBotonesDetalle;
        private MaterialSkin.Controls.MaterialButton btnAgregarProducto;
        private MaterialSkin.Controls.MaterialButton btnQuitarProducto;
        private DataGridView dgvDetalle;
        private MaterialSkin.Controls.MaterialTextBox txtTotal;
        private Panel pnlBusqueda;
        private Label lblSubtitulo;
        private MaterialSkin.Controls.MaterialTextBox txtBuscar;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private Panel pnlGrid;
        private DataGridView dgvCompras;
        private Panel pnlPaginacion;
        private MaterialSkin.Controls.MaterialButton btnAnterior;
        private MaterialSkin.Controls.MaterialButton btnSiguiente;
        private Label lblPaginacion;
    }
}