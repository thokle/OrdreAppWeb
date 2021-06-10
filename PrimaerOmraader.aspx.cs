﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OrdreApp
{
    public partial class PrimPost : Page
    {
        public PrimPost()
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
            Dst = new dst();
            ((System.ComponentModel.ISupportInitialize)Dst).BeginInit();
            // 
            // SqlConn
            // 
            SqlConn.ConnectionString = "data source=AGETOR;initial catalog=dimpSQL;password=hydeliFyt12;persist s" + "ecurity info=True;user id=sa;workstation id=DDDIMP;packet size=4096";
            // 
            // SqlComm
            // 
            SqlComm.Connection = SqlConn;
            // 
            // da
            // 
            da.SelectCommand = SqlSelectCommand1;
            da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] { new System.Data.Common.DataTableMapping("Table", "tblDækning", new System.Data.Common.DataColumnMapping[] { new System.Data.Common.DataColumnMapping("PostNr", "PostNr"), new System.Data.Common.DataColumnMapping("Byen", "Byen") }) });
            // 
            // SqlSelectCommand1
            // 
            SqlSelectCommand1.CommandText = "SELECT tblDækning.PostNr, tblHusstande.Byen, tblDækning.BladId, tblHusstande.ById" + " FROM tblDækning INNER JOIN tblPostNr ON tblDækning.PostNr = tblPostNr.PostNr IN" + "NER JOIN tblHusstande ON tblPostNr.ById = tblHusstande.ById WHERE (tblDækning.Bl" + "adId = @BladID)";


            SqlSelectCommand1.Connection = SqlConn;
            SqlSelectCommand1.Parameters.Add(new SqlParameter("@BladID", SqlDbType.Int, 4, "BladId"));
            // 
            // Dst
            // 
            Dst.DataSetName = "dst";
            Dst.Locale = new System.Globalization.CultureInfo("da-DK");
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
        protected int BladID;
        private SqlDataReader dr;
        protected SqlDataAdapter da;
        protected SqlCommand SqlSelectCommand1;
        protected dst Dst;

        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int counter;
                var checkSum = default(int);
                BladID = Conversions.ToInteger(Request.QueryString["BladID"]);
                SqlComm.CommandText = "SELECT Navn FROM tblBlade WHERE (BladId = " + BladID + ")";
                SqlConn.Open();
                dr = SqlComm.ExecuteReader();
                dr.Read();
                BladNavn = dr["Navn"].ToString();
                dr.Close();
                SqlConn.Close();
                var loopTo = Strings.Len(BladNavn);
                for (counter = 1; counter <= loopTo; counter++)
                    checkSum = (checkSum + Strings.Asc(Strings.Mid(BladNavn, counter, 1))) % 255;
                if (checkSum != Conversions.ToDouble(Request.QueryString["Chk"]))
                {
                    Server.Transfer("CheckSumError.htm");
                }

                SekLink.NavigateUrl = "SekundaerOmraader.aspx?BladID=" + BladID + "&chk=" + checkSum;
                ViewState["BladNavn"] = BladNavn;
                ViewState["BladID"] = BladID;
                ShowOrdrer();
            }
            else
            {
                BladNavn = Conversions.ToString(ViewState["BladNavn"]);
                BladID = Conversions.ToInteger(ViewState["BladID"]);
            }
        }

        private void ShowOrdrer()
        {
            da.SelectCommand.Parameters["@BladID"].Value = BladID;
            da.Fill(Dst);
            DataBind();
        }

        private void grdPrim_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                SqlComm.CommandText = "DELETE FROM tblDækning WHERE (BladID=" + BladID + ") AND (PostNr=" + Conversions.ToInteger(e.Item.Cells[0].Text) + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                ShowOrdrer();
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                Server.Transfer("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }
        }

        private void btnAddPostNr_Click(object sender, EventArgs e)
        {
            try
            {
                SqlComm.CommandText = "INSERT INTO tblDækning (BladID, PostNr) VALUES (" + BladID + "," + Conversions.ToInteger(txtPostPrim.Text) + ")";
                SqlConn.Open();
                SqlComm.ExecuteNonQuery();
                ShowOrdrer();
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                Server.Transfer("FejlOpdater.htm");
            }
            finally
            {
                SqlConn.Close();
            }
        }
    }
}