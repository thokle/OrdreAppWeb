using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class PF : Page
    {
        public PF()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlCommand SqlComm;
        protected SqlConnection SqlConn;
        protected Label lblVigtigt;
        protected Label lblVigtigt2;
        protected int bladID;
        protected string bladNavn;
        protected SqlDataReader dr;
        protected string eMail;
        protected int eMailID;
        protected string personNavn;
        protected string besvaretAf;
        protected int personID;
        protected int queryChk;
        protected int spurgtID;
        protected int placeringUB;
        protected double indFarve;
        protected string[] query = new string[4];
        protected bool VisPlaceringUB;

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
                int checkSum;
                int counter;
                if (Request.QueryString.Count > 1)
                {
                    bladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                    spurgtID = Conversions.ToInteger(Request.QueryString["ID"]);
                    queryChk = Conversions.ToInteger(Request.QueryString["Chk"]);
                    personID = Conversions.ToInteger(Request.QueryString["PID"]);
                }
                else
                {
                    query = Strings.Split(Request.QueryString["Query"], "*");
                    bladID = Conversions.ToInteger(query[0]);
                    queryChk = Conversions.ToInteger(query[1]);
                    spurgtID = Conversions.ToInteger(query[2]);
                    personID = Conversions.ToInteger(query[3]);
                }

                if (personID == 0)
                {
                    Server.Transfer("NoeMail.htm");
                }

                SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " + bladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                bladNavn = dr["Navn"].ToString();
                dr.Close();
                checkSum = 0;
                var loopTo = Strings.Len(bladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    checkSum = (checkSum + Strings.Asc(Strings.Mid(bladNavn, counter, 1))) % 255;
                if (checkSum != queryChk)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                lblTilBlad.Text = "Prisforespørgsel til " + bladNavn;
                SqlComm.CommandText = "SELECT PersonNavn, eMail FROM tblWEBeMails WHERE (PersonID=" + personID + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    personNavn = dr.GetString(0);
                    eMail = dr.GetString(1);
                }

                if (string.IsNullOrEmpty(personNavn))
                {
                    // Response.Redirect("IndtastNavn.aspx" & Request.Url.Query)
                    Server.Transfer("IndtastNavn.aspx" + Request.Url.Query);
                }

                dr.Close();
                SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn, tblWEBeMails.eMail FROM tblWEBForespørgselLinjer INNER JOIN tblWEBeMails ON tblWEBForespørgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForespørgselLinjer.ForespørgselID = " + spurgtID + ") AND (tblWEBForespørgselLinjer.BladID = " + bladID + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    besvaretAf = dr.GetString(0);
                }

                dr.Close();
                if (!string.IsNullOrEmpty(besvaretAf)) // vís bladets svar
                {
                    lblÆndring.Visible = true;
                    lblÆndring.Text = "Vores svar";
                    lblBladmmpris.Visible = true;
                    lblBladmmRabat.Visible = true;
                    lblBladfarvetillæg.Visible = true;
                    lblBladfarverabat.Visible = true;
                    txtBladMmPris.Visible = true;
                    txtBladMmRabat.Visible = true;
                    txtBladFarvetillæg.Visible = true;
                    txtBladFarveRabat.Visible = true;
                    lblBladBemærkning.Visible = true;
                    lblBladBemærkning.Text = "Bemærkning til svar";
                    txtBladBemærkning.Visible = true;
                    // lblPlaceringUB.Style("Top") = 528
                    // PlaceringTable.Style("Top") = 548
                    // lblVigtigt.Style("Top") = 656
                    // lblVigtigt2.Style("Top") = 656
                    // lblMVH.Style("Top") = 712
                    btnGodkend.Text = "Godkend ændringer";
                    btnÆndringer.Text = "Fortryd ændringer";
                    btnGodkend.Visible = false;
                    // btnÆndringer.Visible = False
                    SqlComm.CommandText = "SELECT PlaceringUB, BladMmPris, BladMmRabat, BladFarveTillæg, BladFarveRabat, BladBemærkning FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + bladID + ")";
                    dr = SqlComm.ExecuteReader();
                    dr.Read();
                    placeringUB = dr.GetByte(0);
                    txtBladMmPris.Text = Strings.Format(dr.GetDecimal(1), "###,##0.00");
                    txtBladMmRabat.Text = dr.GetDouble(2).ToString();
                    indFarve = (double)dr.GetDecimal(3);
                    if (indFarve < 20d)
                    {
                        txtBladFarvetillæg.Text = Strings.Format(indFarve, "###,##0.00");
                    }
                    else
                    {
                        txtBladFarvetillæg.Text = Strings.Format(indFarve, "#.###");
                    }

                    txtBladFarveRabat.Text = dr.GetDouble(4).ToString();
                    txtBladBemærkning.Text = dr.GetString(5);
                    dr.Close();
                    switch (placeringUB)
                    {
                        case 1:
                            {
                                chk357.Checked = true;
                                break;
                            }

                        case 2:
                            {
                                chkHsFm.Checked = true;
                                break;
                            }

                        case 3:
                            {
                                chkHøjSide.Checked = true;
                                break;
                            }

                        case 4:
                            {
                                chkNej.Checked = true;
                                break;
                            }
                    }

                    if ((besvaretAf ?? "") != (personNavn ?? ""))
                    {
                        lblBesvaretAf.Text = "Der kan kun ændres af " + besvaretAf;
                        chk357.Enabled = false;
                        chkHsFm.Enabled = false;
                        chkHøjSide.Enabled = false;
                        chkNej.Enabled = false;
                        txtBladMmPris.Enabled = false;
                        txtBladMmRabat.Enabled = false;
                        txtBladFarvetillæg.Enabled = false;
                        txtBladFarveRabat.Enabled = false;
                        txtBladBemærkning.Enabled = false;
                        btnÆndringer.Text = "Luk siden";
                    }
                    else
                    {
                        lblBesvaretAf.Text = "Udfyldt af " + personNavn;
                        btnGodkend.Visible = true;
                        // btnÆndringer.Visible = True
                        // ÅbnGodkend()
                    }
                }
                else // der er ikke svaret før
                {
                    lblBesvaretAf.Text = "Udfyldes af " + personNavn;
                    lblÆndring.Visible = false;
                    lblBladmmpris.Visible = false;
                    lblBladmmRabat.Visible = false;
                    lblBladfarvetillæg.Visible = false;
                    lblBladfarverabat.Visible = false;
                    txtBladMmPris.Visible = false;
                    txtBladMmRabat.Visible = false;
                    txtBladFarvetillæg.Visible = false;
                    txtBladFarveRabat.Visible = false;
                    lblBladBemærkning.Visible = false;
                    txtBladBemærkning.Visible = false;
                    // lblMarker.Style("Top") = 420
                    // lblPlaceringUB.Style("Top") = 348
                    // PlaceringTable.Style("Top") = 368
                    // lblVigtigt.Style("Top") = 476
                    // lblVigtigt2.Style("Top") = 476
                    // lblMVH.Style("Top") = 532
                    btnGodkend.Visible = true;
                }
                // Hent medieplanhoved
                SqlComm.CommandText = "SELECT NavisionContact.Name, Salesperson.Name AS Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblPlacering.Betegnelse, tblWEBForespørgsel.Mediebureau, tblWEBForespørgsel.AntalIndrykninger, tblWEBForespørgsel.Bemærkning, tblWEBForespørgsel.PlaceringUB FROM tblWEBForespørgsel INNER JOIN NavisionContact ON tblWEBForespørgsel.AnnoncørNo_ = NavisionContact.No_ INNER JOIN tblPlacering ON tblWEBForespørgsel.PlaceringID = tblPlacering.PlaceringID INNER JOIN Salesperson ON tblWEBForespørgsel.KonsulentCode = Salesperson.Code WHERE (tblWEBForespørgsel.ForespørgselID = " + spurgtID + ")";
                dr = SqlComm.ExecuteReader();
                dr.Read();
                visAnnoncør.Text = dr.GetString(0);
                lblMVH.Text = "Med venlig hilsen<br>" + dr.GetString(1);
                visFormat.Text = dr.GetString(2);
                visFarver.Text = dr.GetByte(3).ToString();
                visPlacering.Text = dr.GetString(4);
                visMediebureau.Text = dr.GetString(5);
                visAntalIndrykn.Text = dr.GetByte(6).ToString();
                visBemærkning.Text = dr.GetString(7);
                VisPlaceringUB = dr.GetBoolean(8);
                dr.Close();
                if (!VisPlaceringUB)
                {
                    PlaceringTable.Visible = false;
                    lblMarker.Visible = false;
                    lblPlaceringUB.Visible = false;
                }
                // Hent prisforeslag
                SqlComm.CommandText = "SELECT DLUMmPris, DLUMmRabat, DLUFarveTillæg, DLUFarveRabat FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + bladID + ")";
                dr = SqlComm.ExecuteReader();
                dr.Read();
                txtDLUMmpris.Text = Strings.Format(dr.GetDecimal(0), "###,##0.00");
                txtDLUMmRabat.Text = dr.GetDouble(1).ToString();
                indFarve = (double)dr.GetDecimal(2);
                if (indFarve < 20d)
                {
                    txtDLUFarvetillæg.Text = Strings.Format(indFarve, "###,##0.00");
                }
                else
                {
                    txtDLUFarvetillæg.Text = Strings.Format(indFarve, "#.###");
                }

                txtDLUFarveRabat.Text = dr.GetDouble(3).ToString();
                SqlConn.Close();
                ViewState["BladNavn"] = bladNavn;
                ViewState["BladID"] = bladID;
                ViewState["PersonNavn"] = personNavn;
                ViewState["BesvaretAf"] = besvaretAf;
                ViewState["PersonID"] = personID;
                ViewState["spurgtID"] = spurgtID;
                ViewState["PlaceringUB"] = placeringUB;
                ViewState["VisPlaceringUB"] = VisPlaceringUB;
            }
            else
            {
                bladNavn = Conversions.ToString(ViewState["BladNavn"]);
                bladID = Conversions.ToInteger(ViewState["BladID"]);
                personNavn = Conversions.ToString(ViewState["PersonNavn"]);
                besvaretAf = Conversions.ToString(ViewState["BesvaretAf"]);
                personID = Conversions.ToInteger(ViewState["PersonID"]);
                spurgtID = Conversions.ToInteger(ViewState["spurgtID"]);
                placeringUB = Conversions.ToInteger(ViewState["PlaceringUB"]);
                VisPlaceringUB = Conversions.ToBoolean(ViewState["VisPlaceringUB"]);
                if (btnÆndringer.Text != "Ændringer til forslag")
                {
                    // lblPlaceringUB.Style("Top") = 528
                    // PlaceringTable.Style("Top") = 548
                    // lblVigtigt.Style("Top") = 656
                    // lblVigtigt2.Style("Top") = 656
                    // lblMVH.Style("Top") = 712
                    // lblMarker.Style("Top") = 600
                    lblÆndring.Visible = true;
                    lblBladmmpris.Visible = true;
                    lblBladmmRabat.Visible = true;
                    lblBladfarvetillæg.Visible = true;
                    lblBladfarverabat.Visible = true;
                    txtBladMmPris.Visible = true;
                    txtBladMmRabat.Visible = true;
                    txtBladFarvetillæg.Visible = true;
                    txtBladFarveRabat.Visible = true;
                    lblBladBemærkning.Visible = true;
                    txtBladBemærkning.Visible = true;
                }
                else
                {
                    // lblPlaceringUB.Style("Top") = 348
                    // PlaceringTable.Style("Top") = 368
                    // lblVigtigt.Style("Top") = 476
                    // lblVigtigt2.Style("Top") = 476
                    // lblMVH.Style("Top") = 532
                    // lblMarker.Style("Top") = 420
                    lblÆndring.Visible = false;
                    lblBladmmpris.Visible = false;
                    lblBladmmRabat.Visible = false;
                    lblBladfarvetillæg.Visible = false;
                    lblBladfarverabat.Visible = false;
                    txtBladMmPris.Visible = false;
                    txtBladMmRabat.Visible = false;
                    txtBladFarvetillæg.Visible = false;
                    txtBladFarveRabat.Visible = false;
                    lblBladBemærkning.Visible = false;
                    txtBladBemærkning.Visible = false;
                }

                if (!VisPlaceringUB)
                {
                    PlaceringTable.Visible = false;
                    lblMarker.Visible = false;
                    lblPlaceringUB.Visible = false;
                }
            }
        }

        // Private Sub chk357_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk357.CheckedChanged
        // If chk357.Checked = True Then
        // chkHsFm.Checked = False
        // chkHøjSide.Checked = False
        // chkNej.Checked = False
        // PlaceringUB = 1
        // End If
        // ÅbnGodkend()
        // End Sub

        // Private Sub chkHsFm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHsFm.CheckedChanged
        // If chkHsFm.Checked = True Then
        // chk357.Checked = False
        // chkHøjSide.Checked = False
        // chkNej.Checked = False
        // PlaceringUB = 2
        // End If
        // ÅbnGodkend()
        // End Sub

        // Private Sub chkHøjSide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHøjSide.CheckedChanged
        // If chkHøjSide.Checked = True Then
        // chk357.Checked = False
        // chkHsFm.Checked = False
        // chkNej.Checked = False
        // PlaceringUB = 3
        // End If
        // ÅbnGodkend()
        // End Sub

        // Private Sub chkNej_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNej.CheckedChanged
        // If chkNej.Checked = True Then
        // chk357.Checked = False
        // chkHsFm.Checked = False
        // chkHøjSide.Checked = False
        // PlaceringUB = 4
        // End If
        // ÅbnGodkend()
        // End Sub

        // Private Sub ÅbnGodkend()
        // If VisPlaceringUB Then
        // If (chk357.Checked Or chkHsFm.Checked Or chkHøjSide.Checked Or chkNej.Checked) = True Then
        // btnGodkend.Enabled = True
        // Else
        // btnGodkend.Enabled = False
        // placeringUB = 0
        // End If
        // Else
        // btnGodkend.Enabled = True
        // placeringUB = 0
        // End If
        // viewstate("PlaceringUB") = placeringUB
        // End Sub

        private void btnÆndringer_Click(object sender, EventArgs e)
        {
            if (btnÆndringer.Text == "Ændringer til forslag")
            {
                lblÆndring.Visible = true;
                lblBladmmpris.Visible = true;
                lblBladmmRabat.Visible = true;
                lblBladfarvetillæg.Visible = true;
                lblBladfarverabat.Visible = true;
                txtBladMmPris.Visible = true;
                txtBladMmRabat.Visible = true;
                txtBladFarvetillæg.Visible = true;
                txtBladFarveRabat.Visible = true;
                lblBladBemærkning.Visible = true;
                txtBladBemærkning.Visible = true;
                // lblPlaceringUB.Style("Top") = 528
                // PlaceringTable.Style("Top") = 548
                // lblVigtigt.Style("Top") = 656
                // lblVigtigt2.Style("Top") = 656
                // lblMVH.Style("Top") = 712
                // lblMarker.Style("Top") = 600
                btnGodkend.Text = "Godkend ændringer";
                btnÆndringer.Text = "Fortryd ændringer";
                txtBladMmPris.Text = txtDLUMmpris.Text;
                txtBladMmRabat.Text = txtDLUMmRabat.Text;
                txtBladFarvetillæg.Text = txtDLUFarvetillæg.Text;
                txtBladFarveRabat.Text = txtDLUFarveRabat.Text;
            }
            else if (btnÆndringer.Text != "Luk siden")
            {
                lblÆndring.Visible = false;
                lblBladmmpris.Visible = false;
                lblBladmmRabat.Visible = false;
                lblBladfarvetillæg.Visible = false;
                lblBladfarverabat.Visible = false;
                txtBladMmPris.Visible = false;
                txtBladMmRabat.Visible = false;
                txtBladFarvetillæg.Visible = false;
                txtBladFarveRabat.Visible = false;
                lblBladBemærkning.Visible = false;
                txtBladBemærkning.Visible = false;
                // lblPlaceringUB.Style("Top") = 348
                // PlaceringTable.Style("Top") = 368
                // lblVigtigt.Style("Top") = 476
                // lblVigtigt2.Style("Top") = 476
                // lblMVH.Style("Top") = 532
                // lblMarker.Style("Top") = 420
                btnGodkend.Text = "Godkend forslag";
                btnÆndringer.Text = "Ændringer til forslag";
            }
            else
            {
                Response.Redirect("LukBrowseren.htm");
            }
            // ÅbnGodkend()
            btnGodkend.Visible = true;
        }

        private void btnGodkend_Click(object sender, EventArgs e)
        {
            if (btnGodkend.Text == "Godkend forslag")
            {
                // opdater med DLU værdier
                txtBladMmPris.Text = txtDLUMmpris.Text;
                txtBladMmRabat.Text = txtDLUMmRabat.Text;
                txtBladFarvetillæg.Text = txtDLUFarvetillæg.Text;
                txtBladFarveRabat.Text = txtDLUFarveRabat.Text;
            }

            try
            {
                SqlComm.CommandText = "UPDATE tblWEBForespørgselLinjer SET BesvaretAf = " + personID + ", PlaceringUB = " + placeringUB + ", BladMmPris = " + SqlConv(txtBladMmPris.Text) + ", BladMmRabat = " + SqlConv(txtBladMmRabat.Text) + ", BladFarveTillæg = " + SqlConv(txtBladFarvetillæg.Text) + ", BladFarveRabat = " + SqlConv(txtBladFarveRabat.Text) + ", BladBemærkning = '" + Strings.Replace(txtBladBemærkning.Text, "'", "''") + "' WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + bladID + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
            }
            catch
            {
                Response.Redirect("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }

            Server.Transfer("SendTilKollega.aspx" + Request.Url.Query);
        }

        private string SqlConv(string Tal)
        {
            return Strings.Replace(Tal, ",", ".");
        }
    }
}