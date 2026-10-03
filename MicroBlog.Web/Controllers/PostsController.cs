
using MicroBlog.Core;
using MicroBlog.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Post = MicroBlog.Core.Post;

public class PostsController : Controller
{
    private readonly MicroBlogContext _context;

    public PostsController(MicroBlogContext context)
    {
        _context = context;
    }

    // GET: POSTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Post.ToListAsync());
    }

    // GET: POSTS/Details/5
    public async Task<IActionResult> Details(System.Guid? postid)
    {
        if (postid == null)
        {
            return NotFound();
        }

        var post = await _context.Post
            .FirstOrDefaultAsync(m => m.PostId == postid);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    // GET: POSTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: POSTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PostId,Author,Body")] Post post)
    {
        if (ModelState.IsValid)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    // GET: POSTS/Edit/5
    public async Task<IActionResult> Edit(System.Guid? postid)
    {
        if (postid == null)
        {
            return NotFound();
        }

        var post = await _context.Post.FindAsync(postid);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // POST: POSTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(System.Guid? postid, [Bind("PostId,Author,Body")] Post post)
    {
        if (postid != post.PostId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(post.PostId))
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
        return View(post);
    }

    // GET: POSTS/Delete/5
    public async Task<IActionResult> Delete(System.Guid? postid)
    {
        if (postid == null)
        {
            return NotFound();
        }

        var post = await _context.Post
            .FirstOrDefaultAsync(m => m.PostId == postid);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    // POST: POSTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(System.Guid? postid)
    {
        var post = await _context.Post.FindAsync(postid);
        if (post != null)
        {
            _context.Post.Remove(post);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PostExists(System.Guid? postid)
    {
        return _context.Post.Any(e => e.PostId == postid);
    }
}
