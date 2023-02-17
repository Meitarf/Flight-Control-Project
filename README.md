# Flight-Control-Project
This project contains 3 projects: The server (**FlightControlWebAPI**), the client (**FlightsClient**) and the "simulator" (**SimulatorClient**).
Both client and server are ASP.Net Core MVC. The simulator is a simple console project. The project demonstrates an example of a flight control, where flights are being added, going through the different terminals and being displayed in the UI.
## Installation
* Download and run all three projects on Visual Studio.
* Right click on the solution -> Properties -> Mark the option: Multiple startup projects -> In the Action column, change all projects from None to Start. The server (**FlightControlWebAPI**) should be the first one to run.
#### Connection String
```
"ConnectionStrings": {
    "FlightControlDb": "Server=.\\SQLEXPRESS;Database=FlightsDb;Encrypt=False;Integrated Security=true;Pooling=False"
  }
  ```
  This should be set on **appsettings.json** file on the server (**FlightControlWebAPI**).
  * Make sure you are running on http://localhost:5114.\
  ## Overview
  The simulator, which is a Console project, creats a flight by calling the **POST** method from the WebAPI project (the server). When a flight is being added to the database, it needs to go by all the terminals and wait the amount of seconds determained by each terminal. 
  The UI displays all the flights, showing in which terminal each flight is in, when did the flight enter that terminal and when did the flight exit that terminal. When an exit time is being updated, that flight is being highlighted on the table. The page is refreshed every second using an **ajax** call.
  
![image](https://user-images.githubusercontent.com/62158246/219648069-92ddbeee-a439-4a98-9587-6bd1ea5e2cc6.png)
