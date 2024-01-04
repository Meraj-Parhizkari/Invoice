using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceSystem.Areas.Identity;
using InvoiceSystem.Common.Public;
using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.Entities.App;
using InvoiceSystem.Services.Contracts.App;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using InvoiceSystem.ViewModels.Public;
using InvoiceSystem.ViewModels.App;

namespace InvoiceSystem.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {
        #region Properties
        private ResponseJsonViewModel responseJsonViewModel { get; set; }
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _hostingEnvironment;
        #endregion

        #region    ctor
        public BlogController(IBlogService BlogService,
            IMapper mapper,
            IHostingEnvironment hostingEnvironment)
        {
            _blogService = BlogService;

            _mapper = mapper;
            _mapper.CheckArgumentIsNull(nameof(_mapper));

            _hostingEnvironment = hostingEnvironment;

            responseJsonViewModel = new ResponseJsonViewModel();
        }
        #endregion

        #region Posts
        #region PostIndex
        public async Task<IActionResult> PostIndex()
        {
            var posts = await _blogService.GetAllPostAsync();
            var postGroupViewModels = _mapper.Map<List<PostViewModel>>(posts);
            
            return View(postGroupViewModels);
        }
        #endregion

        #region PostCreate
        public async Task<IActionResult> PostCreate()
        {
            //ViewBag.Languages = new SelectList(PublicMethods.Languages().Select(x => new { Id = x.Key, Name = x.Value }), "Id", "Name", 1);
            ViewBag.PostGroups = new SelectList((await _blogService.GetAllPostGroupAsync())
                .Select(x => new
                {
                    id = x.Id,
                    text = x.Title,
                }).ToList()
                , "id", "text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreate(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<Post>(viewModel);

                #region PostPostGroups
                post.PostPostGroups = new List<PostPostGroup>();
                foreach (var item in viewModel.PostGroupsIds)
                {
                    post.PostPostGroups.Add(new PostPostGroup
                    {
                        PostGroupId = item
                    });
                }
                #endregion

                #region Upload Background & Thumbnail
                if (viewModel.ThumbnailFile != null && viewModel.ThumbnailFile.Length > 0)
                {
                    var file = Request.Form.Files[0];
                    var filename = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(file.FileName);
                    var path = Path.Combine(_hostingEnvironment.WebRootPath,
                                            PublicMethods.Paths.PostThumbnailImages,
                                            filename);
                    try
                    {

                        using (var stream = System.IO.File.Create(path))
                        {
                            await file.CopyToAsync(stream);

                            viewModel.BackgroundImage = filename;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                if (viewModel.ThumbnailFile != null && viewModel.ThumbnailFile.Length > 0)
                {
                    var file = Request.Form.Files[0];
                    var filename = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(file.FileName);
                    var path = Path.Combine(_hostingEnvironment.WebRootPath,
                                            PublicMethods.Paths.PostImages,
                                            filename);
                    try
                    {

                        using (var stream = System.IO.File.Create(path))
                        {
                            await file.CopyToAsync(stream);

                            viewModel.Image = filename;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                #endregion

                if (post.ExpiredDatetime != null)
                {
                    post.ExpiredDatetime = Convert.ToDateTime(Convert.ToDateTime(post.ExpiredDatetime).ToString("yyyy/MM/dd 23:59:59"));

                }

                var result = await _blogService.CreatePostAsync(post);

                if (result)
                {
                    return RedirectToAction(nameof(PostIndex));
                }
            }
            else
            {

            }

            ViewBag.PostGroups = new SelectList((await _blogService.GetAllPostGroupAsync())
                .Select(x => new
                {
                    id = x.Id,
                    text = x.Title,
                }).ToList()
                , "id", "text", viewModel.PostGroupsIds);

            return View(viewModel);
        }
        #endregion

        #region PostDelete
        [HttpPost]
        public async Task<JsonResult> PostDelete(int id)
        {
            var result = await _blogService.RemoveAsync<Post>(id);
            responseJsonViewModel.Status = result ? System.Net.HttpStatusCode.OK: System.Net.HttpStatusCode.InternalServerError;

            return Json(responseJsonViewModel);
        }
        #endregion

        #region PostEdit
        public async Task<IActionResult> PostEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postViewModel = _mapper.Map<PostViewModel>(await _blogService.FindPostByIdAsync(id));
            if (postViewModel == null)
            {
                return NotFound();
            }

            ViewBag.PostGroups = new SelectList((await _blogService.GetAllPostGroupAsync())
                .Select(x => new
                {
                    id = x.Id,
                    text = x.Title,
                }).ToList()
                , "id", "text", postViewModel.PostGroupsIds);

            return View(postViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostEdit(PostViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                #region Upload Background & Thumbnail
                if (viewModel.ThumbnailFile != null && viewModel.ThumbnailFile.Length > 0)
                {
                    var file = Request.Form.Files[0];
                    var filename = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(file.FileName);
                    var path = Path.Combine(_hostingEnvironment.WebRootPath,
                                            PublicMethods.Paths.PostThumbnailImages,
                                            filename);
                    try
                    {

                        using (var stream = System.IO.File.Create(path))
                        {
                            await file.CopyToAsync(stream);

                            viewModel.BackgroundImage = filename;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                if (viewModel.ThumbnailFile != null && viewModel.ThumbnailFile.Length > 0)
                {
                    var file = Request.Form.Files[0];
                    var filename = Guid.NewGuid().ToString().Replace("-", string.Empty) + Path.GetExtension(file.FileName);
                    var path = Path.Combine(_hostingEnvironment.WebRootPath,
                                            PublicMethods.Paths.PostImages,
                                            filename);
                    try
                    {

                        using (var stream = System.IO.File.Create(path))
                        {
                            await file.CopyToAsync(stream);

                            viewModel.Image = filename;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                #endregion

                if (viewModel.ExpiredDatetime != null)
                {
                    viewModel.ExpiredDatetime = Convert.ToDateTime(Convert.ToDateTime(viewModel.ExpiredDatetime).ToString("yyyy/MM/dd 23:59:59"));

                }

                var result = await _blogService.EditPostAsync(viewModel);

                if (result)
                {
                    return RedirectToAction(nameof(PostIndex));
                }
            }
            else
            {

            }

            ViewBag.PostGroups = new SelectList((await _blogService.GetAllPostGroupAsync())
                .Select(x => new
                {
                    id = x.Id,
                    text = x.Title,
                }).ToList()
                , "id", "text", viewModel.PostGroupsIds);

            return View(viewModel);
        }
        #endregion

        #region SlugExist
        [HttpPost]
        public async Task<JsonResult> SlugExists(string Slug, int Id = 0)
        {
            var isExists = await _blogService.PostSlugExistAsync(Slug, Id);

            return Json(isExists);
        }
        #endregion
        #endregion

        #region PostGroups        
        #region PostGroupIndex
        public async Task<IActionResult> PostGroupIndex()
        {
            var postGroups = await _blogService.GetAllPostGroupAsync();
            var postGroupViewModels = _mapper.Map<List<PostGroupViewModel>>(postGroups);

            return View(postGroupViewModels);
        }
        #endregion

        #region PostGroupCreate
        public IActionResult PostGroupCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostGroupCreate(PostGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var postGroup = _mapper.Map<PostGroup>(viewModel);
                var result = await _blogService.CreatePostGroupAsync(postGroup);

                if (result)
                {
                    return RedirectToAction(nameof(PostGroupIndex));
                }
            }
            else
            {

            }
            return View(viewModel);
        }
        #endregion
        #region PostGroupEdit
        public async Task<IActionResult> PostGroupEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postGroupViewModel = _mapper.Map<PostGroupViewModel>(await _blogService.FindPostGroupByIdAsync(id));

            if (postGroupViewModel == null)
            {
                return NotFound();
            }

            return View(postGroupViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostGroupEdit(PostGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _blogService.EditPostGroupAsync(viewModel);

                if (result)
                {
                    return RedirectToAction(nameof(PostGroupIndex));
                }
            }
            else
            {

            }
            return View(viewModel);
        }
        #endregion

        #region PostDelete
        [HttpPost]
        public async Task<JsonResult> PostGroupDelete(int id)
        {
            var result = await _blogService.RemoveAsync< PostGroup>(id);
            responseJsonViewModel.Status = result ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.InternalServerError;

            return Json(responseJsonViewModel);
        }
        #endregion
        #endregion
    }
}