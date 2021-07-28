<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ViewRoomAssign.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        
        form{
            padding: 10px;
            padding-top: 80px;
            padding-bottom: 100px;
            margin: auto;
            margin-top:200px;
            width:50%;
            text-align: center;
            border: 1px solid black;
        }

        div input{
            height: 60px;
            font-size:25px;
        }

        input{
            height: 40px;
            font-size:25px;
            width:200px;
            border-radius:10px;
            background-color:white;
        }
        input:hover{
            background-color:burlywood;
        }

        .message{
            margin:10px;
        }
        span{
            color:red;
        }
        
    </style>
</head>
<body>
    
    <form id="form1"  runat="server" >
        <h1>Login form</h1>
        <div>
            <asp:TextBox ID="TextBox1" placeholder="Username" runat="server" Width="320px"></asp:TextBox>
            </div>
        <br/>
        <div>
            <asp:TextBox ID="TextBox2" placeholder="Password" TextMode="Password" runat="server" Width="319px"></asp:TextBox>
        </div>
       <br/>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
        <br/>
        <div class="message">
        <asp:Label ID="Label1" runat="server" ></asp:Label>
            </div>
    </form>
        
</body>
</html>
