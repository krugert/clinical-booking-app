using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;

namespace ClinicalBookingSystem.Client.Pages;
public partial class Login
{
    private MudForm form = new();
    private UserDto model = new();
    private bool success;

    private async Task LoginAsync(IJSRuntime js)
    {
        try
        {
            var response = await Http.PostAsJsonAsync("api/Auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                // Read JSON payload
                var loginResponse = await response.Content.ReadFromJsonAsync<TokenResponseDto>();

                if (loginResponse is null || string.IsNullOrEmpty(loginResponse.AccessToken))
                {
                    Snackbar.Add("Invalid response from server", Severity.Error);
                    return;
                }

                // Store ONLY the token
                await js.InvokeVoidAsync("localStorage.setItem", "authToken", loginResponse.AccessToken);

                Snackbar.Add("Login successful!", Severity.Success);

                Navigation.NavigateTo("/dashboard", true);
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Snackbar.Add(error ?? "Login failed", Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error: {ex.Message}", Severity.Error);
        }
    }
}
