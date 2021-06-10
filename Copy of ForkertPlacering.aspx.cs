using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public class ForkertPlacering : Page
    {
        public ForkertPlacering()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection sqlConn;
        protected SqlCommand sqlComm;
        private Button _btnOpdater;

        protected Button btnOpdater
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOpdater;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOpdater != null)
                {
                    _btnOpdater.Click -= btnOpdater_Click;
                }

                _btnOpdater = value;
                if (_btnOpdater != null)
                {
                    _btnOpdater.Click += btnOpdater_Click;
                }
            }
        }

        protected int ordreID;
        protected int bladID;
        protected int uge;
        protected string bladNavn;
        protected SqlDataReader dr;
        protected int queryChk;
        protected TextBox txtSide;
        protected Label Label1;
        protected Label Label2;
        protected TextBox txtPris;
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
            sqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" + "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
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
                queryChk = Conversions.ToInteger(query[2]);
                ordreID = Conversions.ToInteger(query[3]);
                sqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + bladID + ")";
                sqlConn.Open();
                dr = sqlComm.ExecuteReader();
                dr.Read();
                bladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(bladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(bladNavn, counter, 1))) % 255;
                if (CheckSum != queryChk && queryChk != 999)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                sqlConn.Close();
                ViewState["BladNavn"] = bladNavn;
                ViewState["BladID"] = bladID;
                ViewState["Uge"] = uge;
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
                queryChk = Conversions.ToInteger(ViewState["queryChk"]);
            }
        }

        private void btnOpdater_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("Annoncekontrol.aspx?Query=" + bladID + "*" + uge + "*" + queryChk);
                // Server.Transfer("PF.aspx" & Request.Url.Query)
            }
        }
    }
}