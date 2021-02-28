using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyLionAssesment.DTO.Feature;
using MoneyLionAssesment.Models;
using MoneyLionAssesment.Repository;
using System;

namespace MoneyLionAssesment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepository featureRepo;

        private readonly IMapper mapper;

        public FeatureController(IFeatureRepository featureRepository, IMapper mapper)
        {
            featureRepo = featureRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<FeatureReadDTO> CreateFeature(FeatureCreateDTO featureCreateDto)
        {
            try
            {
                var feature = mapper.Map<Feature>(featureCreateDto);

                featureRepo.CreateFeature(feature);

                if (featureRepo.SaveChanges())
                {
                    return Ok(mapper.Map<FeatureReadDTO>(feature));
                }

                return BadRequest();
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult GetFeatureByNameAndEmail([FromQuery(Name = "email")] string email, [FromQuery(Name = "featureName")] string featureName)
        {
            var feature = featureRepo.GetFeatureByEmailAndName(email, featureName);
            if (feature != null)
            {
                return Ok(new { CanAccess = true });
            }

            return Ok(new { CanAccess = false });
        }

        [HttpPost]
        public ActionResult UpdateFeatureAccess([FromBody] FeatureUpdateDTO req)
        {
            var res = featureRepo.UpdateFeatureAccess(req.email, req.featureName, req.enable);
            if (res)
            {
                if (featureRepo.SaveChanges())
                {
                    return Ok();
                }
            }

            return StatusCode(304);
        }
    }
}
