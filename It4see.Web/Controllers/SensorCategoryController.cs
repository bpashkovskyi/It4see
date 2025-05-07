using AutoMapper;
using It4see.Application.SensorCategories;
using It4see.Domain;
using It4see.Web.ViewModels.SensorCategory;
using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace It4see.Web.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class SensorCategoryController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        List<SensorCategory> sensorCategories = await mediator.Send(new GetAllSensorCategoriesQuery());

        List<SensorCategoryListViewModel> categoryListViewModels = mapper.Map<List<SensorCategoryListViewModel>>(sensorCategories);

        return Ok(categoryListViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        if (id == 2)
        {
            throw new InvalidCastException();
        }

        SensorCategory sensorCategory = await mediator.Send(new GetSensorCategoryQuery { Id = id });
        if (sensorCategory == null)
        {
            return NotFound();
        }

        SensorCategoryDetailsViewModel categoryDetailsViewModel = mapper.Map<SensorCategoryDetailsViewModel>(sensorCategory);

        return Ok(categoryDetailsViewModel);
    }

    [HttpGet("byTitle")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        SensorCategory sensorCategory = await mediator.Send(new GetSensorCategoryByTitleQuery { Title = title });
        if (sensorCategory == null)
        {
            return NotFound();
        }

        SensorCategoryDetailsViewModel categoryDetailsViewModel = mapper.Map<SensorCategoryDetailsViewModel>(sensorCategory);
        
        return Ok(categoryDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SensorCategoryCreateViewModel sensorCategoryCreateViewModel)
    {
        CreateSensorCategoryCommand createSensorCategoryCommand = mapper.Map<CreateSensorCategoryCommand>(sensorCategoryCreateViewModel);

        await mediator.Send(createSensorCategoryCommand);

        return Ok(sensorCategoryCreateViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Put(SensorCategoryUpdateViewModel sensorCategoryUpdateViewModel)
    {
        UpdateSensorCategoryCommand updateSensorCategoryCommand = mapper.Map<UpdateSensorCategoryCommand>(sensorCategoryUpdateViewModel);

        await mediator.Send(updateSensorCategoryCommand);

        return Ok(sensorCategoryUpdateViewModel);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteSensorCategoryCommand { Id = id });

        return NoContent();
    }
}