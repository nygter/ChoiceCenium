<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="ChoiceCenium.View" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v14.1, Version=14.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.1.min.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/style.css"/>

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
    <form id="form1" runat="server" ClientIDMode="Static">
        
        <div class="headercontainer">
            <div class="headerleft">
                Choice Cenium upgrade
             </div>
            <div class="headerright">
                
                <asp:LinkButton runat="server" ID="lnkLogout" OnClick="lnkLogout_Click" Text="Logg ut" ClientIDMode="Static"/>
                <img id="lnkLogin" runat="server" ClientIDMode="Static" src="Images/lock.png"/>

                <div runat="server" ID="pnlLogin" ClientIDMode="Static" style="display:none">
      Brukernavn: <asp:TextBox runat="server" ID="txtUsername"/>&nbsp;
                    Passord: <asp:TextBox runat="server" ID="txtPassword" />&nbsp;&nbsp;
                    <asp:LinkButton runat="server" onclick="ValidateUser_Click" ID="loginSuperUser" Text="Logg inn"/>  
                </div>
            </div>
        </div>

        
            <div class="maincontent">
                
            
            <dx:ASPxGridView ID="HotelList" runat="server" AutoGenerateColumns="False" DataSourceID="CeniumDataSource" Theme="Office2010Black" KeyFieldName="HotelId" Width="100%">
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0" ShowNewButtonInHeader="True" Caption="Opprett" />
                <dx:GridViewDataTextColumn FieldName="HotelId" VisibleIndex="1" Visible="False" />
                <dx:GridViewDataTextColumn FieldName="HotelName" VisibleIndex="2" SortIndex="0" SortOrder="Ascending"/>
                <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="3"/>
                <dx:GridViewDataTextColumn FieldName="Lon" VisibleIndex="4" Visible="False" />
                <dx:GridViewDataTextColumn FieldName="Lat" VisibleIndex="5" Visible="False" />
                <dx:GridViewDataTextColumn FieldName="CurrCeniumVersion" VisibleIndex="6" SortIndex="1" SortOrder="Ascending"/>
                <dx:GridViewDataDateColumn FieldName="UpgradeDate" VisibleIndex="7" SortIndex="2" SortOrder="Ascending"/>
                <dx:GridViewDataCheckColumn FieldName="CeniumUpgradeComplete" VisibleIndex="8" SortIndex="3" SortOrder="Ascending"/>
                <dx:GridViewDataCheckColumn FieldName="NotUpgrading" VisibleIndex="9" SortIndex="4" SortOrder="Ascending"/>
                <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="12" Caption=" " />
                <dx:GridViewDataComboBoxColumn FieldName="KjedeId" VisibleIndex="11">
                    <PropertiesComboBox DataSourceID="KjedeInfoDataSource" TextField="KjedeNavn" ValueField="KjedeId">
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="CeniumDataSource" runat="server" DataObjectTypeName="ChoiceCenium.Hotelinfoes" DeleteMethod="DeleteHotelInfo" SelectMethod="GetHotelInfo" TypeName="ChoiceCenium.Models.HotelInfo" UpdateMethod="UpdateHotelInfo" InsertMethod="InsertHotelInfo"></asp:ObjectDataSource>    
                <asp:ObjectDataSource ID="KjedeInfoDataSource" runat="server" SelectMethod="GetKjedeInfo" TypeName="ChoiceCenium.Models.KjedeInfo"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
