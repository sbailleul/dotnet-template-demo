#Neos template demo
## Template installation 
Go to root folder and run command : 
````shell
dotnet new -i ./ 
````
## Template uninstallation 
Go to root folder and run command : 
````shell
dotnet new -u ./
````
## Generation of new project 
Options : 
* --entity | -E : Name of entity used in template, it will replace "Template" values 
* --name | -n : Name of solution, default is Neos.Templates
* --output | -o : Output directory for solution

## Example 
To generate a users management project you can for example use this command once you have installed template : 
````shell
dotnet new template-demo -e User -n Neos.UsersManagement -o users-management
````