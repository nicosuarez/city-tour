<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="web.Models" %>

<asp:Content ID="homeHead" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%: Url.Content("~/Content/site.css") %>" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?key=AIzaSyB8R77stdNg_eXQLpwKEI1_uFyu8tLW2Sw&sensor=true"></script>
</asp:Content>

<asp:Content ID="homeContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="homeTabs">
	    <ul>
            <li><a href="#scheduledReservationsTab"><%: TextStrings.ScheduledReservations%></a></li>
<%--		    
            <li><a href="#nearLocationsTab"><%: TextStrings.NearLocations%></a></li>
		    <li><a href="#myReservationsTab"><%: TextStrings.MyReservations%></a></li>
		    <li><a href="#myItineraryTab"><%: TextStrings.MyItinerary%></a></li>
            <li><a href="#audioGuidesTab"><%: TextStrings.AudioGuides%></a></li>
--%>	    
        </ul>
        <div id="scheduledReservationsTab">            
		    <% Html.RenderPartial("_ScheduledReservations", ViewData["ScheduledReservations"]); %>            
	    </div>
<%--
	    <div id="nearLocationsTab">
            <div class="map">
                <% Html.RenderPartial("_Map"); %> 
            </div>
	    </div>
	    <div id="myReservationsTab">
		    <p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
	    </div>
	    <div id="myItineraryTab">            
		    <% Html.RenderPartial("_Events", ViewData["Events"]); %>            
	    </div>
        <div id="audioGuidesTab">
            <% Html.RenderPartial("_AudioGuides", ViewData["AudioGuides"]); %>    
        </div>              
--%>    
    </div>
</asp:Content>
