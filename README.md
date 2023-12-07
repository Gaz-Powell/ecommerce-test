# E-Commerce Technical Test

## Solution

The solution is based around an ASP.NET Core web API with supporting .NET class libraries as this is what I'm most familiar with.

I would normally develop using feature branches similar to the process described in the [Atlassian Feature Branch Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow) article, but rather than in this test where I've committed all changes in a single commit to `main`.

## Assumptions

I have assumed that if one LineItem is invalid, an exception is thrown immediately and the whole order fails. In a production setting I would prefer to collect all validation errors and combine them into a single exception.

## Design decisions/considerations

I chose to place API request models in the Models project - if they live in the API project, the request would need to be destructured before being passed to the service; if the request object is passed directly to the service, the service would have become dependent on the API project and a circular dependency would be created.

I considered placing database entities in the Models project as I thought I may encounter similar problems as above, but decided to put them in the DataProvider as I was confident circular dependencies wouldn't be an issue.

A list was used for the LineItems - this could be a HashSet to enforce unique entries.

## Method Naming

I have named any asynchronous methods with an "Async" suffix as that is the recommended style in my current position.