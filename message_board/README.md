PROJECT NAME
Message Board Api: This is a .Net Core 3.0 web api service that serve as the backend for a public message board which accepts CRUD opertation

PROJECT REQUIREMENT
For this project to run, the below technical requirements should be fullfiled 
1)DotNet core SDK must be present on the system 
2)Entity framework core inMemory package must be installed and can be downloaded from Nuget.org 
3)Serilog {AspNetCore,ExtensionsLogging,SinksConsole,SinksFile} can downloaded from Nuget.org 
4)Swashbuckle.AspNetCore can be downloaded from Nuget.org 

INSTALLATION
This Program can be run both on a docker conatainer and locally utilizing iis express.

To run as a docker container you can use the below command:
Ensure you are in the project folder
In terminal, run docker build -t message_board .
Then run docker run -p your_desired_port:80 --name desired_name message_board

To run locally utilizing iis express follow below steps:

On visual studio:
Right click on the project message_board
Click Build
Press F5 on your keyboard

On VsCode: 
Firstly, ensure you are in the project directory
Then run the command dotnet run

USAGE
To Create, Read, Update, Delete message(s), the project must be running and accessible on http://ipaddress:{port}/swagger
this will show you a swagger UI endpoint which eases the the CRUD operations

To Create a message:
Click on POST /api/TodoMessages
Click on Try it out
Ensure application/json is selected as Request body
In the json object, follow the example below
{
  "message": "Write your desired message here",
  "postedBy": "Write the name of the message poster",
  "modifiedDate": "auto generated",
  "posteDate": "auto generated"
}
Then click on Execute
Then you see a server response shown in the response section below the Execute button

To Read a message:
Click on GET /api/TodoMessages
Click on Try it out 
Enter the message id in the id textbox
Then click on Execute
Then you see a server response shown in the response section below the Execute button

To Update a message:
Click on PUT /api/TodoMessages
Click on Try it out
Ensure application/json is selected as Request body
In the json object, follow the example below
Enter the id of the message you want to update in the id textbox
then in the json object, follow the example below
{
  "message": "Write your New message here",
  "postedBy": "Write the name of the message poster",
  "modifiedDate": "auto generated"  
}
Then click on Execute
Then you see a server response shown in the response section below the Execute button


To Delete a message:
Click on DELETE /api/TodoMessages
Click on Try it out 
Enter the message id in the id textbox
Then click on Execute
Then you see a server response shown in the response section below the Execute button
