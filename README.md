# Samples
There are some samples in this repository that could be re-used in different projects. 
The main goal of the repository is to share knowledge and improve my practice skills in programming.  

Language: C# 
Framework: .NET Core

# Paging Sample
There is an example of how to create pagination for the API, using the separate service 'ApiPagingService' to modify the query before execution.
This approach is good because it is possible to continue editing queries after the paging condition have been set. 
It's easy to test and easy to change the implementation if the data source will be changed.

# Auth Sample
There is an example of how to set up authentication and authorization for ASP.NET Core 3.1 without external tools.
In this sample has been provided AuthTokenIssue which generates bearer token and the app configuration has been set up to validate this token.
This time integrations tests as Postman collection was provided.