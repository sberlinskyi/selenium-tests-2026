## Run all tests
```bash
dotnet restore
dotnet test
```

Filter expression to run only a single test:
```bash
dotnet test --filter "FullyQualifiedName~selenium_tests_2026.SeleniumTests.VerifyPageTitleTest"
```