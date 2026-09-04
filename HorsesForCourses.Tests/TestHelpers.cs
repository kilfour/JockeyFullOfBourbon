using HorsesForCourses.Domain.Coaches;
using HorsesForCourses.Domain.Courses;
using HorsesForCourses.Domain.Courses.TimeSlots;

namespace HorsesForCourses.Tests;

public abstract class TestHelpers
{
    protected static Coach CreateCoach(string[]? skills = null)
    {
        Coach coach = Coach.Create("Mark", "coach@JockeyFullOfBourbon.com");
        if (skills?.Length > 0) coach.UpdateSkills(skills);
        return coach;
    }
    protected static Course CreateConfirmedCourse(DateOnly? start = null, DateOnly? end = null, CourseDay day = CourseDay.Monday, int startHour = 9, int endHour = 10, string[]? requiredSkills = null)
    {
        Course course = Course.Create("Domain Unit Testing", start ?? new DateOnly(2026, 1, 5), end ?? new DateOnly(2026, 1, 30));
        if (requiredSkills?.Length > 0) course.UpdateRequiredSkills(requiredSkills);
        course.UpdateTimeSlots([(day, startHour, endHour)], t => t);
        course.Confirm();
        return course;
    }

    protected static Course CreateunconfirmedCourse(string[]? requiredSkills = null)
    {
        Course course = Course.Create("Domain Unit Testing", new DateOnly(2026, 1, 5), new DateOnly(2026, 1, 30));
        if (requiredSkills?.Length > 0) course.UpdateRequiredSkills(requiredSkills);
        return course;
    }
}