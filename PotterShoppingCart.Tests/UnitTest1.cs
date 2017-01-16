using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// UnitTest1 的摘要描述
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_第一集買了一本_其他都沒買_價格應為100()
        {
            //Arrange
            var cart = new ShoppingCart();
            var book = new Book { Title = "哈利波特第一集", Price = 100 , Quantity = 1 };

            //Act
            cart.Add(book);
            int actual = cart.Checkout();

            //Assert
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_第一集買了一本_第二集也買了一本_價格應為190() {
            //Arrange
            var cart = new ShoppingCart();
            var book1 = new Book { Title = "哈利波特第一集", Price = 100, Quantity = 1 };
            var book2 = new Book { Title = "哈利波特第二集", Price = 100, Quantity = 1 };
            //Act
            cart.Add(book1);
            cart.Add(book2);
            int actual = cart.Checkout();

            //Assert
            var expected = 190;
            Assert.AreEqual(expected, actual);
        }
    }

    internal class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Quantity { get; internal set; }
    }

    internal class ShoppingCart
    {
        private List<Book> books;

        public ShoppingCart()
        {
            books = new List<Book>();
        }

        internal void Add(Book book)
        {
            books.Add(book);
        }

        internal int Checkout()
        {
            int amount = 0;
            foreach(var book in books)
            {
                amount += book.Price * book.Quantity;
            }
            return amount;
        }
    }
}