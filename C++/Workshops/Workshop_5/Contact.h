// OOP244 Workshop 5: Class with a Resource
// File: Contact.cpp
// Version: 1.0
// Date: 12/Oct/2016
// Student Name: Eunseok Jeon
// Student ID: 026 110 148
// Description:
// This is header file for Contact.cpp (at_home)
/////////////////////////////////////////////
//Header file for Contact.cpp

#ifndef ICT_CONTACT_H
#define ICT_CONTACT_H

#include "PhoneNumber.h"
namespace ict {
	class Contact {
		char name_[41];
		PhoneNumber* phoneNumber_;
		int noPN_;
		void setEmpty();

	public:
		//Default constructor that sets to an empty safe state
		Contact(); 
		//Copy constructor
		Contact(const Contact& src);
		//Assignment operator
		Contact& operator=(const Contact& src);
		//Contructor that take two arguments
		Contact(const char* _name, int _number);
		//Destructor
		~Contact();
		//Display function
		void display() const;
		void read();		
		bool isEmpty()const;
	};

}
#endif
