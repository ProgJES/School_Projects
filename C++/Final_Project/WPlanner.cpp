/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#define _CRT_SECURE_NO_WARNINGS
#include <cstring>
#include <iomanip>
#include "WPlanner.h"
#include "Good.h"
#include "OnShelf.h"
#include "CustomMade.h"

using namespace std;
namespace ict {
	/***Constructor***/
   WPlanner::WPlanner(const char* filename) 
   {
	   strcpy(this->filename_, filename);
	   for (int i = 0; i < MAX_NO_RECS; i++)
	   {
		   this->items_[i] = nullptr;
	   }
	   this->noOfItems_ = 0;
	   this->loadRecs();
   }
   //This function opens the file(filename_) for writing.
   void WPlanner::saveRecs() 
   {
	   this->datafile_.open(this->filename_, ios::out);
	   //Loops through the items_ array up to noOfItems_ and stores each Good in the datafile
	   for (int i = 0; i < this->noOfItems_; i++)
	   {
		   this->items_[i]->store(this->datafile_, true);
	   }

	   this->datafile_.close();
	   
   }
  
   //This function opens the file(filename_) for reading. 
   void WPlanner::loadRecs() 
   {
	 
	   int readIndex = 0;
	   char recTag;
	   this->datafile_.open(this->filename_, ios::in);
	   //If the file does not exist, this function creates an empty file and exits.  
	   if (!this->datafile_.is_open())
	   {
		   this->datafile_.clear();
		   this->datafile_.close();
		   this->datafile_.open(this->filename_, ios::out);
		   this->datafile_.close();
	   }
	   /*
	      If the file exists, this function loads records from the file overwriting 
		  any old ones that may be pointed to by the items_ array.    
	   */
	   else
	   {
		   while (this->datafile_)
		   {
			   //This function makes sure that any old records are deallocated before allocating memory for each new record and loading each records into that memory.
			   delete this->items_[readIndex];
			   
			   this->datafile_.get(recTag);
			   if (recTag == 'C')
			   {
				   this->items_[readIndex] = new CustomMade;
				   this->datafile_.ignore();
				   this->items_[readIndex]->load(this->datafile_);
				   readIndex++;
			   }
			   else if (recTag == 'O')
			   {
				   this->items_[readIndex] = new OnShelf;
				   this->datafile_.ignore();
				   this->items_[readIndex]->load(this->datafile_);
				   readIndex++;
				   
			   }
			   
			   this->noOfItems_ = readIndex;
		   }
		   //Once this function has completed loading, it closes the file and returns control to its caller.
		   this->datafile_.close();
	   }
   }
   void WPlanner::getSku(char* sku) 
   {
      //Receive the SKU from user into sku argument up to MAX_SKU_LEN + 1 or up to '\n' using istream.getline()
	  cout << "Please enter the SKU: ";
	 
	  cin.getline(sku, MAX_SKU_LEN + 1, '\n');
	  
	  //If stream fails, it will clear the istream and flush the keyboard of any remaining characters
	  if (cin.fail())
	  {
		  cin.clear(); 
		  cin.ignore(MAX_SKU_LEN + 1, '\n');
	  }
   }
   //This function deletes the selected sku
   void WPlanner::deleteItem() 
   {
	  char sku[MAX_SKU_LEN + 1];
	  this->getSku(sku);
	  int found = 0;
	  char confirm;
	  found = this->SearchItems(sku);
	  if (found == -1)
	  {
		  cout << endl <<"Item Not found!" << endl << endl;
	  }
	  else
	  {
		  cout << endl << "The following Item will be deleted:" << endl;
		  this->items_[found]->display(cout, false);
		  
		  cout << endl << endl << "Type (Y) to confirm or (N) to abort: ";
		  cin >> confirm;
		  cout << endl;
		  if (confirm == 'Y' || confirm == 'y')
		  {
			 
			  //Delete the item in the array, shift the values of the rest of the array once towards the deleted item
			  delete this->items_[found];
			  for (int i = found; i < this->noOfItems_; i++)
			  {
				  this->items_[i] = this->items_[i + 1];
			  }
			  delete this->items_[this->noOfItems_];
			  this->items_[this->noOfItems_] = nullptr;
			  //Reduce noOfItems_ by one and save the items into the file
			  this->noOfItems_ -= 1;
			  this->saveRecs();
			  cout << "Item deleted!" << endl << endl;
		  }
		  else
		  {
			  cout << "Aborted!" << endl << endl;
		  }

	  }
	  
   }
   /*
      This function will get the SKU of the Good to be updated using getSku() method and then 
	  if the Good is found in the items_ array, the function will update the quantity on hand of the found Good.
	  If the SKU is not found, following error message is displayed:
	  <newline>Not found<newline>
   */
   void WPlanner::updateQty() 
   {
	   char sku[MAX_SKU_LEN + 1];
	   int found;
	   this->getSku(sku);
	   cout << endl;
	   found = this->SearchItems(sku);
	   
	   //If fail to find, display the message Not found
	   if (found == -1)
	   {
		   cout << "Not found" << endl << endl;
	   }
	   else
	   {
		   int purchaseGood = 0; 
		   this->items_[found]->display(cout, false);
		   //Receive data from the user
		   cout << endl << endl << "Please enter the number of purchased goods: ";
		   cin >> purchaseGood;
		   //If fails to read integer, display the message
		   if (cin.fail())
		   {
			   cout << endl << "Invalid Quantity value!" << endl << endl;
		   }
		   else
		   {
			   //Variable that holds quantity needed to be purchased
			   int qtyNeed = 0;
			   
			   qtyNeed = this->items_[found]->qtyNeeded() - this->items_[found]->quantity();
			   
			   //If purchasedGood is greater than qtyNeedd display the message
			   if (purchaseGood > qtyNeed)
			   {
				   cout << endl << "Too many purchased, only " << qtyNeed << " needed, please return the extra " << purchaseGood - qtyNeed << "." << endl << endl;
			   }
			   //Add purchasedGood into quantity
			   else
			   {
				   *(this->items_[found]) += purchaseGood;
				   this->saveRecs();
				   cout << endl << "Updated!" << endl << endl;
			   }
		   }
		   cin.clear();
		   cin.ignore(999, '\n');
	   }
   }
   //This function prints out the result
   void WPlanner::listItems()const 
   {
	  double totalCost = 0.0;
      cout << " Row | SKU | Good Name          | Cost  |Tax| QTY|Need| Delivery" << endl
           << "-----|-----|--------------------|-------|---|----|----|----------" << endl;

	  for (int i = 0; i < this->noOfItems_; i++)
	  {
		  
		  //Prints the Row number in a field of 4 digit right-justified and print a Bar surrounded by two spaces
		  cout << right << setw(4) << setfill(' ') << i + 1 << " | "; 
		  //Print current Good followed by newline
		  this->items_[i]->display(cout, true);
		  cout << endl;
		  //Add totalCost
		  totalCost += *this->items_[i];
	  }
      cout << "-----+-----+--------------------+-------+---+----+----+----------" << endl;
	  cout << "Total cost of the Wedding: $" << fixed << setprecision(2) << totalCost << endl << endl;
   }
   /*
      This function loops through the item_ array up to noOfItems_ and checks each one for the same SKU as 
	  incoming argument using the operator == implemented for the Good class. 
	  If this function finds a match it returns the index, otherwise it returns -1
   */
   int WPlanner::SearchItems(const char* sku)const 
   {
	   for (int i = 0; i < this->noOfItems_; i++)
	   {
		   if (strcmp(this->items_[i]->sku(),sku) == 0)
		   {
			   return i;
		   }
	   }
	   return -1;
   }
   //This function adds Good to the end of the items_ array
   void WPlanner::addItem(bool isCustomMade) 
   {
	   if (isCustomMade == true)
	   {
		   //Creates CustomMade object and gets its values from the user
		   this->items_[this->noOfItems_] = new CustomMade;
		   this->items_[this->noOfItems_]->conInput(cin);
		   
		   //If an error occurs, this function displays the Good and exits the function
		   if (cin.fail())
		   {
			   cin.clear();
			   cin.ignore(999, '\n');
			   cout << endl;
			   this->items_[this->noOfItems_]->display(cout, true);
			   cout << endl << endl;
		   }

		   /*
		   If no error occurs, this function adds new Good to the end of the items_ array adding one
		   to the no of items(noOfItems_) and saves the items_ in the the datafile_ using saveRec()
		   */
		   else
		   {
			   this->noOfItems_ += 1;
			   saveRecs();
			   cout << endl << "Good added" << endl << endl;
		   }
	   }
	   else
	   {
		   this->items_[this->noOfItems_] = new OnShelf;
		   this->items_[this->noOfItems_]->conInput(cin);
		   
		   if (cin.fail())
		   {
			   cin.clear();
			   cin.ignore(999, '\n');
			   cout << endl;
			   this->items_[this->noOfItems_]->display(cout, true);
			   cout << endl << endl;
		   }
		   else
		   {
			   this->noOfItems_ += 1;
			   saveRecs();
			   cout << endl << "Good added" << endl << endl;
		   }
	   }
   }
   int WPlanner::menu() 
   {
      int selection = -1;
	  
	  cout << "Wedding Planner Management Program" << endl
		   << "1 - List goods" << endl
		   << "2 - Add On Shelf Good" << endl
		   << "3 - Add Custom-Made Good" << endl
		   << "4 - Update Good quantity" << endl
		   << "5 - Delete" << endl
		   << "0 - Exit program" << endl;
	  cout << "> ";
	  cin >> selection;
	  cout << endl;
	  if (cin.fail())
	  {
		  cin.clear();
		  cerr << "===Invalid Selection, try again.===" << endl << endl;
	  }
	  else
	  {
         if (selection >= 0 && selection <= 5)
		 {

			 cin.clear();
			 cin.ignore(999, '\n');
		     return selection;
		 }
	  }
	  cin.clear();
	  cin.ignore(999, '\n');
	  selection = -1;
	  return selection;
   }
   /*
      This function displays the menu and depending on the user's selection, 
      performs the requested action by calling the corresponding private function and redisplay the menu
   */
   int WPlanner::run() 
   {
      bool done = false;
      while (!done) {
         switch (menu()) {
         case 1:
			 this->listItems();
            break;
         case 2:
			 this->addItem(false);
            break;
         case 3:
			 this->addItem(true);
            break;
         case 4:
			 this->updateQty();
            break;
         case 5:
			 this->deleteItem();
            break;
         case 0:
            done = true;
            cout << "Goodbye!!" << endl << endl;
            break;
         case -1:
            cout << "===Invalid Selection, try again.===" << endl <<endl ;
            break;
         }
      }
      return 0;
   } // WPlanner::run() end
}


/* outputs

Wedding Planner Management Program
1 - List goods
2 - Add On Shelf Good
3 - Add Custom-Made Good
4 - Update Good quantity
5 - Delete
0 - Exit program
>



Not found!

Please enter the number of purchased goods:

Too many purchased, only 5 needed, please return the extra 15.

Updated!

Not implemented!

*/