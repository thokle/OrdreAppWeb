using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class BemForm : Page
    {
        public BemForm()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int Uge;
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
            SqlConn.ConnectionString = "data source=DLU02;initial catalog=dimpSQL;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096";
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
                Uge = Conversions.ToInteger(Request.QueryString["Uge"]);
                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Uge + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (CheckSum != Conversions.ToDouble(Request.QueryString["Chk"]))
                {
                    Server.Transfer("CheckSumError.htm");
                }

                SqlComm.CommandText = "SELECT Bemærkning FROM tblUgeBemærkninger WHERE (BladId = " + BladID + ") AND (Uge = " + Uge + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                    txtBem.Text = dr.GetString(0);
                dr.Close();
                SqlConn.Close();
                ViewState["BladNavn"] = BladNavn;
                ViewState["Uge"] = Uge;
                ViewState["BladID"] = BladID;
                DataBind();
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                Uge = Conversions.ToInteger(ViewState["Uge"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
            }
        }

        private void txtBem_TextChanged(object sender, EventArgs e)
        {
            SqlComm.CommandText = "DELETE FROM tblUgeBemærkninger WHERE (BladID=" + BladID + ") AND (Uge=" + Uge + ")";
            SqlConn.Open();
            SqlComm.ExecuteNonQuery();
            SqlComm.CommandText = "INSERT INTO tblUgeBemærkninger (BladID, Uge, Bemærkning) VALUES (" + BladID + "," + Uge + ",'" + Strings.Replace(txtBem.Text, "'", "''") + "')";
            SqlComm.ExecuteNonQuery();
            SqlConn.Close();
        }

        private void btnOpdater_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrdreCheckForm.aspx?BladID=" + BladID + "&Uge=" + Uge + "&Chk=" + Request.QueryString["Chk"]);
        }
    }
}