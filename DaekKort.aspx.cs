using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace OrdreApp
{
    public partial class DaekKort : Page
    {
        public DaekKort()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection sqlConn;
        protected SqlCommand sqlComm;
        protected SqlConnection sqlConn2;
        protected string MedieplanNr;
        protected string Version;
        protected string sqlTxt;
        protected SqlDataReader dr;
        #region  Web Form Designer Generated Code 

        // This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            sqlConn = new SqlConnection();
            sqlComm = new SqlCommand();
            sqlConn2 = new SqlConnection();
            // sqlConn
            // 
            sqlConn.ConnectionString = "data source=AGETOR;initial catalog=DIMPdotNet;password=hydeliFyt12;persist s" + "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
            sqlConn2.ConnectionString = "data source=DDDIMP;initial catalog=DiMPdotNet;password=hydeliFyt12;persist security info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
            // 
            // sqlComm
            // 
            sqlComm.Connection = sqlConn;
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
                MedieplanNr = Request.QueryString["MedieplanNr"];
                Version = Request.QueryString["Version"];
                sqlTxt = "SELECT dbo.tblMedieplanLinjer.UgeavisID, dbo.tblBladDækning.PostNr, dbo.tblPostNr.PostBy, ";
                sqlTxt = sqlTxt + "dbo.tblBladDækning.DækningsGrad FROM dbo.tblBladDækning INNER JOIN dbo.tblPostNr ON dbo.tblBladDækning.PostNr ";
                sqlTxt = sqlTxt + "= dbo.tblPostNr.PostNr INNER JOIN dbo.tblMedieplanLinjer ON dbo.tblBladDækning.UgeavisID = ";
                sqlTxt = sqlTxt + "dbo.tblMedieplanLinjer.UgeavisID ";
                sqlTxt = sqlTxt + "WHERE (dbo.tblMedieplanLinjer.MedieplanNr = " + MedieplanNr + ") AND ";
                sqlTxt = sqlTxt + "(dbo.tblMedieplanLinjer.Version = " + Version + ")";
                sqlComm.CommandText = sqlTxt;
                sqlConn.Open();
                dr = sqlComm.ExecuteReader();
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