using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 110);
            // Integer variable.
            int exit = 0; // Check encryption of file.
                          // String variables.
            string option_select = "\0";         // Variable to store option select.
            string value = "\0";                 // Variable to use it for return conditions.
            string check_username = "\0";        // Variable to store temporary sign in username for validation.
            string check_password = "\0";        // Variable to store temporary sign in password for validation.
                                                 // Variable for owner's data.
            string owner_name = "\0";      // Stores the name of owner.
            string owner_username = " "; // Stores the username of owner.
            string owner_password = " "; // Stores the password of owner.
                                           // String variables for manager's data.
            string islamabad_manager_name = "\0";     // Stores name of manager of islamabad.
            string islamabad_manager_username = "\0"; // Stores username of manager of isalamabad.
            string islamabad_manager_password = "\0"; // Stores password of manager of islamabad.
            string lahore_manager_name = "\0";        // Stores name of manager of lahore.
            string lahore_manager_username = "\0";    // Stores username of manager of lahore.
            string lahore_manager_password = "\0";    // Stores password of manager of lahore.
            string multan_manager_name = "\0";        // Stores name of manager of mutan.
            string multan_manager_username = "\0";    // Stores username of manager of multan.
            string multan_manager_password = "\0";    // Stores password of manager of multan.
                                                      // String variables for employs salaries.
                                                      // Islamabad Branch.
            string sal_islamabad_cook = "0";    // Stores salary of cook of islamabad branch.
            string sal_islamabad_waiter = "0";  // Stores salary of waiter of islamabad branch.
            string sal_islamabad_worker = "0";  // Stores salary of worker of islamabad branch.
            string sal_islamabad_sweeper = "0"; // Stores salary of sweeper of islamabad branch.
            string sal_islamabad_guard = "0";   // Stores salary of guard of islamabad branch.
            string sal_islamabad_manager = "0"; // Stores salary of manager of islamabad branch.
            string[] customer_name = { "\0" };      // Stores name of customers.
            string []customer_username = { "\0 " }; // Stores username of customer.
            string[] customer_password = { "\0 " }; // Stores password of customer.
            string[] customer_cnic= { "\0" };      // Stores CNIC of customers.
            string[] customer_contact = { "\0" };   // Stores Contact number of customers.
                                                 // Data for Islamabad Branch.
                                                       // String arrays for cook's data.
            string[] islamabad_cook_name = { "\0" };     // Stores names of cook in islamabad branch.
            string[] islamabad_cook_username = { "\0" }; // Stores usernames of cook in islamabad branch.
            string[] islamabad_cook_password = { "\0" }; // Stores passowrds of cook in islamabad branch.
            string[] islamabad_cook_cnic = { "\0" };     // Stores names of CNIC in islamabad branch.
            string[] islamabad_cook_contact = { "\0" };  // Stores contact numbers of cook in islamabad branch.
                                                          // String arrays for waiter's data.
            string[] islamabad_waiter_name = { "\0" };     // Stores names of waiter in islamabad branch.
            string[] islamabad_waiter_username = { "\0" }; // Stores usernames of waiter in islamabad branch.
            string[] islamabad_waiter_password = { "\0" }; // Stores password of waiter in islamabad branch.
            string[] islamabad_waiter_cnic = { "\0" };     // Stores CNIC of waiter in islamabad branch.
            string[] islamabad_waiter_contact = { "\0" };  // Stores contact number of waiter in islamabad branch.
                                                              // String arrays for worker's data.
            string[] islamabad_worker_name = { "\0" };     // Stores names of worker in islamabad branch.
            string[] islamabad_worker_username = { "\0" }; // Stores usernames of worker in islamabad branch.
            string[] islamabad_worker_password = { "\0" }; // Stores password of worker in islamabad branch.
            string[] islamabad_worker_cnic = { "\0" };     // Stores CNIC of worker in islamabad branch.
            string[] islamabad_worker_contact = { "\0" };  // Stores contact number of worker in islamabad branch.
                                                              // String arrays for sweeper's data.
            string[] islamabad_sweeper_name = { "\0" };     // Stores names of sweeper in islamabad branch.
            string[] islamabad_sweeper_username = { "\0" }; // Stores usernames of sweeper in islamabad branch.
            string[] islamabad_sweeper_password = { "\0" }; // Stores password of sweeper in islamabad branch.
            string[] islamabad_sweeper_cnic = { "\0" };     // Stores CNIC of sweeper in islamabad branch.
            string[] islamabad_sweeper_contact = { "\0" };  // Stores contact number of sweeper in islamabad branch.
                                                              // String arrays for guard's data.
            string[] islamabad_guard_name = { "\0" };     // Stores names of guard in islamabad branch.
            string[] islamabad_guard_username = { "\0" }; // Stores usernames of guard in islamabad branch.
            string[] islamabad_guard_password = { "\0" }; // Stores password of guard in islamabad branch.
            string[] islamabad_guard_cnic = { "\0" };     // Stores CNIC of guard in islamabad branch.
            string[] islamabad_guard_contact = { "\0" };  // Stores contact number of guard in islamabad branch.
                                                          // String arrays for dish data.
            string[] islamabad_dishes = { "\0" }; // Stores names of dishes in islamabad branch.
                                                    // String arrays for member's data.
            string[] islamabad_premier_username = { "\0" }; // Stores usernames of customers whom got premier membership in islamabad branch.
            string[] islamabad_student_usernam = { "\0" }; // Stores usernames of customers whom got student membership in islamabad branch.
                                                              // Integer type variables.
            int num = 0;                                   // Stores number of owner of islamabad branch.
            int num_customer = 0;                          // Stores number of customers of islamabad branch.
                                                           // Data for Islamabad Branch.
            int num_islamabad_manager = 0;                 // Stores number of manager of islamabad branch.
            int num_islamabad_cook = 0;                    // Stores number of cook of islamabad branch.
            int num_islamabad_waiter = 0;                  // Stores number of waiter of islamabad branch.
            int num_islamabad_worker = 0;                  // Stores number of worker of islamabad branch.
            int num_islamabad_sweeper = 0;                 // Stores number of sweeper of islamabad branch.
            int num_islamabad_guard = 0;                   // Stores number of guard of islamabad branch.
                                                           
            int islamabad_salaries = 0;         // Stores sum of salaries of all employs temporarily of islamabad branch.
            int islamabad_bill_payments = 0;    // Stores amount of bill payments of islamabad branch.
            int islamabad_cooking_expenses = 0; // Stores amount for cooking expenses of islamabad branch.
            int islamabad_expenditures = 0;     // Stores amount for expenditures of islamabad branch.
            int islamabad_service_charge = 0;   // Stores amount for service charges of islamabad branch.
            int islamabad_sales = 0;            // Stores amount total sales of islamabad branch.
                                                // Data about memberships.
            int islamabad_premier_amount = 0; // Stores discount percentage for premier membershipin islamabad branch.
            int islamabad_student_amount = 0; // Stores discount percentage for student membershipin islamabad branch.
                                              // Data about table reservement.
            int islamabad_couple = 0;   // Stores price for table of couplein islamabad branch.
            int islamabad_group = 0;    // Stores price for group tablein islamabad branch.
            int islamabad_family = 0;   // Stores price for family tablein islamabad branch.
            int islamabad_profit = 0;             // Stores profit for islamabad branch.
            int lahore_profit = 0;                // Stores profit for lahore branch.
            int multan_profit = 0;                // Stores profit for multan branch.
                                                  // Loses for Different Branches
            int islamabad_loss = 0;
                                                  // Integer type arrays.
            int[] islamabad_dish_prices = { 0 }; // Stores dish prices for islamabad branch.
            int[] lahore_dish_prices =  { 0 };    // Stores dish prices for lahore branch.
            int[] multan_dish_prices =  { 0 };    // Stores dish prices for multan branch.
            string owner = "Owner";               // Prints Owner.
            string manager = "Manager";           // Prints Manager.
            string cook = "Cook";                 // Prints Cook.
            string waiter = "Waiter";             // Prints Waiter.
            string worker = "Worker";             // Prints Worker.
            string sweeper = "Sweeper";           // Prints Sweeper.
            string guard = "Guard";               // Prints Guards.
                                                  // Stores Text Files Names.
            string file_0 = "Managers_Data.txt";
            string file_1 = "Customer.txt";
            // Islamabad Text Files.
            string file_2 = "Islamabad_Cook.txt";
            string file_3 = "Islamabad_Waiter.txt";
            string file_4 = "Islamabad_Worker.txt";
            string file_5 = "Islamabad_Sweeper.txt";
            string file_6 = "Islamabad_Guard.txt";
            string file_7 = "Islamabad_Dish.txt";
            string file_8 = "Islamabad_Premier.txt";
            string file_9 = "Islamabad_Student.txt";
            string file_10 = "Islamabad_feedback.txt";
            string file_11 = "Islamabad_Single_Data.txt";


            Console.Clear();                  // Clear the console.
                                   // Function to print the start_up page.
                                            // Functions reading the data from text file.
                                            // For Islamabad Branch.
                                            //read_data_5_arrays(num_customer, customer_name, customer_username, customer_password, customer_cnic, customer_contact, file_1, exit);
                                            // read_managers(islamabad_manager_name, islamabad_manager_username, islamabad_manager_password, lahore_manager_name, lahore_manager_username, lahore_manager_password, multan_manager_name, multan_manager_username, multan_manager_password, file_0, exit);
                     //  read_data_5_arrays(num_islamabad_cook, islamabad_cook_name, islamabad_cook_username, islamabad_cook_password, islamabad_cook_cnic, islamabad_cook_contact, file_2, exit);
          //  read_data_5_arrays(num_islamabad_waiter, islamabad_waiter_name, islamabad_waiter_username, islamabad_waiter_password, islamabad_waiter_cnic, islamabad_waiter_contact, file_3, exit);
          //  read_data_5_arrays(num_islamabad_worker, islamabad_worker_name, islamabad_worker_username, islamabad_worker_password, islamabad_worker_cnic, islamabad_worker_contact, file_4, exit);
           // read_data_5_arrays(num_islamabad_sweeper, islamabad_sweeper_name, islamabad_sweeper_username, islamabad_sweeper_password, islamabad_sweeper_cnic, islamabad_sweeper_contact, file_5, exit);
            //read_data_5_arrays(num_islamabad_guard, islamabad_guard_name, islamabad_guard_username, islamabad_guard_password, islamabad_guard_cnic, islamabad_guard_contact, file_6, exit);
           // read_data_array_int(num_islamabad_dishes, islamabad_dishes, islamabad_dish_prices, file_7, exit);
           // read_data_1_array(num_islamabad_premier, islamabad_premier_username, file_8, exit);
           // read_data_1_array(num_islamabad_student, islamabad_student_username, file_9, exit);
         //   read_data_2_arrays(num_islamabad_feedback, islamabad_feedback_username, islamabad_feedback, file_10, exit);
       //     read_singles(owner_name, owner_username, owner_password, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard, sal_islamabad_manager, islamabad_student_amount, islamabad_premier_amount, islamabad_bill_payments, islamabad_cooking_expenses, islamabad_service_charge, islamabad_couple, islamabad_group, islamabad_family, islamabad_sales, file_11, exit);
            // For Lahore Branch.
     //       read_data_5_arrays(num_lahore_cook, lahore_cook_name, lahore_cook_username, lahore_cook_password, lahore_cook_cnic, lahore_cook_contact, file_12, exit);
   //         read_data_5_arrays(num_lahore_waiter, lahore_waiter_name, lahore_waiter_username, lahore_waiter_password, lahore_waiter_cnic, lahore_waiter_contact, file_13, exit);
 //           read_data_5_arrays(num_lahore_worker, lahore_worker_name, lahore_worker_username, lahore_worker_password, lahore_worker_cnic, lahore_worker_contact, file_14, exit);
