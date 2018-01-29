using Emotion.Web.Models;
using Emotion.Web.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Emotion.Web.Controllers
{
    public class EmoUploaderController : Controller
    {
        String serverFolderPath;
        EmotionHelper emoHelper;
        String key;
        EmotionWebContext db = new EmotionWebContext();

        public EmoUploaderController()
        {
            key = ConfigurationManager.AppSettings["EMOTION_KEY"];
            serverFolderPath = ConfigurationManager.AppSettings["UPLOAD_DIR"];
            emoHelper = new EmotionHelper(key);
        }

        // GET: EmoUploader
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IndexAsync(HttpPostedFileBase file)
        {
            //if(file != null && file.ContentLength > 0)
            if(file?.ContentLength > 0)
            {
                var pictureName = Guid.NewGuid().ToString();
                pictureName += Path.GetExtension(file.FileName);

                var route = Server.MapPath(serverFolderPath);

                route = route + "/" + pictureName;
                file.SaveAs(route);

                var emoPicture = await emoHelper.DetectAndExtractFacesAsync(file.InputStream);

                emoPicture.Name = file.FileName;
                //emoPicture.Path = serverFolderPath + "/" + pictureName;
                emoPicture.Path = $"{serverFolderPath}/{pictureName}";

                

                try {
                    db.EmoPictures.Add(emoPicture);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Details", "EmoPictures", new { Id = emoPicture.Id });
                } catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                }

                
            }

            return View();
        }

    }
}