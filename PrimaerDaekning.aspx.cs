using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class PrimærDækning : Page
    {
        public PrimærDækning()
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
            Dst = new dst();
            ((System.ComponentModel.ISupportInitialize)Dst).BeginInit();
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
            da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", "tblWEBPrimærDækning", new System.Data.Common.DataColumnMapping[] { new System.Data.Common.DataColumnMapping("BladId", "BladId"), new System.Data.Common.DataColumnMapping("postNrOgBy", "postNrOgBy"), new System.Data.Common.DataColumnMapping("Primær", "Primær"), new System.Data.Common.DataColumnMapping("PKey", "PKey") }) });
            // 
            // SqlSelectCommand1
            // 
            SqlSelectCommand1.CommandText = "SELECT BladId, postNrOgBy, Primær, PKey FROM tblWEBPrimærDækning WHERE (BladId = " + "@BladID)";
            SqlSelectCommand1.Connection = SqlConn;
            SqlSelectCommand1.Parameters.Add(new SqlParameter("@BladID", SqlDbType.Int, 4, "BladId"));
            // 
            // Dst
            // 
            Dst.DataSetName = "dst";
            Dst.Locale = new System.Globalization.CultureInfo("da-DK");
            Dst.Namespace = "http://www.tempuri.org/dst.xsd";
            ((System.ComponentModel.ISupportInitialize)Dst).EndInit();
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
        protected SqlCommand SqlSelectCommand1;
        protected dst Dst;
        protected int QueryChk;
        private string[] query = new string[2];

        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int counter;
                var checkSum = default(int);
                query = Strings.Split(Request.QueryString["Query"], "*");
                BladID = Conversions.ToInteger(query[0]);
                QueryChk = Conversions.ToInteger(query[1]);
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
                // if not querychk = 999 then
                // If checkSum <> QueryChk Then
                // Server.Transfer("CheckSumError.htm")
                // End If
                // end if
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
            da.SelectCommand.Parameters["@BladID"].Value = BladID;
            da.Fill(Dst);
            DataBind();
        }

        private void grdPrim_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                SqlComm.CommandText = "DELETE FROM tblWEBPrimærDækning WHERE (BladID=" + BladID + ") AND (postNrOgBy='" + e.Item.Cells[0].Text + "')";
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
    }
}