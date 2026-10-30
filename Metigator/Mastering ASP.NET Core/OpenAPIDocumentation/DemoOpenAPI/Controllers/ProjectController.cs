using System.Runtime.CompilerServices;
using System.Security.Claims;
using DemoOpenAPI.Requests;
using DemoOpenAPI.Responses;
using DemoOpenAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using DemoOpenAPI.Permissions;

namespace DemoOpenAPI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/projects")]
[ApiVersion("1.0")]
[ApiVersion("2.0")]


public class ProjectController(IProjectService projectService) : ControllerBase
{
    private Guid GetUserId() => Guid.NewGuid();

    [HttpPost]
    [MapToApiVersion("1.0")]
    [Authorize(Permission.Project.Create)]
    public async Task<ActionResult<ProjectResponse>> CreateProject([FromBody] CreateProjectRequest request)
    {
        var userId = GetUserId();
        var result = await projectService.CreateProjectAsync(request, userId);

        return CreatedAtAction(nameof(GetProject), new { projectId = result.Id }, result);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjects()
    {
        var projects = await projectService.GetProjectsAsync();
        return Ok(projects);
    }

    [HttpGet]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<List<ProjectResponse>>> GetProjectsV2()
    {
        var projects = await projectService.GetProjectsAsync();
        foreach (var project in projects)
            project.Currency = "USD";

        return Ok(projects);
    }

    [HttpGet("{projectId:guid}")]
    [MapToApiVersion("2.0")]

    public async Task<ActionResult<ProjectResponse>> GetProject([FromRoute] Guid projectId)
    {
        var project = await projectService.GetProjectAsync(projectId);
        return Ok(project);
    }

    [HttpGet("{projectId:guid}")]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<ProjectResponse>> GetProjectV2([FromRoute] Guid projectId)
    {
        var project = await projectService.GetProjectAsync(projectId);
        if (project is null)
            return NotFound("Project was not found");

        project.Currency = "USD";
        return Ok(project);
    }

    [HttpPut("{projectId:guid}")]
    [MapToApiVersion("1.0")]

    public async Task<IActionResult> UpdateProject([FromRoute] Guid projectId, [FromBody] UpdateProjectRequest request)
    {
        await projectService.UpdateProjectAsync(projectId, request, GetUserId());
        return NoContent();
    }

    [HttpDelete("{projectId:guid}")]
    [MapToApiVersion("1.0")]

    public async Task<IActionResult> DeleteProject([FromRoute] Guid projectId)
    {
        await projectService.DeleteProjectAsync(projectId, GetUserId());
        return NoContent();
    }

    [HttpPut("{projectId:guid}/budget")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateBudget([FromRoute] Guid projectId, [FromBody] UpdateBudgetRequest request)
    {
        await projectService.ManageBudgetAsync(projectId, request, GetUserId());
        return NoContent();
    }

    [HttpPut("{projectId:guid}/completion")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> EndProject([FromRoute] Guid projectId)
    {
        await projectService.EndProjectAsync(projectId, GetUserId());
        return NoContent();
    }


    // === TASK ENDPOINTS ==================================================

    [HttpPost("{projectId:guid}/tasks")]
    [MapToApiVersion("1.0")]
    public async Task<ActionResult<ProjectTaskResponse>> CreateTask([FromRoute] Guid projectId, [FromBody] CreateTaskRequest request)
    {
        var task = await projectService.CreateTaskAsync(projectId, request, GetUserId());
        return CreatedAtAction(nameof(GetTask), new { projectId, taskId = task.Id }, task);
    }

    [HttpGet("{projectId:guid}/tasks/{taskId:guid}")]
    [MapToApiVersion("1.0")]

    public async Task<ActionResult<ProjectTaskResponse>> GetTask([FromRoute] Guid projectId, [FromRoute] Guid taskId)
    {
        var task = await projectService.GetTaskAsync(projectId, taskId);
        return Ok(task);
    }

    [HttpPut("{projectId:guid}/tasks/{taskId:guid}/status")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateTaskStatus([FromRoute] Guid projectId, [FromRoute] Guid taskId, [FromBody] UpdateTaskStatusRequest request)
    {
        await projectService.UpdateTaskStatusAsync(projectId, taskId, request, GetUserId());
        return NoContent();
    }

    [HttpPut("{projectId:guid}/tasks/{taskId:guid}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> UpdateTask([FromRoute] Guid projectId, [FromRoute] Guid taskId, [FromBody] UpdateTaskRequest request)
    {
        await projectService.UpdateTaskAsync(projectId, taskId, request, GetUserId());
        return NoContent();
    }

    [HttpPut("{projectId:guid}/tasks/{taskId:guid}/assignment")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> AssignUser([FromRoute] Guid projectId, [FromRoute] Guid taskId, [FromBody] AssignUserToTaskRequest request)
    {
        await projectService.AssignUserToTaskAsync(projectId, taskId, request, GetUserId());
        return NoContent();
    }

    [HttpDelete("{projectId:guid}/tasks/{taskId:guid}")]
    [MapToApiVersion("1.0")]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid projectId, [FromRoute] Guid taskId)
    {
        await projectService.DeleteTaskAsync(projectId, taskId, GetUserId());
        return NoContent();
    }
}