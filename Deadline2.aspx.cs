using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class Deadline2 : Page
    {
        public Deadline2()
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
        protected int QueryChk;
        private string[] query = new string[2];

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
                int CheckSum;
                int counter;
                int i;
                if (Request.QueryString.Count > 1)
                {
                    BladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                    QueryChk = Conversions.ToInteger(Request.QueryString["Chk"]);
                }
                else
                {
                    query = Strings.Split(Request.QueryString["Query"], "*");
                    BladID = Conversions.ToInteger(query[0]);
                    QueryChk = Conversions.ToInteger(query[1]);
                }

                SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                CheckSum = 0;
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                // If CheckSum <> QueryChk AndAlso QueryChk <> 9999 Then
                // Server.Transfer("CheckSumError.htm")
                // End If
                ViewState["BladNavn"] = BladNavn;
                ViewState["BladID"] = BladID;
                lstOrdreUge1.Items.Add(" ");
                lstMaterialeUge1.Items.Add(" ");
                lstOrdreUge1.Items.Add("Mandag");
                lstMaterialeUge1.Items.Add("Mandag");
                lstOrdreUge1.Items.Add("Tirsdag");
                lstMaterialeUge1.Items.Add("Tirsdag");
                lstOrdreUge1.Items.Add("Onsdag");
                lstMaterialeUge1.Items.Add("Onsdag");
                lstOrdreUge1.Items.Add("Torsdag");
                lstMaterialeUge1.Items.Add("Torsdag");
                lstOrdreUge1.Items.Add("Fredag");
                lstMaterialeUge1.Items.Add("Fredag");
                lstOrdreUge1.Items.Add("Lørdag");
                lstMaterialeUge1.Items.Add("Lørdag");
                lstOrdreUge1.Items.Add("Søndag");
                lstMaterialeUge1.Items.Add("Søndag");
                lstOrdreTidUge1.Items.Add(" ");
                lstMaterialeTidUge1.Items.Add(" ");
                lstOrdreUge2.Items.Add(" ");
                lstMaterialeUge2.Items.Add(" ");
                lstOrdreUge2.Items.Add("Mandag");
                lstMaterialeUge2.Items.Add("Mandag");
                lstOrdreUge2.Items.Add("Tirsdag");
                lstMaterialeUge2.Items.Add("Tirsdag");
                lstOrdreUge2.Items.Add("Onsdag");
                lstMaterialeUge2.Items.Add("Onsdag");
                lstOrdreUge2.Items.Add("Torsdag");
                lstMaterialeUge2.Items.Add("Torsdag");
                lstOrdreUge2.Items.Add("Fredag");
                lstMaterialeUge2.Items.Add("Fredag");
                lstOrdreUge2.Items.Add("Lørdag");
                lstMaterialeUge2.Items.Add("Lørdag");
                lstOrdreUge2.Items.Add("Søndag");
                lstMaterialeUge2.Items.Add("Søndag");
                lstOrdreTidUge2.Items.Add(" ");
                lstMaterialeTidUge2.Items.Add(" ");
                for (i = 9; i <= 16; i++)
                {
                    lstOrdreTidUge1.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge1.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge1.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge1.Items.Add(i.ToString() + ":30");
                    lstOrdreTidUge2.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge2.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge2.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge2.Items.Add(i.ToString() + ":30");
                }

                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 1)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstOrdreUge1.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge1.SelectedIndex = lstOrdreTidUge1.Items.IndexOf(lstOrdreTidUge1.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge1.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge1.SelectedIndex = lstMaterialeTidUge1.Items.IndexOf(lstMaterialeTidUge1.Items.FindByText(Conversions.ToString(dr[5])));
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 2)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstOrdreUge2.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge2.SelectedIndex = lstOrdreTidUge2.Items.IndexOf(lstOrdreTidUge2.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge2.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge2.SelectedIndex = lstMaterialeTidUge2.Items.IndexOf(lstMaterialeTidUge2.Items.FindByText(Conversions.ToString(dr[5])));
                }

                dr.Close();
                SqlConn.Close();
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
            try
            {
                SqlComm.CommandText = "DELETE FROM tblWEBUdgivelse WHERE (BladID=" + BladID + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                if (lstOrdreUge1.SelectedIndex > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 1,'0', 0," + lstOrdreUge1.SelectedIndex.ToString() + ",'" + lstOrdreTidUge1.SelectedItem.ToString() + "'," + lstMaterialeUge1.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge1.SelectedItem.ToString() + "', 0)";
                    SqlComm.ExecuteNonQuery();
                }

                if (lstOrdreUge2.SelectedIndex > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 2,'0', 0," + lstOrdreUge2.SelectedIndex.ToString() + ",'" + lstOrdreTidUge2.SelectedItem.ToString() + "'," + lstMaterialeUge2.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge2.SelectedItem.ToString() + "', 0)";
                    SqlComm.ExecuteNonQuery();
                }
            }
            catch
            {
                Response.Redirect("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            Response.Redirect("Afslut.htm");
        }
    }
}