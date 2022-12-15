using ADO.NET_Task4.DataAccess;
using ADO.NET_Task4.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADO.NET_Task4.Helpers
{
    public class DatabaseHelper
    {
        static LibraryDataClassesDataContext dtx = new LibraryDataClassesDataContext();

        public static List<Book> GetBooks()
        {
            var books = from b in dtx.Books
                        select b;
            return books.ToList();
        }

        public static List<Author> GetAuthors()
        {
            var authors = from a in dtx.Authors
                          select a;
            return authors.ToList();
        }

        public static List<Theme> GetThemes()
        {
            var themes = from t in dtx.Themes
                         select t;
            return themes.ToList();
        }

        public static List<Category> GetCategories()
        {
            var categories = from c in dtx.Categories
                             select c;
            return categories.ToList();
        }

        public static List<Press> GetPresses()
        {
            var presses = from p in dtx.Presses
                          select p;
            return presses.ToList();
        }

        public static void AddBook(Book book)
        {
            dtx.Books.InsertOnSubmit(book);
            dtx.SubmitChanges();
        }

        public static void SaveChanges(Book book)
        {
            var _book = dtx.Books.FirstOrDefault(b => b.Id == book.Id);
            //_book = book;

            _book.Name = book.Name;
            _book.Pages = book.Pages;
            _book.YearPress = book.YearPress;
            _book.Comment = book.Comment;
            _book.Quantity = book.Quantity;
            _book.Id_Author = book.Id_Author;
            _book.Id_Themes = book.Id_Themes;
            _book.Id_Category = book.Id_Category;
            _book.Id_Press = book.Id_Press;

            dtx.SubmitChanges();
        }

        public static void DeleteBookById(int bookId)
        {
            dtx.Books.DeleteOnSubmit(dtx.Books.FirstOrDefault(b => b.Id == bookId));
            var scards = from s in dtx.S_Cards
                         where s.Id_Book == bookId
                         select s;
            dtx.S_Cards.DeleteAllOnSubmit<S_Card>(scards);

            var tcards = from t in dtx.T_Cards
                         where t.Id_Book == bookId
                         select t;
            dtx.T_Cards.DeleteAllOnSubmit<T_Card>(tcards);

            dtx.SubmitChanges();
        }

        public static Student StudentExists(int id)
        {
            return dtx.Students.FirstOrDefault(s => s.Id == id) ;
        }

        public static void AddSCard(S_Card s_card)
        {
            dtx.S_Cards.InsertOnSubmit(s_card);
            dtx.SubmitChanges();
        }

        public static int GetIdForSCard()
        {
            return dtx.S_Cards.Max(s=> s.Id) + 1;
        }   

        public static int GetRandomLibrarianId()
        {
            return dtx.Libs.First().Id;
        }

        public static List<S_Card> GetSCardsById(int studentId)
        {
            var scards = from s in dtx.S_Cards
                         where s.Id_Student == studentId
                         select s;
                
            return scards.ToList();
        }

        public static void DeleteSCardById(int sCardId)
        {
            dtx.S_Cards.DeleteOnSubmit(dtx.S_Cards.FirstOrDefault(s => s.Id == sCardId));
            dtx.SubmitChanges();
        }
    }
}
