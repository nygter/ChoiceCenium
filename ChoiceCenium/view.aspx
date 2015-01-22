<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="ChoiceCenium.View" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/style.css" />

    <script type="text/javascript">

        $(document).ready(function () {

            $('#lnkLogin').click(function (e) {
                e.preventDefault();
                $(this).hide();
                $('#pnlLogin').show();
                $('#pnlLogin').css('display', '');
            });
        });

    </script>

</head>
<body>
    <form id="form1" runat="server" clientidmode="Static">

        <div class="headercontainer">
            <div style="width: 100%; height: 50px; background-color: black">&nbsp;</div>
            <div class="headerleft">
                <h2>NORDIC CHOICE HOTELS - HOTEL ADMINISTRATION
                </h2>
            </div>
            <div class="headerright">

                <asp:LinkButton runat="server" ID="lnkLogout" OnClick="lnkLogout_Click" Text="Logg ut" ClientIDMode="Static" />
                <img id="lnkLogin" runat="server" clientidmode="Static" src="Images/lock.png" />

                <div runat="server" id="pnlLogin" clientidmode="Static" style="display: none">
                    Brukernavn:
                    <asp:TextBox runat="server" ID="txtUsername" />&nbsp;
                    Passord:
                    <asp:TextBox runat="server" ID="txtPassword" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" OnClick="ValidateUser_Click" ID="loginSuperUser" Text="Logg inn" />
                </div>
            </div>
        </div>


        <div class="maincontent">


            <dx:ASPxGridView ID="HotelList" 
                runat="server" 
                AutoGenerateColumns="False" 
                DataSourceID="CeniumDataSource" 
                Theme="Office2010Black" 
                KeyFieldName="HotelId" 
                Width="100%" EnableTheming="True" 
                OnCommandButtonInitialize="HotelList_CommandButtonInitialize">
                <SettingsPager PageSize="30" />
                <Settings ShowFilterRow="True" />

                <SettingsCommandButton>
                    <EditButton Image-Url="Images/icon-edit.png">
                        <Image Url="Images/icon-edit.png"></Image>
                    </EditButton>
                    <DeleteButton Image-Url="Images/icon-delete.png">
                        <Image Url="Images/icon-delete.png"></Image>
                    </DeleteButton>
                    <NewButton Image-Url="Images/icon-plus.png">
                        <Image Url="Images/icon-plus.png"></Image>
                    </NewButton>



                </SettingsCommandButton>

                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0" ShowNewButtonInHeader="True" Caption="" Visible="False" ShowClearFilterButton="True" >
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="HotelId" VisibleIndex="1" Visible="False" Caption="Hotel ID">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="PropertyCode" VisibleIndex="2" Caption="Property Code" SortIndex="2" Width="150px">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="HotelName" VisibleIndex="3" SortIndex="0" SortOrder="Ascending" Caption="Hotel Name" MinWidth="100" Width="450px">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="4" Caption="Address" SortIndex="1">

                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataComboBoxColumn FieldName="KjedeId" VisibleIndex="5" Caption="Kjede" Visible="False" Width="200px">
                        <PropertiesComboBox DataSourceID="KjedeInfoDataSource" TextField="KjedeNavn" ValueField="KjedeId">
                        </PropertiesComboBox>
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Lon" VisibleIndex="6" Visible="False">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Lat" VisibleIndex="7" Visible="False">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CurrCeniumVersion" VisibleIndex="8" SortIndex="3" SortOrder="Ascending" Caption="Cenium Ver." Visible="False" Width="10px">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="UpgradeDate" VisibleIndex="9" SortIndex="4" SortOrder="Ascending" Caption="Upgrade Date">
                        <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy">
                        </PropertiesDateEdit>
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataCheckColumn FieldName="CeniumUpgradeComplete" VisibleIndex="10" SortIndex="5" SortOrder="Ascending" Caption="Upgrade Complete" Visible="False">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn FieldName="NotUpgrading" VisibleIndex="11" SortIndex="6" SortOrder="Ascending" Caption="Non Cenium" Visible="False">
                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="12" Visible="False">

                        <CellStyle Font-Size="12pt">
                        </CellStyle>
                        <GroupFooterCellStyle BackColor="Black" ForeColor="White">
                        </GroupFooterCellStyle>
                    </dx:GridViewCommandColumn>

                </Columns>
                <Templates>
                    <EditForm>
                        <div style="padding: 30px;">
                      
                        <table>
                                <tr>
                                    <td>
                                        <table class="tbl-def">
                                            <tr>
                                                <td class="tbl-lbl">Property Code 
                                                </td>
                                               <td>
                                                    <dx:ASPxTextBox ID="PersonalIDTB" CssClass="tbl-txt" runat="server" Text='<%# Bind("PropertyCode") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tbl-lbl">Hotel Name 
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox ID="FirstNameTB" CssClass="tbl-txt" runat="server" Text='<%# Bind("HotelName") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tbl-lbl">Address 
                                                </td>
                                              <td>
                                                    <dx:ASPxTextBox ID="MiddleNameTB" CssClass="tbl-txt" runat="server" Text='<%# Bind("Address") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tbl-lbl">Kjede
                                                </td>
                                              <td>
                                                    <dx:ASPxComboBox ID="ASPxComboBox1" CssClass="tbl-txt" runat="server" Value='<%#Bind("KjedeId")%>' DataSourceID="KjedeInfoDataSource" TextField="KjedeNavn" ValueField="KjedeId" ValueType="System.Int32"></dx:ASPxComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Lon
                                                </td>
                                               <td>
                                                    <dx:ASPxTextBox CssClass="tbl-txt" ID="KnownAsTB" runat="server" Text='<%# Bind("Lon") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Lat
                                                </td>
                                               <td>
                                                    <dx:ASPxTextBox CssClass="tbl-txt" ID="ASPxTextBox1" runat="server" Text='<%# Bind("Lat") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Current Cenium Version
                                                </td>
                                                <td>
                                                    <dx:ASPxTextBox CssClass="tbl-txt" ID="ASPxTextBox2" runat="server" Text='<%# Bind("CurrCeniumVersion") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>UpgradeDate
                                                </td>
                                               <td>
                                                    <dx:ASPxDateEdit CssClass="tbl-txt" ID="BirthdayDateEdit" runat="server" MaxDate="2030-01-01" MinDate="1900-01-01"
                                                        Value='<%# Bind("UpgradeDate") %>' EditFormatString="dd.MM.yyyy" DisplayFormatString="dd.MM.yyyy"
                                                        NullText="Not set">
                                                    </dx:ASPxDateEdit>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Cenium Upgrade Complete
                                                </td>
                                              <td>
                                                    <dx:ASPxCheckBox ID="ActiveCheckBox" runat="server" Value='<%# Bind("CeniumUpgradeComplete") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Not Upgrading
                                                </td>
                                               <td>
                                                    <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Value='<%# Bind("NotUpgrading") %>' />
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br/><br/>

                            <div style="text-align: left; padding: 2px; font-size:20px">
                                <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server" />
                                <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server" />
                            </div>
                        </div>
                    </EditForm>
                </Templates>
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="CeniumDataSource" runat="server" DataObjectTypeName="ChoiceCenium.Hotelinfoes" DeleteMethod="DeleteHotelInfo" SelectMethod="GetHotelInfo" TypeName="ChoiceCenium.Models.HotelInfo" UpdateMethod="UpdateHotelInfo" InsertMethod="InsertHotelInfo"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="KjedeInfoDataSource" runat="server" SelectMethod="GetKjedeInfo" TypeName="ChoiceCenium.Models.KjedeInfo"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
