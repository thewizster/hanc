# HANC  
A template for building new ASP.Net Core API microservices

## CLI Quickstart
This quickstart clones the HANC repo, builds, and runs the application

### Tools you will need installed  
+ .NET Core https://www.microsoft.com/net/core  
+ GIT https://git-scm.com/downloads

1) Clone the HANC repo  
```git clone https://github.com/thewizster/hanc.git```

2) Change into the AspNetAPI folder  
```cd hanc/AspNetAPI```

3) Restore packages and build  
```dotnet restore && dotnet build```

4) Run the app  
```dotnet run```

You should now be able to browse to http://localhost:5000/api/hello
