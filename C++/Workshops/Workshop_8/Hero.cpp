/*
Student name: Eunseok Jeon
Student number: 026 110 148
Date: 2016/Nov/10
*/
#include "Hero.h"

    
    //if no argument provided, the object is set to a safe empty state.
	Hero::Hero()
	{
		this->setEmpty();
	}
	//if validation failed, the object it set to safe empty state.
	Hero::Hero(const char* name, double strength)
	{
		if(name[0] == '\0' && strength < 1)
		{
		   this->setEmpty();	 
		}
		else
		{
		   strcpy(this->_name, name);
		   this->_strength = strength;
	    }
	}
	void Hero::setEmpty()
	{
		this->_name[0] = '\0';
		this->_strength = 0.0;
	}
	//return true if the object is empty.
	bool Hero::isEmpty() const
	{
		return _name[0] == '\0' && _strength == 0.0;
	}
	//return strength if the object is not empty. Otherwise, return 0.0
	double Hero::getStrength() const
	{
		return isEmpty() ? 0.0 : this->_strength;
	}
	//it displays name and strength if the object is not empty. Otherwise, it does nothing
	void Hero::display(std::ostream& os) const
	{
		if(!isEmpty())
		{
			os << this->_name << " - " << this->_strength << std::endl;
		}	
	}
	//it returns true if h2's strength greater than h1's strength
	bool operator < (const Hero& h1, const Hero& h2)
	{
		return  h1.getStrength() < h2.getStrength(); 
	}
	//if this->_strength is less than strength, it set this->_strength = 0.0. Otherwise, it takes away specific amount from this->_strength
	void Hero::operator -= (double strength)
	{
		if(this->_strength < strength)
		{
			this->_strength = 0.0;
		}
		else
		{
			this->_strength -= strength;
		}
		
	}
	//it adds strength to this->_strength
	void Hero::operator += (double strength)
	{
		this->_strength += strength;
	}
