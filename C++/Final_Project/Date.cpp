/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
// header files go here
#include "Date.h"


using namespace std;

namespace ict {


	                                           /*PRIVATE MEMBER FUNCTIONS*/

   /*
      returns a unique value representing the date
      this value is used to compare two dates
   */
   int Date::value()const 
   {
      return year_ * 372 + mon_ * 31 + day_;
   }
   /* 
      bool validate(), this is an optional private function
      for validation logic and setting the _readErrorCode.
      see the read() function description for more details
   */
   
   //This function sets the "readErrorCode_" member variable to one of the possible values listed in the Date header file.
   void Date::errCode(int errorCode)
   {
   	   this->readErrorCode_ = errorCode;
   }
   //This function sets the member variables to zero, "readErrorCode_" to "NO_ERROR(0)"
   void Date::setEmpty() 
   {
   	   this->year_ = 0;
   	   this->mon_ = 0;
   	   this->day_ = 0;
   	   this->errCode(NO_ERROR);
   }


                                                      /*CONSTRUCTORS*/
   
   //Default constructor that sets the member variables safe empty state
   Date::Date()
   {
      this->setEmpty();   	
   }
   //This constructor accepts three arguments to set the values of year_, mon_ and day_. It also sets the readErrorCode_ to NO_ERROR. 
   Date::Date(int year, int mon, int day)
   {
      this->year_ = year;
      this->mon_ = mon;
      this->day_ = day;
      this->errCode(NO_ERROR);
   }
   //Destructor
   Date::~Date()
   {}


   
   
   
                                                       /* MEMBER FUNCTIONS */
   //Returns the "readErrorCode_" value
   int Date::errCode() const
   {
      return this->readErrorCode_;
   }
   
   //Return true if "readErrorCode_" is not equals to zero
   bool Date::bad() const
   {
      return this->readErrorCode_ != NO_ERROR;
   }
   
   /* 
      mdays():
      returns the day of the month.
       _mon value must be set for this function to work
       if _mon is invalid, this function returns -1
       leap years are considered in this logic
    */
   int Date::mdays()const {
      int days[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, -1 };
      int mon = mon_ >= 1 && mon_ <= 12 ? mon_ : 13;
      mon--;
      return days[mon] + int((mon == 1)*((year_ % 4 == 0) && (year_ % 100 != 0)) || (year_ % 400 == 0));
   }


                                                /* OPERATORS*/
                                                
   /*
      These operators return the result of comparing the left operand to the right operand.  
      These operators use the value() member function in their comparison. 
      For example operator< returns true if this->value() is less than D.value(); otherwise returns false.
   */ 
   bool Date::operator==(const Date& D)const
   {
      return this->value() == D.value();
   }
   
   bool Date::operator!=(const Date& D)const 
   {
      return this->value() != D.value();
   }
   
   bool Date::operator<(const Date& D)const 
   {
   	   return this->value() < D.value();
   }
   
   bool Date::operator>(const Date& D)const 
   {
      return this->value() > D.value();
   }
   
   bool Date::operator<=(const Date& D)const 
   {
   	  return this->value() <= D.value();
   }
   
   bool Date::operator>=(const Date& D)const
   {
   	  return this->value() >= D.value();
   }



                                                     /*IO FUNCTIONS*/
    /*
	   This function writes the date to the ostream object in the following format: 
	   YYYY/MM/DD, then returns a reference to the ostream object.    
	*/                                              
   ostream& Date::write(ostream& ostr) const
   {   
	   ostr << this->year_ << "/" << right << setw(2) << setfill('0') << this->mon_ << "/" << right << setw(2) << setfill('0') << this->day_;
	   
   	   return ostr;
   }
   /*
      Reads the date in following format: YYYY/MM/DD
      Irrespective of the result of the process, this function returns a reference to the istream object. 
   */
   istream& Date::read(istream& istr)
   {
   	   char backSlash;
   	   
	   istr >> this->year_ >> backSlash >> this->mon_ >> backSlash >> this->day_; 
   	   
   	   //readErrorCode_ to CIN_FAILED and does NOT clear the istream object.
   	   if(istr.fail())
   	   {
   	      this->errCode(CIN_FAILED);	
	   }
	   /*
	      It validate the data members, if they are out of range,
	      it sets  readErrorCode_ to the appropriate error code and omits any further validation.
	   */
	   else
	   {
	   	  if(this->year_ < MIN_YEAR || this->year_ > MAX_YEAR)
	   	  {
	   	     this->errCode(YEAR_ERROR);	
		  }
		  else
		  {
		     if(this->mon_ < 1 || this->mon_ > 12)
		     {
		  	    this->errCode(MON_ERROR);
		     }
		     else
		     {
		        if(this->day_ < 1 || this->day_ > this->mdays())
		        {
		  	       this->errCode(DAY_ERROR);
		        }
				else
				{
					this->errCode(NO_ERROR);
				}
		     }
		  }
	   }
	   
	   return istr;
   }



   												/* NON-MEMBER OPERATOR OVERLOADS */
   
   //Non-member ostream operator overloads, it enables user to write the syntax "cout << OBJECT << endl;" in main function	
   std::ostream& operator << (std::ostream& os, const Date& date)
   {
       return date.write(os);    	
   }
   //Non-member istream operator overloads, it enables user to write the syntax "cin >> OBJECT;" in main function
   std::istream& operator >> (std::istream& is, Date& date)
   {
   	   return date.read(is);
   }

}
