/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#include "OnShelf.h"
using namespace std;

namespace ict 
{
	/***Constructor***/
	/*
	   constructor that receives the value for the filetag_ member variable and if this value is not provided, 
	   it will use the character ¡®O¡¯ as the default value for the argument.
	*/
   OnShelf::OnShelf(char recTag)
   {
   	  this->recTag_ = recTag;
   }
   //virtual destructor
   OnShelf::~OnShelf()
   {
   }
   
   
   /***File Stream Definitions***/
   /*
      Using the operator<< of ostream first writes the recTag_ member variable and a comma into the file argument, 
	  then without any formatting or spaces writes all the member variables of the Good class, comma separated
   */
   fstream& OnShelf::store(fstream& file, bool addNewLine) const	
   {
	  if(addNewLine == true)
	  {
	  	file << this->recTag_ << "," << this->sku() << "," << this->name() << "," << this->price() << "," << this->taxed() << ","
	  	     << this->quantity() << "," << this->qtyNeeded() << endl;
	  }
	  else
	  {
	  	file << this->recTag_ << "," << this->sku() << "," << this->name() << "," << this->price() << "," << this->taxed() << ","
	  	     << this->quantity() << "," << this->qtyNeeded();
	  }
	  
	  return file;
   }
   /*
      Using the operator>>, ignore and getline methods of istream, OnShelf reads all the comma separated fields form the current record in the file and sets the member variables using the setter methods. 
	  When reading the fields, load assumes that the record does not have the ¡°O,¡± (the filetag_) at the beginning,
	  so it starts the reading from the sku. 
   */
   fstream& OnShelf::load(fstream& file)
   {
      char sku[MAX_SKU_LEN + 1];
      char name[20];
      double price;
      bool taxed;
      int quantity;
      int qtyNeeded;

	  file.getline(sku, 50, ',');
	  
	  file.getline(name, 50, ',');
	  file >> price;
	  file.ignore(1);
	  file >> taxed;
	  file.ignore(1);
	  file >> quantity;
	  file.ignore(1);
	  file >> qtyNeeded;

	  this->sku(sku);
	  this->name(name);
	  this->price(price);
	  this->taxed(taxed);
	  this->quantity(quantity);
	  this->qtyNeeded(qtyNeeded);
	  
	  return file;
   }
   /*
      If the err_ member variable is not clear (use isClear member function). 
	  It simply prints the err_ using ostr and returns ostr. If the err_ member variable is clear (No Error) 
	  then depending on the value of linear, display(), prints the Good class in different formats:
   */
   ostream& OnShelf::display(ostream& os, bool linear) const
   {
   	  if(!this->err_.isClear())
   	  {
   	     os << this->err_.message();
	  }
	  else
	  {
	  	 char temp[20];
	  	 strncpy(temp, this->name(), 20); //Truncate if the name goes over 20 characters
	  	 if(linear)
	  	 {
	  	    os << left  << setw(4)  << setfill(' ') 							<< this->sku()       << "|"
			   << left  << setw(20) << setfill(' ') 							<< temp              << "|"
			   << right << setw(7)  << setfill(' ') << fixed << setprecision(2) << this->cost()      << "|";
			   if(this->taxed())
			   {
			   	  os << " t |";  
			   }
			   else
			   {
			   	  os << "   |";
			   }
			os << right << setw(4)  << setfill(' ')								<< this->quantity()  << "|"
			   << right << setw(4)  << setfill(' ') 							<< this->qtyNeeded() << "|";	
		 }
		 else
		 {
		 	if(this->taxed())
		 	{
		 	   os << "Sku: "   			  << this->sku()   		<< endl
			      << "Name: "  			  << this->name()  		<< endl
			      << "Price: " 			  << this->price() 		<< endl
			      << "Price after tax: "  << this->cost() 		<< endl
			      << "Quantity On Hand: " << this->quantity()   << endl
			      << "Quantity Needed: "  << this->qtyNeeded();	
			}
			else
			{
				os << "Sku: "   			  << this->sku()   		<< endl
			       << "Name: "  			  << this->name()  		<< endl
			       << "Price: " 			  << this->price() 		<< endl
			       << "Price after tax: N/A"      					<< endl
			       << "Quantity On Hand: "    << this->quantity()   << endl
			       << "Quantity Needed: "     << this->qtyNeeded();	
			}
		 }
	  }
	  return os;
   }
   
   //Receives the values using istream
   istream& OnShelf::conInput(istream& is)
   {
   	  char sku[MAX_SKU_LEN + 1];
      char name[20];
      double price;
      char taxed;
      int quantity;
      int qtyNeeded;
	  
	  cout << "Sku: ";
	  is >> sku;	
	  cout << "Name: ";
	  is >> name;
	  cout << "Price: ";
	  is >> price;
	  is.ignore(999, '\n');
	  if(is.fail())
	  {
	     this->err_.message("Invalid Price Entry");
	  	 return is;
	  }
	  else
	  { 
	     this->err_.clear();
		 
	     cout << "Taxed: ";
		 is >> taxed;

	     if(!(taxed == 'y' || taxed == 'Y' || taxed == 'n' || taxed == 'N'))
	     {
	  	    is.setstate(ios::failbit); //Set error state manually
	  	    this->err_.message("Only (Y)es or (N)o are acceptable");
	  	 
	  	    return is;
	     }
	     else
	     {
	     	this->err_.clear();
	     	is.clear();
	        cout << "Quantity On hand: ";
	        is >> quantity;
			is.ignore(999, '\n');
	        if(is.fail())
	        {
	  	       this->err_.message("Invalid Quantity Entry");
	  	       return is;
	        }
	        else
	        {   
	           this->err_.clear();
	           cout << "Quantity Needed: ";
	           is >> qtyNeeded;
			   is.ignore(999, '\n');
	           if(is.fail())
	           {
	  	          this->err_.message("Invalid Quantity Needed Entry");
	  	             
				  return is;
	           }
	           else
	           {
	           	  this->sku(sku);
	              this->name(name);
	              this->price(price);
	              this->quantity(quantity);
	              this->qtyNeeded(qtyNeeded);
	           	  if(taxed == 'Y' || taxed == 'y') 
	           	  {
	     		     this->taxed(true);
	              }
	              else
	              {
	                 this->taxed(false);
				  } 
			    }
		    }
        }
    } 

	  return is;
   }
}
