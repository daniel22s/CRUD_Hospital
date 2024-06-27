<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUDWebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
         <div class="jumbotron">
             <asp:Panel ID="pnlDatoPaciente" runat="server">
                 <asp:GridView ID="gvdPaciente" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                        OnRowDeleting="gvdPaciente_RowDeleting" OnRowDeleted="gvdPaciente_RowDeleted">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id Paciente" />
                            <asp:BoundField DataField="NombrePaciente" HeaderText="Nombre" />
                            <asp:BoundField DataField="ApPaterno" HeaderText="Apellido Paterno" />
                            <asp:BoundField DataField="ApMaterno" HeaderText="Apellido Materno" />
                            <asp:BoundField DataField="Edad" HeaderText="Edad" />
                            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbActualizar" runat="server" Text="Actualizar" OnClick="lkbActualizar_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                 <asp:Button ID="btnNuevo" Text="Nuevo Paciente" runat="server" OnClick="btnNuevo_Click" />
             </asp:Panel>
              
             <asp:Panel ID="pnlAltaPaciente" runat="server" Visible="false"> 
                 <div>
                     <asp:Label ID="lblNombre" Text="Nombre" runat="server"></asp:Label>
                     <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                 </div>
                 <div>
                    <asp:Label ID="lblApPaterno" Text="Apellido Paterno" runat="server"></asp:Label>
                    <asp:TextBox ID="txtApPaterno" runat="server"></asp:TextBox>
                </div>
                  <div>
                     <asp:Label ID="lblApMaterno" Text="Apellido Materno" runat="server"></asp:Label>
                     <asp:TextBox ID="txtApMaterno" runat="server"></asp:TextBox>
                 </div>
                 <div>
                    <asp:Label ID="lblEdad" Text="Edad" runat="server"></asp:Label>
                    <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
                </div>
                  <div>
                    <asp:Label ID="lblEspecialidad" Text="Especialidad" runat="server"></asp:Label>
                    <asp:TextBox ID="txtEspecialidad" runat="server"></asp:TextBox>
                </div>
                 <br />
                 <asp:Label ID="lblIdPaciente" runat="server" Visible ="false" ></asp:Label>
                 <asp:Button ID="btnGuardar" runat="server" Text="Guardar Paciente" OnClick="btnGuardar_Click" />
                 <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Paciente" OnClick="btnActualizar_Click" />
             </asp:Panel>

        </div>
    </main>

</asp:Content>
