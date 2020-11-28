namespace TimeBox.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using TimeBox.Data.Models;

    public class QuotesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await dbContext.Quotes.AddAsync(new Quote
            {
                QuoteText = "Най-добрият начин да проектираме бъдещето е да живеем правилно настоящето.",
                QuoteAuthor = "Хорхе Ливрага",
            });

            await dbContext.Quotes.AddAsync(new Quote
            {
                QuoteText = "Всеки ден трябва да слушаш поне една песен, да погледнеш една хубава картина и ако е възможно, да прочетеш едно мъдро изречение.",
                QuoteAuthor = "Йохан Волфганг Гьоте",
            });

            await dbContext.Quotes.AddAsync(new Quote
            {
                QuoteText = "Глупаво е да правиш планове за цял живот, когато не си господар дори на утрешния ден.",
                QuoteAuthor = "Луций Аней Сенека",
            });

            await dbContext.Quotes.AddAsync(new Quote
            {
                QuoteText = "Времето е най-скъпото нещо, което пилеем.",
                QuoteAuthor = "Диоген Лаертски",
            });

            await dbContext.Quotes.AddAsync(new Quote
            {
                QuoteText = "Отлагането е крадец на време.",
                QuoteAuthor = "Китайска мъдрост",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
