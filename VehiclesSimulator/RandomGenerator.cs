using System;
using System.Collections.Generic;

namespace VehiclesSimulator
{
    public class RandomGenerator
    {
        public List<string> AllData {get; set;}
        public RandomGenerator(){

            AllData = new List<string>();

            AllData.Add("{\"CustomerID\" : \"1\", \"VehicleID\" : \"YS2R4X20005399401\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"1\", \"VehicleID\" : \"YS2R4X20005399401\", \"Status\" : \"Off\"}");

            AllData.Add("{\"CustomerID\" : \"1\", \"VehicleID\" : \"VLUR4X20009093588\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"1\", \"VehicleID\" : \"VLUR4X20009093588\", \"Status\" : \"Off\"}");

            AllData.Add("{\"CustomerID\" : \"1\", \"VehicleID\" : \"VLUR4X20009048066\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"1\", \"VehicleID\" : \"VLUR4X20009048066\", \"Status\" : \"Off\"}");

            AllData.Add("{\"CustomerID\" : \"2\", \"VehicleID\" : \"YS2R4X20005388011\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"2\", \"VehicleID\" : \"YS2R4X20005388011\", \"Status\" : \"Off\"}");

            AllData.Add("{\"CustomerID\" : \"2\", \"VehicleID\" : \"YS2R4X20005387949\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"2\", \"VehicleID\" : \"YS2R4X20005387949\", \"Status\" : \"Off\"}");

            AllData.Add("{\"CustomerID\" : \"3\", \"VehicleID\" : \"YS2R4X20005387765\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"3\", \"VehicleID\" : \"YS2R4X20005387765\", \"Status\" : \"Off\"}");

            AllData.Add("{\"CustomerID\" : \"3\", \"VehicleID\" : \"YS2R4X20005387055\", \"Status\" : \"On\"}");
            AllData.Add("{\"CustomerID\" : \"3\", \"VehicleID\" : \"YS2R4X20005387055\", \"Status\" : \"Off\"}");

        }

        public string GetRandomData(){
            Random r = new Random();
            int rInt = r.Next(0, 13);
            return AllData[rInt];
        }
        
    }
}