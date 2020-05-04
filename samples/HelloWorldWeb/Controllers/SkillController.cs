using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Ask.Sdk.Asp.Net.Core.Attributes;
using Ask.Sdk.Core.Skill.Factory;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AlexaRequestValidation]
    public class SkillController : ControllerBase
    {
        private readonly CustomSkillBuilder _skillBuilder;

        public SkillController(CustomSkillBuilder skillBuilder)
        {
            _skillBuilder = skillBuilder;
        }

        [HttpPost]
        public async Task<SkillResponse> Post([FromBody] SkillRequest request)
        {
            return await _skillBuilder.Execute(request);
        }
    }
}