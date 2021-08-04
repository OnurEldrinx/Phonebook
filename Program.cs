using System;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {

            PhoneBook book = new PhoneBook();

            bool flag = true;

            while(flag){

                Console.WriteLine(book.Menu);
                
                int choice = book.operationChoice();

                switch(choice){

                    case 1:
                        book.addNewNumber();
                        break;

                    case 2:
                        book.deleteNumber();
                        break;

                    case 3:
                        book.updateNumber();
                        break;

                    case 4:
                        book.listPhonebook();
                        break;

                    case 5:
                        book.search();
                        break;

                    case 0:
                        Console.WriteLine("\n-> Program is terminated.\n-> Have a nice day!");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\n!!! Invalid input !!!");
                        break;
                        
                }




            }
            
        }
    }
}
