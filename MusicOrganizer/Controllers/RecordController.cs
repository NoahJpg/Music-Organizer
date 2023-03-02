using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class RecordController : Controller
  {

    [HttpGet("/records")]
    public ActionResult Index()
    {
      List<Record> allRecords = Record.GetAll();
      return View(allRecords);
    }

    [HttpGet("/record/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/records")]
    public ActionResult Create(string recordName)
    {
      Record newRecord = new Record(recordName);
      return RedirectToAction("Index");
    }

    [HttpGet("/records/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Record selectedRecord = Record.Find(id);
      List<Artist> recordArtist = selectedRecord.Artists;
      model.Add("record", selectedRecord);
      model.Add("artists", recordArtist);
      return View(model);
    }

    [HttpPost("/records/{recordId}/items")]
    public ActionResult Create(int recordId, string artistName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Record foundRecord = Record.Find(recordId);
      Artist newArtist = new Artist(artistName);
      foundRecord.AddItem(newArtist);
      List<Artist> recordArtists = foundRecord.Artists;
      model.Add("artists", recordArtists);
      model.Add("records", foundRecord);
      return View("Show", model);
    }

  }
}