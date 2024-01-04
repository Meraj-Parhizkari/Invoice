using InvoiceSystem.Entities.App;
using InvoiceSystem.Services.Public;
using InvoiceSystem.ViewModels.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.App
{
    public interface IBlogService: IBaseService
    {
        #region Post
        Task<bool> EditPostAsync(PostViewModel viewModel);
        Task<bool> CreatePostAsync(Post post);
        Task<List<Post>> GetAllPostAsync();
        Task<Post> FindPostByIdAsync(int? id);
        //Task<bool> RemovePostAsync(int id);
        Task<bool> PostSlugExistAsync(string slug, int id);
        #endregion

        #region PostGroup
        Task<List<PostGroup>> GetAllPostGroupAsync();
        Task<bool> CreatePostGroupAsync(PostGroup postGroup);
        Task<PostGroup> FindPostGroupByIdAsync(int? id);
        Task<bool> EditPostGroupAsync(PostGroupViewModel viewModel);
        //Task<bool> RemovePostGroupAsync(int id);
        #endregion
    }
}
