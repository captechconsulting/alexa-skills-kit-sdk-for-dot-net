using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ask.Sdk.Asp.Net.Core.Attributes;
using Ask.Sdk.Core.Skill;
using Ask.Sdk.Core.Skill.Factory;
using Ask.Sdk.Model.Request;
using Ask.Sdk.Model.Response;
using HelloWorldWeb.Handlers;
using Microsoft.AspNetCore.Http;
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
        public async Task<ResponseEnvelope> Post([FromBody] RequestEnvelope request)
        {
            return await _skillBuilder.Execute(request);
        }
    }
}