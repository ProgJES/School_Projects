/*
Student name: Eunseok Jeon
Student number: 026 110 148
Date: 2016/Nov/10
*/
#ifndef ICT_HERO_H
#define ICT_HERO_H

#include <iostream>
#include <cstring>
   
   class Hero
   {
   	  //Privacy level set to protected
   	  protected:
   	  	double _strength;
   	  	char _name[20];
   	  public:
   	  	/*Constructors*/
   	  	Hero();
   	  	Hero(const char*, double);
   	  	
   	  	/*Public member functions*/
   	  	void setEmpty();
   	  	bool isEmpty() const;
   	  	double getStrength() const;
   	  	void display(std::ostream&) const;
   	  	
   	  	/*Overload operators*/
   	  	void operator -= (double strength);
   	  	void operator += (double strength);
   };
   
   /*Helper function*/
   bool operator < (const Hero&, const Hero&);
 	

#endif
