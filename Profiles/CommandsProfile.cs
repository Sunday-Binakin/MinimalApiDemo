using AutoMapper;
using MinimalApiDemo.Dto;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Profiles;

public class CommandsProfile:Profile
{
    public CommandsProfile()
    {
        //source -> Traget
        CreateMap<Command, CommandReadDto>();
        CreateMap<CommandCreateDto,Command>();
        CreateMap<CommandUpdateDto,Command>();
    }
}