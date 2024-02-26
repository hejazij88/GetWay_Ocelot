using System.Reflection;
using Writer_Api.Model;

namespace Writer_Api.Repository
{
    public class WriterRepository
    {
        private readonly static List<Writer> _writers = Populate();

        private static List<Writer> Populate()
        {
            return new List<Writer>
            {
                new Writer
                {
                    Id = 1,
                    Name = "Leanne Graham"
                },
                new Writer
                {
                    Id = 2,
                    Name = "Ervin Howell"
                },
                new Writer
                {
                    Id = 3,
                    Name = "Glenna Reichert"
                }
            };
        }

        public List<Writer> GetAll()
        {
            return _writers;
        }

        public Writer Insert(Writer writer)
        {
            var maxId = _writers.Max(x => x.Id);

            writer.Id = ++maxId;
            _writers.Add(writer);

            return writer;
        }

        public Writer? Get(int id)
        {
            return _writers.FirstOrDefault(x => x.Id == id);
        }
    }
}
