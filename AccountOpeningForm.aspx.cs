using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AjaxControlToolkit;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Microsoft.Win32;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;
using System.Configuration;
using almeezanportal.accountopening_classes;
using System.Threading;
using System.Net.Mail;
using System.Text;
using System.Linq;


public partial class AccountOpeningForm : System.Web.UI.Page
{
    string mystage;
    string _REPORTCNIC;
    clsDBOperation cls = new clsDBOperation();
    Acc_opening acc_opening = new Acc_opening();
    int n;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CalendarExtender1.EndDate = DateTime.Now;
            CalendarExtender2.StartDate = DateTime.Now;
            dob.EndDate = DateTime.Now;

            if (ddloactype.SelectedItem.Text.ToUpper() == "SINGLE")
            {
                panel_nominee_details.Visible = true;
            }

            if (Session["Username"] == null)
            {
                Response.Redirect("~/CentralizedAccountsLogin.aspx");
            }
            lblNameHead.Text = string.Format(Session["Username"].ToString() + Environment.NewLine + "(" + Session["Department"].ToString() + ")");
            panel_minor_account.Visible = false;
            panel_mtpf_ddlist.Visible = false;
            panel_joint_acc_holder.Visible = false;
            //panel_nominee_details.Visible = false;
            panel_kycdetails.Visible = true;
            panel_fatca.Visible = false;
            panel_riskprofileform.Visible = false;
            panel_Operating_Instructions_ddlist.Visible = false;
            btn_submit.Visible = false;
            panel_preview.Visible = false;
            Acc_opening acc = new Acc_opening();

            DataTable dt = new DataTable();
            dt = cls.GetDataTable("select * from Countries");
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "COUNTRY";
            ddlCountry.DataValueField = "COUNTRY_SHORT_NAME";
            ddlCountry.DataBind();
            ddlCountry.SelectedItem.Text = "PAKISTAN";


            ddl_p_country.DataSource = dt;
            ddl_p_country.DataTextField = "COUNTRY";
            ddl_p_country.DataValueField = "COUNTRY_SHORT_NAME";
            ddl_p_country.DataBind();
            ddl_p_country.SelectedItem.Text = "PAKISTAN";



            ddl_pob.DataSource = dt;
            ddl_pob.DataTextField = "COUNTRY";
            ddl_pob.DataValueField = "COUNTRY_SHORT_NAME";
            ddl_pob.DataBind();
            ddl_pob.SelectedItem.Text = "PAKISTAN";



            //////////////////  STP    RELIGION    /////////////////////////////

            DataTable dtReligion = acc.ReligionList();
            ddl_religon.DataSource = dtReligion;
            ddl_religon.DataTextField = "RLG_FULLNAME";
            ddl_religon.DataValueField = "RLG_SHORTNAME";
            ddl_religon.DataBind();
            //ddl_religon.SelectedItem.Text = "Muslim";

            //////////////////  STP   Marital Status    /////////////////////////////

            DataTable dtMaritalStatus = acc.MaritalStatusList();
            ddlMaritalStatus.DataSource = dtMaritalStatus;
            ddlMaritalStatus.DataTextField = "MLS_FULLNAME";
            ddlMaritalStatus.DataValueField = "MLS_SHORTNAME";
            ddlMaritalStatus.DataBind();
            //ddlMaritalStatus.SelectedItem.Text = "Single";

            //////////////////  STP   Account Type List    /////////////////////////////

            DataTable dtAccountTypeList = acc.AccountTypeList();
            ddloactype.DataSource = dtAccountTypeList;
            ddloactype.DataTextField = "ACT_FULLNAME";
            ddloactype.DataValueField = "ACT_SHORTNAME";
            ddloactype.DataBind();
            //ddloactype.SelectedItem.Text = "Single";

            //////////////////  STP   RelationWithPrinciple List    /////////////////////////////

            DataTable dtRelationWithPrinciple = acc.RelationWithPrincipleList();
            ddlRelationWithPrinciple_mnr.DataSource = dtRelationWithPrinciple;
            ddlRelationWithPrinciple_mnr.DataTextField = "RLP_FULLNAME";
            ddlRelationWithPrinciple_mnr.DataValueField = "RLP_SHORTNAME";
            ddlRelationWithPrinciple_mnr.DataBind();
            // ddlRelationWithPrinciple_mnr.SelectedItem.Text = "";

            //DataTable dtRelationWithPrinciple = acc.RelationWithPrincipleList();
            ddlRelationWithPrinciple_J1.DataSource = dtRelationWithPrinciple;
            ddlRelationWithPrinciple_J1.DataTextField = "RLP_FULLNAME";
            ddlRelationWithPrinciple_J1.DataValueField = "RLP_SHORTNAME";
            ddlRelationWithPrinciple_J1.DataBind();

            ddlRelationWithPrinciple_J2.DataSource = dtRelationWithPrinciple;
            ddlRelationWithPrinciple_J2.DataTextField = "RLP_FULLNAME";
            ddlRelationWithPrinciple_J2.DataValueField = "RLP_SHORTNAME";
            ddlRelationWithPrinciple_J2.DataBind();

            ddlRelationWithPrinciple_N3.DataSource = dtRelationWithPrinciple;
            ddlRelationWithPrinciple_N3.DataTextField = "RLP_FULLNAME";
            ddlRelationWithPrinciple_N3.DataValueField = "RLP_SHORTNAME";
            ddlRelationWithPrinciple_N3.DataBind();

            ddlRelationWithPrinciple_N2.DataSource = dtRelationWithPrinciple;
            ddlRelationWithPrinciple_N2.DataTextField = "RLP_FULLNAME";
            ddlRelationWithPrinciple_N2.DataValueField = "RLP_SHORTNAME";
            ddlRelationWithPrinciple_N2.DataBind();

            ddlRelationWithPrinciple_N1.DataSource = dtRelationWithPrinciple;
            ddlRelationWithPrinciple_N1.DataTextField = "RLP_FULLNAME";
            ddlRelationWithPrinciple_N1.DataValueField = "RLP_SHORTNAME";
            ddlRelationWithPrinciple_N1.DataBind();

           // ddl_kyc_act_quest_relation

             ddl_kyc_act_quest_relation.DataSource = dtRelationWithPrinciple;
             ddl_kyc_act_quest_relation.DataTextField = "RLP_FULLNAME";
             ddl_kyc_act_quest_relation.DataValueField = "RLP_SHORTNAME";
             ddl_kyc_act_quest_relation.DataBind();

            //////////////////  STP   MTPF Allocation Scheme List    /////////////////////////////

            DataTable dtddlomtpfac = acc.MTPFAllocationSchemeList();
            ddlomtpfac.DataSource = dtddlomtpfac;
            ddlomtpfac.DataTextField = "MAS_FULLNAME";
            ddlomtpfac.DataValueField = "MAS_SHORTNAME";
            ddlomtpfac.DataBind();
            //ddlomtpfac.SelectedItem.Text = "HIGH VOLATITLITY";

            //////////////////  STP   Operating Instruction List    /////////////////////////////

            DataTable dtddloprt = acc.OperatingInstructionList();
            ddloprt.DataSource = dtddloprt;
            ddloprt.DataTextField = "AOI_FULLNAME";
            ddloprt.DataValueField = "AOI_SHORTNAME";
            ddloprt.DataBind();
            //ddloprt.SelectedItem.Text = "ANY TWO JOINTLY";


            //////////////////  STP   Operating Instruction List    /////////////////////////////


            ddl_BranchCity.DataSource = acc.BranchCitiesList();
            ddl_BranchCity.DataTextField = "CITY";
            ddl_BranchCity.DataValueField = "CODE";
            ddl_BranchCity.DataBind();
            ddl_BranchCity.SelectedItem.Text = "KARACHI";


            DataTable dtCities = acc.CitiesList();
            ddl_City.DataSource = dtCities;
            ddl_City.DataTextField = "CITY";
            ddl_City.DataValueField = "CODE";
            ddl_City.DataBind();
            ddl_City.SelectedItem.Text = "KARACHI";

            //ddl_p_city
            ddl_p_city.DataSource = dtCities;
            ddl_p_city.DataTextField = "CITY";
            ddl_p_city.DataValueField = "CODE";
            ddl_p_city.DataBind();
            ddl_p_city.SelectedItem.Text = "KARACHI";



            DataView dv = new DataView(dtCities);
            dv.RowFilter = "City='" + ddl_City.SelectedItem.Text + "' ";
            dtCities = dv.ToTable();

            txt_cstm_phonenumber.Text = dtCities.Rows[0]["CODE"].ToString();
            txt_cstm_officenumber.Text = dtCities.Rows[0]["CODE"].ToString();
            txt_city.Visible = false;
            ddl_City.Visible = true;

            ddlBanks.DataSource = acc.BankList();
            ddlBanks.DataTextField = "BANKNAME";
            ddlBanks.DataValueField = "BANKID";
            ddlBanks.DataBind();

            ddlMobileType.DataSource = acc.MobileNetwork("");
            ddlMobileType.DataTextField = "Network";
            ddlMobileType.DataValueField = "Network";
            ddlMobileType.DataBind();

            ddlMobileCode.DataSource = acc.MobileNetwork(ddlMobileType.SelectedItem.Text);
            ddlMobileCode.DataTextField = "Code";
            ddlMobileCode.DataValueField = "Code";
            ddlMobileCode.DataBind();

