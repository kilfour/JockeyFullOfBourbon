using HorsesForCourses.Domain.Courses.TimeSlots;

namespace HorsesForCourses.Tests;

public class CoachIsSuitableTests : DomainTest
{
    [Fact]
    public void Coach_Is_Suitable_WHen_Skills_match()
    {
        var coach = GetCoach();

        var course = GetCourse();

        Assert.True(coach.IsSuitableFor(course));
    }

    [Fact]
    public void Coach_Is_Not_Suitable_WHen_Skills_Doesnt_match()
    {
        var coach = GetCoach();

        var course = GetCourse(requiredSkills: ["WO"]);

        Assert.False(coach.IsSuitableFor(course));
    }
}