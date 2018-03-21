import java.lang.reflect.Array;

/** Main class
 * @author Eunseok Jeon
 */
public class Main {

    /** main method
     *
     * @param args
     */
    public static void main(String[] args) {


        /* TASK 1 - build libraries from files - at least two libraries */
        System.out.println("\n\n *" + " TASK 1 " + "*");
        /*
         * Student number: 026 110 148
         * Number of library created : 8
         * Number of books each library: 4 
         * 
         */

        Libraries ls = new Libraries(8);
        
        ls.libraries[0] = ls.buildLibraryFromFile("Newnham", "NewnHamLibrary.txt");
        ls.libraries[1] = ls.buildLibraryFromFile("Seneca@York", "YorkLibrary.txt");
        ls.libraries[2] = ls.buildLibraryFromFile("North York", "NorthYorkLibrary.txt");
        ls.libraries[3] = ls.buildLibraryFromFile("Bloor & Yonge", "BloorLibrary.txt");
        ls.libraries[4] = ls.buildLibraryFromFile("University of Toronto", "UofTLibrary.txt");
        ls.libraries[5] = ls.buildLibraryFromFile("George Brown", "GeorgeBrownLibrary.txt");
        ls.libraries[6] = ls.buildLibraryFromFile("Centennial ", "CentennialLibrary.txt");
        ls.libraries[7] = ls.buildLibraryFromFile("King", "King.txt");
       
        for(int i = 0; i < Array.getLength(ls.libraries); i++) 
        {
            System.out.println(ls.libraries[i].libraryName);
            System.out.println('[');
            for(int j = 0; j < ls.libraries[i].books.size(); j++)
            {
            	System.out.println(ls.libraries[i].books.get(j).toString());
            }
            System.out.println(']');
        }

        /**************************************************************************************************************/

        /* TASK 2 - ask for a book that is not in any library inventory */
        System.out.println("\n\n *" + " TASK 2 " + "*");
        Book tempBook = new Book("C++",20);
        Library library = ls.isThereBookInLibraries(tempBook);
        if (library == null)
            System.out.println(Helper.printNonexistent(tempBook));
        else
        	System.out.println("The book " + tempBook.bookName + " Belongs to the " + library.libraryName + " library");

        /**************************************************************************************************************/

         /* TASK 3 - ask for a book that is in a library inventory
         *  issue a rent request and print the book Essentials of Database Management
         *  issue the same rent request and print the book
         *  return the book
         *  issue the rent request with new dates and print the book
         */

        System.out.println("\n\n *" + " TASK 3 " + "*");
        
        library = ls.isThereBookInLibraries(new Book("Essentials of Database Management", 25));
        Book book = library.getBook(new Book("Essentials of Database Management", 25));
        
        if(library != null)
        { 
        	//issue a rent request and print the book Essentials of the Database Management
            if(library.rentRequest(book, Helper.getCurrentDate(), "07/08/2017"))
            {
            	System.out.println("PART 1 --- Issue a rent request");
                System.out.println(book.toString() + "\n");
            }
            //issue the same rent request and print the book
            if(library.rentRequest(book, Helper.getCurrentDate(), "07/08/2017"))
            {
            	System.out.println("PART 2 --- Issue the same rent request");
                book.rentBook(Helper.getCurrentDate(), "07/08/2017", library); 
                System.out.println("Book is rented \n" + book.toString() + "\n");
                System.out.println("PART3 --- Return the book");
                book.returnBook(library); //return the book
                System.out.println(book.toString() + " \nReturned!\n");
                
            }
            //issue the rent request with new dates and print the book
            if(library.rentRequest(book, "09/02/2017", "10/30/2017"))
            {
            	System.out.println("PART 4 --- Issue the rent request with new dates");
                book.rentBook(Helper.getCurrentDate(), "08/30/2017", library); // if rentRequest is valid then rent the book
                System.out.println("Book is rented: \n" + book.toString() + "\n");
            }
        }
        else 
        {
            System.out.println(Helper.printNonexistent(book));
        }

        /**************************************************************************************************************/

        /*
        * TASK 4 - ask for the same book in all libraries
        * look for the same book in all libraries and return a library, if the book is in the library inventory*
        * look for the same book in all libraries and return a library, if the book is available to be borrowed from that library*.
        * (* the library returned is the first library found from the array of libraries)
        */
        System.out.println("\n\n *" + " TASK 4 " + "*");
        Libraries libs = new Libraries(Array.getLength(ls.libraries));
        
        library = ls.isThereBookInLibraries(new Book("Essentials of Database Management", 25)); //see if a book is in a library
        book = library.getBook(new Book ("Essentials of Database Management", 25)); //if it is, the found book is then returned to work with
        if (library == null)
        {
            System.out.println(Helper.printNonexistent(book));
        }
        else
        {
        	System.out.println("The book " + book.bookName + " Belongs to the " + library.libraryName + " library");
        }

        library = ls.isThereBookInLibraries(new Book("Essentials of Database Management", 25)); //see if a book is in a library
        book = library.getBook(new Book ("Essentials of Database Management", 25)); //if it is, the found book is then returned to work with
        if (library == null)
        {
            System.out.println(Helper.printNonexistent(book));
        }
        else
        {
            if(!book.isRented(library))
                System.out.println(Helper.printAvailables(book));
        }


        /**************************************************************************************************************/

        /* 
         * TASK 5 - calculate maximum value tag for each library
         * calculate Maximum value for all libraries
         */
        System.out.println("\n\n *" + " TASK 5 " + "*");
        int MaxVal = 0;
        
        for(int i = 0; i < Array.getLength(ls.libraries); i++)
        {
        	int maximum = 0;
        	maximum += ls.libraries[i].findMaximumValueTag();
        	System.out.println("The maximum value tag in " + ls.libraries[i].libraryName + " library is: [" + maximum + "]");
        	if(maximum > MaxVal)
        		MaxVal = maximum;
        }

        System.out.println("Max value tag of all libraries is: [" + MaxVal + "]");

        /**************************************************************************************************************/

         /* TASK 6 - inquire about a book - it is available? when does it become available, etc. */
        System.out.println("\n\n *" + " TASK 6 " + "*");

        library = ls.isThereBookInLibraries(new Book ("Essentials of Database Management",25));
        book = library.getBook(new Book ("Essentials of Database Management",25));

        //Rent the book beforehand to print out unique details
        book.rentBook("03/11/2017", "08/30/2017", library);

        if(book.isRented(library))
        {
            System.out.println("This book will be available on " + book.getDueDate());
            if(book.isBookOverdue()) 
            {
                System.out.println("The book " + book.bookName + " overdue, will be available on the date of " + book.availableDate(library));
            }
        }
        else
        {
            System.out.println(Helper.printAvailable(book, Helper.getCurrentDate(), library));
            System.out.println("Able to rent");
        }
        

        /**************************************************************************************************************/

         /* BONUS TASK 8 - Instead of using Vector<Book> in class Library a class LinkedList<T> and instantiated as LinkedList<Book> */
        System.out.println("\n\n *" + " TASK 8 " + "*");
        System.out.println("Instead of using Vector<Book> used LinkedList<T>.");


    }//end main method
}//end class
