using System;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using OxiRNA.Models;
using OxiRNA.Settings;

namespace OxiRNA.Controllers {
  public class HomeController : Controller {
    public IActionResult Index () {
      return View ();
    }

    public IActionResult Browse () {
      return View ();
    }

    public IActionResult SubmitData () {
      return View ();
    }

    public IActionResult Tutorial () {
      return View ();
    }

    public IActionResult SearchResults ([FromForm]string SimpleSearchInput) {
      string url = string.IsNullOrEmpty(SimpleSearchInput) ? "/api/sequences?" : "/api/sequences?anything=" + HttpUtility.UrlPathEncode(SimpleSearchInput);
     
      return View ( new URLModel (url));
    }

    public IActionResult AdvanceSearch ([FromForm] string[] nots, [FromForm] string[] selects, [FromForm] string[] inputs) {
      Dictionary<string, string> selectsNames = new Dictionary<string, string>();
      selectsNames.Add("Sequence name", "name");
      selectsNames.Add("Genbank id", "genbank");
      selectsNames.Add("Journal", "journal");
      selectsNames.Add("Article", "article");
      selectsNames.Add("Taxon", "taxon");
      selectsNames.Add("Species", "species");
  
      string url = "";   
      for (int i = 0; i < selects.Length; i++ ){
        url += (url == "") ? "/api/sequences?" : "&";
        url += selectsNames[ selects[i] ] + "=" + HttpUtility.UrlPathEncode(inputs[i]) + "&" + selectsNames[ selects[i] ] + "="; 
        url += nots[i] == "off" ? "true" : "false";
      }
    
      URLModel result = new URLModel (url);
      return View ("SearchResults", result);
    }

    public IActionResult Login () {
      return View ();
    }

    public IActionResult SubmitMessage () {
      return View ();
    }
    public IActionResult SubmitFail () {
      return View ();
    }

    [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error () {
      return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}