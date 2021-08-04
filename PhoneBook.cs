using System;
using System.Collections;
using System.Collections.Generic;

namespace Phonebook
{

    public class PhoneBook
    {

        // Menu
        private string menu = "-------------------------------------------------\n" + 
                              "Please, choose the operation you want to execute!\n" + 
                              "-------------------------------------------------\n" + 
                              "(1) Save a new phone number\n" +
                              "(2) Delete a phone number\n" +
                              "(3) Varolan Numarayı Güncelleme\n" +
                              "(4) Rehberi Listelemek\n" +
                              "(5) Rehberde Arama Yapmak\n" +
                              "(0) Çıkış\n" +
                              "-------------------------------------------------\n";


        // Default 5 Registry
        private Dictionary<string,string> phonebook = new Dictionary<string, string>
        {
            {"Maria Esposa".ToUpper(),"2122888888"},
            {"Dani Monroe".ToUpper(),"3124354433"},
            {"Sarah Conner".ToUpper(),"2362332320"},
            {"Hailey Rose".ToUpper(),"2742242916"},
            {"Sunny Shen".ToUpper(),"5526768206"}

        };

        public string Menu { get => menu; }
        public Dictionary<string, string> Phonebook { get => phonebook; set => phonebook = value; }


        // Inspected
        public int operationChoice(){
            
            int tempChoice = 0;
            
            bool flag = true;
            
            while(flag){

                Console.Write("\n-> Your Choice : ");
                if(int.TryParse(Console.ReadLine(),out int choice)){

                    tempChoice = choice;
                    flag = false;
                    
                    
                }else{

                    Console.WriteLine("-> Invalid Input");

                }

            }


            return tempChoice;
            

        }

        // Inspected
        public void addNewNumber(){

            Console.Write("\n-> Enter the name".PadRight(30)+": ");
            string name = Console.ReadLine().ToUpper();
            Console.Write("\n-> Enter the surname".PadRight(30)+": ");
            string surname = Console.ReadLine().ToUpper();
            
            string number;

            while(true){
                
                Console.Write("\n-> Enter the phone number".PadRight(30)+": ");
                if(long.TryParse(Console.ReadLine(),out long longNumber)){

                    number = longNumber.ToString();
                    break;

                }else{

                    Console.WriteLine("-> This is not a phone number!");

                }

            }
            
            string owner = name+" "+surname;

            Phonebook.Add(owner,number);

            Console.WriteLine("\n-> This phone number is saved successfully.");


        }

        // Inspected
        public void deleteNumber(){

            Console.Write("\n-> Enter the name or surname of the person you want to delete : ");
            string input = Console.ReadLine().ToUpper();

            string[] keys = new string[Phonebook.Keys.Count];
            Phonebook.Keys.CopyTo(keys,0);
            
            bool isThereAny = false;
            
            foreach (var key in keys)
            {

                if(key.Contains(input)){

                    isThereAny = true;
                    char yesNo;

                    while(true){
                        
                        Console.Write("\n-> ["+key+"] is about to be deleted. Do you confirm?\n-> (Y) or (N) : ");
                        if(char.TryParse(Console.ReadLine().ToUpper(),out char tempChar)){

                            yesNo = tempChar;
                            break;
                        
                        }else{

                            Console.WriteLine("-> Invalid Input.");

                        }


                    }

                    switch(yesNo){

                        case 'Y':
                            Phonebook.Remove(key);
                            Console.WriteLine("-> This person is deleted successfully.");
                            break;
                        
                        case 'N':
                            Console.WriteLine("-> Operation is terminated.");   
                            break;

                    }

                    break;

                }
            
            }
                
                
                if(isThereAny == false){

                    int choice;
                    Console.WriteLine("-> The name you searched for isn't found in the phonebook.");
                    Console.WriteLine("-> Press (1) : Terminate this operation");
                    Console.WriteLine("-> Press (2) : Try again");
                    
                    while(true){
                        
                        Console.Write("\n-> (1) or (2) :");
                        if(int.TryParse(Console.ReadLine(),out int tempInt)){

                            choice = tempInt;
                            break;

                        }else{

                            Console.WriteLine("-> Invalid Input");

                        }


                    }

                    switch(choice){

                        case 1:
                            Console.WriteLine("-> Operation is terminated.");
                            break;
                        
                        case 2:    
                            deleteNumber();
                            break;
                    
                    }

                    

                }

            

        }


