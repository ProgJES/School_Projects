/*
Student Name: Eunseok Jeon
Student Number: 026 110 148
Date: 2016/Dec/05
*/
#ifndef SICT_VALIDATE_H
#define SICT_VALIDATE_H
#include <cstring>

namespace sict
{
	//Template function that validates data
	template<typename T>
	bool validate(const T& min, const T& max, T ary[], int num, bool aryBool[])
	{
		bool returnValue = true;

		for (int i = 0; i < num; i++)
		{
			//If the data within the range, it is valid
			if (ary[i] >= min && ary[i] <= max)
			{
				aryBool[i] = true;
			}
			//Otherwise, the data is not valid
			else
			{
				aryBool[i] = false;
				returnValue = aryBool[i];
			}
		}
		return returnValue;
	}
	//Function template specialization for char type
	template<>
	bool validate<char>(const char& min, const char& max, char ary[], int num, bool aryBool[])
	{

		bool returnValue = true;
		//Create temp array to ignore case-sensitive
		char* temp = new char[strlen(ary) + 1];
		strcpy(temp, ary);
		for (int i = 0; i < num; i++)
		{
			//Convert all the characters to uppercase
			temp[i] = toupper(temp[i]);
			//If the elements of an array within the range, the data is valid
			if (temp[i] >= min && temp[i] <= max)
			{
				aryBool[i] = true;
			}
			//Otherwise, it is not valid
			else
			{
				aryBool[i] = false;
				returnValue = aryBool[i];
			}
		}
		return returnValue;
	}
	//Function template specialization for Car object
	template<>
	bool validate<Car>(const Car& min, const Car& max, Car ary[], int num, bool aryBool[])
	{

		bool returnValue = true;

		for (int i = 0; i < num; i++)
		{
			//If the elements of an array within the range and length equals to 6, data is valid
			if (ary[i] >= min && ary[i] <= max && strlen((const char*)ary[i]) == 6)
			{
				aryBool[i] = true;
			}
			//Otherwise, it is not valid
			else
			{
				aryBool[i] = false;
				returnValue = aryBool[i];
			}
		}
		return returnValue;
	}
}
#endif
