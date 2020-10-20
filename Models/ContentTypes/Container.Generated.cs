// This code was generated by a kontent-generators-net tool 
// (see https://github.com/Kentico/kontent-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery.Abstractions;

namespace Kentico.Kontent.Statiq.Memoirs.Models
{
    public partial class Container
    {
        public const string Codename = "container";
        public const string ItemsCodename = "items";
        public const string MetadataMetaDescriptionCodename = "metadata__meta_description";
        public const string MetadataMetaKeywordsCodename = "metadata__meta_keywords";
        public const string MetadataMetaTitleCodename = "metadata__meta_title";
        public const string MetadataOgDescriptionCodename = "metadata__og_description";
        public const string MetadataOgImageCodename = "metadata__og_image";
        public const string MetadataOgTitleCodename = "metadata__og_title";
        public const string MetadataTwitterCardCodename = "metadata__twitter_card";
        public const string MetadataTwitterCreatorCodename = "metadata__twitter_creator";
        public const string MetadataTwitterImageCodename = "metadata__twitter_image";
        public const string MetadataTwitterSiteCodename = "metadata__twitter_site";
        public const string TitleCodename = "title";
        public const string UrlCodename = "url";

        public IEnumerable<object> Items { get; set; }
        public string MetadataMetaDescription { get; set; }
        public string MetadataMetaKeywords { get; set; }
        public string MetadataMetaTitle { get; set; }
        public string MetadataOgDescription { get; set; }
        public IEnumerable<IAsset> MetadataOgImage { get; set; }
        public string MetadataOgTitle { get; set; }
        public IEnumerable<IMultipleChoiceOption> MetadataTwitterCard { get; set; }
        public string MetadataTwitterCreator { get; set; }
        public IEnumerable<IAsset> MetadataTwitterImage { get; set; }
        public string MetadataTwitterSite { get; set; }
        public IContentItemSystemAttributes System { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}