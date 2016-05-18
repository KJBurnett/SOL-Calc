<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="Sol_Calc_Online.Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Statute of Limitations Calculator</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1"> 
  <link rel="stylesheet" href="bootstrap.css">
    <link rel="stylesheet" type="text/css" href="mystyles.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body class="gray-bg">
<form runat="server">
    <div class="container">
        <div class="container">
            <div class="row-fluid animated fadeInDown">
                <div class="col-md-6 col-lg-6" style="padding-right:5px">
                    <div class="ibox float-e-margins">
                        <div class="ibox-content">
                            <ul class="list-inline">
                                <li>
                                    <h4>Years of Limitation</h4>
                                </li>
                                <li>
                                    <asp:TextBox ID="LimitationLengthTextBox" TextMode="Number" 
                                        runat="server" min="0" step="1" BorderStyle="Inset" Width="40px" />
                                </li>
                        </ul>
                        </div>
                        <div class="ibox-content">
                            <ul class="list-inline">
                                <li>
                                    <h4>Start Date of Limitation</h4>
                                </li>
                                <li>
                                    <asp:TextBox ID="StartTextBox" runat="server" TextMode="Date" Width="140px"></asp:TextBox>
                                </li>
                        </ul>
                        </div>
                        <div class="ibox-content">
                            <ul class="list-inline">
                                <li>
                                    <h4>Total Days in Tolling Periods = </h4>
                                </li>
                                <li class="pull-right">
                                    <asp:Label ID="TotalPeriodDaysLabel" runat="server"></asp:Label>
                                </li>
                                <li>
                                    <asp:ListBox ID="PeriodListBox" runat="server" SelectionMode="Single" Width="240px" Height="120px" />
                                </li>
                                <li style="padding-top:5px; padding-bottom:5px">
                                    <asp:Button class="btn btn-danger" ID="DeleteButton" Text="Delete" runat="server" OnClick="DeleteButton_Click" />
                                    <asp:Button class="btn btn-danger" ID="DeleteAllButton" Text="Delete All" runat="server" OnClick="DeleteAllButton_Click" />
                                </li>
                            </ul>
                        </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-lg-6 no-padding">
            <div class="ibox float-e-margins">
                <div class="ibox-content">
                    <ul class="list-inline">
                        <li>
                            <h4>Tolling Periods (MM/dd/yyyy)</h4>
                        </li>
                        <li>
                            <h5>Start Period:</h5>
                        </li>
                        <li class="pull-right">
                            <asp:TextBox ID="StartPeriodTextBox" runat="server" TextMode="Date" Width="140px"></asp:TextBox>
                        </li>
                        <li style="padding-top:10px;">
                            <h5>End Period:</h5>
                        </li>
                        <li class="pull-right" style="padding-top:10px;"">
                            <asp:TextBox ID="EndPeriodTextbox" runat="server" TextMode="Date" Width="140px"></asp:TextBox>
                        </li>
                        <li style="padding-top:5px;">
                            <asp:Button class="btn btn-success" ID="AddPeriodButton" Text="Add Tolling Period" runat="server" OnClick="AddPeriodButton_Click" />
                        </li>
                    </ul>
                </div>
                <div class="ibox-content">
                    <ul class="list-inline">
                        <li>
                            <h4>Calculate End Limitation Date</h4>
                            <asp:TextBox ID="ResultTextBox" runat="server"></asp:TextBox>
                        </li>
                        <li style="padding-top:5px;">
                            <asp:Button class="btn btn-rounded btn-primary" ID="CalculateButton" Text="Calculate!" runat="server" OnClick="CalculateButton_Click" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</form>
</body>
</html>

