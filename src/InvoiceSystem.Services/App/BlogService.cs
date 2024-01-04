using AutoMapper;
using InvoiceSystem.Common.GuardToolkit;
using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.App;

using InvoiceSystem.Services.Contracts.App;
using InvoiceSystem.Services.Public;
using InvoiceSystem.ViewModels.App;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.App
{
    public class BlogService :BaseService, IBlogService
    {
        
        #region Ctor
        public BlogService(IUnitOfWork uow,IMapper mapper):base(uow,mapper)
        {
            _posts = _uow.Set<Post>();
            _postGroups = _uow.Set<PostGroup>();
        }
        #endregion

        #region Post

        #region CreatePostAsync
        public async Task<bool> CreatePostAsync(Post post)
        {
            await _posts
                .AddAsync(post);

            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion

        #region EditPostAsync
        public async Task<bool> EditPostAsync(PostViewModel viewModel)
        {
            var post = await _posts
                .Include(x=>x.PostPostGroups)
                .FirstAsync(x => x.Id == viewModel.Id);
            _mapper.Map<PostViewModel,Post>(viewModel,post);

            #region PostPostGroups
            post.PostPostGroups?.Clear();
            post.PostPostGroups = new List<PostPostGroup>();
            foreach (var item in viewModel.PostGroupsIds)
            {
                post.PostPostGroups.Add(new PostPostGroup
                {
                    PostGroupId = item
                });
            }
            #endregion

            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion

        #region FindPostByIdAsync
        public async Task<Post> FindPostByIdAsync(int? id)
        {
            var post = await _posts
                .Include(x => x.PostPostGroups)
                .ThenInclude(x => x.PostGroup)
                .FirstOrDefaultAsync(x=>x.Id == id);

            return post;
        }
        #endregion

        //#region FindPostByIdAsync
        //public async Task<bool> RemovePostAsync(int id)
        //{
        //    var post = await _posts
        //        .FirstOrDefaultAsync(x=>x.Id == id);
            
        //    _posts.Remove(post);

        //    var result = await _uow.SaveChangesAsync();

        //    return result>0;
        //}
        //#endregion

        #region GetAllPostAsync
        public async Task<List<Post>> GetAllPostAsync()
        {
            var posts = await _posts
                .Include(x => x.PostPostGroups)
                .ThenInclude(x => x.PostGroup)
                .ToListAsync();

            return posts;
        }
        #endregion

        #region PostSlugExistAsync
        public async Task<bool> PostSlugExistAsync(string slug, int id)
        {
            if (id > 0)
            {
                var post = await _posts.FirstOrDefaultAsync(x => x.Id == id);
                if (post.Slug != slug)
                {
                    return (!await _posts.AnyAsync(x => x.Slug == slug 
                    //&& !x.IsDeleted
                    ));
                }
                if (post.Slug == slug)
                    return true;
            }
            return ! await _posts.AnyAsync(x => x.Slug == slug);
        }
        #endregion
        #endregion

        #region PostGroup
        #region CreatePostGroupAsync
        public async Task<bool> CreatePostGroupAsync(PostGroup postGroup)
        {
            postGroup.LanguageId = 1;
            await _postGroups
                .AddAsync(postGroup);

            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion

        #region EditPostGroupAsync
        public async Task<bool> EditPostGroupAsync(PostGroupViewModel viewModel)
        {
            var PostGroup = await _postGroups
                .FirstAsync(x => x.Id == viewModel.Id);

            _mapper.Map<PostGroupViewModel, PostGroup>(viewModel, PostGroup);

            var result = await _uow.SaveChangesAsync();

            return result > 0;
        }
        #endregion

        #region FindPostGroupByIdAsync
        public async Task<PostGroup> FindPostGroupByIdAsync(int? id)
        {
            var PostGroup = await _postGroups
                .FirstOrDefaultAsync(x => x.Id == id);

            return PostGroup;
        }
        #endregion

        #region GetAllPostGroupAsync
        public async Task<List<PostGroup>> GetAllPostGroupAsync()
        {
            var postGroups = await _postGroups
                .ToListAsync();

            return postGroups;
        }
        #endregion

        //#region FindPostGroupByIdAsync
        //public async Task<bool> RemovePostGroupAsync(int id)
        //{
        //    var PostGroup = await _postGroups
        //        .FirstOrDefaultAsync(x => x.Id == id);

        //    _postGroups.Remove(PostGroup);

        //    var result = await _uow.SaveChangesAsync();

        //    return result > 0;
        //}
        //#endregion
        #endregion
    }
}
