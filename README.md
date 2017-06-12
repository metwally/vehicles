# Intro:
Vehicle will connect with system via websocket.
system will receive status from vehicle then display it and save it to sqlite db.
user can view real time status via web page.
user can view status history via web page.

***Kindly, Take a look to PrtScr directory before start.***

# System Services:

## VehiclesCore:
the core service .. provide websocket connection for all vehicles.
vehicle open websocket connection and start sending its status.
or vehicle can send Http Post request instead.
core service run on port 5000
websocket path is ws://localhost:5000/ws

### core service APIs:
1. GET http://localhost:5000/vehicles
retrieve all vechicles from database

2. POST http://localhost:5000/vehicles
to send vehicle status

body example:
{
	"CustomerID" : "1",
	"VehicleID" : "YS2R4X20005399401",
	"Status" : "On"
}

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


# Run Instructions:
1. start VehiclesCore first

2. then start VehiclesWeb .. you can run it on any web server. for sake of simplicity you can install http-server via npm [node.js package manager]. 
install npm first if you don't have it. https://www.npmjs.com/
then run this command from OS terminal:
`npm i -g http-server`
to run VehiclesWeb navigate to its directory from terminal then run this command:
`http-server -p 5500`
this will run the web app on port 5500.

3. run VehiclesSimulator .. now for each Enter you will press from VehiclesSimulator terminal, a random vehicle data will be sent to VehiclesCore.
you should be able to see real time data arrive to index.html page.
