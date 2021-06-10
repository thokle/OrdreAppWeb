using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class Deadline : Page
    {
        public Deadline()
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
                lstUge1.Items.Add(" ");
                lstUdgivelseUge1.Items.Add(" ");
                lstOrdreUge1.Items.Add(" ");
                lstMaterialeUge1.Items.Add(" ");
                lstUge2.Items.Add(" ");
                lstUdgivelseUge2.Items.Add(" ");
                lstOrdreUge2.Items.Add(" ");
                lstMaterialeUge2.Items.Add(" ");
                lstUge3.Items.Add(" ");
                lstUdgivelseUge3.Items.Add(" ");
                lstOrdreUge3.Items.Add(" ");
                lstMaterialeUge3.Items.Add(" ");
                lstUge4.Items.Add(" ");
                lstUdgivelseUge4.Items.Add(" ");
                lstOrdreUge4.Items.Add(" ");
                lstMaterialeUge4.Items.Add(" ");
                lstUge5.Items.Add(" ");
                lstUdgivelseUge5.Items.Add(" ");
                lstOrdreUge5.Items.Add(" ");
                lstMaterialeUge5.Items.Add(" ");
                lstUge6.Items.Add(" ");
                lstUdgivelseUge6.Items.Add(" ");
                lstOrdreUge6.Items.Add(" ");
                lstMaterialeUge6.Items.Add(" ");
                lstUge7.Items.Add(" ");
                lstUdgivelseUge7.Items.Add(" ");
                lstOrdreUge7.Items.Add(" ");
                lstMaterialeUge7.Items.Add(" ");
                lstUge8.Items.Add(" ");
                lstUdgivelseUge8.Items.Add(" ");
                lstOrdreUge8.Items.Add(" ");
                lstMaterialeUge8.Items.Add(" ");
                for (i = 1; i <= 31; i++)
                {
                    lstUdgivelseUge1.Items.Add(i.ToString());
                    lstOrdreUge1.Items.Add(i.ToString());
                    lstMaterialeUge1.Items.Add(i.ToString());
                    lstUdgivelseUge2.Items.Add(i.ToString());
                    lstOrdreUge2.Items.Add(i.ToString());
                    lstMaterialeUge2.Items.Add(i.ToString());
                    lstUdgivelseUge3.Items.Add(i.ToString());
                    lstOrdreUge3.Items.Add(i.ToString());
                    lstMaterialeUge3.Items.Add(i.ToString());
                    lstUdgivelseUge4.Items.Add(i.ToString());
                    lstOrdreUge4.Items.Add(i.ToString());
                    lstMaterialeUge4.Items.Add(i.ToString());
                    lstUdgivelseUge5.Items.Add(i.ToString());
                    lstOrdreUge5.Items.Add(i.ToString());
                    lstMaterialeUge5.Items.Add(i.ToString());
                    lstUdgivelseUge6.Items.Add(i.ToString());
                    lstOrdreUge6.Items.Add(i.ToString());
                    lstMaterialeUge6.Items.Add(i.ToString());
                    lstUdgivelseUge7.Items.Add(i.ToString());
                    lstOrdreUge7.Items.Add(i.ToString());
                    lstMaterialeUge7.Items.Add(i.ToString());
                    lstUdgivelseUge8.Items.Add(i.ToString());
                    lstOrdreUge8.Items.Add(i.ToString());
                    lstMaterialeUge8.Items.Add(i.ToString());
                }

                lstOrdreTidUge1.Items.Add(" ");
                lstMaterialeTidUge1.Items.Add(" ");
                lstOrdreTidUge2.Items.Add(" ");
                lstMaterialeTidUge2.Items.Add(" ");
                lstOrdreTidUge3.Items.Add(" ");
                lstMaterialeTidUge3.Items.Add(" ");
                lstOrdreTidUge4.Items.Add(" ");
                lstMaterialeTidUge4.Items.Add(" ");
                lstOrdreTidUge5.Items.Add(" ");
                lstMaterialeTidUge5.Items.Add(" ");
                lstOrdreTidUge6.Items.Add(" ");
                lstMaterialeTidUge6.Items.Add(" ");
                lstOrdreTidUge7.Items.Add(" ");
                lstMaterialeTidUge7.Items.Add(" ");
                lstOrdreTidUge8.Items.Add(" ");
                lstMaterialeTidUge8.Items.Add(" ");
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
                    lstOrdreTidUge3.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge3.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge3.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge3.Items.Add(i.ToString() + ":30");
                    lstOrdreTidUge4.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge4.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge4.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge4.Items.Add(i.ToString() + ":30");
                    lstOrdreTidUge5.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge5.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge5.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge5.Items.Add(i.ToString() + ":30");
                    lstOrdreTidUge6.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge6.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge6.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge6.Items.Add(i.ToString() + ":30");
                    lstOrdreTidUge7.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge7.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge7.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge7.Items.Add(i.ToString() + ":30");
                    lstOrdreTidUge8.Items.Add(i.ToString() + ":00");
                    lstOrdreTidUge8.Items.Add(i.ToString() + ":30");
                    lstMaterialeTidUge8.Items.Add(i.ToString() + ":00");
                    lstMaterialeTidUge8.Items.Add(i.ToString() + ":30");
                }

                for (i = 1; i <= 53; i++)
                {
                    lstUge1.Items.Add(i.ToString());
                    lstUge2.Items.Add(i.ToString());
                    lstUge3.Items.Add(i.ToString());
                    lstUge4.Items.Add(i.ToString());
                    lstUge5.Items.Add(i.ToString());
                    lstUge6.Items.Add(i.ToString());
                    lstUge7.Items.Add(i.ToString());
                    lstUge8.Items.Add(i.ToString());
                }

                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 1)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge1.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge1.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge1.SelectedIndex = lstOrdreTidUge1.Items.IndexOf(lstOrdreTidUge1.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge1.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge1.SelectedIndex = lstMaterialeTidUge1.Items.IndexOf(lstMaterialeTidUge1.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge1.SelectedIndex = lstUge1.Items.IndexOf(lstUge1.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke1.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke1_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 2)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge2.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge2.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge2.SelectedIndex = lstOrdreTidUge2.Items.IndexOf(lstOrdreTidUge2.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge2.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge2.SelectedIndex = lstMaterialeTidUge2.Items.IndexOf(lstMaterialeTidUge2.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge2.SelectedIndex = lstUge2.Items.IndexOf(lstUge2.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke2.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke2_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 3)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge3.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge3.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge3.SelectedIndex = lstOrdreTidUge3.Items.IndexOf(lstOrdreTidUge3.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge3.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge3.SelectedIndex = lstMaterialeTidUge3.Items.IndexOf(lstMaterialeTidUge3.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge3.SelectedIndex = lstUge3.Items.IndexOf(lstUge3.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke3.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke3_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 4)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge4.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge4.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge4.SelectedIndex = lstOrdreTidUge4.Items.IndexOf(lstOrdreTidUge4.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge4.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge4.SelectedIndex = lstMaterialeTidUge4.Items.IndexOf(lstMaterialeTidUge4.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge4.SelectedIndex = lstUge4.Items.IndexOf(lstUge4.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke4.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke4_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 5)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge5.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge5.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge5.SelectedIndex = lstOrdreTidUge5.Items.IndexOf(lstOrdreTidUge5.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge5.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge5.SelectedIndex = lstMaterialeTidUge5.Items.IndexOf(lstMaterialeTidUge5.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge5.SelectedIndex = lstUge5.Items.IndexOf(lstUge5.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke5.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke5_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 6)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge6.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge6.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge6.SelectedIndex = lstOrdreTidUge6.Items.IndexOf(lstOrdreTidUge6.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge6.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge6.SelectedIndex = lstMaterialeTidUge6.Items.IndexOf(lstMaterialeTidUge6.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge6.SelectedIndex = lstUge6.Items.IndexOf(lstUge6.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke6.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke6_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 7)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge7.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge7.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge7.SelectedIndex = lstOrdreTidUge7.Items.IndexOf(lstOrdreTidUge7.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge7.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge7.SelectedIndex = lstMaterialeTidUge7.Items.IndexOf(lstMaterialeTidUge7.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge7.SelectedIndex = lstUge7.Items.IndexOf(lstUge7.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke7.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke7_CheckedChanged(new object(), new EventArgs());
                }

                dr.Close();
                SqlComm.CommandText = "SELECT UdkommerIkke, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, Uge FROM tblWEBUdgivelse WHERE (BladID = " + BladID + ") AND (Linje = 8)";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    lstUdgivelseUge8.SelectedIndex = Conversions.ToInteger(dr[1]);
                    lstOrdreUge8.SelectedIndex = Conversions.ToInteger(dr[2]);
                    lstOrdreTidUge8.SelectedIndex = lstOrdreTidUge8.Items.IndexOf(lstOrdreTidUge8.Items.FindByText(Conversions.ToString(dr[3])));
                    lstMaterialeUge8.SelectedIndex = Conversions.ToInteger(dr[4]);
                    lstMaterialeTidUge8.SelectedIndex = lstMaterialeTidUge8.Items.IndexOf(lstMaterialeTidUge8.Items.FindByText(Conversions.ToString(dr[5])));
                    lstUge8.SelectedIndex = lstUge8.Items.IndexOf(lstUge8.Items.FindByText(Conversions.ToString(dr[6])));
                    chkKommerIkke8.Checked = Conversions.ToBoolean(dr[0]);
                    chkKommerIkke8_CheckedChanged(new object(), new EventArgs());
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
                if (lstUge1.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 1,'" + lstUge1.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge1.SelectedIndex.ToString() + "," + lstOrdreUge1.SelectedIndex.ToString() + ",'" + lstOrdreTidUge1.SelectedItem.ToString() + "'," + lstMaterialeUge1.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge1.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke1.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge2.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 2,'" + lstUge2.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge2.SelectedIndex.ToString() + "," + lstOrdreUge2.SelectedIndex.ToString() + ",'" + lstOrdreTidUge2.SelectedItem.ToString() + "'," + lstMaterialeUge2.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge2.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke2.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge3.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 3,'" + lstUge3.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge3.SelectedIndex.ToString() + "," + lstOrdreUge3.SelectedIndex.ToString() + ",'" + lstOrdreTidUge3.SelectedItem.ToString() + "'," + lstMaterialeUge3.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge3.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke3.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge4.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 4,'" + lstUge4.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge4.SelectedIndex.ToString() + "," + lstOrdreUge4.SelectedIndex.ToString() + ",'" + lstOrdreTidUge4.SelectedItem.ToString() + "'," + lstMaterialeUge4.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge4.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke4.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge5.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 5,'" + lstUge5.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge5.SelectedIndex.ToString() + "," + lstOrdreUge5.SelectedIndex.ToString() + ",'" + lstOrdreTidUge5.SelectedItem.ToString() + "'," + lstMaterialeUge5.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge5.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke5.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge6.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 6,'" + lstUge6.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge6.SelectedIndex.ToString() + "," + lstOrdreUge6.SelectedIndex.ToString() + ",'" + lstOrdreTidUge6.SelectedItem.ToString() + "'," + lstMaterialeUge6.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge6.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke6.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge7.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 7,'" + lstUge7.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge7.SelectedIndex.ToString() + "," + lstOrdreUge7.SelectedIndex.ToString() + ",'" + lstOrdreTidUge7.SelectedItem.ToString() + "'," + lstMaterialeUge7.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge7.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke7.Checked, "1", "0")), ")")));
                    SqlComm.ExecuteNonQuery();
                }

                if (lstUge8.SelectedIndex > 0)
                {
                    SqlComm.CommandText = Conversions.ToString(Operators.ConcatenateObject("INSERT INTO tblWebUdgivelse (BladID, Linje, Uge, UdgivelsesDato, OrdreDeadline, OrdreTid, MaterialeDeadline, MaterialeTid, UdkommerIkke) VALUES (" + BladID.ToString() + ", 8,'" + lstUge8.SelectedItem.ToString(), Operators.AddObject(Operators.AddObject("'," + lstUdgivelseUge8.SelectedIndex.ToString() + "," + lstOrdreUge8.SelectedIndex.ToString() + ",'" + lstOrdreTidUge8.SelectedItem.ToString() + "'," + lstMaterialeUge8.SelectedIndex.ToString() + ",'" + lstMaterialeTidUge8.SelectedItem.ToString() + "',", Interaction.IIf(chkKommerIkke8.Checked, "1", "0")), ")")));
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

        private void chkKommerIkke1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke1.Checked == true)
            {
                lstUdgivelseUge1.SelectedIndex = 0;
                lstUdgivelseUge1.Enabled = false;
                lstOrdreUge1.SelectedIndex = 0;
                lstOrdreUge1.Enabled = false;
                lstOrdreTidUge1.SelectedIndex = 0;
                lstOrdreTidUge1.Enabled = false;
                lstMaterialeUge1.SelectedIndex = 0;
                lstMaterialeUge1.Enabled = false;
                lstMaterialeTidUge1.SelectedIndex = 0;
                lstMaterialeTidUge1.Enabled = false;
            }
            else
            {
                lstUdgivelseUge1.Enabled = true;
                lstOrdreUge1.Enabled = true;
                lstOrdreTidUge1.Enabled = true;
                lstMaterialeUge1.Enabled = true;
                lstMaterialeTidUge1.Enabled = true;
            }
        }

        private void chkKommerIkke2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke2.Checked == true)
            {
                lstUdgivelseUge2.SelectedIndex = 0;
                lstUdgivelseUge2.Enabled = false;
                lstOrdreUge2.SelectedIndex = 0;
                lstOrdreUge2.Enabled = false;
                lstOrdreTidUge2.SelectedIndex = 0;
                lstOrdreTidUge2.Enabled = false;
                lstMaterialeUge2.SelectedIndex = 0;
                lstMaterialeUge2.Enabled = false;
                lstMaterialeTidUge2.SelectedIndex = 0;
                lstMaterialeTidUge2.Enabled = false;
            }
            else
            {
                lstUdgivelseUge2.Enabled = true;
                lstOrdreUge2.Enabled = true;
                lstOrdreTidUge2.Enabled = true;
                lstMaterialeUge2.Enabled = true;
                lstMaterialeTidUge2.Enabled = true;
            }
        }

        private void chkKommerIkke3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke3.Checked == true)
            {
                lstUdgivelseUge3.SelectedIndex = 0;
                lstUdgivelseUge3.Enabled = false;
                lstOrdreUge3.SelectedIndex = 0;
                lstOrdreUge3.Enabled = false;
                lstOrdreTidUge3.SelectedIndex = 0;
                lstOrdreTidUge3.Enabled = false;
                lstMaterialeUge3.SelectedIndex = 0;
                lstMaterialeUge3.Enabled = false;
                lstMaterialeTidUge3.SelectedIndex = 0;
                lstMaterialeTidUge3.Enabled = false;
            }
            else
            {
                lstUdgivelseUge3.Enabled = true;
                lstOrdreUge3.Enabled = true;
                lstOrdreTidUge3.Enabled = true;
                lstMaterialeUge3.Enabled = true;
                lstMaterialeTidUge3.Enabled = true;
            }
        }

        private void chkKommerIkke4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke4.Checked == true)
            {
                lstUdgivelseUge4.SelectedIndex = 0;
                lstUdgivelseUge4.Enabled = false;
                lstOrdreUge4.SelectedIndex = 0;
                lstOrdreUge4.Enabled = false;
                lstOrdreTidUge4.SelectedIndex = 0;
                lstOrdreTidUge4.Enabled = false;
                lstMaterialeUge4.SelectedIndex = 0;
                lstMaterialeUge4.Enabled = false;
                lstMaterialeTidUge4.SelectedIndex = 0;
                lstMaterialeTidUge4.Enabled = false;
            }
            else
            {
                lstUdgivelseUge4.Enabled = true;
                lstOrdreUge4.Enabled = true;
                lstOrdreTidUge4.Enabled = true;
                lstMaterialeUge4.Enabled = true;
                lstMaterialeTidUge4.Enabled = true;
            }
        }

        private void chkKommerIkke5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke5.Checked == true)
            {
                lstUdgivelseUge5.SelectedIndex = 0;
                lstUdgivelseUge5.Enabled = false;
                lstOrdreUge5.SelectedIndex = 0;
                lstOrdreUge5.Enabled = false;
                lstOrdreTidUge5.SelectedIndex = 0;
                lstOrdreTidUge5.Enabled = false;
                lstMaterialeUge5.SelectedIndex = 0;
                lstMaterialeUge5.Enabled = false;
                lstMaterialeTidUge5.SelectedIndex = 0;
                lstMaterialeTidUge5.Enabled = false;
            }
            else
            {
                lstUdgivelseUge5.Enabled = true;
                lstOrdreUge5.Enabled = true;
                lstOrdreTidUge5.Enabled = true;
                lstMaterialeUge5.Enabled = true;
                lstMaterialeTidUge5.Enabled = true;
            }
        }

        private void chkKommerIkke6_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke6.Checked == true)
            {
                lstUdgivelseUge6.SelectedIndex = 0;
                lstUdgivelseUge6.Enabled = false;
                lstOrdreUge6.SelectedIndex = 0;
                lstOrdreUge6.Enabled = false;
                lstOrdreTidUge6.SelectedIndex = 0;
                lstOrdreTidUge6.Enabled = false;
                lstMaterialeUge6.SelectedIndex = 0;
                lstMaterialeUge6.Enabled = false;
                lstMaterialeTidUge6.SelectedIndex = 0;
                lstMaterialeTidUge6.Enabled = false;
            }
            else
            {
                lstUdgivelseUge6.Enabled = true;
                lstOrdreUge6.Enabled = true;
                lstOrdreTidUge6.Enabled = true;
                lstMaterialeUge6.Enabled = true;
                lstMaterialeTidUge6.Enabled = true;
            }
        }

        private void chkKommerIkke7_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke7.Checked == true)
            {
                lstUdgivelseUge7.SelectedIndex = 0;
                lstUdgivelseUge7.Enabled = false;
                lstOrdreUge7.SelectedIndex = 0;
                lstOrdreUge7.Enabled = false;
                lstOrdreTidUge7.SelectedIndex = 0;
                lstOrdreTidUge7.Enabled = false;
                lstMaterialeUge7.SelectedIndex = 0;
                lstMaterialeUge7.Enabled = false;
                lstMaterialeTidUge7.SelectedIndex = 0;
                lstMaterialeTidUge7.Enabled = false;
            }
            else
            {
                lstUdgivelseUge7.Enabled = true;
                lstOrdreUge7.Enabled = true;
                lstOrdreTidUge7.Enabled = true;
                lstMaterialeUge7.Enabled = true;
                lstMaterialeTidUge7.Enabled = true;
            }
        }

        private void chkKommerIkke8_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKommerIkke8.Checked == true)
            {
                lstUdgivelseUge8.SelectedIndex = 0;
                lstUdgivelseUge8.Enabled = false;
                lstOrdreUge8.SelectedIndex = 0;
                lstOrdreUge8.Enabled = false;
                lstOrdreTidUge8.SelectedIndex = 0;
                lstOrdreTidUge8.Enabled = false;
                lstMaterialeUge8.SelectedIndex = 0;
                lstMaterialeUge8.Enabled = false;
                lstMaterialeTidUge8.SelectedIndex = 0;
                lstMaterialeTidUge8.Enabled = false;
            }
            else
            {
                lstUdgivelseUge8.Enabled = true;
                lstOrdreUge8.Enabled = true;
                lstOrdreTidUge8.Enabled = true;
                lstMaterialeUge8.Enabled = true;
                lstMaterialeTidUge8.Enabled = true;
            }
        }
    }
}