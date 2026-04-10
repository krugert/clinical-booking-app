using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;

namespace ClinicalBookingSystem.Client.Pages;

public partial class Bookings
{
    private void CreateBooking()
    {
        Navigation.NavigateTo("/create-booking");
    }
}