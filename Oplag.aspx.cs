using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class OplagClass : Page
    {
        public OplagClass()
        {
            base.Init += Page_Init;
            base.Load += Page_Load;
        }

        #region  Web Form Designer Generated Code 

        // This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SqlConn = new SqlConnection();
            SqlComm = new SqlCommand();
            da = new SqlDataAdapter();
            SqlSelectCommand1 = new SqlCommand();
            dst = new dst();
            ((System.ComponentModel.ISupportInitialize)dst).BeginInit();
            // 
            // SqlConn
            // 
            SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" + "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
            // 
            // SqlComm
            // 
            SqlComm.Connection = SqlConn;
            // 
            // da
            // 
            da.SelectCommand = SqlSelectCommand1;
            da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", "tblOplagWEB", new System.Data.Common.DataColumnMapping[] { new System.Data.Common.DataColumnMapping("PostNr", "PostNr"), new System.Data.Common.DataColumnMapping("Oplag", "Oplag"), new System.Data.Common.DataColumnMapping("BladID", "BladID") }) });
            // 
            // SqlSelectCommand1
            // 
            SqlSelectCommand1.CommandText = "SELECT PostNr, Oplag, BladID FROM tblOplagWEB WHERE (BladID = @BladID)";
            SqlSelectCommand1.Connection = SqlConn;
            SqlSelectCommand1.Parameters.Add(new SqlParameter("@BladID", SqlDbType.Int, 4, "BladID"));
            // 
            // dst
            // 
            dst.DataSetName = "dst";
            dst.Locale = new System.Globalization.CultureInfo("da-DK");
            dst.Namespace = "http://www.tempuri.org/dst.xsd";
            ((System.ComponentModel.ISupportInitialize)dst).EndInit();
        }

        private void Page_Init(object sender, EventArgs e)
        {
            // CODEGEN: This method call is required by the Web Form Designer
            // Do not modify it using the code editor.
            InitializeComponent();
        }

        #endregion
        protected string BladNavn;
        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int BladID;
        private SqlDataReader dr;
        protected SqlDataAdapter da;
        protected dst dst;
        protected SqlCommand SqlSelectCommand1;
        protected int queryChk;

        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int counter;
                var checkSum = default(int);
                var query = new string[2];
                query = Strings.Split(Request.QueryString["Query"], "*");
                BladID = Conversions.ToInteger(query[0]);
                queryChk = Conversions.ToInteger(query[1]);
                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                SqlConn.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    checkSum = (checkSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (checkSum != queryChk)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                ViewState["BladNavn"] = BladNavn;
                ViewState["BladID"] = BladID;
                ShowOrdrer();
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
            }
        }

        private void ShowOrdrer()
        {
            if (grdPrim.EditItemIndex > -1)
            {
                btnAddPostNr.Enabled = false;
                btnGodkend.Enabled = false;
                txtPostNr.Enabled = false;
            }
            else
            {
                btnAddPostNr.Enabled = true;
                btnGodkend.Enabled = true;
                txtPostNr.Enabled = true;
            }

            da.SelectCommand.Parameters["@BladID"].Value = BladID;
            da.Fill(dst);
            DataBind();
        }

        private void grdPrim_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                SqlComm.CommandText = "DELETE FROM tblOplagWEB WHERE (BladID=" + BladID + ") AND (PostNr=" + Conversions.ToInteger(e.Item.Cells[0].Text) + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                ShowOrdrer();
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                Server.Transfer("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }
        }

        private void btnAddPostNr_Click(object sender, EventArgs e)
        {
            try
            {
                SqlComm.CommandText = "INSERT INTO tblOplagWEB (BladID, PostNr, Oplag) VALUES ('" + BladID + "', '" + Conversions.ToInteger(txtPostNr.Text) + "', '0')";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                ShowOrdrer();
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                Server.Transfer("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }
        }

        private void grdPrim_EditCommand(object source, DataGridCommandEventArgs e)
        {
            grdPrim.EditItemIndex = e.Item.ItemIndex;
            ShowOrdrer();
        }

        private void grdPrim_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            grdPrim.EditItemIndex = -1;
            ShowOrdrer();
        }

        private void grdPrim_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            var indOplag = default(int);
            try
            {
                indOplag = Conversions.ToInteger(((TextBox)e.Item.Cells[1].Controls[1]).Text);
            }
            catch
            {
                Response.Redirect("FejlKonverter.htm");
            }

            try
            {
                SqlComm.CommandText = "UPDATE tblOplagWEB SET Oplag = '" + indOplag + "' WHERE (BladID=" + BladID + ") AND (PostNr=" + Conversions.ToInteger(e.Item.Cells[0].Text) + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                ShowOrdrer();
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                Server.Transfer("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }

            grdPrim.EditItemIndex = -1;
            ShowOrdrer();
        }

        private void txtPostNr_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPostNr.Text))
            {
                btnAddPostNr.Enabled = true;
            }
            else
            {
                btnAddPostNr.Enabled = false;
            }
        }

        private void btnGodkend_Click(object sender, EventArgs e)
        {
            try
            {
                SqlComm.CommandText = "DELETE FROM tblOplagGodkendWEB WHERE (BladID=" + BladID + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
            }
            catch
            {
                SqlConn.Close();
                Response.Redirect("FejlOpdater.htm?1");
            }
            finally
            {
                SqlConn.Close();
            }

            try
            {
                SqlComm.CommandText = "INSERT INTO tblOplagGodkendWEB (BladID, Godkendt) VALUES ('" + BladID + "', '1')";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                Response.Redirect("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }

            Response.Redirect("Afslut.htm");
        }
    }
}