We are using Clean Architecture for this service. There are 4 layers in this.
Application (Class Library Project) - Define Abstraction of Employee 
Infrastructure(Class Library Project) - Define DBConnection and interaction between database & abstraction(Applicaton)
Domain(Class Library Project)- Define every entity or model
Protivity_POC_Employee(API Project/Presentation)- Interaction from Client(Angular/React).

-----------------------Application-------------------------
Nuget Packages
1. FluentValidation.DependencyInjectionExtensions
2. MediatR


----------------------Infrastructure-----------------------
Nuget Packages
1. Microsoft.Extensions.DependencyInjection
2. Microsoft.EntityFrameworkCore
3. Microsoft.EntityFrameworkCore.SqlServer
4. Microsoft.EntityFrameworkCore.Design

----------------------API Project---------------------------
Nuget Packages
1. Microsoft.EntityFrameworkCore
2. Microsoft.EntityFrameworkCore.SqlServer
3. Microsoft.EntityFrameworkCore.Tools

---------------------Migration With Code First---------------

Open Package manager console and select Infrastructure as a default project.Write below commands
1. add-migration EmployeeMigration00
2. update-database

--------------Project References----------------------------

1. Domain is a independent.
2. Application -> Domain & Infrastructure
3. Infrastructure -> Domain & Application

--------------Error Logging------------------

Using serilog for log information and errors.