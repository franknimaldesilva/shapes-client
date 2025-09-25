using IShapesClb;
using Microsoft.AspNetCore.Mvc;
namespace Shapes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShapeController : ControllerBase
  {
    private readonly IComputeShape _computeShape;
    public ShapeController(IComputeShape computeShape)
    {
      this._computeShape = computeShape;
    }

    [HttpGet]
    public ActionResult Get()
    {
      try
      {
        // the commmand is the user input 
        if (Request.Headers.ContainsKey("command"))
        {
          return Ok(this._computeShape.GetShapeCoordinates(Request.Headers["command"].ToString()));
        }
        return BadRequest("missing command");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

  }
}
