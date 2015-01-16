<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="ChoiceCenium.View" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%@ Register assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>

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
            <SettingsPager PageSize="30" />
                <Columns>
                <dx:GridViewCommandColumn ShowEditButton="true" VisibleIndex="0" ShowNewButtonInHeader="True" Caption="Opprett" />
                <dx:GridViewDataTextColumn FieldName="HotelId" VisibleIndex="1" Visible="False" Caption="Hotel ID" />
                <dx:GridViewDataTextColumn FieldName="PropertyCode" VisibleIndex="2" Caption="Property Code" SortIndex="2" />
                <dx:GridViewDataTextColumn FieldName="HotelName" VisibleIndex="3" SortIndex="0" SortOrder="Ascending" Caption="Hotel Name"/>
                    <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="4" Caption="Address" SortIndex="1" />
                
                    <dx:GridViewDataComboBoxColumn FieldName="KjedeId" VisibleIndex="5" Caption="Kjede" Visible="False">
                    <PropertiesComboBox DataSourceID="KjedeInfoDataSource" TextField="KjedeNavn" ValueField="KjedeId">
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="Lon" VisibleIndex="6" Visible="False" />
                <dx:GridViewDataTextColumn FieldName="Lat" VisibleIndex="7" Visible="False" />
                <dx:GridViewDataTextColumn FieldName="CurrCeniumVersion" VisibleIndex="8" SortIndex="3" SortOrder="Ascending" Caption="Cenium Ver." Visible="False" Width="10px" />
                <dx:GridViewDataDateColumn FieldName="UpgradeDate" VisibleIndex="9" SortIndex="4" SortOrder="Ascending" Caption="Upgrade Date">
                    <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy">
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                    <dx:GridViewDataCheckColumn FieldName="CeniumUpgradeComplete" VisibleIndex="10" SortIndex="5" SortOrder="Ascending" Caption="Upgrade Complete" Visible="False"/>
                <dx:GridViewDataCheckColumn FieldName="NotUpgrading" VisibleIndex="11" SortIndex="6" SortOrder="Ascending" Caption="Non Cenium" Visible="False" />
                <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="12" Visible="False" />
                
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="CeniumDataSource" runat="server" DataObjectTypeName="ChoiceCenium.Hotelinfoes" DeleteMethod="DeleteHotelInfo" SelectMethod="GetHotelInfo" TypeName="ChoiceCenium.Models.HotelInfo" UpdateMethod="UpdateHotelInfo" InsertMethod="InsertHotelInfo"></asp:ObjectDataSource>    
                <asp:ObjectDataSource ID="KjedeInfoDataSource" runat="server" SelectMethod="GetKjedeInfo" TypeName="ChoiceCenium.Models.KjedeInfo"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
