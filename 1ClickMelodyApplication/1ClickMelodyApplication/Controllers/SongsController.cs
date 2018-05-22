using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using _1ClickMelodyApplication.Models;

namespace _1ClickMelodyApplication.Controllers
{
    public class SongsController : Controller
    {

        string ApiKey = "da2ed40303aa35d2baa0d3c87935130b";
        string url = "https://api.musixmatch.com/ws/1.1/";


        SongsApiController api = new SongsApiController();

        public ActionResult Index(string search)
        {
            url = string.Format("{0}track.search?q={1}&quorum_factor=1&apikey={2}", url, search, ApiKey);

            string res = api.RunQuery(url);

            dynamic jsonresults = (JObject)JsonConvert.DeserializeObject(res);
            var trackList = jsonresults.message.body.track_list;

            List<Song> listOfSongs = new List<Song>();
            int trackNo = 0;
            foreach (var arr in trackList)
            {
                foreach (var track in trackList[trackNo])
                {
                    var trackValue = track.Value;

                    Song song = new Song()
                    {
                        trackId = trackValue.track_id,
                        trackName = trackValue.track_name,
                        trackRating = trackValue.track_rating,
                        trackLength = trackValue.track_length,
                        albumId = trackValue.album_id,
                        albumName = trackValue.album_name,
                        lyricsId = trackValue.lyrics_id
                    };
                    listOfSongs.Add(song);
                }
                trackNo += 1;
            }
            return View(listOfSongs);
        }

        public ActionResult Lyrics(int trackId)
        {
        https://api.musixmatch.com/ws/1.1/=94117509&apikey=da2ed40303aa35d2baa0d3c87935130b
            url = string.Format("{0}track.lyrics.get?track_id={1}&apikey={2}", url, trackId, ApiKey);

            string res = api.RunQuery(url);

            dynamic jsonresults = (JObject)JsonConvert.DeserializeObject(res);
            var lyricsObj = jsonresults.message.body.lyrics; //lyricsObj.lyrics_body have lyrics

            return Json(lyricsObj.lyrics_body, JsonRequestBehavior.AllowGet);
        }
    }
}
