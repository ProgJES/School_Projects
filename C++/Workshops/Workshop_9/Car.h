/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#ifndef SICT_CAR_H_
#define SICT_CAR_H_

#include "Vehicle.h"
namespace sict
{
	// complete the declaration of the class
	class Car : public Vehicle
	{
	private:
		// private members go here
		int speed_;
		int maxSpeed_;

	protected:
		// protected members go here
		void speed(int value);
		int maxSpeed() const;

	public:
		// public members go here
		Car(int maxSpeed = 100);
		int speed() const;
	};
	//Non-member function
	std::ostream& operator << (std::ostream&, const Car&);
}

#endif
