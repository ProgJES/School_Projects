import java.util.LinkedList;

/** Represents a Library
 * @author Eunseok Jeon
 */
public class Library implements MaxTagValue {

    String       libraryName;
    LinkedList<Book> books = new LinkedList<>();

    /**
     * ctor that sets library name
     * @param libraryName
     */
    public Library(String libraryName) 
    {
        this.libraryName = libraryName;
    }

    /**
     * runs through all books in this library and returns the max valueTag
     * @return maxElement
     */
    public int findMaximumValueTag() 
    {
        int maxElement = -100;
        for (Book book: books)
        {
            if(book.valueTag > maxElement)
                maxElement = book.valueTag;
        }
        return maxElement;
    }

    /**
     * checks if book can be rented from this library with the current args
     * @param wanted
     * @param requestDate
     * @param dueDate
     * @return boolean
     */
    public boolean rentRequest(Book wanted, String requestDate, String dueDate)
    {
        try 
        {
            Helper.checkDate(requestDate);
            Helper.checkDate(dueDate);
            Helper.timeDifference(requestDate, dueDate);
        }
        catch (DateFormatException e) 
        {
            System.out.println(wanted + e.getMessage());
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
     * get and returns book
     * @param book
     * @return Book
     */
    public Book getBook(Book book){
        for (Book searchBook : books) 
        {
            if (book.bookName.equalsIgnoreCase(searchBook.bookName)&& book.valueTag == searchBook.valueTag)
            {
                return searchBook;
            }
        }
        return null;
    }


    @Override
    public boolean equals(Object o) {
        if (o == null) return false;
        if (o == this) return true;
        if (!(o instanceof Library))return false;

        Library otherLibrary = (Library)o;
        if (((Library) o).libraryName == otherLibrary.libraryName
                && ((Library) o).books == otherLibrary.books)
            return true;
        else
            return false;
    }

    @Override
    public int hashCode() {
        int result = libraryName.hashCode();
        result = 31 * result + books.hashCode();
        return result;
    }

    @Override
    public String toString() {
        return "Library{" + "libraryName='" + libraryName + '\'' + ", books=" + books + '}'; }
}
