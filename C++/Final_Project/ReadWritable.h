/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#ifndef ICT_READWRITABLE_H__
#define ICT_READWRITABLE_H__

#include <iostream>
#include <fstream>
namespace ict {
   class ReadWritable {
   public:
      virtual std::fstream& store(std::fstream& file, bool addNewLine = true)const = 0;
      virtual std::fstream& load(std::fstream& file) = 0;
      virtual std::ostream& display(std::ostream& os, bool linear)const = 0;
      virtual std::istream& conInput(std::istream& is) = 0;
   };
}

#endif // ICT_READWRITABLE
