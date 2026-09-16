using Microsoft.AspNetCore.Mvc;
using lab08.Models;

namespace lab08.Controllers;

public class TvcMemberController : Controller
{
    private static readonly List<TvcMember> _members = new()
    {
        new() { TvcMemberId=Guid.NewGuid().ToString(), TvcUserName="nguyenvanhiep", TvcPassword="123456", TvcFullName="Nguyễn Văn Hiệp - 2410900035", TvcEmail="hiep2410900035@gmail.com" },
        new() { TvcMemberId=Guid.NewGuid().ToString(), TvcUserName="tranthib", TvcPassword="SecurePass456#", TvcFullName="Trần Thị B", TvcEmail="tranthib@outlook.com" },
        new() { TvcMemberId=Guid.NewGuid().ToString(), TvcUserName="levanc", TvcPassword="MyPassword789$", TvcFullName="Lê Văn C", TvcEmail="levanc@company.com" }
    };

    [HttpGet("/TvcMember")]
    public IActionResult Index() => View(_members);

    [HttpGet]
    public IActionResult TvcCreate() => View(new TvcMember());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TvcCreate(TvcMember tvcMember)
    {
        if (!ModelState.IsValid) return View(tvcMember);
        tvcMember.TvcMemberId = Guid.NewGuid().ToString();
        _members.Add(tvcMember);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult TvcEdit(string id)
    {
        var member = _members.FirstOrDefault(x => x.TvcMemberId == id);
        return member == null ? NotFound() : View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TvcEdit(TvcMember tvcMember)
    {
        if (!ModelState.IsValid) return View(tvcMember);
        var member = _members.FirstOrDefault(x => x.TvcMemberId == tvcMember.TvcMemberId);
        if (member == null) return NotFound();
        member.TvcUserName=tvcMember.TvcUserName; member.TvcPassword=tvcMember.TvcPassword;
        member.TvcFullName=tvcMember.TvcFullName; member.TvcEmail=tvcMember.TvcEmail;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult TvcDetails(string id)
    {
        var member = _members.FirstOrDefault(x => x.TvcMemberId == id);
        return member == null ? NotFound() : View(member);
    }

    [HttpGet]
    public IActionResult TvcDelete(string id)
    {
        var member = _members.FirstOrDefault(x => x.TvcMemberId == id);
        return member == null ? NotFound() : View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TvcDeleted(string id)
    {
        var member = _members.FirstOrDefault(x => x.TvcMemberId == id);
        if (member == null) return NotFound();
        _members.Remove(member);
        return RedirectToAction(nameof(Index));
    }
}
