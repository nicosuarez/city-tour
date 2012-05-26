<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="homeHead" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?key=AIzaSyB8R77stdNg_eXQLpwKEI1_uFyu8tLW2Sw&sensor=true"></script>
</asp:Content>

<asp:Content ID="homeContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="homeTabs">
	    <ul>
		    <li><a href="#nearLocationsTab"><%: TextStrings.NearLocations%></a></li>
		    <li><a href="#myReservationsTab"><%: TextStrings.MyReservations%></a></li>
		    <li><a href="#myItineraryTab"><%: TextStrings.MyItinerary%></a></li>
	    </ul>
	    <div id="nearLocationsTab">
            <div class="mapCanvas"></div>
	    </div>
	    <div id="myReservationsTab">
		    <p>Morbi tincidunt, dui sit amet facilisis feugiat, odio metus gravida ante, ut pharetra massa metus id nunc. Duis scelerisque molestie turpis. Sed fringilla, massa eget luctus malesuada, metus eros molestie lectus, ut tempus eros massa ut dolor. Aenean aliquet fringilla sem. Suspendisse sed ligula in ligula suscipit aliquam. Praesent in eros vestibulum mi adipiscing adipiscing. Morbi facilisis. Curabitur ornare consequat nunc. Aenean vel metus. Ut posuere viverra nulla. Aliquam erat volutpat. Pellentesque convallis. Maecenas feugiat, tellus pellentesque pretium posuere, felis lorem euismod felis, eu ornare leo nisi vel felis. Mauris consectetur tortor et purus.</p>
	    </div>
	    <div id="myItineraryTab">
            <div class="mapCanvas">
		         <% @Html.RenderPartial("_Events", ViewData["Events"]); %>
            </div>
	    </div>
    </div>
</asp:Content>
