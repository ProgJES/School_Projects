// OOP244 Workshop 4: Constructors
// File: Enrollment.h
// Version: 1.0
// Date: 2016/Oct/4
// Author: Eunseok Jeon
// Section: OOP244SCC
// Student ID: 026 110 148
// Description:
// Header file for Enrollemnt
/////////////////////////////////////////////

//safeguard
#ifndef _ENROLLMENT_H
#define _ENROLLMENT_H
//namespace ict
namespace ict
{
	class Enrollment
	{
		char name_[31];
		char code_[11];
		int year_;
		int semester_;
		int slot_;
		bool enrolled_;
		
	    public:
	   	   //Empty constructor
		   Enrollment(); 
		   //Constructor that takes 5 arguments (name, code, year, semester, slot, and enrooled = false as a default)	
		   Enrollment(const char* name, const char* code, int year, int semester, int time); 
		   //Destructor
		   ~Enrollment(); 
		   //Set function
		   void set(const char* name, const char* code, int year, int semester, int time, bool enrolled = false);
		   //The function checks if there is a conflict
		   bool hasConflict(const Enrollment &other) const;
		   //Modifier that withdraws the student from the course.
		   void withdraw();
		   //A function that sets the enrolled flag to true and return 0; unless there is a conflict between enrollments array.
		   //If a conflict found, the function returns the sequence number of the element in conflict(i.e. returns index+1) and the
		   //enrollment flag remains false. The parameter size represents the size of the enrollments array 
		   int enrol(const Enrollment* enrollments, int size);
		  
		   /*Coded*/
	       bool isEnrolled() const;
	       bool isValid() const;
	       void setEmpty();
	       void display(bool nameOnly = false) const;
	};
}
#endif 
