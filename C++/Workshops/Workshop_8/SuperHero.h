/*
Student name: Eunseok Jeon
Student number: 026 110 148
Date: 2016/Nov/10
*/
#include "Hero.h"

//Derived class : Base class
class SuperHero : public Hero  
{
   double _shMultiplier;
   char copy[20];
   
   public:
      SuperHero();
      SuperHero(const char*, double, double);
      double getStrength() const;
      void operator *= (SuperHero&);
      void display(std::ostream&) const;
      void setEmpty(); 
};

