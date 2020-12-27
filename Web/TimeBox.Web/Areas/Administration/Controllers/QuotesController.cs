namespace TimeBox.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TimeBox.Data;
    using TimeBox.Data.Common.Repositories;
    using TimeBox.Data.Models;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class QuotesController : Controller
    {
        private readonly IDeletableEntityRepository<Quote> repository;

        public QuotesController(IDeletableEntityRepository<Quote> repository)
        {
            this.repository = repository;
        }

        // GET: Administration/Quotes
        public async Task<IActionResult> Index()
        {
            return this.View(await this.repository.All().ToListAsync());
        }

        // GET: Administration/Quotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var quote = await this.repository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return this.NotFound();
            }

            return this.View(quote);
        }

        // GET: Administration/Quotes/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuoteText,QuoteAuthor,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Quote quote)
        {
            if (this.ModelState.IsValid)
            {
                await this.repository.AddAsync(quote);
                await this.repository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(quote);
        }

        // GET: Administration/Quotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var quote = await this.repository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (quote == null)
            {
                return this.NotFound();
            }

            return this.View(quote);
        }

        // POST: Administration/Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuoteText,QuoteAuthor,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Quote quote)
        {
            if (id != quote.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.repository.Update(quote);
                    await this.repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.QuoteExists(quote.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(quote);
        }

        // GET: Administration/Quotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var quote = await this.repository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return this.NotFound();
            }

            return this.View(quote);
        }

        // POST: Administration/Quotes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quote = await this.repository.All().FirstOrDefaultAsync(x => x.Id == id);
            this.repository.Delete(quote);
            await this.repository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool QuoteExists(int id)
        {
            return this.repository.All().Any(e => e.Id == id);
        }
    }
}
