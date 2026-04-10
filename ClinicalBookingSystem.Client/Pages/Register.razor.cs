using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using MudBlazor;
using System.Net.Http.Json;

namespace ClinicalBookingSystem.Client.Pages;
public partial class Register
{
    private MudForm form = new();
    private UserDto model = new();
    private bool success;

    private async Task RegisterAsync()
    {
        try
        {
            var response = await Http.PostAsJsonAsync("api/Auth/register", model);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                Snackbar.Add("Registration successful!", Severity.Success);
                Navigation.NavigateTo("/login");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Snackbar.Add(error ?? "Registration failed", Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error: {ex.Message}", Severity.Error);
        }
    }
}
