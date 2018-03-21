/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#include "CustomMade.h"
using namespace std;

namespace ict {
   //Constructor invokes the "OnShelf" constructor passing the value 'C' for the recTag argument
   CustomMade::CustomMade() : OnShelf('C')
   {
   	
   }
   //Virtual destructor
   CustomMade::~CustomMade()
   {
   	
   }
   /***Public member functions***/
   
   //returns a constant reference to delivery_ member variable. 
   const Date& CustomMade::delivery() const
   {
      return this->delivery_;
   }
   //Sets the delivery_ attribute to the incoming value. 
   void CustomMade::delivery(const Date& value)
   {
      this->delivery_ = value;
   }
   /***Pure virtual function implementation***/
   /*
      CustomMade re-implements all four virtual methods of the OnShelf
      Calls the parent¡¯s store passing the file and a ¡°false¡± value as arguments and then writes a comma and 
	  the delivery date into the file. If the addNewLine argument is true, it will write a newline into the file.
    */
   fstream& CustomMade::store(fstream& file, bool addNewLine) const
   {
	  	 OnShelf::store(file, false);
	  	 if(addNewLine)
	  	 {
	  	    file << "," << this->delivery() << endl;
		 }
		 else
		 {
		 	file << "," << this->delivery();
		 }
	  
	  return file;
   }
   /*
      Calls the parent¡¯s load passing the file as the argument and then calls the read method of the delivery_ object 
	  passing the file as the argument and then ignores one character (reads one character from the file and dumps it). 
   */
   fstream& CustomMade::load(fstream& file)
   {
	  OnShelf::load(file);
	  
	  file.ignore(1);
	  file >> this->delivery_;		 

	  return file;
   }
   /*
      Calls the display of the parent passing ostr and linear as arguments. Then if err_ is clear and Good is not empty, 
      run a if statement
   */
   ostream& CustomMade::display(ostream& os, bool linear)const
   {
      OnShelf::display(os, linear);
      char temp[MAX_SKU_LEN + 1];
	  strcpy(temp, this->sku());
	  
      if(this->err_.isClear() && temp[0] != '\0')
	  {
	  	 if(linear)
	  	 {	
	  	    os << this->delivery();	
		 }
		 else
		 {
		 	os << endl << "delivery date: "<< this->delivery();
		 }
	  }
	  return os;
   }
   /*
      It will call the parent¡¯s conInput passing istr as argument.  
      Then if err_ is clear it will print: Delivery date (YYYY/MM/DD): then it will read the date from the console 
	  into a temporary Date object. 
   */
   istream& CustomMade::conInput(istream& is)
   {
   	  Date tempDate;
      OnShelf::conInput(is);
      
	  if(this->err_.isClear())
      {
      	 cout << "delivery date (YYYY/MM/DD) : ";
      	 is >> tempDate;
      	 if(tempDate.errCode() == 1)
	  	 {
	  	    is.setstate(ios::failbit);
			this->err_.message("Invalid Date Entry");
		 }
		 else
		 {
		 	if(tempDate.errCode() == 2)
		 	{
		 	   is.setstate(ios::failbit);
			   this->err_.message("Invalid Year in Date Entry");
			}
			else
			{
				if(tempDate.errCode() == 3)
				{
				   is.setstate(ios::failbit);
				   this->err_.message("Invalid Month in Date Entry");	
				}
				else
				{
					if(tempDate.errCode() == 4)
					{
					   is.setstate(ios::failbit);
					   this->err_.message("Invalid Day in Date Entry");	
					}
					else
					{
						this->delivery(tempDate);
					}
				}
			}
		 }
	  }
      return is;
   }
}
