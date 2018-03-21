/***********************************************
Author: Eunseok Jeon
Date: 2016/September/29
************************************************/

// Description
// Main cpp file for the "weather"

#include <iostream>
#include "Weather.h"
#include "string.h"

using namespace std;
using namespace ict;

double findLow(const char* date, const Weather* data, int dataSize);

int main(){
  int i; //  loop counter
  int n; //the count of days worth of weather
  Weather* weather = nullptr;// initialize the weather pointer here


  cout << "Weather Data" << endl
    << "=====================" << endl
    << "Days of Weather: ";
  cin >> n;
  cin.ignore();

  weather = new Weather[n];// allocate dynamic memory here
  

  for (i = 0; i < n; i++){
    char date_description[7];
    double high;
    double low;
    
    cout << "Enter date (yy/mm/dd): ";
    cin >> date_description;
    cout << "Enter high: ";
    cin >> high;
    cout << "Enter low: ";
    cin >> low;
    // ... add code to accept the user input
    // for the weather array
    weather[i].set(date_description, low, high);
  }
  cout << endl
    << "Weather report:" << endl
    << "Date        high  low" << endl
    << "======================" << endl;

  for (i = 0; i < n; i++){
    weather[i].display();
  }
  
  char query[7];
  
  cout << endl << "Enter the date you are looking for: "; 
  //accept user input for the date to find   
  //(in this example stored in char query[7])   
  // and display the found low temprature. 
  
  //clear out the buffer
  cin.ignore(); 
  //receive user input here
  cin.getline(query, 7, '\n');   
  
  //set return value of "findLow" function to "low" variable    
  double low = findLow(query, weather, n);
  
  //display low temperatur   
  cout << "Low temperature: " << low << endl;
  
  // deallocate dynamic memory here
  delete [] weather;
  weather = nullptr;
  
  return 0;
}

double findLow(const char* date, const Weather* data, int dataSize)
{
	//initialize local variables
	int i = 0; 
	int find; 
	
	//Run untill the variable i < dataSize or successfully find date
	while(i < dataSize) 
	{
		//compare the string in the object's date and user input date
		//and set the return value to find
		find = strcmp(data[i].date(), date); 
		//if "find" == 0 (which means, both strings are the same), go out the while loop
		if(find == 0) 
		{
			break;
		}
		   i++;	
	}
	//if "find == 0", which means successfully find the date that user looking for, return its low temperature. 
	//Otherwise, return 0.0
	return find == 0 ? data[i].low() : 0.0; 
}