        public void updateNumber(){

            Console.Write("\n-> Enter the name or surname of the person you want to update : ");
            string input = Console.ReadLine().ToUpper();
            Console.Write("\n-> Enter the new number : ");
            string newNumber = Console.ReadLine();

            string[] keys = new string[Phonebook.Keys.Count];
            Phonebook.Keys.CopyTo(keys,0);

            bool isThereAny = false;

            foreach (var key in keys)
            {

                if(key.Contains(input)){

                    isThereAny = true;
                    Console.Write("\n-> ["+key+"] is about to be updated. Do you confirm?\n-> (Y) or (N) : ");
                    char yesNo = char.Parse(Console.ReadLine().ToUpper());

                    switch(yesNo){

                        case 'Y':
                            Phonebook[key] = newNumber;
                            Console.WriteLine("-> This person is updated successfully.");
                            break;
                        
                        case 'N':
                            Console.WriteLine("-> Operation is terminated.");   
                            break;

                    }

                    break;

                }
                
            } 
            
            if(isThereAny == false){

                    Console.WriteLine("-> The name you searched for isn't found in the phonebook.");
                    Console.WriteLine("-> Press (1) : Terminate this operation");
                    Console.WriteLine("-> Press (2) : Try again");
                    Console.Write("\n-> (1) or (2) :");
                    int choice = int.Parse(Console.ReadLine());

                    switch(choice){

                        case 1:
                            Console.WriteLine("-> Operation is terminated.");
                            break;
                        
                        case 2:    
                            updateNumber();
                            break;
                    }

                    
                    

            }

            


        }


        public void listPhonebook(){

            string[] names = new string[Phonebook.Keys.Count];
            Phonebook.Keys.CopyTo(names,0);

            string[] numbers = new string[Phonebook.Values.Count];
            Phonebook.Values.CopyTo(numbers,0);

            Console.WriteLine("-> (1) List (A to Z)\n-> (2) List (Z to A)");
            Console.Write("\n-> (1) or (2) : ");
            int choice = int.Parse(Console.ReadLine());

            switch(choice){

                case 1:
                    Array.Sort(names);
                    Console.WriteLine("Phonebook\n----------------------------------------------");
                    foreach (var name in names)
                    {
                        string[] s = name.Split(' ');
                        Console.WriteLine("Name    : " + s[0]);
                        Console.WriteLine("Surname : " + s[s.Length-1]);
                        Console.WriteLine("Phone   : " + Phonebook[name]);
                        Console.WriteLine("----------------------------------------------");
                    }
                    break;

                case 2:
                    Array.Sort(names);
                    Array.Reverse(names);
                    Console.WriteLine("Phonebook\n----------------------------------------------");
                    foreach (var name in names)
                    {
                        string[] s = name.Split(' ');
                        Console.WriteLine("Name    : " + s[0]);
                        Console.WriteLine("Surname : " + s[s.Length-1]);
                        Console.WriteLine("Phone   : " + Phonebook[name]);
                        Console.WriteLine("----------------------------------------------");
                    }
                    break;


            }

        }


        public void search(){

            string[] names = new string[Phonebook.Keys.Count];
            Phonebook.Keys.CopyTo(names,0);

            string[] numbers = new string[Phonebook.Values.Count];
            Phonebook.Values.CopyTo(numbers,0);

            Console.WriteLine("-> (1) Search by name or surname");
            Console.WriteLine("-> (2) Search by phone number");
            Console.Write("\n-> (1) or (2) : ");
            int choice = int.Parse(Console.ReadLine());

            int resultCounter = 0;


            switch(choice){

                case 1:

                    Console.Write("\nEnter a name or surname : ");
                    string input = Console.ReadLine().ToUpper();

                    Console.WriteLine("Search Results\n----------------------------------------------");
                    foreach (var name in names)
                    {
                        if(name.Contains(input)){
                            
                            resultCounter++;
                            string[] s = name.Split(' ');
                            Console.WriteLine("Name    : " + s[0]);
                            Console.WriteLine("Surname : " + s[s.Length-1]);
                            Console.WriteLine("Phone   : " + Phonebook[name]);
                            Console.WriteLine("----------------------------------------------");

                        }
                        

                    }

                        if(resultCounter == 0){

                            Console.WriteLine("\n-> There is no data.");

                        }

                break;

                case 2:

                    Console.Write("\nEnter a phone number : ");
                    string number = Console.ReadLine();

                    Console.WriteLine("Search Results\n----------------------------------------------");
                    foreach (var item in numbers)
                    {
                        if(item.Contains(number)){
                            
                            resultCounter++;
                            int nameIndex = Array.IndexOf(numbers,number);
                            string name = names[nameIndex];
                            string[] s = name.Split(' ');
                            Console.WriteLine("Name    : " + s[0]);
                            Console.WriteLine("Surname : " + s[s.Length-1]);
                            Console.WriteLine("Phone   : " + Phonebook[name]);
                            Console.WriteLine("----------------------------------------------");

                        }
                        

                    }

                        if(resultCounter == 0){

                            Console.WriteLine("\n-> There is no data.");

                        }

                break;    



            }

        }


    }


}