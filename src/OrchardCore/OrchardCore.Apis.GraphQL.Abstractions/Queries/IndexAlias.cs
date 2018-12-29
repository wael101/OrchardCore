using System;
using OrchardCore.ContentManagement;
using YesSql;

namespace OrchardCore.Apis.GraphQL.Queries
{
    public class IndexAlias
    {
        public string Alias { get; set; }

        public string Index { get; set; }

        public Func<IQuery<ContentItem>, IQuery<ContentItem>> With { get; set; }
    }
}