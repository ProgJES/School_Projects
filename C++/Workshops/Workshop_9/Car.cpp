/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#include "Car.h"

namespace sict
{
	/***Constructors***/
	/*
	   Receives one argument to set the maxSpeed_ attribute. 
	   If this argument is not provided, it will set the maximum speed to 100. 
	   It also sets the speed_ attribute to 0.
	*/
   Car::Car(int maxSpeed)
   {
   	  this->maxSpeed_ = maxSpeed;
   	  this->speed_ = 0;
   }
   
   /*Protected members*/
   
   /*
      Sets the speed_ attribute to the incoming value.  
	  If the value is greater than maxSpeed_ attribute or less than 0, then values are corrected to maxSpeed_ and 0 respectively. 
   */
   void Car::speed(int value)
   {
   	
      this->speed_ += value;
      
   	  if(this->maxSpeed_ < value)
   	  {
   	     this->speed_ = this->maxSpeed_;
	  }
	  if(this->speed_ < 0)
	  {
	  	 this->speed_ = 0;
	  }
   }
   //Return maxSpeed
   int Car::maxSpeed() const
   {
      return this->maxSpeed_;
   }
   
   /*Public member function*/
   //Return speed
   int Car::speed() const
   {
   	  return this->speed_;
   }
   
   /***Non-member function***/
   //Call and return the display method inherited from the Vehicle, passing the ostream argument through it.
   std::ostream& operator << (std::ostream& os, const Car& car)
   {
   	  return car.display(os);
   }
}
