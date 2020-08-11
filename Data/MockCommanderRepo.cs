using System.Collections.Generic;
using commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<command> GetAllCommands()
        {
            var commands=new List<command>{
                new command{Id=0,Howto="ddd",Line="aa",Platform="wwwww"},
                new command{Id=1,Howto="ddd11",Line="a11a",Platform="wwwww11"},
                new command{Id=2,Howto="ddd22",Line="aa22",Platform="wwwww22"}
            };
            return commands;
        }

        public command GetCommandById(int id)
        {
            return new command{Id=0,Howto="ddd",Line="aa",Platform="wwwww"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}