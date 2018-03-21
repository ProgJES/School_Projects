/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#ifndef ICT_CUSTOMMADE_H__
#define ICT_CUSTOMMADE_H__
#include "OnShelf.h"
#include "Date.h"
#include "Error.h"
namespace ict 
{
   class CustomMade : public OnShelf
   {
      private:
         Date delivery_;
      public:
      	 /***Constructor***/
         CustomMade();
         virtual ~CustomMade();
         /***Public member function***/
	 	 const Date& delivery() const;
         void delivery(const Date &value);
         /***Pure virtual functions from ReadWritable***/
         virtual std::fstream& store(std::fstream& file, bool addNewLine = true)const;
         virtual std::fstream& load(std::fstream& file);
         virtual std::ostream& display(std::ostream& os, bool linear)const;
         virtual std::istream& conInput(std::istream& is);
   };
}


#endif
