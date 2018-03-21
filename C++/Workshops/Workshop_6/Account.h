// OOP244 Workshop 6: operators
// File: Account.h (at_home)
// Version: 1.0
// Date: 2016/Oct/20
// Author: Eunseok Jeon
// Student Number: 026 110 148
// Description:
// This is header file for Account
/////////////////////////////////////////////
#ifndef ICT_ACCOUNT_H__
#define ICT_ACCOUNT_H__

#include <iostream>

namespace ict{
   class Account{
      char name_[41];
      double balance_;
   public:
	  //Display function
      void display(bool gotoNewline = true)const;
	  //Default constructor
      Account();
      //Constructor that takes an argument
      Account(double balance);
      //Constructor that takes two argoments
      Account(const char name[], double balance = 0.0);
      
	  
	  //Member operators
      Account& operator += (const Account& acc);
	  Account& operator = (const Account& acc);
	  void operator = (const char* name);
	  
	  //Accessor
	  double getBalance() const;
	  
	  
   };
   //Non-member function
    std::ostream& operator << (std::ostream& out, const Account& acc);
	Account operator + (const Account& firstAcc, const Account& secondAcc);
	double operator += (double&, const Account& acc);
};

#endif
