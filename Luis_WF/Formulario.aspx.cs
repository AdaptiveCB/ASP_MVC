using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Luis_WF
{
    public partial class Formulario : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection("server=DESKTOP-MMHB282;Database=BCP_WF; Trusted_Connection = true;");
        //SqlConnection sqlCon = new SqlConnection("Server=DESKTOP-MMHB282;Database=BCP_WF;User Id=bcp;Password=123;");
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEliminar.Enabled = false;
                FillGridView();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("CrearOActualizarColaborador", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", (hfIdColaborador.Value == "" ? 0 : Convert.ToInt32(hfIdColaborador.Value)));
            sqlCmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Sueldo", Math.Round(float.Parse(txtSueldo.Text.Trim()), 2));
            sqlCmd.Parameters.AddWithValue("@Sede", ddlSede.SelectedItem.Text);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string idColaborador = hfIdColaborador.Value;
            Limpiar();
            if (idColaborador == "")
            {
                lblExito.Text = "Guardado exitosamente";
            }
            else
            {
                lblExito.Text = "Actualizado exitosamente";
            }
            FillGridView();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("EliminarPorId", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(hfIdColaborador.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Limpiar();
            FillGridView();
            lblExito.Text = "Eliminado exitosamente";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            int idColaborador = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter sqlDa = new SqlDataAdapter("ColaboradorPorId", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@Id", idColaborador);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hfIdColaborador.Value = idColaborador.ToString();
            txtNombre.Text = dtbl.Rows[0]["nombres"].ToString();
            txtApellido.Text = dtbl.Rows[0]["apellidos"].ToString();
            txtSueldo.Text = dtbl.Rows[0]["sueldo"].ToString();
            ddlSede.Text = dtbl.Rows[0]["sede"].ToString();
            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
        }

        void Limpiar()
        {
            hfIdColaborador.Value = "";
            txtNombre.Text = txtApellido.Text = txtSueldo.Text = "";// txtSede.Text = "";
            ddlSede.SelectedIndex = 0;
            lblExito.Text = lblerror.Text = "";
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
        }


        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter sqlDa = new SqlDataAdapter("VerColaboradores", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvColaborador.DataSource = dtbl;
            gvColaborador.DataBind();

        }

    }

}