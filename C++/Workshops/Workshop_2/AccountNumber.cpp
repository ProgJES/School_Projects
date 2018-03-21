/***********************************************
Author: Eunseok Jeon
Date: 2016/September/20

************************************************/
// Description
// This is the implementation file(all member functions' definition) for AccountNumber.h
#include <iostream>
#include <cstring>
using namespace std;
#include "AccountNumber.h"

namespace sict{
  // member functions' (methods') definition go here

	//Private member function that prints name.
	void AccountNumber::displayName() const
	{
	   cout << "Name: " << _name << endl;	
	}
	//Private member function that prints account number.
	void AccountNumber::displayNumber() const	
	{
	   cout << "Account Number: " << _bankCode << "-" << _branchCode << "-" << _accountNumber << endl;
	}
	
	//sets the _name character string in an AccountNumber Obect using the strcpy function
	void AccountNumber::name(const char name[]) 
	{
	   strcpy(_name, name);
	}
	
	/*
	 The accountNumber() function sets the _bankCode, _branchCode and _accountNumber integers in an AccountNumber object
	 and sets _validAccNumber to true or false depending on the value of _bankCode, _branchCode and _accountNumber are
	 within MIN_BACKCODE - MAX_BANKCODE, MIN_BRANCHCODE - MAX_BRANCHCODE, and MIN_ACCNO - MAX_ACCNO
	 */
	void AccountNumber::accountNumber(int bankCode, int branchCode, int accountNumber)
	{
		
		//Check bankCode is in a valid range or not, else sets _validAccNumber to false
		if (bankCode >= MIN_BANKCODE && bankCode <= MAX_BANKCODE)
		{
			//Check branchCode is in a valid range or not
			if (branchCode >= MIN_BRANCHCODE && branchCode <= MAX_BRANCHCODE)
			{
				//Check accountNumber is in a valid range or not
				if (accountNumber >= MIN_ACCNO && accountNumber <= MAX_ACCNO)
				{
					//if they are all in the appropriate range, then sets the values
					_bankCode = bankCode;
					_branchCode = branchCode;
					_accountNumber = accountNumber;
					_validAccNumber = true;
				}
				else
				{
					_validAccNumber = false;
				}
			}
			else
			{
				_validAccNumber = false;
			}
		}
		else
		{
			_validAccNumber = false;
		}

	}
	
	/*The display() function checks if the AccountNumber isValid(). If so, it displays the current AccountNumber object:
	         cout << "Name: " << _name << ", Account number: " << _bankCode << "-"  << _branchCode << "-" << _accountNumber << endl; 
	  If AccountNumber is not Valid it displays:          
	         cout << _name << " does not have a valid account number." << endl;
	*/
	void AccountNumber::display() const
	{
		if(isValid())
		{
			cout << "Name: " << _name << ", Account number: " << _bankCode << "-" << _branchCode << "-" << _accountNumber << endl;
		}
	    else
	    {
	    	cout << _name << " does not have a valid account number." << endl;
		}
	}
	
	//This display function will prints name and account number if the boolean value is set to true
	//otherwise it will print account number only.
	void AccountNumber::display(bool name) const
	{
		if(isValid())
		{
		   if(!name)
		   {
		      displayNumber();
		   }
		   else
		   {
		      displayName();
			  displayNumber();
		   }	
		}
		else
		{
		   cout << _name << " does not have a valid account number." << endl;	
		}
	}
    //This display function will print the name and account number if the boolean values are set to true
	//otherwise it will print nothing 
	void AccountNumber::display(bool name, bool accNumber) const
	{
		if(isValid())
		{
		   if(name)
		   {
		      displayName();
		   
		      if(accNumber)
		      {
		   	     displayNumber();
		      }
		   }
		   else if(!name)
		   {
		      if(accNumber)
			  {
				displayNumber();
			  } 
		   }
	    }
	    else
	    {
	       cout << _name << " does not have a valid account number." << endl;	
		}
	}
	
	/*The isValid()function returns the value of _validAccNumber */
	bool AccountNumber::isValid() const
	{
	   return _validAccNumber;
	}

}
