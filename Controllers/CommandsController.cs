using System.Collections.Generic;
using AutoMapper;
using commander.Dtos;
using commander.Models;
using Commander.Data;
using Commander.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers
{

    //Get  api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsControllers : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsControllers(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        // get api/commands/{id}    
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();
        }
        //Post  api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {

            var commandModel = _mapper.Map<command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new { IDesignTimeMvcBuilderConfiguration = commandReadDto.Id }, commandReadDto);
            //return Ok(_mapper.Map<CommandReadDto>( commandModel));
        }

        //put api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo=_repository.GetCommandById(id);
            if(commandModelFromRepo==null)
         { 
               return NotFound();
         }
         _mapper.Map(commandUpdateDto,commandModelFromRepo);
         
         _repository.UpdateCommand(commandModelFromRepo);

         _repository.SaveChanges();

         return NoContent();

        }
        

        //Patch api/command/{id}
        [HttpPatch("{id}")]
        public ActionResult partialCommandUpdate(int id,JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
                var commandModelFromRepo=_repository.GetCommandById(id);
            if(commandModelFromRepo==null)
         { 
               return NotFound();
         }
         var commandToPatch=_mapper.Map<CommandUpdateDto>(commandModelFromRepo);
         patchDoc.ApplyTo(commandToPatch,ModelState);
         if(! TryValidateModel(commandToPatch))
         {
             return ValidationProblem(ModelState);
         }
         _mapper.Map(commandToPatch,commandModelFromRepo);

         _repository.UpdateCommand(commandModelFromRepo);

         _repository.SaveChanges();

         return NoContent();

        }

        // Delete api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
          var commandModelFromRepo=_repository.GetCommandById(id);
            if(commandModelFromRepo==null)
         { 
               return NotFound();
         }
         _repository.DeleteCommand(commandModelFromRepo);
         _repository.SaveChanges();
         return NoContent();  
        } 
    }
}