using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2Tests
{
    [TestClass()]
    public class TodoItemTests
    {
        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem item = new TodoItem("task");
            item.MarkAsCompleted();
            Assert.IsTrue(item.IsCompleted);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            TodoItem item1 = new TodoItem("task");
            TodoItem item2 = item1;
            TodoItem item3 = new TodoItem("task");
            Assert.IsTrue(item1.Equals(item2));
            Assert.IsFalse(item1.Equals(item3));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            TodoItem item1 = new TodoItem("task");
            TodoItem item2 = item1;
            TodoItem item3 = new TodoItem("task");
            Assert.AreEqual(item1,item2);
            Assert.AreNotEqual(item1, item3);
        }
    }
}