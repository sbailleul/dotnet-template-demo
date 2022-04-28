using Microsoft.AspNetCore.Mvc;

namespace Neos.Templates.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TemplatesController : ControllerBase
{
    public static readonly HashSet<Template> Templates = Enumerable
        .Range(0, 100)
        .Select(index => new Template() { Id = Guid.NewGuid(), Property = $"P-{index}" })
        .ToHashSet();

    private readonly ILogger<TemplatesController> _logger;

    public TemplatesController(ILogger<TemplatesController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{templateId:guid}", Name = nameof(GetTemplateById))]
    public IActionResult GetTemplateById(Guid templateId)
    {
        var template = Templates.FirstOrDefault(t => t.Id == templateId);
        if (template is null)
            return NotFound();
        return Ok(template);
    }

    [HttpDelete("{templateId:guid}", Name = nameof(DeleteTemplateById))]
    public IActionResult DeleteTemplateById(Guid templateId)
    {
        var template = Templates.FirstOrDefault(t => t.Id == templateId);
        if (template is null)
            return NotFound();
        Templates.Remove(template);
        return NoContent();
    }

    public record CreateTemplateRequest(string Property);

    [HttpPost(Name = nameof(CreateTemplate))]
    public IActionResult CreateTemplate([FromBody] CreateTemplateRequest req)
    {
        var newTemplate = new Template { Id = Guid.NewGuid(), Property = req.Property };
        Templates.Add(newTemplate);
        return CreatedAtAction(nameof(GetTemplateById), new { templateId = newTemplate.Id }, null);
    }

    [HttpGet(Name = nameof(GetAllTemplates))]
    public IActionResult GetAllTemplates() => Ok(Templates);

    public record UpdateTemplateRequest(string Property);

    [HttpPut("{templateId:guid}", Name = nameof(UpdateTemplate))]
    public IActionResult UpdateTemplate(Guid templateId, [FromBody] UpdateTemplateRequest req)
    {
        var template = Templates.FirstOrDefault(t => t.Id == templateId);
        if (template is null)
            return NotFound();
        template.Property = req.Property;
        return NoContent();
    }
}