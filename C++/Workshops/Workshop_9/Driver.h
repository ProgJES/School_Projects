/*
Student Name: Eunseok Jeon
Student ID:	026 110 148
Date: 2016/Nov/16
*/
#ifndef SICT_DRIVER_H_
#define SICT_DRIVER_H_

#include <cstring>
#include "Car.h"

namespace sict
{
	class Driver
	{
	private:
		// private members go here
		char name_[31];
		Car& car_;

	public:
		// public members go here
		Driver(const char* name, Car& theCar);
		void drive();
		void stop();
		void showStatus();
	};
}
#endif
