using APAdmin.Application.ClassAttendanceModule.Commands.Register;

namespace APAdmin.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassAttendanceController : ApiControllerBase
{
    public ClassAttendanceController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType(typeof(RegisterClassAttendanceResponse), 200)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(APAdminException), 500)]
    public async Task<IActionResult> Upload([FromForm] ICollection<IFormFile> formFiles)
    {
        if (formFiles == null || formFiles.Count == 0)
            return BadRequest();
        
        var selectedFiles = await LoadSelectedFiles(formFiles);

        var command = new RegisterClassAttendanceRequest(selectedFiles[0]);

        var response = await mediator.Send(command);

        return Execute(response);
    }

    private async Task<List<byte[]>> LoadSelectedFiles(ICollection<IFormFile> formFiles)
    {
        var selectedFiles = new List<byte[]>();

        foreach (var file in formFiles)
        {
            if (file.Length == 0)
                continue;

            using var stream = new MemoryStream();

            await file.CopyToAsync(stream);

            selectedFiles.Add(stream.ToArray());
        }

        return selectedFiles;
    }
}