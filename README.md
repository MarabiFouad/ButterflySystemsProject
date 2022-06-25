# Butterfly Systems Calculator is a simple RESTful web service:
#### A calculator for four basic operations (+, -, *, /)

## This repository contains two projects:

 1. ButterflySystems: ASP Web Api
 2. ClientApp: ReactJS

## In case client app cannot connect to the server follow below guideline:

To run the projects, you need to make sure that ClientApp is pointing to the right url. First run the web api project and replace the server url in environment variable inside .env file in the ClientApp root folder.

REACT_APP_SERVER_URL= http://localhost:5218


## CORS config

By default server will allows all domains but in order to allow only your domain and activate CORS, you need to modify the config file `appsettings.prod.json` as following and set `ASPNETCORE_ENVIRONMENT` to `Production` and `ENV` to `prod`:
Origin:comma seperated domains. e.g. http://localhost:3000,http://localhost:3500

```
  "CORS": {
    "ActivePolicy": "Restricted",
    "Origin": "http://localhost:3000" 
  }
```
## Web Api Solution
![image](https://user-images.githubusercontent.com/23233827/175276070-175f4805-a853-4251-bed3-e4c13063f2ea.png)

## CLient App
![image](https://user-images.githubusercontent.com/23233827/175276101-202cd18d-7e61-4d7b-983b-e4c49184aa0b.png)

## Swagger OpenApi
### URL: http://localhost:5218/swagger/index.html only available on development environemnt
#### V1: simple calculator service
![image](https://user-images.githubusercontent.com/23233827/175500215-d0098bec-90e2-47af-bffd-a8f6475d1bd2.png)
#### V2: startegy and factory design patterns
![image](https://user-images.githubusercontent.com/23233827/175500303-4dd57624-1c49-4550-b3ac-3d5cad30c268.png)
