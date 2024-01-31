﻿using Business.Abstracts;
using Business.Dtos.Requests.User;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors]
public class UsersController : ControllerBase
{

    IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
    {
        var result = await _userService.AddAsync(createUserRequest);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        var result = await _userService.GetListAsync(pageRequest);
        return Ok(result);
    }
    [HttpGet("Get")]
    public async Task<IActionResult> Get([FromQuery] GetUserRequest getUserRequest)
    {
        var result = await _userService.GetByIdAsync(getUserRequest.Id);
        return Ok(result);
    }
    [HttpGet("GetByMail")]
    public async Task<IActionResult> GetByMail([FromQuery] string mail)
    {
        var result = await _userService.GetByMailUserAsync(mail);
        return Ok(result);
    }
    [HttpGet("Activate")]
	public async Task<IActionResult> Activate([FromQuery] string email)
	{
		var result = await _userService.ActivateUserAsync(email);
		return Ok(result);
	}
	[HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserRequest deleteUserRequest)
    {
        var result = await _userService.DeleteAsync(deleteUserRequest);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest UpdateUserRequest)
    {
        var result = await _userService.UpdateAsync(UpdateUserRequest);
        return Ok(result);
    }
}
