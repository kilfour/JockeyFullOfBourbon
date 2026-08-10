# Jockey Full of Bourbon

## Context

Horses for Courses is a small domain model for managing coaches, skills, courses, schedules, and course assignments. The intended behaviour is described in [requirements.md](requirements.md).

Your task is to design and implement a comprehensive automated test suite for the domain model. Treat the requirements as the source of truth: do not assume that the implementation is correct.

The implementation contains bugs. Your tests should expose any behaviour that contradicts the requirements. The number and location of the bugs are deliberately not disclosed.

## Objectives

By completing this assignment, you should demonstrate that you can:

- Translate written domain requirements into executable specifications.
- Test successful behaviour, rejected operations, boundaries, and state transitions.
- Verify invariants across sequences of operations and interactions between domain objects.
- Achieve full line and branch coverage without writing tests whose only purpose is executing code.
- Organise a test suite so that its intent and coverage are easy to navigate.
- Remove unnecessary duplication while keeping each test understandable in isolation.
- OPTIONAL: Use mutation testing to assess the strength of the suite beyond code coverage.

## Assignment

Write tests for all observable behaviour in the `HorsesForCourses` project.

The completed suite must:

- Cover every rule stated in `requirements.md`.
- Exercise every in-scope handwritten production line and branch, reaching 100% line coverage and 100% branch coverage.
- Cover both accepted and rejected operations.
- Cover relevant boundary conditions.
- Verify the resulting domain state, not only return values or thrown exceptions.
- Verify that rejected operations do not leave domain objects in an invalid state.
- Cover behaviour that emerges from sequences of operations and collaboration between domain objects.
- Be deterministic and independent of test execution order.
- Test through the public API rather than private implementation details.

Coverage is a completion criterion, not proof of test quality. A suite that reaches every line but does not meaningfully distinguish correct behaviour from incorrect behaviour is insufficient.

Production code may be modified to correct defects revealed by requirement-led tests. Before fixing a defect, retain the test that exposes it and record the discrepancy against the supplied implementation in `Defects.md`. Keep the original symptom documented after the fix, and briefly record what was changed. Do not weaken a correct assertion or alter a requirement merely to make the suite pass.

The completed suite is expected to have a green baseline. Fixing documented defects is therefore part of preparing the project for meaningful coverage and mutation testing.

## Test organisation

Organise tests according to coherent domain concepts and behaviours. A reader should be able to locate the tests for a requirement without searching through unrelated test classes. Keep files focused, use consistent naming, and separate distinct behaviours when combining them would obscure intent.

Test names must communicate the condition being exercised and the expected outcome. The organisation should make successful behaviour, validation rules, boundaries, state transitions, and object interactions readily discoverable.

Avoid large catch-all test classes, miscellaneous helper folders, and organisation based solely on implementation convenience. The test suite should read as a structured description of the domain.

## Duplication and test support code

Repeated incidental setup should not be copied throughout the suite. Extract shared construction and setup logic when doing so gives it a clear domain meaning and provides sensible defaults.

Use parameterised tests when multiple inputs express the same rule. Reuse test data creation, builders, fixtures, and assertions where they remove noise and improve consistency. Keep shared support code close to the tests that own it unless it is genuinely useful across the suite.

Do not remove duplication at the expense of readability. Information that is essential to understanding a test should remain visible in that test. Avoid deeply layered helpers, hidden mutable state, order-dependent fixtures, and abstractions that force the reader to trace through several files to understand the scenario.

Every abstraction in the test project should make the suite easier to understand or maintain. Mere reduction in line count is not sufficient justification.

## Defect reporting

For every discrepancy discovered, record:

- The requirement that is violated.
- The observable behaviour produced by the implementation.
- The expected behaviour according to the requirements.
- The test or tests that demonstrate the discrepancy.
- Whether the defect was fixed and, if so, a concise summary of the production change.

Describe the original symptoms and violated rules independently of any subsequent fix. Distinct tests may expose the same underlying defect; identify that relationship rather than counting every failing assertion as a separate bug.

## Coverage

Generate line and branch coverage for the production project. Build output and generated files are outside the assessment scope.

1. Install ReportGenerator
   ```powershell
   dotnet tool install --global dotnet-reportgenerator-globaltool
   ```
2. Run the tests with coverage
   ```powershell
   if (Test-Path '.\TestCoverage') {
       Remove-Item '.\TestCoverage' -Recurse -Force
   }
   dotnet test HorsesForCourses.Tests\HorsesForCourses.Tests.csproj --collect:"XPlat Code Coverage" --settings coverage.runsettings --results-directory TestCoverage
   ```
3. Generate an HTML report using ReportGenerator:
   ```powershell
   if (Test-Path '.\TestReport') {
       Remove-Item '.\TestReport' -Recurse -Force
   }
   reportgenerator -reports:"TestCoverage\**\coverage.cobertura.xml" -targetdir:"TestReport" -reporttypes:Html
   start TestReport\index.html
   ```
Review the coverage report rather than relying only on its headline percentage. Each covered line and branch must be reached through a meaningful assertion about externally observable behaviour. Tests that invoke code without verifying its result do not satisfy this requirement.

The submitted coverage result must show 100% line coverage and 100% branch coverage for the handwritten production code.

## OPTIONAL/STRETCH GOAL: Mutation testing with Stryker.NET

After achieving full coverage and fixing documented defects so the test suite passes, run [Stryker.NET](https://stryker-mutator.io/docs/stryker-net/introduction/) against the production project. Mutation testing requires a green initial test run, then alters the implementation in small ways and checks whether the test suite detects those changes. A surviving mutant often indicates a missing assertion, an untested boundary, or a test that executes behaviour without specifying it precisely.

```powershell
dotnet stryker --config-file stryker-config.json --skip-version-check
```

Inspect all surviving, uncovered, timed-out, and errored mutants. Strengthen the suite where a mutant represents a meaningful change in domain behaviour. Do not add tests that merely mirror the current implementation, and do not exclude valid production code simply to increase the mutation score.

Some mutants may be equivalent to the original behaviour or irrelevant to the stated requirements. Document each accepted survivor and justify why no observable requirement can distinguish it. The goal is to eliminate all behaviourally meaningful surviving mutants, not to optimise a number without context.

Include the final mutation report.
