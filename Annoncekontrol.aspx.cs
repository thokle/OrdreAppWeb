using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class Annoncekontrol : Page
    {
        public Annoncekontrol()
        {
            base.Init += Page_Init;
            base.Load += Page_Load;
        }

        #region  Web Form Designer Generated Code 

        // This call is required by the Web Form Designer.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SqlConn = new SqlConnection();
            SqlComm = new SqlCommand();
            da = new SqlDataAdapter();
            SqlSelectCommand1 = new SqlCommand();
            SqlConnection1 = new SqlConnection();
            Dst = new dst();
            ((System.ComponentModel.ISupportInitialize)Dst).BeginInit();
            // 
            // SqlConn
            // 
            SqlConn.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096";
            // 
            // SqlComm
            // 
            SqlComm.Connection = SqlConn;
            // 
            // da
            // 
            da.SelectCommand = SqlSelectCommand1;
            da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", "tblMedieplanLinjer", new System.Data.Common.DataColumnMapping[] { new System.Data.Common.DataColumnMapping("OrdreNr", "OrdreNr"), new System.Data.Common.DataColumnMapping("SlutVist", "SlutVist"), new System.Data.Common.DataColumnMapping("Annoncør", "Annoncør"), new System.Data.Common.DataColumnMapping("Betegnelse", "Betegnelse"), new System.Data.Common.DataColumnMapping("Format", "Format"), new System.Data.Common.DataColumnMapping("AntalFarver", "AntalFarver"), new System.Data.Common.DataColumnMapping("FejlID", "FejlID"), new System.Data.Common.DataColumnMapping("EnOrdre", "EnOrdre"), new System.Data.Common.DataColumnMapping("Kulør", "Kulør"), new System.Data.Common.DataColumnMapping("AnnoncørID", "AnnoncørID"), new System.Data.Common.DataColumnMapping("mmType", "mmType"), new System.Data.Common.DataColumnMapping("BladID", "BladID"), new System.Data.Common.DataColumnMapping("DPKulørID", "DPKulørID"), new System.Data.Common.DataColumnMapping("Version", "Version"), new System.Data.Common.DataColumnMapping("MedieplanNr", "MedieplanNr"), new System.Data.Common.DataColumnMapping("EXPR2", "EXPR2"), new System.Data.Common.DataColumnMapping("SidePlacering", "SidePlacering") }) });
            // 
            // SqlSelectCommand1
            // 
            SqlSelectCommand1.CommandText = "SELECT tblMedieplan.MedieplanNr AS OrdreNr, CASE WHEN tblAnnoncekontrol.ErKontrolleret IS NULL THEN 0 ELSE tblAnnoncekontrol.ErKontrolleret END AS SlutVist, NavisionContact.Name AS Annoncør, tblPlacering.Betegnelse, LTRIM(STR(tblMedieplan.Format1)) + 'x' + LTRIM(STR(tblMedieplan.Format2)) AS Format, tblMedieplan.AntalFarver, CASE WHEN tblAnnoncekontrol.Fejlkode IS NULL THEN 0 ELSE tblAnnoncekontrol.Fejlkode END AS FejlID, tblMedieplan.Fakturering AS EnOrdre, tblDPKulør.Kulør, NavisionContact.No_ AS AnnoncørID, tblPlacering.PlaceringID AS mmType, tblMedieplanLinjer.UgeavisID AS BladID, tblDPKulør.DPKulørID, tblMedieplan.Version, tblMedieplanLinjer.MedieplanNr, tblMedieplanLinjer.Version AS EXPR2, tblAnnoncekontrol.SidePlacering FROM tblMedieplanLinjer INNER JOIN tblDPKulør INNER JOIN NavisionContact INNER JOIN tblPlacering INNER JOIN tblMedieplan ON tblPlacering.PlaceringID = tblMedieplan.PlaceringID ON NavisionContact.No_ = tblMedieplan.AnnoncørNo_ ON tblDPKulør.DPKulørID = tblMedieplan.DPKulørID INNER JOIN tblMedieplanNr ON tblMedieplan.MedieplanNr = tblMedieplanNr.MedieplanNr AND tblMedieplan.Version = tblMedieplanNr.AktivVersion ON tblMedieplanLinjer.MedieplanNr = tblMedieplan.MedieplanNr AND tblMedieplanLinjer.Version = tblMedieplan.Version LEFT OUTER JOIN tblAnnoncekontrol ON tblMedieplanLinjer.MedieplanNr = tblAnnoncekontrol.MedieplanNr AND tblMedieplanLinjer.UgeavisID = tblAnnoncekontrol.UgeavisID WHERE (tblMedieplan.Status = 3 OR tblMedieplan.Status = 5 OR tblMedieplan.Status = 6 OR tblMedieplan.Status = 99) AND (tblMedieplan.IndrykningsUge = @Uge) AND (tblMedieplanLinjer.UgeavisID = @BladID) AND (tblMedieplan.IndrykningsÅr = @År) ORDER BY OrdreNr";
            SqlSelectCommand1.Connection = SqlConnection1;
            SqlSelectCommand1.Parameters.Add(new SqlParameter("@Uge", SqlDbType.TinyInt, 1, "IndrykningsUge"));
            SqlSelectCommand1.Parameters.Add(new SqlParameter("@BladID", SqlDbType.Int, 4, "BladID"));
            SqlSelectCommand1.Parameters.Add(new SqlParameter("@År", SqlDbType.Int, 4, "IndrykningsÅr"));
            // 
            // SqlConnection1
            // 
            SqlConnection1.ConnectionString = "data source=DLU02;initial catalog=DiMPdotNet;password=lp4DLU;persist security info=True;user id=LocalPlanner;workstation id=DDDIMP;packet size=4096";
            // 
            // Dst
            // 
            Dst.DataSetName = "dst";
            Dst.Locale = new CultureInfo("da-DK");
            Dst.Namespace = "http://www.tempuri.org/dst.xsd";
            ((System.ComponentModel.ISupportInitialize)Dst).EndInit();
        }

        private void Page_Init(object sender, EventArgs e)
        {
            // CODEGEN: This method call is required by the Web Form Designer
            // Do not modify it using the code editor.
            InitializeComponent();
        }

        #endregion
        protected string BladNavn;
        protected SqlConnection SqlConn;
        protected SqlCommand SqlComm;
        protected int Uge;
        protected int BladID;
        protected int År;
        protected int QueryChk;
        protected string[] FejlTekst = new string[10];
        private string[] query = new string[3];
        private SqlDataReader dr;
        protected SqlDataAdapter da;
        protected HyperLink BemLink;
        protected dst Dst;
        protected string eMail = "";
        protected SqlConnection SqlConnection1;
        protected SqlCommand SqlSelectCommand1;
        protected int kontrolleretAfDLU = 0;
        protected int FejlIAnnonce = 0;

        private void Page_Load(object sender, EventArgs e)
        {
            FejlTekst[0] = "Ingen valgt";
            FejlTekst[1] = "Bestilt efter deadline";
            FejlTekst[2] = "Ordre ikke modtaget";
            FejlTekst[3] = "Glemt annonce";
            FejlTekst[4] = "DLU har fremsendt forkert materiale";
            FejlTekst[5] = "Vi har indrykket forkert materiale";
            FejlTekst[6] = "Forkert farve";
            FejlTekst[7] = "Forkert placering";
            FejlTekst[8] = "Forkert annonce format";
            FejlTekst[9] = "Glemt farve";
            if (!IsPostBack)
            {
                var CheckSum = default(int);
                int counter;
                int DenneUge;
                query = Strings.Split(Request.QueryString["Query"], "*");
                BladID = Conversions.ToInteger(query[0]);
                Uge = Conversions.ToInteger(query[1]);
                eMail = query[2];
                QueryChk = Conversions.ToInteger(query[3]);
                SqlComm.CommandText = "SELECT Navn FROM tblBladStamdata WHERE (BladID = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                if (QueryChk == 999)
                {
                    kontrolleretAfDLU = 1;
                }
                else
                {
                    var loopTo = Strings.Len(BladNavn);
                    for (counter = 1; counter <= loopTo; counter++)
                        CheckSum = (CheckSum + Uge + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                    if (CheckSum != QueryChk)
                    {
                        Server.Transfer("CheckSumError.htm?" + CheckSum.ToString());
                    }
                }

                dr.Close();
                SqlConn.Close();
                var myCI = new CultureInfo("da-DK");
                var myCal = myCI.Calendar;
                var myCWR = myCI.DateTimeFormat.CalendarWeekRule;
                var myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
                DenneUge = myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW);
                // If DenneUge < Uge Then
                // År = Date.Now.Year - 1
                // Else
                År = DateTime.Now.Year;
                // End If
                ViewState["BladNavn"] = BladNavn;
                ViewState["Uge"] = Uge;
                ViewState["År"] = År;
                ViewState["BladID"] = BladID;
                ViewState["Email"] = eMail;
                ViewState["DLU"] = kontrolleretAfDLU;
                ViewState["QueryChk"] = QueryChk;
                ViewState["FejlIAnnonce"] = FejlIAnnonce;
                ShowOrdrer();
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                Uge = Conversions.ToInteger(ViewState["Uge"]);
                År = Conversions.ToInteger(ViewState["År"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
                eMail = Conversions.ToString(ViewState["Email"]);
                kontrolleretAfDLU = Conversions.ToInteger(ViewState["DLU"]);
                QueryChk = Conversions.ToInteger(ViewState["QueryChk"]);
                FejlIAnnonce = Conversions.ToInteger(ViewState["FejlIAnnonce"]);
            }
        }

        private void ShowOrdrer()
        {
            da.SelectCommand.Parameters["@BladID"].Value = BladID;
            da.SelectCommand.Parameters["@Uge"].Value = Uge;
            da.SelectCommand.Parameters["@År"].Value = År;
            da.Fill(Dst);
            DataBind();
        }

        private void grdOrdrer_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int OrdreID = Conversions.ToInteger(e.Item.Cells[8].Text);
            int ErrorID = 0;
            int ManglerKontrol;
            int AntalFejl;
            int EnOrdre;
            int Status;
            var SidePlacering = default(int);
            if (e.CommandName == "Send")
            {
                try
                {
                    if (grdOrdrer.EditItemIndex > -1)
                    {
                        SidePlacering = Conversions.ToInteger(((TextBox)e.Item.Cells[6].Controls[1]).Text);
                        ErrorID = Conversions.ToInteger(((DropDownList)e.Item.Cells[7].Controls[1]).SelectedItem.Value);
                        EnOrdre = Conversions.ToInteger(e.Item.Cells[9].Text);
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("FejlKonverter.htm");
                }

                if (FejlIAnnonce == 1)
                {
                    if (ErrorID == 0)
                    {
                        Response.Redirect("GlemtAtAngiveFejl.htm");
                    }
                }
                else if (FejlIAnnonce == 2)
                {
                    if (SidePlacering == 0)
                    {
                        Response.Redirect("GlemtAtAngiveSidePlacering.htm");
                    }
                }
                else
                {
                    Response.Redirect("FejlOpdater.htm");
                }

                try
                {
                    SqlConn.Open();
                    SqlComm.CommandText = "DELETE FROM tblAnnoncekontrol WHERE (MedieplanNr = " + OrdreID + ") AND (UgeavisID = " + BladID + ")";
                    SqlComm.ExecuteNonQuery();
                    SqlComm.CommandText = "INSERT INTO tblAnnoncekontrol (MedieplanNr, UgeavisID, ErKontrolleret, " + "KontrolTidspunkt, KontrollørEmail, KontrolleretAfDLU, Fejlkode, SidePlacering) " + "VALUES (" + OrdreID + "," + BladID + ", 1, " + "GETDATE(),'" + eMail + "'," + kontrolleretAfDLU + "," + ErrorID + "," + SidePlacering + ")";


                    SqlComm.ExecuteNonQuery();
                    SqlComm.CommandText = "SELECT DISTINCT COUNT(tblMedieplanLinjer.UgeavisID) AS ManglerKontrol FROM " + "tblMedieplanNr INNER JOIN tblMedieplanLinjer ON tblMedieplanNr.MedieplanNr = tblMedieplanLinjer.MedieplanNr " + "AND tblMedieplanNr.AktivVersion = tblMedieplanLinjer.Version LEFT OUTER JOIN " + "tblAnnoncekontrol ON tblMedieplanLinjer.MedieplanNr = tblAnnoncekontrol.MedieplanNr AND " + "tblMedieplanLinjer.UgeavisID = tblAnnoncekontrol.UgeavisID WHERE " + "(tblMedieplanNr.MedieplanNr = " + OrdreID + ") AND " + "(tblAnnoncekontrol.ErKontrolleret IS NULL OR tblAnnoncekontrol.ErKontrolleret = 0)";





                    ManglerKontrol = Conversions.ToInteger(SqlComm.ExecuteScalar());
                    if (ManglerKontrol == 0)
                    {
                        SqlComm.CommandText = "SELECT COUNT(MedieplanNr) AS AntalFejl FROM tblAnnoncekontrol " + "WHERE(Fejlkode > 0) And (MedieplanNr = " + OrdreID + ")";
                        AntalFejl = Conversions.ToInteger(SqlComm.ExecuteScalar());
                        if (AntalFejl == 0)
                        {
                            SqlComm.CommandText = "SELECT tblMedieplan.Fakturering FROM tblMedieplan INNER JOIN tblMedieplanNr ON " + "tblMedieplan.MedieplanNr = tblMedieplanNr.MedieplanNr AND tblMedieplan.Version = tblMedieplanNr.AktivVersion " + "WHERE(tblMedieplanNr.MedieplanNr = " + OrdreID + ")";

                            EnOrdre = Conversions.ToInteger(SqlComm.ExecuteScalar());
                            if (EnOrdre == 1)
                            {
                                Status = 6;
                            }
                            else
                            {
                                Status = 99;
                            }
                        }
                        else
                        {
                            Status = 5;
                        }

                        SqlComm.CommandText = "UPDATE tblMedieplan SET Status = " + Status + " FROM tblMedieplan INNER JOIN " + "tblMedieplanNr ON tblMedieplan.MedieplanNr = tblMedieplanNr.MedieplanNr AND tblMedieplan.Version = " + "tblMedieplanNr.AktivVersion WHERE (tblMedieplan.MedieplanNr = " + OrdreID + ")";

                        SqlComm.ExecuteNonQuery();
                        SqlComm.CommandText = "UPDATE tblMedieplanNr SET Status = " + Status + " WHERE(MedieplanNr = " + OrdreID + ")";
                        SqlComm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    SqlConn.Close();
                    Response.Redirect("FejlOpdater.htm");
                }
                finally
                {
                    SqlConn.Close();
                }

                if (ErrorID == 7)
                {
                    Response.Redirect("ForkertPlacering.aspx" + Request.Url.Query + "*" + OrdreID.ToString());
                }

                grdOrdrer.EditItemIndex = -1;
                ViewState["FejlIAnnonce"] = 0;
                ShowOrdrer();
            }
            else
            {
                if (e.CommandName == "Ok")
                {
                    try
                    {
                        SqlConn.Open();
                        SqlComm.CommandText = "UPDATE tblAnnoncekontrol SET ErKontrolleret = 0  WHERE (MedieplanNr = " + OrdreID + ") AND (UgeavisID = " + BladID + ")";
                        SqlComm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        SqlConn.Close();
                        Response.Redirect("FejlEditer.htm");
                    }
                    finally
                    {
                        SqlConn.Close();
                    }
                }
                else if (e.CommandName == "Ja")
                {
                    FejlIAnnonce = 2;
                }
                else if (e.CommandName == "Nej")
                {
                    FejlIAnnonce = 1;
                }
                else
                {
                    FejlIAnnonce = 0;
                }

                grdOrdrer.EditItemIndex = e.Item.ItemIndex;
                ViewState["FejlIAnnonce"] = FejlIAnnonce;
                ShowOrdrer();
            }
        }
    }
}