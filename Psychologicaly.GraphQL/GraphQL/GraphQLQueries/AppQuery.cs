using GraphQL.Resolvers;
using GraphQL.Types;
using Psychologicaly.GraphQL.GraphQL.GraphQLTypes;
using Psychologicaly.Repository.Models;
using Psychologicaly.Service;

namespace Psychologicaly.GraphQL.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IAppointmentReportService repository)
        {
            AddField(new FieldType
            {
                Name = "appointmentReports",
                Type = typeof(ListGraphType<AppointmentReportType>),
                Resolver = new AsyncFieldResolver<List<AppointmentReport>>(async context => await repository.GetAll())
            });
        }
    }
}
