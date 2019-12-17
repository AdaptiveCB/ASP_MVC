<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Luis_WF.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <div class="container mt-5">
        <div class="mb-3">
            <asp:Label runat="server" Text="Mantenimiento de Colaboradores" CssClass="h3"></asp:Label>
        </div>
        
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfIdColaborador" runat="server" />
            <table class="table table-borderless table-sm">
                <tr>                    
                    <td>
                        <asp:Label runat="server" Text="Nombres"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                        
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Apellidos"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Sueldo"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtSueldo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Sede"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSede" runat="server">
                            <asp:ListItem Text="Elegir sede" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="La Molina" Value="La Molina"></asp:ListItem>
                            <asp:ListItem Text="San Isidro" Value="San Isidro"></asp:ListItem>
                            <asp:ListItem Text="Cercado de Lima" Value="Cercado de Lima"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblExito" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>

            <hr />

            <asp:GridView ID="gvColaborador" runat="server" AutoGenerateColumns="false" Width="900px" CssClass="table table-sm table-striped table-hover table-center table-bordered">
                <Columns>
                    <asp:BoundField DataField="nombres" HeaderText="Nombre" ControlStyle-BackColor="YellowGreen" />
                    <asp:BoundField DataField="apellidos" HeaderText="Apellido" />
                    <asp:BoundField DataField="sueldo" HeaderText="Sueldo" />
                    <asp:BoundField DataField="sede" HeaderText="Sede" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("id_colaborador") %>' OnClick="lnk_Click">Ver</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
    </div>
</body>
</html>
