/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#include "SportCar.h"

using namespace std;

namespace sict
{
	/***Constructors***/
	//Default constructor that will set number of passenger to 1
   SportCar::SportCar()
   {
   	  this->noOfPassengers_ = 1;
   }
   /*
       Receives maximum speed and number of passengers; 
	   it passes the maximum speed value to its base class (Car) constructor 
	   and sets the number of passengers to the incoming value. 
   */
   SportCar::SportCar(int maxSpeed, int noOfPassengers) : Car(maxSpeed)
   {
   	  this->noOfPassengers_ = noOfPassengers;
   }
   
   /***Pure virtual members from base class***/
   //Adds 40 kilometers to the speed. 
   void SportCar::accelerate()
   {
   	  this->speed(40);
   }
   //Reduces the speed by 10 kilometers 
   void SportCar::brake()
   {
   	  this->speed(-10);
   }
   //Display function
   ostream& SportCar:: display(ostream& ostr) const
   {
   	  //it will display the message depending on its speed
   	  if(this->speed() > 0)
   	  {
   	     ostr << "This sport car is carrying " << this->noOfPassengers_ << " passengers and is traveling at a speed of "
   	          << this->speed() << " km/h.";
   	  }
   	  else
   	  {
   	  	 ostr << "This sport car is carrying " << this->noOfPassengers_ << " passengers and is parked.";
	  }
	  
	  return ostr;
   }


}
