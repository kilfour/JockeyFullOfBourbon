using HorsesForCourses.Abstractions;

namespace HorsesForCourses.Domain.Coaches.InvalidationReasons;

public class CoachCourseAssignmentOutOfSync : DomainException
{
    public CoachCourseAssignmentOutOfSync()
        : base("Coach.AssignCourse requires the course to already be assigned to this coach via Course.AssignCoach().") { }
}
