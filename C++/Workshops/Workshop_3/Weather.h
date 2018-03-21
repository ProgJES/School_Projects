/***********************************************
Author: Eunseok Jeon
Date: 2016/September/29
************************************************/

// Description
// Header files, which contains class "Weather" declaration


// compilation safegaurds
#ifndef _WEATHER_H
#define _WEATHER_H

/*Weather.h*/
// ict namespace
namespace ict
{
	class Weather
	{
	   char _date[7];
	   double _highTemp; 
	   double _lowTemp;
	   
	   public:
	   	void set(const char*, double, double);
	   	void display() const;
	   	const char* date() const;
	   	double low() const;
	};
}

#endif
