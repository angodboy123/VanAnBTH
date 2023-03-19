using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTH1303.Models;

namespace BTH1303.Controllers;

public class PTB2Controller : Controller
{
    PTB2 gpt = new PTB2();
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(string hesoA, string hesoB, string hesoC)
    {
        string ketqua = "";
        ketqua = gpt.Giaiphuongtrinh(hesoA,hesoB,hesoC);           
        ViewBag.mess = ketqua;
        return View();
    }
}