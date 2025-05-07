using AutoMapper;
using It4see.Application.Sensors;
using It4see.Domain;
using It4see.Web.ViewModels.Sensor;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace It4see.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("list")]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        List<Sensor> sensors = await mediator.Send(new GetAllSensorsQuery());

        List<SensorListViewModel> sensorsListViewModels = mapper.Map<List<SensorListViewModel>>(sensors);

        return Ok(sensorsListViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        Sensor sensor = await mediator.Send(new GetSensorQuery { Id = id });
        if (sensor == null)
        {
            return NotFound();
        }

        SensorDetailsViewModel sensorDetailsViewModel = mapper.Map<SensorDetailsViewModel>(sensor);

        return Ok(sensorDetailsViewModel);
    }

    [HttpGet("byName")]
    public async Task<IActionResult> GetByName(string name)
    {
        Sensor sensor = await mediator.Send(new GetSensorByNameQuery { Name = name });
        if (sensor == null)
        {
            return NotFound();
        }

        SensorDetailsViewModel sensorsDetailsViewModel = mapper.Map<SensorDetailsViewModel>(sensor);
        
        return Ok(sensorsDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SensorCreateViewModel sensorCreateViewModel)
    {
        CreateSensorCommand createSensorCommand = mapper.Map<CreateSensorCommand>(sensorCreateViewModel);

        await mediator.Send(createSensorCommand);

        return Ok(sensorCreateViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Put(SensorUpdateViewModel sensorUpdateViewModel)
    {
        UpdateSensorCommand updateSensorCommand = mapper.Map<UpdateSensorCommand>(sensorUpdateViewModel);

        await mediator.Send(updateSensorCommand);

        return Ok(sensorUpdateViewModel);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteSensorCommand { Id = id });

        return NoContent();
    }
}