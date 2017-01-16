using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

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
            var book = new Book { Title = "哈利波特第一集", Quantity = 1 };

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
            var book1 = new Book { Title = "哈利波特第一集", Quantity = 1 };
            var book2 = new Book { Title = "哈利波特第二集", Quantity = 1 };
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
            while (books.Any(x => x.Quantity > 0))
            {
                int serv = 0;
                foreach (var book in books)
                {
                    if (book.Quantity > 0)
                    {
                        serv = serv + 1;
                        book.Quantity = book.Quantity - 1;
                    }
                }
                amount += CalcByBookNum(serv);
            }

            
            return amount;
        }

        private int CalcByBookNum(int serv)
        {
            switch (serv) {
                case 1:
                    return 100;
                case 2:
                    return 190;
            }
            return 0;
        }
    }
}