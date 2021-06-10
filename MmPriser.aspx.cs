using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class MmPriser : Page
    {
        public MmPriser()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int BladID;
        protected string BladNavn;
        private short Placering;
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
            SqlConn.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096";
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
                SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " + BladID + ")";
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
                // If CInt(query(2)) > 0 Then
                // SqlComm.CommandText = "UPDATE tblFarvetillægMinMaxWebApp SET Godkendt=1  WHERE (BladID=" & BladID & ")"
                // SqlComm.ExecuteNonQuery()
                // SqlConn.Close()
                // Response.Redirect("Afslut.htm")
                // End If
                SqlComm.CommandText = "SELECT Placering, Pris FROM tblMmPrisWebApp WHERE (BladID = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                while (dr.Read())
                {
                    Placering = dr.GetByte(0);
                    pris = Strings.Format(dr.GetDecimal(1), "###0.00");
                    switch (Placering)
                    {
                        case 1:
                            {
                                txtTekstside.Text = pris;
                                break;
                            }

                        case 2:
                            {
                                txtSide3.Text = pris;
                                break;
                            }

                        case 3:
                            {
                                txtSide5.Text = pris;
                                break;
                            }

                        case 4:
                            {
                                txtSide7.Text = pris;
                                break;
                            }

                        case 5:
                            {
                                txtHøjreSide.Text = pris;
                                break;
                            }

                        case 16:
                            {
                                txtBolig.Text = pris;
                                break;
                            }

                        case 12:
                            {
                                txtMotorside.Text = pris;
                                break;
                            }

                        case 13:
                            {
                                txtForlystelser.Text = pris;
                                break;
                            }

                        case 15:
                            {
                                txtStillinger.Text = pris;
                                break;
                            }

                        case 14:
                            {
                                txtOfficielle.Text = pris;
                                break;
                            }

                        case 17:
                            {
                                txtUddannelse.Text = pris;
                                break;
                            }

                        case 11:
                            {
                                txtRubrik.Text = pris;
                                break;
                            }
                    }
                }

                dr.Close();
                SqlComm.CommandText = "SELECT farvePris, farveMin, farveMax, farve4Pris, farve4Min, farve4Max, PrisBemærkning FROM tblFarveTillægWebApp WHERE (BladID = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        if (dr.GetDecimal(0) > 0m)
                        {
                            txtFarvetillæg.Text = Strings.Format(dr.GetDecimal(0), "###0.00");
                        }
                        else
                        {
                            txtFarvetillæg.Text = "";
                        }
                    }

                    if (!dr.IsDBNull(1))
                        txtFarveMin.Text = dr.GetInt16(1).ToString();
                    if (!dr.IsDBNull(2))
                        txtFarveMax.Text = dr.GetInt16(2).ToString();
                    if (!dr.IsDBNull(3))
                    {
                        if (dr.GetDecimal(3) > 0m)
                        {
                            txt4Farvetillæg.Text = Strings.Format(dr.GetDecimal(3), "###0.00");
                        }
                        else
                        {
                            txt4Farvetillæg.Text = "";
                        }
                    }

                    if (!dr.IsDBNull(4))
                        txt4FarveMin.Text = dr.GetInt16(4).ToString();
                    if (!dr.IsDBNull(5))
                        txt4FarveMax.Text = dr.GetInt16(5).ToString();
                    if (!dr.IsDBNull(6))
                        txtBem.Text = dr.GetString(6);
                }

                dr.Close();
                SqlConn.Close();
                checkLabels();
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

        private void txtFarvetillæg_TextChanged(object sender, EventArgs e)
        {
            checkLabels();
        }

        private void txt4Farvetillæg_TextChanged(object sender, EventArgs e)
        {
            checkLabels();
        }

        private void checkLabels()
        {
            if (txt4Farvetillæg.Text.Length > 0)
            {
                if (Conversions.ToDouble(txt4Farvetillæg.Text) < 20d)
                {
                    txt4FarveMin.Visible = true;
                    txt4FarveMax.Visible = true;
                }
                else
                {
                    txt4FarveMin.Visible = false;
                    txt4FarveMax.Visible = false;
                }
            }
            else
            {
                txt4FarveMin.Visible = false;
                txt4FarveMax.Visible = false;
            }

            if (txtFarvetillæg.Text.Length > 0)
            {
                if (Conversions.ToDouble(txtFarvetillæg.Text) < 20d)
                {
                    txtFarveMin.Visible = true;
                    txtFarveMax.Visible = true;
                }
                else
                {
                    txtFarveMin.Visible = false;
                    txtFarveMax.Visible = false;
                }
            }
            else
            {
                txtFarveMin.Visible = false;
                txtFarveMax.Visible = false;
            }

            if (txtFarveMin.Visible || txt4FarveMin.Visible)
            {
                lblMin.Visible = true;
            }
            else
            {
                lblMin.Visible = false;
            }

            if (txtFarveMax.Visible || txt4FarveMax.Visible)
            {
                lblMax.Visible = true;
            }
            else
            {
                lblMax.Visible = false;
            }
        }

        private void btnGodkend_Click(object sender, EventArgs e)
        {
            string sql;
            try
            {
                SqlConn.Open();
                SqlComm.CommandText = "DELETE FROM tblMmPrisWebApp WHERE (BladID = " + BladID + ")";
                SqlComm.ExecuteNonQuery();
                if (txtTekstside.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",1," + txtTekstside.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtTekstside.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=1)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtSide3.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",2," + txtSide3.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtSide3.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=2)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtSide5.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",3," + txtSide5.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtSide5.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=3)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtSide7.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",4," + txtSide7.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtSide7.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=4)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtHøjreSide.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",5," + txtHøjreSide.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtHøjreSide.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=5)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtBolig.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",16," + txtBolig.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtBolig.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=16)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtMotorside.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",12," + txtMotorside.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtMotorside.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=12)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtForlystelser.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",13," + txtForlystelser.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtForlystelser.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=13)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtStillinger.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",15," + txtStillinger.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtStillinger.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=15)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtOfficielle.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",14," + txtOfficielle.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtOfficielle.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=14)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtUddannelse.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",17," + txtUddannelse.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtUddannelse.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=17)"
                    SqlComm.ExecuteNonQuery();
                }

                if (txtRubrik.Text.Length > 0)
                {
                    SqlComm.CommandText = "INSERT INTO tblMmPrisWebApp (BladID, Placering, Pris) VALUES (" + BladID + ",11," + txtRubrik.Text.Replace(",", ".") + ")";
                    // SqlComm.CommandText = "UPDATE tblMmPrisWebApp SET Pris=" & txtRubrik.Text.Replace(",", ".") & " WHERE (BladID=" & BladID & " AND Placering=11)"
                    SqlComm.ExecuteNonQuery();
                }

                SqlComm.CommandText = "DELETE FROM tblFarveTillægWebApp WHERE (BladID = " + BladID + ")";
                SqlComm.ExecuteNonQuery();
                if (txtFarvetillæg.Text.Length == 0)
                    txtFarvetillæg.Text = "0";
                if (txt4Farvetillæg.Text.Length == 0)
                    txt4Farvetillæg.Text = "0";
                sql = "INSERT INTO tblFarveTillægWebApp (BladID, farvePris, farveMin, farveMax, farve4Pris, farve4Min, farve4Max, Godkendt, PrisBemærkning) VALUES (";
                sql += BladID + "," + txtFarvetillæg.Text.Replace(",", ".") + "," + txtFarveMin.Text + "," + txtFarveMax.Text + "," + txt4Farvetillæg.Text.Replace(",", ".") + "," + txt4FarveMin.Text + "," + txt4FarveMax.Text + ",1,'" + Strings.Replace(txtBem.Text, "'", "''") + "')";
                SqlComm.CommandText = sql;
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