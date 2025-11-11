namespace CpTiendaRopa
{
    partial class FrmAutenticacion
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
            lblTitulo = new MaterialSkin.Controls.MaterialLabel();
            lblSubtitulo = new Label();
            txtUsuario = new MaterialSkin.Controls.MaterialTextBox();
            txtContraseña = new MaterialSkin.Controls.MaterialTextBox();
            btnIngresar = new MaterialSkin.Controls.MaterialButton();
            btnCancelar = new MaterialSkin.Controls.MaterialButton();
            pnlLogin = new Panel();
            pnlIzquierdo = new Panel();
            picLogo = new PictureBox();
            lblBienvenida = new Label();
            lblDescripcion = new Label();
            pnlLogin.SuspendLayout();
            pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Depth = 0;
            lblTitulo.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblTitulo.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblTitulo.Location = new Point(40, 30);
            lblTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(199, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar Sesión";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitulo.Location = new Point(40, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(221, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Ingrese sus credenciales para continuar";
            // 
            // txtUsuario
            // 
            txtUsuario.AnimateReadOnly = false;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Depth = 0;
            txtUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsuario.Hint = "👤  Usuario";
            txtUsuario.LeadingIcon = null;
            txtUsuario.Location = new Point(40, 120);
            txtUsuario.MaxLength = 20;
            txtUsuario.MouseState = MaterialSkin.MouseState.OUT;
            txtUsuario.Multiline = false;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(380, 50);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "";
            txtUsuario.TrailingIcon = null;
            // 
            // txtContraseña
            // 
            txtContraseña.AnimateReadOnly = false;
            txtContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.Depth = 0;
            txtContraseña.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtContraseña.Hint = "🔒  Contraseña";
            txtContraseña.LeadingIcon = null;
            txtContraseña.Location = new Point(40, 190);
            txtContraseña.MaxLength = 50;
            txtContraseña.MouseState = MaterialSkin.MouseState.OUT;
            txtContraseña.Multiline = false;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Password = true;
            txtContraseña.Size = new Size(380, 50);
            txtContraseña.TabIndex = 1;
            txtContraseña.Text = "";
            txtContraseña.TrailingIcon = null;
            // 
            // btnIngresar
            // 
            btnIngresar.AutoSize = false;
            btnIngresar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIngresar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIngresar.Depth = 0;
            btnIngresar.HighEmphasis = true;
            btnIngresar.Icon = null;
            btnIngresar.Location = new Point(40, 270);
            btnIngresar.Margin = new Padding(4, 6, 4, 6);
            btnIngresar.MouseState = MaterialSkin.MouseState.HOVER;
            btnIngresar.Name = "btnIngresar";
            btnIngresar.NoAccentTextColor = Color.Empty;
            btnIngresar.Size = new Size(180, 45);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "🚀  INGRESAR";
            btnIngresar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnIngresar.UseAccentColor = false;
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSize = false;
            btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelar.Depth = 0;
            btnCancelar.HighEmphasis = false;
            btnCancelar.Icon = null;
            btnCancelar.Location = new Point(240, 270);
            btnCancelar.Margin = new Padding(4, 6, 4, 6);
            btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancelar.Name = "btnCancelar";
            btnCancelar.NoAccentTextColor = Color.Empty;
            btnCancelar.Size = new Size(180, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "❌  CANCELAR";
            btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnCancelar.UseAccentColor = false;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(lblTitulo);
            pnlLogin.Controls.Add(lblSubtitulo);
            pnlLogin.Controls.Add(txtUsuario);
            pnlLogin.Controls.Add(btnCancelar);
            pnlLogin.Controls.Add(txtContraseña);
            pnlLogin.Controls.Add(btnIngresar);
            pnlLogin.Dock = DockStyle.Right;
            pnlLogin.Location = new Point(480, 64);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Padding = new Padding(20);
            pnlLogin.Size = new Size(470, 386);
            pnlLogin.TabIndex = 0;
            // 
            // pnlIzquierdo
            // 
            pnlIzquierdo.BackColor = Color.FromArgb(59, 130, 246);
            pnlIzquierdo.Controls.Add(lblDescripcion);
            pnlIzquierdo.Controls.Add(lblBienvenida);
            pnlIzquierdo.Controls.Add(picLogo);
            pnlIzquierdo.Dock = DockStyle.Fill;
            pnlIzquierdo.Location = new Point(3, 64);
            pnlIzquierdo.Name = "pnlIzquierdo";
            pnlIzquierdo.Padding = new Padding(40, 60, 40, 40);
            pnlIzquierdo.Size = new Size(477, 386);
            pnlIzquierdo.TabIndex = 1;
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.None;
            picLogo.BackColor = Color.Transparent;
            picLogo.Location = new Point(138, 80);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(200, 120);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblBienvenida
            // 
            lblBienvenida.Anchor = AnchorStyles.None;
            lblBienvenida.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(40, 210);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(397, 50);
            lblBienvenida.TabIndex = 1;
            lblBienvenida.Text = "👕 Bienvenido";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDescripcion
            // 
            lblDescripcion.Anchor = AnchorStyles.None;
            lblDescripcion.Font = new Font("Segoe UI", 11F);
            lblDescripcion.ForeColor = Color.FromArgb(219, 234, 254);
            lblDescripcion.Location = new Point(40, 270);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(397, 60);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Sistema de Gestión Punto de Venta\r\nControl total de tu negocio";
            lblDescripcion.TextAlign = ContentAlignment.TopCenter;
            // 
            // FrmAutenticacion
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 450);
            Controls.Add(pnlIzquierdo);
            Controls.Add(pnlLogin);
            MaximizeBox = false;
            Name = "FrmAutenticacion";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - TiendaPOS";
            Load += FrmAutenticacion_Load;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblTitulo;
        private Label lblSubtitulo;
        private MaterialSkin.Controls.MaterialTextBox txtUsuario;
        private MaterialSkin.Controls.MaterialTextBox txtContraseña;
        private MaterialSkin.Controls.MaterialButton btnIngresar;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
        private Panel pnlLogin;
        private Panel pnlIzquierdo;
        private PictureBox picLogo;
        private Label lblBienvenida;
        private Label lblDescripcion;
    }
}