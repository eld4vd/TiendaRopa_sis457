using CadTiendaRopa;
using ClnTiendaRopa;
using System;
using System.Windows.Forms;

namespace CpTiendaRopa
{
    public partial class FrmCategoria : Form
    {
        private bool esNuevo = false;

        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            listar();
            configurarControles(false);
        }

        private void listar()
        {
            var categorias = CategoriaCln.listar();
            dgvCategorias.DataSource = categorias;

            if (dgvCategorias.Columns.Count > 0)
            {
                dgvCategorias.Columns["Id"].HeaderText = "ID";
                dgvCategorias.Columns["Nombre"].HeaderText = "Nombre";
                dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
                dgvCategorias.Columns["Eliminado"].Visible = false;
            }

        }

        private void configurarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
            dgvCategorias.Enabled = !habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
        }

        private void limpiarControles()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            limpiarControles();
            configurarControles(true);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            esNuevo = false;
            var categoria = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;
            txtNombre.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;
            configurarControles(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            try
            {
                var categoria = new Categoria
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                if (esNuevo)
                {
                    CategoriaCln.crear(categoria);
                    MessageBox.Show("Categoría registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    categoria.Id = ((Categoria)dgvCategorias.SelectedRows[0].DataBoundItem).Id;
                    CategoriaCln.actualizar(categoria);
                    MessageBox.Show("Categoría actualizada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                limpiarControles();
                configurarControles(false);
                listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            configurarControles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var categoria = (Categoria)dgvCategorias.SelectedRows[0].DataBoundItem;
                    CategoriaCln.eliminar(categoria.Id);
                    MessageBox.Show("Categoría eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}