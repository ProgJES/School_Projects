/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#include "Driver.h"

using namespace std;

namespace sict
{
	/***Constructor***/
	//car_ initialized with theCar and make copy name to this->name
   Driver::Driver(const char* name, Car& theCar) : car_(theCar)
   {
      strcpy(this->name_, name);
   }
   //Accelerates, brakes and then shows the status of the driver 
   void Driver::drive()
   {   
	  this->car_.accelerate();
	  this->car_.brake();
   	  this->showStatus();
   	  this->car_.display(cout) << endl;
   }
   //Keeps braking until car_ comes to a complete stop(speed()
   void Driver::stop()
   {
   	  while(this->car_.speed() > 0)
   	  {
   	     this->car_.brake();
	  }
	  this->showStatus();
	  this->car_.display(cout) << endl;
   }
   //Display the message
   void Driver::showStatus()
   {
   	  cout << this->name_ << " is driving this car." << endl;
   }
}
