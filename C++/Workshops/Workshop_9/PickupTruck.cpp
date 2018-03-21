/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#include <cstring>
#include "PickupTruck.h"

using namespace std;

namespace sict
{ 	
	/***Constructors***/
	//Sets the loadAmount_ attribute to zero and the loadecMaterial_ to an empty C-style string.
	PickupTruck::PickupTruck()
	{
		this->loadAmount_ = 0;
		this->loadedMaterial_[0] = '\0';
	}
	
	/***Public member functions***/
	//Sets the two corresponding attributes to the incoming values through the argument list. 
	void PickupTruck::load(const char* loadMaterial, int loadAmount)
	{
		strcpy(this->loadedMaterial_, loadMaterial);
		this->loadAmount_ = loadAmount;
	}
	//Sets the loadAmmount_ attribute to zero. 
	void PickupTruck::unload()
	{
		this->loadAmount_ = 0;
	}
	//Return true if loadAmount == 0
	bool PickupTruck::isEmpty() const
	{
		return this->loadAmount_ == 0;
	}
	
	/***Pure virtual members from base class***/
	//Adds 20 kilometers to the speed. 
	void PickupTruck::accelerate()
	{
		this->speed(20);
	}
	//Reduces the speed by 5 kilometers 
	void PickupTruck::brake()
	{
		this->speed(-5);
	}
	//Display function
	ostream& PickupTruck::display(ostream& ostr) const
	{
		//if the function isEmpty() returns true, it displays the message of it. Also, checks it is parked or not
		if(this->isEmpty())
		{
			ostr << "This pickup truck is not carrying any load ";
			if(this->speed() > 0)
			{
			   ostr << ", traveling at the speed of " << this->speed() << " km/h.";
			}
			else
			{
			   ostr << "and is parked.";
			}
		}
		//else, it will display with number of loadAmount. Also, checks it is parked or not
		else
		{	
			ostr << "This pickup truck is carrying "
			     << this->loadAmount_ << " kgs of "
			     << this->loadedMaterial_;
			     if(this->speed() > 0)
			     {
			     	 ostr << ", traveling at the speed of " << this->speed() << " km/h.";
				 }
				 else
				 {
				 	ostr << " and is parked.";
				 }
		}
		return ostr;
	}


}
