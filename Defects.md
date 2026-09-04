### Defect 1 – Coach Suitability (DONE)

Changed `Any` to `All` in **`Coach.cs`** to ensure a coach is only considered suitable when they have **all required skills**.
I will also add tests to verify and prove that the new behavior works correctly.

### Defect 2 – Course Immutability (DONE)

Changed the order in **`Course.cs`** inside `UpdateTimeSlots`.
`NotAllowedIfAlreadyConfirmed()` is now checked **before** validating the new timeslot data. This ensures that a confirmed course cannot be modified, even when the new timeslot data is invalid.
I will also add tests to verify and prove that the correct `CourseAlreadyConfirmed` exception is thrown.



