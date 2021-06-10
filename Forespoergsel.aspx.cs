using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class Forespoergsel : Page
    {
        public Forespoergsel()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected int BladID;
        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected string BladNavn;
        private SqlDataReader dr;
        protected string eMail;
        protected string PersonNavn;
        protected string BesvaretAf;
        protected int PersonID;
        protected bool FirstTime;
        protected int QueryChk;
        protected int spurgtID;
        private string[] query = new string[4];

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
                if (Request.QueryString.Count > 1)
                {
                    BladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                    spurgtID = Conversions.ToInteger(Request.QueryString["ID"]);
                    QueryChk = Conversions.ToInteger(Request.QueryString["Chk"]);
                    eMail = Request.QueryString["eMail"];
                }
                else
                {
                    query = Strings.Split(Request.QueryString["Query"], "*");
                    BladID = Conversions.ToInteger(query[0]);
                    QueryChk = Conversions.ToInteger(query[1]);
                    spurgtID = Conversions.ToInteger(query[2]);
                    eMail = query[3];
                }

                if (string.IsNullOrEmpty(eMail))
                {
                    Server.Transfer("NoeMail.htm");
                }

                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (CheckSum != QueryChk)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                SqlComm.CommandText = "SELECT PersonNavn, PersonID FROM tblWEBeMails WHERE (eMail='" + eMail + "')";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    PersonNavn = dr.GetString(0);
                    PersonID = dr.GetInt32(1);
                }
                // If PersonNavn = "" Then
                // Server.Transfer("IndtastNavn.aspx" & Request.Url.Query)
                // End If
                dr.Close();
                SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn FROM tblWEBForespørgselLinjer INNER JOIN tblWEBeMails ON tblWEBForespørgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForespørgselLinjer.ForespørgselID = " + spurgtID + ") AND (tblWEBForespørgselLinjer.BladID = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    BesvaretAf = dr.GetString(0);
                }

                dr.Close();
                if (!string.IsNullOrEmpty(BesvaretAf)) // vís bladets svar
                {
                    txtBladMmPris.Visible = true;
                    txtBladMmRabat.Visible = true;
                    txtBladFarvetillæg.Visible = true;
                    txtBladFarveRabat.Visible = true;
                    lblBemærkning.Visible = true;
                    txtBemærkning.Visible = true;
                    btnFortryd.Visible = false;
                    btnOpdater.Visible = true;
                    btnGodkend.Visible = false;
                    btnÆndringer.Visible = false;
                    SqlComm.CommandText = "SELECT BladMmPris, BladMmRabat, BladFarveTillæg, BladFarveRabat, BladBemærkning FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + BladID + ")";
                    dr = SqlComm.ExecuteReader();
                    dr.Read();
                    txtBladMmPris.Text = Strings.Format(dr.GetDecimal(0), "###,##0.00");
                    txtBladMmRabat.Text = dr.GetDouble(1).ToString();
                    txtBladFarvetillæg.Text = Strings.Format(dr.GetDecimal(2), "0000");
                    txtBladFarveRabat.Text = dr.GetDouble(3).ToString();
                    txtBemærkning.Text = dr.GetString(4);
                    dr.Close();
                    if ((BesvaretAf ?? "") != (PersonNavn ?? ""))
                    {
                        btnOpdater.Visible = false;
                        lblBesvaretAf.Text = "<h2>Der kan kun ændres af " + BesvaretAf + "</h2>";
                    }
                    else
                    {
                        lblBesvaretAf.Text = "<h3>Udfyldt af " + PersonNavn + "</h3>";
                    }

                    FirstTime = false;
                }
                else // der er ikke svaret før
                {
                    lblBesvaretAf.Text = "<h2>Udfyldes af " + PersonNavn + "</h2>";
                    FirstTime = true;
                }
                // Hent medieplanhoved
                SqlComm.CommandText = "SELECT tblAnnoncører.Annoncør, tblBrugere.Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblMmTyper.Betegnelse, tblWEBForespørgsel.Bemærkning FROM tblWEBForespørgsel INNER JOIN tblAnnoncører ON tblWEBForespørgsel.AnnoncørID = tblAnnoncører.AnnoncørID INNER JOIN tblBrugere ON tblWEBForespørgsel.KonsulentID = tblBrugere.BrugerID INNER JOIN tblMmTyper ON tblWEBForespørgsel.Placering = tblMmTyper.mmType WHERE(tblWEBForespørgsel.ForespørgselID = " + spurgtID + ")";
                dr = SqlComm.ExecuteReader();
                dr.Read();
                lblInfo.Text = "<b>Kunde : </b>" + dr.GetString(0) + "<BR><b>Konsulent : </b>" + dr.GetString(1) + "<br><b>Format : </b>" + dr.GetString(2) + "<br><b>Farver : </b>" + dr.GetByte(3) + "<br><b>Placering : </b>" + dr.GetString(4) + "<br><b>Bemærkning : </b>" + dr.GetString(5);
                dr.Close();
                // Hent prisforeslag
                SqlComm.CommandText = "SELECT DLUMmPris, DLUMmRabat, DLUFarveTillæg, DLUFarveRabat FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                dr.Read();
                txtDLUMmpris.Text = Strings.Format(dr.GetDecimal(0), "###,##0.00");
                txtDLUMmRabat.Text = dr.GetDouble(1).ToString();
                txtDLUFarvetillæg.Text = Strings.Format(dr.GetDecimal(2), "0000");
                txtDLUFarveRabat.Text = dr.GetDouble(3).ToString();
                SqlConn.Close();
                ViewState["BladNavn"] = BladNavn;
                ViewState["BladID"] = BladID;
                ViewState["PersonNavn"] = PersonNavn;
                ViewState["BesvaretAf"] = BesvaretAf;
                ViewState["PersonID"] = PersonID;
                ViewState["spurgtID"] = spurgtID;
                ViewState["FirstTime"] = FirstTime;
                DataBind();
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
                PersonNavn = Conversions.ToString(ViewState["PersonNavn"]);
                BesvaretAf = Conversions.ToString(ViewState["BesvaretAf"]);
                PersonID = Conversions.ToInteger(ViewState["PersonID"]);
                spurgtID = Conversions.ToInteger(ViewState["spurgtID"]);
                FirstTime = Conversions.ToBoolean(ViewState["FirstTime"]);
            }
        }

        private void btnÆndringer_Click(object sender, EventArgs e)
        {
            txtBladMmPris.Visible = true;
            txtBladMmRabat.Visible = true;
            txtBladFarvetillæg.Visible = true;
            txtBladFarveRabat.Visible = true;
            lblBemærkning.Visible = true;
            txtBemærkning.Visible = true;
            btnFortryd.Visible = true;
            btnOpdater.Visible = true;
            btnGodkend.Visible = false;
            btnÆndringer.Visible = false;
        }

        private void btnFortryd_Click(object sender, EventArgs e)
        {
            txtBladMmPris.Visible = false;
            txtBladMmRabat.Visible = false;
            txtBladFarvetillæg.Visible = false;
            txtBladFarveRabat.Visible = false;
            lblBemærkning.Visible = false;
            txtBemærkning.Visible = false;
            btnFortryd.Visible = false;
            btnOpdater.Visible = false;
            btnGodkend.Visible = true;
            btnÆndringer.Visible = true;
        }

        private void btnGodkend_Click(object sender, EventArgs e)
        {
            txtBladMmPris.Text = txtDLUMmpris.Text;
            txtBladMmRabat.Text = txtDLUMmRabat.Text;
            txtBladFarvetillæg.Text = txtDLUFarvetillæg.Text;
            txtBladFarveRabat.Text = txtDLUFarveRabat.Text;
            OpdaterData();
        }

        private string SqlConv(string Tal)
        {
            return Strings.Replace(Tal, ",", ".");
        }

        private void btnOpdater_Click(object sender, EventArgs e)
        {
            OpdaterData();
        }

        private void OpdaterData()
        {
            try
            {
                SqlComm.CommandText = "UPDATE tblWEBForespørgselLinjer SET BesvaretAf = " + PersonID + ", BladMmPris = " + SqlConv(txtBladMmPris.Text) + ", BladMmRabat = " + SqlConv(txtBladMmRabat.Text) + ", BladFarveTillæg = " + SqlConv(txtBladFarvetillæg.Text) + ", BladFarveRabat = " + SqlConv(txtBladFarveRabat.Text) + ", BladBemærkning = '" + txtBemærkning.Text + "' WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + BladID + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                if (FirstTime)
                {
                    SqlComm.CommandText = "UPDATE tblWEBForespørgsel SET AntalSvar = AntalSvar + 1 WHERE (ForespørgselID = " + spurgtID + ")";
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
            }

            Response.Redirect("Afslut.htm");
        }
    }
}