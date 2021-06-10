using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class Kort : Page
    {
        public Kort()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlCommand SqlComm;
        private SqlDataReader dr;
        private int medieplanNr;
        private int version;
        protected SqlConnection SqlConn;
        private string sqlTxt;

        #region  Web Form Designer Generated Code 

        // This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SqlComm = new SqlCommand();
            SqlConn = new SqlConnection();
            // 
            // SqlConn
            // 
            SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" + "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
        }

        private void Page_Init(object sender, EventArgs e)
        {
            // CODEGEN: This method call is required by the Web Form Designer
            // Do not modify it using the code editor.
            InitializeComponent();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                medieplanNr = Conversions.ToInteger(Request.QueryString["MedieplanNr"]);
                version = Conversions.ToInteger(Request.QueryString["Version"]);

                // sqlTxt = "SELECT dbo.tblMedieplanLinjer.UgeavisID, dbo.tblBladDækning.PostNr, dbo.tblPostNr.PostBy, "
                // sqlTxt = sqlTxt + "dbo.tblBladDækning.DækningsGrad FROM dbo.tblBladDækning INNER JOIN dbo.tblPostNr ON dbo.tblBladDækning.PostNr "
                // sqlTxt = sqlTxt + "= dbo.tblPostNr.PostNr INNER JOIN dbo.tblMedieplanLinjer ON dbo.tblBladDækning.UgeavisID = "
                // sqlTxt = sqlTxt + "dbo.tblMedieplanLinjer.UgeavisID "
                // sqlTxt = sqlTxt + "WHERE (dbo.tblMedieplanLinjer.MedieplanNr = " + medieplanNr.ToString + ") AND "
                // sqlTxt = sqlTxt + "(dbo.tblMedieplanLinjer.Version = " + version.ToString + ")"
                // SqlComm.CommandText = sqlTxt
                // SqlConn2.Open()
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    Response.Write(dr["UgeavisID"].ToString());
                    Response.Write(dr["PostNr"].ToString());
                    Response.Write(dr["PostBy"].ToString());
                    Response.Write(dr["Dækningsgrad"].ToString());
                }

                dr.Close();
                Response.End();
            }
        }
    }
}