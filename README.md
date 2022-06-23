# Butterfly Systems Calculator is a simple RESTful web service:
#### A calculator for four basic operations (+, -, *, /)

## This repository contains two projects:

 1. ButterflySystems: asp web api project 
 2. ClientApp: developed in ReactJS. 

## In case client app cannot connect to the server follow below guideline:

To run the projects, you need to make sure that ClientApp is pointing to the right url. First run the web api project and replace the server url in environment variable inside .env file in the ClientApp root folder.

REACT_APP_SERVER_URL= http://localhost:5218


## CORS config

In order to activate CORS you need to modify the config file `appsettings.prod.json` as following:

```
  "CORS": {
    "ActivePolicy": "Restricted",
    "Origin": "https://yourdomain.com"
  }
```
## Web Api Solution
![image](https://user-images.githubusercontent.com/23233827/175276070-175f4805-a853-4251-bed3-e4c13063f2ea.png)

## CLient App
![image](https://user-images.githubusercontent.com/23233827/175276101-202cd18d-7e61-4d7b-983b-e4c49184aa0b.png)

## Swagger OpenApi
### URL: http://localhost:5218/swagger/index.html only available on development environemnt
![Web capture_23-6-2022_15270_localhost](https://user-images.githubusercontent.com/23233827/175288361-a10fddb8-ff2c-4b4c-9a3d-f082872b03e4.jpeg)
