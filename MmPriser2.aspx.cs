using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class MmPriser2 : Page
    {
        public MmPriser2()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int BladID;
        protected string BladNavn;
        private short mmType;
        private string pris;
        private SqlDataReader dr;
        private string[] query = new string[3];

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
                query = Strings.Split(Request.QueryString["Query"], "*");
                BladID = Conversions.ToInteger(query[0]);
                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (CheckSum != Conversions.ToInteger(query[1]))
                {
                    Server.Transfer("CheckSumError.htm");
                }

                if (Conversions.ToInteger(query[2]) > 0)
                {
                    SqlComm.CommandText = "UPDATE tblFarvetillægMinMaxWebApp SET Godkendt=1  WHERE (BladID=" + BladID + ")";
                    SqlComm.ExecuteNonQuery();
                    SqlConn.Close();
                    Response.Redirect("Afslut.htm");
                }

                SqlComm.CommandText = "SELECT mmType, Pris FROM tblMmPrisWebApp WHERE (BladId = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    mmType = dr.GetByte(0);
                    pris = Strings.Format(dr.GetDecimal(1), "###0.00");
                    switch (mmType)
                    {
                        case 9:
                            {
                                txtTekstside.Text = pris;
                                break;
                            }

                        case 10:
                            {
                                txtStillinger.Text = pris;
                                break;
                            }
                    }
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

        private void btnGodkend_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConn.Open();
                SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" + txtTekstside.Text.Replace(",", ".") + " WHERE (BladID=" + BladID + " AND mmType=9)";
                SqlComm.ExecuteNonQuery();
                SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" + txtStillinger.Text.Replace(",", ".") + " WHERE (BladID=" + BladID + " AND mmType=10)";
                SqlComm.ExecuteNonQuery();
                SqlComm.CommandText = "UPDATE tblFarvetillægMinMaxWebApp SET Godkendt=1  WHERE (BladID=" + BladID + ")";
                SqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Response.Redirect("FejlKonverter.htm");
            }
            finally
            {
                SqlConn.Close();
            }

            Response.Redirect("Afslut.htm");
        }
    }
}