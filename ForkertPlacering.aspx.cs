using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class ForkertPlacering2 : Page
    {
        public ForkertPlacering2()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection sqlConn;
        protected SqlCommand sqlComm;
        protected int ordreID;
        protected int bladID;
        protected int uge;
        protected string bladNavn;
        protected string eMail;
        protected SqlDataReader dr;
        protected int queryChk;
        protected TextBox txtPersonNavn;
        protected RequiredFieldValidator validerTxtPersonNavnUdfýldt;
        protected string[] query = new string[4];
        #region  Web Form Designer Generated Code 

        // This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            sqlConn = new SqlConnection();
            sqlComm = new SqlCommand();
            // 
            // sqlConn
            // 
            sqlConn.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096";
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
                int counter;
                var CheckSum = default(int);
                query = Strings.Split(Request.QueryString["Query"], "*");
                bladID = Conversions.ToInteger(query[0]);
                uge = Conversions.ToInteger(query[1]);
                eMail = query[2];
                queryChk = Conversions.ToInteger(query[3]);
                ordreID = Conversions.ToInteger(query[4]);
                sqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " + bladID + ")";
                sqlConn.Open();
                dr = sqlComm.ExecuteReader();
                dr.Read();
                bladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(bladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + uge + Strings.Asc(Strings.Mid(bladNavn, counter, 1))) % 255;
                if (CheckSum != queryChk && queryChk != 999)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                sqlConn.Close();
                ViewState["BladNavn"] = bladNavn;
                ViewState["BladID"] = bladID;
                ViewState["Uge"] = uge;
                ViewState["Email"] = eMail;
                ViewState["queryChk"] = queryChk;
                ViewState["OrdreID"] = ordreID;
                DataBind();
            }
            else
            {
                bladNavn = Conversions.ToString(ViewState["BladNavn"]);
                ordreID = Conversions.ToInteger(ViewState["OrdreID"]);
                bladID = Conversions.ToInteger(ViewState["BladID"]);
                uge = Conversions.ToInteger(ViewState["Uge"]);
                eMail = Conversions.ToString(ViewState["Email"]);
                queryChk = Conversions.ToInteger(ViewState["queryChk"]);
            }
        }

        private void btnOpdater_Click(object sender, EventArgs e)
        {
            try
            {
                sqlComm.CommandText = "UPDATE tblAnnoncekontrol SET IndrykketPåSide = '" + txtSide.Text + "', FaktureresTil = '" + txtPris.Text + "'  WHERE (MedieplanNr = " + ordreID + ") AND (UgeavisID = " + bladID + ")";
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Redirect("FejlKonverter.htm");
            }

            Response.Redirect("Annoncekontrol.aspx?Query=" + bladID + "*" + uge + "*" + eMail + "*" + queryChk);
        }
    }
}