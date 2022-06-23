# This repository contains two projects:

 1. ButterflySystems: asp web api project 
 2. ClientApp: developed in ReactJS. 

# In case of port issue follow the guideline below:

To run the projects, you need to make sure that ClientApp is pointing to the right url. First run the web api project and replace the server url in environment variable inside .env file in the ClientApp root folder.

REACT_APP_SERVER_URL= http://localhost:5218


# Deploy On Production

In order to activate CORS you need to modify the config file `appsettings.prod.json` as following:

```
  "CORS": {
    "ActivePolicy": "Restricted",
    "Origin": "https://yourdomain.com"
  }
```