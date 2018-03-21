/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#ifndef SICT_VEHICLE_
#define SICT_VEHICLE_

#include <iostream>
namespace sict
{
	// complete the declaration of the class
	class Vehicle
	{
	public:
		// public members go here
		
		/*Interface that consist of pure virtual functions*/
		virtual void accelerate() = 0;
		virtual void brake() = 0;
		virtual std::ostream& display(std::ostream& ostr) const = 0;
	};
}
#endif
