using System.Collections.Generic;
using commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<command> GetAllCommands();
        command GetCommandById(int id);
        void CreateCommand(command cmd);
        void UpdateCommand(command cmd);
        void DeleteCommand(command cmd);


    }
}