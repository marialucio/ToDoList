using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class ListaController : Controller
{
    private readonly ToDoListContext _context;

    public ListaController(ToDoListContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Listas);
    }

    public IActionResult Show(int id)
    {
        return View(_context.Listas.Find(id));
    }

    public IActionResult CreateList()
    {
        return View();
    }

    public IActionResult Add([FromForm] string title, [FromForm] string description)
    {
        if(title.Length > 50)
        {
            TempData["MessageError"] = "O título deve ter, no máximo, 50 caracteres. Tente novamente :)";
            return RedirectToAction("CreateList");
        }

        if(description.Length > 50 )
        {
            TempData["MessageError"] = "A descrição deve ter, no máximo, 50 caracteres. Tente novamente :)";
            return RedirectToAction("CreateList");
        }

        _context.Listas.Add(new Lista(title, description));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _context.Listas.Remove(_context.Listas.Find(id));
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        return View(_context.Listas.Find(id));
    }

    public IActionResult Save(int id, [FromForm] string title, [FromForm] string description)
    {

        if(title.Length > 50 )
        {
            TempData["MessageError"] = "O título deve ter, no máximo, 50 caracteres. Tente novamente :)";
            return RedirectToAction("Update", new {id = id});
        }

        if(description.Length > 50 )
        {
            TempData["MessageError"] = "A descrição deve ter, no máximo, 50 caracteres. Tente novamente :)";
            return RedirectToAction("Update", new {id = id});
        }
        
        _context.Listas.Find(id).Title = title;
        _context.Listas.Find(id).Description = description;

        _context.Listas.Update(_context.Listas.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Show", new {id = id});
    }
}