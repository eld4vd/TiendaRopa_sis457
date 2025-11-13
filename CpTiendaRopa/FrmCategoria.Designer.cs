namespace CpTiendaRopa
{
    partial class FrmCategoria
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
            dgvCategorias = new DataGridView();
            pnlPaginacion = new Panel();
            btnSiguiente = new MaterialSkin.Controls.MaterialButton();
            btnAnterior = new MaterialSkin.Controls.MaterialButton();
            lblPaginacion = new Label();
            pnlBusqueda = new Panel();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            txtBuscar = new MaterialSkin.Controls.MaterialTextBox();
            lblSubtitulo = new Label();
            pnlFormulario = new Panel();
            cardDatos = new MaterialSkin.Controls.MaterialCard();
            pnlBotones = new Panel();
            btnGuardar = new MaterialSkin.Controls.MaterialButton();
            btnCancelar = new MaterialSkin.Controls.MaterialButton();
            btnNuevo = new MaterialSkin.Controls.MaterialButton();
            btnEditar = new MaterialSkin.Controls.MaterialButton();
            btnEliminar = new MaterialSkin.Controls.MaterialButton();
            txtDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            txtNombre = new MaterialSkin.Controls.MaterialTextBox();
            pnlSuperior = new Panel();
            lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            pnlContenedor.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            pnlPaginacion.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            pnlFormulario.SuspendLayout();
            cardDatos.SuspendLayout();
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
            lblTitulo.Size = new Size(252, 29);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "🏷️ Gestión de Categorías";
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.FromArgb(249, 250, 251);
            pnlFormulario.Controls.Add(cardDatos);
            pnlFormulario.Dock = DockStyle.Top;
            pnlFormulario.Location = new Point(0, 65);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Padding = new Padding(20, 15, 20, 15);
            pnlFormulario.Size = new Size(1043, 180);
            pnlFormulario.TabIndex = 1;
            // 
            // cardDatos
            // 
            cardDatos.BackColor = Color.White;
            cardDatos.Controls.Add(pnlBotones);
            cardDatos.Controls.Add(txtDescripcion);
            cardDatos.Controls.Add(txtNombre);
            cardDatos.Depth = 0;
            cardDatos.Dock = DockStyle.Fill;
            cardDatos.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardDatos.Location = new Point(20, 15);
            cardDatos.Margin = new Padding(14);
            cardDatos.MouseState = MaterialSkin.MouseState.HOVER;
            cardDatos.Name = "cardDatos";
            cardDatos.Padding = new Padding(25, 20, 25, 20);
            cardDatos.Size = new Size(1003, 150);
            cardDatos.TabIndex = 0;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnGuardar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnNuevo);
            pnlBotones.Controls.Add(btnEditar);
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Dock = DockStyle.Right;
            pnlBotones.Location = new Point(638, 20);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Padding = new Padding(20, 0, 0, 0);
            pnlBotones.Size = new Size(340, 110);
            pnlBotones.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.AutoSize = false;
            btnGuardar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGuardar.Depth = 0;
            btnGuardar.HighEmphasis = true;
            btnGuardar.Icon = null;
            btnGuardar.Location = new Point(20, 60);
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
            btnCancelar.Location = new Point(180, 60);
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
            // btnNuevo
            // 
            btnNuevo.AutoSize = false;
            btnNuevo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNuevo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNuevo.Depth = 0;
            btnNuevo.HighEmphasis = true;
            btnNuevo.Icon = null;
            btnNuevo.Location = new Point(20, 10);
            btnNuevo.Margin = new Padding(4, 6, 4, 6);
            btnNuevo.MouseState = MaterialSkin.MouseState.HOVER;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.NoAccentTextColor = Color.Empty;
            btnNuevo.Size = new Size(100, 38);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "➕ Nuevo";
            btnNuevo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNuevo.UseAccentColor = false;
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.AutoSize = false;
            btnEditar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditar.Depth = 0;
            btnEditar.HighEmphasis = true;
            btnEditar.Icon = null;
            btnEditar.Location = new Point(130, 10);
            btnEditar.Margin = new Padding(4, 6, 4, 6);
            btnEditar.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditar.Name = "btnEditar";
            btnEditar.NoAccentTextColor = Color.Empty;
            btnEditar.Size = new Size(95, 38);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "✏️ Editar";
            btnEditar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditar.UseAccentColor = false;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Visible = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.AutoSize = false;
            btnEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEliminar.Depth = 0;
            btnEliminar.HighEmphasis = true;
            btnEliminar.Icon = null;
            btnEliminar.Location = new Point(235, 10);
            btnEliminar.Margin = new Padding(4, 6, 4, 6);
            btnEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.NoAccentTextColor = Color.Empty;
            btnEliminar.Size = new Size(95, 38);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEliminar.UseAccentColor = false;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtNombre
            // 
            txtNombre.AnimateReadOnly = false;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Depth = 0;
            txtNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNombre.Hint = "🏷️ Nombre de la categoría";
            txtNombre.LeadingIcon = null;
            txtNombre.Location = new Point(25, 15);
            txtNombre.MaxLength = 50;
            txtNombre.MouseState = MaterialSkin.MouseState.OUT;
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(580, 50);
            txtNombre.TabIndex = 0;
            txtNombre.Text = "";
            txtNombre.TrailingIcon = null;
            // 
            // txtDescripcion
            // 
            txtDescripcion.AnimateReadOnly = false;
            txtDescripcion.BorderStyle = BorderStyle.None;
            txtDescripcion.Depth = 0;
            txtDescripcion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDescripcion.Hint = "📝 Descripción (opcional)";
            txtDescripcion.LeadingIcon = null;
            txtDescripcion.Location = new Point(25, 70);
            txtDescripcion.MaxLength = 200;
            txtDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            txtDescripcion.Multiline = false;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(580, 50);
            txtDescripcion.TabIndex = 1;
            txtDescripcion.Text = "";
            txtDescripcion.TrailingIcon = null;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.BackColor = Color.White;
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Controls.Add(lblSubtitulo);
            pnlBusqueda.Dock = DockStyle.Top;
            pnlBusqueda.Location = new Point(0, 245);
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
            txtBuscar.Hint = "Buscar por nombre o descripción...";
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
            lblSubtitulo.Size = new Size(175, 21);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "📋 Lista de Categorías";
            // 
            // pnlGrid
            // 
            pnlGrid.BackColor = Color.FromArgb(249, 250, 251);
            pnlGrid.Controls.Add(dgvCategorias);
            pnlGrid.Controls.Add(pnlPaginacion);
            pnlGrid.Dock = DockStyle.Top;
            pnlGrid.Location = new Point(0, 315);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(20, 10, 20, 10);
            pnlGrid.Size = new Size(1043, 520);
            pnlGrid.TabIndex = 3;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.BorderStyle = BorderStyle.None;
            dgvCategorias.ColumnHeadersHeight = 45;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.EnableHeadersVisualStyles = false;
            dgvCategorias.Location = new Point(20, 10);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.RowTemplate.Height = 45;
            dgvCategorias.ScrollBars = ScrollBars.None;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(1003, 440);
            dgvCategorias.TabIndex = 0;
            // 
            // pnlPaginacion
            // 
            pnlPaginacion.BackColor = Color.White;
            pnlPaginacion.Controls.Add(btnSiguiente);
            pnlPaginacion.Controls.Add(btnAnterior);
            pnlPaginacion.Controls.Add(lblPaginacion);
            pnlPaginacion.Dock = DockStyle.Bottom;
            pnlPaginacion.Location = new Point(20, 450);
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
            lblPaginacion.Text = "Página 1 de 1 | Total: 0 categorías";
            lblPaginacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1060, 576);
            Controls.Add(pnlContenedor);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCategoria";
            Text = "Gestión de Categorías";
            Load += FrmCategoria_Load;
            pnlContenedor.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            pnlPaginacion.ResumeLayout(false);
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            pnlFormulario.ResumeLayout(false);
            cardDatos.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlContenedor;
        private Panel pnlSuperior;
        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private Panel pnlFormulario;
        private MaterialSkin.Controls.MaterialCard cardDatos;
        private MaterialSkin.Controls.MaterialTextBox txtNombre;
        private MaterialSkin.Controls.MaterialTextBox txtDescripcion;
        private Panel pnlBotones;
        private MaterialSkin.Controls.MaterialButton btnNuevo;
        private MaterialSkin.Controls.MaterialButton btnEditar;
        private MaterialSkin.Controls.MaterialButton btnEliminar;
        private MaterialSkin.Controls.MaterialButton btnGuardar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private Panel pnlBusqueda;
        private Label lblSubtitulo;
        private MaterialSkin.Controls.MaterialTextBox txtBuscar;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private Panel pnlGrid;
        private DataGridView dgvCategorias;
        private Panel pnlPaginacion;
        private MaterialSkin.Controls.MaterialButton btnAnterior;
        private MaterialSkin.Controls.MaterialButton btnSiguiente;
        private Label lblPaginacion;
    }
}