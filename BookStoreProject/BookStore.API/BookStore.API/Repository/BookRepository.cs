using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext context;
        private readonly IMapper mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var records = await context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).ToListAsync();

            //return records;

            var records = await context.Books.ToListAsync();
            return mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //var records = await context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description
            //}).FirstOrDefaultAsync();

            //return records;

            var book = await context.Books.FindAsync(bookId);
            return mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await context.Books.FindAsync(bookId);
            //if (book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;

            //    await context.SaveChangesAsync();
            //}

            var book = new Books()
            {
                Id=bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await context.Books.FindAsync(bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            //var book = context.Books.where(x => x.TTitle == "").FirstOrDefault();

            //context.Books.Remove(book);
            //await context.SaveChangesAsync();

            var book =new Books() { Id=bookId };

            context.Books.Remove(book);
            await context.SaveChangesAsync();

        }
    }
}
