import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

/** Represents a collection of Libraries
 * @author Eunseok Jeon
 */
public class Libraries 
{

    public Library[] libraries;
    public int numberOfLibraries;      // number of libraries in collection

    /**
     * Libraries constructor
     * @param num
     */
    public Libraries(int num)
    {
        this.numberOfLibraries = num;
        this.libraries = new Library[this.numberOfLibraries];
    }

    /**
     * builds libraries from a file and adds them to collection
     * @param libraryName
     * @param fileName
     * @return library
     */
    public Library buildLibraryFromFile(String libraryName, String fileName) 
    {

        Library library = new Library(libraryName);

        String path = System.getProperty("user.dir");
        Book book = null;
        String s;

        try (BufferedReader br = new BufferedReader(new FileReader(path + "/src/" + fileName))) 
        {
           while ((s = br.readLine()) != null) 
           {
              String [] parts = s.split(",");
              String bookName = parts[0];
              int valueTag = Integer.parseInt(parts[1]);
              
              book = new Book(bookName, valueTag, library);
           
              //System.out.println(book.getBook() + "  " + book.getValue());
              
              library.books.add(book);
             
           }
        }
        catch (IOException e) 
        {
           System.out.println(e.getMessage());
        }
       
       return library;
    }

    /**
     * method used to search libaries for a book and returns first valid library
     * @param book
     * @return library
     */
    public Library isThereBookInLibraries(Book book) 
    {
       for(int i = 0; i < this.numberOfLibraries; i++)
       {
    	   for(int j = 0; j < this.libraries[i].books.size(); j++)
    	   {
    		   if(this.libraries[i].books.get(j).bookName.equals(book.bookName) && this.libraries[i].books.get(j).valueTag == book.valueTag)
    		   {
    			   return libraries[i];
    		   }
    	   }
       }
       return null;
    }

    /**
     *
     * @param book
     * @param requestDate
     * @param dueDate
     * @return library
     */
    public Library rentBookAvailable(Book book, String requestDate, String dueDate) 
    {
        for(int i = 0; i < this.numberOfLibraries; i++)//for(Library library: libraries)
        { 
            for(int j = 0; j < this.libraries[i].books.size(); j++)
            { 
                if(book.bookName.equalsIgnoreCase(this.libraries[i].books.get(j).bookName) && book.valueTag == this.libraries[i].books.get(j).valueTag)
                {
                    if(!this.libraries[i].books.get(j).isRented(this.libraries[i]))
                    {
                        if(this.libraries[i].rentRequest(book, requestDate, dueDate))
                        {
                        	return this.libraries[i];
                        }
                            
                    }
                }
            }
        }
        return null;
    }

    @Override
    public boolean equals(Object o) 
    {
        if (this == o) return true;
        if (!(o instanceof Libraries)) return false;

        Libraries libraries1 = (Libraries) o;

        if (numberOfLibraries != libraries1.numberOfLibraries) return false;
        return libraries.equals(libraries1.libraries);
    }

    @Override
    public int hashCode() 
    {
        int result = libraries.hashCode();
        result = 31 * result + numberOfLibraries;
        return result;
    }

    @Override
    public String toString() 
    { 
    	return "Libraries{" + "libraries=" + libraries + ", numberOfLibraries=" + numberOfLibraries + '}'; 
    }
}
