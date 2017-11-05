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
    public class TodoRepositoryTests
    {

        [TestMethod()]
        public void AddTest()
        {
            var item = new TodoItem("task");
            var repository = new TodoRepository(null);
            Assert.AreEqual(item, repository.Add(item));
        }

        [TestMethod()]
        public void GetTest()
        {
            var repository = new TodoRepository();
            var test1 = new TodoItem("task1");
            repository.Add(test1);
            Assert.AreEqual(test1, repository.Get(test1.Id));

            repository = new TodoRepository();
            Assert.IsNull(repository.Get(test1.Id));

            repository.Add(test1);
            var test2 = new TodoItem("task2");
            Assert.IsNull(repository.Get(test2.Id));
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            var repository = new TodoRepository();

            var test1 = new TodoItem("task1");
            var test2 = new TodoItem("task2");
            var test3 = new TodoItem("task3");
            repository.Add(test1);
            repository.Add(test2);
            repository.Add(test3);

            repository.MarkAsCompleted(test1.Id);

            List<TodoItem> lista = repository.GetActive();

            Assert.AreEqual(lista[0], test2);

        }

        [TestMethod()]
        public void GetAllTest()
        {
            var repository = new TodoRepository();

            var test1 = new TodoItem("task1");
            var test2 = new TodoItem("task2");
            var test3 = new TodoItem("task3");
            repository.Add(test1);
            repository.Add(test2);
            repository.Add(test3);

            List<TodoItem> lista = repository.GetAll();

            Assert.AreEqual(lista[0], test1);
            Assert.AreEqual(lista[1], test2);
            Assert.AreEqual(lista[2], test3);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            var repository = new TodoRepository();

            var test1 = new TodoItem("task1");
            var test2 = new TodoItem("task2");
            var test3 = new TodoItem("task3");
            repository.Add(test1);
            repository.Add(test2);
            repository.Add(test3);

            repository.MarkAsCompleted(test1.Id);
            repository.MarkAsCompleted(test2.Id);

            List<TodoItem> lista = repository.GetCompleted();

            Assert.AreEqual(lista[0], test1);
            Assert.AreEqual(lista[1], test2);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            var repository = new TodoRepository();

            var test1 = new TodoItem("task1");
            var test2 = new TodoItem("task2");
            var test3 = new TodoItem("task3");
            repository.Add(test1);
            repository.Add(test2);
            repository.Add(test3);

            repository.MarkAsCompleted(test1.Id);
            repository.MarkAsCompleted(test2.Id);

            List<TodoItem> lista = repository.GetFiltered((i) => String.Compare(i.Text, "task1", StringComparison.Ordinal) > 0);

            Assert.AreEqual(lista[0], test2);
            Assert.AreEqual(lista[1], test3);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            var repository = new TodoRepository();

            var test = new TodoItem("task");
            repository.Add(test);

            Assert.IsTrue(repository.MarkAsCompleted(test.Id));
            Assert.IsFalse(repository.MarkAsCompleted(test.Id));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            var repo = new TodoRepository();

            var test1 = new TodoItem("task1");
            var test2 = new TodoItem("task2");
            repo.Add(test1);

            Assert.IsFalse(repo.Remove(test2.Id));
            Assert.IsTrue(repo.Remove(test1.Id));
            Assert.IsFalse(repo.Remove(test1.Id));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var repository = new TodoRepository();

            var test = new TodoItem("task1");

            Assert.AreEqual(test, repository.Add(test));
        }
    }
}