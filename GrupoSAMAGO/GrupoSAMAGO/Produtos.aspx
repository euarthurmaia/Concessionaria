<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="GrupoSAMAGO.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Produtos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <main>
        <br />
        <div class="imagem-veiculo">
            <div class="imagem-esq">
                <asp:Image ID="ImagemVeiculoEsq" runat="server" />
            </div>
            <div class="imagem-cen">
                <asp:Image ID="ImagemVeiculo" runat="server" />
            </div>
            <div class="imagem-dir">
                <asp:Image ID="ImagemVeiculoDir" runat="server" />
            </div>
        </div>

        <div class="info-produto" runat="server">
            <div class="info-veiculo">
                <div class="tamanho-info">
                    <div class="logo-nome">
                        <div class="logo-marca">
                            <asp:Image ID="ImagemMarca" runat="server" />
                        </div>
                        <div class="nome-veiculo">
                            <h4 runat="server" id="txtNomeVeiculo"></h4>
                        </div>
                    </div>
                    <hr />
                    <div class="sobre-veiculo">
                        <div class="class-sobre" runat="server">
                            <label class="label-descricao">Ano Modelo:</label>
                            <h6 runat="server" id="txtAnoModelo"></h6>
                        </div>
                        <div class="class-sobre" runat="server">
                            <label class="label-descricao">Cor:</label>
                            <h6 runat="server" id="txtCor"></h6>
                        </div>
                        <div class="class-sobre" runat="server">
                            <label class="label-descricao">Combustível:</label>
                            <h6 runat="server" id="txtCombustivel"></h6>
                        </div>
                        <div class="class-sobre" runat="server">
                            <label class="label-descricao">Quilometragem:</label>
                            <h6 runat="server" id="txtQuilometragem"></h6>
                        </div>
                        <div class="class-sobre" runat="server">
                            <label class="label-descricao">Câmbio:</label>
                            <h6 runat="server" id="txtCambio"></h6>
                        </div>
                        <div class="class-sobre" runat="server">
                            <label class="label-descricao">Final da Placa:</label>
                            <h6 runat="server" id="txtFinalPlaca"></h6>
                        </div>
                    </div>
                    <div class="descricao-veiculo">
                        <label class="label-descricao">Descrição:</label>
                        <h6 runat="server" id="txtDescricao"></h6>
                    </div>
                    <br />
                </div>
            </div>
            <div class="contato" runat="server">
                <h3 runat="server" id="txtValorContato"></h3>
                <hr />
                <asp:TextBox ID="txtNome" runat="server" placeholder="Nome*"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email*"></asp:TextBox>
                <asp:TextBox ID="txtTelefone" runat="server" placeholder="Telefone*"></asp:TextBox>
                <div class="mensagem">
                    <asp:TextBox ID="txtMensagem" runat="server"  TextMode="MultiLine" Rows="4" Columns="30" placeholder="Mensagem..."></asp:TextBox>
                </div>
                <asp:Button ID="btnEnviarMensagem" runat="server" Text="Enviar Mensagem" />


            </div>
        </div>
        <br />
    </main>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>
