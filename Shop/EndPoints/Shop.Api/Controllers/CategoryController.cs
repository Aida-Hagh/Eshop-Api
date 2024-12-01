using Common.Application;
using Common.AspNetCor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;
using System.Net;

namespace Shop.Api.Controllers;

public class CategoryController : ApiController
{
    private readonly ICategoryFacade _categoryFacade;

    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategories()
    {
        var result = await _categoryFacade.GetCategories();
        return QueryResult(result);
        //return new ApiResult<List<CategoryDto>>()
        //{
        //    Data = result,
        //    MetaData = new MetaData()
        //    {
        //        AppStatusCode = AppStatusCode.Success,
        //        Message = "عملیات با موفقیت انجام شد"
        //    },
        //    IsSuccess = true
        //};
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
    {
        var result = await _categoryFacade.GetCategoryById(id);
        return QueryResult(result);

        // return Ok(result);
    }


    [HttpGet("getChild/{id}")]
    public async Task<ApiResult<List<ChildCategoryDto>>> GetCategoriesByParentId(long parentId)
    {
        var result = await _categoryFacade.GetCategoriesByParentId(parentId);
        return QueryResult(result);
    }


    [HttpPost]
    public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _categoryFacade.Create(command);
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result,HttpStatusCode.Created,url);

        // if (result.Status == OperationResultStatus.Success)
        // {
        //     return Ok();
        // }
        //else return BadRequest(result.Message);  
    }

    [HttpPost("AddChild")]
    public async Task<ApiResult<long>> CreateCategory(AddChildCategoryCommand command)
    {
        var result = await _categoryFacade.AddChild(command);
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, HttpStatusCode.Created, url);

        // if (result.Status == OperationResultStatus.Success)
        // {
        //     return Ok();
        // }
        //else return BadRequest(result.Message);  
    }

    [HttpPut]
    public async Task<ApiResult> EditCategory(EditCategoryCommand command)
    {
        var result = await _categoryFacade.Edit(command);
        return CommandResult(result);

        //if (result.Status == OperationResultStatus.Success)
        //{
        //    return Ok();
        //}
        //else return BadRequest(result.Message);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCategory(long categoryId)
    {
        var result = await _categoryFacade.Remove(categoryId);
        if (result.Status == OperationResultStatus.Success)
        {
            return Ok();
        }
        else return BadRequest(result.Message);
    }
}
