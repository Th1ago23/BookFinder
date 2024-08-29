using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Locacoes.Data;
using Locacoes.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

public class LivroController : Controller
{
    private readonly LivrariaContext _context;

    public LivroController(LivrariaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var livros = _context.livros.Include(l => l.categoria);
        return View(await livros.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.livros
            .Include(l => l.categoria)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }
 
    public IActionResult Create()
    {
        ViewData["CategoriaId"] = new SelectList(_context.categorias, "Id", "Name");
        return View();
    }

    // POST: Livros/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,Ano,CategoriaId")] Livro livro)
    {
        if (ModelState.IsValid)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoriaId"] = new SelectList(_context.categorias, "Id", "Nome", livro.CategoriaId);
        return View(livro);
    }

    // Metodo para pegar as informações para editar
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.livros.FindAsync(id);
        if (livro == null)
        {
            return NotFound();
        }
        ViewData["CategoriaId"] = new SelectList(_context.categorias, "Id", "Nome", livro.CategoriaId);
        return View(livro);
    }

    // Metodo Post - Atualiza os dados
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Ano,CategoriaId")] Livro livro)
    {
        if (id != livro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(livro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(livro.Id))
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
        ViewData["CategoriaId"] = new SelectList(_context.categorias, "Id", "Nome", livro.CategoriaId);
        return View(livro);
    }

    // metodo deletar
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var livro = await _context.livros
            .Include(l => l.categoria)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }

    // deletar
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var livro = await _context.livros.FindAsync(id);
        _context.livros.Remove(livro);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool LivroExists(int id)
    {
        return _context.livros.Any(e => e.Id == id);
    }
}
