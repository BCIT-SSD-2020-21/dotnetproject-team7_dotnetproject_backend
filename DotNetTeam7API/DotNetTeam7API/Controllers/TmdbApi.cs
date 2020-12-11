using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using demo.MVC.Class;
using System.Text;
using DotNetTeam7API.Models;
using static DotNetTeam7API.Class.HelperClass;

namespace DotNetTeam7API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmdbApi : ControllerBase
    {
        public object ViewBag { get; private set; }

        // GET
        public ActionResult Index(string peopleName, int? page)
        {
            if (page != null)
                CallAPI(peopleName, Convert.ToInt32(page));

            Models.TheMovieDb theMovieDb = new Models.TheMovieDb();
            theMovieDb.searchText = peopleName;
            return View(theMovieDb);
        }

        private ActionResult View(TheMovieDb theMovieDb)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Index(Models.TheMovieDb theMovieDb, string searchText)
        {
            if (ModelState.IsValid)
            {
                CallAPI(searchText, 0);
            }
            return View(theMovieDb);
        }

        public void CallAPI(string searchText, int page)
        {
            int pageNo = Convert.ToInt32(page) == 0 ? 1 : Convert.ToInt32(page);

            /*Calling API https://developers.themoviedb.org/3/search/search-people */
            string apiKey = "3356865d41894a2fa9bfa84b2b5f59bb";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/search/person?api_key=" + apiKey + "&language=en-US&query=" + searchText + "&page=" + pageNo + "&include_adult=false") as HttpWebRequest;

            string apiResponse = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                            | SecurityProtocolType.Tls
                            | SecurityProtocolType.Tls11
                            | SecurityProtocolType.Tls12;
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            /*End*/

            /*http://json2csharp.com*/
            ResponseSearchPeople rootObject = JsonConvert.DeserializeObject<ResponseSearchPeople>(apiResponse);

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"resultDiv\"><p>Names</p>");
            foreach (Result result in rootObject.results)
            {
                string image = result.profile_path == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + result.profile_path;
                string link = Url.Action("GetPerson", "TmdbApi", new { id = result.id });

                sb.Append("<div class=\"result\" resourceId=\"" + result.id + "\">" + "<a href=\"" + link + "\"><img src=\"" + image + "\" />" + "<p>" + result.name + "</a></p></div>");
            }

            ViewBag.Result = sb.ToString();

            int pageSize = 20;
            PagingInfo pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = pageNo;
            pagingInfo.TotalItems = rootObject.total_results;
            pagingInfo.ItemsPerPage = pageSize;
            ViewBag.Paging = pagingInfo;
        }

        public ActionResult GetPerson(int id)
        {
            /*Calling API https://developers.themoviedb.org/3/people */
            string apiKey = "3356865d41894a2fa9bfa84b2b5f59bb";
            HttpWebRequest apiRequest = WebRequest.Create("https://api.themoviedb.org/3/person/" + id + "?api_key=" + apiKey + "&language=en-US") as HttpWebRequest;

            string apiResponse = "";
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }
            /*End*/

            /*http://json2csharp.com*/
            ResponsePerson rootObject = JsonConvert.DeserializeObject<ResponsePerson>(apiResponse);
            TheMovieDb theMovieDb = new TheMovieDb();
            theMovieDb.name = rootObject.name;
            theMovieDb.biography = rootObject.biography;
            theMovieDb.birthday = rootObject.birthday;
            theMovieDb.place_of_birth = rootObject.place_of_birth;
            theMovieDb.profile_path = rootObject.profile_path == null ? Url.Content("~/Content/Image/no-image.png") : "https://image.tmdb.org/t/p/w500/" + rootObject.profile_path;
            theMovieDb.also_known_as = string.Join(", ", rootObject.also_known_as);

            return View(theMovieDb);
        }
    }
}
