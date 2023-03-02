using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class ArtistController : Controller
  {

  [HttpGet("/records/[recordId]/artists/new")]
  public ActionResult New(int recordId)
  {
    Record record = Record.Find(recordId);
    return View(record);
  }
  
  [HttpGet("/record/{recordId}/artists/{artistId}")]
  public ActionResult Show(int recordId, int artistId)
  {
    Artist artist = Artist.Find(artistId);
    Record record = Record.Find(recordId);
    Dictionary<string, object> model = new Dictionary<string, object>();
    model.Add("artist", artist);
    model.Add("record", record);
    return View(model);
  }
  }
}