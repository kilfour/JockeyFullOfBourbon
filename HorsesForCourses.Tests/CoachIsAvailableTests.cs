using HorsesForCourses.Domain.Courses.TimeSlots;

namespace HorsesForCourses.Tests;

public class CoachIsAvailableTests : DomainTest
{
    [Fact]
    public void Coach_Is_Available_For_Course_When_No_Courses_Assigned()
    {
        var coach = GetCoach();

        var course = GetCourse();

        Assert.True(coach.IsAvailableFor(course));
    }

    [Fact]
    public void Coach_Is_Available_For_Course_When_No_Course_Overlaps()
    {
        var coach = GetCoach();

        GetCourse().AssignCoach(coach);

        var availableForCourse = GetCourse(timeSlots: [((CourseDay.Thursday, 13, 15))]);

        Assert.True(coach.IsAvailableFor(availableForCourse));
    }

    [Fact]
    public void Coach_Is_Not_Available_When_Course_Overlaps()
    {
        var coach = GetCoach();

        GetCourse().AssignCoach(coach);

        var availableForCourse = GetCourse(timeSlots: [((CourseDay.Monday, 13, 15))]);

        Assert.False(coach.IsAvailableFor(availableForCourse));
    }
}