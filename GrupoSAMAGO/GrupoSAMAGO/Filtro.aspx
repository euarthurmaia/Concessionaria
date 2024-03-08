<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Filtro.aspx.cs" Inherits="GrupoSAMAGO.Filtro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Filtro.css" rel="stylesheet" />
    <link href="css/bootstrap-css.min.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <main>
        <br />
        <div class="filtro">
            <div class="tamanho-filtro">
                <div class="titulo-filtro">
                    <h3>FILTROS</h3>
                </div>
                <hr />
                <div class="botoes">
                    <asp:Button ID="btnFiltrar1" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnLimpar1" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                </div>
                <hr />
                <div class="caixa-filtro">
                    <h4>Marcas:</h4>
                    <div class="marcas-carros">

                        <asp:DropDownList runat="server" ID="DDLMarcasCarros">
                        </asp:DropDownList>

                    </div>
                    <hr />
                    <h4>Valor:</h4>
                    <div class="valor">
                        <asp:TextBox class="Text" TextMode="Number" ID="ValorMin" runat="server"></asp:TextBox>
                        <asp:TextBox class="Text" TextMode="Number" ID="ValorMax" runat="server"></asp:TextBox>
                    </div>
                    <hr />
                    <h4>Ano:</h4>
                    <div class="ano-filtro">
                        <asp:TextBox class="Text" TextMode="Number" ID="AnoMenor" runat="server"></asp:TextBox>
                        <asp:TextBox class="Text" TextMode="Number" ID="AnoMaior" runat="server"></asp:TextBox>
                    </div>
                    <hr />
                    <h4>Quilometragem:</h4>
                    <div class="km-filtro">
                        <asp:TextBox class="Text" TextMode="Number" ID="KmMenor" runat="server"></asp:TextBox>
                        <asp:TextBox class="Text" TextMode="Number" ID="KmMaior" runat="server"></asp:TextBox>
                    </div>
                    <hr />
                    <h4>Combustível:</h4>
                    <div class="combustivel">


                        <asp:RadioButtonList ID="RadioButtonCombustivel" runat="server" RepeatDirection="Vertical">
                            <asp:ListItem Text="" Value="" />
                        </asp:RadioButtonList>


                    </div>
                    <hr />
                    <h4>Câmbio:</h4>
                    <div class="cambio">
                        <asp:RadioButtonList ID="RadioButtonCambio" runat="server" RepeatDirection="Vertical">
                            <asp:ListItem Text="" Value="" />
                        </asp:RadioButtonList>
                    </div>
                    <hr />
                    <h4>Cor:</h4>
                    <div class="cor">
                        <asp:RadioButtonList ID="RadioButtonCor" runat="server" RepeatDirection="Vertical">
                            <asp:ListItem Text="" Value="" />
                        </asp:RadioButtonList>
                    </div>

                </div>
            </div>
        </div>
        <div class="resultado">

            <div class="tamanho-resultado">
                <asp:ListView runat="server" ID="lvFiltro" OnItemCommand="lvVeiculos_ItemCommand">
                    <ItemTemplate>

                        <div class="produto">
                            <asp:LinkButton text-decoration="none" CommandArgument='<%# Eval("IdVeiculo") %>' runat="server">
                                <div class="img-produto">
                                    <img src='<%# Eval("GetImagem") %>' />
                                </div>
                                <div class="descricao-produto">
                                    <div class="marca-descricao-produto">
                                        <div class="marca-imagem">
                                            <img src="<%# Eval("GetImagemMarcas") %>" />
                                        </div>
                                        <div class="ver-parcelas">
                                            
                                                <button>Ver Parcelas</button>
                                            
                                        </div>
                                    </div>
                                    <div class="nome-veiculo">
                                        <label><%# Eval("GetNomeVeiculo") %></label>
                                    </div>
                                    <div class="info-descricao-produto">
                                        <div class="info-produto">
                                            <label><%# Eval("GetInfoProduto") %></label>
                                        </div>
                                        <div class="ano-produto">
                                            <label><%# Eval("GetAnoModelo") %></label>
                                        </div>
                                    </div>
                                    <div class="valor-produto">
                                        <label><%# Eval("GetValorVeiculo") %></label>
                                    </div>
                                </div>
                            </asp:LinkButton>
                        </div>

                    </ItemTemplate>
                </asp:ListView>
            </div>
            <br />
        </div>

    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="js/bootstrap-js.bundle.min.js"></script>
</asp:Content>
