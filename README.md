# Intro:
Vehicle will connect with system via websocket.  
system will receive status from vehicle then display it and save it to sqlite db.  
user can view real time status via web page.  
user can view status history via web page.

***Kindly, Take a look to "PrtScr" directory before start.***  
***services requires dotnet core to run***  

# System Services:

## VehiclesCore:
the core service .. provide websocket connection for all vehicles.  
vehicle open websocket connection and start sending its status.  
or vehicle can send Http Post request instead.  
core service run on port 5000  
websocket path is ws://localhost:5000/ws

### core service APIs:
1. GET http://localhost:5000/vehicles  
retrieve all vehicles from database

2. POST http://localhost:5000/vehicles  
to send vehicle status

body example:  
`{  
	"CustomerID" : "1",  
	"VehicleID" : "YS2R4X20005399401",  
	"Status" : "On"  
}` 

3. GET http://localhost:5000/vehicles/vehicle/{vehicle_id}  
to retrieve specific vehicle data from database

4. GET http://localhost:5000/vehicles/customer/{customer_id}  
to retrieve specific customer vehicles data from database


## VehiclesSimulator:
simulator is a fake vehicle connection.  
service generate random vehicle data each time you press enter on console terminal  
pressing Enter mean you entered an empty line.

## VehiclesWeb:
GUI .. two pages.  
1. index.html which is a live monitor .. whenever any vehicle status been received   
by Vehicle Core service it will be broadcasted to web GUI and will be displayed in real time.

2. history.html .. simply, read data from database.  
you can retrieve all data for all customers and vehicles  
or all data for one customer  
or all data for one vehicle.  

### web GUI basics
- each vehicle will be added as a new row in vehicles table
- each new status for same vehicle will replace the old one .. it will not add new row .. it will replace the old.  
- if vehicle status is "Off" then row color will be red.
- for each vehicle if we didn't receive its status for one minute then status row color will turned to be gray .. or dimmed  
- index page [live] will open empty each time .. it doesn't read from database .. it's read from webscoket.



# Run Instructions:
***Services requires dotnet core to run***
1. start VehiclesCore first  
`dotnet run`  
it will run on port 5000

2. then start VehiclesWeb .. you can run it on any web server. for the sake of simplicity you can install http-server via npm [node.js package manager].   
install npm first if you don't have it. https://www.npmjs.com/  
then run this command from OS terminal:  
`npm i -g http-server`  
to run VehiclesWeb navigate to its directory from terminal then run this command:  
`http-server -p 5500`  
this will run the web app on port 5500.

3. run VehiclesSimulator  
`dotnet run`  
now for each Enter you will press from VehiclesSimulator terminal, a random vehicle data will be sent to VehiclesCore.  
you should be able to see real time data arrive to index.html page.

4. for history .. press "Go To history" button from index page.  
or navigate to http://localhost:5000/history from browser address bar  
then, from history page press "Go" button to retrieve data.  
for all data just press Go without any selection.  
for specific customer data select customer from customers drop menu  
for specific vechile .. select customer first .. then select the vehicle  
