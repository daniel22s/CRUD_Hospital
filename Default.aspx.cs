using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CRUDWebForm
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosPacientes();
            }
        }

        protected void CargarDatosPacientes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SPS_Paciente", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            gvdPaciente.DataSource = reader;
                            gvdPaciente.DataBind();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al cargar los pacientes: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general: " + ex.Message);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlDatoPaciente.Visible = false;
            pnlAltaPaciente.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPaciente();
            CargarDatosPacientes();
            pnlAltaPaciente.Visible = false;
            pnlDatoPaciente.Visible = true;
        }

        protected void GuardarPaciente()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertarPaciente", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombrePaciente", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@ApPaterno", txtApPaterno.Text.Trim());
                        cmd.Parameters.AddWithValue("@ApMaterno", txtApMaterno.Text.Trim());
                        cmd.Parameters.AddWithValue("@Edad", txtEdad.Text.Trim());
                        cmd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al guardar el paciente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general: " + ex.Message);
            }
        }

        protected void lkbActualizar_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            gvdPaciente.SelectedIndex = row.RowIndex;

            lblIdPaciente.Text = gvdPaciente.DataKeys[row.RowIndex].Value.ToString();
            txtNombre.Text = row.Cells[1].Text;
            txtApPaterno.Text = row.Cells[2].Text;
            txtApMaterno.Text = row.Cells[3].Text;
            txtEdad.Text = row.Cells[4].Text;
            txtEspecialidad.Text = row.Cells[5].Text;

            pnlAltaPaciente.Visible = true;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPaciente();
            CargarDatosPacientes();
            pnlAltaPaciente.Visible = false;
            pnlDatoPaciente.Visible = true;
            btnActualizar.Visible = false;
            btnGuardar.Visible = true;
        }

        protected void ActualizarPaciente()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SPU_Paciente", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", lblIdPaciente.Text);
                        cmd.Parameters.AddWithValue("@NombrePaciente", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@ApPaterno", txtApPaterno.Text.Trim());
                        cmd.Parameters.AddWithValue("@ApMaterno", txtApMaterno.Text.Trim());
                        cmd.Parameters.AddWithValue("@Edad", txtEdad.Text.Trim());
                        cmd.Parameters.AddWithValue("@Especialidad", txtEspecialidad.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar el paciente: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general: " + ex.Message);
            }
        }

        protected void gvdPaciente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPaciente = Convert.ToInt32(gvdPaciente.DataKeys[e.RowIndex].Value);

            EliminarPaciente(idPaciente);
        }

        private void EliminarPaciente(int idPaciente)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPD_Paciente";
                cmd.Parameters.AddWithValue("@Id", idPaciente);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void gvdPaciente_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            CargarDatosPacientes();
        }
        }
}
