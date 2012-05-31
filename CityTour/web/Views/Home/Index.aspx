<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="homeHead" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?key=AIzaSyB8R77stdNg_eXQLpwKEI1_uFyu8tLW2Sw&sensor=true"></script>
</asp:Content>

<asp:Content ID="homeContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="DropDownType" data-role="fieldcontain">
	    <label for="select-choice-1" class="select">Rubro:</label>
	    <select name="select-choice-1" id="select-choice-1">
		    <option value="standard">Todos</option>
		    <option value="rush">Restaurants</option>
		    <option value="express">Bar</option>
		    <option value="overnight">Museos</option>
            <option value="overnight">Cines</option>
	    </select>
    </div>
    <div >
	    <div id="nearLocationsTab" class="map">
            <div id="map" class="mapCanvas"></div>
	    </div>


	    <div id="myReservationsTab">
		    <br/><br/><br/>
	    </div>
	    <div id="myItineraryTab">
            <div class="mapCanvas">
		         <% Html.RenderPartial("_Events", ViewData["Events"]); %>
            </div>

	    </div>
    </div>
</asp:Content>
