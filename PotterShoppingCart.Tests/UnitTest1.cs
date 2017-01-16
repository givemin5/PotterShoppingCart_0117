using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var cart = new ShoppingCart();

            var book = new Book { Title = "哈利波特第一集", Price = 100 };

            var expected = 100;

            cart.Add(book, 1);

            int actual = cart.Checkout();

            Assert.AreEqual(expected, actual);

        }
    }

    internal class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }

    }

    internal class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        internal void Add(Book book, int num)
        {
            throw new NotImplementedException();
        }

        internal int Checkout()
        {
            throw new NotImplementedException();
        }
    }
}
