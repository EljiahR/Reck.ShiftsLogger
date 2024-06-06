using ShiftsLoggerUI.Models;
using System.Configuration;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ShiftsLoggerUI;

internal class APICalls
{
    private static JsonSerializerOptions caseInsensitive = new() { PropertyNameCaseInsensitive = true };

    private static HttpClient client = new HttpClient()
    {
        BaseAddress = new Uri(ConfigurationManager.ConnectionStrings["Base"].ConnectionString)
    };
    public static async Task<List<ShiftLog>> GetShiftsAsync()
    {
        List<ShiftLog> shifts = new();
        HttpResponseMessage response = await client.GetAsync("api/ShiftLogs/");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            shifts = JsonSerializer.Deserialize<List<ShiftLog>>(json, caseInsensitive);
        }
        return shifts;
    }

    public static async Task<Uri> PostShiftAsync(ShiftLog shift)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/",shift);
        response.EnsureSuccessStatusCode();

        return response.Headers.Location;
    }

}
