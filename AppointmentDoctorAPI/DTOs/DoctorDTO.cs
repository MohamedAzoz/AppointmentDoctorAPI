using System.ComponentModel.DataAnnotations;

namespace AppointmentDoctorAPI.DTOs
{
    public class DoctorDTO
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
        public string Specialization { get; set; }
        public string ClinicAddress { get; set; }
        public string? ImgURL { get; set; }
    }
}
