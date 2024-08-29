using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Locacoes.Data;
using Locacoes.Models;
using System.Linq;
using System.Threading.Tasks;

public class AutoresController : Controller
{
    private readonly LivrariaContext _context;

    public AutoresController(LivrariaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.autores.ToListAsync());
    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var autor = await _context.autores
            .FirstOrDefaultAsync(m => m.Id == id);
        if (autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Autor autor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(autor);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var autor = await _context.autores.FindAsync(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao")] Autor autor)
    {
        if (id != autor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(autor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(autor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(autor);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var autor = await _context.autores
            .FirstOrDefaultAsync(m => m.Id == id);
        if (autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var autor = await _context.autores.FindAsync(id);
        _context.autores.Remove(autor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AutorExists(int id)
    {
        return _context.autores.Any(e => e.Id == id);
    }
}
