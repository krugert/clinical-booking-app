using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;

namespace ClinicalBookingSystem.Client.Layout;

public partial class MainLayout
{
    [Inject] IJSRuntime JSRuntime { get; set; }
    [Inject] NavigationManager Navigation { get; set; }

    private bool isAuthenticated = false;
    private string username = "";

    protected override async Task OnInitializedAsync()
    {
        await CheckAuthenticationAsync();
    }

    private async Task CheckAuthenticationAsync()
    {
        string? token = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (string.IsNullOrEmpty(token))
        {
            isAuthenticated = false;
            username = "";
            return;
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var nameClaim = jwt.Claims.FirstOrDefault(c =>
                c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
            );

            username = nameClaim?.Value ?? "";

            isAuthenticated = true;
        }
        catch
        {
            // Token invalid or corrupted
            isAuthenticated = false;
            username = "";
        }
    }

    private async Task LogoutAsync()
    {
        await JSRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
        isAuthenticated = false;
        username = "";
        Navigation.NavigateTo("/login", true);
    }
}