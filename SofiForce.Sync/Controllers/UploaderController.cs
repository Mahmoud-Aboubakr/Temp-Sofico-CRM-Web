﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Models;
using Microsoft.AspNetCore.Authorization;


namespace SofiForce.Sync.Controllers
{
    [Route("api/[controller]")]
    public class UploaderController : BaseController
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
      
        public UploaderController(IHttpContextAccessor contextAccessor, IWebHostEnvironment env, IConfiguration configuration) : base(contextAccessor)
        {
            this._env = env;
            this._configuration = configuration;
        }

        [HttpPost("add")]
        public  IActionResult Add()
        {


            string webRootPath = _env.WebRootPath;


            ResponseModel<FileModel> responseModel = new ResponseModel<FileModel>();

            try
            {

                var _root = _configuration["files"];
                var _url = _configuration["filesUrl"];
                var _dir = DateTime.Now.ToString("yyyyMMdd")+"/";

                var _pathToSave = Path.Combine(webRootPath, _root, _dir);

                if (!Directory.Exists(_pathToSave))
                {
                    Directory.CreateDirectory(_pathToSave);
                }


                IFormFile file= Request.Form.Files[0];
                if (file == null)
                {
                    responseModel.Succeeded = false;
                    responseModel.Message = "Invalid Model";
                }

                var UUID = Guid.NewGuid().ToString();
                var fileName = UUID + Path.GetExtension(file.FileName);

                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(_pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    responseModel.Data= new FileModel() { Directory= Path.Combine(_root), FileName= Path.Combine( _dir, fileName), FileUrl= Path.Combine( _url, _dir, fileName), FileSize=file.Length/1024};
                }
                else
                {
                    responseModel.Succeeded=false;
                    responseModel.Message = "Invalid Model";
                }
            }
            catch (Exception ex)
            {
                responseModel.Succeeded = false;
                responseModel.Message = ex.Message;;
            }

            return Ok(responseModel);
        }
    }


}