<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GrupoSAMAGO.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Default.css" rel="stylesheet" />
    <link href="css/bootstrap-css.min.css" rel="stylesheet" />
    <link href="css/owl.carousel.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <main runat="server">
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active"
                    aria-current="true" aria-label="Slide 1">
                </button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1"
                    aria-label="Slide 2">
                </button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="img/carousel1.jpg" class="imagem-carrossel d-block w-100" alt="...">
                </div>
                <div class="carousel-item">
                    <img src="img/carousel2.jpg" class="imagem-carrossel d-block w-100" alt="...">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators"
                data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators"
                data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <hr />
        <h3>ENCONTRE SEU VEÍCULO</h3>
        <div class="pesquisa-produtos">

            <asp:DropDownList ID="DDLMarcas" AutoPostBack="true" OnSelectedIndexChanged="DDLMarcas_SelectedIndexChanged" runat="server">
                <asp:ListItem Text="" Value="" />
            </asp:DropDownList>

            <asp:DropDownList ID="DDLNome" AutoPostBack="true" OnSelectedIndexChanged="DDLNome_SelectedIndexChanged" runat="server">
                <asp:ListItem Text="VEÍCULOS" />
            </asp:DropDownList>

            <asp:DropDownList ID="DDLCambio" runat="server">
                <asp:ListItem Text="CÂMBIOS" />
            </asp:DropDownList>
            <asp:Button ID="btnFiltrar" runat="server" Text="Ver Veículos" OnClick="btnFiltrar_Click" />
        </div>
        <hr />
        <h3>CONFIRA NOSSOS PRODUTOS</h3>
        <div class="amostra-produtos">


            <asp:ListView runat="server" ID="lvVeiculos" OnItemCommand="lvVeiculos_ItemCommand">
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

    </main>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/bootstrap-js.bundle.min.js"></script>
</asp:Content>
