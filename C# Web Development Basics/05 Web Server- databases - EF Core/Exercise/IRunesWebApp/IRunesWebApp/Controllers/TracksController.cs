namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Linq;
    using System.Web;

    public class TracksController : BaseController
    {
        public IHttpResponse CreateGet(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            this.ViewBag["albumId"] = request.QueryData["albumId"].ToString();
            return this.View("Tracks/Create");
        }

        public IHttpResponse CreatePost(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            var trackName = request.FormData["name"].ToString().Trim().Replace("+", " ");
            var decodedName = HttpUtility.UrlDecode(trackName);

            var linkToTrack = request.FormData["link"].ToString().Trim();
            var decodedUrl = HttpUtility.UrlDecode(linkToTrack);

            var price = request.FormData["price"].ToString();
            var decimalPrice = decimal.Parse(price);

            var albumId = request.QueryData["albumId"].ToString();
            var album = this.DbContext.Albums.FirstOrDefault(x => x.Id == albumId);

            if (string.IsNullOrWhiteSpace(trackName) || trackName.Length < 2)
            {
                return this.BadRequestError("Track name should be more than 2 characters!");
            }

            if (string.IsNullOrWhiteSpace(decodedUrl))
            {
                return this.BadRequestError("Track should have valid Url to its source!");
            }

            if (decodedUrl.Contains("youtube.com"))
            {
                decodedUrl = YouTubeUrlAdjuster(decodedUrl);
            }
            

            if (decimalPrice < 0.1m || decimalPrice > 100.0m || string.IsNullOrEmpty(price.ToString()))
            {
                return this.BadRequestError("Price should be in the range of 0.1 to 100!");
            }

            var track = new Track
            {
                Name = decodedName,
                Link = decodedUrl,
                Price = decimalPrice,
                Album = album
            };

            this.ViewBag["albumId"] = albumId;

            try
            {
                this.DbContext.Tracks.Add(track);
                this.DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            return new RedirectResult($"/albums/details?id={albumId}");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            var trackId = request.QueryData["trackId"].ToString();
            var albumId = request.QueryData["albumId"].ToString(); 
            this.ViewBag["trackId"] = trackId;
            this.ViewBag["albumId"] = albumId;

            var track = this.DbContext.Tracks.FirstOrDefault(x => x.Id == trackId);

            this.ViewBag["trackName"] = track.Name;
            this.ViewBag["trackPrice"] = track.Price.ToString();
            this.ViewBag["trackLink"] = track.Link;

            return this.View("Tracks/Details");
        }

        //Methd for embed youtube video via changing the url.
        private string YouTubeUrlAdjuster(string decodedUrl)
        {
            string viewPattern = "embed/";
            string result = decodedUrl.Replace("watch?v=", viewPattern);
            if (result.Contains('&'))
            {
                int queryDelimeterPosition = result.IndexOf('&');
                result = result.Remove(queryDelimeterPosition, result.Length - queryDelimeterPosition);
            }

            //Initial Url https://www.youtube.com/watch?v=aalfNIvQaJ4
            //desired result https://www.youtube.com/embed/aalfNIvQaJ4 
            return result;
        }
    }
}
