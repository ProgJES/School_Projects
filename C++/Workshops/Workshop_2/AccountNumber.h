/***********************************************
Author: Eunseok Jeon
Date: 2016/September/20
************************************************/

// Description
// This header file contains prototypes of data members and member functions, for validating account.
// Protytypes are declared within the "sict" namespace.


#ifndef SICT_ACCOUNTNUMBER_H_
#define SICT_ACCOUNTNUMBER_H_

namespace sict{
  // #define statements go here
  #define MAX_NAME_LENGTH   40 
  #define MIN_BANKCODE    100 
  #define MAX_BANKCODE   999 
  #define MIN_BRANCHCODE    1 
  #define MAX_BRANCHCODE   220 
  #define MIN_ACCNO    10000 
  #define MAX_ACCNO    99999  
  // class declration goes here
  class AccountNumber
  {
     char _name[MAX_NAME_LENGTH + 1]; 
	 int _bankCode; 
	 int _branchCode;
	 int _accountNumber; 
	 bool _validAccNumber;
	 void displayNumber() const;
	 void displayName() const;

	 public: 	
	 void name(const char name[]);
	 void accountNumber(int bankCode, int branchCode, int accountNumber);
	 void display() const;
	 void display(bool name) const;
	 void display(bool name, bool accNumber) const;
	 bool isValid() const;
  };
}

#endif

