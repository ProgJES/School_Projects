/*
Name: Eunseok Jeon
Student ID: 026 110 148
Date: 2016/Nov/29
*/
#include <cstring>
#include <iostream>
#include "String.h"


using namespace std;

namespace ict
{
   // write your implementations here
   
   /*
      This function deletes the dynamic array of characters pointed by m_data 
	  and sets the pointer and m_memSize attribute to nullptr and zero respectively.
   */
   void String::deallocate()
   {
	   if (nullptr != this->m_data)
	   {
		   delete[] this->m_data;
		   this->m_data = nullptr;
		   this->m_memSize = 0;
	   }
   }
   /*
      This function deallocates the memory allocated by m_data and then allocates memSize
      memory and updates the m_memsize member variable.
   */
   void String::allocate(int size)
   {
	  this->deallocate();
	 
   	  this->m_data = new char[size];
   	  this->m_memSize = size;
   }
   /*
      This function is to avoid having the same code in the constructor
      This function can only be called within constructor or the object is in a safe empty state.
   */
   void String::init(const char* str, int memSize)
   {
	   this->m_data = nullptr;
	   int strLength = strlen(str);

	   if (memSize < strLength)
	   {
		   memSize = strLength + 1;
	   }
	   this->allocate(memSize);
	   for (int i = 0; i < this->getMemSize(); i++)
	   {
		   this->m_data[i] = str[i];
	   }
	
	   this->m_len = strlen(this->m_data);
   }
   
   /*
      This function resizes the memory pointed by m_data, keeping the C-style inside m_data intact.
   */
   void String::resize(int newsize)
   {
   	  char* temp = new char[newsize];

   	  if(this->m_data != nullptr)
	  {
		 for (int i = 0; i < this->m_len; i++)
		 {
			 temp[i] = this->m_data[i];
		 }
		 temp[this->m_len] = '\0';
		 this->allocate(newsize);
		 //this->m_data = temp;

		 for (unsigned int i = 0; i < (this->getLength()); i++)
		 {
			 this->m_data[i] = temp[i];
		 }
		 this->m_data[this->getLength()] = '\0';
		 
	  }
	  this->m_len = strlen(this->m_data);
	  

   }
   /*Constructors*/
   //No argument constructo; sets the m_data attribute to null and other member variables to zero (puts the object in a safe empty state). 
   String::String()
   {
   	  this->m_data = nullptr;
   	  this->m_len = 0;
   	  this->m_memSize = 0;
	 
   }
   //Initializes the object using str and memsize values through the init(...) function
   String::String(const char* str, int memsize)
   {
	   this->m_data = nullptr;
	   this->m_len = 0;
	   this->m_memSize = 0;
   	   this->init(str, memsize);
	   
   }
   //Initializes the object using other.m_data and other.m_memSize values through the init(...) function
   String::String(const String& str)
   {
      this->init(str.m_data, str.m_memSize);
   }
   
   /*Assignment operator*/
   String& String::operator=(const String& str)
   {
   	   if(this != &str) //Self assignment check
   	   {
   	      this->deallocate();
		  this->init(str.m_data, str.m_memSize);	
	   }
	   
	   return *this;
   }
   
   /*Virtual destructor*/
   String::~String()
   {
   	  this->deallocate();
   }
   
   /*Getters*/
   //Return m_len
  int String::getLength() const
  {
  	 return this->m_len;
  }
  //Return m_memSize
  int String::getMemSize() const
  {
  	 return this->m_memSize;
  }
  
  /*Cast operator*/
  String::operator const char*() const
  {
	  const char* ss = "";
	  if (this->m_data != nullptr)
		  return this->m_data;
	  return ss;
  } 

  String::operator int() const
  {
     return this->getLength();
  } 
  
  /*Operator overload*/
  //This function concatenates two strings
  String& String::operator+=(const char* str)
  {
	  int tempLength = strlen(str);
	  int sum = tempLength + this->getLength();

	  if (this->m_data != nullptr)
	  {
		  if (this->m_memSize < sum + 1)
		  {
			  this->resize(sum + 1);
		  }
		  strcat(this->m_data, str);
		
		  this->m_len = strlen(this->m_data);
		  
	  }
	  else
	  {
		  this->allocate(sum + 1);
		  strcpy(this->m_data, str);
		  
		  this->m_len = strlen(this->m_data);
		  
	  }
	  
	  return *this;
  }
  //This function concatenates two strings
  String String::operator+(const String& str) const
  {
     String temp(this->m_data);
     temp += str.m_data;
     
     return temp;
  }
  //Reuses the operator += (const char*) passing str.m_data as the argument
  String& String::operator+=(String& s)
  {
  	 *this += s.m_data;
  	 
  	 return *this;
  }
  //Unary operator; adds a space before the string (prefix)
  String& String::operator++()
  {
	  String temp(" ");
	  *this = temp + *this;
     
     return *this;
  }
  //Unary operator; adds a space after the string (postfix)
  String String::operator++(int)
  {
     String temp = *this;
     *this += " ";
     
     return temp;
  }
  //Indexing operator
  char& String::operator[](int idx)
  {
  	if(this->m_memSize < idx)
  	{
  	   	this->resize(idx + ExpansionSize);
	}
     return this->m_data[idx];
  }
  /*
     Instead of getting the string using getline or >>, this function gets the string character by character. 
	 If the number of characters reaches the m_memSize value, it will resize the object to m_memSize + ExpansionSize.
  */
  istream& String::read(istream& is)
  {
  	char c;
  	int size = 0;
  	while(c != '\n')
  	{
  		is.get(c);
  		size++;
	}
	if(this->getMemSize() < size)
	{
		this->resize(this->m_memSize + ExpansionSize);
	}
	
	this->m_data[size] = '\0';
	return is;
  }
  
  
  ostream& operator<<(ostream& os, const String& str)
  {
  	 os << (const char*)str;
  	 
  	 return os;
  }
  istream& operator >> (istream& is, String& str)
  {
  	 return str.read(is);
  }
}












