using AutoMapper;
using It4see.Application.SensorCategories;
using It4see.Web.ViewModels.SensorCategory;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace It4see.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorCategoryController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        var sensorCategories = await mediator.Send(new GetAllSensorCategoriesQuery());

        var categoryListViewModels = mapper.Map<List<SensorCategoryListViewModel>>(sensorCategories);

        return Ok(categoryListViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var sensorCategory = await mediator.Send(new GetSensorCategoryQuery { Id = id });
        if (sensorCategory == null)
        {
            return NotFound();
        }

        var categoryDetailsViewModel = mapper.Map<SensorCategoryDetailsViewModel>(sensorCategory);

        return Ok(categoryDetailsViewModel);
    }

    [HttpGet("byTitle")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var sensorCategory = await mediator.Send(new GetSensorCategoryByTitleQuery { Title = title });
        if (sensorCategory == null)
        {
            return NotFound();
        }

        var categoryDetailsViewModel = mapper.Map<SensorCategoryDetailsViewModel>(sensorCategory);
        
        return Ok(categoryDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SensorCategoryCreateViewModel sensorCategoryCreateViewModel)
    {
        var createSensorCategoryCommand = mapper.Map<CreateSensorCategoryCommand>(sensorCategoryCreateViewModel);

        await mediator.Send(createSensorCategoryCommand);

        return Ok(sensorCategoryCreateViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> Put(SensorCategoryUpdateViewModel sensorCategoryUpdateViewModel)
    {
        var updateSensorCategoryCommand = mapper.Map<UpdateSensorCategoryCommand>(sensorCategoryUpdateViewModel);

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