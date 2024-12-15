using Microsoft.AspNetCore.Mvc;
using RuculaUp.UI.Server;

namespace RuculaUp.WebApi.Controller;

public class UIController : ControllerBase
{
  [HttpGet("ui")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IActionResult Get(string  window)
  {
    var result = Server.GetWindow(window);

    Response.Headers.ContentType = "application/json";
    return  Ok(result);
  }
}
