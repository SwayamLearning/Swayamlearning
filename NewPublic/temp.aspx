<%@ Page Language="C#" AutoEventWireup="true" CodeFile="temp.aspx.cs" Inherits="NewPublic_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <header class="banner">
        <nav class="navbar navbar-default  fixed-top" role="navigation">
            <div class="brand-centered">
                <a class="navbar-brand" href="#">
                    <img style="margin-right: 10px; padding: 0;" src="img/logo2.png" width="150" alt="Swayam Learning">
                </a>
            </div>
             <div id="navbar9" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav ">
                            <%-- //<a class="navbar-brand" href="#pablo">Dashboard</a>--%>
                          <%--  <h5 id="H1" style="font-weight: bold; color: #17252A; margin-right: 25px;"><%: board %> &nbsp;&nbsp;&nbsp;<%: medium %>&nbsp;medium&nbsp;&nbsp;&nbsp; <%: standard %>&nbsp;&nbsp;&nbsp; <span id="Span1"></span></h5>--%>
                       </ul>
                     <ul class="nav navbar-nav navbar-right">
                         <li class="hidden-xs" ><button type="button" class="btn btn-primary-outine-donate" data-toggle="modal" data-target="#myModal" id="btndonate"> Donate</button></li>
                     </ul>

                     <ul class="nav navbar-nav navbar-right">
                          <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation" style="position: absolute; right: 5px; top:15px;">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="navbar-toggler-icon icon-bar"></span>
                            <span class="navbar-toggler-icon icon-bar"></span>
                            <span class="navbar-toggler-icon icon-bar"></span>
                        </button>
                        
                        <div class="collapse navbar-collapse" id="Div1">

                            <style>
                                a.dropdown-item.waves-effect.waves-light:hover
                                {
                                    color: white !important;
                                }
                            </style>
                            <ul class="navbar-nav ml-auto nav-flex-icons">

                                <li class="nav-item dropdown">
                                    <a class="nav-link dropdown-toggle waves-effect waves-light" id="A1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                        <i class="fa fa-user"></i>
                                        <span style="text-transform: none !important; color: #3333ff!important; font-size:1.2em; font-weight: bold">
                                            <%: AppSessions.UserName %>
                                        </span>
                                    </a>

                                    <div class="dropdown-menu dropdown-menu-right dropdown-default" aria-labelledby="navbarDropdownMenuLink">
                                        <a class="dropdown-item waves-effect waves-light" href="../UserManagement/UpdateProfileStudent.aspx">Account</a>
                                         <a class="dropdown-item waves-effect waves-light" href="#">Forum</a>
                                        <a class="dropdown-item waves-effect waves-light" href="../UserManagement/Support.aspx">Support</a>
                                        <a class="dropdown-item waves-effect waves-light" href="../NewPublic/UserLogin.aspx?logout=request">Logout</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                     </ul>
</div>
        </nav>
    </header>
    </div>









    <style type="text/css">
        .dropup, .dropdown
        {
            position: relative;
        }
        .dropdown-toggle::after
        {
            display: inline-block;
            width: 0;
            height: 0;
            margin-left: 0.255em;
            vertical-align: 0.255em;
            content: "";
            border-top: 0.3em solid;
            border-right: 0.3em solid transparent;
            border-bottom: 0;
            border-left: 0.3em solid transparent;
        }
        .dropdown-toggle:empty::after
        {
            margin-left: 0;
        }
        .dropdown-menu
        {
            position: absolute;
            top: 100%;
            left: 0;
            z-index: 1000;
            display: none;
            float: left;
            min-width: 10rem;
            padding: 0.5rem 0;
            margin: 0.125rem 0 0;
            font-size: 1rem;
            color: #212529;
            text-align: left;
            list-style: none;
            background-color: #ffffff;
            background-clip: padding-box;
            border: 1px solid rgba(0, 0, 0, 0.15);
            border-radius: 0.25rem;
            box-shadow: 0 2px 2px 0 rgba(0, 0, 0, 0.14), 0 3px 1px -2px rgba(0, 0, 0, 0.2), 0 1px 5px 0 rgba(0, 0, 0, 0.12);
        }
        .dropup .dropdown-menu
        {
            margin-top: 0;
            margin-bottom: 0.125rem;
        }
        .dropup .dropdown-toggle::after
        {
            display: inline-block;
            width: 0;
            height: 0;
            margin-left: 0.255em;
            vertical-align: 0.255em;
            content: "";
            border-top: 0;
            border-right: 0.3em solid transparent;
            border-bottom: 0.3em solid;
            border-left: 0.3em solid transparent;
        }
        .dropup .dropdown-toggle:empty::after
        {
            margin-left: 0;
        }
        .dropright .dropdown-menu
        {
            margin-top: 0;
            margin-left: 0.125rem;
        }
        .dropright .dropdown-toggle::after
        {
            display: inline-block;
            width: 0;
            height: 0;
            margin-left: 0.255em;
            vertical-align: 0.255em;
            content: "";
            border-top: 0.3em solid transparent;
            border-bottom: 0.3em solid transparent;
            border-left: 0.3em solid;
        }
        .dropright .dropdown-toggle:empty::after
        {
            margin-left: 0;
        }
        .dropright .dropdown-toggle::after
        {
            vertical-align: 0;
        }
        .dropleft .dropdown-menu
        {
            margin-top: 0;
            margin-right: 0.125rem;
        }
        .dropleft .dropdown-toggle::after
        {
            display: inline-block;
            width: 0;
            height: 0;
            margin-left: 0.255em;
            vertical-align: 0.255em;
            content: "";
        }
        .dropleft .dropdown-toggle::after
        {
            display: none;
        }
        .dropleft .dropdown-toggle::before
        {
            display: inline-block;
            width: 0;
            height: 0;
            margin-right: 0.255em;
            vertical-align: 0.255em;
            content: "";
            border-top: 0.3em solid transparent;
            border-right: 0.3em solid;
            border-bottom: 0.3em solid transparent;
        }
        .dropleft .dropdown-toggle:empty::after
        {
            margin-left: 0;
        }
        .dropleft .dropdown-toggle::before
        {
            vertical-align: 0;
        }
        .dropdown-divider
        {
            height: 0;
            margin: 0.5rem 0;
            overflow: hidden;
            border-top: 1px solid #e9ecef;
        }
        .dropdown-item
        {
            display: block;
            width: 100%;
            padding: 0.625rem 1.25rem;
            clear: both;
            font-weight: 400;
            color: #212529;
            text-align: inherit;
            white-space: nowrap;
            background-color: transparent;
            border: 0;
        }
        .dropdown-item:hover, .dropdown-item:focus
        {
            /*color: #16181b;*/
            text-decoration: none;
            background-color: #f8f9fa;
            background-color: #17252a !important;
            color: white !important;
        }
        .dropdown-item.active, .dropdown-item:active
        {
            color: #ffffff;
            text-decoration: none;
            background-color: #2196f3;
        }
        .dropdown-item.disabled, .dropdown-item:disabled
        {
            color: #6c757d;
            background-color: transparent;
        }
        .dropdown-menu.show
        {
            display: block;
        }
        .dropdown-header
        {
            display: block;
            padding: 0.5rem 1.25rem;
            margin-bottom: 0;
            font-size: 0.875rem;
            color: #6c757d;
            white-space: nowrap;
        }
    </style>






    </form>
</body>
</html>
