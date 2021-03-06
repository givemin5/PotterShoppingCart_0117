﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });

            //Act
            int actual = cart.Checkout();

            //Assert
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_第一集買了一本_第二集也買了一本_價格應為190()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第二集", Quantity = 1 });
            //Act
            int actual = cart.Checkout();

            //Assert
            var expected = 190;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三集各買了一本_價格應為_270()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第二集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第三集", Quantity = 1 });
            //Act

            int actual = cart.Checkout();

            //Assert
            var expected = 270;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三四集各買了一本_價格應為_320()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第二集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第三集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第四集", Quantity = 1 });
            //Act

            int actual = cart.Checkout();

            //Assert
            var expected = 320;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三四五集各買了一本_價格應為_375()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第二集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第三集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第四集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第五集", Quantity = 1 });
            //Act

            int actual = cart.Checkout();

            //Assert
            var expected = 375;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二集各買了一本_第三集買了兩本_價格應為_370()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第二集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第三集", Quantity = 2 });
            //Act

            int actual = cart.Checkout();

            //Assert
            var expected = 370;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_第一集買了一本_第二三集各買了兩本_價格應為_460()
        {
            //Arrange
            var cart = new ShoppingCart();
            cart.Add(new Book { Title = "哈利波特第一集", Quantity = 1 });
            cart.Add(new Book { Title = "哈利波特第二集", Quantity = 2 });
            cart.Add(new Book { Title = "哈利波特第三集", Quantity = 2 });
            //Act

            int actual = cart.Checkout();

            //Assert
            var expected = 460;
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

        /// <summary>
        /// 結帳
        /// </summary>
        /// <returns></returns>
        internal int Checkout()
        {
            const int UNIT_PRICE = 100;
            decimal amount = 0;

            while (books.Any(x => x.Quantity > 0))
            {
                int bookNum = 0;
                foreach (var book in books)
                {
                    if (book.Quantity > 0)
                    {
                        bookNum = bookNum + 1;
                        book.Quantity = book.Quantity - 1;
                    }
                }
                amount += UNIT_PRICE * bookNum * GetDiscount(bookNum);
            }

            return Convert.ToInt32(Math.Round(amount,MidpointRounding.AwayFromZero));
        }

        /// <summary>
        /// 根據數量給予優惠金額
        /// </summary>
        /// <param name="bookNum"></param>
        /// <returns></returns>
        private decimal GetDiscount(int bookNum)
        {
            switch (bookNum)
            {
                case 1:
                    return 1m;

                case 2:
                    return 0.95m;

                case 3:
                    return 0.90m;

                case 4:
                    return 0.80m;

                case 5:
                    return 0.75m;
            }
            return 0;
        }
    }
}