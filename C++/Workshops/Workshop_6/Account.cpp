// OOP244 Workshop 6: operators
// File: Account.cpp (at_home)
// Version: 1.0
// Date: 2016/Oct/20
// Author: Eunseok Jeon
// Student Number: 026 110 148
// Description:
// This is implementation file for Account
/////////////////////////////////////////////
#include <iostream>
#include <iomanip>
#include "string.h"
#include "Account.h"

using namespace std;

namespace ict{
    //Display function
    void Account::display(bool gotoNewline)const{
        cout << (name_[0] ? name_: "No Name") << ": $" << setprecision(2) << fixed << balance_;
        if (gotoNewline) cout << endl;
    }

    //Default constructor that sets the variables to safe empty state
    Account::Account(){
        name_[0] = 0;
        balance_ = 0;
    }
    //Constructor that takes an argument(double balnace) and sets the name to empty and balance to the incoming double value
    Account::Account(double balance){
        name_[0] = 0;
        balance_ = balance;
    }
    //Constructor that takes two arguments and sets the name and balnace to incoming values.
    Account::Account(const char name[], double balance){
		strcpy(name_, name);
        balance_ = balance;
    }
    //Member operators
    //"+=" opeartor overloads, sets the "this->balance" to incoming value "acc.balance"
    Account& Account:: operator += (const Account& acc)
    {
    	this->balance_ += acc.balance_;
    	
    	return *this;
	}
	//"=" operator overloads, sets the "this->name" to incoming value "name"
	void Account:: operator = (const char* name)
	{
		strcpy(this->name_, name); 
	}
	//"=" (assignment) operator overloads, it copies the member variables from the another object "acc" 
	Account& Account:: operator = (const Account& acc)
	{
		strcpy(this->name_, acc.name_);
		this->balance_ = acc.balance_;
		
		return *this;
	}
	
   
   //Accessor that returns current object's balance
   double Account::getBalance() const
   {
   	  return this->balance_;
   }
   
   
   //Non-member ostream operator function, it enables user to write the syntax "cout << OBJECT << endl;" in main function
   ostream& operator <<(ostream& out, const Account& acc)
   {
   	  acc.display(false);
   	  
   	  return out;
   }
   //Non-member "+" operator overload function, it enables user add balance from another object
   Account operator + (const Account& firstAcc, const Account& secondAcc)
   { 	  
   	  return Account(firstAcc.getBalance() + secondAcc.getBalance());
   }
   //Non-member "+=" operator overload function, it adds object's variable "balance_" to the variable that is type of double
   double operator += (double& balance, const Account& acc)
   {
   	   balance += acc.getBalance();
   	   
   	   return balance;
   }
}
