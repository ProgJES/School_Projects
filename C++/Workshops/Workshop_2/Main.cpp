/***********************************************
Author: Eunseok Jeon
Date: 2016/September/20
************************************************/

#include <iostream>
using namespace std;
#include "AccountNumber.h"
using namespace sict;
void displayAccountNumber(const AccountNumber* acc);
int main(){
  AccountNumber myNumber;
  char name[41];
  int bankCode;
  int branchCode;
  int accNumber;
  cout << "Bank account app" << endl <<
    "===================" << endl << endl;
  cout << "Please enter your name: ";
  cin >> name;
  cout << "please enter your bank account ,branch code" <<
    ", and account number as follows:" << endl << "999 999 99999: ";
  do{
    cin >> bankCode >> branchCode >> accNumber;
    //if cin failes, clear the fail flag and remove user input by using ignore
    if(cin.fail())
    {
    	cout << "Error! Please enter account number in a correct format!" << endl;
    	cin.clear();
    	cin.ignore(1000, '\n');
	}
	else
	{
		myNumber.name(name);
    	myNumber.accountNumber(bankCode, branchCode, accNumber);
    
    	displayAccountNumber(&myNumber);
	}
    

  } while (!myNumber.isValid()
    && cout << "Invalid account number, (999 999 9999), try again: ");
  cout << "Thank you!" << endl;
  return 0;
}
void displayAccountNumber(const AccountNumber* acc){
  acc->display();
  cout << "-------------" << endl;
  acc->display(false);
  cout << "-------------" << endl;
  acc->display(true, false);
  cout << "-------------" << endl;
  acc->display(false, false);
}
