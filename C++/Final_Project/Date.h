/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#ifndef ICT_DATE_H__
#define ICT_DATE_H__
// header file includes
#include <iostream>
#include <iomanip>
#include "wpgeneral.h"


namespace ict {
   // Error code values go here
      //NO_ERROR   0  -- No error - the date is valid
      #define NO_ERROR 0
      //CIN_FAILED 1  -- istream failed on accepting information 
      #define CIN_FAILED 1
      //YEAR_ERROR 2  -- Year value is invalid 
      #define YEAR_ERROR 2
      //MON_ERROR  3  -- Month value is invalid 
      #define MON_ERROR 3
      //DAY_ERROR  4  -- Day value is invalid
      #define DAY_ERROR 4


   class Date {
   private:
   // private member variables
      //Year, a four digit integer between MIN_YEAR and MAX_YEAR, as defined in "wpgeneral.h"   
	  int year_;
	  //Month of the year, between 1 and 12
	  int mon_;
	  //Day of the month; note that in a leap year February has 29 days(see mday() member function)
	  int day_;
	  //Error code which identifies the validity of the date and, if erroneous, it identifies the part that is incorrect.
      int readErrorCode_; 
      
   // private member functions and setters
      int value()const;
      void errCode(int errorCode);
	  void setEmpty();

   public:
      // constructors
      Date();
      Date(int year, int mon, int day);
      ~Date();
      // operator overloads
      bool operator==(const Date& D)const; 
	  bool operator!=(const Date& D)const; 
	  bool operator<(const Date& D)const; 
	  bool operator>(const Date& D)const; 
	  bool operator<=(const Date& D)const; 
	  bool operator>=(const Date& D)const;
	  
      // IO member functions
      std::ostream& write(std::ostream& ostr) const;
      std::istream& read(std::istream& istr);
      
      // public member functions
      int mdays()const;
      int errCode() const;
      bool bad() const;
   };
   // operator << and >> overloads prototypes for ostream and istream go here
   std::ostream& operator << (std::ostream&, const Date&);
   std::istream& operator >> (std::istream&, Date&);
}

#endif
