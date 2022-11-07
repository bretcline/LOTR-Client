using LOTRSdk;
using LOTRSdk.Data;
using NUnit.Framework;
using System;

namespace LOTRSdk_Tests
{
    public class Tests
    {
        private string AccessToken { get; set; }

        [SetUp]
        public void Setup()
        {
            AccessToken = "P1NeQSJ4lMiuXJyN_5_t";
        }

        public void TestAll<R,T>( BaseRequest<R,T> manager )
        {
            var all = manager.GetAll();

            if (all.Count > 0)
                Assert.Pass();
            else
                Assert.Fail();
        }

        public void TestSingle<R, T>(BaseRequest<R, T> manager) where T : BaseItem
        {
            var random = new Random();
            var all = manager.GetAll();

            var index = random.Next(all.Count - 1);

            var item = manager.GetByID(all[index].Id);
            if (item != null)
                Assert.Pass();
            else
                Assert.Fail();
        }

        public void TestSingleNotExist<R, T>(BaseRequest<R, T> manager) where T : BaseItem
        {
            try
            {
                var item = manager.GetByID("Random Text");
            }
            catch (DoesNotExistException)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        #region Books
        [Test]
        public void TestAllBooks()
        {
            var manager = new Books();
            TestAll( manager );
        }

        [Test]
        public void TestSingleBook()
        {
            var manager = new Books();
            TestSingle(manager);
        }


        [Test]
        public void TestSingleBookNotExist()
        {
            var manager = new Books();
            TestSingleNotExist( manager );
        }
        #endregion

        #region Movies
        [Test]
        public void TestAllMovies()
        {
            var manager = new Movies(AccessToken);
            TestAll(manager);
        }

        [Test]
        public void TestSingleMovie()
        {
            var manager = new Movies(AccessToken);
            TestSingle(manager);
        }

        [Test]
        public void TestGreaterThanMovie()
        {
            var manager = new Movies(AccessToken);
            manager.Filter = new Filters { Operator = ">", Property = "boxOfficeRevenueInMillions", Values = "1000" };
            var all = manager.GetAll();
            if ( all.Count == 4 )
                Assert.Pass();
            else
                Assert.Fail();
        }


        [Test]
        public void TestSingleMovieNotExist()
        {
            var manager = new Movies(AccessToken);
            TestSingleNotExist(manager);
        }
        #endregion

        #region Characters
        [Test]
        public void TestAllCharacters()
        {
            var manager = new Characters(AccessToken);
            TestAll(manager);
        }

        [Test]
        public void TestSingleCharacter()
        {
            var manager = new Characters(AccessToken);
            TestSingle(manager);
        }


        [Test]
        public void TestSingleCharacterNotExist()
        {
            var manager = new Characters(AccessToken);
            TestSingleNotExist(manager);
        }
        #endregion

        #region Quotes
        [Test]
        public void TestAllQuotes()
        {
            var manager = new Quotes(AccessToken);
            TestAll(manager);
        }

        [Test]
        public void TestSingleQuote()
        {
            var manager = new Quotes(AccessToken);
            TestSingle(manager);
        }


        [Test]
        public void TestSingleQuoteNotExist()
        {
            var manager = new Quotes(AccessToken);
            TestSingleNotExist(manager);
        }
        #endregion

        #region Chapters
        [Test]
        public void TestAllChapters()
        {
            var manager = new Chapters(AccessToken);
            TestAll(manager);
        }

        [Test]
        public void TestSingleChapter()
        {
            var manager = new Chapters(AccessToken);
            TestSingle(manager);
        }


        [Test]
        public void TestSingleChapterNotExist()
        {
            var manager = new Chapters(AccessToken);
            TestSingleNotExist(manager);
        }
        #endregion
    }
}