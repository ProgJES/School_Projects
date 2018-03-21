/**
 * The Book class represents a book
 * @author Eunseok Jeon
 */

class Book {

    String       bookName;    // the book name
    int          valueTag;    // an integer between -100 and 100
    Library      library;     // the library having this book it its inventory
    RentSettings rs;          // rent settings

    /**
     * default constructor sets book's name and value tag
     * @param bookName
     * @param valueTag
     */
    public Book(String bookName, int valueTag) 
    {
        this.bookName = bookName;
        this.valueTag = valueTag;
        this.rs = getRs();
    }

    /**
     * Book constructor that takes 3 parameters and sets its member variables
     * @param bookName
     * @param valueTag
     * @param library
     */
    public Book(String bookName, int valueTag, Library library) 
    {
        this.bookName = bookName;
        this.valueTag = valueTag;
        this.rs = getRs();
        this.library = library;
    }

    /**
     * Rentbook
     * @param rentDate
     * @param dueDate
     * @param library
     * @return boolean if book can be rented or not
     */
    public boolean rentBook(String rentDate, String dueDate, Library library) 
    {
        try 
        {
            Helper.checkDate(rentDate);
            Helper.checkDate(dueDate);
            Helper.timeDifference(rentDate, dueDate);
            setRs(this.new RentSettings(rentDate, dueDate, library));
        }
        catch (DateFormatException e)
        {
            e.getMessage();
            return false;
        }
        catch (RentPeriodException e)
        {
            e.getMessage();
            return false;
        }
        
        return true;
    }

    /**
     * destroy the RentSettings object for this book
     * @param library
     */
    public void returnBook(Library library) 
    {
        if(this.library == library)
            //rs = null;
            rs.rentDate = null;
            rs.dueDate = null;
            rs.borrowed = false;
    }

    /**
     * return the date when this book is available
     * @param library
     * @return string representing the date the book is available
     */
    public String availableDate(Library library)
    {
        for (Book book: library.books) 
        {
            if(book.rs.dueDate == null)
            {
                return Helper.getCurrentDate();
            }
            else
            {
                return book.rs.dueDate;
            }
        }
        return "";
    }

    /**
     * returns true if the current date is greater than the due date
     * @return boolean representing if book is overdue or not
     */
    public boolean isBookOverdue() 
    {
        try 
        {
            if(0 > (Helper.timeDifference(Helper.getCurrentDate(), rs.dueDate)))
                return true;
        }
        catch (RentPeriodException e)
        {
            e.getMessage();
            return false;
        }
        catch (DateFormatException e)
        {
            e.getMessage();
            return false;
        }
        return false;
    }

    /**
     * check if book is rented
     * @param l
     * @return boolean representing if the book is renting or not
     */
    public boolean isRented(Library l) 
    {
        if(l.libraryName == this.library.libraryName)
        {
            if (this.rs.borrowed)
                return true;
            else
                return false;
        }
        
        return false;
    }

    /**
     * return an object of this book's RentSettings
     * @return RentSettings object
     */
    public RentSettings getRs() 
    {
        return this.new RentSettings();
    }

    /**
     * set books RentSettings
     * @param rs
     */
    public void setRs(RentSettings rs) 
    {
        this.rs = rs;
    }

    /**
     * get dueDate
     * @return dueDate
     */
    public String getDueDate()
    {
        return rs.dueDate;
    }

    /**
     * get rentDate
     * @return rentDate
     */
    public String getRentDate()
    {
        return rs.rentDate;
    }
    
    /**
     * bookName
     * @return book name and value tag in format
     */
    public String bookName()
	{
		return "(" + bookName + ", " + valueTag + ')'; 
	}
    @Override
    public boolean equals(Object o)
    {
        if (this == o) return true;
        if (!(o instanceof Book)) return false;

        Book book = (Book) o;

        if (valueTag != book.valueTag) return false;
        if (!bookName.equals(book.bookName)) return false;
        if (!library.equals(book.library)) return false;
        return getRs().equals(book.getRs());
    }

    @Override
    public int hashCode() 
    {
        int result = bookName.hashCode();
        result = 31 * result + valueTag;
        result = 31 * result + library.hashCode();
        result = 31 * result + getRs().hashCode();
        return result;
    }

    @Override
    public String toString() 
    { 
    	if(this.library.libraryName == "")
    	{
    		return bookName();
    	}
    	return bookName() + "=> " + this.library.libraryName + " " + this.rs.toString();
    }    

    private class RentSettings 
    {

        private String rentDate;     // date when the item is requested
        private String dueDate;      // date when the item must be returned
        private boolean borrowed; // true if the item is rented

        //Inner class RentSettings
        //default ctr
        private RentSettings()
        {
            this.rentDate = null;
            this.dueDate = null;
            this.borrowed = false;
        }

        // private ctr must throw DateFormatException and RentPeriodException
        private RentSettings(String rentDate, String dueDate, Library library) throws DateFormatException, RentPeriodException 
        {
            Helper.checkDate(rentDate);
            Helper.checkDate(dueDate);
            Helper.timeDifference(rentDate, dueDate);
            this.rentDate = rentDate;
            this.dueDate = dueDate;
            this.borrowed = true;
        }

        @Override
        public boolean equals(Object o) 
        {
            if (this == o) return true;
            if (!(o instanceof RentSettings)) return false;

            RentSettings that = (RentSettings) o;

            if (borrowed != that.borrowed) return false;
            if (rentDate != null ? !rentDate.equals(that.rentDate) : that.rentDate != null) return false;
            return dueDate != null ? dueDate.equals(that.dueDate) : that.dueDate == null;
        }

        @Override
        public int hashCode()
        {
            int result = rentDate != null ? rentDate.hashCode() : 0;
            result = 31 * result + (dueDate != null ? dueDate.hashCode() : 0);
            result = 31 * result + (borrowed ? 1 : 0);
            return result;
        }

        @Override
        public String  toString() 
        { 
        	return "RentSettings(" + rentDate + ", " + dueDate + ", "+ borrowed + ')'; 
        }
    }//end inner class RentSettings

}//end Book class
