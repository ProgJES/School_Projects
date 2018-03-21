// OOP244 Workshop 5: Class with a Resource
// File: Contact.cpp
// Version: 1.0
// Date: 12/Oct/2016
// Student Name: Eunseok Jeon
// Student ID: 026 110 148
// Description:
// This is impletation file for Contact (at_home)
/////////////////////////////////////////////
#include <iostream>
#include "string.h"
#include "Contact.h"

using namespace std;


namespace ict
{  
  //Default constructor that sets to empty safe state
  Contact::Contact()
  {
     this->setEmpty();
  }
  //A two argument constructor that accecpts const char* name and number of PHone numbers for the contact
  Contact::Contact(const char* _name, int _number)
  {
  	 this->setEmpty();
  	 this->phoneNumber_ = new PhoneNumber[_number];
  	 strncpy(this->name_, _name, 41);
  	 this->name_[41] = '\0';
  	 this->noPN_ = _number;
  }
  //Destructor, if "phoneNumber_ != nullptr", it will deallocate the memory of phoneNumber_
  Contact::~Contact()
  {
     if(this->isEmpty())
	 {
	    delete [] this->phoneNumber_;
		this->phoneNumber_ = nullptr;	
	 }	
  }
  //Copy constructor
  Contact::Contact(const Contact& src) 
  {
  	//Shallow copy non-resource variables
  	  strncpy(this->name_, src.name_, 41);
  	  this->name_[41] = '\0';
      this->noPN_ = src.noPN_;
      //If the source is not empty, copy the resource data
      if(src.phoneNumber_ != nullptr)
      {
      	this->phoneNumber_ = new PhoneNumber[this->noPN_];
      	
      	for(int i = 0; i < this->noPN_; i++)
      	{
      	   this->phoneNumber_[i] = src.phoneNumber_[i];	
		}
	  }
	  //Else set the current object to empty
	  else
	  {
	  	this->setEmpty();
	  }
  }
  //Assignment operator
 Contact& Contact::operator=(const Contact& src)
 {
 	//Check for self-assignment
 	if(this != &src)
 	{
 	  //Shallow copy non-resource variables
 	  strncpy(this->name_, src.name_, 41);
 	  this->name_[41] = '\0';
      this->noPN_ = src.noPN_;
      
      //Deallocate previously allocated dynamic memory
      delete [] this->phoneNumber_;
      if(src.phoneNumber_ != nullptr)
      {
      	//Allocate new dynamic memory, if needed
      	this->phoneNumber_ = new PhoneNumber[this->noPN_];
      	//Copy the resource data
      	for(int i = 0; i < this->noPN_; i++)
      	{
      	   this->phoneNumber_[i] = src.phoneNumber_[i];
		}
	  }
	  //Else set the current object to empty 
	  else
	  {
	  	this->setEmpty();
	  }
	}
	return *this;
 }
 
  //Display the elements in the phoneNumber_
  void Contact::display() const
  {
  	cout << this->name_ << endl;
  	for(int i = 0; i < this -> noPN_; i++)
  	{
	   this->phoneNumber_[i].display(); 
	}
	cout << "----------------------------------------" << endl; 
  }
  
  
  void Contact::read(){
    cout << "Contact Name: ";
    cin.getline(name_, 41, '\n');
    cout << "Please enter " << noPN_ << " phone numbers: " << endl;
    for (int i = 0; i < noPN_; i++){
      cout << i + 1 << ": ";
      phoneNumber_[i].read();
    }
  }

  bool Contact::isEmpty()const{
    return phoneNumber_ == nullptr;
  }

  void Contact::setEmpty(){
    name_[0] = 0;
    noPN_ = 0;
    phoneNumber_ = nullptr;
  }

}
