using Marketplace.API.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API;

[ApiController]
[Route("/ad")]
public class ClassifiedAdsCommandsApi(IApplicationService applicationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(ClassifiedAds.V1.Create request)
    {
        await applicationService.Handle(request);
        return Ok();
    }

    [Route("name")]
    [HttpPut]
    public async Task<IActionResult> Put(ClassifiedAds.V1.UpdateTitle request)
    {
        await applicationService.Handle(request);
        return Ok();
    }

    [Route("text")]
    [HttpPut]
    public async Task<IActionResult> Put(ClassifiedAds.V1.UpdateText request)
    {
        await applicationService.Handle(request);
        return Ok();
    }

    [Route("price")]
    [HttpPut]
    public async Task<IActionResult> Put(ClassifiedAds.V1.UpdatePrice request)
    {
        await applicationService.Handle(request);
        return Ok();
    }

    [Route("publish")]
    [HttpPut]
    public async Task<IActionResult> Put(ClassifiedAds.V1.RequestToPublish request)
    {
        await applicationService.Handle(request);
        return Ok();
    }
}