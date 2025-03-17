using GraphQL.Types;
using Psychologicaly.Repository.Models;

namespace Psychologicaly.GraphQL.GraphQL.GraphQLTypes
{
    public class AppointmentType : ObjectGraphType<Appointment>
    {
        public AppointmentType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("ID của cuộc hẹn.");
            Field(x => x.Title, nullable: true).Description("Tiêu đề cuộc hẹn.");
            Field(x => x.Date, nullable: true, type: typeof(DateTimeGraphType)).Description("Ngày diễn ra cuộc hẹn.");
            Field(x => x.LinkMeet, nullable: true).Description("Liên kết cuộc họp.");
            Field(x => x.Status, nullable: true).Description("Trạng thái cuộc hẹn.");
            Field(x => x.IsBooked, nullable: true).Description("Trạng thái đặt cuộc hẹn.");
            Field(x => x.Star, nullable: true).Description("Số sao đánh giá.");
            Field(x => x.Comment, nullable: true).Description("Bình luận.");
            Field(x => x.Note, nullable: true).Description("Ghi chú.");
            Field(x => x.CreateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian tạo.");
            Field(x => x.UpdateAt, nullable: true, type: typeof(DateTimeGraphType)).Description("Thời gian cập nhật.");

            Field<ListGraphType<AppointmentReportType>>("appointment", resolve: context => context.Source.AppointmentReports);

        }
    }
}
