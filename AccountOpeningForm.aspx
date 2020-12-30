<%@ Page Title="Account Opening Form" Language="C#" MasterPageFile="~/CentralizedAccount.master" AutoEventWireup="true" CodeFile="AccountOpeningForm.aspx.cs" Inherits="AccountOpeningForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-32470970-1', 'auto');
        ga('send', 'pageview');

        function InvestmentForm() {
            window.open("investment_form.aspx");
            window.open("AccountOpeningReport.aspx");
        }
        function myReplace() {
            var txt = document.getElementById('<%=txt_email.ClientID %>').value;
            var res = txt.replace(".con", ".com");
            document.getElementById('<%=txt_email.ClientID %>').value = res;
        }       
    </script>
    <script>
        $('#<%=txt_cstm_mobilenumber.ClientID %>').focusout(function () {
            var txt = document.getElementById('<%=txt_cstm_mobilenumber.ClientID %>').value;
             if (txt.lenght < 7) {
                 alert('Please enter complete Mobile No.');
             }
         });
    </script>
    <script src="lib/jquery-3.2.1.min.js"></script>
    <style type="text/css">

        required.after {
            content: "*";
            font-weight: bold;
            color: red;
        }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
    <div class="intro">
        <div class="container">
            <div class="row">
                <div class="col-xs-8">
                    <h2>Al Meezan Portal</h2>
                </div>
                <div class="col-xs-4">
                    <div class="welcome">
                        Logged In as,<span><asp:Label ID="lblNameHead" runat="server"></asp:Label></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="main">
            <div class="col-xs-12">
                <div style="height: 100%" id="msgDiv" runat="server" visible="false">
                                <div class="sent-ok">
                                    <asp:Label ID="lblText" runat="server"></asp:Label></div>
                            </div>
            </div>
            <div class="col-xs-12">
                <h3 style="margin-bottom: 0px;">
                    <strong>ACCOUNT OPENING REQUEST</strong></h3>
                <div class="border">
                    <asp:Panel ID="panel1" runat="server">

                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>Basic Information</h3>
                            </div>
                            <div class="form-group col-xs-4">
                                <div>
                                    <asp:Label ID="lbl_main_account_type" Text="Account Type" runat="server" Font-Bold="true" /><font color="red">*</font></div>
                                <asp:DropDownList ID="ddloactype" runat="server" class="form-control" Enabled="true" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddloactype_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <%-- <asp:ListItem Text="SINGLE" Value="SINGLE"></asp:ListItem>
                                    <asp:ListItem Text="JOINT" Value="JOINT"></asp:ListItem>
                                    <asp:ListItem Text="MINOR" Value="MINOR"></asp:ListItem>
                                    <asp:ListItem Text="MTPF" Value="MTPF"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_main_cnic_no" Text="CNIC/NICOP/Passport" runat="server" Font-Bold="true" /> <font color="red">*</font>
                                <asp:TextBox ID="txt_cnicnum" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txt_cnicnum_TextChanged" MaxLength="13"/>
                                <asp:CheckBox ID="rb_newPF" runat="server" Text="New Portfolio" Visible="false" OnCheckedChanged="rb_newPF_CheckedChanged" AutoPostBack="true" />
                                <asp:Label ID="lbl_error" runat="server" Text="CNIC already used" Visible="false" ForeColor="#FF3300" />
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" ValidChars="0123456789" TargetControlID="txt_cnicnum" Enabled="true" />
                                <asp:RequiredFieldValidator ID="reqCNIC" runat="server" ControlToValidate="txt_cnicnum" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txt_cnicnum" ValidationExpression="^[0-9]{13}$" ErrorMessage="Please enter 13 digits CNIC No." Display="Dynamic" Font-Bold="true" Font-Size="Smaller"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_dao_id" Text="Dao ID" runat="server" Font-Bold="true" /> <font color="red">*</font>
                                <asp:TextBox ID="txt_dao_id" runat="server" CssClass="form-control" MaxLength="4"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_dao_id" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>                                
                                <asp:RegularExpressionValidator ID="regexDaoID" runat="server" ControlToValidate="txt_dao_id" ValidationExpression="^[0-9]{2,4}$" ErrorMessage="Please enter 2 or 4 digits Dao ID" Display="Dynamic" Font-Bold="true" Font-Size="Smaller"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="name" ID="lbl_main_name" runat="server" Text="Name (as per CNIC)" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_name" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txt_name" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="fname" ID="lbl_main_fname" runat="server" Text="Father/Husband's Name" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_fathername" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender42" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txt_fathername" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_fathername" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group col-xs-4">
                                <asp:Label for="fname" ID="lbl_main_mname" runat="server" Text="Mother's Maiden Name" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_mothername" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txt_mothername" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_mothername" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>



                            <div class="form-group col-xs-4">
                                <asp:Label for="msname" ID="lbl_main_marital_status" runat="server" Text="Marital Status" Font-Bold="true" /><font color="red">*</font>
                                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control">
                                    <%--<asp:ListItem>SELECT</asp:ListItem>
                                    <asp:ListItem>SINGLE</asp:ListItem>
                                    <asp:ListItem>MARRIED</asp:ListItem>
                                    <asp:ListItem>WIDOWED</asp:ListItem>
                                    <asp:ListItem>DIVORCED</asp:ListItem>--%>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="txt_maritalstatus" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender43" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txt_maritalstatus" Enabled="true" />--%>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_main_dob" Text="Date of Birth" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_date_of_birth" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <%--<asp:CompareValidator ID="CompareValidator2" ControlToValidate="txt_date_of_birth" runat="server" ErrorMessage="Date Only" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>--%>
                                <cc1:CalendarExtender ID="dob" TargetControlID="txt_date_of_birth" Format="yyyy-MM-dd" PopupButtonID="txt_date_of_birth" runat="server"></cc1:CalendarExtender>                                
                            </div>
                           
                            
                             <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_main_cnic_issue" Text="CNIC Issue Date" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cnic_issue" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;" AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <asp:Label ID="lbl_cnic_issue" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txt_cnic_issue" Format="yyyy-MM-dd" PopupButtonID="txt_cnic_issue" runat="server"></cc1:CalendarExtender >
                            </div>
                            
                            
                            <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_main_cnic_expiry" Text="CNIC Expiry Date" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cnic_expiry" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;" OnTextChanged="txt_cnic_expiry_TextChanged" AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <asp:TextBox ID="txt_cnic_renew_num" runat="server" class="form-control" Enabled="true" placeholder="enter renew number (if available)" Style="text-transform: uppercase" Visible="false" MaxLength="20" AutoPostBack="True" OnTextChanged="txt_cnic_renew_num_TextChanged"></asp:TextBox>
                                <asp:Label ID="lbl_cnic_exp" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <%--<asp:CompareValidator ID="CompareValidator1" ControlToValidate="txt_cnic_expiry" runat="server" ErrorMessage="Date Only" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>--%>
                                <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txt_cnic_expiry" Format="yyyy-MM-dd" PopupButtonID="txt_cnic_expiry" runat="server"></cc1:CalendarExtender>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_main_nationality" runat="server" Text="Nationality" Font-Bold="true" /> <font color="red">*</font>
                                <asp:TextBox ID="txt_nationality" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender44" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txt_nationality" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_nationality" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group col-xs-4">                                
                                <asp:Label ID="lbl_dual_national" Text="Dual National: &nbsp;" runat="server" Font-Bold="true" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_dual_national_yes" runat="server" GroupName="dual_national" Text="Yes"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_dual_national_no" runat="server" GroupName="dual_national" Text="No" />
                                </label>
                            </div>

                           
                            
                            
                             <div class="form-group col-xs-4">
                                <asp:Label for="txt_religon" ID="lbl_main_religon" runat="server" Text="Religion" Font-Bold="true" /><font color="red">*</font>
                                <%-- <asp:TextBox ID="txt_religon" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>  --%>

                                <asp:DropDownList ID="ddl_religon" runat="server" CssClass="form-control" AutoPostBack="true" Visible="True">
                                </asp:DropDownList>

                                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender45" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" TargetControlID="txt_religon" Enabled="true" />--%>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="txt_address" ID="lbl_main_address" runat="server" Text="Current Address" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_address" runat="server" class="form-control" Enabled="true" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender46" runat="server" InvalidChars="@#$%^&*()=+~`<>?{}[];:" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/, " TargetControlID="txt_address" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_address" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>
                          
                            <div class="form-group col-xs-4">
                                <asp:Label for="txt_par_address" ID="lbl_par_address" runat="server" Text="Parmenant Address" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_par_address" runat="server" class="form-control" Enabled="true" TextMode="MultiLine" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" InvalidChars="@#$%^&*()=+~`<>?{}[];:" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-/, " TargetControlID="txt_par_address" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_par_address" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>




                            
                              <div class="form-group col-xs-4">
                                <asp:Label for="txt_email" ID="lbl_main_email_address" runat="server" Text="Email Address" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_email" runat="server" class="form-control" Enabled="true"
                                    Style="text-transform: uppercase" AutoPostBack="false" OnTextChanged="txt_email_TextChanged" onblur="myReplace()"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_email"
                                    runat="server" ForeColor="Red" ErrorMessage="Invalid Email" Font-Size="Smaller"
                                    Display="Dynamic" Font-Bold="true" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                            </div>
                           
                             <div class="form-group col-xs-4">
                                <asp:Label for="txt_country" ID="Label52" runat="server" Text="Parmenant Address Country" Font-Bold="true" /><font color="red">*</font>
                              <asp:DropDownList ID="ddl_p_country" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                              <div class="form-group col-xs-4">
                                <asp:Label for="txt_city" ID="Label53" runat="server" Text="City" Font-Bold="true" /><font color="red">*</font>
                                
                                <asp:DropDownList ID="ddl_p_city" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>
                            </div>

                               <div class="form-group col-xs-4">
                                <asp:Label for="txt_country" ID="Label54" runat="server" Text="Place of Birth" Font-Bold="true" /><font color="red">*</font>
                              <asp:DropDownList ID="ddl_pob" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>



                            
                             <div class="form-group col-xs-4">
                                <asp:Label for="txt_country" ID="lbl_main_res_country" runat="server" Text="Residence Country" Font-Bold="true" /><font color="red">*</font>
                              <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                           
                           <div class="col-xs-12">
                             <asp:Label ID="lbl_resident_status" Text="Residential Status: &nbsp;" runat="server" Font-Bold="true" />
                            </div>
                              <div class="form-group col-xs-12">                              
                               
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_resident_pakistan" runat="server" GroupName="resident_non_resident" Text="Pakistan Resident"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_resident_non_resident" runat="server" GroupName="resident_non_resident" Text="Non-Resident" />
                                </label>
                                  <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_resident_for" runat="server" GroupName="resident_non_resident" Text="Resident Foreign National"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_resident_non_for" runat="server" GroupName="resident_non_resident" Text="Non-Resident Foreign National" />
                                </label>


                            </div>




                            
                            
                             <div class="form-group col-xs-6">
                                <asp:Label for="txt_city" ID="lbl_main_city" runat="server" Text="Parmenant Address City" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_city" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <asp:DropDownList ID="ddl_City" runat="server" CssClass="form-control" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-12">
                                <h3>CONTACT DETAILS</h3>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="pnum" ID="lbl_main_phn_number" runat="server" Text="Phone No." Font-Bold="true" />
                                <asp:TextBox ID="txt_cstm_phonenumber" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" ValidChars="0123456789" TargetControlID="txt_cstm_phonenumber" Enabled="true" />
                            </div>
                            <div class="form-group col-xs-4">
                                <div class="form-inline">
                                    <asp:Label for="mnum" ID="lbl_main_mbl_number" runat="server" Text="Mobile No." Font-Bold="true" /><font color="red">*</font>
                                    <asp:CheckBox ID="cb_MobilePorted" runat="server" Text="Ported" AutoPostBack="True" OnCheckedChanged="cb_MobilePorted_CheckedChanged" />
                                </div>
                                <div class="form-inline">
                                    <asp:DropDownList ID="ddlMobileType" runat="server" CssClass="form-control" Width="110px" AutoPostBack="True" OnSelectedIndexChanged="ddlMobileType_SelectedIndexChanged">
                                    </asp:DropDownList>

                                    <asp:TextBox ID="txtOtherMobile" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" ValidChars="0123456789" TargetControlID="txtOtherMobile" Enabled="true" />

                                    <asp:DropDownList ID="ddlMobileCode" runat="server" CssClass="form-control" Width="80px">
                                    </asp:DropDownList>

                                    <asp:TextBox ID="txt_cstm_mobilenumber" runat="server" class="form-control" Enabled="true"
                                        Width="110px" Style="text-transform: uppercase" MaxLength="7"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" ValidChars="0123456789" TargetControlID="txt_cstm_mobilenumber" Enabled="true" />
                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txt_cstm_mobilenumber" ID="RegularExpressionValidator2" ValidationExpression = "^[0-9]{7}$" runat="server" ErrorMessage="Please enter complete number" Font-Size="Small" Font-Bold="true"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="cm" ID="lbl_main_off_number" runat="server" Text="Office No." Font-Bold="true" />
                                <asp:TextBox ID="txt_cstm_officenumber" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" ValidChars="0123456789" TargetControlID="txt_cstm_officenumber" Enabled="true" />
                            </div>

                            <div class="col-xs-12">
                                <h3>Bank Details</h3>
                            </div>

                            <div class="form-group col-xs-6">
                                <asp:Label for="bname" ID="lbl_main_bnk_name" runat="server" Text="Bank Name" Font-Bold="true" />
                                <asp:DropDownList ID="ddlBanks" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBanks_SelectedIndexChanged"></asp:DropDownList>
                                <asp:TextBox ID="txt_cstm_bankname" runat="server" class="form-control" Enabled="true" PlaceHolder="Bank Name" Style="text-transform: uppercase" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group col-xs-6">
                                <asp:Label for="bname" ID="lbl_main_accnt_number" runat="server" Text="Account Number <font size='1'><i>(IBAN Number Only)</i></font>" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cstm_accountname" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase" MaxLength="24"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" ValidChars="0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" TargetControlID="txt_cstm_accountname" Enabled="true" />
                                <asp:RegularExpressionValidator ID="RegularExpressionBankAccount" runat="server" ErrorMessage="Please enter valid IBAN Number" Font-Bold="true" Font-Size="Smaller" ControlToValidate="txt_cstm_accountname" ValidationExpression="^[A-Za-z]{2}[0-9]{2}[A-Za-z]{4}[0-9]{16}$" Display="Dynamic" />
                            </div>
                            <div class="form-group col-xs-6">
                                <asp:Label for="add" ID="lbl_main_brnch_name" runat="server" Text="Branch Name" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_branch_name" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz " TargetControlID="txt_branch_name" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_branch_name" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group col-xs-6">
                                <asp:Label for="add" ID="lbl_main_branch_city" runat="server" Text="Branch City" Font-Bold="true" />
                                <%--<asp:TextBox ID="txt_branch_city" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_BranchCity" runat="server" CssClass="form-control" AutoPostBack="true" Visible="True" OnSelectedIndexChanged="ddl_City_SelectedIndexChanged">
                                </asp:DropDownList>

                                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" TargetControlID="txt_branch_city" Enabled="true" />--%>
                            </div>
                            <div class="col-xs-12">
                                <asp:Label ID="lbl_main_divdnt_mandate" Text="DIVIDEND MANDATE" runat="server" CssClass="h3" Style="font-size: 16px; text-transform: uppercase; font-weight: 600; color: #2d0c5c" />
                                <div>&nbsp;</div>
                            </div>
                            <div class="form-group col-xs-6">
                                <asp:Label ID="lbl_main_divdnt_cash" Text="Cash Dividend: &nbsp;" runat="server" Font-Bold="true" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_dm_cd_reinvest" runat="server" GroupName="CashDiv" Text="Reinvest" OnCheckedChanged="Rb_cstm_dm_cd_reinvest_CheckedChanged" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_dm_cd_providecash" runat="server" GroupName="CashDiv" Text="Provide Cash" />
                                </label>
                            </div>
                            <div class="form-group col-xs-6">
                                <asp:Label ID="lbl_main_divdnt_stock" Text="Stock Dividend: &nbsp;" runat="server" Font-Bold="true" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_dm_sd_ibu" runat="server" GroupName="stock_divident" Text="Issue bonus units" OnCheckedChanged="Rb_cstm_dm_sd_ibu_CheckedChanged" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_dm_sd_ebu" runat="server" GroupName="stock_divident" Text="Encash bonus units" />
                                </label>
                            </div>
                        </div>
                        <asp:Panel ID="panel_minor_account" runat="server">
                            <div class="col-xs-12">
                                <div class="col-xs-12">
                                    <h3>MINOR ACCOUNTS</h3>
                                </div>
                                <div class="form-group col-xs-6">
                                    <asp:Label ID="lbl_main_minor_gname" runat="server" Text="Name Of Guardian" Font-Bold="true" />
                                    <asp:TextBox ID="txt_cstm_mnr_ng" runat="server" CssClass="form-control" />
                                </div>
                                <div class="form-group col-xs-6">
                                    <asp:Label ID="lbl_main_main_gcnic_no" runat="server" Text="Guardian CNIC" Font-Bold="true" />
                                    <asp:TextBox ID="txt_cstm_mnr_gcnic" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group col-xs-6">
                                    <asp:Label ID="lbl_main_minor_rwp" runat="server" Text="Relationship With Principal" Font-Bold="true" />
                                    <%-- <asp:TextBox ID="txt_cstm_mnr_rwp" runat="server" CssClass="form-control"></asp:TextBox>--%>

                                    <asp:DropDownList ID="ddlRelationWithPrinciple_mnr" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                    </asp:DropDownList>


                                </div>
                                <div class="form-group col-xs-6">
                                    <asp:Label ID="lbl_main_minor_cdate" runat="server" Text="CNIC Expiry Date" Font-Bold="true" />
                                    <asp:TextBox ID="txt_cstm_mnr_cnic_expiry" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel ID="panel_mtpf_ddlist" runat="server">
                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>MTPF Account</h3>
                            </div>
                            <div class="form-group col-xs-6">
                                <label>Expected Retirement Age</label>
                                <asp:TextBox ID="retirement_age" runat="server" class="form-control" Enabled="true" MaxLength="2" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server"
                                    Enabled="True" TargetControlID="retirement_age" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-6">
                                <label>Allocation Scheme</label>
                                <asp:DropDownList ID="ddlomtpfac" runat="server" class="form-control" Enabled="true"
                                    Visible="true" OnSelectedIndexChanged="ddlomtpfac_SelectedIndexChanged">
                                    <%--<asp:ListItem Text="HIGH VOLATITLITY" Value="HIGH VOLATILITY"></asp:ListItem>
                                    <asp:ListItem Text="MEDIUM VOLATITLITY" Value="MEDIUM VOLATILITY"></asp:ListItem>
                                    <asp:ListItem Text="LOW VOLATITLITY" Value="LOW VOLATILITY"></asp:ListItem>
                                    <asp:ListItem Text="LOWER VOLATITLITY" Value="LOWER VOLATILITY"></asp:ListItem>
                                    <asp:ListItem Text="LIFE CYCLE PLAN" Value="LIFE CYCLE PLAN"></asp:ListItem>
                                    <asp:ListItem Text="VOLATILITY ALLOCATION SCHEME" Value="VOLATILITY ALLOCATION SCHEME"></asp:ListItem>
                                    <asp:ListItem Text="100% DEBT" Value="100% DEBT"></asp:ListItem>
                                    <asp:ListItem Text="100% EQUITY" Value="100% EQUITY"></asp:ListItem>
                                    <asp:ListItem Text="100% MONEY MARKET" Value="100% MONEY MARKET"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="col-xs-12">
                        <div class="form-group col-xs-12">
                            <asp:Panel ID="panel_Operating_Instructions_ddlist" runat="server">
                                <label>Operating Instructions</label>
                                <asp:DropDownList ID="ddloprt" runat="server" class="form-control" Enabled="true">
                                    <asp:ListItem Text="ANY TWO JOINTLY" Value="ANY TWO JOINTLY"></asp:ListItem>
                                    <asp:ListItem Text="EITHER OR SURVIVOR" Value="EITHER OR SURVIVOR"></asp:ListItem>
                                    <asp:ListItem Text="JOINTLY BY ALL AC HLDR" Value="JOINTLY BY ALL AC HLDR"></asp:ListItem>
                                    <asp:ListItem Text="AS PER LIST AUTH SIGN" Value="AS PER LIST AUTH SIGN"></asp:ListItem>
                                    <asp:ListItem Text="ONLY BY PRINCIPAL AC HOLDER" Value="ONLY BY PRIN AC HOLDER"></asp:ListItem>
                                </asp:DropDownList>
                            </asp:Panel>
                        </div>
                    </div>
                    <asp:Panel ID="panel_joint_acc_holder" runat="server">
                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>Joint Account Holder Details (For Joint Account)</h3>
                            </div>
                        </div>
                        <div class="col-xs-6">
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_main_jh1_main" Text="JOINT HOLDER 1" runat="server" Font-Bold="true" />
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="n1" ID="lbl_main_jh1_name" runat="server" Text="Name" Font-Bold="true" />
                                <asp:TextBox ID="txt_cstm_jh_jhname1" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_jh_jhname1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="ncnic1" ID="lbl_main_jh1_cnic_no" runat="server" Text="CNIC/NICOP/Passport" Font-Bold="true" />
                                <asp:TextBox ID="txt_cstm_jh_jhcnic1" runat="server" class="form-control"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server"
                                    Enabled="true" TargetControlID="txt_cstm_jh_jhcnic1" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="nrwp1" ID="lbl_main_jh1_rwp" runat="server" Text="Relationship With Principal" Font-Bold="true" />
                                <%--  <asp:TextBox ID="txt_cstm_jh_jhrwp1" runat="server" class="form-control"></asp:TextBox>--%>

                                <asp:DropDownList ID="ddlRelationWithPrinciple_J1" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>


                                <%--   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_jh_jhrwp1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>--%>
                            </div>
                       
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_main_jh1_cnic_issue_date" Text="CNIC Issue Date" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cstm_jh1_cnic_issue_date" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;" AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <asp:Label ID="lbl_cnic_issue_jh1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <cc1:CalendarExtender ID="CalendarExtender3" TargetControlID="txt_cstm_jh1_cnic_issue_date" Format="yyyy-MM-dd" PopupButtonID="txt_cstm_jh1_cnic_issue_date" runat="server"></cc1:CalendarExtender >
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_main_jh1_cnic_exp_date" Text="CNIC Expiry Date" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cstm_jh1_cnic_exp_date" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;"  AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control" Enabled="true" placeholder="enter renew number (if available)" Style="text-transform: uppercase" Visible="false" MaxLength="20" AutoPostBack="True" ></asp:TextBox>
                                <asp:Label ID="lbl_cnic_exp_jh1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <%--<asp:CompareValidator ID="CompareValidator1" ControlToValidate="txt_cnic_expiry" runat="server" ErrorMessage="Date Only" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>--%>
                                <cc1:CalendarExtender ID="CalendarExtender4" TargetControlID="txt_cstm_jh1_cnic_exp_date" Format="yyyy-MM-dd" PopupButtonID="txt_cstm_jh1_cnic_exp_date" runat="server"></cc1:CalendarExtender>
                            </div>


                            
                             </div>
                        <div class="col-xs-6">
                            <div class="form-group col-xs-12">
                                <asp:Label for="n2" ID="lbl_main_jh2_main" runat="server" Text="JOINT HOLDER 2" Font-Bold="true" />
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="nname2" ID="lbl_main_jh2_name" runat="server" Text="Name" Font-Bold="true" />
                                <asp:TextBox ID="txt_cstm_jh_jhname2" runat="server" class="form-control" Enabled="true"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_jh_jhname2" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="ncnic2" ID="lbl_main_jh2_cnic" runat="server" Text="CNIC/NICOP/Passport" Font-Bold="true" />
                                <asp:TextBox ID="txt_cstm_jh_jhcnic2" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>


                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_jh_jhcnic2" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="nrwp1" ID="lbl_main_jh2_rwp" runat="server" Text="Relationship With Principal" Font-Bold="true" />
                                <%-- <asp:TextBox ID="txt_cstm_jh_jhrwp2" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>--%>

                                <asp:DropDownList ID="ddlRelationWithPrinciple_J2" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>


                                <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_jh_jhrwp2" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>--%>
                            </div>
                       
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_main_jh2_cnic_issue_date" Text="CNIC Issue Date" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cstm_jh2_cnic_issue_date" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;" AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <asp:Label ID="lbl_cnic_issue_jh2" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <cc1:CalendarExtender ID="CalendarExtender5" TargetControlID="txt_cstm_jh2_cnic_issue_date" Format="yyyy-MM-dd" PopupButtonID="txt_cstm_jh2_cnic_issue_date" runat="server"></cc1:CalendarExtender >
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_main_jh2_cnic_exp_date" Text="CNIC Expiry Date" runat="server" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_cstm_jh2_cnic_exp_date" ValidationGroup='valGroup1' runat="server" type="text" class="form-control" placeholder="yyyy-MM-dd" onkeypress="return false;"  AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                <span class="fa fa-calendar form-control-feedback" aria-hidden="true"></span>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" Enabled="true" placeholder="enter renew number (if available)" Style="text-transform: uppercase" Visible="false" MaxLength="20" AutoPostBack="True" ></asp:TextBox>
                                <asp:Label ID="lbl_cnic_exp_jh2" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                <%--<asp:CompareValidator ID="CompareValidator1" ControlToValidate="txt_cnic_expiry" runat="server" ErrorMessage="Date Only" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>--%>
                                <cc1:CalendarExtender ID="CalendarExtender6" TargetControlID="txt_cstm_jh2_cnic_exp_date" Format="yyyy-MM-dd" PopupButtonID="txt_cstm_jh2_cnic_exp_date" runat="server"></cc1:CalendarExtender>
                            </div>

          
                             </div>
                    </asp:Panel>
                    <asp:Panel ID="panel_nominee_details" runat="server">
                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>Nominee Details (Optional - For Single & MTPF Account)</h3>
                            </div>
                        </div>
                        <div class="col-xs-4">
                            <div class="form-group col-xs-12">
                                <label>NOMINEE 1</label>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Name</label>
                                <asp:TextBox ID="txt_cstm_mtpf_nname1" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nname1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>CNIC/NICOP/Passport</label>
                                <asp:TextBox ID="txt_cstm_mtpf_ncnic1" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_ncnic1" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Relationship With Principal</label>
                                <%--<asp:TextBox ID="txt_cstm_mtpf_nrwp1" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>--%>

                                <asp:DropDownList ID="ddlRelationWithPrinciple_N1" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>


                                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nrwp1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>--%>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Sharing % MTPF</label>
                                <asp:TextBox ID="txt_cstm_mtpf_sharing1" runat="server" class="form-control" Enabled="true" MaxLength="4" Style="text-transform: uppercase"></asp:TextBox>

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_sharing1" ValidChars="0123456789%"></cc1:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-xs-4">
                            <div class="form-group col-xs-12">
                                <label>NOMINEE 2</label>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Name</label>
                                <asp:TextBox ID="txt_cstm_mtpf_nname2" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nname2" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>CNIC/NICOP/Passport</label>
                                <asp:TextBox ID="txt_cstm_mtpf_ncnic2" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_ncnic2" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Relationship With Principal</label>
                                <%--  <asp:TextBox ID="txt_cstm_mtpf_nrwp2" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>--%>


                                <asp:DropDownList ID="ddlRelationWithPrinciple_N2" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>

                                <%--  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender47" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nrwp2" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>--%>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Sharing % MTPF</label>
                                <asp:TextBox ID="txt_cstm_mtpf_sharing2" runat="server" class="form-control" Enabled="true" MaxLength="4" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender48" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_sharing2" ValidChars="0123456789%"></cc1:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="col-xs-4">
                            <div class="form-group col-xs-12">
                                <label>NOMINEE 3</label>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Name</label>
                                <asp:TextBox ID="txt_cstm_mtpf_nname3" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender49" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nname1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>CNIC/NICOP/Passport</label>
                                <asp:TextBox ID="txt_cstm_mtpf_ncnic3" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender50" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_ncnic1" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Relationship With Principal</label>
                                <%-- <asp:TextBox ID="txt_cstm_mtpf_nrwp3" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>--%>

                                <asp:DropDownList ID="ddlRelationWithPrinciple_N3" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>


                                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender51" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nrwp1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>--%>
                            </div>
                            <div class="form-group col-xs-12">
                                <label>Sharing % MTPF</label>
                                <asp:TextBox ID="txt_cstm_mtpf_sharing3" runat="server" class="form-control" Enabled="true" MaxLength="4" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender52" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_sharing1" ValidChars="0123456789%"></cc1:FilteredTextBoxExtender>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panel_kycdetails" runat="server">
                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>KYC DETAILS OF PRINCIPAL ACCOUNT HOLDER</h3>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_main_occupation" Text="Occupation:" runat="server" Font-Bold="true" Width="150px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_ocptn_gservices" runat="server" GroupName="OCCUPATION_" Text="Government Services" OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_ocptn_pservices" runat="server" Text="Private Services" GroupName="OCCUPATION_" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_ocptn_selfemplyd" runat="server" Text="Self Employed" GroupName="OCCUPATION_" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_ocptn_retired" runat="server" Text="Retired" GroupName="OCCUPATION_" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_ocptn_hwife" runat="server" Text="House Wife" GroupName="OCCUPATION_" Enabled="true"  OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_ocptn_student" runat="server" Text="Student" GroupName="OCCUPATION_" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="rb_cstm_kyc_ocptn_other" runat="server" Text="Other" GroupName="OCCUPATION_" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_ocptn_CheckedChanged"  AutoPostBack="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="source_of_income" ID="lbl_main_source_of_income" runat="server" Text="Source of Income:" Font-Bold="true" Width="150px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_business" runat="server" Text="Business/Self-Owned" GroupName="SOURCE_OF_INCOME" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_salary" runat="server" Text="Salary" GroupName="SOURCE_OF_INCOME" Enabled="true"  OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_pensions" runat="server" Text="Pension" GroupName="SOURCE_OF_INCOME" Enabled="true"  OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_inheritances" runat="server" Text="Inheritances" GroupName="SOURCE_OF_INCOME" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_remittances" runat="server" Text="Remittances" GroupName="SOURCE_OF_INCOME" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_saving" runat="server" Text="Savings" GroupName="SOURCE_OF_INCOME" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_stocks" runat="server" Text="Stocks/investments" GroupName="SOURCE_OF_INCOME" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                                 <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_soi_Other" runat="server" Text="Other" GroupName="SOURCE_OF_INCOME" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_soi_CheckedChanged"  AutoPostBack="true"/>
                                </label>
                            </div>
                            <div id="name_of_emp_div" runat="server" class="form-group col-xs-12">
                                <label>Name of Employer/Business</label>
                                <asp:TextBox ID="txt_cstm_kyc_noeb" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_kyc_noeb" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                         
                           
                         <%--   //////////////////////////////////////////////////////////--%>
                            
                             <div class="form-group col-xs-4">
                                <asp:Label for="kyc_designation" ID="lbl_kyc_designation" runat="server" Text="Designation" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_kyc_designation" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890- " TargetControlID="txt_kyc_designation" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_kyc_designation" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>

                             <div class="form-group col-xs-4">
                                <asp:Label for="kyc_nob" ID="lbl_kyc_nob" runat="server" Text="Nature of Business" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_kyc_nob" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890- " TargetControlID="txt_kyc_nob" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_kyc_nob" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>--%>
                            </div>


                             <div class="form-group col-xs-12">
                                 <asp:Label for="kycq7" ID="lbl_geography_head" runat="server" Text="Geographies Involved :" Font-Bold="true" />

                             </div>


                            <div class="form-group col-xs-6">
                                <asp:Label for="msname" ID="lbl_geography_domestic" runat="server" Text="Domestic" Font-Bold="true" /><font color="red">*</font>
                                <asp:DropDownList ID="ddl_kyc_gepgraphy_domestic" runat="server" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>SINDH</asp:ListItem>
                                    <asp:ListItem>KPK</asp:ListItem>
                                    <asp:ListItem>PUNJAB</asp:ListItem>
                                    <asp:ListItem>BALOCHISTAN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                <div class="form-group col-xs-6">
                                <asp:Label for="msname" ID="lbl_geography_international" runat="server" Text="International" Font-Bold="true" /><font color="red">*</font>
                                <asp:DropDownList ID="ddl_kyc_gepgraphy_international" runat="server" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>FATF COMPLIANT</asp:ListItem>
                                    <asp:ListItem>FATF NON-COMPLIANT</asp:ListItem>                               

                                </asp:DropDownList>
                            
