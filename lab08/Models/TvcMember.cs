using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab08.Models;

public class TvcMember
{
    public string TvcMemberId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
    [DisplayName("Tên đăng nhập")]
    public string TvcUserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [DisplayName("Mật khẩu")]
    public string TvcPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập họ tên")]
    [DisplayName("Họ và tên")]
    public string TvcFullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [DisplayName("Email")]
    public string TvcEmail { get; set; } = string.Empty;
}
