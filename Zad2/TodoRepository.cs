using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Zad2
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
                throw new DuplicateTodoItemException($"Duplicate Id: {todoItem.Id}");
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public TodoItem Get(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Count() == 0) return null;
            TodoItem t = _inMemoryTodoDatabase.FirstOrDefault(i =>
            {
                if (i == null) return false;
                return i.Id == todoId;
            });
            return t;
        }

        public List<TodoItem> GetActive()
        {
            var Database = _inMemoryTodoDatabase.Where(x => x != null).ToList();
            return Database.Where(x => !x.IsCompleted).ToList();
        }

        public List<TodoItem> GetAll()
        {
            var Database = _inMemoryTodoDatabase.Where(x => x != null).ToList();
            return Database;
        }

        public List<TodoItem> GetCompleted()
        {
            var Database = _inMemoryTodoDatabase.Where(x => x != null).ToList();
            return Database.Where(x => x.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            var Database = _inMemoryTodoDatabase.Where(x => x != null).ToList();
            return Database.Where(filterFunction).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            var temp = Get(todoId);
            if (temp == null || temp.IsCompleted != false) return false;
            temp.MarkAsCompleted();
            return true;
        }

        public bool Remove(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Count() == 0) return false;
            TodoItem t = _inMemoryTodoDatabase.FirstOrDefault(i =>
            {
                if (i == null) return false;
                return i.Id == todoId;
            });

            if (t == null) return false;
            _inMemoryTodoDatabase.Remove(t);
            return true;

        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (!_inMemoryTodoDatabase.Contains(todoItem))
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
            else
            {
                var t = _inMemoryTodoDatabase.First(i => i.Equals(todoItem));
                t.DateCreated = todoItem.DateCreated;
                t.Text = todoItem.Text;
                t.DateCompleted = todoItem.DateCompleted;
            }
            return todoItem;
        }
    }

    internal class DuplicateTodoItemException : Exception
    {

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

    }
}

