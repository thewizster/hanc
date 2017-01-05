![logo](hanc300.png "Hanc logo")

# HANC  
Useful for building new ASP.Net Core API microservices

## CLI Quickstart
This quickstart clones the HANC repo, builds, and runs the application

### Tools you will need installed  
+ .NET Core https://www.microsoft.com/net/core  
+ GIT https://git-scm.com/downloads
+ Postman https://www.getpostman.com/

1) Clone the HANC repo  
```git clone https://github.com/thewizster/hanc.git```

2) Change into the AspNetAPI folder  
```cd hanc/AspNetAPI```

3) Restore packages and build  
```dotnet restore && dotnet build```

4) Run the app  
```dotnet run```

Use Postman to test Hanc

5) Set postman to GET request for http://localhost:5000/api/hello

6) Set X-Hanc-Application-Id header in Postman request to some_key_value (see appsettings.json to change AppId)

7) Press send for the Postman GET request
