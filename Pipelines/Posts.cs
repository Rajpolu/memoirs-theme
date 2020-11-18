using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Statiq.Memoirs.Models;
using Kontent.Statiq;
using MemoirsTheme.Pipelines;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;
using Statiq.SearchIndex;
using System.Linq;

namespace Kentico.Kontent.Statiq.Lumen.Pipelines
{
    public class Posts : Pipeline
    {
        public Posts(IDeliveryClient deliveryClient, SiteSettings site)
        {
            InputModules = new ModuleList{
                new Kontent<Post>(deliveryClient)
                    .OrderBy(Post.PostDateCodename, SortOrder.Descending)
                    .WithQuery(new DepthParameter(1), new IncludeTotalCountParameter()),
                /*new SetMetadata(nameof(Category), Config.FromDocument((doc, ctx) =>
                {
                    // Add category (useful for grouping)
                    return doc.AsKontent<Article>().SelectedCategory.System.Codename;
                })),
                new SetMetadata(nameof(Article.SelectedCategory), Config.FromDocument((doc, ctx) =>
                {
                    // Add some extra metadata to be used later for creating filenames
                    return doc.AsKontent<Article>().SelectedCategory;
                })),
                new SetMetadata(nameof(Tag), Config.FromDocument((doc, ctx) =>
                {
                    // Add tag (useful for grouping)
                    return doc.AsKontent<Article>().TagObjects.Select(t=>t.System.Codename);
                })),
                new SetMetadata(nameof(Article.TagObjects), Config.FromDocument((doc, ctx) =>
                {
                    // Add some extra metadata to be used later for creating filenames
                    return doc.AsKontent<Article>().TagObjects;
                })),*/
                new SetDestination(KontentConfig.Get((Post post)  => new NormalizedPath(post.Url))),
                new SetMetadata(SearchIndex.SearchItemKey, Config.FromDocument((doc,ctx)=>
                {
                    var post = doc.AsKontent<Post>();
                    return new LunrIndexDocItem(doc, post.Title, post.Body)
                    {
                        Description = post.MetadataMetaDescription,
                        Tags = string.Join(", ", post.Tags.Select( t => t.Name ))
                    };
                })),
            };

            ProcessModules = new ModuleList {
                new MergeContent(new ReadFiles(patterns: "Post.cshtml") ),
                new RenderRazor()
                    .WithViewData("Author", KontentConfig.Get<Post,Author>( p => p.Author.OfType<Author>().FirstOrDefault() ))
                    .WithViewData("SiteMetadata", site )
                    .WithModel(KontentConfig.As<Post>()),
                new KontentImageProcessor()
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}