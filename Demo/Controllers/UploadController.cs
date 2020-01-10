using Demo.Image;
using Demo.Models;
using Demo.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class UploadController : Controller
    {

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase imageFile)
        {
            var supportedFileTypes = new[] { ".png", ".gif", ".jpg", ".jpeg" };

            // File existence validation
            if (imageFile == null)
            {
                ViewBag.Message = "Select an image first";
                return View();
            }

            // File type Validation
            var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
            if (Array.IndexOf(supportedFileTypes, fileExtension) < 0)
            {
                ViewBag.Message = "File is invalid. Only upload .png, .gif, .jpg/.jpeg file";
                return View();
            }

            // Encoding image file to Base 64
            byte[] imageBase64 = Image.ImageEncoding.EncodingToBase64(imageFile);

            // Response from WS call in JSON format
            string response = WSCalls.UploadImage.Upload(imageBase64, imageFile.FileName);

            // Verification of response
            if (string.IsNullOrWhiteSpace(response) || response.Contains("error"))
            {
                ViewBag.Message = "Unable to upload image";
                return View();
            }

            List<Face> faces = JsonConvert.DeserializeObject<List<Face>>(response);

            // Editing original image for adding frame for each face
            Bitmap bitmapImageFile = ImageEditing.AddFrames(imageFile, faces);

            // Saving edited image and getting response
            string relativePath = "~/img/" + Path.GetFileName(imageFile.FileName);
            // Saving at ./img folder
            string failedSaving = ImageEditing.SaveImage(bitmapImageFile, Server.MapPath(relativePath));

            // Validation of successful saving
            if (failedSaving.Length > 0)
            {
                ViewBag.Message = failedSaving;
                return View();
            }

            ViewBag.Message = "File uploaded: " + imageFile.FileName;
            var imageViewModel = new ImageViewModel
            {
                Faces = faces,
                RelativePath = relativePath
            };
            return View(imageViewModel);
        }
    }
}