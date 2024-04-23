using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Domain.Bookings;

public static class CourseErrors
{
    public static readonly Error NotFound = new(
        "Booking.Found",
        "درس مورد نظر وجود ندارد");
}
