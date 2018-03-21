/*
Student name: Eunseok Jeon
Student number: 026 110 148
Date: 2016/Nov/10
*/
#include "SuperHero.h"

using namespace std;

//Default constructor that sets multiplier to 0
SuperHero::SuperHero()
{
   this->_shMultiplier = 0;
}
//receives 3 parameters and set the values. if it is not valid set this->_shMultiplier to 0
SuperHero::SuperHero(const char* name, double strength, double multiplier)
{
	if(name[0] != '\0' && strength > 0 && multiplier > 0)
	{
	   strcpy(this->_name, name);
	   this->_strength = strength;
	   this->_shMultiplier = multiplier;  
    }
    else
    {
    	this->_shMultiplier = 0;
	}
}
//return strength * multiplier
double SuperHero::getStrength() const
{
	return this->_strength * this->_shMultiplier;
}
/*
1.	Find out which Hero has more strength left
2.	The Hero that has more strength "takes" the strength of the weaker one and adds it to her own.  
    The strength multiplier is not changed.  
    The weaker Hero loses the battle and is set to the safe, empty state.
*/
void SuperHero::operator *= (SuperHero& sh)
{
	if(this->getStrength() < sh.getStrength())
	{
	   sh._strength += this->_strength;
	   this->setEmpty();
	}
	else
	{
	   this->_strength += sh._strength;	
	   sh.setEmpty();
	} 
}
//if data is valid and not empty, display the message "living superhero" and call the Hero's display function, so re-use its definition
//else it displays "deceased superhero"
void SuperHero::display(ostream& out) const
{
	
	if(this->_name[0] != '\0' && this->_strength > 0 && this->_shMultiplier > 0)
	{	
	   out << "living superhero! " ;
       Hero::display(out);
    }
	else
	{
		out <<"deceased superhero!" << endl;
	}
}

void SuperHero::setEmpty()
{
	this->Hero::setEmpty();
	this->_shMultiplier = 0;
}
