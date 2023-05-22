using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberManGUI.UsersManager
{
    public class UserRepository
    {
        private readonly string _filePath;
        public UserRepository(string filePath = null)
        {
            _filePath = filePath ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{typeof(User).Name}.json");
            EnsureFileExists();
        }

        public bool Add(User user)
        {
            try
            {
                var users = GetAllItems();

                if (users != null)
                {
                    users.Add(user);
                }
                else
                {
                    users = new List<User>();
                    users.Add(user);
                }

                WriteToFile(users);

                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed add entity to file: {ex.Message}");
            }
        }
        public User GetById(Guid id)
        {
            try
            {
                var entityResult = GetByPredicate(entity => entity.Id.Equals(id));

                if (entityResult != null)
                {
                    return entityResult;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed get entity by id: {ex.Message}");
            }
        }

        private void WriteToFile(List<User> users)
        {
            try
            {
                using (StreamWriter file = File.CreateText(_filePath))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(file))
                    {
                        writer.Formatting = Formatting.Indented;//?
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, users);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed write to file: {ex.Message}");
            }

        }

        private List<User> GetAllItems()
        {
            try
            {
                using (StreamReader file = File.OpenText(_filePath))
                {
                    using (JsonReader jsonReader = new JsonTextReader(file))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        return serializer.Deserialize<List<User>>(jsonReader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed read from file: {ex.Message}");
            }
        }

        public User GetByPredicate(Func<User, bool> predicate)
        {
            try
            {
                var entities = GetAllItems();
                var entity = entities.FirstOrDefault(predicate);

                if (entity == null)
                {
                    return null;
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get by predicate from file: {ex.Message}");
            }
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                WriteToFile(new List<User>());
            }
        }
    }
}