            if (Session["CNIC"] != null)
            {
                DataTable dtCust = acc.GetCustomerInfo(Session["CNIC"].ToString(), Session["Role"].ToString());
                Session["CNIC"] = null;
                if (dtCust.Rows.Count > 0)
                {
                    #region BASIC
                    txt_dao_id.Text = string.IsNullOrEmpty(dtCust.Rows[0]["DAOID"].ToString()) ? string.Empty : dtCust.Rows[0]["DAOID"].ToString();
                    txt_cnicnum.Text = dtCust.Rows[0]["CNIC"].ToString();
                    txt_name.Text = dtCust.Rows[0]["CUSTOMER_NAME"].ToString();
                    txt_fathername.Text = dtCust.Rows[0]["FATHER_HUSBAND_NAME"].ToString();

                    txt_mothername.Text = dtCust.Rows[0]["MOTHER_NAME"].ToString();
                    
                    //txt_maritalstatus.Text = dtCust.Rows[0]["MARITAL_STATUS"].ToString();
                    ddlMaritalStatus.SelectedIndex = ddlMaritalStatus.Items.IndexOf(ddlMaritalStatus.Items.FindByText(dtCust.Rows[0]["MARITAL_STATUS"].ToString()));
                    txt_date_of_birth.Text = Convert.ToDateTime(dtCust.Rows[0]["DATE_OF_BIRTH"].ToString()).ToString("MM/dd/yyyy");
                    txt_cnic_expiry.Text = Convert.ToDateTime(dtCust.Rows[0]["CNIC_EXPIRY_DATE"].ToString()).ToString("MM/dd/yyyy");
                    txt_cnic_issue.Text = string.IsNullOrEmpty(dtCust.Rows[0]["CNIC_ISSUE_DATE"].ToString()) ? string.Empty : Convert.ToDateTime(dtCust.Rows[0]["CNIC_ISSUE_DATE"].ToString()).ToString("MM/dd/yyyy");
                    if (!string.IsNullOrEmpty(dtCust.Rows[0]["CNIC_RENEW_RECEIPT_NO"].ToString()))
                    {
                        txt_cnic_renew_num.Text = dtCust.Rows[0]["CNIC_RENEW_RECEIPT_NO"].ToString();
                        txt_cnic_expiry.Visible = false;
                        txt_cnic_renew_num.Visible = true;
                    }
                    txt_nationality.Text = dtCust.Rows[0]["NATIONALITY"].ToString();

                    txt_par_address.Text = dtCust.Rows[0]["PARMANENT_ADDRESS"].ToString();

                    //txt_religon.Text = dtCust.Rows[0]["RELIGON"].ToString();

                    ddl_religon.SelectedIndex = ddl_religon.Items.IndexOf(ddl_religon.Items.FindByText(dtCust.Rows[0]["RELIGON"].ToString()));

                    txt_address.Text = dtCust.Rows[0]["ADDRESS"].ToString();
                    txt_email.Text = dtCust.Rows[0]["EMAIL"].ToString();
                    ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByText(dtCust.Rows[0]["COUNTRY"].ToString()));

                    ddl_p_country.SelectedIndex = ddl_p_country.Items.IndexOf(ddlCountry.Items.FindByText(dtCust.Rows[0]["permanent_country"].ToString()));

                    ddl_p_city.SelectedIndex = ddl_p_city.Items.IndexOf(ddl_p_city.Items.FindByText(dtCust.Rows[0]["permanent_city"].ToString()));

                    ddl_pob.SelectedIndex = ddl_pob.Items.IndexOf(ddl_p_city.Items.FindByText(dtCust.Rows[0]["pob"].ToString()));



                    Rb_dual_national_yes.Checked = dtCust.Rows[0]["DUAL_NATIONALITY"].ToString() == "YES";
                    Rb_dual_national_no.Checked = dtCust.Rows[0]["DUAL_NATIONALITY"].ToString() == "NO";

                    Rb_resident_pakistan.Checked = dtCust.Rows[0]["RESIDENTIAL_STATUS"].ToString() == "Pakistan Resident";
                    Rb_resident_non_resident.Checked = dtCust.Rows[0]["RESIDENTIAL_STATUS"].ToString() == "Non-Resident";
                    Rb_resident_for.Checked = dtCust.Rows[0]["RESIDENTIAL_STATUS"].ToString() == "Resident Foreign National";
                    Rb_resident_non_for.Checked = dtCust.Rows[0]["RESIDENTIAL_STATUS"].ToString() == "Non-Resident Foreign National";



                    Rb_cstm_dm_cd_reinvest.Checked = dtCust.Rows[0]["DIVIDEND_MANDATE"].ToString() == "REINVEST";
                    Rb_cstm_dm_cd_providecash.Checked = dtCust.Rows[0]["DIVIDEND_MANDATE"].ToString() == "PROVIDE CASH";



                    

                    if (ddlCountry.SelectedItem.Text == "Pakistan".ToUpper())
                    {
                        txt_city.Visible = false;
                        ddl_City.Visible = true;
                        ddl_City.DataSource = acc.CitiesList();
                        ddl_City.DataTextField = "CITY";
                        ddl_City.DataValueField = "CODE";
                        ddl_City.DataBind();
                        ddl_City.SelectedIndex = ddl_City.Items.IndexOf(ddl_City.Items.FindByText(dtCust.Rows[0]["RESIDENCE_CITY"].ToString()));
                    }
                    else
                    {
                        txt_city.Visible = true;
                        ddl_City.Visible = false;
                        txt_city.Text = dtCust.Rows[0]["RESIDENCE_CITY"].ToString();
                    }
                    txt_cstm_phonenumber.Text = dtCust.Rows[0]["RESIDENTIAL_NUMBER"].ToString();
                    txt_cstm_officenumber.Text = dtCust.Rows[0]["OFF_NUMBER"].ToString();

                    cb_MobilePorted.Checked = dtCust.Rows[0]["NETWORK_PORTED"].ToString() == "YES";
                    ddlMobileType.SelectedIndex = ddlMobileType.Items.IndexOf(ddlMobileType.Items.FindByText(dtCust.Rows[0]["MOBILE_NETWORK"].ToString()));
                    txtOtherMobile.Visible = ddlMobileType.SelectedItem.Text == "OTHER";
                    ddlMobileCode.Visible = !txtOtherMobile.Visible;
                    txt_cstm_mobilenumber.Visible = !txtOtherMobile.Visible;

                    if (txtOtherMobile.Visible)
                    {
                        txtOtherMobile.Text = dtCust.Rows[0]["MOBILE"].ToString();
                    }
                    else
                    {
                        ddlMobileCode.DataSource = acc.MobileNetwork(cb_MobilePorted.Checked ? "Ported" : dtCust.Rows[0]["MOBILE_NETWORK"].ToString());
                        ddlMobileCode.DataTextField = "Code";
                        ddlMobileCode.DataValueField = "Code";
                        ddlMobileCode.DataBind();

                        ddlMobileCode.SelectedIndex = ddlMobileCode.Items.IndexOf(ddlMobileCode.Items.FindByText(dtCust.Rows[0]["MOBILE"].ToString().Substring(0, 4)));
                        txt_cstm_mobilenumber.Text = dtCust.Rows[0]["MOBILE"].ToString().Substring(4);
                    }


                    if (ddlBanks.Items.FindByValue(dtCust.Rows[0]["BANK_NAME"].ToString()) != null)
                    {
                        txt_cstm_bankname.Visible = false;
                        ddlBanks.Visible = true;
                        ddlBanks.SelectedIndex = ddlBanks.Items.IndexOf(ddlBanks.Items.FindByValue(dtCust.Rows[0]["BANK_NAME"].ToString()));
                    }
                    else
                    {
                        txt_cstm_bankname.Visible = true;
                        ddlBanks.Visible = false;
                        txt_cstm_bankname.Text = dtCust.Rows[0]["BANK_NAME"].ToString();
                    }
                    txt_cstm_accountname.Text = dtCust.Rows[0]["BANK_ACC_NUMBER"].ToString();
                    txt_branch_name.Text = dtCust.Rows[0]["BRANCH_NAME"].ToString();

                    // txt_branch_city.Text = dtCust.Rows[0]["BRANCH_CITY"].ToString();
                    ddl_BranchCity.SelectedIndex = ddl_BranchCity.Items.IndexOf(ddl_BranchCity.Items.FindByText(dtCust.Rows[0]["BRANCH_CITY"].ToString()));
                    
                    txt_cstm_kyc_noeb.Text = dtCust.Rows[0]["NAME_OF_EMPLOYER_BUSINESS"].ToString();
                    ddloactype.SelectedIndex = ddloactype.Items.IndexOf(ddloactype.Items.FindByText(dtCust.Rows[0]["ACCOUNT_TYPE"].ToString()));
                    ddl_kycq7.SelectedIndex = ddl_kycq7.Items.IndexOf(ddl_kycq7.Items.FindByText(dtCust.Rows[0]["WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN"].ToString()));

                    #endregion
                    #region DIVIDEND MENDATE
                    Rb_cstm_dm_cd_reinvest.Checked = dtCust.Rows[0]["DIVIDEND_MANDATE"].ToString() == "REINVEST";
                    Rb_cstm_dm_cd_providecash.Checked = dtCust.Rows[0]["DIVIDEND_MANDATE"].ToString() == "PROVIDE CASH";
                    #endregion
                    #region BONUS MENDATE
                    Rb_cstm_dm_sd_ibu.Checked = dtCust.Rows[0]["BONUS_MANDATE"].ToString() == "ISSUE BONUS UNITS";
                    Rb_cstm_dm_sd_ebu.Checked = dtCust.Rows[0]["BONUS_MANDATE"].ToString() == "ENCASH BONUS UNITS";
                    #endregion
                    #region OCCUPATION
                    Rb_cstm_kyc_ocptn_gservices.Checked = dtCust.Rows[0]["OCCUPATION"].ToString() == "GOVERMENT SERVICES";
                    Rb_cstm_kyc_ocptn_pservices.Checked = dtCust.Rows[0]["OCCUPATION"].ToString() == "PRIVATE SERVICES";
                    Rb_cstm_kyc_ocptn_selfemplyd.Checked = dtCust.Rows[0]["OCCUPATION"].ToString() == "SELF EMPLOYED";
                    Rb_cstm_kyc_ocptn_retired.Checked = dtCust.Rows[0]["OCCUPATION"].ToString() == "RETIRED";
                    Rb_cstm_kyc_ocptn_student.Checked = dtCust.Rows[0]["OCCUPATION"].ToString() == "STUDENT";
                    Rb_cstm_kyc_ocptn_hwife.Checked = dtCust.Rows[0]["OCCUPATION"].ToString() == "HOUSE WIFE";
                    #endregion
                    #region SOURCE OF INCOME
                    Rb_cstm_kyc_soi_business.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "BUSINESS/SELF-OWNED";
                    Rb_cstm_kyc_soi_salary.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "SALARY";
                    Rb_cstm_kyc_soi_saving.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "SAVING";
                    Rb_cstm_kyc_soi_pensions.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "PENSIONS";
                    Rb_cstm_kyc_soi_remittances.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "REMITTANCES";
                    Rb_cstm_kyc_soi_inheritances.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "INHERITANCES";
                    Rb_cstm_kyc_soi_stocks.Checked = dtCust.Rows[0]["SOURCE_OF_INCOME"].ToString() == "STOCKS/INVESTMENT";
                    #endregion
                    #region FINANCIAL INSTITUTE REFUSE
                    Rb_cstm_kyc_firoa_yes.Checked = dtCust.Rows[0]["ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER"].ToString() == "YES";
                    Rb_cstm_kyc_firoa_no.Checked = dtCust.Rows[0]["ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER"].ToString() == "NO";

                    Rb_cstm_kyc_firoa_yes_j1.Checked = dtCust.Rows[0]["ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1"].ToString() == "YES";
                    Rb_cstm_kyc_firoa_no_j1.Checked = dtCust.Rows[0]["ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1"].ToString() == "NO";

                    Rb_cstm_kyc_firoa_yes_j2.Checked = dtCust.Rows[0]["ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2"].ToString() == "YES";
                    Rb_cstm_kyc_firoa_no_j2.Checked = dtCust.Rows[0]["ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2"].ToString() == "NO";
                    
                    #endregion
                    #region ACTING ON BEHALF
                    Rb_cstm_kyc_abop_yes.Checked = dtCust.Rows[0]["ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON"].ToString() == "YES";
                    Rb_cstm_kyc_abop_no.Checked = dtCust.Rows[0]["ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON"].ToString() == "NO";
                    #endregion
                    #region SENIOR POSITION GOVT
                    
                    Rb_cstm_kyc_spgi_yes.Checked = dtCust.Rows[0]["HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE"].ToString() == "YES";
                    Rb_cstm_kyc_spgi_no.Checked = dtCust.Rows[0]["HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE"].ToString() == "NO";

                    Rb_cstm_kyc_spgi_yes_j1.Checked = dtCust.Rows[0]["HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1"].ToString() == "YES";
                    Rb_cstm_kyc_spgi_no_j1.Checked = dtCust.Rows[0]["HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1"].ToString() == "NO";

                    Rb_cstm_kyc_spgi_yes_j2.Checked = dtCust.Rows[0]["HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2"].ToString() == "YES";
                    Rb_cstm_kyc_spgi_no_j2.Checked = dtCust.Rows[0]["HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2"].ToString() == "NO";

                    #endregion
                    #region SENIOR POSITION POLITICALPARTY
                    
                    Rb_cstm_kyc_sppp_yes.Checked = dtCust.Rows[0]["SENOIR_MEMBER_IN_POLITICAL_PARTY"].ToString() == "YES";
                    Rb_cstm_kyc_sppp_no.Checked = dtCust.Rows[0]["SENOIR_MEMBER_IN_POLITICAL_PARTY"].ToString() == "NO";
                    Rb_cstm_kyc_sppp_yes_j1.Checked = dtCust.Rows[0]["SENOIR_MEMBER_IN_POLITICAL_PARTY_J1"].ToString() == "YES";
                    Rb_cstm_kyc_sppp_no_j1.Checked = dtCust.Rows[0]["SENOIR_MEMBER_IN_POLITICAL_PARTY_J1"].ToString() == "NO";
                    Rb_cstm_kyc_sppp_yes_j2.Checked = dtCust.Rows[0]["SENOIR_MEMBER_IN_POLITICAL_PARTY_J2"].ToString() == "YES";
                    Rb_cstm_kyc_sppp_no_j2.Checked = dtCust.Rows[0]["SENOIR_MEMBER_IN_POLITICAL_PARTY_J2"].ToString() == "NO";
                                                          
                    #endregion
                    #region HIGH VALUE ITEMS
                    Rb_cstm_kyc_hvitem_yes.Checked = dtCust.Rows[0]["DEAL_IN_HIGH_VALUE_ITEMS"].ToString() == "YES";
                    Rb_cstm_kyc_hvitem_no.Checked = dtCust.Rows[0]["DEAL_IN_HIGH_VALUE_ITEMS"].ToString() == "NO";
                    Rb_cstm_kyc_hvitem_yes_j1.Checked = dtCust.Rows[0]["DEAL_IN_HIGH_VALUE_ITEMS_j1"].ToString() == "YES";
                    Rb_cstm_kyc_hvitem_no_j1.Checked = dtCust.Rows[0]["DEAL_IN_HIGH_VALUE_ITEMS_j1"].ToString() == "NO";
                    Rb_cstm_kyc_hvitem_yes_j2.Checked = dtCust.Rows[0]["DEAL_IN_HIGH_VALUE_ITEMS_j2"].ToString() == "YES";
                    Rb_cstm_kyc_hvitem_no_j2.Checked = dtCust.Rows[0]["DEAL_IN_HIGH_VALUE_ITEMS_j2"].ToString() == "NO";                    
                    #endregion

                    #region financial support
                    Rb_cstm_kyc_fsupport_yes.Checked = dtCust.Rows[0]["FINANCIALLY_SUPPORTED"].ToString() == "YES";
                    Rb_cstm_kyc_fsupport_no.Checked = dtCust.Rows[0]["FINANCIALLY_SUPPORTED"].ToString() == "NO";

                    Rb_cstm_kyc_fsupport_j1_yes.Checked = dtCust.Rows[0]["FINANCIALLY_SUPPORTED_J1"].ToString() == "YES";
                    Rb_cstm_kyc_fsupport_j1_no.Checked = dtCust.Rows[0]["FINANCIALLY_SUPPORTED_J1"].ToString() == "NO";

                    Rb_cstm_kyc_fsupport_j2_yes.Checked = dtCust.Rows[0]["FINANCIALLY_SUPPORTED_J2"].ToString() == "YES";
                    Rb_cstm_kyc_fsupport_j2_no.Checked = dtCust.Rows[0]["FINANCIALLY_SUPPORTED_J2"].ToString() == "NO";

                    #endregion
                                        
                    #region Customer Wealth
                    Rb_cstm_kyc_wealth_yes.Checked = dtCust.Rows[0]["wealth_source_p"].ToString() == "YES";
                    Rb_cstm_kyc_wealth_no.Checked = dtCust.Rows[0]["wealth_source_p"].ToString() == "NO";

                    Rb_cstm_kyc_wealth_yes_j1.Checked = dtCust.Rows[0]["wealth_source_j1"].ToString() == "YES";
                    Rb_cstm_kyc_wealth_no_j1.Checked = dtCust.Rows[0]["wealth_source_j1"].ToString() == "NO";

                    Rb_cstm_kyc_wealth_yes_j2.Checked = dtCust.Rows[0]["wealth_source_j2"].ToString() == "YES";
                    Rb_cstm_kyc_wealth_no_j2.Checked = dtCust.Rows[0]["wealth_source_j2"].ToString() == "NO";

                    
                    #endregion

                    #region Head of state
                    Rb_cstm_kyc_head_state_yes.Checked = dtCust.Rows[0]["Head_of_state_p"].ToString() == "YES";
                    Rb_cstm_kyc_head_state_no.Checked = dtCust.Rows[0]["Head_of_state_p"].ToString() == "NO";
                    Rb_cstm_kyc_head_state_yes_j1.Checked = dtCust.Rows[0]["Head_of_state_j1"].ToString() == "YES";
                    Rb_cstm_kyc_head_state_no_j1.Checked = dtCust.Rows[0]["Head_of_state_j1"].ToString() == "NO";
                    Rb_cstm_kyc_head_state_yes_j2.Checked = dtCust.Rows[0]["Head_of_state_j2"].ToString() == "YES";
                    Rb_cstm_kyc_head_state_no_j2.Checked = dtCust.Rows[0]["Head_of_state_j2"].ToString() == "NO";
                    #endregion

                    #region Adviser
                    Rb_cstm_kyc_adviser_yes.Checked = dtCust.Rows[0]["Adviser"].ToString() == "YES";
                    Rb_cstm_kyc_adviser_no.Checked = dtCust.Rows[0]["Adviser"].ToString() == "NO";

                    Rb_cstm_kyc_adviser_yes_j1.Checked = dtCust.Rows[0]["Adviser_j1"].ToString() == "YES";
                    Rb_cstm_kyc_adviser_no_j1.Checked = dtCust.Rows[0]["Adviser_j1"].ToString() == "NO";

                    Rb_cstm_kyc_adviser_yes_j2.Checked = dtCust.Rows[0]["Adviser_j2"].ToString() == "YES";
                    Rb_cstm_kyc_adviser_no_j2.Checked = dtCust.Rows[0]["Adviser_j2"].ToString() == "NO";

                    #endregion

                    #region judicial
                    Rb_cstm_kyc_judicial_yes.Checked = dtCust.Rows[0]["Judicial"].ToString() == "YES";
                    Rb_cstm_kyc_judicial_no.Checked = dtCust.Rows[0]["Judicial"].ToString() == "NO";

                    Rb_cstm_kyc_judicial_yes_j1.Checked = dtCust.Rows[0]["Judicial_j1"].ToString() == "YES";
                    Rb_cstm_kyc_judicial_no_j1.Checked = dtCust.Rows[0]["Judicial_j1"].ToString() == "NO";

                    Rb_cstm_kyc_judicial_yes_j2.Checked = dtCust.Rows[0]["Judicial_j2"].ToString() == "YES";
                    Rb_cstm_kyc_judicial_no_j2.Checked = dtCust.Rows[0]["Judicial_j2"].ToString() == "NO";


                    #endregion

                    #region Military
                    Rb_cstm_kyc_military_yes.Checked = dtCust.Rows[0]["Judicial"].ToString() == "YES";
                    Rb_cstm_kyc_military_no.Checked = dtCust.Rows[0]["Judicial"].ToString() == "NO";

                    Rb_cstm_kyc_military_yes_j1.Checked = dtCust.Rows[0]["Judicial_j1"].ToString() == "YES";
                    Rb_cstm_kyc_military_no_j1.Checked = dtCust.Rows[0]["Judicial_j1"].ToString() == "NO";

                    Rb_cstm_kyc_military_yes_j2.Checked = dtCust.Rows[0]["Judicial_j2"].ToString() == "YES";
                    Rb_cstm_kyc_military_no_j2.Checked = dtCust.Rows[0]["Judicial_j2"].ToString() == "NO";


                    #endregion

                    #region HOD
                    Rb_cstm_kyc_hod_yes.Checked = dtCust.Rows[0]["Hod_State_p"].ToString() == "YES";
                    Rb_cstm_kyc_hod_no.Checked = dtCust.Rows[0]["Hod_State_p"].ToString() == "NO";

                    Rb_cstm_kyc_hod_yes_j1.Checked = dtCust.Rows[0]["Hod_State_j1"].ToString() == "YES";
                    Rb_cstm_kyc_hod_no_j1.Checked = dtCust.Rows[0]["Hod_State_j1"].ToString() == "NO";

                    Rb_cstm_kyc_hod_yes_j2.Checked = dtCust.Rows[0]["Hod_State_j2"].ToString() == "YES";
                    Rb_cstm_kyc_hod_no_j2.Checked = dtCust.Rows[0]["Hod_State_j2"].ToString() == "NO";


                    #endregion

                    #region International Organization
                    
                    Rb_cstm_kyc_io_yes.Checked = dtCust.Rows[0]["International_Organization_p"].ToString() == "YES";
                    Rb_cstm_kyc_io_no.Checked = dtCust.Rows[0]["International_Organization_p"].ToString() == "NO";

                    Rb_cstm_kyc_io_yes_j1.Checked = dtCust.Rows[0]["International_Organization_j1"].ToString() == "YES";
                    Rb_cstm_kyc_io_no_j1.Checked = dtCust.Rows[0]["International_Organization_j1"].ToString() == "NO";

                    Rb_cstm_kyc_io_yes_j2.Checked = dtCust.Rows[0]["International_Organization_j2"].ToString() == "YES";
                    Rb_cstm_kyc_io_no_j2.Checked = dtCust.Rows[0]["International_Organization_j2"].ToString() == "NO";

                    #endregion

                    #region Assembly

                    Rb_cstm_kyc_assembly_yes.Checked = dtCust.Rows[0]["Assembly_p"].ToString() == "YES";
                    Rb_cstm_kyc_assembly_no.Checked = dtCust.Rows[0]["Assembly_p"].ToString() == "NO";

                    Rb_cstm_kyc_assembly_yes_j1.Checked = dtCust.Rows[0]["Assembly_j1"].ToString() == "YES";
                    Rb_cstm_kyc_assembly_no_j1.Checked = dtCust.Rows[0]["Assembly_j1"].ToString() == "NO";

                    Rb_cstm_kyc_assembly_yes_j2.Checked = dtCust.Rows[0]["Assembly_j2"].ToString() == "YES";
                    Rb_cstm_kyc_assembly_no_j2.Checked = dtCust.Rows[0]["Assembly_j2"].ToString() == "NO";

                    #endregion

                    #region Political

                    Rb_cstm_kyc_party_yes.Checked = dtCust.Rows[0]["Political_p"].ToString() == "YES";
                    Rb_cstm_kyc_party_no.Checked = dtCust.Rows[0]["Political_p"].ToString() == "NO";

                    Rb_cstm_kyc_party_yes_j1.Checked = dtCust.Rows[0]["Political_j1"].ToString() == "YES";
                    Rb_cstm_kyc_party_no_j1.Checked  = dtCust.Rows[0]["Political_j1"].ToString() == "NO";

                    Rb_cstm_kyc_party_yes_j2.Checked =  dtCust.Rows[0]["Political_j2"].ToString() == "YES";
                    Rb_cstm_kyc_party_no_j2.Checked =   dtCust.Rows[0]["Political_j2"].ToString() == "NO";

                    #endregion

                    #region board member

                    Rb_cstm_kyc_mob_yes.Checked = dtCust.Rows[0]["board_member_p"].ToString() == "YES";
                    Rb_cstm_kyc_mob_no.Checked = dtCust.Rows[0]["board_member_p"].ToString() == "NO";

                    Rb_cstm_kyc_mob_yes_j1.Checked = dtCust.Rows[0]["board_member_j1"].ToString() == "YES";
                    Rb_cstm_kyc_mob_no_j1.Checked = dtCust.Rows[0]["board_member_j1"].ToString() == "NO";

                    Rb_cstm_kyc_mob_yes_j2.Checked = dtCust.Rows[0]["board_member_j2"].ToString() == "YES";
                    Rb_cstm_kyc_mob_no_j2.Checked = dtCust.Rows[0]["board_member_j2"].ToString() == "NO";


                    #endregion


           Rb_kyc_tran_mode_online.Checked = dtCust.Rows[0]["Possible_modes_of_transactions"].ToString() == "ONLINE";
           Rb_kyc_tran_mode_physical.Checked = dtCust.Rows[0]["Possible_modes_of_transactions"].ToString() == "PHYSICAL";
           Rb_kyc_tran_mode_Both.Checked = dtCust.Rows[0]["Possible_modes_of_transactions"].ToString() == "BOTH";




           if (dtCust.Rows[0]["Possible_Turnover_in_Account"].ToString() != "")
           {
               Rb_kyc_turn_over_monthly.Checked = true;
               txt_kyc_turn_over.Text = dtCust.Rows[0]["Possible_Turnover_in_Account"].ToString();
           }
           else 
           { Rb_kyc_turn_over_annually.Checked = true;
           txt_kyc_turn_over.Text = dtCust.Rows[0]["Possible_turnover_in_acount_annual"].ToString();
           }

           Rb_kyc_exp_amount_2.Checked = dtCust.Rows[0]["Amount_of_Investment"].ToString() == "upto Rs. 2.5M";
           Rb_kyc_exp_amount_5.Checked = dtCust.Rows[0]["Amount_of_Investment"].ToString() == "upto Rs. 2.5M to Rs 5M";
           Rb_kyc_exp_amount_10.Checked = dtCust.Rows[0]["Amount_of_Investment"].ToString() == "upto Rs. 5M to Rs 10M";

           Rb_kyc_exp_amount_10above.Checked = dtCust.Rows[0]["Amount_of_Investment"].ToString() == "Above Rs. 10M";

           Rb_kyc_annual_income_1.Checked = dtCust.Rows[0]["Annual_Gross_Income"].ToString() == "upto Rs. 1M";
           Rb_kyc_annual_income_3.Checked = dtCust.Rows[0]["Annual_Gross_Income"].ToString() == "Rs. 1 M to Rs. 3 M";
           Rb_kyc_annual_income_6.Checked = dtCust.Rows[0]["Annual_Gross_Income"].ToString() == "Rs. 3 M to Rs. 6 M";
           Rb_kyc_annual_income_8.Checked = dtCust.Rows[0]["Annual_Gross_Income"].ToString() == "Rs. 6 M to Rs. 8 M";
           Rb_kyc_annual_income_10.Checked = dtCust.Rows[0]["Annual_Gross_Income"].ToString() == "Rs. 8 M to Rs. 10 M";


                                        
                    txt_kyc_designation.Text = dtCust.Rows[0]["designation"].ToString();
                    txt_kyc_nob.Text = dtCust.Rows[0]["Nature_of_business"].ToString();

                    ddl_kyc_gepgraphy_international_cparty.SelectedIndex = ddl_kyc_gepgraphy_international_cparty.Items.IndexOf(ddl_kyc_gepgraphy_international_cparty.Items.FindByText(dtCust.Rows[0]["Type_of_Counterparty_International"].ToString()));

                    ddl_kyc_gepgraphy_domestic_cparty.SelectedIndex = ddl_kyc_gepgraphy_domestic_cparty.Items.IndexOf(ddl_kyc_gepgraphy_domestic_cparty.Items.FindByText(dtCust.Rows[0]["Type_of_Counterparty_Domestic"].ToString()));

                    ddl_kyc_gepgraphy_domestic.SelectedIndex = ddl_kyc_gepgraphy_domestic.Items.IndexOf(ddl_kyc_gepgraphy_domestic.Items.FindByText(dtCust.Rows[0]["Geographic_Involved_Domestic"].ToString()));
                    ddl_kyc_gepgraphy_international.SelectedIndex = ddl_kyc_gepgraphy_international.Items.IndexOf(ddl_kyc_gepgraphy_international.Items.FindByText(dtCust.Rows[0]["Geographic_Involved_International"].ToString()));
                   
                    ddl_p_country.SelectedIndex = ddl_p_country.Items.IndexOf(ddlCountry.Items.FindByText(dtCust.Rows[0]["permanent_country"].ToString()));

                    txt_kyc_act_quest.Text = dtCust.Rows[0]["Name_of_Ultimate_Beneficiary"].ToString();

                    txt_kyc_Act_quest_cnic.Text = dtCust.Rows[0]["CNIC_Passport_No_of_Beneficiary"].ToString();

                    ddl_kyc_act_quest_relation.SelectedIndex 
                    = ddl_kyc_act_quest_relation.Items.IndexOf(ddl_kyc_act_quest_relation.Items.FindByText(dtCust.Rows[0]["Relationship_with_Customer"].ToString()));



                    #region MINOR_ACCOUNT
                    panel_minor_account.Visible = ddloactype.SelectedItem.Text == "MINOR";
                    txt_cstm_mnr_ng.Text = string.IsNullOrEmpty(dtCust.Rows[0]["ACC_MINOR_GUARDIAN_NAME"].ToString()) ? "" : dtCust.Rows[0]["ACC_MINOR_GUARDIAN_NAME"].ToString();
                    txt_cstm_mnr_gcnic.Text = string.IsNullOrEmpty(dtCust.Rows[0]["ACC_GUARDIAN_CNIC"].ToString()) ? "" : dtCust.Rows[0]["ACC_GUARDIAN_CNIC"].ToString();
                    txt_cstm_mnr_cnic_expiry.Text = string.IsNullOrEmpty(dtCust.Rows[0]["ACC_GUARDIAN_CNIC_EXPIRY"].ToString()) ? "" : dtCust.Rows[0]["ACC_GUARDIAN_CNIC_EXPIRY"].ToString();
                    //   txt_cstm_mnr_rwp.Text = string.IsNullOrEmpty(dtCust.Rows[0]["ACC_MINOR_RELATIONSHIP"].ToString()) ? "" : dtCust.Rows[0]["ACC_MINOR_RELATIONSHIP"].ToString();


                    ddlRelationWithPrinciple_mnr.SelectedIndex = ddlRelationWithPrinciple_mnr.Items.IndexOf(ddlRelationWithPrinciple_mnr.Items.FindByText(dtCust.Rows[0]["ACC_MINOR_RELATIONSHIP"].ToString()));



                    #endregion
                    #region JOINT_HOLDER

                    if (!string.IsNullOrEmpty(dtCust.Rows[0]["JOINT_HOLDER_ONE_CNIC"].ToString()) || !string.IsNullOrEmpty(dtCust.Rows[0]["JOINT_HOLDER_TWO_CNIC"].ToString()))
                    {
                        panel_joint_acc_holder.Visible = true;
                    }

                    ddloprt.Visible = !string.IsNullOrEmpty(dtCust.Rows[0]["ACCOUNT_OPERATING_INSTRUCTION"].ToString());
                    ddloprt.SelectedIndex = ddloprt.Visible ? ddloprt.Items.IndexOf(ddloprt.Items.FindByText(dtCust.Rows[0]["ACCOUNT_OPERATING_INSTRUCTION"].ToString())) : 0;

                    txt_cstm_jh_jhcnic1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["JOINT_HOLDER_ONE_CNIC"].ToString()) ? "" : dtCust.Rows[0]["JOINT_HOLDER_ONE_CNIC"].ToString();
                    txt_cstm_jh_jhname1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["JOINT_HOLDER_ONE_NAME"].ToString()) ? "" : dtCust.Rows[0]["JOINT_HOLDER_ONE_NAME"].ToString();
                    //   txt_cstm_jh_jhrwp1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_ONE"].ToString()) ? "" : dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_ONE"].ToString();

                    ddlRelationWithPrinciple_J1.SelectedIndex = ddlRelationWithPrinciple_J1.Items.IndexOf(ddlRelationWithPrinciple_J1.Items.FindByText(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_ONE"].ToString()));


                    txt_cstm_jh_jhcnic2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["JOINT_HOLDER_TWO_CNIC"].ToString()) ? "" : dtCust.Rows[0]["JOINT_HOLDER_TWO_CNIC"].ToString();
                    txt_cstm_jh_jhname2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["JOINT_HOLDER_TWO_NAME"].ToString()) ? "" : dtCust.Rows[0]["JOINT_HOLDER_TWO_NAME"].ToString();
                    // txt_cstm_jh_jhrwp2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_TWO"].ToString()) ? "" : dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_TWO"].ToString();
                    ddlRelationWithPrinciple_J2.SelectedIndex = ddlRelationWithPrinciple_J2.Items.IndexOf(ddlRelationWithPrinciple_J2.Items.FindByText(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_TWO"].ToString()));

                    
          // txt_cnic_expiry.Text = Convert.ToDateTime(dtCust.Rows[0]["CNIC_EXPIRY_DATE"].ToString()).ToString("MM/dd/yyyy");
                    txt_cstm_jh1_cnic_issue_date.Text = Convert.ToDateTime(dtCust.Rows[0]["joint_issue_date_j1"].ToString()).ToString("MM/dd/yyyy");
                    txt_cstm_jh1_cnic_exp_date.Text = Convert.ToDateTime(dtCust.Rows[0]["joint_exp_date_j1"].ToString()).ToString("MM/dd/yyyy");
                    txt_cstm_jh2_cnic_issue_date.Text = Convert.ToDateTime(dtCust.Rows[0]["joint_issue_date_j2"].ToString()).ToString("MM/dd/yyyy");
                    txt_cstm_jh2_cnic_exp_date.Text = Convert.ToDateTime(dtCust.Rows[0]["joint_exp_date_j2"].ToString()).ToString("MM/dd/yyyy");


                    #endregion
                    #region MTPF
                    panel_mtpf_ddlist.Visible = ddloactype.SelectedItem.Text == "MTPF";
                    retirement_age.Text = string.IsNullOrEmpty(dtCust.Rows[0]["EXPECTED_RETIREMENT_AGE"].ToString()) ? "" : dtCust.Rows[0]["EXPECTED_RETIREMENT_AGE"].ToString();
                    ddlomtpfac.SelectedIndex = string.IsNullOrEmpty(dtCust.Rows[0]["ALLOCATION_SCHEME"].ToString()) ? -1 : ddloprt.Items.IndexOf(ddloprt.Items.FindByText(dtCust.Rows[0]["ALLOCATION_SCHEME"].ToString()));
                    #endregion
                    #region NOMINEE

                    panel_nominee_details.Visible = true;

                    txt_cstm_mtpf_ncnic1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["NOMINEE_CNIC_ONE"].ToString()) ? "" : dtCust.Rows[0]["NOMINEE_CNIC_ONE"].ToString();
                    txt_cstm_mtpf_ncnic2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["NOMINEE_CNIC_TWO"].ToString()) ? "" : dtCust.Rows[0]["NOMINEE_CNIC_TWO"].ToString();
                    txt_cstm_mtpf_ncnic3.Text = string.IsNullOrEmpty(dtCust.Rows[0]["NOMINEE_CNIC_THREE"].ToString()) ? "" : dtCust.Rows[0]["NOMINEE_CNIC_THREE"].ToString();

                    txt_cstm_mtpf_nname1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["NOMINEE_NAME_ONE"].ToString()) ? "" : dtCust.Rows[0]["NOMINEE_NAME_ONE"].ToString();
                    txt_cstm_mtpf_nname2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["NOMINEE_NAME_TWO"].ToString()) ? "" : dtCust.Rows[0]["NOMINEE_NAME_TWO"].ToString();
                    txt_cstm_mtpf_nname3.Text = string.IsNullOrEmpty(dtCust.Rows[0]["NOMINEE_NAME_THREE"].ToString()) ? "" : dtCust.Rows[0]["NOMINEE_NAME_THREE"].ToString();

                    txt_cstm_mtpf_sharing1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["SHARING_PERC_ONE"].ToString()) ? "" : dtCust.Rows[0]["SHARING_PERC_ONE"].ToString();
                    txt_cstm_mtpf_sharing2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["SHARING_PERC_TWO"].ToString()) ? "" : dtCust.Rows[0]["SHARING_PERC_TWO"].ToString();
                    txt_cstm_mtpf_sharing3.Text = string.IsNullOrEmpty(dtCust.Rows[0]["SHARING_PERC_THREE"].ToString()) ? "" : dtCust.Rows[0]["SHARING_PERC_THREE"].ToString();

                    //txt_cstm_mtpf_nrwp1.Text = string.IsNullOrEmpty(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_ONE"].ToString()) ? "" : dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_ONE"].ToString();
                    //  txt_cstm_mtpf_nrwp2.Text = string.IsNullOrEmpty(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_TWO"].ToString()) ? "" : dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_TWO"].ToString();
                    //  txt_cstm_mtpf_nrwp3.Text = string.IsNullOrEmpty(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_THREE"].ToString()) ? "" : dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_THREE"].ToString();




                    ddlRelationWithPrinciple_N1.SelectedIndex = ddlRelationWithPrinciple_N1.Items.IndexOf(ddlRelationWithPrinciple_N1.Items.FindByText(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_ONE"].ToString()));

                    ddlRelationWithPrinciple_N2.SelectedIndex = ddlRelationWithPrinciple_N2.Items.IndexOf(ddlRelationWithPrinciple_N2.Items.FindByText(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_TWO"].ToString()));
                    ddlRelationWithPrinciple_N2.SelectedIndex = ddlRelationWithPrinciple_N2.Items.IndexOf(ddlRelationWithPrinciple_N2.Items.FindByText(dtCust.Rows[0]["RELATIONSHIP_WITH_PRINCIPLE_THREE"].ToString()));









                    #endregion

                    #region FATCA
                    Rb_ftca_ctrotp_none.Checked = dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() == "NONE";
                    Rb_ftca_ctrotp_USA.Checked = dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() == "USA";
                    Rb_ftca_ctrotp_other.Checked = dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() != "NONE" && dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() != "USA" ? true : false;
                    txt_ftca_ctrotp_other_cntry.Text = dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() != "NONE" && dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() != "USA" ? dtCust.Rows[0]["TAX_RESIDENCE_OTHER_THAN_PAKISTAN"].ToString() : "";

                    txt_ftca_pob_city.Text = dtCust.Rows[0]["PLACE_OF_BIRTH_CITY"].ToString();
                    txt_ftca_pob_bstate.Text = dtCust.Rows[0]["PLACE_OF_BIRTH_STATE"].ToString();
                    txt_ftca_pob_birthcountry.Text = dtCust.Rows[0]["PLACE_OF_BIRTH_COUNTRY"].ToString();

                    Rb_ftca_uscitizen_yes.Checked = dtCust.Rows[0]["US_CITIZEN"].ToString() == "YES";
                    Rb_ftca_uscitizen_no.Checked = dtCust.Rows[0]["US_CITIZEN"].ToString() == "NO";

                    Rb_ftca_usresdnt_yes.Checked = dtCust.Rows[0]["US_RESIDENT"].ToString() == "YES";
                    Rb_ftca_usresdnt_no.Checked = dtCust.Rows[0]["US_RESIDENT"].ToString() == "NO";

                    Rb_ftca_usgc_yes.Checked = dtCust.Rows[0]["GREEEN_CARD"].ToString() == "YES";
                    Rb_ftca_usgc_no.Checked = dtCust.Rows[0]["GREEEN_CARD"].ToString() == "NO";

                    Rb_ftca_usborn_yes.Checked = dtCust.Rows[0]["DOB_OF_USA"].ToString() == "YES";
                    Rb_ftca_usborn_no.Checked = dtCust.Rows[0]["DOB_OF_USA"].ToString() == "NO";

                    Rb_ftca_ussitf_yes.Checked = dtCust.Rows[0]["TRANSFER_FUND_TO_USA_ACCOUNT"].ToString() == "YES";
                    Rb_ftca_ussitf_no.Checked = dtCust.Rows[0]["TRANSFER_FUND_TO_USA_ACCOUNT"].ToString() == "NO";

                    Rb_ftca_uspa_yes.Checked = dtCust.Rows[0]["POWER_OF_ATTORNEY_USA_ADDRESS"].ToString() == "YES";
                    Rb_ftca_uspa_no.Checked = dtCust.Rows[0]["POWER_OF_ATTORNEY_USA_ADDRESS"].ToString() == "NO";

                    Rb_ftca_usaddr_yes.Checked = dtCust.Rows[0]["US_RESIDENCE_MAIL_ADDRESS"].ToString() == "YES";
                    Rb_ftca_usaddr_no.Checked = dtCust.Rows[0]["US_RESIDENCE_MAIL_ADDRESS"].ToString() == "NO";

                    Rb_ftca_ustn_yes.Checked = dtCust.Rows[0]["US_TELELPHONE_NUMBER"].ToString() == "YES";
                    Rb_ftca_ustn_no.Checked = dtCust.Rows[0]["US_TELELPHONE_NUMBER"].ToString() == "NO";
                    #endregion

                    #region RISK PROFILE
                    Rb_rpf_age_60.Checked = dtCust.Rows[0]["AGE"].ToString() == "ABOVE 60";
                    Rb_rpf_age_50.Checked = dtCust.Rows[0]["AGE"].ToString() == "50-60";
                    Rb_rpf_age_40.Checked = dtCust.Rows[0]["AGE"].ToString() == "40-50";
                    Rb_rpf_age_39.Checked = dtCust.Rows[0]["AGE"].ToString() == "BELOW 40";

                    Rb_rpf_rtl_lr.Checked = dtCust.Rows[0]["RISK_RETURN_TOLERENCE_LEVEL"].ToString() == "LOWER RISK, LOWER RETURN";
                    Rb_rpf_rtl_hr.Checked = dtCust.Rows[0]["RISK_RETURN_TOLERENCE_LEVEL"].ToString() == "HIGH RISK, HIGH RETURN";
                    Rb_rpf_rtl_mr.Checked = dtCust.Rows[0]["RISK_RETURN_TOLERENCE_LEVEL"].ToString() == "MEDIUM RISK, MEDIUM RETURN";

                    Rb_rpf_ms_25.Checked = dtCust.Rows[0]["MONTHLY_SAVINGS"].ToString() == "Rs.1,000-Rs.25,000";
                    Rb_rpf_ms_50.Checked = dtCust.Rows[0]["MONTHLY_SAVINGS"].ToString() == "Rs.25,000-Rs.50,000";
                    Rb_rpf_ms_150.Checked = dtCust.Rows[0]["MONTHLY_SAVINGS"].ToString() == "RS.150,000-RS.500,000";
                    Rb_rpf_ms_500.Checked = dtCust.Rows[0]["MONTHLY_SAVINGS"].ToString() == "More than Rs.50,000";

                    Rb_rpf_oc_slrd.Checked = dtCust.Rows[0]["OCCUPATION_RPF"].ToString() == "SALARIED";
                    Rb_rpf_oc_hws.Checked = dtCust.Rows[0]["OCCUPATION_RPF"].ToString() == "HOUSEWIFE/STUDENT";
                    Rb_rpf_oc_rtd.Checked = dtCust.Rows[0]["OCCUPATION_RPF"].ToString() == "RETIRED";
                    Rb_rpf_oc_bse.Checked = dtCust.Rows[0]["OCCUPATION_RPF"].ToString() == "BUSINESS/SELF-EMPLOYED";


                    Rb_rpf_ib_cm.Checked = dtCust.Rows[0]["INVESTMENT_OBJECTIVE"].ToString() == "CASH MANAGEMENT";
                    Rb_rpf_ib_mi.Checked = dtCust.Rows[0]["INVESTMENT_OBJECTIVE"].ToString() == "MONTHLY INCOME";
                    Rb_rpf_ib_lts.Checked = dtCust.Rows[0]["INVESTMENT_OBJECTIVE"].ToString() == "CAPITAL GROWTH/LONG TERM SAVINGS";
                    Rb_rpf_ib_rtmnt.Checked = dtCust.Rows[0]["INVESTMENT_OBJECTIVE"].ToString() == "RETIREMENT";

                    Rb_rpf_kifm_bk.Checked = dtCust.Rows[0]["KNOWLEDGE_LEVEL"].ToString() == "BASIC";
                    Rb_rpf_kifm_lk.Checked = dtCust.Rows[0]["KNOWLEDGE_LEVEL"].ToString() == "LIMITED KNOWLEDGE";
                    Rb_rpf_kifm_ak.Checked = dtCust.Rows[0]["KNOWLEDGE_LEVEL"].ToString() == "AVERAGE";
                    Rb_rpf_kifm_gk.Checked = dtCust.Rows[0]["KNOWLEDGE_LEVEL"].ToString() == "GOOD";
                    Rb_rpf_kifm_ek.Checked = dtCust.Rows[0]["KNOWLEDGE_LEVEL"].ToString() == "EXCELLENT";

                    Rb_ih_6mnths.Checked = dtCust.Rows[0]["INVESTMENT_HORIZON"].ToString() == "LESS THAN 6 MONTHS";
                    Rb_rpf_ih_1yr.Checked = dtCust.Rows[0]["INVESTMENT_HORIZON"].ToString() == "LESS THEN 1 YEAR";
                    Rb_rpf_ih_23yr.Checked = dtCust.Rows[0]["INVESTMENT_HORIZON"].ToString() == "2-3 YEARS";
                    Rb_rpf_ih_35yr.Checked = dtCust.Rows[0]["INVESTMENT_HORIZON"].ToString() == "3-5 YEARS";
                    Rb_rpf_ih_5yr.Checked = dtCust.Rows[0]["INVESTMENT_HORIZON"].ToString() == "MORE THAN 5 YEARS";

                    #endregion

                    acc.CentralizedAccoutsLogs(txt_cnicnum.Text, string.Format("Edit form loaded"), Session["Username"].ToString());
                }
            }
            else
                acc.CentralizedAccoutsLogs(string.Empty, string.Format("New form loaded"), Session["Username"].ToString());
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //Session["CNIC"] = null;
    }
    //protected void btnHist_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/ChangesHistory.aspx");
    //}
    protected void btnedit_Click(object sender, EventArgs e)
    {
        //if (gvrJointHolder.Rows.Count > 0)
        //{
        //    ddloprt.Enabled = false;
        //    lblbankname.Enabled = false;
        //    lblbankaddress.Enabled = false;
        //    lblAccountNo.Enabled = false;
        //    ddldivid.Enabled = false;
        //}
        //else
        //{
        //    ddloprt.Enabled = true;
        //    lblbankname.Enabled = true;
        //    lblbankaddress.Enabled = true;
        //    lblAccountNo.Enabled = true;
        //    ddldivid.Enabled = true;
        //}
        //ddlcour.Enabled = true;
        //lblname.Enabled = false;
        //lblfname.Enabled = false;
        //lbladdress.Enabled = true;
        //lblphone.Enabled = true;
        //lblmobile.Enabled = true;
        //lblemail.Enabled = true;
        //lblfmr.Enabled = true;
        //lblprisms.Enabled = true;
        //lblpriemail.Enabled = true;
        //btnclear.Visible = true;
        //btnedit.Visible = false;
        //btnsubmit.Visible = true;
        //gvrJointHolder.Visible = false;
        ////Label6.Text = "Change in Profile Form";
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        // string CNIC = ((TextBox).FindControl("txt_cnicnum")).Text;
        //   string CNIC =
        //string CNIC = Request.Form["txt_cnicnum"];
        //string CNIC = 
        // string ACCOUNT_TYPE=Request.Form["ddloactype"];
        //string CUSTOMER_NAME = Request.Form["txt_name"];
        //string FATHER_HUSBAND_NAME = Request.Form["txt_fathername"];
        //string MARITAL_STATUS = Request.Form["txt_maritalstatus"];
        //string DATE_OF_BIRTH = Request.Form["txt_date_of_birth"];
        //string NATIONALITY = Request.Form["txt_nationality"];
        //string RELIGON = Request.Form["txt_religon"];
        //string CNIC_EXPIRY_DATE = Request.Form["txt_cnic_expiry"];
        //string ADDRESS = Request.Form["txt_address"];
        //string RESIDENCE_CITY = Request.Form["txt_residence"];
        //string COUNTRY = Request.Form["txt_country"];
        //string MOBILE = Request.Form["txt_cstm_mobilenumber"];
        //string OFF_NUMBER = Request.Form["txt_cstm_officenumber"];
        //string RESIDENTIAL_NUMBER = Request.Form["txt_cstm_phonenumber"];
        //string EMAIL = Request.Form["txt_email"];
        //// string ACC_MINOR_CASE=Request.Form[""];
        //string ACC_MINOR_RELATIONSHIP = Request.Form["txt_cstm_mnr_rwp"];
        //string ACC_MINOR_GUARDIAN_NAME = Request.Form["txt_cstm_mnr_ng"];
        //string ACC_GUARDIAN_CNIC = Request.Form["txt_cstm_mnr_gcnic"];
        //string ACC_GUARDIAN_CNIC_EXPIRY = Request.Form["txt_cstm_mnr_cnic_expiry"];
        //string BANK_ACC_NUMBER = Request.Form["txt_cstm_accountname"];
        //string BANK_NAME = Request.Form["txt_cstm_bankname"];
        ////  string BRANCH_NAME = Request.Form[""];  //  control to be created 
        //// string BRANCH_CITY                    // control to be created      
        ////string ACCOUNT_OPERATING_INSTRUCTION = Request.Form["ddloprt"];
        ////string DIVIDEND_MANDATE
        //// string BONUS_MANDATE
        //string EXPECTED_RETIREMENT_AGE = Request.Form["retirement_age"];
        ////string ALLOCATION_SCHEME = Request.Form["ddlomtpfac"];
        //// DateTime dt = DateTime;
        //DateTime date = DateTime.Now.Date;
        //string TIME_STAMP = date.ToString("MM/dd/yyyy");
        //bool flag = false;
        //if (lblnamesub.Text == lblnamesub.Text)
        //{
        //    lblnamesub.Text = "";
        //}
        //else
        //{
        //    lblnamesub.Text = lblnamesub.Text;
        //    flag = true;
        //}
        //if (lblfnamesub.Text == lblfname.Text)
        //{
        //    lblfnamesub.Text = "";
        //}
        //else
        //{
        //    lblfnamesub.Text = lblfname.Text;
        //    flag = true;
        //}
        //    if (lbladdresssub.Text == lbladdress.Text)
        //    {
        //        lbladdresssub.Text = "";
        //    }
        //    else
        //    {
        //        lbladdresssub.Text = lbladdress.Text;
        //        flag = true;
        //    }
        //    if (lblphonesub.Text == lblphone.Text)
        //    {
        //        lblphonesub.Text = "";
        //    }
        //    else
        //    {
        //        lblphonesub.Text = lblphone.Text;
        //        flag = true;
        //    }
        //    if (lblmobilesub.Text == lblmobile.Text)
        //    {
        //        lblmobilesub.Text = "";
        //    }
        //    else
        //    {
        //        lblmobilesub.Text = lblmobile.Text;
        //        flag = true;
        //    }
        //    if (lblemailsub.Text == lblemail.Text)
        //    {
        //        lblemailsub.Text = "";
        //    }
        //    else
        //    {
        //        lblemailsub.Text = lblemail.Text;
        //        flag = true;
        //    }
        //    if (lblcoursub.Text == ddlcour.SelectedValue)
        //    {
        //        lblcoursub.Text = "";
        //    }
        //    else
        //    {
        //        lblcoursub.Text = ddlcour.SelectedValue;
        //        flag = true;
        //    }
        //    if (lbldividsub.Text == ddldivid.SelectedValue)
        //    {
        //        lbldividsub.Text = "";
        //    }
        //    else
        //    {
        //        lbldividsub.Text = ddldivid.SelectedValue;
        //        flag = true;
        //    }
        //    if (lbloprtsub.Text == ddloprt.SelectedValue)
        //    {
        //        lbloprtsub.Text = "";
        //    }
        //    else
        //    {
        //        lbloprtsub.Text = ddloprt.SelectedValue;
        //        flag = true;
        //    }
        //    if (lblbanknamesub.Text == lblbankname.Text)
        //    {
        //        lblbanknamesub.Text = "";
        //    }
        //    else
        //    {
        //        lblbanknamesub.Text = lblbankname.Text;
        //        flag = true;
        //    }
        //    if (lblbankaddresssub.Text == lblbankaddress.Text)
        //    {
        //        lblbankaddresssub.Text = "";
        //    }
        //    else
        //    {
        //        lblbankaddresssub.Text = lblbankaddress.Text;
        //        flag = true;
        //    }
        //    if (lblAccountNosub.Text == lblAccountNo.Text)
        //    {
        //        lblAccountNosub.Text = "";
        //    }
        //    else
        //    {
        //        lblAccountNosub.Text = lblAccountNo.Text;
        //        flag = true;
        //    }
        //    if (flag == true)
        //    {
        //        //MainPanel.Visible = false;
        //        Submit.Visible = true;
        //    }
        //    else
        //    {
        //        lbladdresssub.Text = lbladdress.Text;
        //        lblAccountNosub.Text = lblAccountNo.Text;
        //        lblbankaddresssub.Text = lblbankaddress.Text;
        //        lblbanknamesub.Text = lblbankname.Text;
        //        lbloprtsub.Text = ddloprt.SelectedValue;
        //        lblemailsub.Text = lblemail.Text;
        //        lblmobilesub.Text = lblmobile.Text;
        //        lblphonesub.Text = lblphone.Text;
        //        lbladdresssub.Text = lbladdress.Text;
        //        lbldividsub.Text = ddldivid.SelectedValue;
        //        lblcoursub.Text = ddlcour.SelectedValue;
        //    }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        ////MainPanel.Visible = true;
        //Submit.Visible = false;
        //lbladdresssub.Text = lbladdress.Text;
        //lblAccountNosub.Text = lblAccountNo.Text;
        //lblbankaddresssub.Text = lblbankaddress.Text;
        //lblbanknamesub.Text = lblbankname.Text;
        //lbloprtsub.Text = ddloprt.SelectedValue;
        //lblemailsub.Text = lblemail.Text;
        //lblmobilesub.Text = lblmobile.Text;
        //lblphonesub.Text = lblphone.Text;
        //lbladdresssub.Text = lbladdress.Text;
        //lbldividsub.Text = ddldivid.SelectedValue;
        //lblcoursub.Text = ddlcour.SelectedValue;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    DataTable data = cls.GetDataTable("select isnull(max(right(requestid,len(requestid)-5)),0) from [dbo].[Customer_Changes]");
        //    string ID = "MSREQ" + (Convert.ToDouble(data.Rows[0][0]) + 1).ToString().PadLeft(7, '0').ToString();
        //    cls.ExecuteNonQuery(" insert into Customer_Changes values ('" + ID + "','" + lblportfolioidsub.Text + "','" + lblnamesub.Text + "','" + lblfnamesub.Text + "','" + lbladdresssub.Text + "','" + lblphonesub.Text + "','" + lblmobilesub.Text + "','" + lblemailsub.Text + "','" + lblcoursub.Text + "','" + lbldividsub.Text + "','" + lbloprtsub.Text + "','" + lblbanknamesub.Text + "','" + lblAccountNosub.Text + "','" + lblbankaddresssub.Text + "','Open','" + DateTime.Now.ToString("yyyyMMdd") + "')");
        //    lblMessage.Text = "Your Request has been Submited. Request ID = " + ID;
        //    lblMessage.ForeColor = Color.Green;
        //    lblMessage.Visible = true;
        //    //MainPanel.Visible = true;
        //    gvrJointHolder.Visible = true;
        //    Submit.Visible = false;
        //    btnsubmit.Visible = false;
        //    btnedit.Visible = true;
        //    lblname.Enabled = false;
        //    lblfname.Enabled = false;
        //    lbladdress.Enabled = false;
        //    lblphone.Enabled = false;
        //    lblmobile.Enabled = false;
        //    lblemail.Enabled = false;
        //    lblfmr.Enabled = false;
        //    lblprisms.Enabled = false;
        //    lblpriemail.Enabled = false;
        //    ddloprt.Enabled = false;
        //    ddlcour.Enabled = false;
        //    ddldivid.Enabled = false;
        //    lblbankname.Enabled = false;
        //    lblbankaddress.Enabled = false;
        //    lblAccountNo.Enabled = false;


        //    //Label6.Text = "Portfolio Wise Profile Information";
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message.ToString();
        //    lblMessage.ForeColor = Color.Red;
        //    lblMessage.Visible = true;
        //}

    }

    protected void ftca_ctrotp_other(object sender, EventArgs e)
    {
        txt_ftca_ctrotp_other_cntry.Visible = true;
        panel_kycdetails.Visible = false;

        Rb_ftca_uscitizen_yes.Enabled = Rb_ftca_uscitizen_no.Enabled
                = Rb_ftca_usresdnt_yes.Enabled = Rb_ftca_usresdnt_no.Enabled
                = Rb_ftca_usgc_yes.Enabled = Rb_ftca_usgc_no.Enabled
                = Rb_ftca_usborn_yes.Enabled = Rb_ftca_usborn_no.Enabled
                = Rb_ftca_ussitf_yes.Enabled = Rb_ftca_ussitf_no.Enabled
                = Rb_ftca_uspa_yes.Enabled = Rb_ftca_uspa_no.Enabled
                = Rb_ftca_usaddr_yes.Enabled = Rb_ftca_usaddr_no.Enabled
                = Rb_ftca_ustn_yes.Enabled = Rb_ftca_ustn_no.Enabled = true;

    }

    protected void btnclear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlPortfolio_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddloactype_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddloactype.SelectedValue.ToUpper() == "MINOR")
        {
            panel_minor_account.Visible = true;
            panel_joint_acc_holder.Visible = false;
            panel_Operating_Instructions_ddlist.Visible = false;
            panel_nominee_details.Visible = false;
            panel_mtpf_ddlist.Visible = false;
            panel_kyc_j1.Visible = false;
            panel_kyc_j2.Visible = false;
        }
        if (ddloactype.SelectedValue.ToUpper() == "JOINT")
        {
            panel_joint_acc_holder.Visible = true;
            panel_Operating_Instructions_ddlist.Visible = true;
            panel_minor_account.Visible = false;
            panel_nominee_details.Visible = false;
            panel_mtpf_ddlist.Visible = false;
            panel_kyc_j1.Visible = true;
            //panel_kyc_j2.Visible = true;
        
        }
        if (ddloactype.SelectedValue.ToUpper() == "SINGLE")
        {
            panel_nominee_details.Visible = true;
            panel_joint_acc_holder.Visible = false;
            panel_Operating_Instructions_ddlist.Visible = false;
            panel_minor_account.Visible = false;
            panel_mtpf_ddlist.Visible = false;
            panel_kyc_j1.Visible = false;
            panel_kyc_j2.Visible = false;
        
        }
        if (ddloactype.SelectedValue.ToUpper() == "MTPF")
        {
            panel_nominee_details.Visible = true;
            panel_mtpf_ddlist.Visible = true;
            panel_joint_acc_holder.Visible = false;
            panel_Operating_Instructions_ddlist.Visible = false;
            panel_minor_account.Visible = false;
            panel_kyc_j1.Visible = false;
            panel_kyc_j2.Visible = false;
        }


    }

    protected void verify_cnic(object sender, EventArgs e)
    {
        Acc_opening acc_opening_verification = new Acc_opening();
        bool verification;

        verification = acc_opening_verification.verify_cnic(txt_cnicnum.Text);
        if (verification == true)
        {
            txt_cnicnum.Text = string.Empty;

        }
        else
        {

            //btn_verify_cnic.Visible = false;
        }

    }

    protected void btn_next_click_fatca(object sender, EventArgs e)
    {

        if (txt_ftca_acctitle.Text == "" || txt_ftca_pob_city.Text == "" || txt_ftca_pob_bstate.Text == "" || txt_ftca_pob_birthcountry.Text == "")
        {

            if (txt_ftca_pob_city.Text == "") { lbl_main_ftca_city.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_ftca_city.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_ftca_pob_bstate.Text == "") { lbl_main_ftca_state.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_ftca_state.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_ftca_pob_birthcountry.Text == "") { lbl_main_ftca_country.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_ftca_country.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }



            panel_fatca.Visible = true;

            //panel_error_mesg.Visible = true;
            //mystage_.Text = "fatca";
            ////mystage = "fatca";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;

            return;

        }

        if (Rb_ftca_ctrotp_none.Checked == false && Rb_ftca_ctrotp_USA.Checked == false && Rb_ftca_ctrotp_other.Checked == false)
        {

            lbl_main_ftca_tax_country.ForeColor = System.Drawing.Color.Red;
            panel_fatca.Visible = true;
            panel_kycdetails.Visible = false;
            return;

        }
        else { lbl_main_ftca_tax_country.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_ftca_ctrotp_other.Checked == true && txt_ftca_ctrotp_other_cntry.Text == "")
        {
            lbl_main_ftca_tax_country.ForeColor = System.Drawing.Color.Red;
            panel_fatca.Visible = true;
            panel_kycdetails.Visible = false;
            return;
        }
        else { lbl_main_ftca_tax_country.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (!Rb_ftca_ctrotp_none.Checked)
        {

            if (Rb_ftca_uscitizen_yes.Checked == false && Rb_ftca_uscitizen_no.Checked == false)
            {

                lbl_main_ftca_uscitizen.ForeColor = System.Drawing.Color.Red;

                panel_fatca.Visible = true;
                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;

            }
            else { lbl_main_ftca_uscitizen.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


            if (Rb_ftca_usresdnt_yes.Checked == false && Rb_ftca_usresdnt_no.Checked == false)
            {
                lbl_main_ftca_usresident.ForeColor = System.Drawing.Color.Red;

                panel_fatca.Visible = true;
                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;
            }
            else { lbl_main_ftca_usresident.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


            if (Rb_ftca_usgc_yes.Checked == false && Rb_ftca_usgc_no.Checked == false)
            {


                lbl_main_ftca_usgreen_card.ForeColor = System.Drawing.Color.Red;
                panel_fatca.Visible = true;
                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;
            }
            else { lbl_main_ftca_usgreen_card.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_ftca_usborn_yes.Checked == false && Rb_ftca_usborn_no.Checked == false)
            {

                lbl_main_ftca_us_born.ForeColor = System.Drawing.Color.Red;
                panel_fatca.Visible = true;

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;
            }
            else { lbl_main_ftca_us_born.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_ftca_ussitf_yes.Checked == false && Rb_ftca_ussitf_no.Checked == false)
            {

                lbl_main_ftca_ussitf.ForeColor = System.Drawing.Color.Red;
                panel_fatca.Visible = true;

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;
            }
            else { lbl_main_ftca_ussitf.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (Rb_ftca_uspa_yes.Checked == false && Rb_ftca_uspa_no.Checked == false)
            {

                lbl_main_ftca_uspa.ForeColor = System.Drawing.Color.Red;
                panel_fatca.Visible = true;

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;
            }
            else { lbl_main_ftca_uspa.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_ftca_usaddr_yes.Checked == false && Rb_ftca_usaddr_no.Checked == false)
            {

                lbl_main_ftca_usaddr.ForeColor = System.Drawing.Color.Red;
                panel_fatca.Visible = true;

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;
            }
            else { lbl_main_ftca_usaddr.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_ftca_ustn_yes.Checked == false && Rb_ftca_ustn_no.Checked == false)
            {

                lbl_main_ftca_ustn.ForeColor = System.Drawing.Color.Red;
                panel_fatca.Visible = true;

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "fatca";
                ////mystage = "fatca";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;

                return;
            }
            else { lbl_main_ftca_ustn.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        }
        panel_fatca.Visible = false;
        panel_riskprofileform.Visible = true;
        panel_kycdetails.Visible = false;
        btn_submit.Visible = false;

        acc_opening.CentralizedAccoutsLogs(txt_cnicnum.Text, "Fatca information filled", Session["Username"].ToString());
    }

    protected void btn_back_click_fatca(object sender, EventArgs e)
    {
        panel1.Visible = true;
        panel_kycdetails.Visible = true;

        if (ddloactype.SelectedValue == "SINGLE") { panel_nominee_details.Visible = true; }

        if (ddloactype.SelectedValue == "MINOR") { panel_minor_account.Visible = true; }

        // panel_minor_account.Visible = true;
        if (ddloactype.SelectedValue == "MTPF") { panel_mtpf_ddlist.Visible = true; panel_nominee_details.Visible = true; }

        //panel_mtpf_ddlist.Visible = true;
        if (ddloactype.SelectedValue == "JOINT") { panel_joint_acc_holder.Visible = true; panel_Operating_Instructions_ddlist.Visible = true; }

        //panel_joint_acc_holder.Visible = true;
        // panel_Operating_Instructions_ddlist.Visible = true;

        panel_fatca.Visible = false;

        btn_next.Visible = true;

    }



    protected void btn_next_click_rpf(object sender, EventArgs e)
    {

        ///////////////// setting preview page ///////////////////////////

        if (Rb_rpf_age_39.Checked == false && Rb_rpf_age_40.Checked == false && Rb_rpf_age_50.Checked == false && Rb_rpf_age_60.Checked == false)
        {
            lbl_main_rpf_age.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;
            return;

        }
        else { lbl_main_rpf_age.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (Rb_rpf_rtl_lr.Checked == false && Rb_rpf_rtl_mr.Checked == false && Rb_rpf_rtl_hr.Checked == false)
        {
            lbl_main_rpf_rrtl.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;
            return;
        }
        else { lbl_main_rpf_rrtl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_rpf_ms_25.Checked == false && Rb_rpf_ms_50.Checked == false && Rb_rpf_ms_150.Checked == false && Rb_rpf_ms_500.Checked == false)
        {
            lbl_main_rpf_ms.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;
            return;
        }
        else { lbl_main_rpf_ms.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_rpf_oc_rtd.Checked == false && Rb_rpf_oc_hws.Checked == false && Rb_rpf_oc_slrd.Checked == false && Rb_rpf_oc_bse.Checked == false)
        {
            lbl_main_rpf_occupation.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;

            return;
        }
        else { lbl_main_rpf_occupation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (Rb_rpf_ib_cm.Checked == false && Rb_rpf_ib_mi.Checked == false && Rb_rpf_ib_lts.Checked == false && Rb_rpf_ib_rtmnt.Checked == false)
        {
            lbl_main_rpf_ib.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;

            return;
        }
        else { lbl_main_rpf_ib.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (Rb_rpf_kifm_lk.Checked == false && Rb_rpf_kifm_ak.Checked == false && Rb_rpf_kifm_gk.Checked == false && Rb_rpf_kifm_bk.Checked == false && Rb_rpf_kifm_ek.Checked == false)
        {

            lbl_main_rpf_kifm.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;

            return;
        }
        else { lbl_main_rpf_kifm.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (Rb_rpf_ih_1yr.Checked == false && Rb_rpf_ih_5yr.Checked == false && Rb_rpf_ih_35yr.Checked == false && Rb_rpf_ih_23yr.Checked == false && Rb_ih_6mnths.Checked == false)
        {

            lbl_main_rpf_ih.ForeColor = System.Drawing.Color.Red;
            panel_riskprofileform.Visible = true;
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "rpf";
            //mystage = "rpf";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;

            return;
        }
        else { lbl_main_rpf_ih.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        _REPORTCNIC = txt_cnicnum.Text;

        lbl_cnic_prv.Text = txt_cnicnum.Text.ToUpper();
        lbl_name_prv.Text = txt_name.Text.ToUpper();
        lbl_fname_prv.Text = txt_fathername.Text.ToUpper();
        //lbl_maritalstatus_prv.Text = txt_maritalstatus.Text.ToUpper();
        lbl_maritalstatus_prv.Text = ddlMaritalStatus.SelectedItem.Text.ToUpper();
        lbl_Date_of_Birth.Text = txt_date_of_birth.Text.ToUpper();
        lbl_CNIC_Expiry_Date.Text = txt_cnic_expiry.Text.ToUpper();
        lbl_CNIC_Issue_Date.Text = txt_cnic_issue.Text.ToUpper();
        lbl_nationality_prv.Text = txt_nationality.Text.ToUpper();
        // lbl_Religon_prv.Text = txt_religon.Text.ToUpper();

        lbl_Religon_prv.Text = ddl_religon.SelectedItem.Text.ToUpper();

        lbl_Address_prv.Text = txt_address.Text.ToUpper();
        lbl_EmailAddress_prv.Text = txt_email.Text.ToUpper();
        lbl_Residense_city_prv.Text = string.IsNullOrEmpty(txt_city.Text) ? ddl_City.SelectedItem.Text : txt_city.Text.ToUpper();
        lbl_country_prv.Text = ddlCountry.SelectedItem.Text;
        lbl_Phone_Number_prv.Text = txt_cstm_phonenumber.Text.ToUpper();
        lbl_Mobile_Number_prv.Text = txtOtherMobile.Visible ? txtOtherMobile.Text : ddlMobileCode.SelectedItem.Text + txt_cstm_mobilenumber.Text + "(" + ddlMobileType.SelectedItem.Value + ")";
        lbl_Office_number_prv.Text = txt_cstm_officenumber.Text.ToUpper();
        lbl_BankName_prv.Text = txt_cstm_bankname.Visible ? txt_cstm_bankname.Text.ToUpper() : ddlBanks.SelectedItem.Text;
        lbl_AccountNumber_prv.Text = txt_cstm_accountname.Text.ToUpper();
        lbl_Branch_Name_prv.Text = txt_branch_name.Text.ToUpper();
        ///////////////////////fatca  details //////////////////

        lbl_ftca_Account_title_prv.Text = txt_ftca_acctitle.Text.ToUpper();
        if (Rb_ftca_ctrotp_none.Checked == true) { lbl_ftca_ctrp_prv.Text = "NONE"; }
        if (Rb_ftca_ctrotp_USA.Checked == true) { lbl_ftca_ctrp_prv.Text = "USA"; }
        if (Rb_ftca_ctrotp_other.Checked == true) { lbl_ftca_ctrp_prv.Text = txt_ftca_ctrotp_other_cntry.Text; }
        lbl_ftca_pob_city.Text = txt_ftca_pob_city.Text.ToUpper();
        lbl_ftca_pob_state.Text = txt_ftca_pob_bstate.Text.ToUpper();
        lbl_ftca_pob_country.Text = txt_ftca_pob_birthcountry.Text.ToUpper();
        if (Rb_ftca_uscitizen_yes.Checked == true)
        {
            lbl_ftca_uscitizen_prv.Text = "YES";
        }
        else { lbl_ftca_uscitizen_prv.Text = "NO"; }
        if (Rb_ftca_usresdnt_yes.Checked == true)
        {
            lbl_ftca_usresident_prv.Text = "YES";
        }
        else
        {
            lbl_ftca_usresident_prv.Text = "NO";
        }
        if (Rb_ftca_usgc_yes.Checked == true)
        {
            lbl_ftca_usgreencrd_prv.Text = "YES";
        }
        else
        {
            lbl_ftca_usgreencrd_prv.Text = "NO";
        }


        if (Rb_ftca_ussitf_yes.Checked == true)
        {
            lbl_ftca_sitfausa_prv.Text = "YES";
        }
        else
        {
            lbl_ftca_sitfausa_prv.Text = "NO";
        }
        if (Rb_ftca_uspa_yes.Checked == true)
        {
            lbl_ftca_pwratt_prv.Text = "YES";
        }
        else
        {
            lbl_ftca_pwratt_prv.Text = "NO";
        }

        if (Rb_ftca_ustn_yes.Checked == true)
        {
            lbl_ftca_ustelenum_prv.Text = "YES";
        }
        else
        {
            lbl_ftca_ustelenum_prv.Text = "NO";
        }



        ///////////////////////fatca details //////////////////

        ///////////////////////rpf details //////////////////
        int AGERPF = 0; int RRTL = 0; int MS = 0; int OCCP = 0; int IO = 0; int KNOWLEDGE = 0; int IH = 0;
        if (Rb_rpf_age_39.Checked == true) { lbl_rpf_age_prv.Text = "BELOW 40"; AGERPF = 4; Session["rpf_age"] = "BELOW 40"; }
        if (Rb_rpf_age_40.Checked == true) { lbl_rpf_age_prv.Text = "40-50"; AGERPF = 3; Session["rpf_age"] = "40-50"; }
        if (Rb_rpf_age_50.Checked == true) { lbl_rpf_age_prv.Text = "50-60"; AGERPF = 2; Session["rpf_age"] = "50-60"; }
        if (Rb_rpf_age_60.Checked == true) { lbl_rpf_age_prv.Text = "ABOVE 60"; AGERPF = 1; Session["rpf_age"] = "ABOVE 60"; }
        //////////////////////////////////////////////////////////////////////      
        if (Rb_rpf_rtl_lr.Checked == true) { lbl_rpf_rrtl_prv.Text = Rb_rpf_rtl_lr.Text.ToUpper(); RRTL = 1; Session["rpf_rtl"] = Rb_rpf_rtl_lr.Text.ToUpper(); }
        if (Rb_rpf_rtl_mr.Checked == true) { lbl_rpf_rrtl_prv.Text = Rb_rpf_rtl_mr.Text.ToUpper(); RRTL = 4; Session["rpf_rtl"] = Rb_rpf_rtl_mr.Text.ToUpper(); }
        if (Rb_rpf_rtl_hr.Checked == true) { lbl_rpf_rrtl_prv.Text = Rb_rpf_rtl_hr.Text.ToUpper(); RRTL = 8; Session["rpf_rtl"] = Rb_rpf_rtl_hr.Text.ToUpper(); }
        /////////////////////////////////////////////////////////////////////
        if (Rb_rpf_ms_25.Checked == true) { lbl_rpf_ms_prv.Text = Rb_rpf_ms_25.Text.ToUpper(); MS = 2; Session["rpf_ms"] = Rb_rpf_ms_25.Text.ToUpper(); }
        if (Rb_rpf_ms_50.Checked == true) { lbl_rpf_ms_prv.Text = Rb_rpf_ms_50.Text.ToUpper(); MS = 2; Session["rpf_ms"] = Rb_rpf_ms_50.Text.ToUpper(); }
        if (Rb_rpf_ms_150.Checked == true) { lbl_rpf_ms_prv.Text = Rb_rpf_ms_150.Text.ToUpper(); MS = 3; Session["rpf_ms"] = Rb_rpf_ms_150.Text.ToUpper(); }
        if (Rb_rpf_ms_500.Checked == true) { lbl_rpf_ms_prv.Text = Rb_rpf_ms_500.Text.ToUpper(); MS = 3; Session["rpf_ms"] = Rb_rpf_ms_500.Text.ToUpper(); }
        ////////////////////////////////////////////////////////////////////
        if (Rb_rpf_oc_rtd.Checked == true) { lbl_rpf_occ_prv.Text = Rb_rpf_oc_rtd.Text.ToUpper(); OCCP = 1; Session["rpf_occ"] = Rb_rpf_oc_rtd.Text.ToUpper(); }
        if (Rb_rpf_oc_hws.Checked == true) { lbl_rpf_occ_prv.Text = Rb_rpf_oc_hws.Text.ToUpper(); OCCP = 2; Session["rpf_occ"] = Rb_rpf_oc_hws.Text.ToUpper(); }
        if (Rb_rpf_oc_slrd.Checked == true) { lbl_rpf_occ_prv.Text = Rb_rpf_oc_slrd.Text.ToUpper(); OCCP = 3; Session["rpf_occ"] = Rb_rpf_oc_slrd.Text.ToUpper(); }
        if (Rb_rpf_oc_bse.Checked == true) { lbl_rpf_occ_prv.Text = Rb_rpf_oc_bse.Text.ToUpper(); OCCP = 4; Session["rpf_occ"] = Rb_rpf_oc_bse.Text.ToUpper(); }
        //////////////////////////////////////////////////////////////////////
        if (Rb_rpf_ib_cm.Checked == true) { lbl_rpf_io_prv.Text = Rb_rpf_ib_cm.Text.ToUpper(); IO = 2; Session["rpf_io"] = Rb_rpf_ib_cm.Text.ToUpper(); }
        if (Rb_rpf_ib_mi.Checked == true) { lbl_rpf_io_prv.Text = Rb_rpf_ib_mi.Text.ToUpper(); IO = 4; Session["rpf_io"] = Rb_rpf_ib_mi.Text.ToUpper(); }
        if (Rb_rpf_ib_lts.Checked == true) { lbl_rpf_io_prv.Text = Rb_rpf_ib_lts.Text.ToUpper(); IO = 8; Session["rpf_io"] = Rb_rpf_ib_lts.Text.ToUpper(); }
        if (Rb_rpf_ib_rtmnt.Checked == true) { lbl_rpf_io_prv.Text = Rb_rpf_ib_rtmnt.Text.ToUpper(); IO = 8; Session["rpf_io"] = Rb_rpf_ib_rtmnt.Text.ToUpper(); }
        ////////////////////////////////////////////////////////////////////////
        if (Rb_rpf_kifm_lk.Checked == true) { lbl_rpf_kifm_prv.Text = Rb_rpf_kifm_lk.Text.ToUpper(); KNOWLEDGE = 2; Session["rpf_kifm"] = Rb_rpf_kifm_lk.Text.ToUpper(); }
        if (Rb_rpf_kifm_ak.Checked == true) { lbl_rpf_kifm_prv.Text = Rb_rpf_kifm_ak.Text.ToUpper(); KNOWLEDGE = 2; Session["rpf_kifm"] = Rb_rpf_kifm_ak.Text.ToUpper(); }
        if (Rb_rpf_kifm_bk.Checked == true) { lbl_rpf_kifm_prv.Text = Rb_rpf_kifm_bk.Text.ToUpper(); KNOWLEDGE = 2; Session["rpf_kifm"] = Rb_rpf_kifm_bk.Text.ToUpper(); }
        if (Rb_rpf_kifm_gk.Checked == true) { lbl_rpf_kifm_prv.Text = Rb_rpf_kifm_gk.Text.ToUpper(); KNOWLEDGE = 3; Session["rpf_kifm"] = Rb_rpf_kifm_gk.Text.ToUpper(); }
        if (Rb_rpf_kifm_ek.Checked == true) { lbl_rpf_kifm_prv.Text = Rb_rpf_kifm_ek.Text.ToUpper(); KNOWLEDGE = 3; Session["rpf_kifm"] = Rb_rpf_kifm_ek.Text.ToUpper(); }
        /////////////////////////////////////////////////////////////////////////////////////
        if (Rb_rpf_ih_1yr.Checked == true) { lbl_rpf_ih_prv.Text = Rb_rpf_ih_1yr.Text.ToUpper(); IH = 4; Session["rpf_ih"] = Rb_rpf_ih_1yr.Text.ToUpper(); }
        if (Rb_rpf_ih_5yr.Checked == true) { lbl_rpf_ih_prv.Text = Rb_rpf_ih_5yr.Text.ToUpper(); IH = 8; Session["rpf_ih"] = Rb_rpf_ih_5yr.Text.ToUpper(); }
        if (Rb_rpf_ih_35yr.Checked == true) { lbl_rpf_ih_prv.Text = Rb_rpf_ih_35yr.Text.ToUpper(); IH = 8; Session["rpf_ih"] = Rb_rpf_ih_35yr.Text.ToUpper(); }
        if (Rb_rpf_ih_23yr.Checked == true) { lbl_rpf_ih_prv.Text = Rb_rpf_ih_23yr.Text.ToUpper(); IH = 6; Session["rpf_ih"] = Rb_rpf_ih_23yr.Text.ToUpper(); }
        if (Rb_ih_6mnths.Checked == true) { lbl_rpf_ih_prv.Text = Rb_ih_6mnths.Text.ToUpper(); IH = 2; Session["rpf_ih"] = Rb_ih_6mnths.Text.ToUpper(); }

        int sum = IH + KNOWLEDGE + IO + OCCP + MS + RRTL + AGERPF;
        if (sum >= 33)
        {
            lbl_rpf_idealport_prv.Text = Rb_rpf_scr_38.Text;

        }
        if (sum >= 24 && sum <= 32)
        {

            lbl_rpf_idealport_prv.Text = Rb_rpf_scr_32.Text;

        }
        if (sum >= 15 && sum <= 23)
        {

            lbl_rpf_idealport_prv.Text = Rb_rpf_scr_23.Text;

        }

        if (sum >= 11 && sum <= 14)
        {

            lbl_rpf_idealport_prv.Text = Rb_rpf_scr_14.Text;

        }

        ///////////////////////rpf details //////////////////


        ///////////////////////kyc details //////////////////

        if (Rb_cstm_kyc_ocptn_gservices.Checked == true) { lbl_OCCUPATION_prv.Text = Rb_cstm_kyc_ocptn_gservices.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_pservices.Checked == true) { lbl_OCCUPATION_prv.Text = Rb_cstm_kyc_ocptn_pservices.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_selfemplyd.Checked == true) { lbl_OCCUPATION_prv.Text = Rb_cstm_kyc_ocptn_selfemplyd.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_retired.Checked == true) { lbl_OCCUPATION_prv.Text = Rb_cstm_kyc_ocptn_retired.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_hwife.Checked == true) { lbl_OCCUPATION_prv.Text = Rb_cstm_kyc_ocptn_hwife.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_student.Checked == true) { lbl_OCCUPATION_prv.Text = Rb_cstm_kyc_ocptn_student.Text.ToUpper(); }

        if (Rb_cstm_kyc_soi_business.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_business.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_salary.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_salary.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_pensions.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_pensions.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_inheritances.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_inheritances.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_remittances.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_remittances.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_saving.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_saving.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_stocks.Checked == true) { lbl_SOURCE_OF_INCOME_prv.Text = Rb_cstm_kyc_soi_stocks.Text.ToUpper(); }
        lbl_Name_of_business.Text = txt_cstm_kyc_noeb.Text.ToUpper();


        if (Rb_cstm_kyc_firoa_yes.Checked == true)
        {
            lbl_firoa_prv.Text = "YES";
        }
        else
        {
            lbl_firoa_prv.Text = "NO";

        }
        if (Rb_cstm_kyc_abop_yes.Checked == true)
        {
            lbl_abop_prv.Text = "YES";
        }
        else
        {
            lbl_abop_prv.Text = "NO";

        }
        if (Rb_cstm_kyc_spgi_yes.Checked == true)
        {
            lbl_spgi_prv.Text = "YES";
        }
        else
        {
            lbl_spgi_prv.Text = "NO";

        }

        if (Rb_cstm_kyc_sppp_yes.Checked == true)
        {
            lbl_sppp_prv.Text = "YES";
        }
        else
        {
            lbl_sppp_prv.Text = "NO";
        }
        if (Rb_cstm_kyc_hvitem_yes.Checked == true)
        {
            lbl_hitems_prv.Text = "YES";
        }
        else
        {
            lbl_hitems_prv.Text = "NO";
        }
        lbl_hereaboutus_prv.Text = ddl_kycq7.SelectedValue;

        ///////////////////////kyc details //////////////////


        if (Rb_cstm_dm_cd_reinvest.Checked == true)
        {

            lbl_Cash_Divident_prv.Text = Rb_cstm_dm_cd_reinvest.Text;
            //return reinvest;

        }
        else
        {

            lbl_Cash_Divident_prv.Text = Rb_cstm_dm_cd_providecash.Text;
            //      return provide_cash;

        }

        if (Rb_cstm_dm_sd_ibu.Checked == true)
        {
            lbl_Stock_Divident_prv.Text = Rb_cstm_dm_sd_ibu.Text;
        }
        else
        {
            lbl_Stock_Divident_prv.Text = Rb_cstm_dm_sd_ebu.Text;
            //      return provide_cash;
        }


        //lbl_Cash_Divident_prv.Text=;
        //lbl_Stock_Divident_prv.Text;
        lbl_Account_Type_prv.Text = ddloactype.SelectedValue;

        if (ddloactype.SelectedValue != "MINOR")
        {

            lbl_acctminr_main.Visible = false;
            lbl_acctminr_gname_hd.Visible = false;
            lbl_acctminr_gcnic_hd.Visible = false;
            lbl_acctminr_grwp_hd.Visible = false;
            lbl_acctminr_cedate_hd.Visible = false;

            lbl_acctminr_gname_prv.Visible = false;
            lbl_acctminr_gcnic_prv.Visible = false;
            lbl_acctminr_grwp_prv.Visible = false;
            lbl_acctminr_cedate_prv.Visible = false;

        }


        if (ddloactype.SelectedValue == "MINOR")
        {
            lbl_acctminr_gname_prv.Visible = true;
            lbl_acctminr_gcnic_prv.Visible = true;
            lbl_acctminr_grwp_prv.Visible = true;
            lbl_acctminr_cedate_prv.Visible = true;
            lbl_acctminr_gname_prv.Text = txt_cstm_mnr_ng.Text;
            lbl_acctminr_gcnic_prv.Text = txt_cstm_mnr_gcnic.Text;
            // lbl_acctminr_grwp_prv.Text = txt_cstm_mnr_rwp.Text;

            lbl_acctminr_grwp_prv.Text = ddlRelationWithPrinciple_mnr.SelectedItem.Text.ToUpper();


            lbl_acctminr_cedate_prv.Text = txt_cstm_mnr_cnic_expiry.Text;
        }

        if (ddloactype.SelectedValue != "JOINT")
        {
            lbl_jh_main.Visible = false;
            lbl_jh_sub1.Visible = false;
            lbl_jh_sub2.Visible = false;
            lbl_jh_name1_hd.Visible = false;
            lbl_jh_cnic1_hd.Visible = false;
            lbl_jh_rwp1_hd.Visible = false;
            lbl_jh_name2_hd.Visible = false;
            lbl_jh_cnic2_hd.Visible = false;
            lbl_jh_rwp2_hd.Visible = false;


            lbl_jh_name1_prv.Visible = false;
            lbl_jh_cnic1_prv.Visible = false;
            lbl_jh_rwp1_prv.Visible = false;
            lbl_jh_name2_prv.Visible = false;
            lbl_jh_cnic2_prv.Visible = false;
            lbl_jh_rwp2_prv.Visible = false;
        }


        if (ddloactype.SelectedValue == "JOINT")
        {
            lbl_jh_name1_prv.Visible = true;
            lbl_jh_cnic1_prv.Visible = true;
            lbl_jh_rwp1_prv.Visible = true;
            lbl_jh_name2_prv.Visible = true;
            lbl_jh_cnic2_prv.Visible = true;
            lbl_jh_rwp2_prv.Visible = true;

            lbl_jh_name1_prv.Text = txt_cstm_jh_jhname1.Text;
            lbl_jh_cnic1_prv.Text = txt_cstm_jh_jhcnic1.Text;
            //lbl_jh_rwp1_prv.Text = txt_cstm_jh_jhrwp1.Text;

            lbl_jh_rwp1_prv.Text = ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper();

            if (txt_cstm_jh_jhname2.Text == "" || txt_cstm_jh_jhcnic2.Text == "")
            {
                lbl_jh_sub2.Visible = false;
                lbl_jh_name2_hd.Visible = false;
                lbl_jh_name2_prv.Visible = false;
                lbl_jh_cnic2_hd.Visible = false;
                lbl_jh_cnic2_prv.Visible = false;
                lbl_jh_rwp2_prv.Visible = false;
                lbl_jh_rwp2_hd.Visible = false;
            }
            else
            {
                lbl_jh_sub2.Visible = true;
                lbl_jh_cnic2_hd.Visible = true;
                lbl_jh_name2_hd.Visible = true;
                lbl_jh_rwp2_hd.Visible = true;
                lbl_jh_name2_prv.Text = txt_cstm_jh_jhname2.Text;
                lbl_jh_cnic2_prv.Text = txt_cstm_jh_jhcnic2.Text;
                //    lbl_jh_rwp2_prv.Text = txt_cstm_jh_jhrwp2.Text;

                lbl_jh_rwp2_prv.Text = ddlRelationWithPrinciple_J2.SelectedItem.Text.ToUpper();

            }

        }

        if (ddloactype.SelectedValue != "MTPF")
        {


            lbl_mtpf_main.Visible = false;
            lbl_erage_hd.Visible = false;
            lbl_Allocation_Scheme_hd.Visible = false;
            lbl_nominee_main.Visible = false;
            lbl_nominee_sub1.Visible = false;
            lbl_nominee_sub2.Visible = false;
            lbl_nominee_sub3.Visible = false;

            lbl_nominee_name1_hd.Visible = false;
            lbl_nominee_cnic1_hd.Visible = false;
            lbl_nominee_rwp1_hd.Visible = false;
            lbl_nominee_shr1_hd.Visible = false;
            lbl_nominee_name2_hd.Visible = false;
            lbl_nominee_cnic2_hd.Visible = false;
            lbl_nominee_rwp2_hd.Visible = false;
            lbl_nominee_shr2_hd.Visible = false;
            lbl_nominee_name3_hd.Visible = false;
            lbl_nominee_cnic3_hd.Visible = false;
            lbl_nominee_rwp3_hd.Visible = false;
            lbl_nominee_shr3_hd.Visible = false;

            lbl_erage_prv.Visible = false;
            lbl_Allocation_Scheme_prv.Visible = false;
            lbl_nominee_name1_prv.Visible = false;
            lbl_nominee_cnic1_prv.Visible = false;
            lbl_nominee_rwp1_prv.Visible = false;
            lbl_nominee_shr1_prv.Visible = false;
            lbl_nominee_name2_prv.Visible = false;
            lbl_nominee_cnic2_prv.Visible = false;
            lbl_nominee_rwp2_prv.Visible = false;
            lbl_nominee_shr2_prv.Visible = false;
            lbl_nominee_name3_prv.Visible = false;
            lbl_nominee_cnic3_prv.Visible = false;
            lbl_nominee_rwp3_prv.Visible = false;
            lbl_nominee_shr3_prv.Visible = false;
        }

        if (ddloactype.SelectedValue == "MTPF")
        {
            lbl_erage_prv.Visible = true;
            lbl_Allocation_Scheme_prv.Visible = true;

            if (txt_cstm_mtpf_nname1.Text != "" && txt_cstm_mtpf_ncnic1.Text != ""
                //&& txt_cstm_mtpf_nrwp1.Text != "" 
                && ddlRelationWithPrinciple_J2.SelectedItem.Text.ToUpper() != ""
                && txt_cstm_mtpf_sharing1.Text != "")
            {
                lbl_nominee_name1_prv.Visible = true;
                lbl_nominee_cnic1_prv.Visible = true;
                lbl_nominee_rwp1_prv.Visible = true;
                lbl_nominee_shr1_prv.Visible = true;
                lbl_nominee_name1_prv.Text = txt_cstm_mtpf_nname1.Text;
                lbl_nominee_cnic1_prv.Text = txt_cstm_mtpf_ncnic1.Text;
                lbl_nominee_rwp1_prv.Text = ddlRelationWithPrinciple_N1.SelectedItem.Text.ToUpper();
                lbl_nominee_shr1_prv.Text = txt_cstm_mtpf_sharing1.Text;
            }
            else
            {
                lbl_nominee_main.Visible = false;
                lbl_nominee_sub1.Visible = false;
                lbl_nominee_name3_hd.Visible = false;
                lbl_nominee_cnic3_hd.Visible = false;
                lbl_nominee_rwp3_hd.Visible = false;
                lbl_nominee_shr3_hd.Visible = false;
                //lbl_nominee_sub3.Visible = false;

                lbl_nominee_name1_prv.Visible = false;
                lbl_nominee_cnic1_prv.Visible = false;
                lbl_nominee_rwp1_prv.Visible = false;
                lbl_nominee_shr1_prv.Visible = false;
            }

            if (txt_cstm_mtpf_nname2.Text != "" && txt_cstm_mtpf_ncnic2.Text != ""
                //&& txt_cstm_mtpf_nrwp2.Text != "" 
                && ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper() != ""
                && txt_cstm_mtpf_sharing2.Text != "")
            {
                lbl_nominee_name2_prv.Visible = true;
                lbl_nominee_cnic2_prv.Visible = true;
                lbl_nominee_rwp2_prv.Visible = true;
                lbl_nominee_shr2_prv.Visible = true;
                lbl_nominee_name2_prv.Text = txt_cstm_mtpf_nname2.Text;
                lbl_nominee_cnic2_prv.Text = txt_cstm_mtpf_ncnic2.Text;
                //lbl_nominee_rwp2_prv.Text = txt_cstm_mtpf_nrwp2.Text;

                lbl_nominee_rwp2_prv.Text = ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper();


                lbl_nominee_shr2_prv.Text = txt_cstm_mtpf_sharing2.Text;

            }

            else
            {
                lbl_nominee_sub2.Visible = false;
                lbl_nominee_name3_hd.Visible = false;
                lbl_nominee_cnic3_hd.Visible = false;
                lbl_nominee_rwp3_hd.Visible = false;
                lbl_nominee_shr3_hd.Visible = false;
                lbl_nominee_sub3.Visible = false;

                lbl_nominee_name2_prv.Visible = false;
                lbl_nominee_cnic2_prv.Visible = false;
                lbl_nominee_rwp2_prv.Visible = false;
                lbl_nominee_shr2_prv.Visible = false;
            }
            if (txt_cstm_mtpf_nname3.Text != "" && txt_cstm_mtpf_ncnic3.Text != ""
                //&& txt_cstm_mtpf_nrwp3.Text != "" 
                  && ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper() != ""
                && txt_cstm_mtpf_sharing3.Text != "")
            {
                lbl_nominee_name3_prv.Visible = true;
                lbl_nominee_cnic3_prv.Visible = true;
                lbl_nominee_rwp3_prv.Visible = true;
                lbl_nominee_shr3_prv.Visible = true;
                lbl_nominee_name3_prv.Text = txt_cstm_mtpf_nname3.Text;
                lbl_nominee_cnic3_prv.Text = txt_cstm_mtpf_ncnic3.Text;

                //lbl_nominee_rwp3_prv.Text = txt_cstm_mtpf_nrwp3.Text;

                lbl_nominee_rwp3_prv.Text = ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper();



                lbl_nominee_shr3_prv.Text = txt_cstm_mtpf_sharing3.Text;
            }
            else
            {
                lbl_nominee_name3_hd.Visible = false;
                lbl_nominee_cnic3_hd.Visible = false;
                lbl_nominee_rwp3_hd.Visible = false;
                lbl_nominee_shr3_hd.Visible = false;
                lbl_nominee_sub3.Visible = false;

                lbl_nominee_sub3.Visible = false;
                lbl_nominee_name3_prv.Visible = false;
                lbl_nominee_cnic3_prv.Visible = false;
                lbl_nominee_rwp3_prv.Visible = false;
                lbl_nominee_shr3_prv.Visible = false;
            }

            lbl_erage_prv.Text = retirement_age.Text;

            lbl_Allocation_Scheme_prv.Text = ddlomtpfac.SelectedValue;
        }

        if (ddloactype.SelectedValue == "SINGLE")
        {
            if (txt_cstm_mtpf_nname1.Text != string.Empty && txt_cstm_mtpf_ncnic1.Text != string.Empty
                //  && txt_cstm_mtpf_nrwp1.Text != string.Empty
                && ddlRelationWithPrinciple_N1.SelectedItem.Text.ToUpper() != ""
                && txt_cstm_mtpf_sharing1.Text != string.Empty)
            {
                lbl_nominee_main.Visible = true;
                lbl_nominee_sub1.Visible = true;
                lbl_nominee_name1_hd.Visible = true;
                lbl_nominee_cnic1_hd.Visible = true;
                lbl_nominee_rwp1_hd.Visible = true;
                lbl_nominee_shr1_hd.Visible = true;


                lbl_nominee_name1_prv.Visible = true;
                lbl_nominee_cnic1_prv.Visible = true;
                lbl_nominee_rwp1_prv.Visible = true;
                lbl_nominee_shr1_prv.Visible = true;

                lbl_nominee_name1_prv.Text = txt_cstm_mtpf_nname1.Text;
                lbl_nominee_cnic1_prv.Text = txt_cstm_mtpf_ncnic1.Text;
                //lbl_nominee_rwp1_prv.Text = txt_cstm_mtpf_nrwp1.Text;

                lbl_nominee_rwp1_prv.Text = ddlRelationWithPrinciple_N1.SelectedItem.Text.ToUpper();

                lbl_nominee_shr1_prv.Text = txt_cstm_mtpf_sharing1.Text;
            }
            else
            {
                lbl_nominee_main.Visible = false;
                lbl_nominee_sub1.Visible = false;
                lbl_nominee_name1_prv.Visible = false;
                lbl_nominee_cnic1_prv.Visible = false;
                lbl_nominee_rwp1_prv.Visible = false;
                lbl_nominee_shr1_prv.Visible = false;
            }
            if (txt_cstm_mtpf_nname2.Text != string.Empty && txt_cstm_mtpf_ncnic2.Text != string.Empty
                //&& txt_cstm_mtpf_nrwp2.Text != string.Empty 
                && ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper() != ""
                && txt_cstm_mtpf_sharing2.Text != string.Empty)
            {
                lbl_nominee_sub2.Visible = true;
                lbl_nominee_name2_hd.Visible = true;
                lbl_nominee_cnic2_hd.Visible = true;
                lbl_nominee_rwp2_hd.Visible = true;
                lbl_nominee_shr2_hd.Visible = true;

                lbl_nominee_name2_prv.Visible = true;
                lbl_nominee_cnic2_prv.Visible = true;
                lbl_nominee_rwp2_prv.Visible = true;
                lbl_nominee_shr2_prv.Visible = true;
                lbl_nominee_name2_prv.Text = txt_cstm_mtpf_nname2.Text;
                lbl_nominee_cnic2_prv.Text = txt_cstm_mtpf_ncnic2.Text;
                //lbl_nominee_rwp2_prv.Text = txt_cstm_mtpf_nrwp2.Text;

                lbl_nominee_rwp2_prv.Text = ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper();



                lbl_nominee_shr2_prv.Text = txt_cstm_mtpf_sharing2.Text;

            }
            else
            {
                lbl_nominee_name2_hd.Visible = false;
                lbl_nominee_cnic2_hd.Visible = false;
                lbl_nominee_rwp2_hd.Visible = false;
                lbl_nominee_shr2_hd.Visible = false;
                lbl_nominee_sub2.Visible = false;
                lbl_nominee_name2_prv.Visible = false;
                lbl_nominee_cnic2_prv.Visible = false;
                lbl_nominee_rwp2_prv.Visible = false;
                lbl_nominee_shr2_prv.Visible = false;
            }
            if (txt_cstm_mtpf_nname3.Text != string.Empty && txt_cstm_mtpf_ncnic3.Text != string.Empty
                //&& txt_cstm_mtpf_nrwp3.Text != string.Empty 
                && ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper() != ""
                && txt_cstm_mtpf_sharing3.Text != string.Empty)
            {
                lbl_nominee_sub3.Visible = true;
                lbl_nominee_name3_hd.Visible = true;
                lbl_nominee_cnic3_hd.Visible = true;
                lbl_nominee_rwp3_hd.Visible = true;
                lbl_nominee_shr3_hd.Visible = true;

                lbl_nominee_name3_prv.Visible = true;
                lbl_nominee_cnic3_prv.Visible = true;
                lbl_nominee_rwp3_prv.Visible = true;
                lbl_nominee_shr3_prv.Visible = true;
                lbl_nominee_name3_prv.Text = txt_cstm_mtpf_nname3.Text;
                lbl_nominee_cnic3_prv.Text = txt_cstm_mtpf_ncnic3.Text;
                //lbl_nominee_rwp3_prv.Text = txt_cstm_mtpf_nrwp3.Text;

                lbl_nominee_rwp3_prv.Text = ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper();


                lbl_nominee_shr3_prv.Text = txt_cstm_mtpf_sharing3.Text;
            }
            else
            {

                lbl_nominee_name3_hd.Visible = false;
                lbl_nominee_cnic3_hd.Visible = false;
                lbl_nominee_rwp3_hd.Visible = false;
                lbl_nominee_shr3_hd.Visible = false;
                lbl_nominee_sub3.Visible = false;
                lbl_nominee_name3_prv.Visible = false;
                lbl_nominee_cnic3_prv.Visible = false;
                lbl_nominee_rwp3_prv.Visible = false;
                lbl_nominee_shr3_prv.Visible = false;
            }
        }

        panel_riskprofileform.Visible = false;
        panel_kycdetails.Visible = false;
        panel_preview.Visible = true;
        btn_submit.Visible = false;
        finaldiv.Visible = true;

        acc_opening.CentralizedAccoutsLogs(txt_cnicnum.Text, "Risk Profiling information filled", Session["Username"].ToString());
    }

    protected void btn_back_click_rpf(object sender, EventArgs e)
    {

        panel_fatca.Visible = true;
        panel_riskprofileform.Visible = false;
        panel_kycdetails.Visible = false;
        btn_submit.Visible = false;

    }

    protected void btn_back_click_prv(object sender, EventArgs e)
    {
        panel_kycdetails.Visible = false;
        panel_preview.Visible = false;
        panel_riskprofileform.Visible = true;

    }



    protected void retirement_age_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlomtpfac_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Rb_cstm_dm_cd_reinvest_CheckedChanged(object sender, System.EventArgs e)
    {
        if (Rb_cstm_dm_cd_reinvest.Checked == true)
        {

            string reinvest = Rb_cstm_dm_cd_reinvest.Text;
            //return reinvest;

        }
        else
        {

            string provide_cash = Rb_cstm_dm_cd_providecash.Text;
            //      return provide_cash;

        }
    }


    protected void Rb_cstm_dm_sd_ibu_CheckedChanged(object sender, System.EventArgs e)
    {

        if (Rb_cstm_dm_sd_ibu.Checked == true)
        {
            string ibu = Rb_cstm_dm_sd_ibu.Text;


        }
        else
        {

            string ebu = Rb_cstm_dm_sd_ebu.Text;
            //      return provide_cash;

        }


    }

    protected void btn_next_click(object sender, EventArgs e)
    {



        //////////////////////////////////////////////////////////////////

        // if (txt_name.Text == "") { lbl_main_name.ForeColor = System.Drawing.Color.Red;}


        /////////////////////////////////////////////////////////////////


        if (txt_cnicnum.Text == "" || txt_name.Text == "" || txt_fathername.Text == "" || ddlMaritalStatus.SelectedIndex == -1 || txt_date_of_birth.Text == "" || txt_cnic_expiry.Text == "" || txt_cnic_issue.Text == ""
  || txt_nationality.Text == "" ||
            //txt_religon.Text == "" 
  ddl_religon.SelectedIndex == -1
  || txt_address.Text == "" || txt_address.Text == "" || txt_email.Text == "" || (txt_city.Text == "" && txt_city.Visible) /*|| txt_country.Text == ""*/
  || txt_cstm_accountname.Text == "" || txt_branch_name.Text == ""
      || (txt_cstm_bankname.Text == "" && txt_cstm_bankname.Visible) || txt_branch_name.Text == "" || ddloactype.SelectedValue == ""|| txt_mothername.Text=="")
        {

            if (txt_cnicnum.Text == "") { lbl_main_cnic_no.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_cnic_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_name.Text == "") { lbl_main_name.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_fathername.Text == "") { lbl_main_fname.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_fname.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (ddlMaritalStatus.SelectedIndex == -1) { lbl_main_marital_status.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_marital_status.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_date_of_birth.Text == "") { lbl_main_dob.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_dob.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_cnic_issue.Text == "") { lbl_main_cnic_issue.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_cnic_issue.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_cnic_expiry.Text == "") { lbl_main_cnic_expiry.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_cnic_expiry.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_nationality.Text == "") { lbl_main_nationality.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_nationality.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            //if (txt_religon.Text == "") { lbl_main_religon.ForeColor = System.Drawing.Color.Red; }
            if (ddl_religon.SelectedIndex == -1) { lbl_main_religon.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_religon.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


            if (txt_address.Text == "") { lbl_main_address.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_address.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_email.Text == "") { lbl_main_email_address.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_email_address.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            //if (txt_city.Text == "") { lbl_main_res_country.ForeColor = System.Drawing.Color.Red; }
            //else { lbl_main_res_country.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            //if (txt_country.Text == "") { lbl_main_city.ForeColor = System.Drawing.Color.Red; }
            //else { lbl_main_city.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            //if (txt_cstm_bankname.Text == "") { lbl_main_bnk_name.ForeColor = System.Drawing.Color.Red; }
            //else { lbl_main_bnk_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (txt_branch_name.Text == "") { lbl_main_brnch_name.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_brnch_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (ddloactype.SelectedValue == "") { lbl_main_account_type.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_account_type.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_cstm_accountname.Text == "") { lbl_main_accnt_number.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_accnt_number.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (txt_mothername.Text == "") { lbl_main_mname.ForeColor = System.Drawing.Color.Red; }
            else { lbl_main_mname.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (txt_par_address.Text == "") { lbl_par_address.ForeColor = System.Drawing.Color.Red; }
            else { lbl_par_address.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
     
            //panel_error_mesg.Visible = true;
            //mystage_.Text = "main";
            //mystage = "main";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            //panel_kycdetails.Visible = false;
            //panel1.Visible = false;
            //btn_next.Visible = false;
            return;
        }

        if (Rb_dual_national_yes.Checked == false && Rb_dual_national_no.Checked == false)
        {
            lbl_dual_national.ForeColor = System.Drawing.Color.Red;          
            return;
        }
        else { lbl_dual_national.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


        if (Rb_resident_pakistan.Checked == false && Rb_resident_non_resident.Checked == false && Rb_resident_for.Checked == false && Rb_resident_non_for.Checked == false)
        {
            lbl_resident_status.ForeColor = System.Drawing.Color.Red;         
            return;
        }
        else { lbl_resident_status.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


        //if (Rb_cstm_dm_cd_reinvest.Checked == false && Rb_cstm_dm_cd_providecash.Checked == false) { lbl_main_divdnt_cash.ForeColor = System.Drawing.Color.Red; return; }
        //else { lbl_main_divdnt_cash.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //if (Rb_cstm_dm_sd_ibu.Checked == false && Rb_cstm_dm_sd_ebu.Checked == false) { lbl_main_divdnt_stock.ForeColor = System.Drawing.Color.Red; return; }
        //else { lbl_main_divdnt_stock.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

 
        
        if (Rb_cstm_kyc_ocptn_gservices.Checked == false && Rb_cstm_kyc_ocptn_pservices.Checked == false && Rb_cstm_kyc_ocptn_selfemplyd.Checked == false && Rb_cstm_kyc_ocptn_retired.Checked == false && Rb_cstm_kyc_ocptn_hwife.Checked == false && Rb_cstm_kyc_ocptn_student.Checked == false)
        {

            lbl_main_occupation.ForeColor = System.Drawing.Color.Red;
            // panel_error_mesg.Visible = true;
            // mystage_.Text = "main";
            //mystage = "main";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            //panel_kycdetails.Visible = false;
            //panel1.Visible = false;
            //btn_next.Visible = false;
            return;
        }
        else { lbl_main_occupation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


        if (Rb_cstm_kyc_soi_business.Checked == false && Rb_cstm_kyc_soi_salary.Checked == false && Rb_cstm_kyc_soi_pensions.Checked == false && Rb_cstm_kyc_soi_inheritances.Checked == false && Rb_cstm_kyc_soi_remittances.Checked == false && Rb_cstm_kyc_soi_saving.Checked == false && Rb_cstm_kyc_soi_stocks.Checked == false)
        {

            lbl_main_source_of_income.ForeColor = System.Drawing.Color.Red;
            // panel_error_mesg.Visible = true;
            // mystage_.Text = "main";
            //mystage = "main";
            //Lblmsg.Text = "Incomplete Data";
            //Lblmsg.Visible = true;
            //btn_go_back.Visible = true;
            //panel_kycdetails.Visible = false;
            //panel1.Visible = false;
            //btn_next.Visible = false;
            return;
        }
        else { lbl_main_source_of_income.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (txt_kyc_designation.Text == "" || txt_kyc_no_of_tran.Text == "" || txt_kyc_turn_over.Text == "")
        {
            if (txt_kyc_designation.Text == "") { lbl_kyc_designation.ForeColor = System.Drawing.Color.Red; }
            else { lbl_kyc_designation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_kyc_no_of_tran.Text == "") { lbl_kyc_no_of_tran.ForeColor = System.Drawing.Color.Red; }
            else { lbl_kyc_no_of_tran.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            if (txt_kyc_turn_over.Text == "") { lbl_kyc_turn_over.ForeColor = System.Drawing.Color.Red; }
            else { lbl_kyc_turn_over.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            return;        
        }
        else 
        {
            lbl_kyc_designation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            lbl_kyc_no_of_tran.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
            lbl_kyc_turn_over.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333");
        }


        if (Rb_cstm_kyc_abop_yes.Checked == false && Rb_cstm_kyc_abop_no.Checked == false)
        {
            lbl_main_kyc_abop.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_abop.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_abop_yes.Checked == true) 
        {
            if (txt_kyc_act_quest.Text == "" || txt_kyc_Act_quest_cnic.Text == "" || ddl_kyc_act_quest_relation.SelectedValue == "")
            {
                lbl_main_kyc_abop.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else 
            { 
            
              { lbl_main_kyc_abop.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
            }

        }
       
        
        if (Rb_cstm_kyc_firoa_yes.Checked == false && Rb_cstm_kyc_firoa_no.Checked == false)
        {
            lbl_main_kyc_firoa.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_firoa.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_spgi_yes.Checked == false && Rb_cstm_kyc_spgi_no.Checked == false)
        {
            lbl_main_kyc_spgi.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_spgi.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_sppp_yes.Checked == false && Rb_cstm_kyc_sppp_no.Checked == false)
        {
            lbl_main_kyc_sppp.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_sppp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_fsupport_yes.Checked == false && Rb_cstm_kyc_fsupport_no.Checked == false)
        {
            lbl_main_kyc_fsupport.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_fsupport.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }



        if (Rb_cstm_kyc_hvitem_yes.Checked == false && Rb_cstm_kyc_hvitem_no.Checked == false)
        {
            lbl_main_kyc_hvitem.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_hvitem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_wealth_yes.Checked == false && Rb_cstm_kyc_wealth_no.Checked == false)
        {
            lbl_main_kyc_wealth.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_wealth.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        /////////   kyc questions remaining 

        if (Rb_cstm_kyc_head_state_yes.Checked == false && Rb_cstm_kyc_head_state_no.Checked == false)
        {
            lbl_main_kyc_head_state.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_head_state.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_adviser_yes.Checked == false && Rb_cstm_kyc_adviser_no.Checked == false)
        {
            lbl_main_kyc_advisers.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_advisers.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_judicial_yes.Checked == false && Rb_cstm_kyc_judicial_no.Checked == false)
        {
            lbl_main_kyc_judicial.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_judicial.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_military_yes.Checked == false && Rb_cstm_kyc_military_no.Checked == false)
        {
            lbl_main_kyc_military.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_military.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_hod_yes.Checked == false && Rb_cstm_kyc_hod_no.Checked == false)
        {
            lbl_main_kyc_hod.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_hod.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_io_yes.Checked == false && Rb_cstm_kyc_io_no.Checked == false)
        {
            lbl_main_kyc_io.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_io.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_mob_yes.Checked == false && Rb_cstm_kyc_mob_no.Checked == false)
        {
            lbl_main_kyc_mob.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_mob.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_assembly_no.Checked == false && Rb_cstm_kyc_assembly_yes.Checked == false)
        {
            lbl_main_kyc_assembly.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_assembly.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        if (Rb_cstm_kyc_party_yes.Checked == false && Rb_cstm_kyc_party_no.Checked == false)
        {
            lbl_main_kyc_party.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else { lbl_main_kyc_party.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        
        
        //if (Rb_cstm_kyc_firoa_yes.Checked == false && Rb_cstm_kyc_firoa_no.Checked == false) { lbl_main_kyc_firoa.ForeColor = System.Drawing.Color.Red; return; }
        //else { lbl_main_kyc_firoa.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //if (Rb_cstm_kyc_firoa_no.Checked)
        //{
        //    if (Rb_cstm_kyc_abop_yes.Checked == false && Rb_cstm_kyc_abop_no.Checked == false) { lbl_main_kyc_abop.ForeColor = System.Drawing.Color.Red; return; }
        //    else { lbl_main_kyc_abop.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //    if (Rb_cstm_kyc_hvitem_yes.Checked == false && Rb_cstm_kyc_hvitem_no.Checked == false) { lbl_main_kyc_hvitem.ForeColor = System.Drawing.Color.Red; return; }
        //    else { lbl_main_kyc_hvitem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //    if (Rb_cstm_kyc_spgi_yes.Checked == false && Rb_cstm_kyc_spgi_no.Checked == false) { lbl_main_kyc_spgi.ForeColor = System.Drawing.Color.Red; return; }
        //    else { lbl_main_kyc_spgi.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //    if (Rb_cstm_kyc_sppp_yes.Checked == false && Rb_cstm_kyc_sppp_no.Checked == false) { lbl_main_kyc_sppp.ForeColor = System.Drawing.Color.Red; return; }
        //    else { lbl_main_kyc_sppp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //    if (ddl_kycq7.SelectedValue == "") { lbl_main_kyc_hear_about_us.ForeColor = System.Drawing.Color.Red; return; }
        //    else { lbl_main_kyc_hear_about_us.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //}

        #region minor
        if (ddloactype.SelectedValue == "MINOR")
        {
            /////// BOTH OF THEM ARE TEMPROARY PURPOSES ///////////////
            // ACCOUNT_OPERATING_INSTRUCTION = "ONLY BY PRIN AC HOLDER";
            // ALLOCATION_SCHEME = "NONE";
            if (txt_cstm_mnr_ng.Text == "" || txt_cstm_mnr_gcnic.Text == "" || txt_cstm_mnr_cnic_expiry.Text == "" ||
                //txt_cstm_mnr_rwp.Text == ""                
                ddlRelationWithPrinciple_mnr.SelectedItem.Text.ToUpper() == ""
                )
            {

                if (txt_cstm_mnr_ng.Text == "") { lbl_main_minor_gname.ForeColor = System.Drawing.Color.Red; panel_minor_account.Visible = true; return; }
                else { lbl_main_minor_gname.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
                if (txt_cstm_mnr_gcnic.Text == "") { lbl_main_main_gcnic_no.ForeColor = System.Drawing.Color.Red; panel_minor_account.Visible = true; return; }
                else { lbl_main_main_gcnic_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
                if (txt_cstm_mnr_cnic_expiry.Text == "") { lbl_main_minor_cdate.ForeColor = System.Drawing.Color.Red; panel_minor_account.Visible = true; return; }
                else { lbl_main_minor_cdate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
                //if (txt_cstm_mnr_rwp.Text == "") { lbl_main_minor_rwp.ForeColor = System.Drawing.Color.Red; panel_minor_account.Visible = true; return; }
                if (ddlRelationWithPrinciple_mnr.SelectedItem.Text.ToUpper() == "") { lbl_main_minor_rwp.ForeColor = System.Drawing.Color.Red; panel_minor_account.Visible = true; return; }
                else { lbl_main_minor_rwp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "main";
                //mystage = "main";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                //panel_kycdetails.Visible = false;
                //panel1.Visible = false;
                //btn_next.Visible = false;

                return;
            }

        }
        #endregion

        #region joint
        if (ddloactype.SelectedValue == "JOINT")
        {
            /////// BOTH OF THEM ARE TEMPROARY PURPOSES ///////////////
            // ACCOUNT_OPERATING_INSTRUCTION = "ONLY BY PRIN AC HOLDER";
            // ALLOCATION_SCHEME = "NONE";
            if (txt_cstm_jh_jhcnic1.Text == "" || txt_cstm_jh_jhname1.Text == "" ||
                //txt_cstm_jh_jhrwp1.Text == ""
           ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper() == "" || txt_cstm_jh1_cnic_issue_date.Text == "" || txt_cstm_jh1_cnic_exp_date.Text=="")
            {

                if (txt_cstm_jh_jhcnic1.Text == "") { lbl_main_jh1_cnic_no.ForeColor = System.Drawing.Color.Red; panel_joint_acc_holder.Visible = true; return; }
                else { lbl_main_jh1_cnic_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
                if (txt_cstm_jh_jhname1.Text == "") { lbl_main_jh1_name.ForeColor = System.Drawing.Color.Red; panel_joint_acc_holder.Visible = true; return; }
                else { lbl_main_jh1_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
                //if (txt_cstm_jh_jhrwp1.Text == "") 

                if (txt_cstm_jh1_cnic_issue_date.Text == "") { lbl_main_jh1_cnic_no.ForeColor = System.Drawing.Color.Red; panel_joint_acc_holder.Visible = true; return; }
                else { lbl_main_jh1_cnic_issue_date.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

                if (txt_cstm_jh1_cnic_exp_date.Text == "") { lbl_main_jh1_cnic_no.ForeColor = System.Drawing.Color.Red; panel_joint_acc_holder.Visible = true; return; }
                else { lbl_main_jh1_cnic_exp_date.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


                if (ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper() == "")

                { lbl_main_jh1_rwp.ForeColor = System.Drawing.Color.Red; panel_joint_acc_holder.Visible = true; return; }

                else { lbl_main_jh1_rwp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

                //panel_error_mesg.Visible = true;
                //mystage_.Text = "main";
                //mystage = "main";
                //Lblmsg.Text = "Incomplete Data";
                //Lblmsg.Visible = true;
                //btn_go_back.Visible = true;
                //panel_kycdetails.Visible = false;
                //panel1.Visible = false;
                //btn_next.Visible = false;
                return;
            }

            if (Rb_cstm_kyc_firoa_yes_j1.Checked == false && Rb_cstm_kyc_firoa_no_j1.Checked == false)
            {
                lbl_main_kyc_firoa_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_firoa_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_spgi_yes_j1.Checked == false && Rb_cstm_kyc_spgi_no_j1.Checked == false)
            {
                lbl_main_kyc_spgi_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_spgi_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_sppp_yes_j1.Checked == false && Rb_cstm_kyc_sppp_no_j1.Checked == false)
            {
                lbl_main_kyc_sppp_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_sppp_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_fsupport_j1_yes.Checked == false && Rb_cstm_kyc_fsupport_j1_no.Checked == false)
            {
                lbl_main_kyc_fsupport_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_fsupport_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


            if (Rb_cstm_kyc_hvitem_yes_j1.Checked == false && Rb_cstm_kyc_hvitem_no_j1.Checked == false)
            {
                lbl_main_kyc_hvitem_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_hvitem_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_wealth_yes_j1.Checked == false && Rb_cstm_kyc_wealth_no_j1.Checked == false)
            {
                lbl_main_kyc_wealth_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_wealth_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            /////////   kyc questions remaining 

            if (Rb_cstm_kyc_head_state_yes_j1.Checked == false && Rb_cstm_kyc_head_state_no_j1.Checked == false)
            {
                lbl_main_kyc_head_state_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_head_state_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_adviser_yes_j1.Checked == false && Rb_cstm_kyc_adviser_no_j1.Checked == false)
            {
                lbl_main_kyc_advisers_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_advisers_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_judicial_yes_j1.Checked == false && Rb_cstm_kyc_judicial_no_j1.Checked == false)
            {
                lbl_main_kyc_judicial_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_judicial_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_military_yes_j1.Checked == false && Rb_cstm_kyc_military_no_j1.Checked == false)
            {
                lbl_main_kyc_military_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_military_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_hod_yes_j1.Checked == false && Rb_cstm_kyc_hod_no_j1.Checked == false)
            {
                lbl_main_kyc_hod_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_hod_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_io_yes_j1.Checked == false && Rb_cstm_kyc_io_no_j1.Checked == false)
            {
                lbl_main_kyc_io_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_io_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_mob_yes_j1.Checked == false && Rb_cstm_kyc_mob_no_j1.Checked == false)
            {
                lbl_main_kyc_mob_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_mob_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_assembly_no_j1.Checked == false && Rb_cstm_kyc_assembly_yes_j1.Checked == false)
            {
                lbl_main_kyc_assembly_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_assembly_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

            if (Rb_cstm_kyc_party_yes_j1.Checked == false && Rb_cstm_kyc_party_no_j1.Checked == false)
            {
                lbl_main_kyc_party_j1.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else { lbl_main_kyc_party_j1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }














        }
        #endregion

        if (lbl_main_cnic_no.ForeColor == System.Drawing.Color.Red) { lbl_main_cnic_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_name.ForeColor == System.Drawing.Color.Red) { lbl_main_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_fname.ForeColor == System.Drawing.Color.Red) { lbl_main_fname.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_marital_status.ForeColor == System.Drawing.Color.Red) { lbl_main_marital_status.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_dob.ForeColor == System.Drawing.Color.Red) { lbl_main_dob.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_cnic_expiry.ForeColor == System.Drawing.Color.Red) { lbl_main_cnic_expiry.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_nationality.ForeColor == System.Drawing.Color.Red) { lbl_main_nationality.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_religon.ForeColor == System.Drawing.Color.Red) { lbl_main_religon.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_address.ForeColor == System.Drawing.Color.Red) { lbl_main_address.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_email_address.ForeColor == System.Drawing.Color.Red) { lbl_main_email_address.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_res_country.ForeColor == System.Drawing.Color.Red) { lbl_main_res_country.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_city.ForeColor == System.Drawing.Color.Red) { lbl_main_city.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_bnk_name.ForeColor == System.Drawing.Color.Red) { lbl_main_bnk_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_brnch_name.ForeColor == System.Drawing.Color.Red) { lbl_main_brnch_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_account_type.ForeColor == System.Drawing.Color.Red) { lbl_main_account_type.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        //////////////////////////

        if (lbl_main_minor_gname.ForeColor == System.Drawing.Color.Red) { lbl_main_minor_gname.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_main_gcnic_no.ForeColor == System.Drawing.Color.Red) { lbl_main_main_gcnic_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_minor_cdate.ForeColor == System.Drawing.Color.Red) { lbl_main_minor_cdate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_minor_rwp.ForeColor == System.Drawing.Color.Red) { lbl_main_minor_rwp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        /////////////////////////////////

        if (lbl_main_jh1_cnic_no.ForeColor == System.Drawing.Color.Red) { lbl_main_jh1_cnic_no.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_jh1_name.ForeColor == System.Drawing.Color.Red) { lbl_main_jh1_name.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_jh1_rwp.ForeColor == System.Drawing.Color.Red) { lbl_main_jh1_rwp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }

        //////////////////////////////

        if (lbl_main_kyc_firoa.ForeColor == System.Drawing.Color.Red) { lbl_main_kyc_firoa.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_kyc_abop.ForeColor == System.Drawing.Color.Red) { lbl_main_kyc_abop.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_kyc_hvitem.ForeColor == System.Drawing.Color.Red) { lbl_main_kyc_hvitem.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_kyc_spgi.ForeColor == System.Drawing.Color.Red) { lbl_main_kyc_spgi.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_kyc_sppp.ForeColor == System.Drawing.Color.Red) { lbl_main_kyc_sppp.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }
        if (lbl_main_kyc_hear_about_us.ForeColor == System.Drawing.Color.Red) { lbl_main_kyc_hear_about_us.ForeColor = System.Drawing.ColorTranslator.FromHtml("#333333"); }


        ////////////////////////////////
        panel1.Visible = false;
        panel_kycdetails.Visible = false;

        panel_minor_account.Visible = false;
        panel_nominee_details.Visible = false;
        panel_mtpf_ddlist.Visible = false;
        panel_joint_acc_holder.Visible = false;
        panel_Operating_Instructions_ddlist.Visible = false;
        panel_fatca.Visible = true;
        btn_next.Visible = false;      /// this button lies outside the panel 
        txt_ftca_cnicnumber.Text = txt_cnicnum.Text;
        txt_ftca_acctitle.Text = txt_name.Text;

        acc_opening.CentralizedAccoutsLogs(txt_cnicnum.Text, "Basic information filled", Session["Username"].ToString());
    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {


        //JH1_CNIC_ISSUE_DATE_, JH1_CNIC_EXPIRY_DATE_, JH2_CNIC_ISSUE_DATE_, JH2_CNIC_EXPIRY_DATE_


        DateTime Basic_date = new DateTime(1900, 01, 01);

        Acc_opening acc_opening = new Acc_opening();
        // string EXPECTED_RETIREMENT_AGE ;
        //string ALLOCATION_SCHEME;
        //string ACCOUNT_OPERATING_INSTRUCTION ;
        string DIVIDEND_MANDATE;
        string BONUS_MANDATE;
        DateTime TIME_STAMP = DateTime.Now;

        string CNIC = txt_cnicnum.Text.ToUpper();

        string DAO_ID = txt_dao_id.Text;
        //Document Attachement Check...
        //var CNIC_COPY = cb_docList.Items.FindByValue("ID").Selected ? "Y" : "N";
        //var PROOF = cb_docList.Items.FindByValue("PROOF").Selected ? "Y" : "N";
        //var ZAKAT = cb_docList.Items.FindByValue("ZAKAT").Selected ? "Y" : "N";
        //var CHEQUE = cb_docList.Items.FindByValue("CHEQUE").Selected ? "Y" : "N";

        // string ACCOUNT_TYPE=Request.Form["ddloactype"];
        string CUSTOMER_NAME = txt_name.Text.ToUpper();

        Session["CNIC"] = CNIC;
        Session["CUSTOMER_NAME"] = CUSTOMER_NAME;

        string FATHER_HUSBAND_NAME = txt_fathername.Text.ToUpper();

        string MOTHER_NAME = txt_mothername.Text.ToUpper();

        string DUAL_NATIONAL = "";

        string resident_Status = "";

       // ddlCountry.SelectedItem.Text;
        
        string p_country = ddl_p_country.SelectedItem.Text;

        string p_city = ddl_p_city.SelectedItem.Text;

        string pob = ddl_pob.SelectedItem.Text;


        string p_address = "";

        string MARITAL_STATUS;//= txt_maritalstatus.Text.ToUpper();
        MARITAL_STATUS = ddlMaritalStatus.SelectedItem.Text.ToUpper();
        string DATE_OF_BIRTH = txt_date_of_birth.Text.ToUpper();
        if (txt_date_of_birth.Text == "" || txt_cnic_expiry.Text == "" || txt_cnic_issue.Text == "")
        {
            mystage_.Text = "main";
            mystage = "main";
            Lblmsg.Text = "Incomplete Data";
            Lblmsg.Visible = true;
            btn_go_back.Visible = true;
            panel_kycdetails.Visible = false;
            return;

        }

        DateTime DATE_OF_BIRTH_ = DateTime.Parse(DATE_OF_BIRTH);

        string NATIONALITY = txt_nationality.Text.ToUpper();

        // string RELIGON = txt_religon.Text.ToUpper();

        string RELIGON = ddl_religon.SelectedItem.Text.ToUpper();

        p_address = txt_par_address.Text.ToUpper();

        string CNIC_EXPIRY_DATE = txt_cnic_expiry.Text;
        string CNIC_ISSUE_DATE = txt_cnic_issue.Text;
        DateTime CNIC_ISSUE_DATE_ = DateTime.Parse(CNIC_ISSUE_DATE);
        DateTime CNIC_EXPIRY_DATE_ = DateTime.Parse(CNIC_EXPIRY_DATE);

        string CNIC_EXP_RENEW_NUM = txt_cnic_renew_num.Text.ToUpper();

        string ADDRESS = txt_address.Text.ToUpper();


        string COUNTRY = ddlCountry.SelectedItem.Text;

        string RESIDENCE_CITY = string.IsNullOrEmpty(txt_city.Text) ? ddl_City.SelectedItem.Text : txt_city.Text;


        //string MOBILE = txt_cstm_mobilenumber.Text.ToUpper();
        string MOBILE = string.Empty;
        if (!txtOtherMobile.Visible)
        {
            MOBILE = ddlMobileCode.SelectedItem.Text + txt_cstm_mobilenumber.Text.ToUpper();
        }
        else
        {
            MOBILE = txtOtherMobile.Text;
        }
        Session["MOBILE"] = MOBILE;
        string PORTED = cb_MobilePorted.Checked ? "YES" : "NO";
        string MOBILE_NETWORK = ddlMobileType.SelectedItem.Text.ToUpper();

        string OFF_NUMBER = txt_cstm_officenumber.Text.ToUpper();

        string RESIDENTIAL_NUMBER = txt_cstm_phonenumber.Text.ToUpper();

        string EMAIL = txt_email.Text.ToUpper();
        string ACC_MINOR_CASE;
        // string ACC_MINOR_CASE=Request.Form[""]'


        //  string ACC_MINOR_RELATIONSHIP = txt_cstm_mnr_rwp.Text.ToUpper();

        string ACC_MINOR_RELATIONSHIP = ddlRelationWithPrinciple_mnr.SelectedItem.Text.ToUpper();


        string ACC_MINOR_GUARDIAN_NAME = txt_cstm_mnr_ng.Text.ToUpper();
        string ACC_GUARDIAN_CNIC = txt_cstm_mnr_gcnic.Text.ToUpper();

        string ACC_GUARDIAN_CNIC_EXPIRY = txt_cstm_mnr_cnic_expiry.Text.ToUpper();

        DateTime ACC_GUARDIAN_CNIC_EXPIRY_ = DateTime.Now;


        string BANK_ACC_NUMBER = txt_cstm_accountname.Text.ToUpper();
        Session["BANK_ACC_NUMBER"] = BANK_ACC_NUMBER;
        string BANK_NAME;
        if (ddlBanks.SelectedItem.Text == "OTHER")
        {
            BANK_NAME = txt_cstm_bankname.Text.ToUpper();
        }
        else
        {
            BANK_NAME = ddlBanks.SelectedItem.Value.ToUpper();
        }


        string BRANCH_NAME = txt_branch_name.Text.ToUpper();  //  control to be created 
        string BRANCH_CITY = ddl_BranchCity.SelectedItem.Text.ToUpper();
        //txt_branch_city.Text.ToUpper();                    // control to be created      
        Session["BRANCH_NAME"] = BRANCH_NAME;
        Session["BANK_NAME"] = BANK_NAME;

        string ACCOUNT_OPERATING_INSTRUCTION;
        string ALLOCATION_SCHEME;

        ////////////////////////////////////// fatca form variables /////////////////////////////// 
        string TITLE_OF_ACCOUNT = "";
        string TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "";
        string PLACE_OF_BIRTH_CITY = "";
        string PLACE_OF_BIRTH_STATE = "";
        string PLACE_OF_BIRTH_COUNTRY = "";
        string US_CITIZEN = "";
        string US_RESIDENT = "";
        string GREEEN_CARD = "";
        string DOB_OF_USA = "";
        string TRANSFER_FUND_TO_USA_ACCOUNT = "";
        string POWER_OF_ATTORNEY_USA_ADDRESS = "";
        string US_RESIDENCE_MAIL_ADDRESS = "";
        string US_TELELPHONE_NUMBER = "";
        ////////////////////////////////////// fatca form variables /////////////////////////////// 

        ////////////////////////////////////// risk profile form variables /////////////////////////////// 
        string PORTFOLIO_NUMBER = "";
        string OLD_REGNUMBER = "";
        string AGE = "";
        string RISK_RETURN_TOLERENCE_LEVEL = "";
        string MONTHLY_SAVINGS = "";
        string OCCUPATION_rpf = "";
        string INVESTMENT_OBJECTIVE = "";
        string KNOWLEDGE_LEVEL = "";
        string INVESTMENT_HORIZON = "";
        string IDEAL_PORTFOLIO_SCORE = "";
        string IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "";
        string IDEAL_PORTFOLIO_FUND = "";
        int AGERPF = 0; int RRTL = 0; int MS = 0; int OCCP = 0; int IO = 0; int KNOWLEDGE = 0; int IH = 0;


        ////////////////////////////////////// risk profile form variables ///////////////////////////////
        //string DIVIDEND_MANDATE
        // string BONUS_MANDATE
        if (Rb_cstm_dm_cd_reinvest.Checked == true)
        {

            DIVIDEND_MANDATE = Rb_cstm_dm_cd_reinvest.Text.ToUpper();
            //return reinvest;

        }
        else
        {
            DIVIDEND_MANDATE = Rb_cstm_dm_cd_providecash.Text.ToUpper();
            //      return provide_cash;
        }

        if (Rb_cstm_dm_sd_ibu.Checked == true)
        {
            BONUS_MANDATE = Rb_cstm_dm_sd_ibu.Text.ToUpper();
        }
        else
        {
            BONUS_MANDATE = Rb_cstm_dm_sd_ebu.Text.ToUpper();
            //      return provide_cash;
        }

        if (Rb_dual_national_yes.Checked == true)
        {
            DUAL_NATIONAL = Rb_dual_national_yes.Text.ToUpper();
            //return reinvest;
        }
        else
        {
            DUAL_NATIONAL = Rb_dual_national_no.Text.ToUpper();
            //      return provide_cash;
        }
        if (Rb_resident_pakistan.Checked == true)
        {
            resident_Status = Rb_resident_pakistan.Text.ToUpper();
            //return reinvest;
        }
     
        if (Rb_resident_non_resident.Checked == true)
        {
            resident_Status = Rb_resident_non_resident.Text.ToUpper();
            //return reinvest;
        }
      
        if (Rb_resident_for.Checked == true)
        {
            resident_Status = Rb_resident_for.Text.ToUpper();
            //return reinvest;
        }
    
        if (Rb_resident_non_for.Checked == true)
        {
            resident_Status = Rb_resident_non_for.Text.ToUpper();
            //return reinvest;
        }
      



        string EXPECTED_RETIREMENT_AGE = "";


        string ACCOUNT_TYPE = ddloactype.SelectedValue.ToUpper();
        string OCCUPATION = "";
        string SOURCE_OF_INCOME = "";
        string NAME_OF_EMPLOYER_BUSINESS = txt_cstm_kyc_noeb.Text.ToUpper();

        string ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER = "";
        string ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON = "";
        string HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE = "";
        string SENOIR_MEMBER_IN_POLITICAL_PARTY = "";
        string DEAL_IN_HIGH_VALUE_ITEMS = "";
        string WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN = "";

        string financially_supported = "";




        string ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1 = "";
        string HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1 = "";
        string SENOIR_MEMBER_IN_POLITICAL_PARTY_J1 = "";
        string DEAL_IN_HIGH_VALUE_ITEMS_J1 = "";
        string financially_supported_J1 = "";

        string ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2 = "";
        string HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2 = "";
        string SENOIR_MEMBER_IN_POLITICAL_PARTY_J2 = "";
        string DEAL_IN_HIGH_VALUE_ITEMS_J2 = "";
        string financially_supported_J2 = "";

        /////////////////////////////////////////////////////////

        string DESIGNATION = "";
        string NATURE_BUSINESS = "";
        string PEP = "";


string Geographic_Involved_Domestic="";
      string Geographic_Involved_International="";
      string Type_of_Counterparty_Domestic="";
      string Type_of_Counterparty_International="";
      string Possible_modes_of_transactions="";
      string Possible_No_of_transactions="";
      string Possible_Turnover_in_Account="";
      string Annual_Gross_Income="";
      string Amount_of_Investment="";

      string CUSTOMER_WEALTH_P = "";
      string HEAD_OF_STATE_P = "";
      string ADVISER_P = "";
      string JUDICIAL_OFFICER_P = "";
      string MILITARY_P = "";
      string HOD_P = "";
      string INTERNATIONAL_ORGANIZATION_P = "";
      string MOB_P = "";
      string ASSEMBLY_P = "";
      string PARTY_P = "";

      string CUSTOMER_WEALTH_j1 = "";
      string HEAD_OF_STATE_j1 = "";
      string ADVISER_j1 = "";
      string JUDICIAL_OFFICER_j1 = "";
      string MILITARY_j1 = "";
      string HOD_j1 = "";
      string INTERNATIONAL_ORGANIZATION_j1 = "";
      string MOB_j1 = "";
      string ASSEMBLY_j1 = "";
      string PARTY_j1 = "";

      string CUSTOMER_WEALTH_j2 = "";
      string HEAD_OF_STATE_j2 = "";
      string ADVISER_j2 = "";
      string JUDICIAL_OFFICER_j2 = "";
      string MILITARY_j2 = "";
      string HOD_j2 = "";
      string INTERNATIONAL_ORGANIZATION_j2 = "";
      string MOB_j2 = "";
      string ASSEMBLY_j2 = "";
      string PARTY_j2 = "";




      DESIGNATION = txt_kyc_designation.Text.ToUpper();
      NATURE_BUSINESS = txt_kyc_nob.Text.ToUpper();

       string Name_of_Ultimate_Beneficiary="", CNIC_Passport_No_of_Beneficiary="",  Relationship_with_Customer="", Possible_turnover_in_acount_annual="";


      Geographic_Involved_Domestic = ddl_kyc_gepgraphy_domestic.SelectedValue.ToString();
      Geographic_Involved_International = ddl_kyc_gepgraphy_international.SelectedValue.ToString();

      Type_of_Counterparty_Domestic = ddl_kyc_gepgraphy_domestic_cparty.SelectedValue.ToString();
      Type_of_Counterparty_International = ddl_kyc_gepgraphy_international_cparty.SelectedValue.ToString();

      Possible_No_of_transactions = txt_kyc_no_of_tran.Text;

      Possible_Turnover_in_Account = "";

      if (Rb_kyc_turn_over_annually.Checked == true) { Possible_turnover_in_acount_annual = txt_kyc_turn_over.Text; }

      if (Rb_kyc_turn_over_monthly.Checked == true)  { Possible_Turnover_in_Account = txt_kyc_turn_over.Text; }


      if (Rb_kyc_tran_mode_online.Checked == true) { Possible_modes_of_transactions = Rb_kyc_tran_mode_online.Text.ToUpper(); }
      if (Rb_kyc_tran_mode_physical.Checked == true) { Possible_modes_of_transactions = Rb_kyc_tran_mode_physical.Text.ToUpper(); }
      if (Rb_kyc_tran_mode_Both.Checked == true) { Possible_modes_of_transactions = Rb_kyc_tran_mode_Both.Text.ToUpper(); }

      if (Rb_kyc_exp_amount_2.Checked == true) { Amount_of_Investment = Rb_kyc_exp_amount_2.Text.ToUpper(); }
      if (Rb_kyc_exp_amount_5.Checked == true) { Amount_of_Investment = Rb_kyc_exp_amount_5.Text.ToUpper(); }
      if (Rb_kyc_exp_amount_10.Checked == true) { Amount_of_Investment = Rb_kyc_exp_amount_10.Text.ToUpper(); }
      if (Rb_kyc_exp_amount_10above.Checked == true) { Amount_of_Investment = Rb_kyc_exp_amount_10above.Text.ToUpper(); }

      if (Rb_kyc_annual_income_1.Checked == true) { Annual_Gross_Income = Rb_kyc_annual_income_1.Text.ToUpper(); }
      if (Rb_kyc_annual_income_3.Checked == true) { Annual_Gross_Income = Rb_kyc_annual_income_3.Text.ToUpper(); }
      if (Rb_kyc_annual_income_6.Checked == true) { Annual_Gross_Income = Rb_kyc_annual_income_6.Text.ToUpper(); }
      if (Rb_kyc_annual_income_8.Checked == true) { Annual_Gross_Income = Rb_kyc_annual_income_8.Text.ToUpper(); }
      if (Rb_kyc_annual_income_10.Checked == true) { Annual_Gross_Income = Rb_kyc_annual_income_10.Text.ToUpper(); }
      if (Rb_kyc_annual_income_10above.Checked == true) { Annual_Gross_Income = Rb_kyc_annual_income_10above.Text.ToUpper(); }

        ///////////////////////////////////


        if (Rb_cstm_kyc_ocptn_gservices.Checked == true) { OCCUPATION = Rb_cstm_kyc_ocptn_gservices.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_pservices.Checked == true) { OCCUPATION = Rb_cstm_kyc_ocptn_pservices.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_selfemplyd.Checked == true) { OCCUPATION = Rb_cstm_kyc_ocptn_selfemplyd.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_retired.Checked == true) { OCCUPATION = Rb_cstm_kyc_ocptn_retired.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_hwife.Checked == true) { OCCUPATION = Rb_cstm_kyc_ocptn_hwife.Text.ToUpper(); }
        if (Rb_cstm_kyc_ocptn_student.Checked == true) { OCCUPATION = Rb_cstm_kyc_ocptn_student.Text.ToUpper(); }

        if (Rb_cstm_kyc_soi_business.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_business.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_salary.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_salary.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_pensions.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_pensions.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_inheritances.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_inheritances.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_remittances.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_remittances.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_saving.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_saving.Text.ToUpper(); }
        if (Rb_cstm_kyc_soi_stocks.Checked == true) { SOURCE_OF_INCOME = Rb_cstm_kyc_soi_stocks.Text.ToUpper(); }


       
        if (Rb_cstm_kyc_abop_yes.Checked == true)
        {
            ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON = "YES";
            Name_of_Ultimate_Beneficiary = txt_kyc_act_quest.Text;
            CNIC_Passport_No_of_Beneficiary = txt_kyc_Act_quest_cnic.Text;
            Relationship_with_Customer = ddl_kyc_act_quest_relation.SelectedValue.ToString();
                
        }
        else
        {
            ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON = "NO";

        }

        if (Rb_cstm_kyc_firoa_yes.Checked == true)
        {
            ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER = "YES";
        }
        else
        {
            ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER = "NO";

        }        
        if (Rb_cstm_kyc_spgi_yes.Checked == true)
        {
            HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE = "YES";
        }
        else
        {
            HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE = "NO";

        }

        if (Rb_cstm_kyc_sppp_yes.Checked == true)
        {
            SENOIR_MEMBER_IN_POLITICAL_PARTY = "YES";
        }
        else
        {
            SENOIR_MEMBER_IN_POLITICAL_PARTY = "NO";

        }
        if (Rb_cstm_kyc_hvitem_yes.Checked == true)
        {
            DEAL_IN_HIGH_VALUE_ITEMS = "YES";
        }
        else
        {
            DEAL_IN_HIGH_VALUE_ITEMS = "NO";

        }

        if (Rb_cstm_kyc_wealth_yes.Checked == true)
        {
            //DEAL_IN_HIGH_VALUE_ITEMS = "YES";
            CUSTOMER_WEALTH_P = "YES";               
        }
        else
        {
            CUSTOMER_WEALTH_P = "NO";
        }

        if (Rb_cstm_kyc_head_state_yes.Checked == true)
        {  HEAD_OF_STATE_P = "YES";}
        else
        { HEAD_OF_STATE_P = "NO"; }

        if (Rb_cstm_kyc_adviser_yes.Checked == true)
        { ADVISER_P = "YES"; }
        else
        { ADVISER_P ="NO"; }

        if (Rb_cstm_kyc_judicial_yes.Checked == true)
        { JUDICIAL_OFFICER_P = "YES"; }
        else
        { JUDICIAL_OFFICER_P = "NO"; }

        if (Rb_cstm_kyc_military_yes.Checked == true)
        { MILITARY_P = "YES"; }
        else
        { MILITARY_P = "NO"; }

        if (Rb_cstm_kyc_hod_yes.Checked == true)
        { HOD_P = "YES"; }
        else
        { HOD_P = "NO"; }

        if (Rb_cstm_kyc_io_yes.Checked == true)
        { INTERNATIONAL_ORGANIZATION_P = "YES"; }
        else
        { INTERNATIONAL_ORGANIZATION_P = "NO"; }

        if (Rb_cstm_kyc_mob_yes.Checked == true)
        { MOB_P = "YES"; }
        else
        { MOB_P = "NO"; }

        if (Rb_cstm_kyc_assembly_yes.Checked == true)
        { ASSEMBLY_P = "YES"; }
        else
        { ASSEMBLY_P = "NO"; }

        if (Rb_cstm_kyc_party_yes.Checked == true)
        { PARTY_P = "YES"; }
        else
        { PARTY_P = "NO"; }

        if (Rb_cstm_kyc_fsupport_yes.Checked == true)
        { financially_supported = "YES"; }
        else
        { financially_supported = "NO"; }




        WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN = ddl_kycq7.SelectedValue.ToUpper();


        string NOMINEE_CNIC_ONE = "";
        string NOMINEE_NAME_ONE = "";
        string SHARING_PERC_ONE = "";
        string RELATIONSHIP_WITH_PRINCIPLE_ONE_ = "";
        string NOMINEE_CNIC_TWO = "";
        string NOMINEE_NAME_TWO = "";
        string SHARING_PERC_TWO = "";
        string RELATIONSHIP_WITH_PRINCIPLE_TWO_ = "";
        string NOMINEE_CNIC_THREE = "";
        string NOMINEE_NAME_THREE = "";
        string SHARING_PERC_THREE = "";
        string RELATIONSHIP_WITH_PRINCIPLE_THREE_ = "";

        string Department = Session["DPTMnemonic"].ToString();

        string Img1 = string.Empty, Img2 = string.Empty, Img3 = string.Empty, Img4 = string.Empty;
        //if (txt_cnicnum.Text == "" || txt_name.Text == "" || txt_fathername.Text == "" || txt_maritalstatus.Text == "" || txt_date_of_birth.Text == "" || txt_cnic_expiry.Text == ""
        //|| txt_nationality.Text == "" || txt_religon.Text == "" || txt_address.Text == "" || txt_address.Text == "" || txt_email.Text == "" || (txt_city.Text == "" && txt_city.Visible)  /*|| txt_country.Text == ""*/
        //|| txt_cstm_accountname.Text == "" || txt_branch_name.Text == ""
        //    || (txt_cstm_bankname.Text == "" && txt_cstm_bankname.Visible) || txt_branch_name.Text == "" || ACCOUNT_TYPE == "" || OCCUPATION == "" || SOURCE_OF_INCOME == "" || NAME_OF_EMPLOYER_BUSINESS == ""
        //    || ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER == "" || ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON == "" || HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE == ""
        //    || SENOIR_MEMBER_IN_POLITICAL_PARTY == "" || DEAL_IN_HIGH_VALUE_ITEMS == "" || WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN == "")
        //{
        //    mystage_.Text = "main";
        //    mystage = "main";
        //    Lblmsg.Text = "Incomplete Data";
        //    Lblmsg.Visible = true;
        //    btn_go_back.Visible = true;
        //    panel_kycdetails.Visible = false;
        //    return;
        //}

        //if(txt_bankaddress.Text==""||txt_branch_name.Text==""||txt_branch_city.Text==""||txt_cstm_accountname.Text=="")
        //{  
        //}
        //        else { }   // in if condition we have to enter all the non nullable fields and in else conventional code will take place 

        #region MINOR
        if (ddloactype.SelectedValue.ToUpper() == "MINOR")
        {
            /////// BOTH OF THEM ARE TEMPROARY PURPOSES ///////////////
            // ACCOUNT_OPERATING_INSTRUCTION = "ONLY BY PRIN AC HOLDER";
            // ALLOCATION_SCHEME = "NONE";
            if (txt_cstm_mnr_ng.Text == "" || txt_cstm_mnr_gcnic.Text == "" || txt_cstm_mnr_cnic_expiry.Text == "" ||
                //txt_cstm_mnr_rwp.Text == ""
                ddlRelationWithPrinciple_mnr.SelectedItem.Text.ToUpper() == "")
            {

                mystage_.Text = "main";
                //mystage = "main";
                Lblmsg.Text = "invalid data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;
            }


            ACC_MINOR_CASE = "YES";

            //ACC_MINOR_RELATIONSHIP = txt_cstm_mnr_rwp.Text.ToUpper();

            ACC_MINOR_RELATIONSHIP = ddlRelationWithPrinciple_mnr.SelectedItem.Text.ToUpper();

            ACC_MINOR_GUARDIAN_NAME = txt_cstm_mnr_ng.Text.ToUpper();
            ACC_GUARDIAN_CNIC = txt_cstm_mnr_gcnic.Text.ToUpper();
            ACC_GUARDIAN_CNIC_EXPIRY_ = DateTime.Parse(txt_cstm_mnr_cnic_expiry.Text);
            ACCOUNT_OPERATING_INSTRUCTION = null;
            ALLOCATION_SCHEME = null;

            string PRINCIPLE_CNIC = txt_cnicnum.Text.ToUpper();
            string JOINT_HOLDER_ONE_CNIC = string.Empty;
            string JOINT_HOLDER_ONE_NAME = string.Empty;
            string RELATIONSHIP_WITH_PRINCIPLE_ONE = string.Empty;
            string JOINT_HOLDER_TWO_CNIC = string.Empty;
            string JOINT_HOLDER_TWO_NAME = string.Empty;
            string RELATIONSHIP_WITH_PRINCIPLE_TWO = string.Empty;
            ////////////////////////////  SP CALL /////////////////////////

            // acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
            // , RELIGON, CNIC_EXPIRY_DATE_, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
            // ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
            // BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP);

            // acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS);

            // acc_opening.customer_kyc_questions(CNIC,
            // ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            // ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
            // HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            // SENOIR_MEMBER_IN_POLITICAL_PARTY,
            //DEAL_IN_HIGH_VALUE_ITEMS,
            //WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN);
            //////////////////////////////////// fatca form ////////////////////////////////////////

            TITLE_OF_ACCOUNT = txt_ftca_acctitle.Text.ToUpper();
            TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "";
            if (Rb_ftca_ctrotp_none.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "NONE"; }
            if (Rb_ftca_ctrotp_USA.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "USA"; }
            if (Rb_ftca_ctrotp_other.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = txt_ftca_ctrotp_other_cntry.Text; }

            PLACE_OF_BIRTH_CITY = txt_ftca_pob_city.Text.ToUpper();
            PLACE_OF_BIRTH_STATE = txt_ftca_pob_bstate.Text.ToUpper();
            PLACE_OF_BIRTH_COUNTRY = txt_ftca_pob_birthcountry.Text.ToUpper();
            if (Rb_ftca_uscitizen_yes.Checked == true)
            {
                US_CITIZEN = "YES";
            }
            else { US_CITIZEN = "NO"; }
            if (Rb_ftca_usresdnt_yes.Checked == true)
            {
                US_RESIDENT = "YES";
            }
            else
            {
                US_RESIDENT = "NO";
            }
            if (Rb_ftca_usgc_yes.Checked == true)
            {
                GREEEN_CARD = "YES";
            }
            else
            {
                GREEEN_CARD = "NO";
            }

            if (Rb_ftca_usborn_yes.Checked == true)
            {
                DOB_OF_USA = "YES";
            }
            else
            {
                DOB_OF_USA = "NO";
            }
            if (Rb_ftca_ussitf_yes.Checked == true)
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "YES";
            }
            else
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "NO";
            }
            if (Rb_ftca_uspa_yes.Checked == true)
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "YES";
            }
            else
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "NO";
            }
            if (Rb_ftca_usaddr_yes.Checked == true)
            {
                US_RESIDENCE_MAIL_ADDRESS = "YES";
            }
            else
            {
                US_RESIDENCE_MAIL_ADDRESS = "NO";
            }
            if (Rb_ftca_ustn_yes.Checked == true)
            {
                US_TELELPHONE_NUMBER = "YES";
            }
            else
            {
                US_TELELPHONE_NUMBER = "NO";
            }

            if (CNIC == "" || TITLE_OF_ACCOUNT == "" || TAX_RESIDENCE_OTHER_THAN_PAKISTAN == "" || PLACE_OF_BIRTH_CITY == "" || PLACE_OF_BIRTH_STATE == ""
                || PLACE_OF_BIRTH_COUNTRY == "" || US_CITIZEN == "" || US_RESIDENT == "" || GREEEN_CARD == "" || DOB_OF_USA == "" || TRANSFER_FUND_TO_USA_ACCOUNT == ""
                || POWER_OF_ATTORNEY_USA_ADDRESS == "" || US_RESIDENCE_MAIL_ADDRESS == "" || US_TELELPHONE_NUMBER == "")
            {
                mystage_.Text = "fatca";
                //mystage = "fatca";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }

            //acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
            //PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
            //US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
            //TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
            //US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_age_39.Checked == true) { AGE = "BELOW 40"; AGERPF = 4; }
            if (Rb_rpf_age_40.Checked == true) { AGE = "40-50"; AGERPF = 3; }
            if (Rb_rpf_age_50.Checked == true) { AGE = "50-60"; AGERPF = 2; }
            if (Rb_rpf_age_60.Checked == true) { AGE = "ABOVE 60"; AGERPF = 1; }
            //////////////////////////////////////////////////////////////////////      
            if (Rb_rpf_rtl_lr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_lr.Text; RRTL = 1; }
            if (Rb_rpf_rtl_mr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_mr.Text; RRTL = 4; }
            if (Rb_rpf_rtl_hr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_hr.Text; RRTL = 8; }
            /////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ms_25.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_25.Text; MS = 2; }
            if (Rb_rpf_ms_50.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_50.Text; MS = 2; }
            if (Rb_rpf_ms_150.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_150.Text; MS = 2; }
            if (Rb_rpf_ms_500.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_500.Text; MS = 2; }
            ////////////////////////////////////////////////////////////////////
            if (Rb_rpf_oc_rtd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_rtd.Text; OCCP = 3; }
            if (Rb_rpf_oc_hws.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_hws.Text; OCCP = 2; }
            if (Rb_rpf_oc_slrd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_slrd.Text; OCCP = 3; }
            if (Rb_rpf_oc_bse.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_bse.Text; OCCP = 4; }
            //////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ib_cm.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_cm.Text; IO = 2; }
            if (Rb_rpf_ib_mi.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_mi.Text; IO = 4; }
            if (Rb_rpf_ib_lts.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_lts.Text; IO = 8; }
            if (Rb_rpf_ib_rtmnt.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_rtmnt.Text; IO = 8; }
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_kifm_lk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_lk.Text; KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ak.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ak.Text; KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_bk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_bk.Text; KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_gk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_gk.Text; KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ek.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ek.Text; KNOWLEDGE = 2; }
            /////////////////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ih_1yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_1yr.Text; IH = 4; }
            if (Rb_rpf_ih_5yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_5yr.Text; IH = 8; }
            if (Rb_rpf_ih_35yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_35yr.Text; IH = 8; }

            if (Rb_rpf_ih_23yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_23yr.Text; IH = 6; }

            if (Rb_ih_6mnths.Checked == true) { INVESTMENT_HORIZON = Rb_ih_6mnths.Text; IH = 2; }

            int sum = IH + KNOWLEDGE + IO + OCCP + MS + RRTL + AGERPF;
            if (sum >= 33)
            {
                IDEAL_PORTFOLIO_SCORE = "33-38";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "AGGRESSIVE";
                IDEAL_PORTFOLIO_FUND = "EQUITY";
                Rb_rpf_scr_38.Visible = true;

            }
            if (sum >= 24 && sum <= 32)
            {
                IDEAL_PORTFOLIO_SCORE = "24-32";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "BALANCE";
                IDEAL_PORTFOLIO_FUND = "BALANCED";
                Rb_rpf_scr_32.Visible = true;

            }
            if (sum >= 15 && sum <= 23)
            {
                IDEAL_PORTFOLIO_SCORE = "15-23";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "STABLE";
                IDEAL_PORTFOLIO_FUND = "INCOME";
                Rb_rpf_scr_23.Visible = true;

            }

            if (sum >= 11 && sum <= 14)
            {
                IDEAL_PORTFOLIO_SCORE = "11-14";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "CONSERVATIVE";
                IDEAL_PORTFOLIO_FUND = "MONEY MARKET";
                Rb_rpf_scr_14.Visible = true;

            }


            if (AGE == "" || RISK_RETURN_TOLERENCE_LEVEL == "" || MONTHLY_SAVINGS == "" || OCCUPATION == "" || INVESTMENT_OBJECTIVE == "" || KNOWLEDGE_LEVEL == ""
                || INVESTMENT_HORIZON == "" || IDEAL_PORTFOLIO_SCORE == "" || IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO == "" || IDEAL_PORTFOLIO_FUND == "")
            {

                //mystage_.Text = "rpf";
                mystage = "rpf";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }



            ///////////////////////// RISK PROFILE SP CALLED ////////////////////////////////////// 

            acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
              , RELIGON, CNIC_EXPIRY_DATE_, CNIC_EXP_RENEW_NUM, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, MOBILE_NETWORK, PORTED, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
              ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
              BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP, DAO_ID, CNIC_ISSUE_DATE_, Department, Session["Username"].ToString(), Img1, Img2, Img3, Img4, MOTHER_NAME, DUAL_NATIONAL, resident_Status, p_address, p_country, p_city, pob);

            acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS, Geographic_Involved_Domestic, Geographic_Involved_International, Type_of_Counterparty_Domestic, Type_of_Counterparty_International, Possible_modes_of_transactions, Possible_No_of_transactions, Possible_Turnover_in_Account, Annual_Gross_Income, Amount_of_Investment, PEP, Name_of_Ultimate_Beneficiary, CNIC_Passport_No_of_Beneficiary, Relationship_with_Customer, Possible_turnover_in_acount_annual, DESIGNATION, NATURE_BUSINESS);

            acc_opening.customer_kyc_questions(CNIC,
            ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
            HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            SENOIR_MEMBER_IN_POLITICAL_PARTY,
           DEAL_IN_HIGH_VALUE_ITEMS,
           WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN, HEAD_OF_STATE_P, ADVISER_P, JUDICIAL_OFFICER_P, MILITARY_P, HOD_P,
           INTERNATIONAL_ORGANIZATION_P, ASSEMBLY_P, PARTY_P, HEAD_OF_STATE_j1, ADVISER_j1, JUDICIAL_OFFICER_j1, MILITARY_j1,
           HOD_j1, INTERNATIONAL_ORGANIZATION_j1, ASSEMBLY_j1, PARTY_j1, HEAD_OF_STATE_j2, ADVISER_j2, JUDICIAL_OFFICER_j2,
           MILITARY_j2, HOD_j2, INTERNATIONAL_ORGANIZATION_j2, ASSEMBLY_j2, PARTY_j2, CUSTOMER_WEALTH_P,
           CUSTOMER_WEALTH_j1, CUSTOMER_WEALTH_j2, MOB_P, MOB_j1, MOB_j2,
           ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1, HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1,
           SENOIR_MEMBER_IN_POLITICAL_PARTY_J1, DEAL_IN_HIGH_VALUE_ITEMS_J1, ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2,
           HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2, SENOIR_MEMBER_IN_POLITICAL_PARTY_J2,
           DEAL_IN_HIGH_VALUE_ITEMS_J2, financially_supported, financially_supported_J1, financially_supported_J2);

            acc_opening.joint_holders_details(PRINCIPLE_CNIC, JOINT_HOLDER_ONE_CNIC, JOINT_HOLDER_ONE_NAME, RELATIONSHIP_WITH_PRINCIPLE_ONE, JOINT_HOLDER_TWO_CNIC, JOINT_HOLDER_TWO_NAME, RELATIONSHIP_WITH_PRINCIPLE_TWO, Basic_date, Basic_date, Basic_date, Basic_date);

            acc_opening.nominee_details(CNIC, NOMINEE_CNIC_ONE, NOMINEE_NAME_ONE, SHARING_PERC_ONE, RELATIONSHIP_WITH_PRINCIPLE_ONE_,
                                NOMINEE_CNIC_TWO, NOMINEE_NAME_TWO, SHARING_PERC_TWO, RELATIONSHIP_WITH_PRINCIPLE_TWO_, NOMINEE_CNIC_THREE, NOMINEE_NAME_THREE, SHARING_PERC_THREE, RELATIONSHIP_WITH_PRINCIPLE_THREE_);

            acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
         PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
         US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
         TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
         US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);


            acc_opening.risk_profile_form(CNIC, PORTFOLIO_NUMBER, OLD_REGNUMBER, AGE, RISK_RETURN_TOLERENCE_LEVEL,
                MONTHLY_SAVINGS, OCCUPATION_rpf, INVESTMENT_OBJECTIVE,
                KNOWLEDGE_LEVEL, INVESTMENT_HORIZON, IDEAL_PORTFOLIO_SCORE,
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO,
                IDEAL_PORTFOLIO_FUND);

        }
        #endregion

        #region JOINT
        if (ddloactype.SelectedValue.ToUpper() == "JOINT")
        {

            ACCOUNT_OPERATING_INSTRUCTION = ddloprt.SelectedValue;

            string PRINCIPLE_CNIC = txt_cnicnum.Text.ToUpper();
            string JOINT_HOLDER_ONE_CNIC = txt_cstm_jh_jhcnic1.Text.ToUpper();
            string JOINT_HOLDER_ONE_NAME = txt_cstm_jh_jhname1.Text.ToUpper();

            string Jh_ISSUE_DATE_1 = txt_cstm_jh1_cnic_issue_date.Text;
            string Jh_EXP_DATE_1 = txt_cstm_jh1_cnic_exp_date.Text;

            DateTime JH1_CNIC_ISSUE_DATE_ = DateTime.Parse(Jh_ISSUE_DATE_1);
            DateTime JH1_CNIC_EXPIRY_DATE_ = DateTime.Parse(Jh_EXP_DATE_1);

            //string RELATIONSHIP_WITH_PRINCIPLE_ONE = txt_cstm_jh_jhrwp1.Text.ToUpper();


            string RELATIONSHIP_WITH_PRINCIPLE_ONE = ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper();

            string JOINT_HOLDER_TWO_CNIC = txt_cstm_jh_jhcnic2.Text.ToUpper();
            string JOINT_HOLDER_TWO_NAME = txt_cstm_jh_jhname2.Text.ToUpper();
            //string RELATIONSHIP_WITH_PRINCIPLE_TWO = txt_cstm_jh_jhrwp2.Text.ToUpper();

            string Jh_ISSUE_DATE_2 = txt_cstm_jh2_cnic_issue_date.Text;
            string Jh_EXP_DATE_2 = txt_cstm_jh2_cnic_exp_date.Text;


            DateTime JH2_CNIC_ISSUE_DATE_ = DateTime.Parse(Jh_ISSUE_DATE_2);
            DateTime JH2_CNIC_EXPIRY_DATE_ = DateTime.Parse(Jh_EXP_DATE_2);



            string RELATIONSHIP_WITH_PRINCIPLE_TWO = ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper();



            NOMINEE_NAME_ONE = txt_cstm_mtpf_nname1.Text.ToUpper();
            NOMINEE_CNIC_ONE = txt_cstm_mtpf_ncnic1.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_ONE_ = txt_cstm_mtpf_nrwp1.Text.ToUpper();


            RELATIONSHIP_WITH_PRINCIPLE_ONE_ = ddlRelationWithPrinciple_N1.SelectedItem.Text.ToUpper();

            SHARING_PERC_ONE = txt_cstm_mtpf_sharing1.Text.ToUpper();
            NOMINEE_NAME_TWO = txt_cstm_mtpf_nname2.Text.ToUpper();
            NOMINEE_CNIC_TWO = txt_cstm_mtpf_ncnic2.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_TWO_ = txt_cstm_mtpf_nrwp2.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_TWO_ = ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper();

            SHARING_PERC_TWO = txt_cstm_mtpf_sharing2.Text.ToUpper();
            NOMINEE_NAME_THREE = txt_cstm_mtpf_nname3.Text.ToUpper();
            NOMINEE_CNIC_THREE = txt_cstm_mtpf_ncnic3.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_THREE_ = txt_cstm_mtpf_nrwp3.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_THREE_ = ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper();


            SHARING_PERC_THREE = txt_cstm_mtpf_sharing3.Text.ToUpper();

            EXPECTED_RETIREMENT_AGE = null;
            ACC_MINOR_CASE = "NO";
            ALLOCATION_SCHEME = null;



            ////////SP CALL///////////////////////////////////
            // acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
            //  , RELIGON, CNIC_EXPIRY_DATE_, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
            //  ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
            //  BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP);

            // ///// SP CALLED///////////////////////////////////
            // acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS);

            // acc_opening.customer_kyc_questions(CNIC,
            // ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            // ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
            // HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            // SENOIR_MEMBER_IN_POLITICAL_PARTY,
            //DEAL_IN_HIGH_VALUE_ITEMS,
            //WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN);

            ///////////// SP CALL/////////////////////////////

            if (txt_cstm_jh_jhcnic1.Text == "" || txt_cstm_jh_jhname1.Text == "" ||
                //txt_cstm_jh_jhrwp1.Text == ""
                ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper() == ""
                )
            {
                mystage_.Text = "main";
                //mystage="main";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }

            /////////////////////////// kyc for joint ///////////////////////////////////


            if (Rb_cstm_kyc_firoa_yes_j1.Checked == true)
            {
                ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1 = "YES";
            }
            else
            {
                ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1 = "NO";

            }
            if (Rb_cstm_kyc_spgi_yes_j1.Checked == true)
            {
                HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1 = "YES";
            }
            else
            {
                HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1 = "NO";

            }

            if (Rb_cstm_kyc_sppp_yes_j1.Checked == true)
            {
                SENOIR_MEMBER_IN_POLITICAL_PARTY_J1 = "YES";
            }
            else
            {
                SENOIR_MEMBER_IN_POLITICAL_PARTY_J1 = "NO";

            }



            if (Rb_cstm_kyc_fsupport_j1_yes.Checked == true)
            { financially_supported_J1 = "YES"; }
            else
            { financially_supported_J1 = "NO"; }


            
            if (Rb_cstm_kyc_hvitem_yes_j1.Checked == true)
            {
                DEAL_IN_HIGH_VALUE_ITEMS_J1 = "YES";
            }
            else
            {
                DEAL_IN_HIGH_VALUE_ITEMS_J1 = "NO";

            }

            if (Rb_cstm_kyc_wealth_yes_j1.Checked == true)
            {
                //DEAL_IN_HIGH_VALUE_ITEMS = "YES";
                CUSTOMER_WEALTH_j1 = "YES";
            }
            else
            {
                CUSTOMER_WEALTH_j1 = "NO";
            }

            if (Rb_cstm_kyc_head_state_yes_j1.Checked == true)
            { HEAD_OF_STATE_j1 = "YES"; }
            else
            { HEAD_OF_STATE_j1 = "NO"; }

            if (Rb_cstm_kyc_adviser_yes_j1.Checked == true)
            { ADVISER_j1 = "YES"; }
            else
            { ADVISER_j1 = "NO"; }

            if (Rb_cstm_kyc_judicial_yes_j1.Checked == true)
            { JUDICIAL_OFFICER_j1 = "YES"; }
            else
            { JUDICIAL_OFFICER_j1 = "NO"; }

            if (Rb_cstm_kyc_military_yes_j1.Checked == true)
            { MILITARY_j1 = "YES"; }
            else
            { MILITARY_j1 = "NO"; }

            if (Rb_cstm_kyc_hod_yes_j1.Checked == true)
            { HOD_j1 = "YES"; }
            else
            { HOD_j1 = "NO"; }

            if (Rb_cstm_kyc_io_yes_j1.Checked == true)
            { INTERNATIONAL_ORGANIZATION_j1 = "YES"; }
            else
            { INTERNATIONAL_ORGANIZATION_j1 = "NO"; }

            if (Rb_cstm_kyc_mob_yes_j1.Checked == true)
            { MOB_j1 = "YES"; }
            else
            { MOB_j1 = "NO"; }

            if (Rb_cstm_kyc_assembly_yes_j1.Checked == true)
            { ASSEMBLY_j1 = "YES"; }
            else
            { ASSEMBLY_j1 = "NO"; }

            if (Rb_cstm_kyc_party_yes_j1.Checked == true)
            { PARTY_j1 = "YES"; }
            else
            { PARTY_j1 = "NO"; }

            if ((txt_cstm_jh_jhcnic2.Text != "") && (txt_cstm_jh_jhname2.Text != ""))
            {

                if (Rb_cstm_kyc_firoa_yes_j2.Checked == true)
                {
                    ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2 = "YES";
                }
                else
                {
                    ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2 = "NO";

                }
                if (Rb_cstm_kyc_spgi_yes_j2.Checked == true)
                {
                    HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2 = "YES";
                }
                else
                {
                    HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2 = "NO";

                }

                if (Rb_cstm_kyc_sppp_yes_j2.Checked == true)
                {
                    SENOIR_MEMBER_IN_POLITICAL_PARTY_J2 = "YES";
                }
                else
                {
                    SENOIR_MEMBER_IN_POLITICAL_PARTY_J2 = "NO";

                }



                if (Rb_cstm_kyc_fsupport_j2_yes.Checked == true)
                { financially_supported_J2 = "YES"; }
                else
                { financially_supported_J2 = "NO"; }



                if (Rb_cstm_kyc_hvitem_yes_j2.Checked == true)
                {
                    DEAL_IN_HIGH_VALUE_ITEMS_J2 = "YES";
                }
                else
                {
                    DEAL_IN_HIGH_VALUE_ITEMS_J2 = "NO";

                }

                if (Rb_cstm_kyc_wealth_yes_j2.Checked == true)
                {
                    //DEAL_IN_HIGH_VALUE_ITEMS = "YES";
                    CUSTOMER_WEALTH_j2 = "YES";
                }
                else
                {
                    CUSTOMER_WEALTH_j2 = "NO";
                }

                if (Rb_cstm_kyc_head_state_yes_j2.Checked == true)
                { HEAD_OF_STATE_j2 = "YES"; }
                else
                { HEAD_OF_STATE_j2 = "NO"; }

                if (Rb_cstm_kyc_adviser_yes_j2.Checked == true)
                { ADVISER_j2 = "YES"; }
                else
                { ADVISER_j2 = "NO"; }

                if (Rb_cstm_kyc_judicial_yes_j2.Checked == true)
                { JUDICIAL_OFFICER_j2 = "YES"; }
                else
                { JUDICIAL_OFFICER_j2 = "NO"; }

                if (Rb_cstm_kyc_military_yes_j2.Checked == true)
                { MILITARY_j2 = "YES"; }
                else
                { MILITARY_j2 = "NO"; }

                if (Rb_cstm_kyc_hod_yes_j2.Checked == true)
                { HOD_j2 = "YES"; }
                else
                { HOD_j2 = "NO"; }

                if (Rb_cstm_kyc_io_yes_j2.Checked == true)
                { INTERNATIONAL_ORGANIZATION_j2 = "YES"; }
                else
                { INTERNATIONAL_ORGANIZATION_j2 = "NO"; }

                if (Rb_cstm_kyc_mob_yes_j2.Checked == true)
                { MOB_j2 = "YES"; }
                else
                { MOB_j2 = "NO"; }

                if (Rb_cstm_kyc_assembly_yes_j2.Checked == true)
                { ASSEMBLY_j2 = "YES"; }
                else
                { ASSEMBLY_j2 = "NO"; }

                if (Rb_cstm_kyc_party_yes_j2.Checked == true)
                { PARTY_j2 = "YES"; }
                else
                { PARTY_j2 = "NO"; }
            
            
            
            
            }
            else
            {






            }









            //acc_opening.joint_holders_details(PRINCIPLE_CNIC,JOINT_HOLDER_ONE_CNIC,JOINT_HOLDER_ONE_NAME,RELATIONSHIP_WITH_PRINCIPLE_ONE,JOINT_HOLDER_TWO_CNIC,JOINT_HOLDER_TWO_NAME,RELATIONSHIP_WITH_PRINCIPLE_TWO);

            //if (rb_add_another.Checked == true)
            //{
            //    PRINCIPLE_CNIC = txt_cnicnum.Text;


            //    acc_opening.joint_holders_details(PRINCIPLE_CNIC, JOINT_HOLDER_CNIC2, JOINT_HOLDER_NAME2, RELATIONSHIP_WITH_PRINCIPLE2);
            //    rb_add_another.Checked = false;
            //    rb_add_another.Visible = false;

            //}
            //////////////////////////////////// fatca form ////////////////////////////////////////
            TITLE_OF_ACCOUNT = txt_ftca_acctitle.Text;
            TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "";
            if (Rb_ftca_ctrotp_none.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "NONE"; }
            if (Rb_ftca_ctrotp_USA.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "USA"; }
            if (Rb_ftca_ctrotp_other.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = txt_ftca_ctrotp_other_cntry.Text; }

            PLACE_OF_BIRTH_CITY = txt_ftca_pob_city.Text.ToUpper();
            PLACE_OF_BIRTH_STATE = txt_ftca_pob_bstate.Text.ToUpper();
            PLACE_OF_BIRTH_COUNTRY = txt_ftca_pob_birthcountry.Text.ToUpper();
            if (Rb_ftca_uscitizen_yes.Checked == true)
            {
                US_CITIZEN = "YES";
            }
            else { US_CITIZEN = "NO"; }
            if (Rb_ftca_usresdnt_yes.Checked == true)
            {
                US_RESIDENT = "YES";
            }
            else
            {
                US_RESIDENT = "NO";
            }
            if (Rb_ftca_usgc_yes.Checked == true)
            {
                GREEEN_CARD = "YES";
            }
            else
            {
                GREEEN_CARD = "NO";
            }

            if (Rb_ftca_usborn_yes.Checked == true)
            {
                DOB_OF_USA = "YES";
            }
            else
            {
                DOB_OF_USA = "NO";
            }
            if (Rb_ftca_ussitf_yes.Checked == true)
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "YES";
            }
            else
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "NO";
            }
            if (Rb_ftca_uspa_yes.Checked == true)
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "YES";
            }
            else
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "NO";
            }
            if (Rb_ftca_usaddr_yes.Checked == true)
            {
                US_RESIDENCE_MAIL_ADDRESS = "YES";
            }
            else
            {
                US_RESIDENCE_MAIL_ADDRESS = "NO";
            }
            if (Rb_ftca_ustn_yes.Checked == true)
            {
                US_TELELPHONE_NUMBER = "YES";
            }
            else
            {
                US_TELELPHONE_NUMBER = "NO";
            }
            if (CNIC == "" || TITLE_OF_ACCOUNT == "" || TAX_RESIDENCE_OTHER_THAN_PAKISTAN == "" || PLACE_OF_BIRTH_CITY == "" || PLACE_OF_BIRTH_STATE == ""
               || PLACE_OF_BIRTH_COUNTRY == "" || US_CITIZEN == "" || US_RESIDENT == "" || GREEEN_CARD == "" || DOB_OF_USA == "" || TRANSFER_FUND_TO_USA_ACCOUNT == ""
               || POWER_OF_ATTORNEY_USA_ADDRESS == "" || US_RESIDENCE_MAIL_ADDRESS == "" || US_TELELPHONE_NUMBER == "")
            {
                mystage_.Text = "fatca";
                //mystage="fatca";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }


            //acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
            //PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
            //US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
            //TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
            //US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_age_39.Checked == true) { AGE = "BELOW 40"; AGERPF = 4; }
            if (Rb_rpf_age_40.Checked == true) { AGE = "40-50"; AGERPF = 3; }
            if (Rb_rpf_age_50.Checked == true) { AGE = "50-60"; AGERPF = 2; }
            if (Rb_rpf_age_60.Checked == true) { AGE = "ABOVE 60"; AGERPF = 1; }
            //////////////////////////////////////////////////////////////////////      
            if (Rb_rpf_rtl_lr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_lr.Text.ToUpper(); RRTL = 1; }
            if (Rb_rpf_rtl_mr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_mr.Text.ToUpper(); RRTL = 4; }
            if (Rb_rpf_rtl_hr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_hr.Text.ToUpper(); RRTL = 8; }
            /////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ms_25.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_25.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_50.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_50.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_150.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_150.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_500.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_500.Text.ToUpper(); MS = 2; }
            ////////////////////////////////////////////////////////////////////
            if (Rb_rpf_oc_rtd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_rtd.Text.ToUpper(); OCCP = 3; }
            if (Rb_rpf_oc_hws.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_hws.Text.ToUpper(); OCCP = 2; }
            if (Rb_rpf_oc_slrd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_slrd.Text.ToUpper(); OCCP = 3; }
            if (Rb_rpf_oc_bse.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_bse.Text.ToUpper(); OCCP = 4; }
            //////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ib_cm.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_cm.Text.ToUpper(); IO = 2; }
            if (Rb_rpf_ib_mi.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_mi.Text.ToUpper(); IO = 4; }
            if (Rb_rpf_ib_lts.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_lts.Text.ToUpper(); IO = 8; }
            if (Rb_rpf_ib_rtmnt.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_rtmnt.Text.ToUpper(); IO = 8; }
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_kifm_lk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_lk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ak.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ak.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_bk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_bk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_gk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_gk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ek.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ek.Text.ToUpper(); KNOWLEDGE = 2; }
            /////////////////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ih_1yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_1yr.Text.ToUpper(); IH = 4; }
            if (Rb_rpf_ih_5yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_5yr.Text.ToUpper(); IH = 8; }
            if (Rb_rpf_ih_35yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_35yr.Text.ToUpper(); IH = 8; }

            if (Rb_rpf_ih_23yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_23yr.Text.ToUpper(); IH = 6; }

            if (Rb_ih_6mnths.Checked == true) { INVESTMENT_HORIZON = Rb_ih_6mnths.Text.ToUpper(); IH = 2; }

            int sum = IH + KNOWLEDGE + IO + OCCP + MS + RRTL + AGERPF;
            if (sum >= 33)
            {
                IDEAL_PORTFOLIO_SCORE = "33-38";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "AGGRESSIVE";
                IDEAL_PORTFOLIO_FUND = "EQUITY";
                Rb_rpf_scr_38.Visible = true;

            }
            if (sum >= 24 && sum <= 32)
            {
                IDEAL_PORTFOLIO_SCORE = "24-32";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "BALANCE";
                IDEAL_PORTFOLIO_FUND = "BALANCED";
                Rb_rpf_scr_32.Visible = true;

            }
            if (sum >= 15 && sum <= 23)
            {
                IDEAL_PORTFOLIO_SCORE = "15-23";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "STABLE";
                IDEAL_PORTFOLIO_FUND = "INCOME";
                Rb_rpf_scr_23.Visible = true;

            }

            if (sum >= 11 && sum <= 14)
            {
                IDEAL_PORTFOLIO_SCORE = "11-14";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "CONSERVATIVE";
                IDEAL_PORTFOLIO_FUND = "MONEY MARKET";
                Rb_rpf_scr_14.Visible = true;

            }

            if (AGE == "" || RISK_RETURN_TOLERENCE_LEVEL == "" || MONTHLY_SAVINGS == "" || OCCUPATION == "" || INVESTMENT_OBJECTIVE == "" || KNOWLEDGE_LEVEL == ""
           || INVESTMENT_HORIZON == "" || IDEAL_PORTFOLIO_SCORE == "" || IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO == "" || IDEAL_PORTFOLIO_FUND == "")
            {
                mystage_.Text = "rpf";
                mystage = "rpf";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }



            ///////////////////////// RISK PROFILE SP CALLED ////////////////////////////////////// 


            acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
               , RELIGON, CNIC_EXPIRY_DATE_, CNIC_EXP_RENEW_NUM, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, MOBILE_NETWORK, PORTED, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
               ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
               BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP, DAO_ID, CNIC_ISSUE_DATE_, Department, Session["Username"].ToString(), Img1, Img2, Img3, Img4, MOTHER_NAME, DUAL_NATIONAL, resident_Status, p_address, p_country, p_city, pob);

            ///// SP CALLED///////////////////////////////////
            acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS, Geographic_Involved_Domestic, Geographic_Involved_International, Type_of_Counterparty_Domestic, Type_of_Counterparty_International, Possible_modes_of_transactions, Possible_No_of_transactions, Possible_Turnover_in_Account, Annual_Gross_Income, Amount_of_Investment, PEP, Name_of_Ultimate_Beneficiary, CNIC_Passport_No_of_Beneficiary, Relationship_with_Customer, Possible_turnover_in_acount_annual, DESIGNATION, NATURE_BUSINESS);

            acc_opening.customer_kyc_questions(CNIC,
            ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
            HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            SENOIR_MEMBER_IN_POLITICAL_PARTY,
           DEAL_IN_HIGH_VALUE_ITEMS,
           WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN, HEAD_OF_STATE_P, ADVISER_P, JUDICIAL_OFFICER_P, MILITARY_P, HOD_P,
           INTERNATIONAL_ORGANIZATION_P, ASSEMBLY_P, PARTY_P, HEAD_OF_STATE_j1, ADVISER_j1, JUDICIAL_OFFICER_j1, MILITARY_j1,
           HOD_j1, INTERNATIONAL_ORGANIZATION_j1, ASSEMBLY_j1, PARTY_j1, HEAD_OF_STATE_j2, ADVISER_j2, JUDICIAL_OFFICER_j2,
           MILITARY_j2, HOD_j2, INTERNATIONAL_ORGANIZATION_j2, ASSEMBLY_j2, PARTY_j2, CUSTOMER_WEALTH_P,
           CUSTOMER_WEALTH_j1, CUSTOMER_WEALTH_j2, MOB_P, MOB_j1, MOB_j2,
           ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1, HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1,
           SENOIR_MEMBER_IN_POLITICAL_PARTY_J1, DEAL_IN_HIGH_VALUE_ITEMS_J1, ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2,
           HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2, SENOIR_MEMBER_IN_POLITICAL_PARTY_J2,
           DEAL_IN_HIGH_VALUE_ITEMS_J2, financially_supported, financially_supported_J1, financially_supported_J2);



            acc_opening.joint_holders_details(PRINCIPLE_CNIC, JOINT_HOLDER_ONE_CNIC, JOINT_HOLDER_ONE_NAME, RELATIONSHIP_WITH_PRINCIPLE_ONE, JOINT_HOLDER_TWO_CNIC, JOINT_HOLDER_TWO_NAME, RELATIONSHIP_WITH_PRINCIPLE_TWO, JH1_CNIC_ISSUE_DATE_, JH1_CNIC_EXPIRY_DATE_, JH2_CNIC_ISSUE_DATE_, JH2_CNIC_EXPIRY_DATE_);

            acc_opening.nominee_details(CNIC, NOMINEE_CNIC_ONE, NOMINEE_NAME_ONE, SHARING_PERC_ONE, RELATIONSHIP_WITH_PRINCIPLE_ONE_,
                    NOMINEE_CNIC_TWO, NOMINEE_NAME_TWO, SHARING_PERC_TWO, RELATIONSHIP_WITH_PRINCIPLE_TWO_, NOMINEE_CNIC_THREE, NOMINEE_NAME_THREE, SHARING_PERC_THREE, RELATIONSHIP_WITH_PRINCIPLE_THREE_);

            acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
           PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
           US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
           TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
           US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);

            acc_opening.risk_profile_form(CNIC, PORTFOLIO_NUMBER, OLD_REGNUMBER, AGE, RISK_RETURN_TOLERENCE_LEVEL,
                MONTHLY_SAVINGS, OCCUPATION_rpf, INVESTMENT_OBJECTIVE,
                KNOWLEDGE_LEVEL, INVESTMENT_HORIZON, IDEAL_PORTFOLIO_SCORE,
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO,
                IDEAL_PORTFOLIO_FUND);

        }
        #endregion
        //string EXPECTED_RETIREMENT_AGE = retirement_age.Text;

        //string ALLOCATION_SCHEME = Request.Form["ddlomtpfac"];

        // DateTime dt = DateTime;




        DateTime date = DateTime.Now.Date;
        // string TIME_STAMP = date.ToString("yyyy/mm/dd 00:00:00.000");
        #region MTPF
        if (ddloactype.SelectedValue.ToUpper() == "MTPF")
        {

            ACC_MINOR_CASE = "NO";
            ACCOUNT_OPERATING_INSTRUCTION = "";
            ALLOCATION_SCHEME = ddlomtpfac.SelectedValue.ToUpper();
            EXPECTED_RETIREMENT_AGE = retirement_age.Text.ToUpper();

            string PRINCIPLE_CNIC = txt_cnicnum.Text.ToUpper();
            string JOINT_HOLDER_ONE_CNIC = txt_cstm_jh_jhcnic1.Text.ToUpper();
            string JOINT_HOLDER_ONE_NAME = txt_cstm_jh_jhname1.Text.ToUpper();
            //string RELATIONSHIP_WITH_PRINCIPLE_ONE = txt_cstm_jh_jhrwp1.Text.ToUpper();

            string RELATIONSHIP_WITH_PRINCIPLE_ONE = ddlRelationWithPrinciple_J1.SelectedItem.Text.ToUpper();

            string JOINT_HOLDER_TWO_CNIC = txt_cstm_jh_jhcnic2.Text.ToUpper();
            string JOINT_HOLDER_TWO_NAME = txt_cstm_jh_jhname2.Text.ToUpper();
            // string RELATIONSHIP_WITH_PRINCIPLE_TWO = txt_cstm_jh_jhrwp2.Text.ToUpper();

            string RELATIONSHIP_WITH_PRINCIPLE_TWO = ddlRelationWithPrinciple_J2.SelectedItem.Text.ToUpper();



            //acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
            //    , RELIGON, CNIC_EXPIRY_DATE_, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
            //    ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
            //    BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP);

            // acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS);

            // acc_opening.customer_kyc_questions(CNIC,
            // ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            // ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
            // HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            // SENOIR_MEMBER_IN_POLITICAL_PARTY,
            //DEAL_IN_HIGH_VALUE_ITEMS,
            //WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN);

            NOMINEE_NAME_ONE = txt_cstm_mtpf_nname1.Text.ToUpper();
            NOMINEE_CNIC_ONE = txt_cstm_mtpf_ncnic1.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_ONE_ = txt_cstm_mtpf_nrwp1.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_ONE_ = ddlRelationWithPrinciple_N1.SelectedItem.Text.ToUpper();



            SHARING_PERC_ONE = txt_cstm_mtpf_sharing1.Text.ToUpper();
            NOMINEE_NAME_TWO = txt_cstm_mtpf_nname2.Text.ToUpper();
            NOMINEE_CNIC_TWO = txt_cstm_mtpf_ncnic2.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_TWO_ = txt_cstm_mtpf_nrwp2.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_TWO_ = ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper();

            SHARING_PERC_TWO = txt_cstm_mtpf_sharing2.Text.ToUpper();
            NOMINEE_NAME_THREE = txt_cstm_mtpf_nname3.Text.ToUpper();
            NOMINEE_CNIC_THREE = txt_cstm_mtpf_ncnic3.Text.ToUpper();
            // RELATIONSHIP_WITH_PRINCIPLE_THREE_ = txt_cstm_mtpf_nrwp3.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_THREE_ = ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper();

            SHARING_PERC_THREE = txt_cstm_mtpf_sharing3.Text.ToUpper();

            //if(NOMINEE_CNIC_ONE!=""||NOMINEE_NAME_ONE==""||SHARING_PERC_ONE==""||RELATIONSHIP_WITH_PRINCIPLE_ONE_=="")
            //{
            //    Lblmsg.Text = "incomplete details";
            //    Lblmsg.Visible = true;
            //    btn_go_back.Visible = true;
            //    panel_kycdetails.Visible = false;
            //    return;
            //}



            //acc_opening.nominee_details(CNIC, NOMINEE_CNIC_ONE, NOMINEE_NAME_ONE, SHARING_PERC_ONE, RELATIONSHIP_WITH_PRINCIPLE_ONE_,
            //    NOMINEE_CNIC_TWO, NOMINEE_NAME_TWO, SHARING_PERC_TWO, RELATIONSHIP_WITH_PRINCIPLE_TWO_, NOMINEE_CNIC_THREE, NOMINEE_NAME_THREE, SHARING_PERC_THREE, RELATIONSHIP_WITH_PRINCIPLE_THREE_);


            //if (txt_cstm_mtpf_nname1.Text != "" && txt_cstm_mtpf_ncnic1.Text != "" && txt_cstm_mtpf_nrwp1.Text != "" && txt_cstm_mtpf_sharing1.Text != "")
            //{

            //    acc_opening.nominee_details(CNIC, NOMINEE_CNIC, NOMINEE_NAME, SHARING_PERC, RELATIONSHIP_WITH_PRINCIPLE_NOMINEE);
            //}

            //if (txt_cstm_mtpf_nname2.Text != "" && txt_cstm_mtpf_ncnic2.Text != "" && txt_cstm_mtpf_nrwp2.Text != "" && txt_cstm_mtpf_sharing2.Text != "")
            //{

            //                    acc_opening.nominee_details(CNIC, NOMINEE_CNIC, NOMINEE_NAME, SHARING_PERC, RELATIONSHIP_WITH_PRINCIPLE_NOMINEE);

            //}
            //if (txt_cstm_mtpf_nname3.Text != "" && txt_cstm_mtpf_ncnic3.Text != "" && txt_cstm_mtpf_nrwp3.Text != "" && txt_cstm_mtpf_sharing3.Text != "")
            //{


            //    acc_opening.nominee_details(CNIC, NOMINEE_CNIC, NOMINEE_NAME, SHARING_PERC, RELATIONSHIP_WITH_PRINCIPLE_NOMINEE);

            //}

            //////////////////////////////////// fatca form ////////////////////////////////////////
            TITLE_OF_ACCOUNT = txt_ftca_acctitle.Text;
            TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "";
            if (Rb_ftca_ctrotp_none.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "NONE"; }
            if (Rb_ftca_ctrotp_USA.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "USA"; }
            if (Rb_ftca_ctrotp_other.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = txt_ftca_ctrotp_other_cntry.Text; }

            PLACE_OF_BIRTH_CITY = txt_ftca_pob_city.Text;
            PLACE_OF_BIRTH_STATE = txt_ftca_pob_bstate.Text;
            PLACE_OF_BIRTH_COUNTRY = txt_ftca_pob_birthcountry.Text;
            if (Rb_ftca_uscitizen_yes.Checked == true)
            {
                US_CITIZEN = "YES";
            }
            else { US_CITIZEN = "NO"; }
            if (Rb_ftca_usresdnt_yes.Checked == true)
            {
                US_RESIDENT = "YES";
            }
            else
            {
                US_RESIDENT = "NO";
            }
            if (Rb_ftca_usgc_yes.Checked == true)
            {
                GREEEN_CARD = "YES";
            }
            else
            {
                GREEEN_CARD = "NO";
            }

            if (Rb_ftca_usborn_yes.Checked == true)
            {
                DOB_OF_USA = "YES";
            }
            else
            {
                DOB_OF_USA = "NO";
            }
            if (Rb_ftca_ussitf_yes.Checked == true)
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "YES";
            }
            else
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "NO";
            }
            if (Rb_ftca_uspa_yes.Checked == true)
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "YES";
            }
            else
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "NO";
            }
            if (Rb_ftca_usaddr_yes.Checked == true)
            {
                US_RESIDENCE_MAIL_ADDRESS = "YES";
            }
            else
            {
                US_RESIDENCE_MAIL_ADDRESS = "NO";
            }
            if (Rb_ftca_ustn_yes.Checked == true)
            {
                US_TELELPHONE_NUMBER = "YES";
            }
            else
            {
                US_TELELPHONE_NUMBER = "NO";
            }

            if (CNIC == "" || TITLE_OF_ACCOUNT == "" || TAX_RESIDENCE_OTHER_THAN_PAKISTAN == "" || PLACE_OF_BIRTH_CITY == "" || PLACE_OF_BIRTH_STATE == ""
                || PLACE_OF_BIRTH_COUNTRY == "" || US_CITIZEN == "" || US_RESIDENT == "" || GREEEN_CARD == "" || DOB_OF_USA == "" || TRANSFER_FUND_TO_USA_ACCOUNT == ""
                || POWER_OF_ATTORNEY_USA_ADDRESS == "" || US_RESIDENCE_MAIL_ADDRESS == "" || US_TELELPHONE_NUMBER == "")
            {
                mystage_.Text = "fatca";
                mystage = "fatca";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }
            //  acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
            //PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
            //US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
            //TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
            //US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);



            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_age_39.Checked == true) { AGE = "BELOW 40"; AGERPF = 4; }
            if (Rb_rpf_age_40.Checked == true) { AGE = "40-50"; AGERPF = 3; }
            if (Rb_rpf_age_50.Checked == true) { AGE = "50-60"; AGERPF = 2; }
            if (Rb_rpf_age_60.Checked == true) { AGE = "ABOVE 60"; AGERPF = 1; }
            //////////////////////////////////////////////////////////////////////      
            if (Rb_rpf_rtl_lr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_lr.Text.ToUpper(); RRTL = 1; }
            if (Rb_rpf_rtl_mr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_mr.Text.ToUpper(); RRTL = 4; }
            if (Rb_rpf_rtl_hr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_hr.Text.ToUpper(); RRTL = 8; }
            /////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ms_25.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_25.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_50.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_50.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_150.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_150.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_500.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_500.Text.ToUpper(); MS = 2; }
            ////////////////////////////////////////////////////////////////////
            if (Rb_rpf_oc_rtd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_rtd.Text.ToUpper(); OCCP = 3; }
            if (Rb_rpf_oc_hws.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_hws.Text.ToUpper(); OCCP = 2; }
            if (Rb_rpf_oc_slrd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_slrd.Text.ToUpper(); OCCP = 3; }
            if (Rb_rpf_oc_bse.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_bse.Text.ToUpper(); OCCP = 4; }
            //////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ib_cm.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_cm.Text.ToUpper(); IO = 2; }
            if (Rb_rpf_ib_mi.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_mi.Text.ToUpper(); IO = 4; }
            if (Rb_rpf_ib_lts.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_lts.Text.ToUpper(); IO = 8; }
            if (Rb_rpf_ib_rtmnt.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_rtmnt.Text.ToUpper(); IO = 8; }
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_kifm_lk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_lk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ak.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ak.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_bk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_bk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_gk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_gk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ek.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ek.Text.ToUpper(); KNOWLEDGE = 2; }
            /////////////////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ih_1yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_1yr.Text.ToUpper(); IH = 4; }
            if (Rb_rpf_ih_5yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_5yr.Text.ToUpper(); IH = 8; }
            if (Rb_rpf_ih_35yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_35yr.Text.ToUpper(); IH = 8; }

            if (Rb_rpf_ih_23yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_23yr.Text.ToUpper(); IH = 6; }

            if (Rb_ih_6mnths.Checked == true) { INVESTMENT_HORIZON = Rb_ih_6mnths.Text.ToUpper(); IH = 2; }

            int sum = IH + KNOWLEDGE + IO + OCCP + MS + RRTL + AGERPF;
            if (sum >= 33)
            {
                IDEAL_PORTFOLIO_SCORE = "33-38";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "AGGRESSIVE";
                IDEAL_PORTFOLIO_FUND = "EQUITY";
                Rb_rpf_scr_38.Visible = true;

            }
            if (sum >= 24 && sum <= 32)
            {
                IDEAL_PORTFOLIO_SCORE = "24-32";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "BALANCE";
                IDEAL_PORTFOLIO_FUND = "BALANCED";
                Rb_rpf_scr_32.Visible = true;

            }
            if (sum >= 15 && sum <= 23)
            {
                IDEAL_PORTFOLIO_SCORE = "15-23";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "STABLE";
                IDEAL_PORTFOLIO_FUND = "INCOME";
                Rb_rpf_scr_23.Visible = true;

            }

            if (sum >= 11 && sum <= 14)
            {
                IDEAL_PORTFOLIO_SCORE = "11-14";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "CONSERVATIVE";
                IDEAL_PORTFOLIO_FUND = "MONEY MARKET";
                Rb_rpf_scr_14.Visible = true;

            }

            if (AGE == "" || RISK_RETURN_TOLERENCE_LEVEL == "" || MONTHLY_SAVINGS == "" || OCCUPATION == "" || INVESTMENT_OBJECTIVE == "" || KNOWLEDGE_LEVEL == ""
           || INVESTMENT_HORIZON == "" || IDEAL_PORTFOLIO_SCORE == "" || IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO == "" || IDEAL_PORTFOLIO_FUND == "")
            {
                mystage_.Text = "rpf";
                //mystage="rpf";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }
            ///////////////////////// RISK PROFILE SP CALLED ////////////////////////////////////// 


            
          acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
              , RELIGON, CNIC_EXPIRY_DATE_, CNIC_EXP_RENEW_NUM, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, MOBILE_NETWORK, PORTED, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
              ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
              BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP, DAO_ID, CNIC_ISSUE_DATE_, Department, Session["Username"].ToString(), Img1, Img2, Img3, Img4, MOTHER_NAME, DUAL_NATIONAL, resident_Status, p_address,p_country,p_city,pob);

            acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS, Geographic_Involved_Domestic, Geographic_Involved_International, Type_of_Counterparty_Domestic, Type_of_Counterparty_International, Possible_modes_of_transactions, Possible_No_of_transactions, Possible_Turnover_in_Account, Annual_Gross_Income, Amount_of_Investment, PEP, Name_of_Ultimate_Beneficiary, CNIC_Passport_No_of_Beneficiary, Relationship_with_Customer, Possible_turnover_in_acount_annual, DESIGNATION, NATURE_BUSINESS);

            acc_opening.customer_kyc_questions(CNIC,ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            SENOIR_MEMBER_IN_POLITICAL_PARTY,DEAL_IN_HIGH_VALUE_ITEMS,
           WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN, HEAD_OF_STATE_P, ADVISER_P, JUDICIAL_OFFICER_P, MILITARY_P, HOD_P,
           INTERNATIONAL_ORGANIZATION_P, ASSEMBLY_P, PARTY_P, HEAD_OF_STATE_j1, ADVISER_j1, JUDICIAL_OFFICER_j1, MILITARY_j1,
           HOD_j1, INTERNATIONAL_ORGANIZATION_j1, ASSEMBLY_j1, PARTY_j1, HEAD_OF_STATE_j2, ADVISER_j2, JUDICIAL_OFFICER_j2,
           MILITARY_j2, HOD_j2, INTERNATIONAL_ORGANIZATION_j2, ASSEMBLY_j2, PARTY_j2, CUSTOMER_WEALTH_P,
           CUSTOMER_WEALTH_j1, CUSTOMER_WEALTH_j2, MOB_P, MOB_j1, MOB_j2,
           ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1, HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1,
           SENOIR_MEMBER_IN_POLITICAL_PARTY_J1, DEAL_IN_HIGH_VALUE_ITEMS_J1, ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2,
           HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2, SENOIR_MEMBER_IN_POLITICAL_PARTY_J2,
           DEAL_IN_HIGH_VALUE_ITEMS_J2, financially_supported, financially_supported_J1, financially_supported_J2);


            acc_opening.joint_holders_details(PRINCIPLE_CNIC, JOINT_HOLDER_ONE_CNIC, JOINT_HOLDER_ONE_NAME, RELATIONSHIP_WITH_PRINCIPLE_ONE, JOINT_HOLDER_TWO_CNIC, JOINT_HOLDER_TWO_NAME, RELATIONSHIP_WITH_PRINCIPLE_TWO, Basic_date, Basic_date, Basic_date, Basic_date);

            acc_opening.nominee_details(CNIC, NOMINEE_CNIC_ONE, NOMINEE_NAME_ONE, SHARING_PERC_ONE, RELATIONSHIP_WITH_PRINCIPLE_ONE_,
                    NOMINEE_CNIC_TWO, NOMINEE_NAME_TWO, SHARING_PERC_TWO, RELATIONSHIP_WITH_PRINCIPLE_TWO_, NOMINEE_CNIC_THREE, NOMINEE_NAME_THREE, SHARING_PERC_THREE, RELATIONSHIP_WITH_PRINCIPLE_THREE_);

            acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
          PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
          US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
          TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
          US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);

            acc_opening.risk_profile_form(CNIC, PORTFOLIO_NUMBER, OLD_REGNUMBER, AGE, RISK_RETURN_TOLERENCE_LEVEL,
                MONTHLY_SAVINGS, OCCUPATION_rpf, INVESTMENT_OBJECTIVE,
                KNOWLEDGE_LEVEL, INVESTMENT_HORIZON, IDEAL_PORTFOLIO_SCORE,
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO,
                IDEAL_PORTFOLIO_FUND);
        }
        #endregion

        ////// calling procedures
        #region SINGLE

        if (ddloactype.SelectedIndex == 0)
        {
            ddloactype.SelectedIndex = ddloactype.Items.IndexOf(ddloactype.Items.FindByText("SINGLE"));
            ACCOUNT_TYPE = ddloactype.SelectedItem.Text.ToUpper();
        }

        if (ddloactype.SelectedValue.ToUpper() == "SINGLE")
        {

            ACC_MINOR_CASE = "NO";
            ACC_GUARDIAN_CNIC_EXPIRY_ = new DateTime(1900, 01, 01);
            ACCOUNT_OPERATING_INSTRUCTION = null;
            ALLOCATION_SCHEME = null;
            EXPECTED_RETIREMENT_AGE = null;


            // acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
            // , RELIGON, CNIC_EXPIRY_DATE_, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
            // ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
            // BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP);

            // acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS);

            // acc_opening.customer_kyc_questions(CNIC,
            // ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
            // ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
            // HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
            // SENOIR_MEMBER_IN_POLITICAL_PARTY,
            //DEAL_IN_HIGH_VALUE_ITEMS,
            //WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN);

            NOMINEE_NAME_ONE = txt_cstm_mtpf_nname1.Text.ToUpper();
            NOMINEE_CNIC_ONE = txt_cstm_mtpf_ncnic1.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_ONE_ = txt_cstm_mtpf_nrwp1.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_ONE_ = ddlRelationWithPrinciple_N1.SelectedItem.Text.ToUpper();


            SHARING_PERC_ONE = txt_cstm_mtpf_sharing1.Text.ToUpper();


            NOMINEE_NAME_TWO = txt_cstm_mtpf_nname2.Text.ToUpper();
            NOMINEE_CNIC_TWO = txt_cstm_mtpf_ncnic2.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_TWO_ = txt_cstm_mtpf_nrwp2.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_TWO_ = ddlRelationWithPrinciple_N2.SelectedItem.Text.ToUpper();

            SHARING_PERC_TWO = txt_cstm_mtpf_sharing2.Text.ToUpper();
            NOMINEE_NAME_THREE = txt_cstm_mtpf_nname3.Text.ToUpper();
            NOMINEE_CNIC_THREE = txt_cstm_mtpf_ncnic3.Text.ToUpper();
            //RELATIONSHIP_WITH_PRINCIPLE_THREE_ = txt_cstm_mtpf_nrwp3.Text.ToUpper();

            RELATIONSHIP_WITH_PRINCIPLE_THREE_ = ddlRelationWithPrinciple_N3.SelectedItem.Text.ToUpper();


            SHARING_PERC_THREE = txt_cstm_mtpf_sharing3.Text.ToUpper();

            string PRINCIPLE_CNIC = txt_cnicnum.Text.ToUpper();
            string JOINT_HOLDER_ONE_CNIC = string.Empty;
            string JOINT_HOLDER_ONE_NAME = string.Empty;
            string RELATIONSHIP_WITH_PRINCIPLE_ONE = string.Empty;
            string JOINT_HOLDER_TWO_CNIC = string.Empty;
            string JOINT_HOLDER_TWO_NAME = string.Empty;
            string RELATIONSHIP_WITH_PRINCIPLE_TWO = string.Empty;
            //if (NOMINEE_CNIC_ONE != "" && NOMINEE_NAME_ONE == "" || SHARING_PERC_ONE == "" || RELATIONSHIP_WITH_PRINCIPLE_ONE_ == "")
            //{
            //    Lblmsg.Text = "incomplete details";
            //    Lblmsg.Visible = true;
            //    btn_go_back.Visible = true;
            //    panel_kycdetails.Visible = false;
            //    return;
            //}


            //acc_opening.nominee_details(CNIC, NOMINEE_CNIC_ONE, NOMINEE_NAME_ONE, SHARING_PERC_ONE, RELATIONSHIP_WITH_PRINCIPLE_ONE_,
            //        NOMINEE_CNIC_TWO, NOMINEE_NAME_TWO, SHARING_PERC_TWO, RELATIONSHIP_WITH_PRINCIPLE_TWO_, NOMINEE_CNIC_THREE, NOMINEE_NAME_THREE, SHARING_PERC_THREE, RELATIONSHIP_WITH_PRINCIPLE_THREE_);

            //  else{}

            //if (txt_cstm_mtpf_nname1.Text != "" && txt_cstm_mtpf_ncnic1.Text != "" && txt_cstm_mtpf_nrwp1.Text != "" && txt_cstm_mtpf_sharing1.Text != "")
            //{
            //    NOMINEE_NAME = txt_cstm_mtpf_nname1.Text.ToUpper();
            //    NOMINEE_CNIC = txt_cstm_mtpf_ncnic1.Text.ToUpper();
            //    RELATIONSHIP_WITH_PRINCIPLE_NOMINEE = txt_cstm_mtpf_nrwp1.Text.ToUpper();
            //    SHARING_PERC = txt_cstm_mtpf_sharing1.Text.ToUpper();
            //    acc_opening.nominee_details(CNIC, NOMINEE_CNIC, NOMINEE_NAME, SHARING_PERC, RELATIONSHIP_WITH_PRINCIPLE_NOMINEE);
            //}

            //if (txt_cstm_mtpf_nname2.Text != "" && txt_cstm_mtpf_ncnic2.Text != "" && txt_cstm_mtpf_nrwp2.Text != "" && txt_cstm_mtpf_sharing2.Text != "")
            //{

            //    NOMINEE_NAME = txt_cstm_mtpf_nname2.Text.ToUpper();
            //    NOMINEE_CNIC = txt_cstm_mtpf_ncnic2.Text.ToUpper();
            //    RELATIONSHIP_WITH_PRINCIPLE_NOMINEE = txt_cstm_mtpf_nrwp2.Text.ToUpper();
            //    SHARING_PERC = txt_cstm_mtpf_sharing2.Text.ToUpper();
            //    acc_opening.nominee_details(CNIC, NOMINEE_CNIC, NOMINEE_NAME, SHARING_PERC, RELATIONSHIP_WITH_PRINCIPLE_NOMINEE);

            //}
            //if (txt_cstm_mtpf_nname3.Text != "" && txt_cstm_mtpf_ncnic3.Text != "" && txt_cstm_mtpf_nrwp3.Text != "" && txt_cstm_mtpf_sharing3.Text != "")
            //{

            //    NOMINEE_NAME = txt_cstm_mtpf_nname3.Text.ToUpper();
            //    NOMINEE_CNIC = txt_cstm_mtpf_ncnic3.Text.ToUpper();
            //    RELATIONSHIP_WITH_PRINCIPLE_NOMINEE = txt_cstm_mtpf_nrwp3.Text.ToUpper();
            //    SHARING_PERC = txt_cstm_mtpf_sharing3.Text.ToUpper();
            //    acc_opening.nominee_details(CNIC, NOMINEE_CNIC, NOMINEE_NAME, SHARING_PERC, RELATIONSHIP_WITH_PRINCIPLE_NOMINEE);

            //}

            //////////////////////////////////// fatca form ////////////////////////////////////////
            TITLE_OF_ACCOUNT = txt_ftca_acctitle.Text.ToUpper();
            TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "";
            if (Rb_ftca_ctrotp_none.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "NONE"; }
            if (Rb_ftca_ctrotp_USA.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = "USA"; }
            if (Rb_ftca_ctrotp_other.Checked == true) { TAX_RESIDENCE_OTHER_THAN_PAKISTAN = txt_ftca_ctrotp_other_cntry.Text.ToUpper(); }

            PLACE_OF_BIRTH_CITY = txt_ftca_pob_city.Text.ToUpper();
            PLACE_OF_BIRTH_STATE = txt_ftca_pob_bstate.Text.ToUpper();
            PLACE_OF_BIRTH_COUNTRY = txt_ftca_pob_birthcountry.Text.ToUpper();
            if (Rb_ftca_uscitizen_yes.Checked == true)
            {
                US_CITIZEN = "YES";
            }
            else { US_CITIZEN = "NO"; }
            if (Rb_ftca_usresdnt_yes.Checked == true)
            {
                US_RESIDENT = "YES";
            }
            else
            {
                US_RESIDENT = "NO";
            }
            if (Rb_ftca_usgc_yes.Checked == true)
            {
                GREEEN_CARD = "YES";
            }
            else
            {
                GREEEN_CARD = "NO";
            }

            if (Rb_ftca_usborn_yes.Checked == true)
            {
                DOB_OF_USA = "YES";
            }
            else
            {
                DOB_OF_USA = "NO";
            }
            if (Rb_ftca_ussitf_yes.Checked == true)
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "YES";
            }
            else
            {
                TRANSFER_FUND_TO_USA_ACCOUNT = "NO";
            }
            if (Rb_ftca_uspa_yes.Checked == true)
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "YES";
            }
            else
            {
                POWER_OF_ATTORNEY_USA_ADDRESS = "NO";
            }
            if (Rb_ftca_usaddr_yes.Checked == true)
            {
                US_RESIDENCE_MAIL_ADDRESS = "YES";
            }
            else
            {
                US_RESIDENCE_MAIL_ADDRESS = "NO";
            }
            if (Rb_ftca_ustn_yes.Checked == true)
            {
                US_TELELPHONE_NUMBER = "YES";
            }
            else
            {
                US_TELELPHONE_NUMBER = "NO";
            }

            if (CNIC == "" || TITLE_OF_ACCOUNT == "" || TAX_RESIDENCE_OTHER_THAN_PAKISTAN == "" || PLACE_OF_BIRTH_CITY == "" || PLACE_OF_BIRTH_STATE == ""
              || PLACE_OF_BIRTH_COUNTRY == "" || US_CITIZEN == "" || US_RESIDENT == "" || GREEEN_CARD == "" || DOB_OF_USA == "" || TRANSFER_FUND_TO_USA_ACCOUNT == ""
              || POWER_OF_ATTORNEY_USA_ADDRESS == "" || US_RESIDENCE_MAIL_ADDRESS == "" || US_TELELPHONE_NUMBER == "")
            {
                mystage_.Text = "fatca";
                //mystage="fatca";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }


            //acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
            //PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
            //US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
            //TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
            //US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_age_39.Checked == true) { AGE = "BELOW 40"; AGERPF = 4; }
            if (Rb_rpf_age_40.Checked == true) { AGE = "40-50"; AGERPF = 3; }
            if (Rb_rpf_age_50.Checked == true) { AGE = "50-60"; AGERPF = 2; }
            if (Rb_rpf_age_60.Checked == true) { AGE = "ABOVE 60"; AGERPF = 1; }
            //////////////////////////////////////////////////////////////////////      
            if (Rb_rpf_rtl_lr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_lr.Text.ToUpper(); RRTL = 1; }
            if (Rb_rpf_rtl_mr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_mr.Text.ToUpper(); RRTL = 4; }
            if (Rb_rpf_rtl_hr.Checked == true) { RISK_RETURN_TOLERENCE_LEVEL = Rb_rpf_rtl_hr.Text.ToUpper(); RRTL = 8; }
            /////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ms_25.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_25.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_50.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_50.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_150.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_150.Text.ToUpper(); MS = 2; }
            if (Rb_rpf_ms_500.Checked == true) { MONTHLY_SAVINGS = Rb_rpf_ms_500.Text.ToUpper(); MS = 2; }
            ////////////////////////////////////////////////////////////////////
            if (Rb_rpf_oc_rtd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_rtd.Text.ToUpper(); OCCP = 3; }
            if (Rb_rpf_oc_hws.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_hws.Text.ToUpper(); OCCP = 2; }
            if (Rb_rpf_oc_slrd.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_slrd.Text.ToUpper(); OCCP = 3; }
            if (Rb_rpf_oc_bse.Checked == true) { OCCUPATION_rpf = Rb_rpf_oc_bse.Text.ToUpper(); OCCP = 4; }
            //////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ib_cm.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_cm.Text.ToUpper(); IO = 2; }
            if (Rb_rpf_ib_mi.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_mi.Text.ToUpper(); IO = 4; }
            if (Rb_rpf_ib_lts.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_lts.Text.ToUpper(); IO = 8; }
            if (Rb_rpf_ib_rtmnt.Checked == true) { INVESTMENT_OBJECTIVE = Rb_rpf_ib_rtmnt.Text.ToUpper(); IO = 8; }
            ////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_kifm_lk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_lk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ak.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ak.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_bk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_bk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_gk.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_gk.Text.ToUpper(); KNOWLEDGE = 2; }
            if (Rb_rpf_kifm_ek.Checked == true) { KNOWLEDGE_LEVEL = Rb_rpf_kifm_ek.Text.ToUpper(); KNOWLEDGE = 2; }
            /////////////////////////////////////////////////////////////////////////////////////
            if (Rb_rpf_ih_1yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_1yr.Text.ToUpper(); IH = 4; }
            if (Rb_rpf_ih_5yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_5yr.Text.ToUpper(); IH = 8; }
            if (Rb_rpf_ih_35yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_35yr.Text.ToUpper(); IH = 8; }

            if (Rb_rpf_ih_23yr.Checked == true) { INVESTMENT_HORIZON = Rb_rpf_ih_23yr.Text.ToUpper(); IH = 6; }

            if (Rb_ih_6mnths.Checked == true) { INVESTMENT_HORIZON = Rb_ih_6mnths.Text.ToUpper(); IH = 2; }

            int sum = IH + KNOWLEDGE + IO + OCCP + MS + RRTL + AGERPF;
            if (sum >= 33)
            {
                IDEAL_PORTFOLIO_SCORE = "33-38";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "AGGRESSIVE";
                IDEAL_PORTFOLIO_FUND = "EQUITY";
                Rb_rpf_scr_38.Visible = true;

            }
            if (sum >= 24 && sum <= 32)
            {
                IDEAL_PORTFOLIO_SCORE = "24-32";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "BALANCE";
                IDEAL_PORTFOLIO_FUND = "BALANCED";
                Rb_rpf_scr_32.Visible = true;

            }
            if (sum >= 15 && sum <= 23)
            {
                IDEAL_PORTFOLIO_SCORE = "15-23";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "STABLE";
                IDEAL_PORTFOLIO_FUND = "INCOME";
                Rb_rpf_scr_23.Visible = true;

            }

            if (sum >= 11 && sum <= 14)
            {
                IDEAL_PORTFOLIO_SCORE = "11-14";
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO = "CONSERVATIVE";
                IDEAL_PORTFOLIO_FUND = "MONEY MARKET";
                Rb_rpf_scr_14.Visible = true;

            }


            if (AGE == "" || RISK_RETURN_TOLERENCE_LEVEL == "" || MONTHLY_SAVINGS == "" || /*OCCUPATION == "" ||*/ INVESTMENT_OBJECTIVE == "" || KNOWLEDGE_LEVEL == ""
                     || INVESTMENT_HORIZON == "" || IDEAL_PORTFOLIO_SCORE == "" || IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO == "" || IDEAL_PORTFOLIO_FUND == "")
            {
                mystage_.Text = "rpf";
                //mystage="rpf";
                Lblmsg.Text = "Incomplete Data";
                Lblmsg.Visible = true;
                btn_go_back.Visible = true;
                panel_kycdetails.Visible = false;
                return;

            }
            ///////////////////////// RISK PROFILE SP CALLED ////////////////////////////////////// 
            acc_opening.customer_details(CNIC, ACCOUNT_TYPE, CUSTOMER_NAME, FATHER_HUSBAND_NAME, MARITAL_STATUS, DATE_OF_BIRTH_, NATIONALITY
              , RELIGON, CNIC_EXPIRY_DATE_, CNIC_EXP_RENEW_NUM, ADDRESS, RESIDENCE_CITY, COUNTRY, MOBILE, MOBILE_NETWORK, PORTED, OFF_NUMBER, RESIDENTIAL_NUMBER, EMAIL, ACC_MINOR_CASE,
              ACC_MINOR_RELATIONSHIP, ACC_MINOR_GUARDIAN_NAME, ACC_GUARDIAN_CNIC, ACC_GUARDIAN_CNIC_EXPIRY_, BANK_ACC_NUMBER, BANK_NAME, BRANCH_NAME,
              BRANCH_CITY, ACCOUNT_OPERATING_INSTRUCTION, DIVIDEND_MANDATE, BONUS_MANDATE, EXPECTED_RETIREMENT_AGE, ALLOCATION_SCHEME, TIME_STAMP, DAO_ID, CNIC_ISSUE_DATE_, Department, Session["Username"].ToString(), Img1, Img2, Img3, Img4, MOTHER_NAME, DUAL_NATIONAL, resident_Status, p_address,p_country,p_city,pob);

            acc_opening.customer_kyc_details(CNIC, OCCUPATION, SOURCE_OF_INCOME, NAME_OF_EMPLOYER_BUSINESS,Geographic_Involved_Domestic,Geographic_Involved_International,Type_of_Counterparty_Domestic,Type_of_Counterparty_International,Possible_modes_of_transactions,Possible_No_of_transactions,Possible_Turnover_in_Account,Annual_Gross_Income,Amount_of_Investment,PEP,Name_of_Ultimate_Beneficiary,CNIC_Passport_No_of_Beneficiary,Relationship_with_Customer,Possible_turnover_in_acount_annual,DESIGNATION,NATURE_BUSINESS);

            /////////////////////////////////////////////////////////////////////////

            acc_opening.customer_kyc_questions(CNIC,
                        ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER,
                        ARE_YOU_ACTING_ON_BEHALF_OF_OTHER_PERSON,
                        HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE,
                        SENOIR_MEMBER_IN_POLITICAL_PARTY,
                       DEAL_IN_HIGH_VALUE_ITEMS,
                       WHERE_DID_YOU_HEAR_ABOUT_ALMEEZAN, HEAD_OF_STATE_P, ADVISER_P, JUDICIAL_OFFICER_P, MILITARY_P, HOD_P,
                       INTERNATIONAL_ORGANIZATION_P, ASSEMBLY_P, PARTY_P, HEAD_OF_STATE_j1, ADVISER_j1, JUDICIAL_OFFICER_j1, MILITARY_j1,
                       HOD_j1, INTERNATIONAL_ORGANIZATION_j1, ASSEMBLY_j1, PARTY_j1, HEAD_OF_STATE_j2, ADVISER_j2, JUDICIAL_OFFICER_j2,
                       MILITARY_j2, HOD_j2, INTERNATIONAL_ORGANIZATION_j2, ASSEMBLY_j2, PARTY_j2, CUSTOMER_WEALTH_P,
                       CUSTOMER_WEALTH_j1, CUSTOMER_WEALTH_j2, MOB_P, MOB_j1, MOB_j2,
                       ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J1, HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J1,
                       SENOIR_MEMBER_IN_POLITICAL_PARTY_J1, DEAL_IN_HIGH_VALUE_ITEMS_J1, ACC_OPENING_REFUSED_IN_FINANCIAL_INSTITUTE_EVER_J2,
                       HAVE_SENIOR_POSITION_IN_GOVERTMENT_INSTITUTE_J2, SENOIR_MEMBER_IN_POLITICAL_PARTY_J2,
                       DEAL_IN_HIGH_VALUE_ITEMS_J2, financially_supported, financially_supported_J1, financially_supported_J2);


            ////////////////////////////////////////////////////////////////////////////

            acc_opening.nominee_details(CNIC, NOMINEE_CNIC_ONE, NOMINEE_NAME_ONE, SHARING_PERC_ONE, RELATIONSHIP_WITH_PRINCIPLE_ONE_,
                    NOMINEE_CNIC_TWO, NOMINEE_NAME_TWO, SHARING_PERC_TWO, RELATIONSHIP_WITH_PRINCIPLE_TWO_, NOMINEE_CNIC_THREE, NOMINEE_NAME_THREE, SHARING_PERC_THREE, RELATIONSHIP_WITH_PRINCIPLE_THREE_);

            acc_opening.joint_holders_details(PRINCIPLE_CNIC, JOINT_HOLDER_ONE_CNIC, JOINT_HOLDER_ONE_NAME, RELATIONSHIP_WITH_PRINCIPLE_ONE, JOINT_HOLDER_TWO_CNIC, JOINT_HOLDER_TWO_NAME, RELATIONSHIP_WITH_PRINCIPLE_TWO, Basic_date, Basic_date, Basic_date, Basic_date);

            acc_opening.fatca_form(CNIC, TITLE_OF_ACCOUNT, TAX_RESIDENCE_OTHER_THAN_PAKISTAN,
          PLACE_OF_BIRTH_CITY, PLACE_OF_BIRTH_STATE, PLACE_OF_BIRTH_COUNTRY,
          US_CITIZEN, US_RESIDENT, GREEEN_CARD, DOB_OF_USA,
          TRANSFER_FUND_TO_USA_ACCOUNT, POWER_OF_ATTORNEY_USA_ADDRESS,
          US_RESIDENCE_MAIL_ADDRESS, US_TELELPHONE_NUMBER);

            acc_opening.risk_profile_form(CNIC, PORTFOLIO_NUMBER, OLD_REGNUMBER, AGE, RISK_RETURN_TOLERENCE_LEVEL,
                MONTHLY_SAVINGS, OCCUPATION_rpf, INVESTMENT_OBJECTIVE,
                KNOWLEDGE_LEVEL, INVESTMENT_HORIZON, IDEAL_PORTFOLIO_SCORE,
                IDEAL_PORTFOLIO_INVESTOR_PORTFOLIO,
                IDEAL_PORTFOLIO_FUND);

            if (Department != "IAS")
                acc_opening.ACCOUNT_STATUS(CNIC, "INITIATED", Session["Role"].ToString());
        }
        #endregion

        acc_opening.CentralizedAccoutsLogs(CNIC, Session["Role"].ToString().Equals(Departments.IAS) ? "Form Updated" : "Form Initiated", Session["Username"].ToString());

        btn_crystal.Enabled = true;
        panel_preview.Visible = false;
        panel_kycdetails.Visible = false;

        btn_crystal.Visible = true;
        btn_submit_preview.Visible = false;
        btn_back_preview.Visible = false;

        lblText.Text = "Your account opening form has been submitted successfully. Please proceed to Investment Form.";
        msgDiv.Visible = true;
        //generate text file here to upload at T24 FTP...


    }
    protected void txt_cnicnum_TextChanged(object sender, EventArgs e)
    {
        Acc_opening acc_opening_verification = new Acc_opening();
        bool verification;
        bool verification2;

        //if (!Regex.IsMatch(txt_cnicnum.Text,@"\d+"))
        //{
        //    txt_cnicnum.Text = string.Empty;
        //    lbl_error.Text = "enter only numeric characters ";
        //    lbl_error.Visible = true;
        //    // Name does not match schema
        //}

        if (txt_cnicnum.Text.Length != 13 || !Regex.IsMatch(txt_cnicnum.Text, @"\d+"))
        {

            txt_cnicnum.Text = string.Empty;
            lbl_error.Text = "Use correct format";
            lbl_error.Visible = true;
            //lbl_sterick.Visible = true;
        }
        else
        {
            if (!rb_newPF.Checked)
            {

                verification = acc_opening_verification.verify_cnic(txt_cnicnum.Text);
                if (verification == true)
                {
                    txt_cnicnum.Text = string.Empty;
                    lbl_error.Visible = true;
                    rb_newPF.Visible = true;
                    //lbl_sterick.Visible = true; 
                    return;
                }
                else
                {
                    //lbl_sterick.Visible = false;
                    lbl_error.Visible = false;
                    //btn_verify_cnic.Visible = false;
                }
                verification2 = acc_opening_verification.verify_cnic2(txt_cnicnum.Text);
                if (verification2 == true)
                {
                    txt_cnicnum.Text = string.Empty;
                    lbl_error.Visible = true;
                    rb_newPF.Visible = true;
                    return;
                    // lbl_sterick.Visible = true;
                }
                else
                {
                    lbl_error.Visible = false;
                    //btn_verify_cnic.Visible = false;
                    //lbl_sterick.Visible = false;
                }
            }
        }


    }
    protected void btn_crystal_Click(object sender, EventArgs e)
    {

        //ReportDocument cryRpt = new ReportDocument();
        //    cryRpt.Load(PUT CRYSTAL REPORT PATH HERE\\CrystalReport1.rpt");
        //    crystalReportViewer1.ReportSource = cryRpt;
        //    crystalReportViewer1.Refresh();
        #region

        Session["CNIC"] = txt_cnicnum.Text;
        Session["investmentCNIC"] = txt_cnicnum.Text;
        //Acc_opening acc = new Acc_opening();
        //DataTable dt = acc.GetCustomerInfo(txt_cnicnum.Text);
        //string curr_no = dt.Rows.Count > 0 ? dt.Rows[0]["CURR_NO"].ToString() : "0";
        //Session["CURR_NO"] = curr_no;
        //Session["CNIC"] = txt_cnicnum.Text;
        //Session["Customer_Name"] = txt_name.Text;
        //Session["Bank"] = ddlBanks.SelectedItem.Text == "OTHER" ? txt_cstm_bankname.Text.ToUpper() : ddlBanks.SelectedItem.Text;
        //Session["Branch"] = txt_branch_name.Text;
        //Session["ACC_NUMBER"] = txt_cstm_accountname.Text.ToUpper();
        //Session["Mobile"] = ddlMobileType.SelectedItem.Text == "OTHER" ? txtOtherMobile.Text : ddlMobileCode.SelectedItem.Text + txt_cstm_mobilenumber.Text.ToUpper();
        //_REPORTCNIC = txt_cnicnum.Text;


        //string filePath;
        ////filePath = @"C:\Users\misbah.haque\Desktop\almeezan portal\REPORT_BACKUP\New folder\AccountOpeningForm.rpt"; // location of rpt file 
        //// filePath = @"C:\Users\misbah.haque\Desktop\almeezan portal\ACCOUNT_OPENING\AccountOpeningForm.rpt"; // location of rpt file 
        //filePath = Server.MapPath("~/Report/AccountOpeningForm.rpt");
        //// filePath = Server.MapPath("~/MisReports/Reports/AccountStatement_CRM.rpt");
        //ReportDocument report = new ReportDocument();
        //report.Load(filePath);

        //MemoryStream oStream;
        ////clsDBOperation cls = new clsDBOperation();
        //// report.SetParameterValue(0, Request.QueryString["P_code"].ToString());

        //string _servername = ConfigurationManager.AppSettings["servername"];
        //string _databasename = ConfigurationManager.AppSettings["databasenameACOP"];
        //string _userid = ConfigurationManager.AppSettings["userid"];
        //string _password = ConfigurationManager.AppSettings["password"];

        //// _REPORTCNIC = "159951753";
        //report.DataSourceConnections[0].SetConnection(_servername, _databasename, _userid, _password);
        //report.Subreports[0].DataSourceConnections[0].SetConnection(_servername, _databasename, _userid, _password);
        //report.Subreports[1].DataSourceConnections[0].SetConnection(_servername, _databasename, _userid, _password);
        //report.Subreports[2].DataSourceConnections[0].SetConnection(_servername, _databasename, _userid, _password);


        //// report.RecordSelectionFormula = "({CUSTOMER_DETAILS.CNIC} = {CNIC})";

        //report.RecordSelectionFormula = "({CUSTOMER_DETAILS.CNIC} = {?CNIC} AND {CUSTOMER_DETAILS.CURR_NO} = {?CURR_NO})";  // get it from crystal report expert option //

        //// report.RecordSelectionFormula = "({CUSTOMER_DETAILS.CNIC}  ='"+_REPORTCNIC+"')";
        //// report.RecordSelectionFormula = "({CUSTOMER_DETAILS.CNIC}  ='"+_REPORTCNIC +"')";
        //report.SetParameterValue("CNIC", _REPORTCNIC); // BADINDEX EXCEPTION        
        //report.SetParameterValue("CURR_NO", curr_no);
        ////  report.SetParameterValue("@StartDate", DateTime.Now.AddYears(-1).ToShortDateString());
        //// report.SetParameterValue("@StartDate", startdate);
        //// report.SetParameterValue("@EndDate", enddate);

        ////comment
        //// report.SetParameterValue("@PFNO_new", pcode);
        //// report.SetParameterValue("@StartDate_new", startdate);
        //// report.SetParameterValue("@EndDate_new", enddate);




        //oStream = (MemoryStream)
        //report.ExportToStream(
        //CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "Application/pdf";



        //Response.BinaryWrite(oStream.ToArray());

        //// string UserFolder = Session["Username"].ToString();



        //string filePathE = Server.MapPath("~/Download/"); // path of the folder where adobe file to be created  
        ////string UserFolder = Session["Username"].ToString();

        //string path = Server.MapPath("~/Download/");
        //if (!Directory.Exists(path))
        //{
        //    Directory.CreateDirectory(path);

        //}
        //string a = "a";

        //filePathE = filePathE + _REPORTCNIC + ".pdf";
        //Session["filePathE"] = filePathE;

        ////if (!Directory.Exists(filePathE))
        ////{
        ////    Directory.CreateDirectory(filePathE);

        ////}

        //bool isExist = File.Exists(filePathE);
        //if (isExist)
        //{
        //    File.Delete(filePathE);
        //}






        //report.ExportToDisk(ExportFormatType.PortableDocFormat, filePathE);

        //// filePathE = Server.MapPath(path+"/"+a+".pdf");
        ////    filePathE = (path + "\\");
        ////   filePathE = filePathE + a + ".pdf";
        ////if (!Directory.Exists(filePathE))
        ////{
        //// Directory.CreateDirectory(filePathE);

        ////}



        ////  report.ExportToDisk(ExportFormatType.PortableDocFormat,filePath);
        ////  Response.End();
        //oStream.Flush();
        //oStream.Close();
        //oStream.Dispose();

        //report.Close();
        //report.Dispose();

        //Session["reportFile"] = filePathE;
        #endregion
        //string url = "AccountopeningReport.aspx?reportFile=" + filePathE;
        //StringBuilder sb = new StringBuilder();
        //sb.Append("<script type = 'text/javascript'>");
        //sb.Append("window.open('");
        //sb.Append(url);
        //sb.Append("');");
        //sb.Append("</script>");
        //ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString()); 

        // Response.Redirect("AccountopeningReport.aspx");
    }
    protected void btn_go_back_Click(object sender, EventArgs e)
    {
        if (mystage_.Text == "main")
        {
            panel_error_mesg.Visible = false;
            panel1.Visible = true;
            btn_go_back.Visible = false;
            Lblmsg.Visible = false;
            btn_next.Visible = true;
            //   panel_kycdetails.Visible = false;

            // panel_error_mesg.Visible = false;


        }

        if (mystage_.Text == "fatca")
        {
            panel_error_mesg.Visible = false;
            panel_fatca.Visible = true;
            btn_go_back.Visible = false;
            Lblmsg.Visible = false;
            panel_kycdetails.Visible = false;
            // panel_error_mesg.Visible = false;


        }

        if (mystage_.Text == "rpf")
        {
            panel_error_mesg.Visible = false;
            panel_riskprofileform.Visible = true;
            // panel_fatca.Visible = true;
            btn_go_back.Visible = false;
            Lblmsg.Visible = false;
            panel_kycdetails.Visible = false;
            // panel_error_mesg.Visible = false;


        }


        //panel1.Visible = true;
        //btn_go_back.Visible = false;
        //Lblmsg.Visible = false;
        //btn_next.Visible = true;
    }
    protected void txt_cnic_expiry_TextChanged(object sender, EventArgs e)
    {
        Thread.Sleep(3000);
        DateTime cnic_exp_date = Convert.ToDateTime(txt_cnic_expiry.Text);
        DateTime curr_date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
        if (cnic_exp_date < curr_date)
        {
            //txt_cnic_expiry.Text = string.Empty;
            txt_cnic_expiry.Visible = false;
            lbl_cnic_exp.Visible = true;
            txt_cnic_renew_num.Visible = true;
            lbl_cnic_exp.Text = "CNIC expired, enter renew receipt no.";
        }
    }
    protected void txt_cnic_renew_num_TextChanged(object sender, EventArgs e)
    {
        if (txt_cnic_renew_num.Text != string.Empty)
        {
            lbl_cnic_exp.Text = string.Empty;
        }
    }
    protected void ddlBanks_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBanks.SelectedItem.Text == "OTHER")
        {
            txt_cstm_bankname.Visible = true;
        }
        else
        {
            txt_cstm_bankname.Visible = false;
        }
    }
    protected void Rb_cstm_kyc_firoa_yes_CheckedChanged(object sender, EventArgs e)
    {
        btn_next.Enabled = !Rb_cstm_kyc_firoa_yes.Checked;
        //if (Rb_cstm_kyc_firoa_yes.Checked)
        //{
        //    Rb_cstm_kyc_abop_no.Enabled = Rb_cstm_kyc_abop_yes.Enabled
        //        = Rb_cstm_kyc_spgi_yes.Enabled = Rb_cstm_kyc_spgi_no.Enabled
        //        = Rb_cstm_kyc_sppp_yes.Enabled = Rb_cstm_kyc_sppp_no.Enabled
        //        = Rb_cstm_kyc_hvitem_yes.Enabled = Rb_cstm_kyc_hvitem_no.Enabled = false;

        //    Rb_cstm_kyc_abop_no.Checked = Rb_cstm_kyc_abop_yes.Checked
        //        = Rb_cstm_kyc_spgi_yes.Checked = Rb_cstm_kyc_spgi_no.Checked
        //        = Rb_cstm_kyc_sppp_yes.Checked = Rb_cstm_kyc_sppp_no.Checked
        //        = Rb_cstm_kyc_hvitem_yes.Checked = Rb_cstm_kyc_hvitem_no.Checked = false;
        //}
    }
    protected void Rb_cstm_kyc_firoa_no_CheckedChanged(object sender, EventArgs e)
    {
        btn_next.Enabled = Rb_cstm_kyc_firoa_no.Checked;
        //if (Rb_cstm_kyc_firoa_no.Checked)
        //{
        //    Rb_cstm_kyc_abop_no.Enabled = Rb_cstm_kyc_abop_yes.Enabled
        //        = Rb_cstm_kyc_spgi_yes.Enabled = Rb_cstm_kyc_spgi_no.Enabled
        //        = Rb_cstm_kyc_sppp_yes.Enabled = Rb_cstm_kyc_sppp_no.Enabled
        //        = Rb_cstm_kyc_hvitem_yes.Enabled = Rb_cstm_kyc_hvitem_no.Enabled = true;
        //}
    }
    protected void Rb_ftca_ctrotp_none_CheckedChanged(object sender, EventArgs e)
    {
        if (Rb_ftca_ctrotp_none.Checked)
        {
            Rb_ftca_uscitizen_yes.Enabled = Rb_ftca_uscitizen_no.Enabled
                = Rb_ftca_usresdnt_yes.Enabled = Rb_ftca_usresdnt_no.Enabled
                = Rb_ftca_usgc_yes.Enabled = Rb_ftca_usgc_no.Enabled
                = Rb_ftca_usborn_yes.Enabled = Rb_ftca_usborn_no.Enabled
                = Rb_ftca_ussitf_yes.Enabled = Rb_ftca_ussitf_no.Enabled
                = Rb_ftca_uspa_yes.Enabled = Rb_ftca_uspa_no.Enabled
                = Rb_ftca_usaddr_yes.Enabled = Rb_ftca_usaddr_no.Enabled
                = Rb_ftca_ustn_yes.Enabled = Rb_ftca_ustn_no.Enabled = false;

            Rb_ftca_uscitizen_yes.Checked = Rb_ftca_uscitizen_no.Checked
                = Rb_ftca_usresdnt_yes.Checked = Rb_ftca_usresdnt_no.Checked
                = Rb_ftca_usgc_yes.Checked = Rb_ftca_usgc_no.Checked
                = Rb_ftca_usborn_yes.Checked = Rb_ftca_usborn_no.Checked
                = Rb_ftca_ussitf_yes.Checked = Rb_ftca_ussitf_no.Checked
                = Rb_ftca_uspa_yes.Checked = Rb_ftca_uspa_no.Checked
                = Rb_ftca_usaddr_yes.Checked = Rb_ftca_usaddr_no.Checked
                = Rb_ftca_ustn_yes.Checked = Rb_ftca_ustn_no.Checked = false;
        }
    }
    protected void Rb_ftca_ctrotp_USA_CheckedChanged(object sender, EventArgs e)
    {
        Rb_ftca_uscitizen_yes.Enabled = Rb_ftca_uscitizen_no.Enabled
                = Rb_ftca_usresdnt_yes.Enabled = Rb_ftca_usresdnt_no.Enabled
                = Rb_ftca_usgc_yes.Enabled = Rb_ftca_usgc_no.Enabled
                = Rb_ftca_usborn_yes.Enabled = Rb_ftca_usborn_no.Enabled
                = Rb_ftca_ussitf_yes.Enabled = Rb_ftca_ussitf_no.Enabled
                = Rb_ftca_uspa_yes.Enabled = Rb_ftca_uspa_no.Enabled
                = Rb_ftca_usaddr_yes.Enabled = Rb_ftca_usaddr_no.Enabled
                = Rb_ftca_ustn_yes.Enabled = Rb_ftca_ustn_no.Enabled = true;
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedItem.Text == "Pakistan".ToUpper())
        {
            Acc_opening acc = new Acc_opening();
            txt_city.Visible = false;
            ddl_City.Visible = true;
            ddl_City.DataSource = acc.CitiesList();
            ddl_City.DataTextField = "CITY";
            ddl_City.DataValueField = "CODE";
            ddl_City.DataBind();
        }
        else
        {
            txt_cstm_phonenumber.Text = string.Empty;
            txt_cstm_officenumber.Text = string.Empty;
            ddl_City.Visible = false;
            txt_city.Visible = true;
        }
    }
    protected void ddl_City_SelectedIndexChanged(object sender, EventArgs e)
    {
        Acc_opening acc = new Acc_opening();
        DataTable dtCityCode = acc.CitiesList();
        DataView dv = new DataView(dtCityCode);
        dv.RowFilter = "City='" + ddl_City.SelectedItem.Text + "' ";
        dtCityCode = dv.ToTable();
        txt_cstm_phonenumber.Text = dtCityCode.Rows[0]["CODE"].ToString();
        txt_cstm_officenumber.Text = dtCityCode.Rows[0]["CODE"].ToString();
    }
    protected void ddlMobileType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!cb_MobilePorted.Checked)
        {
            Acc_opening acc = new Acc_opening();
            DataTable dtCodes = acc.MobileNetwork(ddlMobileType.SelectedItem.Text);
            ddlMobileCode.DataSource = dtCodes;
            ddlMobileCode.DataTextField = "Code";
            ddlMobileCode.DataValueField = "Code";
            ddlMobileCode.DataBind();
        }
        else
        {
            Acc_opening acc = new Acc_opening();
            DataTable dtCodes = acc.MobileNetwork("Ported");
            ddlMobileCode.DataSource = dtCodes;
            ddlMobileCode.DataTextField = "Code";
            ddlMobileCode.DataValueField = "Code";
            ddlMobileCode.DataBind();
        }

        if (!(ddlMobileType.SelectedItem.Text == "OTHER"))
        {
            ddlMobileCode.Visible = txt_cstm_mobilenumber.Visible = true;
            txtOtherMobile.Visible = false;
        }
        else
        {
            ddlMobileCode.Visible = txt_cstm_mobilenumber.Visible = false;
            txtOtherMobile.Visible = true;
        }
    }
    protected void cb_MobilePorted_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_MobilePorted.Checked)
        {
            Acc_opening acc = new Acc_opening();
            DataTable dtCodes = acc.MobileNetwork("Ported");
            ddlMobileCode.DataSource = dtCodes;
            ddlMobileCode.DataTextField = "Code";
            ddlMobileCode.DataValueField = "Code";
            ddlMobileCode.DataBind();
        }
        else
        {
            Acc_opening acc = new Acc_opening();
            DataTable dtCodes = acc.MobileNetwork(ddlMobileType.SelectedItem.Text);
            ddlMobileCode.DataSource = dtCodes;
            ddlMobileCode.DataTextField = "Code";
            ddlMobileCode.DataValueField = "Code";
            ddlMobileCode.DataBind();
        }

    }
    protected void rb_newPF_CheckedChanged(object sender, EventArgs e)
    {
        lbl_error.Visible = false;
    }
    protected void txt_email_TextChanged(object sender, EventArgs e)
    {
        if (txt_email.Text.Contains(".CON") || txt_email.Text.Contains(".con"))
        {
            txt_email.Text = txt_email.Text.Replace(".con", ".com");
            txt_email.Text = txt_email.Text.Replace(".CON", ".COM");
        }
    }
    protected void Rb_cstm_kyc_ocptn_CheckedChanged(object sender, EventArgs e)
    {
        //if (Rb_cstm_kyc_ocptn_selfemplyd.Checked || Rb_cstm_kyc_soi_business.Checked)
        //{
        //    name_of_emp_div.Style.Remove("display");
        //    name_of_emp_div.Style.Add("display", "block");
        //}
        //else
        //{
        //    name_of_emp_div.Style.Remove("display");
        //    name_of_emp_div.Style.Add("display", "none");
        //}

    }
    protected void Rb_cstm_kyc_soi_CheckedChanged(object sender, EventArgs e)
    {
        //if (Rb_cstm_kyc_soi_business.Checked || Rb_cstm_kyc_ocptn_selfemplyd.Checked)
        //{
        //    name_of_emp_div.Style.Remove("display");
        //    name_of_emp_div.Style.Add("display", "block");
        //}
        //else
        //{
        //    name_of_emp_div.Style.Remove("display");
        //    name_of_emp_div.Style.Add("display", "none");
        //}
    }
    protected void btnCalculateIdealPortfolio_Click(object sender, EventArgs e)
    {
        int AGERPF = 0; int RRTL = 0; int MS = 0; int OCCP = 0; int IO = 0; int KNOWLEDGE = 0; int IH = 0;
        if (Rb_rpf_age_39.Checked == true) { AGERPF = 4; }
        if (Rb_rpf_age_40.Checked == true) { AGERPF = 3; }
        if (Rb_rpf_age_50.Checked == true) { AGERPF = 2; }
        if (Rb_rpf_age_60.Checked == true) { AGERPF = 1; }
        //////////////////////////////////////////////////////////////////////      
        if (Rb_rpf_rtl_lr.Checked == true) { RRTL = 1; }
        if (Rb_rpf_rtl_mr.Checked == true) { RRTL = 4; }
        if (Rb_rpf_rtl_hr.Checked == true) { RRTL = 8; }
        /////////////////////////////////////////////////////////////////////
        if (Rb_rpf_ms_25.Checked == true) { MS = 2; }
        if (Rb_rpf_ms_50.Checked == true) { MS = 2; }
        if (Rb_rpf_ms_150.Checked == true) { MS = 3; }
        if (Rb_rpf_ms_500.Checked == true) { MS = 3; }
        ////////////////////////////////////////////////////////////////////
        if (Rb_rpf_oc_rtd.Checked == true) { OCCP = 1; }
        if (Rb_rpf_oc_hws.Checked == true) { OCCP = 2; }
        if (Rb_rpf_oc_slrd.Checked == true) { OCCP = 3; }
        if (Rb_rpf_oc_bse.Checked == true) { OCCP = 4; }
        //////////////////////////////////////////////////////////////////////
        if (Rb_rpf_ib_cm.Checked == true) { IO = 2; }
        if (Rb_rpf_ib_mi.Checked == true) { IO = 4; }
        if (Rb_rpf_ib_lts.Checked == true) { IO = 8; }
        if (Rb_rpf_ib_rtmnt.Checked == true) { IO = 8; }
        ////////////////////////////////////////////////////////////////////////
        if (Rb_rpf_kifm_lk.Checked == true) { KNOWLEDGE = 2; }
        if (Rb_rpf_kifm_ak.Checked == true) { KNOWLEDGE = 2; }
        if (Rb_rpf_kifm_bk.Checked == true) { KNOWLEDGE = 2; }
        if (Rb_rpf_kifm_gk.Checked == true) { KNOWLEDGE = 3; }
        if (Rb_rpf_kifm_ek.Checked == true) { KNOWLEDGE = 3; }
        /////////////////////////////////////////////////////////////////////////////////////
        if (Rb_rpf_ih_1yr.Checked == true) { IH = 4; }
        if (Rb_rpf_ih_5yr.Checked == true) { IH = 8; }
        if (Rb_rpf_ih_35yr.Checked == true) { IH = 8; }

        if (Rb_rpf_ih_23yr.Checked == true) { IH = 6; }

        if (Rb_ih_6mnths.Checked == true) { IH = 2; }

        int sum = IH + KNOWLEDGE + IO + OCCP + MS + RRTL + AGERPF;
        if (sum >= 33)
        {
            lblidealPortfolio.Text = Rb_rpf_scr_38.Text;

        }
        if (sum >= 24 && sum <= 32)
        {

            lblidealPortfolio.Text = Rb_rpf_scr_32.Text;

        }
        if (sum >= 15 && sum <= 23)
        {

            lblidealPortfolio.Text = Rb_rpf_scr_23.Text;

        }

        if (sum >= 11 && sum <= 14)
        {

            lblidealPortfolio.Text = Rb_rpf_scr_14.Text;

        }

        acc_opening.CentralizedAccoutsLogs(txt_cnicnum.Text, string.Format("Risk profiling calculated {0}", lblidealPortfolio.Text), Session["Username"].ToString());
    }
    protected void Rb_cstm_kyc_abop_yes_CheckedChanged(object sender, EventArgs e)
    {

        if (Rb_cstm_kyc_abop_yes.Checked == true)
        {
            panel_kyc_act_ques.Visible = true;

        }
        else 
        {
            panel_kyc_act_ques.Visible = false;
        
        }

    }
}