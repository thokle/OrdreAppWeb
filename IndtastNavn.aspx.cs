using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class IndtastNavn : Page
    {
        public IndtastNavn()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection sqlConn;
        protected SqlCommand sqlComm;
        protected string personNavn;
        protected int bladID;
        protected string bladNavn;
        protected SqlDataReader dr;
        protected string eMail;
        protected int PersonID;
        protected int queryChk;
        protected int spurgtID;
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
                var CheckSum = default(int);
                int counter;
                if (Request.QueryString.Count > 1)
                {
                    bladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                    spurgtID = Conversions.ToInteger(Request.QueryString["ID"]);
                    queryChk = Conversions.ToInteger(Request.QueryString["Chk"]);
                    PersonID = Conversions.ToInteger(Request.QueryString["eMail"]);
                }
                else
                {
                    query = Strings.Split(Request.QueryString["Query"], "*");
                    bladID = Conversions.ToInteger(query[0]);
                    queryChk = Conversions.ToInteger(query[1]);
                    spurgtID = Conversions.ToInteger(query[2]);
                    PersonID = Conversions.ToInteger(query[3]);
                }

                if (PersonID == 0)
                {
                    Server.Transfer("NoeMail.htm");
                }

                sqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " + bladID + ")";
                sqlConn.Open();
                dr = sqlComm.ExecuteReader();
                dr.Read();
                bladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(bladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(bladNavn, counter, 1))) % 255;
                if (CheckSum != queryChk)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                sqlComm.CommandText = "SELECT PersonNavn, eMail FROM tblWEBeMails WHERE (PersonID=" + PersonID + ")";
                dr = sqlComm.ExecuteReader();
                if (dr.Read())
                {
                    personNavn = dr.GetString(0);
                    eMail = dr.GetString(1);
                }

                sqlConn.Close();
                ViewState["BladNavn"] = bladNavn;
                ViewState["BladID"] = bladID;
                ViewState["PersonID"] = PersonID;
                ViewState["eMail"] = eMail;
                DataBind();
            }
            else
            {
                // BladNavn = CStr(ViewState("BladNavn"))
                PersonID = Conversions.ToInteger(ViewState["PersonID"]);
                bladID = Conversions.ToInteger(ViewState["BladID"]);
                eMail = Conversions.ToString(ViewState["eMail"]);
            }
        }

        private void btnOpdater_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                sqlComm.CommandText = "UPDATE tblWEBeMails SET PersonNavn = '" + txtPersonNavn.Text + "' WHERE PersonID = " + PersonID;
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
                Server.Transfer("PF.aspx" + Request.Url.Query);
            }
        }
    }
}