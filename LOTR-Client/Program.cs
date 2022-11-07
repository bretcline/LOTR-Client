using LOTRSdk;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("LOTR");

        var accessToken = "P1NeQSJ4lMiuXJyN_5_t";

        //var books = new Books();
        //var allbooks = books.GetAll();

        //foreach( var book in allbooks)
        //{
        //    Console.WriteLine( book.Name );
        //}

        //var movies = new Movies(accessToken);
        //var allmovies = movies.GetAll();

        //foreach (var movie in allmovies)
        //{
        //    Console.WriteLine(movie.Name);
        //}
        //var firstMovie = movies.GetByID(allmovies[2].Id);
        //Console.WriteLine(firstMovie.Name);
        //Console.WriteLine(firstMovie.AcademyAwardNominations);

        //movies.Filter = new Filters { Property = "character", Values = "5cd99d4bde30eff6ebccfbe6" };
        //movies.Sorting = new Sorting { Descending = true, Property = "name" };
        //movies.Pagination = new Pagination { Limit = 10, Page = 3 };

        //var quotes = movies.GetQuoteByMovie(allmovies[6].Id);
        //foreach( var quote in quotes)
        //    Console.WriteLine($"{quote.Character} - {quote.Dialog}");



        var quotes = new Quotes( accessToken);

        quotes.GetByID( "test" );

        quotes.Filter = new Filters { Property = "character", Values = "5cd99d4bde30eff6ebccfbe6" };
        var quoteList = quotes.GetAll();
        foreach (var quote in quoteList)
            Console.WriteLine($"{quote.Character} - {quote.Dialog}");


        var characters = new Characters(accessToken);
        characters.Filter = new Filters { Property = "name", Values = "Gandalf", Exclude = true};
        characters.Sorting = new Sorting { Descending = true, Property = "name" };
        characters.Pagination = new Pagination { Limit = 10, Page = 3 };
        var characterList = characters.GetAll();
        foreach( var person in characterList )
            Console.WriteLine(person.Name );
    }
}