</div>

                              <div class="form-group col-xs-12">
                                 <asp:Label for="kycq7" ID="lbl_geography_head_cparty" runat="server" Text="Type of Counter Parties :" Font-Bold="true" />

                             </div>


                            <div class="form-group col-xs-6">
                                <asp:Label for="msname" ID="lbl_geography_domestic_cparty" runat="server" Text="Domestic" Font-Bold="true" /><font color="red">*</font>
                                <asp:DropDownList ID="ddl_kyc_gepgraphy_domestic_cparty" runat="server" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>SINDH</asp:ListItem>
                                    <asp:ListItem>KPK</asp:ListItem>
                                    <asp:ListItem>PUNJAB</asp:ListItem>
                                    <asp:ListItem>BALOCHISTAN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                <div class="form-group col-xs-6">
                                <asp:Label for="msname" ID="lbl_geography_international_cparty" runat="server" Text="International" Font-Bold="true" /><font color="red">*</font>
                                <asp:DropDownList ID="ddl_kyc_gepgraphy_international_cparty" runat="server" CssClass="form-control">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>FATF COMPLIANT</asp:ListItem>
                                    <asp:ListItem>FATF NON-COMPLIANT</asp:ListItem>                               

                                </asp:DropDownList>
                            
</div>
                            <div class="form-group col-xs-6">
                                <asp:Label ID="lbl_tran_mode" Text="Possible Modes of Transaction: " runat="server" Font-Bold="true" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_tran_mode_online" runat="server" GroupName="kyc_tran_mode" Text="Online" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_tran_mode_physical" runat="server" GroupName="kyc_tran_mode" Text="Physical" />
                                </label>
                          <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_tran_mode_Both" runat="server" GroupName="kyc_tran_mode" Text="Both" />
                                </label>
                                    </div>

                             <div class="form-group col-xs-6">
                                <asp:Label for="fname" ID="lbl_kyc_no_of_tran" runat="server" Text="Number of transaction" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_kyc_no_of_tran" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server" ValidChars="1234567890" TargetControlID="txt_kyc_no_of_tran" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_kyc_no_of_tran" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>


                              <div class="form-group col-xs-6">
                                <asp:Label ID="lbl_kyc_turn_over" Text="Expected Turnover in Account " runat="server" Font-Bold="true" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_turn_over_monthly" runat="server" GroupName="kyc_turn_over" Text="Monthly" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_turn_over_annually" runat="server" GroupName="kyc_turn_over" Text="Annually" />
                                </label>
                        
                                   <asp:TextBox ID="txt_kyc_turn_over" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" runat="server" ValidChars="1234567890" TargetControlID="txt_kyc_turn_over" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_kyc_turn_over" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                                    </div>

                             <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_kyc_exp_amount" Text="Expected Investment Amount:" runat="server" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_exp_amount_2" runat="server" GroupName="kyc_exp_amount" Text="upto Rs. 2.5M"   AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_exp_amount_5" runat="server" Text="upto Rs. 2.5M to Rs 5M" GroupName="kyc_exp_amount" Enabled="true"  AutoPostBack="true"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_exp_amount_10" runat="server"  Text="upto Rs. 5M to Rs 10M" GroupName="kyc_exp_amount" Enabled="true"   AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_exp_amount_10above" runat="server" Text="Above Rs. 10M" GroupName="kyc_exp_amount" Enabled="true"    AutoPostBack="true"  />
                                </label>
                               
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label ID="lbl_kyc_annual_income" Text="Annual Income:" runat="server" Font-Bold="true" Width="150px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_annual_income_1" runat="server" GroupName="kyc_annual_income" Text="upto Rs. 1M"   AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_annual_income_3" runat="server" GroupName="kyc_annual_income" Text="Rs. 1 M to Rs. 3 M"   AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_annual_income_6" runat="server" GroupName="kyc_annual_income" Text="Rs. 3 M to Rs. 6 M"   AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_annual_income_8" runat="server" GroupName="kyc_annual_income" Text="Rs. 6 M to Rs. 8 M"   AutoPostBack="true" />
                                </label>
                               
                                   <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_annual_income_10" runat="server" GroupName="kyc_annual_income" Text="Rs. 8 M to Rs. 10 M"   AutoPostBack="true" />
                                </label>

                                  <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_kyc_annual_income_10above" runat="server" GroupName="kyc_annual_income"  Text="Above Rs. 10 M"   AutoPostBack="true" />
                                </label>


                            </div>
                          
                             <div class="col-xs-12">
                                   </div>


                              <div class="col-xs-12">
                                <h3>PEP DECLARATION DETAILS</h3>
                            </div>



                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq2" ID="lbl_main_kyc_abop" runat="server" Text="Are you acting on the behalf of other person?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_abop_yes" runat="server" Text="Yes" GroupName="Q2" Enabled="true" OnCheckedChanged="Rb_cstm_kyc_abop_yes_CheckedChanged" AutoPostBack="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_abop_no" runat="server" Text="No" GroupName="Q2" Enabled="true"  OnCheckedChanged="Rb_cstm_kyc_abop_yes_CheckedChanged" AutoPostBack="true" />
                                </label>
                            </div>
                            
                                                            
                               <asp:Panel ID="panel_kyc_act_ques" runat="server" Visible="false">

                            <div class="form-group col-xs-4">
                                <asp:Label for="fname" ID="lbl_kyc_act_quest_name" runat="server" Text="Name of Ultimate Benificary" Font-Bold="true" /><font color="red">*</font>
                                <asp:TextBox ID="txt_kyc_act_quest" runat="server" class="form-control" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ " TargetControlID="txt_kyc_act_quest" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_kyc_act_quest" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>

                           <div class="form-group col-xs-4">
                                <asp:Label ID="lbl_kyc_act_quest_cnic" Text="CNIC/NICOP/Passport" runat="server" Font-Bold="true" /> <font color="red">*</font>
                                <asp:TextBox ID="txt_kyc_Act_quest_cnic" runat="server" CssClass="form-control" AutoPostBack="true" MaxLength="13"/>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" runat="server" ValidChars="1234567890" TargetControlID="txt_kyc_Act_quest_cnic" Enabled="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_kyc_Act_quest_cnic" ErrorMessage="Required" Display="Dynamic" Font-Size="Small" Font-Bold="true"></asp:RequiredFieldValidator>
                            </div>

                                 <div class="form-group col-xs-4">
                                <label>Relationship With Principal</label>
                                <%--<asp:TextBox ID="txt_cstm_mtpf_nrwp1" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>--%>

                                <asp:DropDownList ID="ddl_kyc_act_quest_relation" runat="server" CssClass="form-control" AutoPostBack="true" Visible="true">
                                </asp:DropDownList>
 </div>

                                <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" runat="server"
                                    Enabled="True" TargetControlID="txt_cstm_mtpf_nrwp1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>--%>
                            





                                </asp:Panel>


                               <div class="form-group col-xs-12">
                                <asp:Label for="kycq1" ID="lbl_main_kyc_firoa" runat="server" Text="Has any Financial Institution ever refused to open your account?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_firoa_yes" runat="server" Text="Yes" GroupName="Q1" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_cstm_kyc_firoa_yes_CheckedChanged" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_firoa_no" runat="server" Text="No" GroupName="Q1" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_cstm_kyc_firoa_no_CheckedChanged" />
                                </label>
                            </div>
                          
                          
                            
                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq3" ID="lbl_main_kyc_spgi" runat="server" Text="Are you holding the senior position in the Goverment Institute?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_spgi_yes" runat="server" Text="Yes" GroupName="Q3" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_spgi_no" runat="server" Text="No" GroupName="Q3" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq4" ID="lbl_main_kyc_sppp" runat="server" Text="Are you holding the senior position in Political Party?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_sppp_yes" runat="server" Text="Yes" GroupName="Q4" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_sppp_no" runat="server" Text="No" GroupName="Q4" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_fsupport" runat="server" Text="Do you deal in high value items such as Gold,Silver, Diamond etc?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_fsupport_yes" runat="server" Text="Yes" GroupName="Q16" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_fsupport_no" runat="server" Text="No" GroupName="Q16" Enabled="true" />
                                </label>
                            </div>
                          
                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_hvitem" runat="server" Text="Do you deal in high value items such as Gold,Silver, Diamond etc?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hvitem_yes" runat="server" Text="Yes" GroupName="Q5" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hvitem_no" runat="server" Text="No" GroupName="Q5" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_wealth" runat="server" Text="Customer’s source of Wealth/Income is High Risk/Cash Incentive." Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_wealth_yes" runat="server" Text="Yes" GroupName="Q6" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_wealth_no" runat="server" Text="No" GroupName="Q6" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_head_state" runat="server" Text="Head of State/ Government" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_head_state_yes" runat="server" Text="Yes" GroupName="Q7" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_head_state_no" runat="server" Text="No" GroupName="Q7" Enabled="true" />
                                </label>
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_advisers" runat="server" Text="Federal or Provincial Minister/ Advisers" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_adviser_yes" runat="server" Text="Yes" GroupName="Q8" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_adviser_no" runat="server" Text="No" GroupName="Q8" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_judicial" runat="server" Text="Senior Judicial Officer" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_judicial_yes" runat="server" Text="Yes" GroupName="Q9" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_judicial_no" runat="server" Text="No" GroupName="Q9" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_military" runat="server" Text="Senior Military Officer Ltd. General or above/Air Vice Marshal or above/ Vice Admiral or above" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_military_yes" runat="server" Text="Yes" GroupName="Q10" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_military_no" runat="server" Text="No" GroupName="Q10" Enabled="true" />
                                </label>
                            </div>

                               <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_hod" runat="server" Text="Senior executive or Head of Departments of State Owned Corporations" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hod_yes" runat="server" Text="Yes" GroupName="Q11" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hod_no" runat="server" Text="No" GroupName="Q11" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_io" runat="server" Text="Senior executive of International Organization (such as UN, IMF, World Bank etc)" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_io_yes" runat="server" Text="Yes" GroupName="Q12" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_io_no" runat="server" Text="No" GroupName="Q12" Enabled="true" />
                                </label>
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_mob" runat="server" Text="Member of Board of State Owned/ International Organization" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_mob_yes" runat="server" Text="Yes" GroupName="Q13" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_mob_no" runat="server" Text="No" GroupName="Q13" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_assembly" runat="server" Text="Member of National/ Provincial Assemblies/ Senate (current as well as previous)" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_assembly_yes" runat="server" Text="Yes" GroupName="Q14" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_assembly_no" runat="server" Text="No" GroupName="Q14" Enabled="true" />
                                </label>
                            </div>

                            
                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_party" runat="server" Text="Political Party Officials" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_party_yes" runat="server" Text="Yes" GroupName="Q15" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_party_no" runat="server" Text="No" GroupName="Q15" Enabled="true" />
                                </label>
                            </div>
                            
                             <div class="col-xs-12">
                              
                            </div>
                            <div class="col-xs-12">
                              
                            </div>



                             <asp:Panel ID="panel_kyc_j1" runat="server" Visible="false">

                                   <div class="col-xs-12">
                                <h3>PEP DECLARATION DETAILS For JOINT  HOLDER 1</h3>
                            </div>


                                                                <div class="form-group col-xs-12">
                                <asp:Label for="kycq1" ID="lbl_main_kyc_firoa_j1" runat="server" Text="Has any Financial Institution ever refused to open your account?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_firoa_yes_j1" runat="server" Text="Yes" GroupName="Q1_j1" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_cstm_kyc_firoa_yes_CheckedChanged" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_firoa_no_j1" runat="server" Text="No" GroupName="Q1_j1" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_cstm_kyc_firoa_no_CheckedChanged" />
                                </label>
                            </div>
                          
                          
                            
                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq3" ID="lbl_main_kyc_spgi_j1" runat="server" Text="Are you holding the senior position in the Goverment Institute?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_spgi_yes_j1" runat="server" Text="Yes" GroupName="Q3_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_spgi_no_j1" runat="server" Text="No" GroupName="Q3_j1" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq4" ID="lbl_main_kyc_sppp_j1" runat="server" Text="Are you holding the senior position in Political Party?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_sppp_yes_j1" runat="server" Text="Yes" GroupName="Q4_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_sppp_no_j1" runat="server" Text="No" GroupName="Q4_j1" Enabled="true" />
                                </label>
                            </div>
                           
                                 <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_fsupport_j1" runat="server" Text="Are you (customer) financially dependent or supported by another person?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_fsupport_j1_yes" runat="server" Text="Yes" GroupName="Q16_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_fsupport_j1_no" runat="server" Text="No" GroupName="Q16_j1" Enabled="true" />
                                </label>
                            </div>



                                 
                                  <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_hvitem_j1" runat="server" Text="Do you deal in high value items such as Gold,Silver, Diamond etc?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hvitem_yes_j1" runat="server" Text="Yes" GroupName="Q5_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hvitem_no_j1" runat="server" Text="No" GroupName="Q5_j1" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_wealth_j1" runat="server" Text="Customer’s source of Wealth/Income is High Risk/Cash Incentive." Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_wealth_yes_j1" runat="server" Text="Yes" GroupName="Q6_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_wealth_no_j1" runat="server" Text="No" GroupName="Q6_j1" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_head_state_j1" runat="server" Text="Head of State/ Government" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_head_state_yes_j1" runat="server" Text="Yes" GroupName="Q7_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_head_state_no_j1" runat="server" Text="No" GroupName="Q7_j1" Enabled="true" />
                                </label>
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_advisers_j1" runat="server" Text="Federal or Provincial Minister/ Advisers" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_adviser_yes_j1" runat="server" Text="Yes" GroupName="Q8_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_adviser_no_j1" runat="server" Text="No" GroupName="Q8_j1" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_judicial_j1" runat="server" Text="Senior Judicial Officer" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_judicial_yes_j1" runat="server" Text="Yes" GroupName="Q9_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_judicial_no_j1" runat="server" Text="No" GroupName="Q9_j1" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_military_j1" runat="server" Text="Senior Military officercer Ltd. General or above/Air Vice Marshal or above/ Vice Admiral or above" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_military_yes_j1" runat="server" Text="Yes" GroupName="Q10_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_military_no_j1" runat="server" Text="No" GroupName="Q10_j1" Enabled="true" />
                                </label>
                            </div>

                               <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_hod_j1" runat="server" Text="Senior executive or Head of Departments of State Owned Corporations" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hod_yes_j1" runat="server" Text="Yes" GroupName="Q11_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hod_no_j1" runat="server" Text="No" GroupName="Q11_j1" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_io_j1" runat="server" Text="Senior executive of International Organization (such as UN, IMF, World Bank etc)" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_io_yes_j1" runat="server" Text="Yes" GroupName="Q12_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_io_no_j1" runat="server" Text="No" GroupName="Q12_j1" Enabled="true" />
                                </label>
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_mob_j1" runat="server" Text="Member of Board of State Owned/ International Organization" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_mob_yes_j1" runat="server" Text="Yes" GroupName="Q13_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_mob_no_j1" runat="server" Text="No" GroupName="Q13_j1" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_assembly_j1" runat="server" Text="Member of National/ Provincial Assemblies/ Senate (current as well as previous)" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_assembly_yes_j1" runat="server" Text="Yes" GroupName="Q14_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_assembly_no_j1" runat="server" Text="No" GroupName="Q14_j1" Enabled="true" />
                                </label>
                            </div>

                            
                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_party_j1" runat="server" Text="Political Party Officials" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_party_yes_j1" runat="server" Text="Yes" GroupName="Q15_j1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_party_no_j1" runat="server" Text="No" GroupName="Q15_j1" Enabled="true" />
                                </label>
                            </div>

                                </asp:Panel>
            

                            <div class="col-xs-12"></div>
                            <div class="col-xs-12"></div>

                             <asp:Panel ID="panel_kyc_j2" runat="server" Visible="false">

                                    <div class="col-xs-12">
                                <h3>PEP DECLARATION DETAILS For JOINT  HOLDER 2</h3>
                            </div>

                                <div class="form-group col-xs-12">
                                <asp:Label for="kycq1" ID="lbl_main_kyc_firoa_j2" runat="server" Text="Has any Financial Institution ever refused to open your account?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                <asp:RadioButton ID="Rb_cstm_kyc_firoa_yes_j2" runat="server" Text="Yes" GroupName="Q1_j2" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_cstm_kyc_firoa_yes_CheckedChanged" />
                                </label>
                                <label class="radio-inline">
                                <asp:RadioButton ID="Rb_cstm_kyc_firoa_no_j2" runat="server" Text="No" GroupName="Q1_j2" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_cstm_kyc_firoa_no_CheckedChanged" />
                                </label>
                                </div>
                          
                          
                            
                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq3" ID="lbl_main_kyc_spgi_j2" runat="server" Text="Are you holding the senior position in the Goverment Institute?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_spgi_yes_j2" runat="server" Text="Yes" GroupName="Q3_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_spgi_no_j2" runat="server" Text="No" GroupName="Q3_j2" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq4" ID="lbl_main_kyc_sppp_j2" runat="server" Text="Are you holding the senior position in Political Party?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_sppp_yes_j2" runat="server" Text="Yes" GroupName="Q4_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_sppp_no_j2" runat="server" Text="No" GroupName="Q4_j2" Enabled="true" />
                                </label>
                            </div>
                           
                                 <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_fsupport_j2" runat="server" Text="Are you (customer) financially dependent or supported by another person?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_fsupport_j2_yes" runat="server" Text="Yes" GroupName="Q16_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_fsupport_j2_no" runat="server" Text="No" GroupName="Q16_j2" Enabled="true" />
                                </label>
                            </div>

                                 
                                 
                                 
                                 
                                  <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_hvitem_j2" runat="server" Text="Do you deal in high value items such as Gold,Silver, Diamond etc?" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hvitem_yes_j2" runat="server" Text="Yes" GroupName="Q5_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hvitem_no_j2" runat="server" Text="No" GroupName="Q5_j2" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_wealth_j2" runat="server" Text="Customer’s source of Wealth/Income is High Risk/Cash Incentive." Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_wealth_yes_j2" runat="server" Text="Yes" GroupName="Q6_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_wealth_no_j2" runat="server" Text="No" GroupName="Q6_j2" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_head_state_j2" runat="server" Text="Head of State/ Government" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_head_state_yes_j2" runat="server" Text="Yes" GroupName="Q7_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_head_state_no_j2" runat="server" Text="No" GroupName="Q7_j2" Enabled="true" />
                                </label>
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_advisers_j2" runat="server" Text="Federal or Provincial Minister/ Advisers" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_adviser_yes_j2" runat="server" Text="Yes" GroupName="Q8_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_adviser_no_j2" runat="server" Text="No" GroupName="Q8_j2" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_judicial_j2" runat="server" Text="Senior Judicial Officer" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_judicial_yes_j2" runat="server" Text="Yes" GroupName="Q9_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_judicial_no_j2" runat="server" Text="No" GroupName="Q9_j2" Enabled="true" />
                                </label>
                            </div>

                            <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_military_j2" runat="server" Text="Senior Military Officer Ltd. General or above/Air Vice Marshal or above/ Vice Admiral or above" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_military_yes_j2" runat="server" Text="Yes" GroupName="Q10_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_military_no_j2" runat="server" Text="No" GroupName="Q10_j2" Enabled="true" />
                                </label>
                            </div>

                               <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_hod_j2" runat="server" Text="Senior executive or Head of Departments of State Owned Corporations" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hod_yes_j2" runat="server" Text="Yes" GroupName="Q11_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_hod_no_j2" runat="server" Text="No" GroupName="Q11_j2" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_io_j2" runat="server" Text="Senior executive of International Organization (such as UN, IMF, World Bank etc)" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_io_yes_j2" runat="server" Text="Yes" GroupName="Q12_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_io_no_j2" runat="server" Text="No" GroupName="Q12_j2" Enabled="true" />
                                </label>
                            </div>

                              <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_mob_j2" runat="server" Text="Member of Board of State Owned/ International Organization" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_mob_yes_j2" runat="server" Text="Yes" GroupName="Q13_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_mob_no_j2" runat="server" Text="No" GroupName="Q13_j2" Enabled="true" />
                                </label>
                            </div>

                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_assembly_j2" runat="server" Text="Member of National/ Provincial Assemblies/ Senate (current as well as previous)" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_assembly_yes_j2" runat="server" Text="Yes" GroupName="Q14_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_assembly_no_j2" runat="server" Text="No" GroupName="Q14_j2" Enabled="true" />
                                </label>
                            </div>

                            
                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq5" ID="lbl_main_kyc_party_j2" runat="server" Text="Political Party Officials" Font-Bold="true" Width="500px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_party_yes_j2" runat="server" Text="Yes" GroupName="Q15_j2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_cstm_kyc_party_no_j2" runat="server" Text="No" GroupName="Q15_j2" Enabled="true" />
                                </label>
                            </div>

                                </asp:Panel>


                             <div class="form-group col-xs-12">
                                <asp:Label for="kycq7" ID="lbl_main_kyc_hear_about_us" runat="server" Text="Where do you hear about us?" Font-Bold="true" />
                                <asp:DropDownList ID="ddl_kycq7" runat="server" class="form-control" Enabled="true"
                                    Visible="true">
                                    <asp:ListItem Text="NEWSPAPER/ADVERTISING" Value="NEWSPAPER/ADVERTISING"></asp:ListItem>
                                    <asp:ListItem Text="EMAIL/SMS" Value="EMAIL/SMS"></asp:ListItem>
                                    <asp:ListItem Text="TEAM MEMBER OF ALMEEZAN" Value="TEAM MEMBER OF ALMEEZAN"></asp:ListItem>
                                    <asp:ListItem Text="SOCIAL MEDIA" Value="SOCIAL MEDIA "></asp:ListItem>
                                    <asp:ListItem Text="TELE MARKETTING" Value="TELE MARKETTING"></asp:ListItem>
                                    <asp:ListItem Text="DISTRIBUTORS" Value="DISTRIBUTORS"></asp:ListItem>
                                    <asp:ListItem Text="WEBSITE" Value="WEBSITE"></asp:ListItem>
                                    <asp:ListItem Text="OTHERS" Value="OTHERS"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        
                                
                                
                                
                                </div>



                        <table>
                            <tr style="height: 50px;">

                                <td></td>

                            </tr>

                        </table>

                    </asp:Panel>
                    <asp:Panel ID="panel_fatca" runat="server">
                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>FATCA FORM</h3>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="form-group col-xs-6">
                                <asp:Label for="acct_title" ID="lbl_main_ftca_accnt_title" runat="server" Text="Account Title" Font-Bold="true" />
                                <asp:TextBox ID="txt_ftca_acctitle" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" runat="server"
                                    Enabled="True" TargetControlID="txt_ftca_acctitle" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz "></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-6">
                                <asp:Label for="CNUMBER" ID="lbl_main_ftca_cnic" runat="server" Text="CNIC/NICOP/Passport" Font-Bold="true" />
                                <asp:TextBox ID="txt_ftca_cnicnumber" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" runat="server"
                                    Enabled="True" TargetControlID="txt_ftca_cnicnumber" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="cdivident" ID="lbl_main_ftca_tax_country" runat="server" Text="Country of tax residence other than Pakistan: &nbsp;" Font-Bold="true" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ctrotp_none" runat="server" Text="None" GroupName="fq1" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_ftca_ctrotp_none_CheckedChanged" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ctrotp_USA" runat="server" Text="USA" GroupName="fq1" Enabled="true" AutoPostBack="True" OnCheckedChanged="Rb_ftca_ctrotp_USA_CheckedChanged" />
                                </label>
                                <label class="form-inline radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ctrotp_other" runat="server" Text="Other &nbsp;" GroupName="fq1" Enabled="true" OnCheckedChanged="ftca_ctrotp_other" AutoPostBack="True" />
                                    <asp:TextBox ID="txt_ftca_ctrotp_other_cntry" runat="server" class="form-control" Enabled="true" Visible="true" Style="text-transform: uppercase"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" Enabled="True" TargetControlID="txt_ftca_ctrotp_other_cntry" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"></cc1:FilteredTextBoxExtender>
                                </label>
                            </div>
                            <div class="form-group col-xs-12" style="margin-bottom: 0px;">
                                <label>PLACE OF BIRTH</label>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="birthcity" ID="lbl_main_ftca_city" runat="server" Text="City" Font-Bold="true" />
                                <asp:TextBox ID="txt_ftca_pob_city" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" runat="server" Enabled="True" TargetControlID="txt_ftca_pob_city" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="birthstate" ID="lbl_main_ftca_state" runat="server" Text="State" Font-Bold="true" />
                                <asp:TextBox ID="txt_ftca_pob_bstate" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" runat="server" Enabled="True" TargetControlID="txt_ftca_pob_bstate" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-4">
                                <asp:Label for="birthcountry" ID="lbl_main_ftca_country" runat="server" Text="Country" Font-Bold="true" />
                                <asp:TextBox ID="txt_ftca_pob_birthcountry" runat="server" class="form-control" Enabled="true" Style="text-transform: uppercase"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" runat="server" Enabled="True" TargetControlID="txt_ftca_pob_birthcountry" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq1" ID="lbl_main_ftca_uscitizen" runat="server" Text="Are you a US citizen? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_uscitizen_yes" runat="server" Text="Yes" GroupName="fq2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_uscitizen_no" runat="server" Text="No" GroupName="fq2" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq2" ID="lbl_main_ftca_usresident" runat="server" Text="Are you a US resident? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usresdnt_yes" runat="server" Text="Yes" GroupName="fq3" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usresdnt_no" runat="server" Text="No" GroupName="fq3" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq3" ID="lbl_main_ftca_usgreen_card" runat="server" Text="Do you hold a US permanent resident card (Green card)? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usgc_yes" runat="server" Text="Yes" GroupName="fq4" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usgc_no" runat="server" Text="No" GroupName="fq4" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq4" ID="lbl_main_ftca_us_born" runat="server" Text="Were you born in USA? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usborn_yes" runat="server" Text="Yes" GroupName="fq5" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usborn_no" runat="server" Text="No" GroupName="fq5" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq5" ID="lbl_main_ftca_ussitf" runat="server" Text="Standing instructions to transfer funds to an account maintained in USA? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ussitf_yes" runat="server" Text="Yes" GroupName="fq6" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ussitf_no" runat="server" Text="No" GroupName="fq6" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq6" ID="lbl_main_ftca_uspa" runat="server" Text="Do you have any power of Attorney/Authorized Signatory/Mandate Holder having US address? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_uspa_yes" runat="server" Text="Yes" GroupName="fq7" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_uspa_no" runat="server" Text="No" GroupName="fq7" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq7" ID="lbl_main_ftca_usaddr" runat="server" Text="Do you have US residence /mailing/Sole Hold Mail address? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usaddr_yes" runat="server" Text="Yes" GroupName="fq8" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_usaddr_no" runat="server" Text="No" GroupName="fq8" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_ftca_ustn" runat="server" Text="Do you have US Telephone number? &nbsp;" Font-Bold="true" Width="600px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ustn_yes" runat="server" Text="Yes" GroupName="fq9" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ftca_ustn_no" runat="server" Text="No" GroupName="fq9" Enabled="true" />
                                </label>
                            </div>
                        </div>

                        <table>


                            <tr style="height: 70px;">
                                <td></td>
                            </tr>


                            <tr>

                                <td style="padding-left: 350px;"></td>

                                <td>
                                    <asp:Button ID="btn_back_fatca" runat="server" Text="BACK" Visible="true" OnClick="btn_back_click_fatca" CssClass="btn btn-green" />

                                </td>

                                <td>
                                    <asp:Button ID="btn_next_fatca" runat="server" Text="NEXT" Visible="true" OnClick="btn_next_click_fatca" CssClass="btn btn-green" />

                                </td>

                            </tr>

                        </table>


                    </asp:Panel>
                    <asp:Panel ID="panel_riskprofileform" runat="server">
                        <div class="col-xs-12">
                            <div class="col-xs-12">
                                <h3>RISK PROFILE FORM</h3>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_age" runat="server" Text="Age(in yrs): &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_age_60" runat="server" Text="Above 60" GroupName="rpf1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_age_50" runat="server" Text="50-60" GroupName="rpf1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_age_40" runat="server" Text="40-50" GroupName="rpf1" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_age_39" runat="server" Text="Below 40" GroupName="rpf1" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_rrtl" runat="server" Text="Risk-Return Tolerence Level:  &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_rtl_lr" runat="server" Text="LOWER RISK, LOWER RETURN" GroupName="rpf2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_rtl_mr" runat="server" Text="MEDIUM RISK, MEDIUM RETURN" GroupName="rpf2" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_rtl_hr" runat="server" Text="HIGH RISK, HIGH RETURN" GroupName="rpf2" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_ms" runat="server" Text=" Monthly Savings: &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ms_25" runat="server" Text="Rs.1,000-Rs.25,000" GroupName="rpf3" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ms_50" runat="server" Text="Rs.25,000-Rs.50,000" GroupName="rpf3" Enabled="true"  />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ms_150" runat="server" Text="Rs.150,000-Rs.500,000" GroupName="rpf3" Enabled="true"  Visible="false"/>
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ms_500" runat="server" Text="More than Rs.50,000" GroupName="rpf3" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_occupation" runat="server" Text="Occupation: &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_oc_rtd" runat="server" Text="Retired" GroupName="rpf4" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_oc_hws" runat="server" Text="Housewife/Student" GroupName="rpf4" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_oc_slrd" runat="server" Text="Salaried" GroupName="rpf4" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_oc_bse" runat="server" Text="Business/Self-employed" GroupName="rpf4" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_ib" runat="server" Text="Investment Objective: &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ib_cm" runat="server" Text="Cash Management" GroupName="rpf5" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ib_mi" runat="server" Text="Monthly Income" GroupName="rpf5" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ib_lts" runat="server" Text="Capital Growth/Long term savings" GroupName="rpf5" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ib_rtmnt" runat="server" Text="Retirement" GroupName="rpf5" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_kifm" runat="server" Text="Knowledge of Investment: &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_kifm_lk" runat="server" Text="Limited Knowledge" GroupName="rpf6" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_kifm_bk" runat="server" Text="Basic" GroupName="rpf6" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_kifm_ak" runat="server" Text="Average" GroupName="rpf6" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_kifm_gk" runat="server" Text="Good" GroupName="rpf6" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_kifm_ek" runat="server" Text="Excellent" GroupName="rpf6" Enabled="true" />
                                </label>
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label for="fq8" ID="lbl_main_rpf_ih" runat="server" Text="Investment Horizon: &nbsp;" Font-Bold="true" Width="200px" />
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_ih_6mnths" runat="server" Text="Less than 6 months" GroupName="rpf7" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ih_1yr" runat="server" Text="Less then 1 year" GroupName="rpf7" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ih_23yr" runat="server" Text="2-3 years" GroupName="rpf7" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ih_35yr" runat="server" Text="3-5 years" GroupName="rpf7" Enabled="true" />
                                </label>
                                <label class="radio-inline">
                                    <asp:RadioButton ID="Rb_rpf_ih_5yr" runat="server" Text="More than 5 years" GroupName="rpf7" Enabled="true" />
                                </label>
                            </div>
                        </div>
                        <%-- <div class="form-group">
                                        <label for="investment_horizon">
                                            YOUR IDEAL PORTFOLIO
                                        </label>
                                    </div>--%>
                        <div class="form-group">
                            <asp:RadioButton ID="Rb_rpf_scr_38" runat="server" Text="33-38 - Aggressive - Equity" Visible="false" AutoPostBack="true"
                                GroupName="Software" />
                        </div>
                        <div class="form-group">
                            <asp:RadioButton ID="Rb_rpf_scr_32" runat="server" Text="24-32 - Balance - Balanced" Visible="false" AutoPostBack="true"
                                GroupName="Software" />
                        </div>
                        <div class="form-group">
                            <asp:RadioButton ID="Rb_rpf_scr_23" runat="server" Text="15-23 - Stable - Income" Visible="false" AutoPostBack="true"
                                GroupName="Software" />
                        </div>
                        <div class="form-group">
                            <asp:RadioButton ID="Rb_rpf_scr_14" runat="server" Text="11-14 - Conservative - Money Market" Visible="false" AutoPostBack="true"
                                GroupName="Software" />
                        </div>
                        <div class="col-xs-12">
                            <div class="form-group col-xs-12">
                                <asp:Button ID="btnCalculateIdealPortfolio" runat="server" Text="Calculate" OnClick="btnCalculateIdealPortfolio_Click" CssClass="btn btn-primary" />
                            </div>
                            <div class="form-group col-xs-12">
                                <asp:Label ID="lblidealPortfolio" runat="server"></asp:Label>
                            </div>
                        </div>
                        <table>
                            <tr>
                                <td style="padding-left: 350px;"></td>
                                <td>
                                    <asp:Button ID="btn_back_rpf" runat="server" Text="BACK" Visible="true" OnClick="btn_back_click_rpf" CssClass="btn btn-green" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_next_rpf" runat="server" Text="NEXT" Visible="true" OnClick="btn_next_click_rpf" CssClass="btn btn-green" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>

                    <asp:Panel ID="panel_preview" runat="server">

                        <h3>Preview
                        </h3>

                        <table>

                            <tr>
                                <td>
                                    <asp:Label ID="Label44" runat="server" Text="<h3>Customer Details</h3>" fontcolor="#EE82EE"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="lbl_cnichd" runat="server" Text="<b> CNIC/NICOP/Passport :</b> "></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_cnic_prv" runat="server" Text="CNIC/NICOP/Passport"></asp:Label>
                                </td>


                                <td>
                                    <asp:Label ID="lbl_namehd" runat="server" Text="<b> CUSTOMER NAME:</b>"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_name_prv" runat="server" Text="CUSTOMER NAME"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_fnamehd" runat="server" Text="<b>F/H NAME</b> "></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_fname_prv" runat="server" Text="FATHER/HUSBAND NAME"></asp:Label>
                                </td>

                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td>
                                    <asp:Label ID="Label46" runat="server" Text="               "></asp:Label></td>
                                <td></td>
                            </tr>



                            <tr>

                                <td>
                                    <asp:Label ID="lbl_maritialstatushd" runat="server" Text="<b>MARITAL STATUS:</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_maritalstatus_prv" runat="server" Text="MARITAL STATUS"></asp:Label>

                                </td>


                                <td>
                                    <asp:Label ID="DateofBirthhd" runat="server" Text="<b> Date of Birth:</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Date_of_Birth" runat="server" Text="Date of Birth"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label51" runat="server" Text="<b> CNIC Issue Date: </b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_CNIC_Issue_Date" runat="server" Text="CNIC Expiry Date "></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="<b> CNIC Expiry Date: </b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_CNIC_Expiry_Date" runat="server" Text="CNIC Expiry Date "></asp:Label>
                                </td>


                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>



                            <tr>

                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="<b> Nationality:</b> "></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nationality_prv" runat="server" Text="Nationality"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="<b> Religon:</b>"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_Religon_prv" runat="server" Text="Religon"></asp:Label>
                                </td>



                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="<b> Address: </b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Address_prv" runat="server" Text="Address"></asp:Label>
                                </td>



                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>



                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="<b> Email Address: </b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_EmailAddress_prv" runat="server" Text="Email Address"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="<b> Residense city</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_Residense_city_prv" runat="server" Text="Residense City:"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_country" runat="server" Text="<b> Country </b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_country_prv" runat="server" Text="Country"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>

                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="<b>  Phone Number# </b> "></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_Phone_Number_prv" runat="server" Text="Phone Number"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="<b> Mobile Number# </b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_Mobile_Number_prv" runat="server" Text="Mobile Number"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="<b> Office number# </b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Office_number_prv" runat="server" Text="Office number"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="Label50" runat="server" Text="<h3>BANK ACCOUNT DETAILS</h3>">  
                                    </asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="<b>Bank Name: </b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_BankName_prv" runat="server" Text="Bank Name"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="<b> Account Number </b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_AccountNumber_prv" runat="server" Text="Account Number"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="<b> Branch Name</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Branch_Name_prv" runat="server" Text="Branch Name"></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="<b> Cash Divident </b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_Cash_Divident_prv" runat="server" Text="Cash Divident"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text=" <b> Stock Divident </b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_Stock_Divident_prv" runat="server" Text="Stock Divident"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="<b> Account Type </b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Account_Type_prv" runat="server" Text="Account Type"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="lbl_mtpf_main" runat="server" Text="<b>MTPF ACCOUNT</b>"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_erage_hd" runat="server" Text="<b> EXPECTED RETIREMENT AGE </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_erage_prv" runat="server" Text="EXPECTED RETIREMENT AGE"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_Allocation_Scheme_hd" runat="server" Text=" <b> Allocation Scheme </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_Allocation_Scheme_prv" runat="server" Text="Allocation Scheme"></asp:Label>

                                </td>

                            </tr>


                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_main" runat="server" Text="<b>Nominee Details</b>"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="lbl_nominee_sub1" runat="server" Text="<b>Nominee 1</b>"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_name1_hd" runat="server" Text="<b> NAME </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_name1_prv" runat="server" Text="NAME"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_nominee_cnic1_hd" runat="server" Text="<b> CNIC/NICOP/Passport </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_cnic1_prv" runat="server" Text="CNIC/NICOP/Passport"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_rwp1_hd" runat="server" Text="<b> RELATIONSHIP WITH PRINCIPAL </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_rwp1_prv" runat="server" Text="RELATIONSHIP WITH PRINCIPAL1"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_nominee_shr1_hd" runat="server" Text="<b> Sharing% MTPF </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_shr1_prv" runat="server" Text="Sharing% MTPF"></asp:Label>


                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="lbl_nominee_sub2" runat="server" Text="<b>Nominee 2</b>"></asp:Label>

                                </td>

                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_name2_hd" runat="server" Text="<b> NAME </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_name2_prv" runat="server" Text="NAME"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_nominee_cnic2_hd" runat="server" Text="<b> CNIC/NICOP/Passport </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_cnic2_prv" runat="server" Text="CNIC/NICOP/Passport"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_rwp2_hd" runat="server" Text="<b> RELATIONSHIP WITH PRINCIPAL </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_rwp2_prv" runat="server" Text="RELATIONSHIP WITH PRINCIPAL2"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_nominee_shr2_hd" runat="server" Text="<b> Sharing% MTPF </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_shr2_prv" runat="server" Text="Sharing% MTPF"></asp:Label>
                                </td>




                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="lbl_nominee_sub3" runat="server" Text="<b> Nominee 3</b>"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_name3_hd" runat="server" Text="<b>NAME</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_name3_prv" runat="server" Text="NAME"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_nominee_cnic3_hd" runat="server" Text="<b>CNIC/NICOP/Passport </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_cnic3_prv" runat="server" Text="CNIC/NICOP/Passport"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_nominee_rwp3_hd" runat="server" Text="<b> RELATIONSHIP WITH PRINCIPAL </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_rwp3_prv" runat="server" Text="RELATIONSHIP WITH PRINCIPAL3"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_nominee_shr3_hd" runat="server" Text="<b> Sharing% MTPF </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_nominee_shr3_prv" runat="server" Text="Sharing% MTPF"></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="lbl_acctminr_main" runat="server" Text="<b>Minor Accounts</b>"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_acctminr_gname_hd" runat="server" Text="<b>Name of GURDIAN</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_acctminr_gname_prv" runat="server" Text="Name of GURDIAN"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_acctminr_gcnic_hd" runat="server" Text="<b>Gurdian CNIC NO</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_acctminr_gcnic_prv" runat="server" Text="CNIC NO"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="lbl_acctminr_grwp_hd" runat="server" Text="<b>RELATIONSHIP WITH PRINCIPAL</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_acctminr_grwp_prv" runat="server" Text="RELATIONSHIP WITH PRINCIPAL3"></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="lbl_acctminr_cedate_hd" runat="server" Text="<b>CNIC EXPIRY DATE</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_acctminr_cedate_prv" runat="server" Text=""></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_jh_main" runat="server" Text="<b>Joint Holders Details</b>"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <asp:Label ID="lbl_jh_sub1" runat="server" Text="<b>Joint Holder 1</b>"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbl_jh_name1_hd" runat="server" Text="<b>NAME</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_jh_name1_prv" runat="server" Text="NAME"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_jh_cnic1_hd" runat="server" Text="<b>CNIC/NICOP/Passport</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_jh_cnic1_prv" runat="server" Text="CNIC/NICOP/Passport"></asp:Label>

                                </td>

                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="lbl_jh_rwp1_hd" runat="server" Text="<b> RELATIONSHIP WITH PRINCIPAL </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_jh_rwp1_prv" runat="server" Text=""></asp:Label>
                                </td>


                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="lbl_jh_sub2" runat="server" Text="<b>Joint Holder 2</b>"></asp:Label>

                                </td>

                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_jh_name2_hd" runat="server" Text="<b> NAME </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_jh_name2_prv" runat="server" Text=""></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_jh_cnic2_hd" runat="server" Text="<b> CNIC/NICOP/Passport </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_jh_cnic2_prv" runat="server" Text=""></asp:Label>

                                </td>

                            </tr>

                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="lbl_jh_rwp2_hd" runat="server" Text=" <b> RELATIONSHIP WITH PRINCIPAL </b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_jh_rwp2_prv" runat="server" Text=""></asp:Label>
                                </td>






                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label48" runat="server" Text="<h3>KYC DETAILS</h3>"></asp:Label></td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="<b> OCCUPATION </b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_OCCUPATION_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="<b> SOURCE OF INCOME</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_SOURCE_OF_INCOME_prv" runat="server" Text=""></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="<b> Name of employer/business</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_Name_of_business" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="<b>Has any Financial Institution ever refused to open your account</b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_firoa_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="<b>Are you acting on the behalf of other person</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_abop_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>

                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="<b>Are you holding the senior position in the Goverment Institute</b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_spgi_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text="<b>Are you holding the senior position in Political Party </b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_sppp_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>

                                <td>
                                    <asp:Label ID="Label21" runat="server" Text="<b>Do you deal in high value items such as Gold,Silver, Diamond etc</b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_hitems_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text="<b>Where do you hear about us</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_hereaboutus_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>

                                    <asp:Label ID="Label24" runat="server" Text="<h3>FATCA DETAILS</h3>"></asp:Label>

                                </td>

                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="<b>Account title</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_Account_title_prv" runat="server" Text="Account_title"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="Label28" runat="server" Text="<b>Country of tax other then Pakistan</b>"></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_ctrp_prv" runat="server" Text=""></asp:Label>

                                </td>

                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="Label29" runat="server" Text="<b>Place of Birth</b>"></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Text="<b>City</b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_ftca_pob_city" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label30" runat="server" Text="<b>State</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_pob_state" runat="server" Text=""></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="<b>Country</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_pob_country" runat="server" Text="pakistan"></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label31" runat="server" Text="<b>Are you a US citizen ?<b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_ftca_uscitizen_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label34" runat="server" Text="<b>Are you a US resident ?</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_usresident_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>

                                <td>
                                    <asp:Label ID="Label36" runat="server" Text="<b>Do you hold a US permanent resident card(Green card)?</b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_ftca_usgreencrd_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label38" runat="server" Text="<b>Standing instructions to transfer funds to an account maintained in USA?</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_sitfausa_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>

                                <td>
                                    <asp:Label ID="Label40" runat="server" Text="<b>Do you have any Mandate Holder having US address?</b>"></asp:Label>

                                </td>

                                <td>
                                    <asp:Label ID="lbl_ftca_pwratt_prv" runat="server" Text=""></asp:Label>

                                </td>
                                <td>
                                    <asp:Label ID="Label42" runat="server" Text="<b>Do you have US Telephone number ?</b>"></asp:Label>


                                </td>
                                <td>
                                    <asp:Label ID="lbl_ftca_ustelenum_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>

                                    <asp:Label ID="Label33" runat="server" Text="<h3>Risk Profile Details</h3>"></asp:Label>

                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="Label39" runat="server" Text="<b>Age</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_age_prv" runat="server" Text=""></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label43" runat="server" Text="<b>Risk-Return Tolerence Level</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_rrtl_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label35" runat="server" Text="<b>Monthly Savings</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_ms_prv" runat="server" Text=""></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label37" runat="server" Text="<b>Occupation</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_occ_prv" runat="server" Text=""></asp:Label>
                                </td>

                            </tr>

                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>

                            <tr>

                                <td>
                                    <asp:Label ID="Label45" runat="server" Text="<b>Investment Objective</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_io_prv" runat="server" Text=""></asp:Label>
                                </td>

                                <td>
                                    <asp:Label ID="Label47" runat="server" Text="<b>Knowledge of Investment and Financial markets</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_kifm_prv" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 20px;">
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label ID="Label41" runat="server" Text="<b>Investment Horizon</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_ih_prv" runat="server" Text=""></asp:Label>
                                </td>


                                <td>
                                    <asp:Label ID="Label49" runat="server" Text="<b>Ideal Portfolio</b>"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl_rpf_idealport_prv" runat="server" Text=""></asp:Label>
                                </td>



                            </tr>



                        </table>

                        <table>

                            <tr style="height: 70px;">
                                <td></td>
                            </tr>
                            <%-- <tr>
                            <td colspan="3">
                                <h3>DOCUMENT ATTACHED:</h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBoxList ID="cb_docList" runat="server" RepeatDirection="Horizontal" Width="600px">
                                    <asp:ListItem Value="ID" Text="CNIC/NTN/Form-B"></asp:ListItem>
                                    <asp:ListItem Value="PROOF" Text="Job Proof/Source of Income"></asp:ListItem>
                                    <asp:ListItem Value="ZAKAT"  Text="Zakat Declaration"></asp:ListItem>
                                    <asp:ListItem Value="CHEQUE"  Text="Cheque"></asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>--%>
                          <%--  <tr>
                                <td style="padding-left: 290px"></td>
                                <td>
                                    <asp:Button ID="btn_back_preview" runat="server" Text="BACK" Visible="true" OnClick="btn_back_click_prv" CssClass="btn btn-green" />
                                </td>
                                <td>
                                    <asp:Button ID="btn_submit_preview" runat="server" Text="SUBMIT" Visible="true"
                                        OnClick="btn_submit_Click" CssClass="btn btn-green" />
                                </td>

                                <td>
                                    <asp:Button ID="btn_crystal" runat="server" Text="Proceed to Investment Form" Visible="false"
                                        OnClick="btn_crystal_Click" Enabled="false" CssClass="btn btn-green" OnClientClick="InvestmentForm();" />
                                </td>

                            </tr>--%>

                        </table>



                    </asp:Panel>

                    <div class="form-group" id="finaldiv" runat="server" visible="false">
                        <div class="col-xs-3"></div>
                        <div class="col-xs-2">
                            <asp:Button ID="btn_back_preview" runat="server" Text="BACK" Visible="true" OnClick="btn_back_click_prv" CssClass="btn btn-green" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button ID="btn_submit_preview" runat="server" Text="SUBMIT" Visible="true" OnClick="btn_submit_Click" CssClass="btn btn-green" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button ID="btn_crystal" runat="server" Text="PROCEED TO INVESTMENT FORM" Visible="false" OnClick="btn_crystal_Click" Enabled="false" CssClass="btn btn-green" OnClientClick="InvestmentForm();" />
                        </div>
                        <div class="col-xs-3"></div>
                    </div>



                    <div>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" Visible="true" OnClick="btn_submit_Click" CssClass="btn btn-green" />
                                </td>
                            </tr>
                            <%-- <tr style="height:50px;">
                                
                                <td></td>
                                <td></td>
                                <td></td>
                                </tr>--%>

                            <tr>

                                <td style="padding-left: 490px;"></td>
                                <td>
                                    <asp:Button ID="btn_next" runat="server" Text="NEXT" Visible="true" OnClick="btn_next_click" CssClass="btn btn-green" />
                                </td>

                                <td style="padding-left: 170px;"></td>

                            </tr>

                        </table>

                        <asp:Panel ID="panel_error_mesg" runat="server" Visible="false">
                            <table>
                                <tr>
                                    <td style="padding-left: 450px"></td>

                                    <td align="center">
                                        <asp:Label ID="Lblmsg" runat="server" Font-Bold="True" Font-Size="XX-large" ForeColor="#FF3300" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="mystage_" runat="server" Visible="false">
                                        </asp:Label>
                                    </td>

                                </tr>
                                <tr style="height: 40px;">
                                    <td></td>

                                </tr>


                                <tr>
                                    <td style="padding-left: 100px"></td>

                                    <td>
                                        <asp:Button ID="btn_go_back" runat="server" Text="GO BACK" Visible="false"
                                            CssClass="btn btn-green" OnClick="btn_go_back_Click" />
                                    </td>
                                </tr>

                            </table>

                        </asp:Panel>

                    </div>

                </div>
                <div class="col-xs-12">
                    &nbsp;
                </div>
            </div>
        </div>
    </div>
</asp:Content>
