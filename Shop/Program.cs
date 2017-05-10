﻿using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram=true;//Controling the Main loop
            while(runProgram)
            {
                Console.Clear();
               
                Console.WriteLine("Welcome to the Magic Store\nPlease navigate in the menu by using numbers");

                Console.WriteLine("(1)Enter the shop\n(0)Exit");
                //Main Menu
                switch(Console.ReadLine())
                {
                    case "1"://Entering the Shop
                        
                        bool questioning = true;
                        string answer = "-1";
                        while(questioning)
                        {
                            Console.Clear();
                            Console.WriteLine("Dangers ahead!!!\nAre you really sure that you want to enter the shop?(y/n)");

                            answer = Console.ReadLine().ToLower();
                            switch(answer)
                            {
                                case "y":
                                    questioning = false;
                                    break;
                                case "n":
                                    questioning = false;
                                    break;
                                default:
                                    Console.WriteLine("Error Message: input isn't 'y' or 'n'\nPlease enter a key to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        if (answer == "y")//Enter the shop
                        {
                            ShopLogic shop=new ShopLogic();
                            bool inShop = true;
                            int sortValue = 0;
                            while (inShop)
                            {
                                
                                Console.Clear();
                                Console.WriteLine("(1)Buy\n(2)Shopping cart\n(3)Search\n(4)Sorting\n(0)Exit");
                                /*  I have failed with protecting the storage from editing inside Program.cs
                                 *  Programmers can in theory inject code inside here so this is a hole on the security aspect
                                 *  How should I do to avoid this from happening? I want some classes to be allowed for editing but the thing is
                                 *  it can be used the other way around. I guess it's because I'm returning the same List in storage instead of returning a readonly copy
                                foreach (Item item in shop.GetAllItems())
                                {
                                    item.Price = 22; //Change price for specific item
                                }
                                 */

                                PrintLine();
                                string[] column = {"Article Number","Name","Category","Price" };
                                PrintRow("Item List");
                                PrintLine();
                                PrintRow(column);
                                column = null;
                                
                                foreach(var item in shop.GetAllItems(sortValue))
                                {
                                    PrintLine();
                                    string[] column2 = { item.ProductNumber,item.Name,item.Category.ToString(), item.Price.ToString()+"$" };
                                    PrintRow(column2);
                                    
                                }
                                switch(Console.ReadLine())
                                {

                                    case "1":
                                    Console.Clear();
                                    Console.WriteLine("Please enter the item name or article number for the item you want to buy");
                                    bool added=shop.AddToCart(Console.ReadLine());
                                    if (added==true)
                                    {
                                        Console.WriteLine("Item is added to your cart.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The item you want to add doesn't exist in the shop.");
                                    }
                                    Console.ReadKey();
                                        break;
                                    case "2":
                                    
                                    bool shoppingListLoop = true;
                                    while(shoppingListLoop==true)
                                    {
                                        Console.Clear();

                                        Console.WriteLine("1. Remove Item   2. Get Receipt  3. Return back");
                                        foreach(Item item in shop.GetCartList())
                                        {
                                            Console.WriteLine("Name: " + item.Name + "\nArticle Number: " + item.ProductNumber);
                                        }
                                        switch(Console.ReadLine())
                                        {
                                            case "1":
                                                Console.Clear();
                                                Console.WriteLine("Enter a name or article number for the item you want to remove from your shopping cart. ");
                                                bool removed=shop.RemoveFromCart(Console.ReadLine());
                                                if(removed==true)
                                                {
                                                    Console.WriteLine("An item got removed from your shopping cart.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The item you want to remove doesn't exist in your shopping cart.");
                                                }
                                                break;
                                            case "2": //Get the Shopping Reciept and output it too console
                                                Console.Clear();
                                                Console.WriteLine(shop.GetReceipt());
                                                Console.ReadKey();
                                                break;
                                            case "3"://Return back
                                                shoppingListLoop = false;
                                                break;
                                        }
                                    }
                                        break;
                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine("Please enter something to search for item(s).");
                                PrintLine();
                                string[] column3 = {"Article Number","Name","Category","Price" };
                                PrintRow("Item List");
                                PrintLine();
                                PrintRow(column3);
                                column = null;
                                
                                foreach(var item in shop.SearchItem(Console.ReadLine()))
                                {
                                    PrintLine();
                                    string[] column2 = { item.ProductNumber,item.Name,item.Category.ToString(), item.Price.ToString()+"$" };
                                    PrintRow(column2);
                                    
                                }
                                Console.ReadKey();
                                        break;
                                    case "4":
                                        Console.Clear();
                                        Console.WriteLine("Sorting Menu");
                                        Console.WriteLine("(1)Names\n(2)Price\n(3)Names and Price\n(4)Price grouped by Category\n(5)Category\n(6)Reset Sort\n(0)Return back");
                                        switch(Console.ReadLine())
                                        {
                                            case "1":
                                                sortValue = 1;
                                                break;
                                            case "2":
                                                sortValue = 2;
                                                break;
                                            case "3":
                                                sortValue = 3;
                                                break;
                                            case "4":
                                                sortValue = 4;
                                                break;
                                            case "5":
                                                sortValue = 5;
                                                break;
                                            case "6":
                                                sortValue = 0;
                                                break;
                                            case "0":
                                                break;
                                        }
                                        break;
                                    case "0":
                                        inShop = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You will return back to main menu!");
                            Console.ReadKey();
                        }
                        break;
                    case "0": //Exit the program
                        runProgram = false;
                        break;
                }
                
            }
        }
        //Table Code from patrick-mcdonald - Code taken from http://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
        static int tableWidth = 117;

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text; //If the string is too long, three dots are added and the string is shortened

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
