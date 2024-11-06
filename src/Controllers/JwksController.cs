using System.Threading.Tasks;
using AdvantageTool.Data;
using AdvantageTool.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AdvantageTool.Controllers;

[Route(".well-known/jwks")]
public class JwksController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get(string platformId, [FromServices] ApplicationDbContext dbContext)
    {
        var platform = await dbContext.GetPlatformByPlatformId(platformId);
        if (platform == null)
        {
            return NotFound();
        }

        var keySet = new JsonWebKeySet();
        var jwk = PemHelper.PublicKeyFromPemString(platform.PublicKey);
        keySet.Keys.Add(jwk);
        return Ok(keySet);
    }
}