using ClinicalBookingSystem.Infrastructure.Models.Domain;
using ClinicalBookingSystem.Infrastructure.Models.DTOs;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;

namespace ClinicalBookingSystem.Client.Pages;
public partial class CreateBooking
{
    private MudForm form = new();
    private BookingDto model = new();
    private List<ClinicDto> clinicModel = new();
    private List<Clinic> clinics = new();
    private List<TimeSpan> TimeSlots = new();
    private bool success;

    private DateTime? _date = DateTime.Today;

    protected override async Task OnInitializedAsync()
    {
        clinics = await Http.GetFromJsonAsync<List<Clinic>>("api/Clinic/get-clinics")
                       ?? new List<Clinic>();

        var start = new TimeSpan(9, 0, 0);
        var end = new TimeSpan(17, 0, 0);
        var interval = TimeSpan.FromMinutes(30);

        for (var time = start; time <= end; time = time.Add(interval))
        {
            TimeSlots.Add(time);
        }
    }

    private void SelectTime(TimeSpan time)
    {
        // Handle selection, e.g., bind to a model
        Console.WriteLine($"Selected: {time}");
    }

    private async Task CreateBookingAsync(IJSRuntime js)
    {
    }
}
