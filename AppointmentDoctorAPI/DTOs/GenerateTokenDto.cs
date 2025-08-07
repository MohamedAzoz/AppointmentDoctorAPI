namespace AppointmentDoctorAPI.DTOs
{
    public class GenerateTokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
