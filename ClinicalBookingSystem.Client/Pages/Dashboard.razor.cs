using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClinicalBookingSystem.Client.Pages;
public partial class Dashboard
{
    private void Booking()
    {
        Navigation.NavigateTo("/bookings");
    }
}
