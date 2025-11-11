using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadTiendaRopa;

namespace CpTiendaRopa
{
    public partial class ProductoCard : UserControl
    {
        private Producto producto;
        private static readonly HttpClient httpClient = new HttpClient();
        public event EventHandler<Producto> VerDetalleClick;

        public ProductoCard(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
            CargarDatos();
        }

        private async void CargarDatos()
        {
            if (!string.IsNullOrEmpty(producto.ImagenUrl))
            {
                await CargarImagenDesdeUrl(producto.ImagenUrl);
            }
            else
            {
                MostrarImagenPorDefecto();
            }

            lblNombre.Text = producto.Nombre;
            lblPrecio.Text = $"Bs. {producto.Precio:N2}";
            lblStock.Text = $"Stock: {producto.Stock}";
            lblCategoria.Text = producto.Categoria;
            lblDetalles.Text = $"{producto.Talla} | {producto.Color}";
            
            // Color del stock
            if (producto.Stock < 10)
                lblStock.ForeColor = Color.FromArgb(239, 68, 68);
            else if (producto.Stock < 50)
                lblStock.ForeColor = Color.FromArgb(251, 191, 36);
            else
                lblStock.ForeColor = Color.FromArgb(34, 197, 94);
        }

        private async Task CargarImagenDesdeUrl(string url)
        {
            try
            {
                picProducto.Image = null;
                var bytes = await httpClient.GetByteArrayAsync(url);
                using (var ms = new System.IO.MemoryStream(bytes))
                {
                    picProducto.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                MostrarImagenPorDefecto();
            }
        }

        private void MostrarImagenPorDefecto()
        {
            Bitmap bmp = new Bitmap(240, 200);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(229, 231, 235));
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                
                string inicial = producto.Nombre.Length > 0 ? producto.Nombre.Substring(0, 1).ToUpper() : "?";
                using (Font font = new Font("Segoe UI", 80, FontStyle.Bold))
                {
                    SizeF size = g.MeasureString(inicial, font);
                    PointF point = new PointF((240 - size.Width) / 2, (200 - size.Height) / 2);
                    g.DrawString(inicial, font, new SolidBrush(Color.FromArgb(156, 163, 175)), point);
                }
            }
            picProducto.Image = bmp;
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            VerDetalleClick?.Invoke(this, producto);
        }

        private void InitializeComponent()
        {
            this.picProducto = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // picProducto
            // 
            this.picProducto.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.picProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.picProducto.Location = new System.Drawing.Point(0, 0);
            this.picProducto.Name = "picProducto";
            this.picProducto.Size = new System.Drawing.Size(260, 200);
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProducto.TabIndex = 0;
            this.picProducto.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.lblNombre.Location = new System.Drawing.Point(12, 210);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(236, 45);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre Producto";
            // 
            // lblCategoria
            // 
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblCategoria.Location = new System.Drawing.Point(12, 255);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(236, 16);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría";
            // 
            // lblDetalles
            // 
            this.lblDetalles.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDetalles.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDetalles.Location = new System.Drawing.Point(12, 271);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(236, 16);
            this.lblDetalles.TabIndex = 3;
            this.lblDetalles.Text = "Talla | Color";
            // 
            // lblPrecio
            // 
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lblPrecio.Location = new System.Drawing.Point(12, 295);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(150, 30);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Bs. 0.00";
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(168, 302);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(80, 20);
            this.lblStock.TabIndex = 5;
            this.lblStock.Text = "Stock: 0";
            this.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerDetalle.FlatAppearance.BorderSize = 0;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerDetalle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnVerDetalle.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalle.Location = new System.Drawing.Point(12, 335);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(236, 35);
            this.btnVerDetalle.TabIndex = 6;
            this.btnVerDetalle.Text = "👁️ Ver Detalles";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // ProductoCard
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.picProducto);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ProductoCard";
            this.Size = new System.Drawing.Size(260, 380);
            this.Margin = new System.Windows.Forms.Padding(10);
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.Button btnVerDetalle;
    }
}