using HorsesForCourses.Domain.Coaches;
using HorsesForCourses.Domain.Courses;
using static HorsesForCourses.Tests.TestHelpers;

namespace HorsesForCourses.Tests.CoachTests;

public class CoachSuitabilityTests
{
    [Fact]
    public void Coach_With_AllRequiredSkills_IsSubitable()
    {
        Coach coach = CreateCoach(["C#", "SQL"]);
        Course course = CreateConfirmedCourse(requiredSkills: ["C#", "SQL"]);
        Assert.True(coach.IsSuitableFor(course));
    }

    [Fact]
    public void Coach_With_OnlySomeRequiredSkills_IsNotSuitable()
    {
        Coach coach = CreateCoach(["C#"]);
        Course course = CreateConfirmedCourse(requiredSkills: ["C#", "SQL"]);
        Assert.False(coach.IsSuitableFor(course));
    }

    [Fact]
    public void Coach_With_NoMatchingSkills_IsNotSuitable()
    {
        Coach coach = CreateCoach(["React"]);
        Course course = CreateConfirmedCourse(requiredSkills: ["C#", "SQL"]);
        Assert.False(coach.IsSuitableFor(course));
    }

    [Fact]
    public void Coach_With_ExtraSkills_What_IsRequired_IsStillSuitable()
    {
        Coach coach = CreateCoach(["C#", "SQL", "Docker"]);
        Course course = CreateConfirmedCourse(requiredSkills: ["C#", "SQL"]);
        Assert.True(coach.IsSuitableFor(course));
    }
    [Fact]
    public void Coach_IsSuitable_When_CourseRequiredsNoSkills()
    {
        Coach coach = CreateCoach(["C#"]);
        Course course = CreateConfirmedCourse();
        Assert.True(coach.IsSuitableFor(course));
    }
}