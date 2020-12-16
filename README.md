# ⚔️ Deploy the Server Side App

### We have built a Web Application using a Microsoft SQL Server Database, Identity Authentication, a .NET Core backend, and Web API with the front end views being rendered using React-JS technology.

    In this article, we will demonstrate each step of deploying the backend application from github repository to Azure app service.

## Build the Web API on the Local Machine

-   **Clone Github in Visual Studio 2019**\
    https://github.com/BCIT-SSD-2020-21/dotnetproject-team6_netproject-FRONTEND.git

-   **install or update NuGet packages on Package Manager Console**

    ```c-sharp
        PM > Install-Package Microsoft.EntityFrameworkCore  -Version 3.1.10
        PM > Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.10
        PM > Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 3.1.10
        PM > Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 3.1.10
        PM > Install-package Microsoft.AspNetCore.Cors
        PM > Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson -Version 3.1.10
    ```

-   **Configue Database Connection**\
    Rename appsettingsCopy.json to appsettings.json, add "Connection Strings", then under it, add "MovieConnection". Here is an example below:
    ```c-sharp
      "ConnectionStrings": {
            "MovieConnection": "Server=LAPTOP-3GTODMGABC;Database=MovieApiABC;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
    ```
-   **Configue JWT Tokens on the Server**\
    Create JWT in secrets.json. Here is a sample code:

    ```
    {
        "JWT_ISSUER":"ThisisIssuer",
        "JWT_SITEKEY": "ThisismySecretekey123"
    }
    ```

-   **Build Movie and Authentication Database**\
    On Package Manager Console, run
    ```
        PM > Add-Migration InitialMovieSchema -Context MovieDbContext -OutputDir "Data/Migrations"
        PM > Update-Database -Context MovieDbContext
        PM > Add-Migration InitialAuthSchema -Context AuthContext -OutputDir "Areas/Identity/Data/Migrations"
        PM > Update-Database -Context AuthContext
    ```
