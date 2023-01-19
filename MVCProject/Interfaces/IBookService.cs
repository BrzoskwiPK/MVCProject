using MVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IBookService
    {
        public Book Save(Book book);
        public Book? FindById(int? id);
        public List<Book> FindAll();
        public bool Delete(int? id);
        public bool Update(Book book);
    }
}
