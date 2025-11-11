namespace CpTiendaRopa
{
    partial class FrmVenta
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
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            this.pnlIzquierdo = new System.Windows.Forms.Panel();
            this.pnlBotonesVenta = new System.Windows.Forms.Panel();
            this.btnNueva = new MaterialSkin.Controls.MaterialButton();
            this.btnGuardar = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.cardDetalle = new MaterialSkin.Controls.MaterialCard();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.pnlTotalVenta = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotalVenta = new MaterialSkin.Controls.MaterialLabel();
            this.cardProductos = new MaterialSkin.Controls.MaterialCard();
            this.btnQuitarProducto = new MaterialSkin.Controls.MaterialButton();
            this.btnAgregarProducto = new MaterialSkin.Controls.MaterialButton();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new MaterialSkin.Controls.MaterialLabel();
            this.lblStock = new MaterialSkin.Controls.MaterialLabel();
            this.lblPrecioUnitario = new MaterialSkin.Controls.MaterialLabel();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new MaterialSkin.Controls.MaterialLabel();
            this.cardDatosVenta = new MaterialSkin.Controls.MaterialCard();
            this.lblEmpleado = new MaterialSkin.Controls.MaterialLabel();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new MaterialSkin.Controls.MaterialLabel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new MaterialSkin.Controls.MaterialLabel();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.pnlBotonesLista = new System.Windows.Forms.Panel();
            this.btnEliminar = new MaterialSkin.Controls.MaterialButton();
            this.btnVerDetalle = new MaterialSkin.Controls.MaterialButton();
            this.pnlSuperior.SuspendLayout();
            this.pnlIzquierdo.SuspendLayout();
            this.pnlBotonesVenta.SuspendLayout();
            this.cardDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlTotalVenta.SuspendLayout();
            this.cardProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.cardDatosVenta.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.pnlBotonesLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.White;
            this.pnlSuperior.Controls.Add(this.lblTitulo);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlSuperior.Size = new System.Drawing.Size(1060, 50);
            this.pnlSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Depth = 0;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitulo.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblTitulo.Location = new System.Drawing.Point(15, 12);
            this.lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(188, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🛒 Gestión de Ventas";
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.Controls.Add(this.pnlBotonesVenta);
            this.pnlIzquierdo.Controls.Add(this.cardDetalle);
            this.pnlIzquierdo.Controls.Add(this.cardProductos);
            this.pnlIzquierdo.Controls.Add(this.cardDatosVenta);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIzquierdo.Location = new System.Drawing.Point(0, 50);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.pnlIzquierdo.Size = new System.Drawing.Size(450, 526);
            this.pnlIzquierdo.TabIndex = 1;
            // 
            // pnlBotonesVenta
            // 
            this.pnlBotonesVenta.Controls.Add(this.btnNueva);
            this.pnlBotonesVenta.Controls.Add(this.btnGuardar);
            this.pnlBotonesVenta.Controls.Add(this.btnCancelar);
            this.pnlBotonesVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotonesVenta.Location = new System.Drawing.Point(10, 470);
            this.pnlBotonesVenta.Name = "pnlBotonesVenta";
            this.pnlBotonesVenta.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.pnlBotonesVenta.Size = new System.Drawing.Size(435, 51);
            this.pnlBotonesVenta.TabIndex = 3;
            // 
            // btnNueva
            // 
            this.btnNueva.AutoSize = false;
            this.btnNueva.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNueva.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNueva.Depth = 0;
            this.btnNueva.HighEmphasis = true;
            this.btnNueva.Icon = null;
            this.btnNueva.Location = new System.Drawing.Point(15, 8);
            this.btnNueva.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNueva.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNueva.Size = new System.Drawing.Size(125, 36);
            this.btnNueva.TabIndex = 0;
            this.btnNueva.Text = "🆕 Nueva";
            this.btnNueva.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNueva.UseAccentColor = false;
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGuardar.Depth = 0;
            this.btnGuardar.HighEmphasis = true;
            this.btnGuardar.Icon = null;
            this.btnGuardar.Location = new System.Drawing.Point(148, 8);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGuardar.Size = new System.Drawing.Size(130, 36);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "💾 Guardar";
            this.btnGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGuardar.UseAccentColor = true;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = false;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(286, 8);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(130, 36);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "❌ Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cardDetalle
            // 
            this.cardDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardDetalle.Controls.Add(this.dgvDetalle);
            this.cardDetalle.Controls.Add(this.pnlTotalVenta);
            this.cardDetalle.Depth = 0;
            this.cardDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardDetalle.Location = new System.Drawing.Point(10, 270);
            this.cardDetalle.Margin = new System.Windows.Forms.Padding(10);
            this.cardDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDetalle.Name = "cardDetalle";
            this.cardDetalle.Padding = new System.Windows.Forms.Padding(10);
            this.cardDetalle.Size = new System.Drawing.Size(435, 200);
            this.cardDetalle.TabIndex = 2;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(10, 10);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(415, 140);
            this.dgvDetalle.TabIndex = 0;
            // 
            // pnlTotalVenta
            // 
            this.pnlTotalVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pnlTotalVenta.Controls.Add(this.lblTotalVenta);
            this.pnlTotalVenta.Controls.Add(this.txtTotal);
            this.pnlTotalVenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotalVenta.Location = new System.Drawing.Point(10, 150);
            this.pnlTotalVenta.Name = "pnlTotalVenta";
            this.pnlTotalVenta.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlTotalVenta.Size = new System.Drawing.Size(415, 40);
            this.pnlTotalVenta.TabIndex = 1;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(250, 7);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(140, 27);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Depth = 0;
            this.lblTotalVenta.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalVenta.ForeColor = System.Drawing.Color.White;
            this.lblTotalVenta.Location = new System.Drawing.Point(15, 10);
            this.lblTotalVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(93, 17);
            this.lblTotalVenta.TabIndex = 0;
            this.lblTotalVenta.Text = "TOTAL (Bs.):";
            // 
            // cardProductos
            // 
            this.cardProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardProductos.Controls.Add(this.btnQuitarProducto);
            this.cardProductos.Controls.Add(this.btnAgregarProducto);
            this.cardProductos.Controls.Add(this.nudCantidad);
            this.cardProductos.Controls.Add(this.lblCantidad);
            this.cardProductos.Controls.Add(this.lblStock);
            this.cardProductos.Controls.Add(this.lblPrecioUnitario);
            this.cardProductos.Controls.Add(this.cboProducto);
            this.cardProductos.Controls.Add(this.lblProducto);
            this.cardProductos.Depth = 0;
            this.cardProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardProductos.Location = new System.Drawing.Point(10, 115);
            this.cardProductos.Margin = new System.Windows.Forms.Padding(10);
            this.cardProductos.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardProductos.Name = "cardProductos";
            this.cardProductos.Padding = new System.Windows.Forms.Padding(10);
            this.cardProductos.Size = new System.Drawing.Size(435, 155);
            this.cardProductos.TabIndex = 1;
            // 
            // btnQuitarProducto
            // 
            this.btnQuitarProducto.AutoSize = false;
            this.btnQuitarProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnQuitarProducto.Depth = 0;
            this.btnQuitarProducto.HighEmphasis = false;
            this.btnQuitarProducto.Icon = null;
            this.btnQuitarProducto.Location = new System.Drawing.Point(220, 105);
            this.btnQuitarProducto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnQuitarProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnQuitarProducto.Name = "btnQuitarProducto";
            this.btnQuitarProducto.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnQuitarProducto.Size = new System.Drawing.Size(195, 32);
            this.btnQuitarProducto.TabIndex = 7;
            this.btnQuitarProducto.Text = "➖ Quitar";
            this.btnQuitarProducto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnQuitarProducto.UseAccentColor = false;
            this.btnQuitarProducto.UseVisualStyleBackColor = true;
            this.btnQuitarProducto.Click += new System.EventHandler(this.btnQuitarProducto_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.AutoSize = false;
            this.btnAgregarProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregarProducto.Depth = 0;
            this.btnAgregarProducto.HighEmphasis = true;
            this.btnAgregarProducto.Icon = null;
            this.btnAgregarProducto.Location = new System.Drawing.Point(15, 105);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregarProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregarProducto.Size = new System.Drawing.Size(195, 32);
            this.btnAgregarProducto.TabIndex = 6;
            this.btnAgregarProducto.Text = "➕ Agregar";
            this.btnAgregarProducto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregarProducto.UseAccentColor = true;
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Font = new System.Drawing.Font("Roboto", 10F);
            this.nudCantidad.Location = new System.Drawing.Point(85, 68);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(100, 23);
            this.nudCantidad.TabIndex = 5;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Depth = 0;
            this.lblCantidad.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCantidad.Location = new System.Drawing.Point(15, 70);
            this.lblCantidad.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(57, 14);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Depth = 0;
            this.lblStock.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblStock.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.lblStock.Location = new System.Drawing.Point(250, 42);
            this.lblStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(52, 14);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "Stock: 0";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Depth = 0;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblPrecioUnitario.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(85, 42);
            this.lblPrecioUnitario.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(92, 14);
            this.lblPrecioUnitario.TabIndex = 2;
            this.lblPrecioUnitario.Text = "Precio: Bs. 0.00";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Roboto", 10F);
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(85, 10);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(330, 24);
            this.cboProducto.TabIndex = 1;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Depth = 0;
            this.lblProducto.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblProducto.Location = new System.Drawing.Point(15, 12);
            this.lblProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(58, 14);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "Producto:";
            // 
            // cardDatosVenta
            // 
            this.cardDatosVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardDatosVenta.Controls.Add(this.lblEmpleado);
            this.cardDatosVenta.Controls.Add(this.cboCliente);
            this.cardDatosVenta.Controls.Add(this.lblCliente);
            this.cardDatosVenta.Controls.Add(this.dtpFecha);
            this.cardDatosVenta.Controls.Add(this.lblFecha);
            this.cardDatosVenta.Depth = 0;
            this.cardDatosVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.cardDatosVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardDatosVenta.Location = new System.Drawing.Point(10, 5);
            this.cardDatosVenta.Margin = new System.Windows.Forms.Padding(10);
            this.cardDatosVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardDatosVenta.Name = "cardDatosVenta";
            this.cardDatosVenta.Padding = new System.Windows.Forms.Padding(10);
            this.cardDatosVenta.Size = new System.Drawing.Size(435, 110);
            this.cardDatosVenta.TabIndex = 0;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Depth = 0;
            this.lblEmpleado.Font = new System.Drawing.Font("Roboto Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblEmpleado.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            this.lblEmpleado.Location = new System.Drawing.Point(15, 80);
            this.lblEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(68, 13);
            this.lblEmpleado.TabIndex = 4;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.Font = new System.Drawing.Font("Roboto", 10F);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(85, 45);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(330, 24);
            this.cboCliente.TabIndex = 3;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Depth = 0;
            this.lblCliente.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCliente.Location = new System.Drawing.Point(15, 47);
            this.lblCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(45, 14);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Roboto", 10F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(85, 10);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(120, 23);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Depth = 0;
            this.lblFecha.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFecha.Location = new System.Drawing.Point(15, 12);
            this.lblFecha.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 14);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.Controls.Add(this.dgvVentas);
            this.pnlDerecho.Controls.Add(this.pnlBotonesLista);
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.Location = new System.Drawing.Point(450, 50);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.pnlDerecho.Size = new System.Drawing.Size(610, 526);
            this.pnlDerecho.TabIndex = 2;
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(5, 5);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(595, 476);
            this.dgvVentas.TabIndex = 0;
            // 
            // pnlBotonesLista
            // 
            this.pnlBotonesLista.Controls.Add(this.btnEliminar);
            this.pnlBotonesLista.Controls.Add(this.btnVerDetalle);
            this.pnlBotonesLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotonesLista.Location = new System.Drawing.Point(5, 481);
            this.pnlBotonesLista.Name = "pnlBotonesLista";
            this.pnlBotonesLista.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBotonesLista.Size = new System.Drawing.Size(595, 40);
            this.pnlBotonesLista.TabIndex = 1;
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEliminar.Depth = 0;
            this.btnEliminar.HighEmphasis = true;
            this.btnEliminar.Icon = null;
            this.btnEliminar.Location = new System.Drawing.Point(153, 3);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEliminar.Size = new System.Drawing.Size(135, 32);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "🗑️ Eliminar";
            this.btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEliminar.UseAccentColor = false;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.AutoSize = false;
            this.btnVerDetalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVerDetalle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnVerDetalle.Depth = 0;
            this.btnVerDetalle.HighEmphasis = true;
            this.btnVerDetalle.Icon = null;
            this.btnVerDetalle.Location = new System.Drawing.Point(10, 3);
            this.btnVerDetalle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnVerDetalle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnVerDetalle.Size = new System.Drawing.Size(135, 32);
            this.btnVerDetalle.TabIndex = 0;
            this.btnVerDetalle.Text = "👁️ Ver Detalle";
            this.btnVerDetalle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnVerDetalle.UseAccentColor = false;
            this.btnVerDetalle.UseVisualStyleBackColor = true;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1060, 576);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.pnlIzquierdo);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVenta";
            this.Text = "Gestión de Ventas";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            this.pnlIzquierdo.ResumeLayout(false);
            this.pnlBotonesVenta.ResumeLayout(false);
            this.cardDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlTotalVenta.ResumeLayout(false);
            this.pnlTotalVenta.PerformLayout();
            this.cardProductos.ResumeLayout(false);
            this.cardProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.cardDatosVenta.ResumeLayout(false);
            this.cardDatosVenta.PerformLayout();
            this.pnlDerecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.pnlBotonesLista.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlSuperior;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private System.Windows.Forms.Panel pnlIzquierdo;
        private MaterialSkin.Controls.MaterialCard cardDatosVenta;
        private MaterialSkin.Controls.MaterialLabel lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private MaterialSkin.Controls.MaterialLabel lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private MaterialSkin.Controls.MaterialLabel lblEmpleado;
        private MaterialSkin.Controls.MaterialCard cardProductos;
        private MaterialSkin.Controls.MaterialLabel lblProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private MaterialSkin.Controls.MaterialLabel lblPrecioUnitario;
        private MaterialSkin.Controls.MaterialLabel lblStock;
        private MaterialSkin.Controls.MaterialLabel lblCantidad;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private MaterialSkin.Controls.MaterialButton btnAgregarProducto;
        private MaterialSkin.Controls.MaterialButton btnQuitarProducto;
        private MaterialSkin.Controls.MaterialCard cardDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Panel pnlTotalVenta;
        private MaterialSkin.Controls.MaterialLabel lblTotalVenta;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel pnlBotonesVenta;
        private MaterialSkin.Controls.MaterialButton btnNueva;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.Panel pnlBotonesLista;
        private MaterialSkin.Controls.MaterialButton btnVerDetalle;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
    }
}