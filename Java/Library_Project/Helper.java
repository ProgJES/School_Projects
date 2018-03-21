
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
/** Helper functions
 * @author Eunseok Jeon
 */
public class Helper {

    /**
     * checks if date is valid
     * @param date
     * @return boolean
     */
    public static boolean isValidDate(String date) 
    {
        boolean valid = true;

        DateFormat formatter = new SimpleDateFormat("MM/dd/yyyy");
        formatter.setLenient(false);
        try 
        {
            formatter.parse(date);
        } 
        catch (ParseException e) 
        {
            valid = false;
        }
        return valid;
    }

    /**
     * calls isValidDate to see if date is valid
     * @param date
     * @throws DateFormatException
     */
    public static void checkDate(String date) throws DateFormatException
    {

        if (!Helper.isValidDate(date))
        {
            try 
            {
                throw new DateFormatException("Invalid data format " + date + " it should be MM/dd/yyyy");
            } 
            catch (DateFormatException e)
            {
                e.getMessage();
            }
        }
    }

    /**
     * checks the difference of time between two different dates
     * @param date1
     * @param date2
     * @return
     * @throws DateFormatException
     * @throws RentPeriodException
     */
    public static long timeDifference(String date1, String date2) throws DateFormatException, RentPeriodException
    {

        SimpleDateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy");

        if ( !isValidDate(date1) || !isValidDate(date2)) {
            throw new DateFormatException();
        }

        Date d1 = null;
        Date d2 = null;
        long diffDays = 0;

        try 
        {
            d1 = dateFormat.parse(date1);
            d2 = dateFormat.parse(date2);

            //in milliseconds
            long diff = d2.getTime() - d1.getTime();
            diffDays = diff / (24 * 60 * 60 * 1000);
            if(diffDays < 0)
            {
                throw new RentPeriodException();
            }
            return diffDays;

        } 
        catch (Exception e)
        {
            e.printStackTrace();
        }
        return diffDays;
    }

    /**
     * gets current date
     * @return string of current date
     */
    public static String getCurrentDate()
    {
        DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy");
        //get current date time with Date()
        Date date = new Date();
        return dateFormat.format(date);
    }

    /**
     * print book available details
     * @param book
     * @param rentDate
     * @param library
     * @return string with available book details
     */
    public static String printAvailable(Book book, String rentDate, Library library)
    {
        return "Book (" + book.bookName + ", "+ book.valueTag +") is available at " +  rentDate + " from library: " + library.libraryName;
    }

    /**
     * prints book available for rent
     * @param book
     * @return string
     */
    
    public static String printAvailables(Book book)
    {
        return "Book (" + book.bookName + ", "+ book.valueTag +") is available for rent at " + book.library.libraryName;
    }

    /**
     * prints unavailable book
     * @param book
     * @param rentDate
     * @return string
     */
    public static String printUnavailable(Book book, String rentDate)
    {
        return "Book " + book.bookName + " is not available for " + rentDate;
    }

  
    /**
     * prints non existant book
     * @param book
     * @return string
     */
    public static String printNonexistent(Book book)
    {
        return "Book " + book.bookName + " does not exist! ";
    }

}
