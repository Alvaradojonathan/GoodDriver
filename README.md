# Good Driver
Working streamreader to calculate average speed and driving distance for a car insurance company. The software will run calculations based on their trips and output a report.

### Good Driver Input
The Good Driver Device reports driving data in a text file called `DrivingRecord.txt`. The file contains the following information:
```
Driver Lauren
Driver Jarryd
Driver Daniel
Driver Jordan
Trip Lauren 07:15 07:45 17.3
Trip Lauren 06:12 06:32 21.8
Trip Jarryd 12:01 13:16 42.0
Trip Jordan 06:06 12:26 80.2
Trip Jarryd 15:00 15:49 11.4
```
The lines that start with `Driver` have the names of the drivers on the insurance account.  
- The software splits each line creating an array for each line that contains driver in it.
- From that array it creates objects with a Name property on index 1 of that array.

The lines that start with `Trip` have the name of the driver for that trip, the start time of the trip, end time of the trip, and number of miles traveled for that trip.  
- The software splits each line that contains `Trip` in them creating an array.
- From that array it matches the name of the driver who drove with the Name property in the objects list created previously.
- If a match is found it edits the following properties:
  - Miles Driven
  - Total Time Driven

### Good Driver Output
After storing the information for each object above the software will output a summary report to the console window. Based on the input in the file, output would look like this:
```
Jordan: 80 miles @ 13 mph
Jarryd: 53 miles @ 26 mph
Lauren: 39 miles @ 47 mph
Daniel: 0 miles
```
The record includes every driver listed on the account, the total number of miles driven and their average speed.