//            read_data_5_arrays(num_lahore_sweeper, lahore_sweeper_name, lahore_sweeper_username, lahore_sweeper_password, lahore_sweeper_cnic, lahore_sweeper_contact, file_15, exit);
           // read_data_5_arrays(num_lahore_guard, lahore_guard_name, lahore_guard_username, lahore_guard_password, lahore_guard_cnic, lahore_guard_contact, file_16, exit);
          //  read_data_array_int(num_lahore_dishes, lahore_dishes, lahore_dish_prices, file_17, exit);
          //  read_data_1_array(num_lahore_premier, lahore_premier_username, file_18, exit);
        //    read_data_1_array(num_lahore_student, lahore_student_username, file_19, exit);
       //     read_data_2_arrays(num_lahore_feedback, lahore_feedback_username, lahore_feedback, file_20, exit);
      //      read_singles(owner_name, owner_username, owner_password, sal_lahore_cook, sal_lahore_waiter, sal_lahore_worker, sal_lahore_sweeper, sal_lahore_guard, sal_lahore_manager, lahore_student_amount, lahore_premier_amount, lahore_bill_payments, lahore_cooking_expenses, lahore_service_charge, lahore_couple, lahore_group, lahore_family, lahore_sales, file_21, exit);
            // For Multan Branch.
        //    read_data_5_arrays(num_multan_cook, multan_cook_name, multan_cook_username, multan_cook_password, multan_cook_cnic, multan_cook_contact, file_22, exit);
      //      read_data_5_arrays(num_multan_waiter, multan_waiter_name, multan_waiter_username, multan_waiter_password, multan_waiter_cnic, multan_waiter_contact, file_23, exit);
    //        read_data_5_arrays(num_multan_worker, multan_worker_name, multan_worker_username, multan_worker_password, multan_worker_cnic, multan_worker_contact, file_24, exit);
  //          read_data_5_arrays(num_multan_sweeper, multan_sweeper_name, multan_sweeper_username, multan_sweeper_password, multan_sweeper_cnic, multan_sweeper_contact, file_25, exit);
           // read_data_5_arrays(num_multan_guard, multan_guard_name, multan_guard_username, multan_guard_password, multan_guard_cnic, multan_guard_contact, file_26, exit);
         //   read_data_array_int(num_multan_dishes, multan_dishes, multan_dish_prices, file_27, exit);
       //     read_data_1_array(num_multan_premier, multan_premier_username, file_28, exit);
     //       read_data_1_array(num_multan_student, multan_student_username, file_29, exit);
   //         read_data_2_arrays(num_multan_feedback, multan_feedback_username, multan_feedback, file_30, exit);
 //           read_singles(owner_name, owner_username, owner_password, sal_multan_cook, sal_multan_waiter, sal_multan_worker, sal_multan_sweeper, sal_multan_guard, sal_multan_manager, multan_student_amount, multan_premier_amount, multan_bill_payments, multan_cooking_expenses, multan_service_charge, multan_couple, multan_group, multan_family, multan_sales, file_31, exit);

 /*           if (exit == 1) // Conditon to check encryption of files.
            {
              Console.Clear();
             menu();
                encrypted_file();
                
                 * 
                 * 
                 * 
                 * 
                 * 
                 * 
                 
            }*/
            while (true) // Loop for the main menu.
            {            // Printing the main menu and taking input.
                Console.Clear();
                menu();
                user_type();
                input_option(ref option_select);
                if (option_select == "1")
                {
                    int back = 0;
                    while (back == 0) // Loop to show Access Hub Menu.
                    {
                        Console.Clear();
                        menu();
                        access_hub();
                        input_option(ref option_select);
                        if (option_select == "1")
                        {
                            while (back == 0)
                            {
                                if (owner_username == "\0" || owner_password == "\0") // Condition to check whether owner is signed_up or not.
                                {
                                    Console.Clear();
                                    menu();
                                    not_signed(owner);
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    menu();
                                    sign_in(ref check_username,ref check_password);                                      // Function to check access the owner menu.
                                    if ((check_username == owner_username) && (check_password == owner_password)) // Condition to check whether inputs are valid.
                                    {
                                        while (back == 0)
                                        {
                                            Console.Clear();
                                            menu();
                                            branch_menu();
                                            input_option(ref option_select); // Takes input to select the branch.
                                            if (option_select == "1")
                                            { // Islamabad Branch
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    menu();
                                                    owner_menu();
                                                    check_profit_loss(ref islamabad_profit,ref islamabad_loss, islamabad_sales, islamabad_expenditures);
                                                    input_option(ref option_select);
                                                    if (option_select == "1")
                                                    { // Functionality to view all information about employs.
                                                        while (true)
                                                        {
                                                            clear();
                                                            staff_information();
                                                            input_option(ref option_select);
                                                            if (option_select == "1")
                                                            {
                                                                // Viewsinformation about cooks.
                                                                clear();
                                                                display();
                                                                show_staff_information(num_islamabad_cook, islamabad_cook_name, islamabad_cook_username, islamabad_cook_cnic, islamabad_cook_contact);
                                                                Console.ReadKey();
                                                            }
                                                            else if (option_select == "2")
                                                            {
                                                                // Viewsinformation about waiters.
                                                                clear();
                                                                display();
                                                                show_staff_information(num_islamabad_waiter, islamabad_waiter_name, islamabad_waiter_username, islamabad_waiter_cnic, islamabad_waiter_contact);
                                                                Console.ReadKey();
                                                            }
                                                            else if (option_select == "3")
                                                            {
                                                                // Viewsinformation about workers.
                                                                clear();
                                                                display();
                                                                show_staff_information(num_islamabad_worker, islamabad_worker_name, islamabad_worker_username, islamabad_worker_cnic, islamabad_worker_contact);
                                                                Console.ReadKey();
                                                            }
                                                            else if (option_select == "4")
                                                            {
                                                                // Viewsinformation about sweepers.
                                                                clear();
                                                                display();
                                                                show_staff_information(num_islamabad_sweeper, islamabad_sweeper_name, islamabad_sweeper_username, islamabad_sweeper_cnic, islamabad_sweeper_contact);
                                                                Console.ReadKey();
                                                            }
                                                            else if (option_select == "5")
                                                            {
                                                                // Viewsinformation about guards.
                                                                clear();
                                                                display();
                                                                show_staff_information(num_islamabad_guard, islamabad_guard_name, islamabad_guard_username, islamabad_guard_cnic, islamabad_guard_contact);
                                                                Console.ReadKey();
                                                            }
                                                            else if (option_select == "6")
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                // Prints invalid statment.
                                                                Console.SetCursorPosition(62, 28);
                                                                invalid();
                                                            }
                                                        }
                                                    }
                                                    else if (option_select == "2")
                                                    {

                                                        while (true)
                                                        { // Functionality to edit salaries of employs.
                                                            clear();
                                                            show_salary(sal_islamabad_manager, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard);
                                                            input_option(ref option_select);
                                                            if (option_select == "1")
                                                            { // Editing salary of manager.
                                                                set_salary(manager, ref sal_islamabad_manager);
                                                            }
                                                            else if (option_select == "2")
                                                            {
                                                                // Editing salary of cook.
                                                                set_salary(cook,ref  sal_islamabad_cook);
                                                            }
                                                            else if (option_select == "3")
                                                            {
                                                                // Editing salary of waiter.
                                                                set_salary(waiter,ref sal_islamabad_waiter);
                                                            }
                                                            else if (option_select == "4")
                                                            {
                                                                // Editing salary of workers.
                                                                set_salary(worker,ref sal_islamabad_worker);
                                                            }
                                                            else if (option_select == "5")
                                                            {
                                                                // Editing salary of sweepers.
                                                                set_salary(sweeper,ref sal_islamabad_sweeper);
                                                            }
                                                            else if (option_select == "6")
                                                            {
                                                                // Editing salary of guards.
                                                                set_salary(guard,ref sal_islamabad_guard);
                                                            }
                                                            else if (option_select == "7")
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.SetCursorPosition(58, 29);
                                                                invalid();
                                                            }
                                                            //write_singles(owner_name, owner_username, owner_password, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard, sal_islamabad_manager, islamabad_student_amount, islamabad_premier_amount, islamabad_bill_payments, islamabad_cooking_expenses, islamabad_service_charge, islamabad_couple, islamabad_group, islamabad_family, islamabad_sales, file_11);
                                                        }
                                                    }
                                                    else if (option_select == "3")
                                                    {
                                                        // Functionality showing all expenditures of branch.
                                                        clear();
                                                        sum_of_salaries(ref islamabad_salaries, sal_islamabad_manager, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard, num_islamabad_manager, num_islamabad_cook, num_islamabad_waiter, num_islamabad_worker, num_islamabad_sweeper, num_islamabad_guard);
                                                        sum_of_expenditures(ref islamabad_expenditures, islamabad_salaries, islamabad_bill_payments, islamabad_cooking_expenses);
                                                        show_total_expenditures(islamabad_salaries, islamabad_bill_payments, islamabad_cooking_expenses, islamabad_expenditures);
                                                        Console.ReadKey();
                                                    }
                                                    else if (option_select == "4")
                                                    {
                                                        // Functionality showing profit or loss of branch.
                                                        clear();
                                                        sum_of_salaries(ref islamabad_salaries, sal_islamabad_manager, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard, num_islamabad_manager, num_islamabad_cook, num_islamabad_waiter, num_islamabad_worker, num_islamabad_sweeper, num_islamabad_guard);
                                                        sum_of_expenditures(ref islamabad_expenditures, islamabad_salaries, islamabad_bill_payments, islamabad_cooking_expenses);
                                                        check_profit_loss(ref islamabad_profit,ref islamabad_loss, islamabad_sales, islamabad_expenditures);
                                                        show_profit_loss(islamabad_profit, islamabad_loss, islamabad_sales, islamabad_expenditures);
                                                        Console.ReadKey();
                                                    }
                                                    else if (option_select == "5")
                                                    {
                                                        // Functionality showing average of profit of all branches in form of graph.
                                                        graph(islamabad_profit, lahore_profit, multan_profit);
                                                    }
                                                    else if (option_select == "6")
                                                    {
                                                        // Functionality to add manager for a branch.
                                                        add_manager(ref islamabad_manager_username,ref  islamabad_manager_password,ref islamabad_manager_name,ref num_islamabad_manager,ref option_select);
                                                        //write_managers(islamabad_manager_name, islamabad_manager_username, islamabad_manager_password, lahore_manager_name, lahore_manager_username, lahore_manager_password, multan_manager_name, multan_manager_username, multan_manager_password, file_0);
                                                    }
                                                    else if (option_select == "7")
                                                    {
                                                        // Functionality showing th elist of all customers.
                                                        clear();
                                                        display();
                                                        customer_list(num_customer, customer_name, customer_username, customer_cnic, customer_contact);
                                                        Console.ReadKey();
                                                    }
                                                    else if (option_select == "8")
                                                    {
                                                        // Functionality to change manager for the branch.
                                                        specify_manager(ref islamabad_manager_name, ref islamabad_manager_username,ref islamabad_manager_password,ref option_select,ref check_username,ref check_password);
                                                        //write_managers(islamabad_manager_name, islamabad_manager_username, islamabad_manager_password, lahore_manager_name, lahore_manager_username, lahore_manager_password, multan_manager_name, multan_manager_username, multan_manager_password, file_0);
                                                    }
                                                    else if (option_select == "9")
                                                    {
                                                        // Functionality to change owner's password.
                                                        while (true)
                                                        {
                                                            clear();
                                                            change_owner_password(ref num,ref owner_password);
                                                            if (num == 1)
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                input_option(ref option_select);
                                                                if (option_select == "1")
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        //write_singles(owner_name, owner_username, owner_password, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard, sal_islamabad_manager, islamabad_student_amount, islamabad_premier_amount, islamabad_bill_payments, islamabad_cooking_expenses, islamabad_service_charge, islamabad_couple, islamabad_group, islamabad_family, islamabad_sales, file_11);
                                                    }
                                                    else if (option_select == "10")
                                                    {
                                                        back = 1;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.SetCursorPosition(62, 32);
                                                        invalid();
                                                    }
                                                }
                                            }
                                            else if (option_select == "4")
                                            {
                                                // Returns to previous menu.
                                                back = 1;
                                                break;
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(62, 26);
                                                invalid();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        invalid_1();
                                        input_option(ref value);
                                        if (value == "1")
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else if (option_select == "2")
                        {
                            Console.Clear();
                            menu();
                            if (owner_username != "\0" && owner_password != "\0")
                            {
                                owner_already_signed();
                            }
                            else
                            {
                                clear();
                                sign_up(ref owner_name,ref owner_username,ref owner_password);
                            }
                            //write_singles(owner_name, owner_username, owner_password, sal_islamabad_cook, sal_islamabad_waiter, sal_islamabad_worker, sal_islamabad_sweeper, sal_islamabad_guard, sal_islamabad_manager, islamabad_student_amount, islamabad_premier_amount, islamabad_bill_payments, islamabad_cooking_expenses, islamabad_service_charge, islamabad_couple, islamabad_group, islamabad_family, islamabad_sales, file_11);
                            //write_singles(owner_name, owner_username, owner_password, sal_multan_cook, sal_multan_waiter, sal_multan_worker, sal_multan_sweeper, sal_multan_guard, sal_multan_manager, multan_student_amount, multan_premier_amount, multan_bill_payments, multan_cooking_expenses, multan_service_charge, multan_couple, multan_group, multan_family, multan_sales, file_31);
                            //write_singles(owner_name, owner_username, owner_password, sal_lahore_cook, sal_lahore_waiter, sal_lahore_worker, sal_lahore_sweeper, sal_lahore_guard, sal_lahore_manager, lahore_student_amount, lahore_premier_amount, lahore_bill_payments, lahore_cooking_expenses, lahore_service_charge, lahore_couple, lahore_group, lahore_family, lahore_sales, file_11);
                        }
                        else if (option_select == "3")
                        {
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(62, 25);
                            invalid();
                        }
                    }
                }
            }
        }
        static void menu() // Function to print interface.
        {

            Console.WriteLine(" ###########################################################################################################################################################");
            Console.WriteLine(" #                                                                                                                                                         #");
            Console.Write(" #                                        ");

            Console.Write("____  __     __   ____  __  ____  ____     ___  _  _  __  ____  __  __ _  ____");

            Console.WriteLine("                                   #");
            Console.Write(" #                                       ");

            Console.Write("(  __)/   \\  /   \\(    \\(  )(  __)/ ___)   / __)/ )( \\(  )/ ___)(  )(  ( \\(  __)");

            Console.WriteLine("                                  #");
            Console.Write(" #                                        ");

            Console.Write(") _)(  O  )(  O  )) D ( )(  ) _) \\___ \\  ( (__ ) \\/ ( )( \\___ \\ )( /    / ) _)");

            Console.WriteLine("                                   #");
            Console.Write(" #                                       ");

            Console.Write("(__)  \\ __/  \\ __/(____/(__)(____)(____/   \\___)\\ __ /(__)(____/(__)\\_)__)(____)");

            Console.WriteLine("                                  #");
            Console.WriteLine(" #                                                                                                                                                         #");
            Console.WriteLine(" #                                                                                                                                                         #");
            Console.WriteLine(" ###########################################################################################################################################################");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine("                                                                                                                                                            ");
            Console.WriteLine(" #    #                                            #                                                     #                                            #    #");
            Console.WriteLine(" #     #                                          #                                                       #                                          #     #");
            Console.WriteLine(" # #    ##########################################                                                         ##########################################    # #");
            Console.WriteLine(" # #                                                                                                                                                     # #");
            Console.WriteLine(" # # #                                                                                                                                                 # # #");
            Console.WriteLine(" # # #                                                                                                                                                 # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # # #                                                                                                                                             # # # #");
            Console.WriteLine(" # # #                                                                                                                                                 # # #");
            Console.WriteLine(" # # #                                                                                                                                                 # # #");
            Console.WriteLine(" # #                                                                                                                                                     # #");
            Console.WriteLine(" # #                                                                                                                                                     # #");
            Console.WriteLine(" #                                                                                                                                                         #");
            Console.WriteLine(" #                                                                                                                                                         #");
            Console.WriteLine("             ##################################################################################################################################");
            Console.WriteLine("      ################################################################################################################################################      ");

        }
        static void access_hub() // Prints the menu for access hub.
        {
            Console.SetCursorPosition(62, 15);
            int x = 62;
            int y = 20;
            int owner_options = 0;
            string[] owner_cout = new string[3] { "1.Sign in", "2.Sign up", "3.Return" };
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(owner_cout[i]);
                owner_options = y + 2 + i;
            }
            Console.SetCursorPosition(x, owner_options);
            Console.WriteLine("Enter an option to continue...");
        }
        static void user_type() // Prints the menu for role.
        {
            string user_type_input = "\0";
            int x = 62;
            int y = 20;
            int users = 0;
            string[] user_types = new string[5] { "1.Owner", "2.Manager", "3.Employ", "4.Customer", "5.Exit" };
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(user_types[i]);
                users = y + 2 + i;
            }
            Console.SetCursorPosition(x, users);
            Console.WriteLine("Select an option to continue...");
        }
        static void branch_menu() // Prints the menu for branches.
        {

            int x = 62;
            int y = 20;
            int branch_options = 0;
            string branch_input;
            string[] branch_cout = new string[4] { "1.Islamabad", "2.Lahore", "3.Multan", "4.Return" };
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(branch_cout[i]);
                branch_options = y + 2 + i;
            }
            Console.SetCursorPosition(x, branch_options);
            Console.WriteLine("Enter an option to continue...");
        }
        static void owner_menu() // Prints the menu for owner.
        {
            int x = 62;
            int y = 20;
            int owner_options = 0;
            string[] owner_menu_list = new string[10] { "1.Staff Information", "2.Salary Update", "3.Expendituers", "4.Profit or Loss", "5.Profit Graph", "6.Specify Manager", "7.Customer's List", "8.Change Manager", "9.Change Password", "10.Log out" };
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(owner_menu_list[i]);
                owner_options = y + 2 + i;
            }
            Console.SetCursorPosition(x, owner_options);
            Console.WriteLine("Enter an option to continue...");
        }
        static void manager_menu() // Prints the menu for manager.
        {
            int x = 62;
            int y = 18;
            int manager_options = 0;
            string[] manager_menu_list = new string[13] { "1.Staff Information", "2.Add Employ", "3.Remove Employ", "4.Edit Menu Card", "5.Update Prices", "6.Add Expenses", "7.Check Sales", "8.Add Service Charges", "9.Add Discount", "10.Reservations", "11.Members", "12.Feedback", "13.Log out" };
            for (int i = 0; i < 13; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(manager_menu_list[i]);
                manager_options = y + 2 + i;
            }
            Console.SetCursorPosition(x, manager_options);
            Console.WriteLine("Enter an option to continue...");
        }
        static void customer_menu() // Prints the menu for customer.
        {

            int x = 62;
            int y = 20;
            int branch_options = 0;
            string branch_input;
            string[] branch_cout = new string[8] { "1.Menu Card", "2.Search Dish", "3.Order", "4.Membership", "5.Reservation", "6.Edit Profile", "7.Feedback", "8.Log out" };
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(branch_cout[i]);
                branch_options = y + 2 + i;
            }
            Console.SetCursorPosition(x, branch_options);
            Console.WriteLine("Enter an option to continue...");
        }
        static void employ_menu() // Prints the menu for employ.
        {
            clear();
            Console.SetCursorPosition(62, 15);
            int x = 62;
            int y = 20;
            int owner_options = 0;
            string[] owner_cout = new string[6] { "1.View Menu", "2.Search Dish", "3.Order", "4.Check Salary", "5.Edit Profile", "6.Log out" };
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(owner_cout[i]);
                owner_options = y + 2 + i;
            }
            Console.SetCursorPosition(x, owner_options);
            Console.WriteLine("Enter an option to continue...");
        }
        static void staff_information() // Prints the menu for staff list.
        {
            int x = 62;
            int y = 20;
            int option = 0;
            string[] staff_info = new string[6] { "1.Cook", "2.Waiters", "3.Workers", "4.Sweepers", "5.Guards", "6.Return" };
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(staff_info[i]);
                option = y + 2 + i;
            }
            Console.SetCursorPosition(x, option);
            Console.WriteLine("Enter an option to continue...");
        }
        // Functions to print statements.
        static void invalid() // Only prints invalid statement.
        {

            Console.WriteLine("Invalid input...Press any key to continue...");
            Console.ReadKey();

        }
        static void invalid_1() // Prints two statements for invalid inputs.
        {

            Console.SetCursorPosition(62, 23);
            Console.WriteLine("Invalid input...Press any key to retry...");

            Console.SetCursorPosition(62, 24);
            Console.WriteLine("Press 1 to return...");
        }
        static void owner_already_signed() // Prints owner signed up statement.
        {
            Console.SetCursorPosition(62, 20);
            Console.WriteLine("Owner has already signed up...");
            Console.ReadKey();
        }
        static void display() // Displays the header for information screen.
        {

            int x = 13;
            int y = 17;
            Console.SetCursorPosition(x + 25, y);
            Console.WriteLine("Name");
            Console.SetCursorPosition(x + 46, y);
            Console.WriteLine("Username");
            Console.SetCursorPosition(x + 70, y);
            Console.WriteLine("CNIC");
            Console.SetCursorPosition(x + 88, y);
            Console.WriteLine("Contact No.");

        }
        static void encrypted_file() // Prints statements about file encryption.
        {

            Console.SetCursorPosition(62, 23);
            Console.WriteLine("File is Encrypted...Debug the file first...");
            Console.SetCursorPosition(62, 24);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
        static void clear() // Clear the middle area of console only.
        {
            int x = 15;
            int y = 16;
            for (int i = y; i < 35; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.WriteLine("                                                                                                                   ");
            }
        }
        static void input_option(ref string option_select) // Takes input in parameter.
        {
            option_select = Console.ReadLine();


        }
        static void not_signed(string employ) // Prints that parameter is not signed up.
        {
            Console.SetCursorPosition(62, 20);
            Console.WriteLine(employ+ " is not signed up...");
        }
        static void sign_in(ref string username, ref string password) // Takes inputs in parameters.
        {
            Console.SetCursorPosition(62, 20);
            Console.WriteLine("Username: ");
            input_option(ref username);
            Console.SetCursorPosition(62, 21);
            Console.WriteLine("Password: ");
            input_option(ref password);
        }
        static void sign_up(ref string name, ref string username, ref string password)
        {
            // loop for taking inputs and verifying them.
            while (true)
            {
                clear();
                string option = "0";
                string input_1 = "";
                string input_2 = "";
                string input_3 = "";
                // loop for input name.
                while (true)
                {
                    Console.SetCursorPosition(62, 20);

                    Console.WriteLine("Name: ");
                    input_option(ref input_1);
                    if (input_1 != "\0" && name_space(input_1) == true)
                    {
                        break;
                    }
                    else if ((input_1 == "\0") || (name_space(input_1) == false))
                    {

                        Console.SetCursorPosition(62, 21);
                        Console.WriteLine("Invalid input...");

                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("Press 1 to return...");
                        input_option(ref option);
                        Console.SetCursorPosition(62, 20);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 21);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("                                                                      ");
                        if (option == "1")
                        {
                            break;
                        }
                    }
                }
                if (option == "1")
                {
                    break;
                }
                // Loop for input username.
                while (true)
                {
                    Console.SetCursorPosition(62, 21);
                    Console.WriteLine("Username: ");
                    input_option(ref input_2);
                    if (input_2 != "\0" && name_space(input_2) == true)
                    {
                        break;
                    }
                    else if ((input_2 == "\0") || (name_space(input_2) == false))
                    {

                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("Invalid input...");

                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("Press 1 to return...");
                        input_option(ref option);
                        Console.SetCursorPosition(62, 21);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("                                                                      ");
                        if (option == "1")
                        {
                            break;
                        }
                    }
                }
                if (option == "1")
                {
                    break;
                }
                // Loop for input pasword.
                while (true)
                {
                    Console.SetCursorPosition(62, 22);
                    Console.WriteLine("Password: ");
                    input_option(ref input_3);
                    if (input_3 != "\0" && password_space(input_3) == true)
                    {
                        name = input_1;
                        username = input_2;
                        password = input_3;
                        option = "1";
                        break;
                    }
                    else if ((input_3 == "\0") || (password_space(input_3) == false))
                    {

                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("Invalid input...");

                        Console.SetCursorPosition(62, 24);
                        Console.WriteLine("Press 1 to return...");
                        input_option(ref option);
                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 24);
                        Console.WriteLine("                                                                      ");
                        if (option == "1")
                        {
                            break;
                        }
                    }
                }
                if (option == "1")
                {
                    break;
                }
            }
        }
        // Functions for owner.
        static void set_salary(string employ, ref string salary) // Decides the salary for employs and manager.
        {
            // Loop for accurate value.
            while (true)
            {
                clear();
                Console.SetCursorPosition(62, 20);
                Console.WriteLine("Enter the Salary of "+ employ+ ": ");
                input_option(ref salary);
                if (salary == "\0")
                {
                    Console.SetCursorPosition(62, 21);
                    invalid();
                }
                else
                {
                    int check;
                    check = check_integer(salary);
                    if (check == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(62, 21);
                        invalid();
                    }
                }
            }
        }
        static void add_manager(ref string manager_username, ref string manager_password, ref string manager_name, ref int number, ref string option_select) // Adds manager for particular branch.
        {
            clear();
            // Verificaton of inputs.
            if (manager_username == "\0" || manager_password == "\0")
            {
                sign_up(ref manager_name, ref manager_username, ref manager_password);
            }
            else if ((manager_username != "\0") && (manager_password != "\0"))
            {
                Console.SetCursorPosition(58, 20);
                Console.WriteLine("Manager has already added...");
                Console.SetCursorPosition(58, 21);
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
            }
        }
        static void specify_manager(ref string manager_name, ref string manager_username, ref string manager_password, ref string option_select, ref string check_username, ref string check_password) // Changes the manager of the branch.
        {
            int loop = 0;
            while (loop == 0)
            {
                if (option_select == "1")
                    break;
                if ((manager_username != "\0") && (manager_password != "\0")) // Check whether manager is added.
                {

                    while (loop == 0)
                    {

                        if (option_select == "1")
                        {
                            break;
                        }
                        clear();
                        sign_in(ref check_username, ref check_password);
                        if ((check_username == manager_username) && (check_password == manager_password))
                        {
                            // Loop for valid inputs.
                            while (true)
                            {
                                clear();

                                if (sign_up_1(ref manager_name, ref manager_username, ref manager_password) == false)
                                {
                                    option_select = "1";
                                    loop = 1;
                                    break;
                                }
                                else if (manager_name != "\0" && manager_username != "\0" && manager_password != "\0")
                                {

                                    loop = 1;
                                    Console.SetCursorPosition(62, 24);
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                    break;
                                }
                                else if (manager_username == "\0" || (manager_password == "\0"))
                                {

                                    Console.SetCursorPosition(62, 23);
                                    Console.WriteLine("Invalid input...Username or password must not be empty...");

                                    Console.SetCursorPosition(62, 24);
                                    Console.WriteLine("Press any key to change manager...");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else if ((check_username != manager_username) || (check_password != manager_password) || (check_password == "")) // Verifing inputs.
                        {

                            Console.SetCursorPosition(62, 23);
                            Console.WriteLine("Wrong username or password...Press any key to retry...");

                            Console.SetCursorPosition(62, 24);
                            Console.WriteLine("Press 1 to return...");
                            input_option(ref option_select);
                            if (option_select == "1")
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
                // If manager is not added.
                else if (manager_username == "\0" || manager_password == "\0")
                {
                    clear();
                    Console.SetCursorPosition(58, 20);
                    Console.WriteLine("First add a manager...");
                    Console.SetCursorPosition(58, 21);
                    Console.WriteLine("Press any key to return...");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void show_total_expenditures(int salaries, int bills, int cooking, int expenditures) // Prints different types of expenditures.
        {

            int x = 58;
            int y = 21;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("Expenditure Type                           Amount(Rs)");

            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("Salaries                                     "+ salaries);
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("Bill Payments                                "+ bills);
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("Cooking Expenses                             "+ cooking);
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("Total Expenses                               "+ expenditures);
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("Press any key to return...");
        }
        static void sum_of_expenditures(ref int expenditures, int salaries, int bills, int cooking) // Calculates the sum of expenditures.
        {
            expenditures = salaries + bills + cooking;
        }
        static void show_salary(string manager, string cook, string waiter, string worker, string sweeper, string guard) // Displays all employs with thier salaries.
        {
            int x = 58;
            int y = 19;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("Designation                             Salary(Rs)");

            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("1.Manager                                   " + manager);
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("2.Cook                                      " + cook);
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("3.Waiter                                    " + waiter);
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("4.Worker                                    " + worker);
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("5.Sweeper                                   " + sweeper);
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("6.Guard                                     " + guard);
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("7.Return");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("Select the option to edit...");
        }
        static void show_profit_loss(int profit, int loss, int sales, int expenditures) // Shows total profits or loss.
        {
            int x = 58;
            int y = 21;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Total Sales                                  Rs." + sales);
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("Total Expenditures                           Rs." + expenditures);
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("Profit                                       Rs." + profit);
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("Loss                                         Rs." + loss);
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("Press any key to continue...");
        }
        static void check_profit_loss(ref int profit, ref int loss, int sales, int expenditures) // Calculates whether owner have got profit ur loss.
        {
            int check;
            check = sales - expenditures;
            if (check >= 0)
            {
                profit = check;
                loss = 0;
            }
            else
            {
                loss = check * (-1);
                profit = 0;
            }
        }
        static void sum_of_salaries(ref int salaries, string manager, string cook, string waiter, string worker, string sweeper, string guard, int num_manager, int num_cook, int num_waiter, int num_worker, int num_sweeper, int num_guard) // Function to give sum of salaries.
        {
            // Converting string into integer for calculation.
            int a = int.Parse(manager);
            int b = int.Parse(cook);
            int c = int.Parse(waiter);
            int d = int.Parse(worker);
            int e = int.Parse(sweeper);
            int f = int.Parse(guard);
            salaries = (a * num_manager) + (b * num_cook) + (c * num_waiter) + (d * num_worker) + (e * num_sweeper) + (f * num_guard);
        }
        static void change_owner_password(ref int num, ref string owner_password) // Change onwer paasword.
        {
            int x = 58;
            int y = 20;
            num = 0;
            string password = "\0";
            string password_1 = "\0";
            Console.SetCursorPosition(x, y);
            Console.Write("Enter old password: ");
            input_option(ref password);
            // Verifying the old password.
            if (password == owner_password)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.Write("Enter new password: ");
                input_option(ref password);
                Console.SetCursorPosition(x, y + 2);
                Console.Write("Confirm password: ");
                input_option(ref password_1);
                // Authenticating new password.
                if (password_1 == password && (password != "\0" && password_1 != "\0") && (password_space(password) == true))
                {
                    owner_password = password_1;
                    Console.SetCursorPosition(x, y + 3);
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    num++;
                }
                else if (password == "\0" || password_1 == "\0")
                {

                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("Password must not be empty...");

                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("Press any key to retry...");
                }
                else if (password_space(password) == false)
                {

                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("Password must not contain space...");

                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("Press any key to retry...");
                }
                else
                {

                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine("Password don't match...");

                    Console.SetCursorPosition(x, y + 4);
                    Console.WriteLine("Press any key to retry...");
                }
            }
            else
            {

                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine("Invalid password...Press any key to retry");

                Console.SetCursorPosition(x, y + 2);
                Console.WriteLine("Press 1 to return...");
            }
        }
        static void graph(int input, int input_1, int input_2) // Graph to represent ratio of profits.
        {

            int x = 53;
            int y = 13;
            clear();
            char box = (char)219;

            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 11);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 13);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 14);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 15);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 16);
            Console.WriteLine("|                                                 ");
            Console.SetCursorPosition(x, y + 17);
            Console.WriteLine("|_________________________________________________");
            Console.SetCursorPosition(x, y + 19);
            Console.WriteLine("        --------------Profit------------->");
            int length = graph_length(input, input_1, input_2);
            Console.SetCursorPosition(x + 1, y + 5);
            print_bar(box, length);
            Console.WriteLine(" ISLAMABAD");
            length = graph_length(input_1, input, input_2);
            Console.SetCursorPosition(x + 1, y + 10);
            print_bar(box, length);
            Console.WriteLine(" LAHORE");
            length = graph_length(input_2, input_1, input);
            Console.SetCursorPosition(x + 1, y + 15);
            print_bar(box, length);
            Console.WriteLine(" MULTAN");
            Console.SetCursorPosition(x + 3, y + 21);
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }
        static void print_bar(char box, int length) // Decides the length of bar in graph.
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(box);
            }
        }
        static void show_staff_information(int number, string[] name, string[] username, string[] cnic, string[] contact) // Prints list of employs with information.
        {
            string input_1 = "";
            string input_2 = "";
            string input_3 = "";
            string input_4 = "";
            int x = 13;
            int y = 19;
            for (int i = 0; i < number; i++)
            {
                input_1 = name[i];
                input_2 = username[i];
                input_3 = cnic[i];
                input_4 = contact[i];
                Console.SetCursorPosition(x + 25, y + i);
                for (int j = 0; input_1[j] != '\0'; j++)
                {
                    if (input_1[j] != ' ')
                    {
                        Console.WriteLine(input_1[j]);
                    }
                    else
                    {
                        Console.WriteLine("_");
                    }
                }
                Console.SetCursorPosition(x + 46, y + i);
                for (int j = 0; input_2[j] != '\0'; j++)
                {
                    if (input_2[j] != ' ')
                    {
                        Console.WriteLine(input_2[j]);
                    }
                    else
                    {
                        Console.WriteLine("_");
                    }
                }
                Console.SetCursorPosition(x + 70, y + i);
                for (int j = 0; j < 13; j++)
                {
                    if (j == 5 || j == 12)
                    {
                        Console.WriteLine("-");
                    }
                    Console.WriteLine(input_3[j]);
                }
                Console.SetCursorPosition(x + 88, y + i);
                for (int j = 0; j < 11; j++)
                {
                    if (j == 4)
                    {
                        Console.WriteLine("-");
                    }
                    Console.WriteLine(input_4[j]);
                }
            }
            Console.SetCursorPosition(58, y + number + 1);
            Console.WriteLine("Press any key to continue...");
        }
        static void customer_list(int number, string [] name, string[] username, string[] cnic, string[] contact) // Prints the list of customers.
        {
            string input_1 = "";
            string input_2 = "";
            string input_3 = "";
            string input_4 = "";
            int x = 13;
            int y = 19;
            for (int i = 0; i < number; i++)
            {
                input_1 = name[i];
                input_2 = username[i];
                input_3 = cnic[i];
                input_4 = contact[i];
                Console.SetCursorPosition(x + 25, y + i);
                for (int j = 0; input_1[j] != '\0'; j++)
                {
                    if (input_1[j] != ' ')
                    {
                        Console.WriteLine(input_1[j]);
                    }
                    else
                    {
                        Console.WriteLine("_");
                    }
                }
                Console.SetCursorPosition(x + 46, y + i);
                for (int j = 0; input_2[j] != '\0'; j++)
                {
                    if (input_2[j] != ' ')
                    {
                        Console.WriteLine(input_2[j]);
                    }
                    else
                    {
                        Console.WriteLine("_");
                    }
                }
                Console.SetCursorPosition(x + 70, y + i);
                for (int j = 0; j < 13; j++)
                {
                    if (j == 5 || j == 12)
                    {
                        Console.WriteLine("-");
                    }
                    Console.WriteLine(input_3[j]);
                }
                Console.SetCursorPosition(x + 88, y + i);
                for (int j = 0; j < 11; j++)
                {
                    if (j == 4)
                    {
                        Console.WriteLine("-");
                    }
                    Console.WriteLine(input_4[j]);
                }
            }
            Console.SetCursorPosition(58, y + number + 1);
            Console.WriteLine("Press any key to continue...");
        }
        static int check_integer(string num) // Checks the intergers for a string.
        {
            int check = 0;
            for (int i = 0; num[i] != '\0'; i++)
            {
                if ((num[i] != '0') && (num[i] != '1') && (num[i] != '2') && (num[i] != '3') && (num[i] != '4') && (num[i] != '5') && (num[i] != '6') && (num[i] != '7') && (num[i] != '8') && (num[i] != '9'))
                {
                    check++;
                }
            }
            return check;
        }
        static int check_index(string user, string[] username, int num) // Identifies the index.
        {
            int check = 0;
            if (num != 0)
            {
                for (int i = 0; i < num; i++)
                {
                    if (user == username[i])
                    {
                        check = i;
                        break;
                    }
                }
            }
            else if (num == 0)
            {
                check = 0;
            }
            return check;
        }
        static int graph_length(int input, int input_1, int input_2) // Decides the length of the graph bar.
        {
            int count = 0;
            if (input == 0)
            {
                count = 1;
            }
            else if (input != 0 && (input_1 == 0 && input_2 == 0))
            {
                count = 38;
            }
            else if ((input == input_1 && input_2 == 0) || (input == input_2 && input_1 == 0))
            {
                count = 19;
            }
            else if ((input > input_1 && input_1 != 0) || (input > input_2 && input_2 != 0))
            {
                count = 38;
            }
            else if ((input > input_1 && input < input_2) || (input > input_2 && input < input_1))
            {
                count = 19;
            }
            else if (input == input_1 || input == input_2)
            {
                count = 19;
            }
            else if ((input < input_1 && input != 0) || (input < input_1 && input != 0))
            {
                count = 19;
            }
            else if (input > input_1 && (input_1 == input_2))
            {
                count = 38;
            }
            return count;
        }
        int check_character_num(string record) // calculates the number of character in record.
        {
            int count = 0;
            char a = (char)219;
            for (int i = 0; record[i] != '\0'; i++)
            {

                if (record[i] == a)
                {
                    count++;
                }
            }
            return count;
        }
        // Bool type functions.
        static bool sign_up_1(ref string name, ref string username, ref string password) // Check sign up for new user.
        {
            string option = "0";
            // loop for taking inputs and verifying them.
            while (option == "0")
            {
                clear();
                string input_1 = "";
                string input_2 = "";
                string input_3 = "";
                // loop for input name.
                while (true)
                {
                    Console.SetCursorPosition(62, 20);

                    Console.WriteLine("Name: ");
                    input_option(ref input_1);
                    if (input_1 != "\0" && name_space(input_1) == true)
                    {
                        break;
                    }
                    else if ((input_1 == "\0") || (name_space(input_1) == false))
                    {

                        Console.SetCursorPosition(62, 21);
                        Console.WriteLine("Invalid input...");

                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("Press 1 to return...");
                        input_option(ref option);
                        Console.SetCursorPosition(62, 20);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 21);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("                                                                      ");
                        if (option == "1")
                        {
                            break;
                        }
                    }
                }
                if (option == "1")
                {
                    break;
                }
                // Loop for input username.
                while (true)
                {
                    Console.SetCursorPosition(62, 21);
                    Console.WriteLine("Username: ");
                    input_option(ref input_2);
                    if (input_2 != "\0" && name_space(input_2) == true)
                    {
                        break;
                    }
                    else if ((input_2 == "\0") || (name_space(input_2) == false))
                    {

                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("Invalid input...");

                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("Press 1 to return...");
                        input_option(ref option);
                        Console.SetCursorPosition(62, 21);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("                                                                      ");
                        if (option == "1")
                        {
                            break;
                        }
                    }
                }
                if (option == "1")
                {
                    break;
                }
                // Loop for input pasword.
                while (true)
                {
                    Console.SetCursorPosition(62, 22);
                    Console.WriteLine("Password: ");
                    input_option(ref input_3);
                    if (input_3 != "\0" && password_space(input_3) == true)
                    {
                        name = input_1;
                        username = input_2;
                        password = input_3;
                        option = "1";
                        break;
                    }
                    else if ((input_3 == "\0") || (password_space(input_3) == false))
                    {

                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("Invalid input...");

                        Console.SetCursorPosition(62, 24);
                        Console.WriteLine("Press 1 to return...");
                        input_option(ref option);
                        Console.SetCursorPosition(62, 22);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 23);
                        Console.WriteLine("                                                                      ");
                        Console.SetCursorPosition(62, 24);
                        Console.WriteLine("                                                                      ");
                        if (option == "1")
                        {
                            break;
                        }
                    }
                    if (option == "1")
                    {
                        break;
                    }
                }
            }
            return false;
        }
        static bool check_ratio(string input) // Checks if input is less than 100.
        {
            int int_input = 0;
            if (input != "")
            {
                if (check_integer(input) == 0)
                {
                    int_input = int.Parse(input);
                    if (int_input < 101)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        bool check_username(string input, string[] compare, int number) // Checks validation for username.
        {

            if (input != "")
            {
                if (number == 0)
                {
                    return true;
                }
                else
                {
                    for (int i = 0; i < number; i++)
                    {
                        if (input == compare[i])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        bool check_cnic(string input, string[] compare, int number) // Validation for CNIC.
        {
            if (check_integer(input) == 0)
            {
                if (input.Length == 13)
                {
                    if (input != "\0")
                    {
                        if (number == 0)
                        {
                            return true;
                        }
                        else
                        {
                            for (int i = 0; i < number; i++)
                            {
                                if (input == compare[i])
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }

                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        bool check_contact(string input, string[] compare, int number) // Validation for contact number.
        {
            if (check_integer(input) == 0)
            {
                if (input.Length== 11)
                {
                    if (input != "\0")
                    {
                        if (number == 0)
                        {
                            return true;
                        }
                        else
                        {
                            for (int i = 0; i < number; i++)
                            {
                                if (input == compare[i])
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        static bool password_space(string input) // Verification of space characters.

        {
            for (int i = 0; input[i] != '\0'; i++)
            {
                if (input[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }
        static bool name_space(string input) // Validation for space characters in string.
        {
            int num = 0;
            if (input.Length == 0)
            {
                return false;
            }
            for (int i = 0; input[i] != '\0'; i++)
            {
                num = i;
            }
            if (input[0] == ' ' || input[num] == ' ' || input[0] == '\0')
            {
                return false;
            }
            return true;
        }



    

                }
            }
        