using AutoMapper;
using commander.Dtos;
using commander.Models;
using Commander.Dtos;

namespace Commander.Profiles
{
public class CommandsProfile : Profile
{
public CommandsProfile()
{
    CreateMap<command,CommandReadDto>();
    CreateMap<CommandCreateDto,command>();
    CreateMap<CommandUpdateDto,command>();
    CreateMap<command,CommandUpdateDto>();

}
}

}