using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ClinicalBookingSystem.Client.Pages;
public partial class Profile
{
    [Inject]
    public NavigationManager Navigation { get; set; }

    private async Task LogoutAsync()
    {
        await JSRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
        Navigation.NavigateTo("/login");
    }
}
