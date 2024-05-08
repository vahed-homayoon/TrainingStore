namespace TrainingStore.Application.TeacherCourses.GetTeacherCourseList;

public sealed record TeacherCourseListResponse(
	int Id,
	string Name,
	string NationalCode,
	string FirstName,
	string SureName,
	DateTime StartDate,
	DateTime EndDate);


//public sealed record CourseScheduleResponse(
//	int Day,
//	TimeSpan FromHour,
//	TimeSpan ToHour);