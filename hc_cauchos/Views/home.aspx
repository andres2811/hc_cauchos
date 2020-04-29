<%@ Page Title="" Language="C#" MasterPageFile="~/Views/principal.master" AutoEventWireup="true" CodeFile="~/Controllers/home.aspx.cs" Inherits="Views_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
      
          * p {
              font-size:22px;
          }
      #galeria img{
          vertical-align: top;
	        width: 300px;
	        height: 300px;
	        margin: 20px;
	        opacity: 0.6;
	        border: 1px solid #484848;
      }

      #galeria img:hover{
          border: 1px solid#fff;
	      opacity: 1;
          width: 325px;
	      height: 325px;
      }

      #punto:hover{
          border-color:black;
      }
      #punto1:hover{
          border-color:black;
      }
      #punto2:hover{
          border-color:black;
      }
      #punto3:hover{
          border-color:black;
      }
      #punto4:hover{
          border-color:black;
      }
      #punto5:hover{
          border-color:black;
      }

      #princi img{
          width:auto;
          height:400px;
      }
      #princi img:hover {
          border-color:black;
          border:solid 9px;
      }
      #mision{
          transition:all .6s ease;
      }
      #mision:hover{
          background: #cc1919;
          color:white;
	      width:350px;
	      transform: rotate(360deg);
      }#mision1{
          transition:all .6s ease;
      }
      #mision1:hover{
          background: black;
          color:white;
	      width:350px;
	      transform: rotate(360deg);
      }#mision2{
          transition:all .6s ease;
      }
      #mision2:hover{
          background: #cc1919;
          color:white;
	      width:350px;
	      transform: rotate(360deg);
      }



        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header>
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
          <div class="carousel-inner" role="listbox">
            <!-- Slide One - Set the background image for this slide in the line below -->
            <div class="carousel-item active" style="background-image: url('../ima/radia.jpeg')">
              <div class="carousel-caption d-none d-md-block">
              </div>
            </div>
            <!-- Slide Two - Set the background image for this slide in the line below -->
              <div class="carousel-item" style="background-image: url('../ima/coches.png')">
              <div class="carousel-caption d-none d-md-block">
                   <h2 class="text-dark"> <strong>Disponibilidad En Muchas Marcas</strong></h2>
              </div>
            </div>
            <!-- Slide Three - Set the background image for this slide in the line below -->
            <div class="carousel-item" style="background-image: url('../ima/bandas.jpeg')">
              <div class="carousel-caption d-none d-md-block">
              </div>
            </div>
          </div>
          <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>
      </header>
      <!-- Page Content -->
      <div class="container">
        <h1 class="my-4 text-capitalize" ><strong>Bienvenido a HC cauchos</strong></h1>
          <hr />
          <!-- Features Section -->
          <br />
        <div class="row">
          <div class="col-lg-6">
            <h2 class="text-danger"><strong>¿Quienes Somos?</strong></h2>
            <p><strong>HC CAUCHOS</strong> es una empresa encargada de comercializacion de productos(cauchos) destinados al mantenimiento 
                de automiviles, maquinaria o multiples fines. <br /> <br />
                en nuestro productos puede encontrar:
            </p>
            <ul>
              <li>Soportes para motor y caja</li>
              <li>Mangueras</li>
              <li>Bujes</li>
              <li>Empaques</li>
              <li>Tapete</li>
              <li>correas</li>
              <li>topes</li>
            </ul>
          </div>
          <div id="princi" class="col-lg-6">
            <img class="img-fluid rounded" src="../ima/local.png" alt="">
          </div>
        </div>
        <!-- /.row -->
          <hr />
        <!-- Marketing Icons Section -->
          <br />
        <div class="row">
          <div class="col-lg-4 mb-4">
            <div id="mision" class="card h-100 ">
              <h4  class="card-header bg-dark text-danger"><strong>MISION</strong></h4>
              <div class="card-body">
                <p class="card-text"><asp:Label ID="LB_mision" runat="server" Text="Label"></asp:Label></p>
              </div>
              <div class="card-footer bg-dark">
              </div>
            </div>
          </div>
          <div class="col-lg-4 mb-4">
            <div id="mision1" class="card h-100">
              <h4 class="card-header bg-danger"><strong>VISION</strong></h4>
              <div class="card-body">
                <p class="card-text"><asp:Label ID="LB_vision" runat="server" Text="Label"></asp:Label></p>
              </div>
              <div class="card-footer bg-danger">
              </div>
            </div>
          </div>
          <div class="col-lg-4 mb-4">
            <div id="mision2" class="card h-100">
              <h4 class="card-header bg-dark text-danger"><strong>OBJETIVOS</strong></h4>
              <div class="card-body">
                <p class="card-text"><asp:Label ID="LB_objetivo" runat="server" Text="Label"></asp:Label></p>
              </div>
              <div class="card-footer bg-dark">
              </div>
            </div>
          </div>
        </div>
        <!-- /.row -->
          <hr />
        <!-- Portfolio Section -->
          <br />
        <h2 class="text-danger"><strong>Algunos Productos</strong></h2>
        <div id="galeria" class="row">
          <div  class="col-lg-4 col-sm-6 portfolio-item">
            <div id="punto"  class="card h-100">
              <img class="card-img-top" src="../ima/2.jpg" alt=""/>
              <div class="card-body">
                <h3 class="card-title text-dark">
                  Empaque Para Puerta
                </h3>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div id="punto1" class="card h-100">
              <img class="card-img-top" src="../ima/3.jpg" alt=""/>
              <div class="card-body">
                <h3 class="card-title text-dark">
                 Fundas Para Barra
                </h3>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div id="punto2" class="card h-100">
              <img class="card-img-top" src="../ima/mangue.jpg" alt=""/>
              <div class="card-body">
                <h3 class="card-title text-dark">
                  Manguera De Radiador
                </h3>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
            <div class="col-lg-4 col-sm-6 portfolio-item">
            <div id="punto3" class="card h-100">
              <img class="card-img-top" src="../ima/manguera.jpg" alt=""/>
              <div class="card-body">
                <h3 class="card-title text-dark">
                  Empaque de puerta
                </h3>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div id="punto4" class="card h-100">
              <img class="card-img-top" src="../ima/soporte5.jpg" alt=""/>
              <div class="card-body">
                <h3 class="card-title text-dark">
                  Soporte de motor
                </h3>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div id="punto5" class="card h-100">
              <img class="card-img-top" src="../ima/bandas.jpg" alt=""/>
              <div class="card-body">
                <h3 class="card-title text-dark" >
                  Manguera de presion
                </h3>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
        </div>
        <!-- /.row -->
        <hr/>
        <!-- Call to Action Section -->
        <div class="row mb-4">
          <div class="col-md-8">
              <h2>¿DESEAS VER MAS PRODUCTOS Y DETALLES?</h2>
          </div>
          <div class="col-md-4">
            <a class="btn btn-lg btn-secondary btn-block text-danger" href="catalogo.aspx"><strong>Catalogo</strong></a>
          </div>
        </div>

      </div>
      <!-- /.container -->

</asp:Content>

