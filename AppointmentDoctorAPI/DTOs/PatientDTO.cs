using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppointmentDoctorAPI.DTOs
{
    public class PatientDTO
    {
        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z1-9]+@gmail\.com$")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateOnly DateOfBirth { get; set; }

    }
}
