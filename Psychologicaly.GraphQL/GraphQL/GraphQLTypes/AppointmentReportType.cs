using GraphQL.Types;
using Psychologicaly.Repository.Models;

namespace Psychologicaly.GraphQL.GraphQL.GraphQLTypes
{
    public class AppointmentReportType : ObjectGraphType<AppointmentReport>
    {
        public AppointmentReportType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("ID của báo cáo cuộc hẹn.");
            Field(x => x.AppointmentId, nullable: true).Description("ID của cuộc hẹn.");
            Field(x => x.Star, nullable: true).Description("Số sao đánh giá.");
            Field(x => x.Description, nullable: true).Description("Mô tả đánh giá.");
            Field(x => x.CreateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian tạo báo cáo.");
            Field(x => x.UpdateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian cập nhật báo cáo.");

            // Liên kết với Appointment
            Field<AppointmentType>("appointment", resolve: context => context.Source.Appointment);
        }
    }
}
