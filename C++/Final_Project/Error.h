/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#ifndef SICT_ERROR_H__
#define SICT_ERROR_H__
#include <iostream>
namespace ict
{
  class Error
  {
  	private:
  	    char* message_;
  	public:
  		/*Constructor*/
  		Error();
  		Error(const char* Error);
  		/*Public member functions and operator overloads*/
  		
		//A delete copy constructor and assignment operator overload to prevent an Error object to be copied/assigned
  		Error(const Error& em) = delete;
  	   	Error& operator = (const Error& em) = delete;
  	   	
  	   	Error& operator = (const char* errorMessage);
			 	
  	   	virtual ~Error();
  	   	
  	   	void clear();
  	   	bool isClear() const;
  	   	void message(const char* value);
  	   	const char* message() const;
  	   	
	   
  };
  // operator<< overload prototype
  std::ostream& operator << (std::ostream&, const Error&);
}
#endif

