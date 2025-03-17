using GraphQL.Types;
using Psychologicaly.GraphQL.GraphQL.GraphQLQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Psychologicaly.GraphQL.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
