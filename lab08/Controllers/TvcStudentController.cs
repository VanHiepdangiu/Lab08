using Microsoft.AspNetCore.Mvc;
using lab08.Models;

namespace lab08.Controllers;

public class TvcStudentController : Controller
{
    private static readonly List<TvcStudent> _students = new()
    {
        new() { Id=1, StudentCode="2410900035", FullName="Nguyễn Văn Hiệp", ClassName="K24CNT1", Email="hiep2410900035@gmail.com", Phone="0988089376", DateOfBirth=new DateTime(2006,9,27) }
    };

    [HttpGet("/TvcStudent")]
    public IActionResult Index() => View(_students);

    [HttpGet]
    public IActionResult Create() => View(new TvcStudent());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TvcStudent student)
    {
        if (_students.Any(x => x.StudentCode.Equals(student.StudentCode, StringComparison.OrdinalIgnoreCase)))
            ModelState.AddModelError(nameof(student.StudentCode), "Mã sinh viên đã tồn tại");
        if (!ModelState.IsValid) return View(student);
        student.Id = _students.Count == 0 ? 1 : _students.Max(x => x.Id) + 1;
        _students.Add(student);
        TempData["Message"] = "Thêm mới sinh viên thành công";
        return RedirectToAction(nameof(Index));
    }
}
