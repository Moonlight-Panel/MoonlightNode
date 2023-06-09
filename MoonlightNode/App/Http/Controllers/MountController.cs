﻿using Microsoft.AspNetCore.Mvc;
using MoonlightNode.App.Exceptions;
using MoonlightNode.App.Http.Requests;
using MoonlightNode.App.Services;

namespace MoonlightNode.App.Http.Controllers;

[ApiController]
[Route("mount")]
public class MountController : Controller
{
    private readonly MountService MountService;

    public MountController(MountService mountService)
    {
        MountService = mountService;
    }

    [HttpPost]
    public async Task<ActionResult> Mount([FromBody] Mount mount)
    {
        try
        {
            await MountService.Mount(
                mount.Server,
                mount.ServerPath,
                mount.Path
            );
            
            return Ok();
        }
        catch (BashException e)
        {
            return Problem(e.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Unmount([FromBody] Unmount unmount)
    {
        try
        {
            await MountService.Unmount(unmount.Path);
            
            return Ok();
        }
        catch (BashException e)
        {
            return Problem(e.Message);
        }
    }
}