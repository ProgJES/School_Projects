/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#ifndef ICT_ONSHELF_H__
#define ICT_ONSHELF_H__
#include <iomanip>
#include "Good.h"
#include "Error.h"
namespace ict 
{
   class OnShelf : public Good
   {
   private:
      char recTag_;
   protected:
   	  Error err_;
   public:
   	  /***Constructor***/
      OnShelf(char recTag = 'O');
      /***Destructor***/
      virtual ~OnShelf();
      /***Pure virtual functions from ReadWritable***/
      virtual std::fstream& store(std::fstream& file, bool addNewLine = true)const;
      virtual std::fstream& load(std::fstream& file);
      virtual std::ostream& display(std::ostream& os, bool linear)const;
      virtual std::istream& conInput(std::istream& is);
   };
}
#endif
