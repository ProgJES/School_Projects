/***********************************************
Author: Eunseok Jeon
Date: 2016/September/29
************************************************/

// Description
// Implementation file for class in header file "Weather.h"


/*Weather.cpp*/
//  includes go here
#include <iostream>
#include "Weather.h"
#include "string.h"
#include <iomanip>
// ict namespace
namespace ict
{
	// set method
	void Weather::set(const char* date, double lowTemp, double highTemp)
	{
		//receives data from user and assing them into member variables
		_lowTemp = lowTemp;
		_highTemp = highTemp;
		strcpy(_date, date);
	}

	// date method (query)=accessor
	const char* Weather::date() const
	{
		//return date
	   return _date;
	}
	// low method (query)=accessor 
	double Weather::low() const
	{
		//return low
		return _lowTemp;
	}
	// display function =
	void Weather::display() const
	{
		//temperature will have 1 floating point
		std::cout.precision(1); 
		std::cout << _date;
		//set width 16 and - lenght of string "date" in order to make better output
		std::cout.width(16 - strlen(_date));
		//fill with '_'
		std::cout.fill('_');
		//display high tmperture
		std::cout << std::fixed << _highTemp;

		//set width 6 for low temperature
		std::cout.width(6);
		//fill with '_'
		std::cout.fill('_');
		//display low temperat
		std::cout << _lowTemp << std::endl;

	}
}
