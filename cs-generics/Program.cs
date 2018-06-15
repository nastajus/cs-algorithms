using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book { Isbn = "1111", Title = "C# Advanced" };

            //var numbers = new List();
            //numbers.Add(10);

            //var books = new BookList();
            //books.Add(book);

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(book);
        }
    }

    class List
    {
        public void Add(int number)
        {
            throw new NotImplementedException();
        }

        //int get this[int index] {
        //    get {throw new NotImplementedException(); }
        //}

        int At(int index)
        {
            return { throw new NotImplementedException () };
        }

    }

    class BookList
    {
        public void Add(Book book) {
            throw new NotImplementedException();
        }

        //Book get this[Book index ] {
        //    get {throw new NotImplementedException(); }
        //}

        Book At(Book book)
        {
            return { throw new NotImplementedException(); }
        }
    }

    class Book {
        public string Isbn;
        public string Title;
    }

    class GenericList<T>
    {
        public void Add(T value)
        {

        }

        //public T this[int value]
        //{

        //}

        public T At(int index)
        {

        }
    }
}
