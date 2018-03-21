// OOP244 Workshop 4: Constructors
// File: Enrollment.cpp
// Version: 1.0
// Date: 2016/Oct/4
// Author: Eunseok Jeon
// Section: OOP244SCC
// Student ID: 026 110 148
// Description:
// implementation file for Enrollemnt
/////////////////////////////////////////////
#include <iostream>
#include "string.h"
#include "Enrollment.h"
using namespace std;


//namespace ict
namespace ict
{
	//Empty constructor that sets the object to a safe empty state
	Enrollment::Enrollment()
	{
		setEmpty();
	}
	//Constructor that takes 5 arguments and call the set function without value of enrolled(it will automatically sets to false when I call the function "set" without enrolled value). 
	Enrollment::Enrollment(const char* name, const char* code, int year, int semester, int time)
	{
		set(name, code, year, semester, time);
	}
	//Destructor which sets the object to a safe empty state
	Enrollment::~Enrollment()
	{
		setEmpty();
	}
	//Function that checks and validates the values. Otherwise, sest the object to a safe empty state.
	void Enrollment::set(const char* name, const char* code, int year, int semester, int time, bool enrolled)
	{
		if (NULL != name && '\0' != name[0] &&
			NULL != code && '\0' != code[0] &&
			year >= 2015 && 
			semester > 0 && semester < 4    &&
			time > 0     && time < 6)
		{
			strcpy(this->name_, name);
			strcpy(this->code_, code);
			this->year_ = year;
			this->semester_ = semester;
			this->slot_ = time;
			this->enrolled_ = enrolled;
		}
		else
		{
			setEmpty();
		}
		
	}
	//Function that checks and return true if there is a conflict
	bool Enrollment::hasConflict(const Enrollment &other) const
	{
		if(isValid())
		{
		   if(this->year_ == other.year_ && this->semester_ == other.semester_ && this->slot_ == other.slot_)
		      return true;
		}
		return false;   
	}
	//Modifier that withdraws the student from the course.
	void Enrollment::withdraw()
	{
		enrolled_ = false;
	}
	
	//A function that sets the enrolled flag to true and return 0; unless there is a conflict between enrollments array.
	//If a conflict found, the function returns the sequence number of the element in conflict(i.e. returns index+1) and the
	//enrollment flag remains false. The parameter size represents the size of the enrollments array 
	int Enrollment::enrol(const Enrollment* enrollments, int size)
	{
		//Run for loop until the index < size
		for (int index = 0; index < size; index++)
		{
			//Run a for loop until i < size
			//If there is a conflict between "this object" and "enrollments array" it will return index + 1 and set enrolled_ = false;
			if (hasConflict(enrollments[index]))
			{
				this->enrolled_ = false;

				return index + 1;
			}
		}

		//If ther is no conflict set enrolled_ to true and return 0
		this->enrolled_ = true;
	
		return 0;
	}
	
	
	
	
	
	
  /**********************Coded**********************/	 
  //done
  bool Enrollment::isValid() const
  {
    return name_ && name_[0];
  }
  //done
  void Enrollment::setEmpty(){
    name_[0] = 0;
    code_[0] = 0;
    year_ = 0;
    semester_ = 0;
    slot_ = 0;
    enrolled_ = false;
  }
  // done
  bool Enrollment::isEnrolled() const{
    return enrolled_;
  }

  // done
  void Enrollment::display(bool nameOnly)const{
    if (isValid()){
      cout << name_;
      if (!nameOnly){
        cout << endl << code_ << ", Year: " << year_ << " semester: " << semester_ << " Slot: " << slot_ << endl;
        cout << "Status: " << (isEnrolled() ? "E" : "Not e") << "nrolled." << endl;
      }
    }
    else{
      cout << "Invalid enrollment!" << endl;
    }
  }
}
