/*
Student Name: Eunseok Jeon
Student ID: 026 110 148
Section: OOP244SCC
Final Submission Date: 2016/Dec/08
*/
#include "Good.h"

using namespace std;
namespace ict
{
   /*Constructors*/
   
   //Default constructor that set to safe empty state
   Good::Good()
   {
      this->setEmpty();
   }
   //Constructor that takes 5 parameters
   Good::Good(const char* sku, const char* name, double price, int qtyNeeded, bool taxed)
   {
      this->setEmpty();
      
      strncpy(this->sku_, sku, MAX_SKU_LEN);
      
	  this->name_ = new char[strlen(name + 1)];
      strcpy(this->name_, name);
      
      this->price_ = price;
      this->qtyNeeded_ = qtyNeeded;
      this->taxed_ = taxed;
      this->quantity_ = 0;
   }
   //Copy constructor
   Good::Good(const Good& other)
   {
   	  //Shallow copy non-resource variables
      this->price_ = other.price_;
      this->quantity_ = other.quantity_;
      this->qtyNeeded_ = other.qtyNeeded_;
      this->taxed_ = other.taxed_;
      strncpy(this->sku_, other.sku_, MAX_SKU_LEN);
      //If the source is not empty, copy the resource data
      if(other.name_ != nullptr)
      {
      	 //Allocate new dynamic memory
         this->name_ = new char[strlen(other.name_) + 1];
         //Copy resource data
         strcpy(this->name_, other.name_);
	  }
	  //Else set the current object to empty
	  else
	  {
	     this->setEmpty();
	  }
   }
   /*Destructor*/
   Good::~Good()
   {
      this->clear();
      
   }
   /*Public member functions*/
   
   //Function that set data members to safe empty state
   void Good::setEmpty()
   {
      this->sku_[0] = '\0';
      this->name_ = nullptr;
      this->price_ = 0.0;
      this->quantity_ = 0;
      this->qtyNeeded_ = 0;
      this->taxed_ = true;
   }
   //Function that deletes dynamically allocated memory
   void Good::clear()
   {
      delete [] this->name_;
      this->name_ = nullptr;
   }
   
   /*Setters*/
   
   //Sets SKU
   void Good::sku(const char* sku)
   {
      strncpy(this->sku_, sku, MAX_SKU_LEN + 1);
   }
   //Sets Name by allocating dynamic memory
   void Good::name(const char* name)
   {
       this->name_ = new char[strlen(name) + 1];
       strcpy(this->name_, name);
   }
   //Sets Price
   void Good::price(double price)
   {
   	   this->price_ = price;
   }
   //Sets Quantity
   void Good::quantity(int quantity)
   {
   	   this->quantity_ = quantity;
   }
   //Sets Quantity Needed
   void Good::qtyNeeded(int qtyNeeded)
   {
   	   this->qtyNeeded_ = qtyNeeded;
   }
   //Sets Taxed
   void Good::taxed(bool taxed)
   {
   	   this->taxed_ = taxed;
   }
   
   /*Getters*/
   
   //Returns SKU
   const char* Good::sku() const
   {
      return this->sku_;
   }
   //Returns Name
   const char* Good::name() const
   {
      return this->name_;
   }
   //Returns Price
   double Good::price() const
   {
   	  return this->price_;
   }
   //Returns Taxed
   bool Good::taxed() const
   {
   	  return this->taxed_;
   }
   //Returns Quantity
   int Good::quantity() const
   {
   	  return this->quantity_;
   }
   //Returns Quantity Needed
   int Good::qtyNeeded() const
   {
   	  return this->qtyNeeded_;
   }
   //Returns cost --> if taxed == true, it will return price * TAX. Otherwise, it will return just price
   double Good::cost() const
   {
   	  return this->taxed() == true ? this->price() * (1 + TAX) : this->price();
   }
   
   
   /*Member operator overloads*/
   
   //Assignment operator
   Good& Good::operator = (const Good& other)
   {
   	  //Check for self-assignment
      if(this != &other)
      {
      	 //Shallow copy non-resource variables
         this->price_ = other.price_;
         this->quantity_ = other.quantity_;
         this->qtyNeeded_ = other.qtyNeeded_;
         this->taxed_ = other.taxed_;
         strncpy(this->sku_, other.sku_, MAX_SKU_LEN);
         
         //Deallocate previously allocated dynamic memory
         this->clear();
         
         if(other.name_ != nullptr)
         {
         	//Allocate new dynamic memory 
            this->name_ = new char[strlen(other.name_) + 1];
            //Copy the resource data
            strcpy(this->name_, other.name_);
	     }
	     else
	     {
	        this->setEmpty();
	     }  
	  }
	  
	  return *this;
   }
   //Compare left operand's SKU and left operand's SKU. Return true if they are same. Otherwise, return false;
   bool Good::operator == (const char* sku)
   {
      return strcmp(this->sku_, sku) == 0 ? true : false;
   }
   //This operator will add the received integer value to the quantity on hand of the Good, returning the sum.
   int Good::operator += (const int quantity)
   {
   	  
   	  this->quantity(this->quantity() + quantity);
      return this->quantity();
   }
   

   
   /*Non-member operator overloads*/
   
   //This operator adds the total cost of the item on hand to the left operand, which is a double reference, and then returns it. 
   double operator += (double& totalCost, const Good& other)
   {
   	  totalCost += other.cost() * other.quantity();
      return totalCost;
   }
   /*
      Non-member ostream operator overloads, it enables user to write the syntax "cout << OBJECT << endl;" in main function
      Using the virtual std::ostream& display(std::ostream& os, bool linear)const = 0; function in the "ReadWritable.h" to implement operator overloads
    */
   ostream& operator << (ostream& os, const Good& other)
   {
      return other.display(os, true);
   }
   /*
      Non-member istream operator overloads, it enables user to write the syntax "cin >> OBJECT;" in main function
      Using the virtual std::istream& conInput(std::istream& is) = 0; function in the "ReadWritable.h" to implement operator overloads
    */
   istream& operator >> (istream& is, Good& other)
   {
   	  return other.conInput(is);
   }

}
