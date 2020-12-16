# ⚔️ 𝕯𝖊𝖕𝖑𝖔𝖞 𝖙𝖍𝖊 𝕾𝖊𝖗𝖛𝖊𝖗 𝕾𝖎𝖉𝖊 𝕬𝖕𝖕

### 𝕿𝖍𝖎𝖘 𝐖𝐞𝐛 𝐀𝐩𝐩𝐥𝐢𝐜𝐚𝐭𝐢𝐨𝐧 𝐮𝐬𝖊𝖘 𝐚 𝐌𝐢𝐜𝐫𝐨𝐬𝐨𝐟𝐭 𝐒𝐐𝐋 𝐒𝐞𝐫𝐯𝐞𝐫 𝐃𝐚𝐭𝐚𝐛𝐚𝐬𝐞, 𝐈𝐝𝐞𝐧𝐭𝐢𝐭𝐲 𝐀𝐮𝐭𝐡𝐞𝐧𝐭𝐢𝐜𝐚𝐭𝐢𝐨𝐧, 𝐚 .𝐍𝐄𝐓 𝐂𝐨𝐫𝐞 𝐛𝐚𝐜𝐤𝐞𝐧𝐝, 𝐚𝐧𝐝 𝐖𝐞𝐛 𝐀𝐏𝐈 𝐰𝐢𝐭𝐡 𝐭𝐡𝐞 𝐟𝐫𝐨𝐧𝐭 𝐞𝐧𝐝 𝐯𝐢𝐞𝐰𝐬 𝐛𝐞𝐢𝐧𝐠 𝐫𝐞𝐧𝐝𝐞𝐫𝐞𝐝 𝐮𝐬𝐢𝐧𝐠 𝐑𝐞𝐚𝐜𝐭-𝐉𝐒 𝐭𝐞𝐜𝐡𝐧𝐨𝐥𝐨𝐠𝐲. 𝐈𝐧 𝐭𝐡𝐢𝐬 𝐚𝐫𝐭𝐢𝐜𝐥𝐞, 𝐰𝐞 𝐰𝐢𝐥𝐥 𝐝𝐞𝐦𝐨𝐧𝐬𝐭𝐫𝐚𝐭𝐞 𝐞𝐚𝐜𝐡 𝐬𝐭𝐞𝐩 𝐨𝐟 𝐝𝐞𝐩𝐥𝐨𝐲𝐢𝐧𝐠 𝐭𝐡𝐞 𝐛𝐚𝐜𝐤𝐞𝐧𝐝 𝐚𝐩𝐩𝐥𝐢𝐜𝐚𝐭𝐢𝐨𝐧 𝐟𝐫𝐨𝐦 𝐠𝐢𝐭𝐡𝐮𝐛 𝐫𝐞𝐩𝐨𝐬𝐢𝐭𝐨𝐫𝐲 𝐭𝐨 𝖆 𝖑𝖔𝖈𝖆𝖑 𝖒𝖆𝖈𝖍𝖎𝖓𝖊 𝖔𝖗 𝐀𝐳𝐮𝐫𝐞 𝐚𝐩𝐩 𝐬𝐞𝐫𝐯𝐢𝐜𝐞.

## ⚜️ Build the Korflix Web API on the Local Machine

-   **Clone Github in Visual Studio 2019**\
    https://github.com/BCIT-SSD-2020-21/dotnetproject-team6_netproject-FRONTEND.git

-   **install or update NuGet packages on Package Manager Console**

    ```c-sharp
        PM > Install-Package Microsoft.EntityFrameworkCore  -Version 3.1.10
        PM > Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.10
        PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.10
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
    -   **Run the Web Backend App on a Local Machine**\
        To run the app locally, simply Press the key F5 and type the Web API endpoints in a browser. After running the App, its movie seeder service will pull about 2400 Korean movies from https://www.themoviedb.org/ to the local MS-SQL server.

## 🔱 Deploy the Korflix Web API using the Microsoft Azure Service

-   To publish the Korflix API to Azure with a new App Service, first subscribe Azure account. In Visual Studio, choose Azure to **Publish** the Korflix project, create a web app service, create a database, write JWT_ISSUER and JWT_SITEKEY on the 'Application setttings' dialog, and then launch the Publish service.

## 🍁 Korflix Web API endpoints\

-   ### Movie

    #### Requests

    -   Replace https://korflixapi.azurewebsites.net to [https://localhost:xxxx](https://localhost:xxxx) if running the app on a local machine.

        -   https://korflixapi.azurewebsites.net/movie
        -   https://korflixapi.azurewebsites.net/movie?search=Jumong
        -   https://korflixapi.azurewebsites.net/movie?search=Goguryeo
        -   https://korflixapi.azurewebsites.net/movie?genreId=18
        -   https://korflixapi.azurewebsites.net/movie?genreId=18&search=Jumong
        -   https://korflixapi.azurewebsites.net/movie?genreId=18&search=Goguryeo
        -   https://korflixapi.azurewebsites.net/movie?genreid=18

    #### Response ( 0 to many movies)

    ![](https://i.imgur.com/kKd62Fy.png)

-   ### Authention (Responding User Token and User Id for the front end to store in sessions)

    Replace https://korflixapi.azurewebsites.net to https://localhost:xxxx] if running the app on a local machine.

    -   #### Register

    ![](https://i.imgur.com/riinuBW.png)

    -   #### Login

    ![](https://i.imgur.com/wQ7wxy3.png)

-   ### Rating

    #### Requests

    -   Replace https://korflixapi.azurewebsites.net to [https://localhost:xxxx](https://localhost:xxxx) if running the app on a local machine.

        -   https://korflixapi.azurewebsites.net/movie
        -   https://korflixapi.azurewebsites.net/movie?search=Jumong
        -   https://korflixapi.azurewebsites.net/movie?search=Goguryeo
        -   https://korflixapi.azurewebsites.net/movie?genreId=18
        -   https://korflixapi.azurewebsites.net/movie?genreId=18&search=Jumong
        -   https://korflixapi.azurewebsites.net/movie?genreId=18&search=Goguryeo
        -   https://korflixapi.azurewebsites.net/movie?genreid=18

    #### Response ( 0 to many movies)

    ![](https://i.imgur.com/kKd62Fy.png)

    🎼🍁
