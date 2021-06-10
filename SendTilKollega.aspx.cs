using System;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class SendTilKollega : Page
    {
        public SendTilKollega()
        {
            base.Init += Page_Init;

            #endregion

            base.Load += Page_Load;
        }

        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int BladID;
        protected int QueryChk;
        protected int spurgtID;
        protected string eMail;
        protected SqlDataReader dr;
        protected string BladNavn;
        protected string EmailTilbud;
        protected string[] query = new string[4];
        protected string[] emails;
        protected int PersonID;
        protected string PersonNavn;

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
                int i;
                int fundne;
                if (Request.QueryString.Count > 1)
                {
                    BladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                    spurgtID = Conversions.ToInteger(Request.QueryString["ID"]);
                    QueryChk = Conversions.ToInteger(Request.QueryString["Chk"]);
                    PersonID = Conversions.ToInteger(Request.QueryString["PID"]);
                }
                else
                {
                    query = Strings.Split(Request.QueryString["Query"], "*");
                    BladID = Conversions.ToInteger(query[0]);
                    QueryChk = Conversions.ToInteger(query[1]);
                    spurgtID = Conversions.ToInteger(query[2]);
                    PersonID = Conversions.ToInteger(query[3]);
                }

                if (PersonID == 0)
                {
                    Server.Transfer("NoeMail.htm");
                }

                SqlComm.CommandText = "SELECT Navn, PrisforespørgselEmails FROM tblBladStamdata WHERE (BladID = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                EmailTilbud = dr["PrisforespørgselEmails"].ToString();
                dr.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    CheckSum = (CheckSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (CheckSum != QueryChk)
                {
                    Server.Transfer("CheckSumError.htm");
                }

                SqlComm.CommandText = "SELECT PersonNavn, eMail FROM tblWEBeMails WHERE (PersonID=" + PersonID + ")";
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    PersonNavn = dr.GetString(0);
                    eMail = dr.GetString(1);
                }

                if (string.IsNullOrEmpty(PersonNavn))
                {
                    Server.Transfer("IndtastNavn.aspx" + Request.Url.Query);
                }

                dr.Close();

                // emails = Split(EmailTilbud, ";")
                // fundne = 0
                // For i = 0 To UBound(emails)
                // If eMail <> emails(i) Then
                // fundne = fundne + 1
                // Select Case fundne
                // Case 1
                // txtEmail1.Text = emails(i)
                // txtEmail1_TextChanged(New System.Object(), New System.EventArgs())
                // Case 2
                // txtEmail2.Text = emails(i)
                // txtEmail2_TextChanged(New System.Object(), New System.EventArgs())
                // Case 3
                // txtEmail3.Text = emails(i)
                // txtEmail3_TextChanged(New System.Object(), New System.EventArgs())
                // Case 4
                // txtEmail4.Text = emails(i)
                // txtEmail4_TextChanged(New System.Object(), New System.EventArgs())
                // End Select
                // End If
                // Next i
                ViewState["BladNavn"] = BladNavn;
                ViewState["BladID"] = BladID;
                ViewState["PersonNavn"] = PersonNavn;
                ViewState["PersonID"] = PersonID;
                ViewState["spurgtID"] = spurgtID;
                ViewState["eMail"] = eMail;
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
                PersonNavn = Conversions.ToString(ViewState["PersonNavn"]);
                PersonID = Conversions.ToInteger(ViewState["PersonID"]);
                spurgtID = Conversions.ToInteger(ViewState["spurgtID"]);
                eMail = Conversions.ToString(ViewState["eMail"]);
            }
        }

        private void btnAfslut_Click(object sender, EventArgs e)
        {
            Response.Redirect("LukBrowseren.htm");
        }

        private void txtEmail1_TextChanged(object sender, EventArgs e)
        {
            regEx1.Validate();
            if (!string.IsNullOrEmpty(txtEmail1.Text) & regEx1.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail2.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail2.Enabled = false;
            }
        }

        private void txtEmail2_TextChanged(object sender, EventArgs e)
        {
            regEx2.Validate();
            if (!string.IsNullOrEmpty(txtEmail2.Text) & regEx2.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail3.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail3.Enabled = false;
            }
        }

        private void txtEmail3_TextChanged(object sender, EventArgs e)
        {
            regEx3.Validate();
            if (!string.IsNullOrEmpty(txtEmail3.Text) & regEx3.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail4.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail4.Enabled = false;
            }
        }

        private void txtEmail4_TextChanged(object sender, EventArgs e)
        {
            regEx4.Validate();
            if (!string.IsNullOrEmpty(txtEmail4.Text) & regEx4.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail5.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail5.Enabled = false;
            }
        }

        private void txtEmail5_TextChanged(object sender, EventArgs e)
        {
            regEx5.Validate();
            if (!string.IsNullOrEmpty(txtEmail5.Text) & regEx5.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail6.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail6.Enabled = false;
            }
        }

        private void txtEmail6_TextChanged(object sender, EventArgs e)
        {
            regEx6.Validate();
            if (!string.IsNullOrEmpty(txtEmail6.Text) & regEx6.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail7.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail7.Enabled = false;
            }
        }

        private void txtEmail7_TextChanged(object sender, EventArgs e)
        {
            regEx7.Validate();
            if (!string.IsNullOrEmpty(txtEmail7.Text) & regEx7.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail8.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail8.Enabled = false;
            }
        }

        private void txtEmail8_TextChanged(object sender, EventArgs e)
        {
            regEx8.Validate();
            if (!string.IsNullOrEmpty(txtEmail8.Text) & regEx8.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail9.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail9.Enabled = false;
            }
        }

        private void txtEmail9_TextChanged(object sender, EventArgs e)
        {
            regEx9.Validate();
            if (!string.IsNullOrEmpty(txtEmail9.Text) & regEx9.IsValid)
            {
                btnSend.Enabled = true;
                txtEmail10.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
                txtEmail10.Enabled = false;
            }
        }

        private void txtEmail10_TextChanged(object sender, EventArgs e)
        {
            regEx10.Validate();
            if (!string.IsNullOrEmpty(txtEmail10.Text) & regEx10.IsValid)
            {
                btnSend.Enabled = true;
            }
            else
            {
                btnSend.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Sendekode her
                var eMailMSG = new System.Net.Mail.SmtpClient();
                string sendHTML;
                string Annoncør, MVH, FormatString, Farver, Placering, Mediebureau, AntalIndrykn, Bemærkning;
                string BesvaretAf = "";
                string BladMmPris, BladMmRabat, BladFarvetillæg, BladFarveRabat, BladBemærkning;
                double indFarve;
                int PlaceringUB;
                int i;
                SqlComm.CommandText = "SELECT tblWEBeMails.PersonNavn, tblWEBeMails.eMail FROM tblWEBForespørgselLinjer INNER JOIN tblWEBeMails ON tblWEBForespørgselLinjer.BesvaretAf = tblWEBeMails.PersonID WHERE (tblWEBForespørgselLinjer.ForespørgselID = " + spurgtID + ") AND (tblWEBForespørgselLinjer.BladID = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                if (dr.Read())
                {
                    BesvaretAf = dr.GetString(0);
                }

                dr.Close();
                // Hent medieplanhoved
                // SqlComm.CommandText = "SELECT tblAnnoncører.Annoncør, tblBrugere.Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblMmTyper.Betegnelse, tblWEBForespørgsel.Mediebureau, tblWEBForespørgsel.AntalIndrykninger, tblWEBForespørgsel.Bemærkning FROM tblWEBForespørgsel INNER JOIN tblAnnoncører ON tblWEBForespørgsel.AnnoncørID = tblAnnoncører.AnnoncørID INNER JOIN tblBrugere ON tblWEBForespørgsel.KonsulentID = tblBrugere.BrugerID INNER JOIN tblMmTyper ON tblWEBForespørgsel.Placering = tblMmTyper.mmType WHERE(tblWEBForespørgsel.ForespørgselID = " & spurgtID & ")"
                SqlComm.CommandText = "SELECT NavisionContact.Name, Salesperson.Name AS Navn, tblWEBForespørgsel.Format, tblWEBForespørgsel.AntalFarver, tblPlacering.Betegnelse, tblWEBForespørgsel.Mediebureau, tblWEBForespørgsel.AntalIndrykninger, tblWEBForespørgsel.Bemærkning FROM tblWEBForespørgsel INNER JOIN NavisionContact ON tblWEBForespørgsel.AnnoncørNo_ = NavisionContact.No_ INNER JOIN tblPlacering ON tblWEBForespørgsel.PlaceringID = tblPlacering.PlaceringID INNER JOIN Salesperson ON tblWEBForespørgsel.KonsulentCode = Salesperson.Code WHERE (tblWEBForespørgsel.ForespørgselID = " + spurgtID + ")";
                dr = SqlComm.ExecuteReader();
                dr.Read();
                Annoncør = dr.GetString(0);
                MVH = "Med venlig hilsen<br>" + dr.GetString(1);
                FormatString = dr.GetString(2);
                Farver = dr.GetByte(3).ToString();
                Placering = dr.GetString(4);
                Mediebureau = dr.GetString(5);
                AntalIndrykn = dr.GetByte(6).ToString();
                Bemærkning = dr.GetString(7);
                dr.Close();

                // Hent prisforeslag
                SqlComm.CommandText = "SELECT PlaceringUB, BladMmPris, BladMmRabat, BladFarveTillæg, BladFarveRabat, BladBemærkning FROM tblWEBForespørgselLinjer WHERE (ForespørgselID = " + spurgtID + ") AND (BladID = " + BladID + ")";
                dr = SqlComm.ExecuteReader();
                dr.Read();
                PlaceringUB = dr.GetByte(0);
                BladMmPris = Strings.Format(dr.GetDecimal(1), "###,##0.00");
                BladMmRabat = dr.GetDouble(2).ToString();
                indFarve = (double)dr.GetDecimal(3);
                if (indFarve < 20d)
                {
                    BladFarvetillæg = Strings.Format(indFarve, "###,##0.00");
                }
                else
                {
                    BladFarvetillæg = Strings.Format(indFarve, "#.###");
                }

                BladFarveRabat = dr.GetDouble(4).ToString();
                BladBemærkning = dr.GetString(5);
                dr.Close();
                // sendHTML = "<HTML><HEAD><TITLE>Afgivet tilbud.</TITLE><META http-equiv=" + Chr(34) + "Content-Type" + Chr(34) + " content=" + Chr(34) + "text/html; charset=windows-1250" + Chr(34) + "></HEAD><BODY>"
                // sendHTML = sendHTML + "<B>Vi har afgivet følgende tilbud til DLU.<BR>"
                // sendHTML = "<B>Vi har afgivet følgende tilbud til DLU.<BR>"
                // sendHTML = sendHTML + "Tilbuddet er udfyldt af " + BesvaretAf + "</B><BR><BR>"
                sendHTML = "Vi har afgivet følgende tilbud til DLU." + Constants.vbCrLf;
                sendHTML = sendHTML + "Tilbuddet er udfyldt af " + BesvaretAf + Constants.vbCrLf + Constants.vbCrLf;
                sendHTML = sendHTML + "Annoncør: " + Annoncør + Constants.vbCrLf;
                sendHTML = sendHTML + "Mediebureau: " + Mediebureau + Constants.vbCrLf;
                sendHTML = sendHTML + "Format: " + FormatString + Constants.vbCrLf;
                sendHTML = sendHTML + "Farver: " + Farver + Constants.vbCrLf;
                sendHTML = sendHTML + "Placering: " + Placering + Constants.vbCrLf;
                sendHTML = sendHTML + "Antal indrykninger: " + AntalIndrykn + Constants.vbCrLf;
                sendHTML = sendHTML + Constants.vbCrLf;
                sendHTML = sendHTML + "Bemærkninger: " + Bemærkning + Constants.vbCrLf + Constants.vbCrLf + BladBemærkning + Constants.vbCrLf + Constants.vbCrLf + Constants.vbCrLf;
                sendHTML = sendHTML + "Tilbud:" + Constants.vbCrLf;
                sendHTML = sendHTML + "kr./mm.: " + BladMmPris + Constants.vbCrLf;
                sendHTML = sendHTML + "mm. rabat: " + BladMmRabat + Constants.vbCrLf;
                sendHTML = sendHTML + "farvetillæg: " + BladFarvetillæg + Constants.vbCrLf;
                sendHTML = sendHTML + "farve rabat: " + BladFarveRabat + Constants.vbCrLf;
                // sendHTML = sendHTML + "<TABLE cellspacing=" + Chr(34) + "0" + Chr(34) + " cellpadding=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "90%" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "15%" + Chr(34) + ">Annoncør</TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "85%" + Chr(34) + ">" + Annoncør + "</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD>Mediebureau</TD><TD>" + Mediebureau + "</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD>Format</TD><TD>" + FormatString + "</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD>Farver</TD><TD>" + Farver + "</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD>Placering</TD><TD>" + Placering + "</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD>Antal indrykn.</TD><TD>" + AntalIndrykn + "</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + "><TD><BR></TD><TD></TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD>Bemærkninger</TD><TD>" + Bemærkning + "<br><br>" + BladBemærkning + "</TD></TR>"
                // sendHTML = sendHTML + "</TABLE><BR><BR>"
                // sendHTML = sendHTML + "<TABLE cellpadding=" + Chr(34) + "0" + Chr(34) + " cellspacing=" + Chr(34) + "0" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "60%" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "32%" + Chr(34) + "><B>Tilbud</B></TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>kr./mm</B></TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>rabat</B></TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>farvetillæg</B></TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + "><B>rabat</B></TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + "><TD></TD>"
                // sendHTML = sendHTML + "<TD>" + BladMmPris + "</TD>"
                // sendHTML = sendHTML + "<TD>" + BladMmRabat + "</TD>"
                // sendHTML = sendHTML + "<TD>" + BladFarvetillæg + "</TD>"
                // sendHTML = sendHTML + "<TD>" + BladFarveRabat + "</TD></TR></TABLE><BR>"
                // sendHTML = sendHTML + "<B>Der ydes placering u/b</B>"
                // sendHTML = sendHTML + "<TABLE cellspacing=" + Chr(34) + "0" + Chr(34) + " cellpadding=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "60%" + Chr(34) + " border=" + Chr(34) + "1" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "32%" + Chr(34) + "></TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">side 3,5,7</TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">Høj. side f. midt</TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">Høj. side</TD>"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "17%" + Chr(34) + " align=" + Chr(34) + "middle" + Chr(34) + ">nej</TD></TR>"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + "><TD><br></TD>"
                // While i < PlaceringUB - 1
                // sendHTML = sendHTML + "<TD align=" + Chr(34) + "middle" + Chr(34) + "><br></TD>"
                // i = i + 1
                // End While
                // sendHTML = sendHTML + "<TD align=" + Chr(34) + "middle" + Chr(34) + ">X</TD>"
                // While i < 3
                // sendHTML = sendHTML + "<TD align=" + Chr(34) + "middle" + Chr(34) + "><br></TD>"
                // i = i + 1
                // End While
                // sendHTML = sendHTML + "</TR></TABLE><BR>"
                // sendHTML = sendHTML + "<BR>"
                // sendHTML = sendHTML + "<TABLE cellspacing=" + Chr(34) + "0" + Chr(34) + " cellpadding=" + Chr(34) + "0" + Chr(34) + " width=" + Chr(34) + "90%" + Chr(34) + " border=" + Chr(34) + "0" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TR valign=" + Chr(34) + "top" + Chr(34) + ">"
                // sendHTML = sendHTML + "<TD width=" + Chr(34) + "21%" + Chr(34) + "><B>Vigtigt</B></TD>"
                // sendHTML = sendHTML + "<TD><B>Det er vigtigt, at vi overholder de afgivne priser, hvis vi kontaktes af "
                // sendHTML = sendHTML + "annoncøren eller mediebureauet, når/hvis de kontakter os direkte for at "
                // sendHTML = sendHTML + "forhandle prisen ned.</B></TD></TR></TABLE></BODY></HTML>"
                sendHTML = sendHTML + Constants.vbCrLf + Constants.vbCrLf;
                sendHTML = sendHTML + "Vigtigt!!" + Constants.vbCrLf;
                sendHTML = sendHTML + "Det er vigtigt, at vi overholder de afgivne priser, hvis vi kontaktes af " + Constants.vbCrLf;
                sendHTML = sendHTML + "annoncøren eller mediebureauet, når/hvis de kontakter os direkte for at " + Constants.vbCrLf;
                sendHTML = sendHTML + "forhandle prisen ned.";

                // eMailMSG.Subject = "Vi har afgivet dette tilbud til " + Annoncør
                // eMailMSG.To.Add(txtEmail1.Text)
                // eMailMSG.Body = sendHTML
                // eMailMSG.BodyFormat = System.Net.Mail.
                // SmtpMail.SmtpServer = "192.168.100.44"

                eMailMSG.Host = "10.10.5.12";
                try
                {
                    eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail1.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                }
                catch
                {
                }

                if (!string.IsNullOrEmpty(txtEmail2.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail2.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail3.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail3.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail4.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail4.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail5.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail5.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail6.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail6.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail7.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail7.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail8.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail8.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail9.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail9.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                if (!string.IsNullOrEmpty(txtEmail10.Text))
                {
                    try
                    {
                        eMailMSG.Send("Udsending@delokaleugeaviser.dk", txtEmail10.Text, "Vi har afgivet dette tilbud til " + Annoncør, sendHTML);
                    }
                    catch
                    {
                    }
                }

                Response.Redirect("LukBrowseren.htm");
            }
        }
    }
}