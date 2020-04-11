<%@ Page Title="" Language="C#" MasterPageFile="~/Views/principal.master" AutoEventWireup="true" CodeFile="~/Controllers/home.aspx.cs" Inherits="Views_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
      
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
          <div class="col-lg-6">
            <img class="img-fluid rounded" src="../ima/local.png" alt="">
          </div>
        </div>
        <!-- /.row -->
          <hr />
        <!-- Marketing Icons Section -->
          <br />
        <div class="row">
          <div class="col-lg-4 mb-4">
            <div class="card h-100 ">
              <h4 class="card-header bg-dark text-danger"><strong>MISION</strong></h4>
              <div class="card-body">
                <p class="card-text">Somos una empresa dedicada a consolidar, preservar y acrecentar la <strong>confianza</strong>
                    que nuestros clientes depositan en nosotros brindando soluciones integrales mediante la produccion y comercializacion 
                    de productos en caucho y plastico.</p>
              </div>
              <div class="card-footer bg-dark">
              </div>
            </div>
          </div>
          <div class="col-lg-4 mb-4">
            <div class="card h-100">
              <h4 class="card-header bg-danger"><strong>VISION</strong></h4>
              <div class="card-body">
                <p class="card-text">Tener un crecimiento continuo basado en objetivos, ser una empresa referente en productos de plastico y caucho,
                    expandir nuestro servicio a nivel nacional y lograr estar constituidos como una empresa fiel y correcta.
                </p>
              </div>
              <div class="card-footer bg-danger">
              </div>
            </div>
          </div>
          <div class="col-lg-4 mb-4">
            <div class="card h-100">
              <h4 class="card-header bg-dark text-danger"><strong>OBJETIVOS</strong></h4>
              <div class="card-body">
                <p class="card-text">Nuestro objetivo es entregar productos con los estandares mas altos de calidad para
                    encontrar la satisfaccion total en nuestro clientes de recibir un producto 100% confiable y asi mismo 
                    obtener reconocimiento por merito propio
                </p>
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
        <div class="row">
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div class="card h-100">
              <a ><img class="card-img-top" src="../ima/2.jpg" alt=""/></a>
              <div class="card-body">
                <h4 class="card-title">
                  <a class="text-dark">Empaque Para Puerta</a>
                </h4>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div class="card h-100">
              <a ><img class="card-img-top" src="../ima/3.jpg" alt=""/></a>
              <div class="card-body">
                <h4 class="card-title">
                  <a class="text-dark">Fundas Para Barra</a>
                </h4>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div class="card h-100">
              <a ><img class="card-img-top" src="../ima/mangue.jpg" alt=""/></a>
              <div class="card-body">
                <h4 class="card-title">
                  <a class="text-dark">Manguera De Radiador</a>
                </h4>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
            <div class="col-lg-4 col-sm-6 portfolio-item">
            <div class="card h-100">
              <a href="#"><img class="card-img-top" src="../ima/manguera.jpg" alt=""/></a>
              <div class="card-body">
                <h4 class="card-title">
                  <a class="text-dark">Empaque de puerta
                  </a>
                </h4>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div class="card h-100">
              <a><img class="card-img-top" src="../ima/soporte5.jpg" alt=""/></a>
              <div class="card-body">
                <h4 class="card-title">
                  <a class="text-dark">Soporte de motor</a>
                </h4>
                <p class="card-text"></p>
              </div>
            </div>
          </div>
          <div class="col-lg-4 col-sm-6 portfolio-item">
            <div class="card h-100">
              <a ><img class="card-img-top" src="../ima/bandas.jpg" alt=""/></a>
              <div class="card-body">
                <h4 class="card-title">
                  <a class="text-dark">Manguera de presion</a>
                </h4>
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

