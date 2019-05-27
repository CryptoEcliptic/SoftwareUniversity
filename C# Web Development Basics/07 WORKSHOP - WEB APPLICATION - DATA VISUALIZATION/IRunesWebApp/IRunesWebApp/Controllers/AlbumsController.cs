namespace IRunesWebApp.Controllers
{
    using IRunesWebApp.Models;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    public class AlbumsController : BaseController
    {
        private const decimal DiscountPercentCoeff = 0.87m;

        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            else
            {
                var albums = this.DbContext.Albums.ToList();
                var albumsHtml = new StringBuilder();

                if (albums.Count == 0)
                {
                    albumsHtml.AppendLine("<h3>There are currently no albums.</h3>"); 
                }

                else
                {
                    int number = 1;
                    foreach (var album in albums)
                    {
                        var albumHtml = $"<tr><th>{number++}.</th><th><a href=\"/albums/details?id={album.Id}\" style=\"color: black\">{album.Name}</a></th></tr>";
                        albumsHtml.Append(albumHtml);
                    }
                }

                this.ViewBag["albumsList"] = albumsHtml.ToString();
            }
           
            return this.View("All");
        }

        public IHttpResponse CreateGet(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            return this.View("Create");
        }

        public IHttpResponse CreatePost(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            var albumName = request.FormData["name"].ToString().Trim().Replace("+", " ");
            var coverPhotoUrl = request.FormData["cover"].ToString().Trim();
            var decodedUrl = HttpUtility.UrlDecode(coverPhotoUrl);

            if (string.IsNullOrWhiteSpace(albumName) || albumName.Length < 2 || string.IsNullOrEmpty(albumName))
            {
                return this.BadRequestError("Album name should be more than 2 characters!");
            }

           
            if (string.IsNullOrWhiteSpace(decodedUrl) || string.IsNullOrEmpty(decodedUrl))
            {
                return this.BadRequestError("Album should have valid Url to a cover photo!");
            }

            var album = new Album
            {
                Name = albumName,
                Cover = decodedUrl,         
            };

            try
            {
                this.DbContext.Albums.Add(album);
                this.DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            return new RedirectResult("/albums/all");
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            var query = request.QueryData.FirstOrDefault(x => x.Key == "id");
            var albumIdValue = query.Value.ToString();

            var album = this.DbContext.Albums.FirstOrDefault(x => x.Id == albumIdValue);
            var albumCover = album.Cover;
            var albumName = album.Name;
            var albumPrice = album.Tracks.Sum(x => x.Price) * DiscountPercentCoeff;
            var albumId = album.Id;
            var songsList = album.Tracks.ToList();


            this.ViewBag["albumCover"] = albumCover;
            this.ViewBag["albumName"] = albumName;
            this.ViewBag["albumPrice"] = albumPrice.ToString("F2");
            this.ViewBag["albumId"] = albumId;
           var outputHtml = new StringBuilder();

            if (songsList.Count == 0)
            {
                outputHtml.AppendLine("<h1>There are currently no songs in this album.</h1>");
            }

            else
            {
                int count = 1;
                foreach (var song in songsList)
                {
                    var songHtml = $" <li><a href=\"/tracks/details?albumId={album.Id}&trackId={song.Id}\">{count++}.{song.Name}</a></li>";
                    outputHtml.AppendLine(songHtml);
                }
            }
           
            this.ViewBag["songsList"] = outputHtml.ToString();

            return this.View("Details");
        }
    }
}
