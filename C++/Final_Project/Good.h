/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#ifndef ICT_GOOD_H__
#define ICT_GOOD_H__

#include <iostream>
#include <cstring>
#include "ReadWritable.h"
#include "wpgeneral.h"

namespace ict
{
	//Derived class : Base class
   class Good : public ReadWritable
   {
      private:
      	char sku_[MAX_SKU_LEN + 1];
      	char* name_;
      	double price_;
      	bool taxed_;
      	int quantity_;
      	int qtyNeeded_;

      public:
      	/*Constructors*/
      	Good();
      	Good(const char*, const char*, double, int, bool taxed = true);
      	Good(const Good&);
      	
      	/*Virtual destructor*/
      	virtual ~Good();
      	
      	/*Public member functions: */
      	void setEmpty();
      	void clear();

        /*Setters*/
		void sku(const char*);
		void name(const char*);
		void price(double);
		void taxed(bool);
		void quantity(int);
		void qtyNeeded(int);
		
		/*Getters*/
		const char* sku() const;
		const char* name() const;
		double price() const;    
		bool taxed() const;
		int quantity() const;
		int qtyNeeded() const;
	    double cost() const;
	    
		/*Member operator overloads*/
		Good& operator = (const Good&);
		bool operator == (const char*);
		int operator += (const int); 	 
	  	
   };
   
   /*Non-member operator overload*/
   double operator += (double&, const Good&);
   std::ostream& operator << (std::ostream&, const Good&);
   std::istream& operator >> (std::istream&, Good&);
}


#endif
