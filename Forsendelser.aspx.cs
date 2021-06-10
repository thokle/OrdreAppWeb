using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class Forsendelser : Page
    {
        public Forsendelser()
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
                // Dim CheckSum As Integer
                // Dim counter As Integer
                BladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                // For counter = 1 To Len(BladNavn)
                // CheckSum = (CheckSum + (Asc(Mid(BladNavn, counter, 1)))) Mod 255
                // Next
                // If CheckSum <> Request.QueryString("Chk") Then
                // Server.Transfer("CheckSumError.htm")
                // End If
                SqlComm.CommandText = "SELECT ForsendelsesNavn, ForsendelsesEmail FROM tblBlade WHERE (BladId = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    txtNavn.Text = dr.GetString(0);
                    txtEmail.Text = dr.GetString(1);
                }

                dr.Close();
                SqlConn.Close();
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

        private void btnOpdater_Click(object sender, EventArgs e)
        {
            SqlComm.CommandText = "UPDATE tblBlade SET ForsendelsesNavn='" + txtNavn.Text + "', ForsendelsesEmail='" + txtEmail.Text + "' WHERE (BladID=" + BladID + ")";
            SqlConn.Open();
            SqlComm.ExecuteNonQuery();
            SqlConn.Close();
            Response.Redirect("Afslut.htm");
        }
    }
}