### Defect 1 – Coach Suitability (DONE)

Changed `Any` to `All` in **`Coach.cs`** to ensure a coach is only considered suitable when they have **all required skills**.
I will also add tests to verify and prove that the new behavior works correctly.

### Defect 2 – Course Immutability (DONE)

Changed the order in **`Course.cs`** inside `UpdateTimeSlots`.
`NotAllowedIfAlreadyConfirmed()` is now checked **before** validating the new timeslot data. This ensures that a confirmed course cannot be modified, even when the new timeslot data is invalid.
I will also add tests to verify and prove that the correct `CourseAlreadyConfirmed` exception is thrown.

### Defect 3 – Skills Silently Disappear

Changed the implementation in **`Coach.cs`** and **`Course.cs`** to materialize the given skills once at the beginning of the method.
This ensures that **all given skills are stored correctly**, even when the input is a single-pass `IEnumerable<string>`.
I will also add tests to verify and prove that all given skills are kept correctly.



