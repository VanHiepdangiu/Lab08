using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab08.Models;

public class TvcStudent
{
    public int Id { get; set; }

    [Required(ErrorMessage="Vui lòng nhập mã sinh viên")]
    [DisplayName("Mã sinh viên")]
    public string StudentCode { get; set; } = string.Empty;

    [Required(ErrorMessage="Vui lòng nhập họ và tên")]
    [DisplayName("Họ và tên")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage="Vui lòng nhập lớp")]
    [DisplayName("Lớp")]
    public string ClassName { get; set; } = string.Empty;

    [Required(ErrorMessage="Vui lòng nhập email")]
    [EmailAddress(ErrorMessage="Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage="Số điện thoại không hợp lệ")]
    [DisplayName("Số điện thoại")]
    public string Phone { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [DisplayName("Ngày sinh")]
    public DateTime DateOfBirth { get; set; } = DateTime.Today;
}
