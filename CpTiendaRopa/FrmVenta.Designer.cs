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
            pnlContenedor = new Panel();
            pnlCarrito = new Panel();
            cardCarrito = new MaterialSkin.Controls.MaterialCard();
            dgvCarrito = new DataGridView();
            pnlTotales = new Panel();
            btnProcesarVenta = new MaterialSkin.Controls.MaterialButton();
            lblTotal = new Label();
            lblTotalTexto = new Label();
            pnlProductos = new Panel();
            cardProductos = new MaterialSkin.Controls.MaterialCard();
            dgvProductos = new DataGridView();
            pnlBusquedaProducto = new Panel();
            txtBuscarProducto = new MaterialSkin.Controls.MaterialTextBox();
            lblProductos = new Label();
            pnlCliente = new Panel();
            cardCliente = new MaterialSkin.Controls.MaterialCard();
            cboCliente = new MaterialSkin.Controls.MaterialComboBox();
            lblCliente = new Label();
            pnlSuperior = new Panel();
            lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            pnlContenedor.SuspendLayout();
            pnlCarrito.SuspendLayout();
            cardCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            pnlTotales.SuspendLayout();
            pnlProductos.SuspendLayout();
            cardProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            pnlBusquedaProducto.SuspendLayout();
            pnlCliente.SuspendLayout();
            cardCliente.SuspendLayout();
            pnlSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContenedor
            // 
            pnlContenedor.AutoScroll = true;
            pnlContenedor.BackColor = Color.FromArgb(249, 250, 251);
            pnlContenedor.Controls.Add(pnlCarrito);
            pnlContenedor.Controls.Add(pnlProductos);
            pnlContenedor.Controls.Add(pnlCliente);
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
            lblTitulo.Size = new Size(230, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🛒 Nueva Venta - POS";
            // 
            // pnlCliente
            // 
            pnlCliente.BackColor = Color.FromArgb(249, 250, 251);
            pnlCliente.Controls.Add(cardCliente);
            pnlCliente.Dock = DockStyle.Top;
            pnlCliente.Location = new Point(0, 65);
            pnlCliente.Name = "pnlCliente";
            pnlCliente.Padding = new Padding(20, 15, 20, 15);
            pnlCliente.Size = new Size(1043, 100);
            pnlCliente.TabIndex = 1;
            // 
            // cardCliente
            // 
            cardCliente.BackColor = Color.White;
            cardCliente.Controls.Add(cboCliente);
            cardCliente.Controls.Add(lblCliente);
            cardCliente.Depth = 0;
            cardCliente.Dock = DockStyle.Fill;
            cardCliente.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardCliente.Location = new Point(20, 15);
            cardCliente.Margin = new Padding(14);
            cardCliente.MouseState = MaterialSkin.MouseState.HOVER;
            cardCliente.Name = "cardCliente";
            cardCliente.Padding = new Padding(20);
            cardCliente.Size = new Size(1003, 70);
            cardCliente.TabIndex = 0;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCliente.ForeColor = Color.FromArgb(31, 41, 55);
            lblCliente.Location = new Point(20, 20);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(155, 19);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "👤 Seleccionar Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.AutoResize = false;
            cboCliente.BackColor = Color.FromArgb(255, 255, 255);
            cboCliente.Depth = 0;
            cboCliente.DrawMode = DrawMode.OwnerDrawVariable;
            cboCliente.DropDownHeight = 174;
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.DropDownWidth = 121;
            cboCliente.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cboCliente.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cboCliente.FormattingEnabled = true;
            cboCliente.Hint = "Buscar y seleccionar cliente...";
            cboCliente.IntegralHeight = false;
            cboCliente.ItemHeight = 43;
            cboCliente.Location = new Point(200, 12);
            cboCliente.MaxDropDownItems = 4;
            cboCliente.MouseState = MaterialSkin.MouseState.OUT;
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(780, 49);
            cboCliente.StartIndex = 0;
            cboCliente.TabIndex = 1;
            // 
            // pnlProductos
            // 
            pnlProductos.BackColor = Color.FromArgb(249, 250, 251);
            pnlProductos.Controls.Add(cardProductos);
            pnlProductos.Dock = DockStyle.Top;
            pnlProductos.Location = new Point(0, 165);
            pnlProductos.Name = "pnlProductos";
            pnlProductos.Padding = new Padding(20, 0, 20, 15);
            pnlProductos.Size = new Size(1043, 320);
            pnlProductos.TabIndex = 2;
            // 
            // cardProductos
            // 
            cardProductos.BackColor = Color.White;
            cardProductos.Controls.Add(dgvProductos);
            cardProductos.Controls.Add(pnlBusquedaProducto);
            cardProductos.Depth = 0;
            cardProductos.Dock = DockStyle.Fill;
            cardProductos.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardProductos.Location = new Point(20, 0);
            cardProductos.Margin = new Padding(14);
            cardProductos.MouseState = MaterialSkin.MouseState.HOVER;
            cardProductos.Name = "cardProductos";
            cardProductos.Padding = new Padding(20);
            cardProductos.Size = new Size(1003, 305);
            cardProductos.TabIndex = 0;
            // 
            // pnlBusquedaProducto
            // 
            pnlBusquedaProducto.Controls.Add(txtBuscarProducto);
            pnlBusquedaProducto.Controls.Add(lblProductos);
            pnlBusquedaProducto.Dock = DockStyle.Top;
            pnlBusquedaProducto.Location = new Point(20, 20);
            pnlBusquedaProducto.Name = "pnlBusquedaProducto";
            pnlBusquedaProducto.Size = new Size(963, 65);
            pnlBusquedaProducto.TabIndex = 0;
            // 
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductos.ForeColor = Color.FromArgb(31, 41, 55);
            lblProductos.Location = new Point(0, 10);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(268, 19);
            lblProductos.TabIndex = 0;
            lblProductos.Text = "📦 Buscar Productos (Doble clic para agregar):";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.AnimateReadOnly = false;
            txtBuscarProducto.BorderStyle = BorderStyle.None;
            txtBuscarProducto.Depth = 0;
            txtBuscarProducto.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBuscarProducto.Hint = "🔍 Buscar por nombre, categoría, talla o color...";
            txtBuscarProducto.LeadingIcon = null;
            txtBuscarProducto.Location = new Point(280, 5);
            txtBuscarProducto.MaxLength = 50;
            txtBuscarProducto.MouseState = MaterialSkin.MouseState.OUT;
            txtBuscarProducto.Multiline = false;
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(680, 50);
            txtBuscarProducto.TabIndex = 1;
            txtBuscarProducto.Text = "";
            txtBuscarProducto.TrailingIcon = null;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersHeight = 40;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.Location = new Point(20, 85);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowTemplate.Height = 35;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(963, 200);
            dgvProductos.TabIndex = 1;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // pnlCarrito
            // 
            pnlCarrito.BackColor = Color.FromArgb(249, 250, 251);
            pnlCarrito.Controls.Add(cardCarrito);
            pnlCarrito.Dock = DockStyle.Top;
            pnlCarrito.Location = new Point(0, 485);
            pnlCarrito.Name = "pnlCarrito";
            pnlCarrito.Padding = new Padding(20, 0, 20, 20);
            pnlCarrito.Size = new Size(1043, 350);
            pnlCarrito.TabIndex = 3;
            // 
            // cardCarrito
            // 
            cardCarrito.BackColor = Color.White;
            cardCarrito.Controls.Add(dgvCarrito);
            cardCarrito.Controls.Add(pnlTotales);
            cardCarrito.Depth = 0;
            cardCarrito.Dock = DockStyle.Fill;
            cardCarrito.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardCarrito.Location = new Point(20, 0);
            cardCarrito.Margin = new Padding(14);
            cardCarrito.MouseState = MaterialSkin.MouseState.HOVER;
            cardCarrito.Name = "cardCarrito";
            cardCarrito.Padding = new Padding(20);
            cardCarrito.Size = new Size(1003, 330);
            cardCarrito.TabIndex = 0;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.ColumnHeadersHeight = 40;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.Location = new Point(20, 20);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowTemplate.Height = 40;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(963, 210);
            dgvCarrito.TabIndex = 0;
            dgvCarrito.CellEndEdit += dgvCarrito_CellEndEdit;
            dgvCarrito.UserDeletingRow += dgvCarrito_UserDeletingRow;
            // 
            // pnlTotales
            // 
            pnlTotales.BackColor = Color.FromArgb(249, 250, 251);
            pnlTotales.Controls.Add(btnProcesarVenta);
            pnlTotales.Controls.Add(lblTotal);
            pnlTotales.Controls.Add(lblTotalTexto);
            pnlTotales.Dock = DockStyle.Bottom;
            pnlTotales.Location = new Point(20, 230);
            pnlTotales.Name = "pnlTotales";
            pnlTotales.Padding = new Padding(20, 15, 20, 15);
            pnlTotales.Size = new Size(963, 80);
            pnlTotales.TabIndex = 1;
            // 
            // lblTotalTexto
            // 
            lblTotalTexto.AutoSize = true;
            lblTotalTexto.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalTexto.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotalTexto.Location = new Point(20, 25);
            lblTotalTexto.Name = "lblTotalTexto";
            lblTotalTexto.Size = new Size(172, 30);
            lblTotalTexto.TabIndex = 0;
            lblTotalTexto.Text = "💰 TOTAL (Bs):";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Consolas", 24F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(34, 197, 94);
            lblTotal.Location = new Point(200, 20);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(107, 37);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "0.00";
            // 
            // btnProcesarVenta
            // 
            btnProcesarVenta.AutoSize = false;
            btnProcesarVenta.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnProcesarVenta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnProcesarVenta.Depth = 0;
            btnProcesarVenta.Dock = DockStyle.Right;
            btnProcesarVenta.HighEmphasis = true;
            btnProcesarVenta.Icon = null;
            btnProcesarVenta.Location = new Point(663, 15);
            btnProcesarVenta.Margin = new Padding(4, 6, 4, 6);
            btnProcesarVenta.MouseState = MaterialSkin.MouseState.HOVER;
            btnProcesarVenta.Name = "btnProcesarVenta";
            btnProcesarVenta.NoAccentTextColor = Color.Empty;
            btnProcesarVenta.Size = new Size(280, 50);
            btnProcesarVenta.TabIndex = 2;
            btnProcesarVenta.Text = "🛒 PROCESAR VENTA";
            btnProcesarVenta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnProcesarVenta.UseAccentColor = true;
            btnProcesarVenta.UseVisualStyleBackColor = true;
            btnProcesarVenta.Click += btnProcesarVenta_Click;
            // 
            // FrmVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1060, 576);
            Controls.Add(pnlContenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmVenta";
            Text = "Nueva Venta";
            Load += FrmVenta_Load;
            pnlContenedor.ResumeLayout(false);
            pnlCarrito.ResumeLayout(false);
            cardCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            pnlTotales.ResumeLayout(false);
            pnlTotales.PerformLayout();
            pnlProductos.ResumeLayout(false);
            cardProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            pnlBusquedaProducto.ResumeLayout(false);
            pnlBusquedaProducto.PerformLayout();
            pnlCliente.ResumeLayout(false);
            cardCliente.ResumeLayout(false);
            cardCliente.PerformLayout();
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlContenedor;
        private Panel pnlSuperior;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private Panel pnlCliente;
        private MaterialSkin.Controls.MaterialCard cardCliente;
        private MaterialSkin.Controls.MaterialComboBox cboCliente;
        private Label lblCliente;
        private Panel pnlProductos;
        private MaterialSkin.Controls.MaterialCard cardProductos;
        private Panel pnlBusquedaProducto;
        private MaterialSkin.Controls.MaterialTextBox txtBuscarProducto;
        private Label lblProductos;
        private DataGridView dgvProductos;
        private Panel pnlCarrito;
        private MaterialSkin.Controls.MaterialCard cardCarrito;
        private DataGridView dgvCarrito;
        private Panel pnlTotales;
        private MaterialSkin.Controls.MaterialButton btnProcesarVenta;
        private Label lblTotal;
        private Label lblTotalTexto;
    }
}