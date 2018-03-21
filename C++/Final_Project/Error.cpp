/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#include <cstring>
#include "Error.h"

namespace ict
{
	//Sets the message_ member variable to nullptr
   Error::Error()
   {
      this->message_ = nullptr;
   }
   
   /*
      1. Sets the message_ memeber variable to nullptr  
	  2. then uses the message() setter member function to set the error message to the Error argument 
   */
   Error::Error(const char* Error)
   {
   	   this->message_ = nullptr;
   	   this->message(Error);
   }
   
   /*
      Sets the message_ to the  Error argument and returns the current object (*this) by: 
         1. De-allocating the memory pointed by message_
         2. Allocating memory to the same length of Error + 1 and keeping the address in message_ data member
         3. Copying Error c-style into message_
         4. Return *this
    */
   Error& Error::operator = (const char* errorMessage)
   {
      this->clear(); 
      this->message(errorMessage);
      
      return *this;
      
   }
   
   //De-allocates the memory pointed by message_
   Error::~Error()
   {
      this->clear();
   }
   
   //De-allocates the memory pointed by message_ and then sets message_ to nullptr
   void Error::clear()
   {
      delete [] this->message_;
      this->message_ = nullptr;
   }
   
   //Return true if message_ is nullptr
   bool Error::isClear() const
   {
      return this->message_ == nullptr;
   }
   
   /*
      Sets the message_ of the Error object to a new value by:
         1. De-allocating the memory pointed by message_
         2. Allocating memory to  the same length of value + 1 keeping address in message_ data member
         3. Copying value c-style into message_
   */
   void Error::message(const char* value)
   {
      this->message_ = new char[strlen(value) + 1];
      
      strcpy(this->message_, value);
   }
   
   //Returns the address of kept in message_
   const char* Error::message() const
   {
      return this->message_;
   }
   
   /*
      Overload operator << so the Error can be printed using cout
      If Error isClear(If this function returns true), nothing should be printed, otherwise the c-string pointed by message_ is printed
   */
   std::ostream& operator << (std::ostream& os, const Error& err)
   {
   	   if(!err.isClear())
   	   {
   	      os << err.message();	
	   }
   	   return os;
   }

}
