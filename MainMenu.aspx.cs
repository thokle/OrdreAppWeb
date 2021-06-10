using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int BladID;
        protected string BladNavn;
        private SqlDataReader dr;
        #region  Web Form Designer Generated Code 

        // This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SqlConn = new SqlConnection();
            SqlComm = new SqlCommand();
            // 
            // SqlConn
            // 
            SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" + "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
            // 
            // SqlComm
            // 
            SqlComm.Connection = SqlConn;
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
                var CheckSum = default(int);
                int counter;
                BladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (CheckSum != Conversions.ToDouble(Request.QueryString["Chk"]))
                {
                    Server.Transfer("CheckSumError.htm");
                }

                SqlConn.Close();
                linkPris.NavigateUrl = "MmPriser.aspx?BladID=" + BladID + "&chk=" + CheckSum;
                linkPrimaer.NavigateUrl = "PrimaerOmraader.aspx?BladID=" + BladID + "&chk=" + CheckSum;
                linkKommuner.NavigateUrl = "PrimaerKommuner.aspx?BladID=" + BladID + "&chk=" + CheckSum;
                ViewState["BladNavn"] = BladNavn;
                ViewState["BladID"] = BladID;
                DataBind();
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
            }
        }
    }
}