using System;
using System.Linq;

namespace Algorithm
{
    class Program
    {
        static string text;
        static string pattern;
        static void Main(string[] args)
        {           
            while (true)
            {
               
                char[] trueValues = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',',','.',' '};                
                int countt;
                bool flag2;
                do //This loop checks that the text the user enters consists of English characters and some punctuations.
                {
                    flag2 = true;
                    countt = 0;
                    Console.Write("Please enter the text :");
                    text = Console.ReadLine();
                    text = text.ToLower();
                    for (int i = 0; i < text.Length; i++)
                    {
                        for (int a = 0; a < trueValues.Length; a++)
                        {
                            if (text[i] == trueValues[a])
                            {
                                countt++;
                                break;
                            }                            
                        }
                    }
                    if (countt != text.Length)
                    {
                        Console.WriteLine("Please enter just english sentences");
                        flag2 = false;
                    }
                } while (flag2== false);
                trueValues = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '*', '-'};
                
                do //This loop checks that the pattern the user enters consists of English characters and some marks.
                {
                    countt = 0;
                    flag2 = true;
                    Console.Write("Please enter the pattern :");
                    pattern = Console.ReadLine();
                    pattern = pattern.ToLower();
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        if (((pattern.Contains('*') && pattern.Contains('-')) || (!pattern.Contains('*') && !pattern.Contains('-'))))
                        {
                            flag2 = false;
                            Console.WriteLine("Pattern has to contain * or -");
                            break;
                        }
                        for (int a = 0; a < trueValues.Length; a++)
                        {
                            if (pattern[i] == trueValues[a])
                            {
                                countt++;
                                break;
                            }
                        }
                        if (flag2 == false)
                        {
                            break;
                        }
                    }
                    if (flag2==true && countt != pattern.Length)
                    {
                        Console.WriteLine("Please enter just english sentences");
                        flag2 = false;
                    }
                } while (!flag2);                              
                text = text.Replace(",", " ");
                text = text.Replace(".", " ");
                text = text.Replace("   ", "  ");
                text = text.Replace("  ", " ");
                bool flag = true;               
                string[] text1 = text.Split(" ");
                 text1 = text1.Distinct().ToArray(); //Extracts the same words in the array.
                for (int i = 0; i < text1.Length; i++)//This loop checks the - sign by creating a counter based on the length of the word and the pattern and the equality of the indexes of the pattern and text.
                {
                    if (text1[i].Length == pattern.Length)
                    {
                        int count = 0;
                        string text_ = text1[i];
                        for (int a = 0; a < pattern.Length; a++)
                        {
                            if (text_[a] == pattern[a] || pattern[a] == '-')
                            {
                                count++;
                                if (count == pattern.Length&&text1[i]!= " ")
                                {
                                    Console.WriteLine(text1[i]);
                                }
                            }
                            else
                            {
                                flag = false;
                                break;
                            }
                        }
                    }                    
                }
                int numberOfPattern = 0;
                for (int i = 0; i < pattern.Length; i++) //Checks how many * are in the pattern.
                {
                    if (pattern[i] == '*')
                    {
                        numberOfPattern++;
                    }
                }
                int indexOfPattern = pattern.IndexOf('*');
                if (pattern.Contains('*') && numberOfPattern == pattern.Length) //prints all the elements of the array if the number * is the same as the length of the pattern.
                {
                    for (int i = 0; i < text1.Length; i++)
                    {
                        string elementOfArray = text1[i];
                        if (elementOfArray != "  ")
                        {
                            Console.WriteLine(elementOfArray);
                        }
                        

                    }
                }
                if (pattern.Contains('*') && numberOfPattern == 1)//If the * number is in the 1st and 0th index, it checks the pattern and the end of the text according to the length of the pattern and prints it if they are the same.
                {
                    if (pattern[0] == '*')
                    {
                        for (int i = 0; i < text1.Length; i++)
                        {
                            int countPattern = 0;
                            string elementOfArray = text1[i];
                            if (elementOfArray.Length + 1 >= pattern.Length)
                            {
                                for (int b = elementOfArray.Length - 1; b > elementOfArray.Length - (pattern.Length); b--)
                                {
                                    for (int a = pattern.Length - 1; a >= 1; a--)
                                    {
                                        if (elementOfArray[b] == pattern[a])
                                        {
                                            countPattern++;
                                            if (countPattern == pattern.Length - 1&&elementOfArray!= " ")
                                            {
                                                Console.WriteLine(elementOfArray);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else if (pattern[pattern.Length - 1] == '*') //If the * number is 1 and in the last index, it checks the pattern and the beginning of the text according to the length of the pattern and prints it if they are the same.
                    {
                        for (int i = 0; i < text1.Length; i++)
                        {
                            int countPattern = 0;
                            string elementOfArray = text1[i];
                            if (elementOfArray.Length + 1 >= pattern.Length)
                            {
                                for (int b = 0; b <= pattern.Length - 2; b++)
                                {
                                    for (int a = 0; a <= pattern.Length - 2; a++)
                                    {
                                        if (elementOfArray[b] == pattern[a])
                                        {
                                            countPattern++;
                                            if (countPattern == pattern.Length - 1 && elementOfArray != " ")
                                            {
                                                Console.WriteLine(elementOfArray);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < text1.Length; i++)//It checks the beginning and end of the pattern and the beginning and the end of the text according to the indexes to be in the middle in the pattern, and the count increases according to the accuracy in each index, if the number of the count is one less than the length of the pattern, it prints it.
                        {
                            int countPattern = 0;
                            string elementOfArray = text1[i];
                            if (elementOfArray.Length + 1 >= pattern.Length)
                            {
                                for (int b = 0; b < indexOfPattern; b++)
                                {
                                    for (int a = 0; a < indexOfPattern; a++)
                                    {
                                        if (elementOfArray[b] == pattern[a])
                                        {
                                            countPattern++;
                                            break;
                                        }
                                    }
                                }
                                for (int c = elementOfArray.Length - 1; c > elementOfArray.Length - 1 - (pattern.Length - indexOfPattern - 1); c--)
                                {
                                    for (int d = pattern.Length - 1; d > indexOfPattern; d--)
                                    {
                                        if (elementOfArray[c] == pattern[d])
                                        {
                                            countPattern++;
                                            break;
                                        }
                                    }
                                }
                                if (countPattern == pattern.Length - 1 && elementOfArray != " ")
                                {
                                    Console.WriteLine(elementOfArray);
                                }
                            }

                        }
                    }
                }
                bool flag1 = false;
                int[] whichIndex = new int[2];
                if (pattern.Contains('*') && numberOfPattern == 2)
                {
                    for (int i = 0; i < text1.Length; i++)
                    {
                        string elementOfArray = text1[i];
                        for (int a = 0; a < pattern.Length; a++)//In case of more than one star, it checks the indexes of the stars in the pattern.
                        {
                            if (flag1 && pattern[a] == '*')
                            {
                                whichIndex[1] = a;
                            }
                            else if (pattern[a] == '*')
                            {
                                whichIndex[0] = a;
                                flag1 = true;
                            }
                        }
                        if (elementOfArray.Length + 2 >= pattern.Length&& whichIndex[0]+1!=whichIndex[1])//Controls two-star pattern states when the stars are not next to each other.
                        {

                            if (whichIndex[0] != 0 && whichIndex[1] != pattern.Length - 1)
                            {
                                string[] p = new string[3];
                                string[] t = new string[3];
                                t[0] = elementOfArray.Substring(0, whichIndex[0]);
                                string elementOfArray1 = elementOfArray.Remove(0, whichIndex[0]);
                                string elementOfArray2 = elementOfArray.Remove(elementOfArray.Length - (pattern.Length - 1 - whichIndex[1]), pattern.Length - 1 - whichIndex[1]);
                                t[1] = elementOfArray2;
                                t[2] = elementOfArray.Substring(elementOfArray.Length - (pattern.Length - 1 - whichIndex[1]),pattern.Length-1-whichIndex[1]);
                                p[0] = pattern.Substring(0, whichIndex[0]);
                                p[1] = pattern.Substring(whichIndex[0] + 1, whichIndex[1] - whichIndex[0] - 1);
                                p[2] = pattern.Substring(whichIndex[1] + 1);
                                if (t[0] == p[0] &&elementOfArray2.Contains(p[1]) && p[2] == t[2] && elementOfArray != " ")
                                {
                                    Console.WriteLine(elementOfArray);
                                }
                            }
                            else if (whichIndex[0] == 0 && whichIndex[1] != pattern.Length - 1)
                            {
                                string[] p = new string[2];
                                string[] t = new string[1];
                                p[0] = pattern.Substring(1, whichIndex[1] - 1);
                                p[1] = pattern.Substring(whichIndex[1] + 1);
                                string elementOfArray1 = elementOfArray.Remove(elementOfArray.Length - (pattern.Length - 1 - whichIndex[1]), pattern.Length - 1 - whichIndex[1]);                                
                                t[0] = elementOfArray.Substring(elementOfArray.Length - (pattern.Length - 1 - whichIndex[1]), pattern.Length - 1 - whichIndex[1]);
                                if (p[1] == t[0] && elementOfArray1.Contains(p[0]) && elementOfArray != " ")
                                {
                                    Console.WriteLine(elementOfArray);
                                }

                            }
                            else if (whichIndex[0] != 0 && whichIndex[1] == pattern.Length - 1)
                            {
                                string[] p = new string[2];
                                string[] t = new string[1];
                                p[0] = pattern.Substring(0, whichIndex[0]);
                                p[1] = pattern.Substring(whichIndex[0] + 1, whichIndex[1] - whichIndex[0] - 1);
                                t[0] = elementOfArray.Substring(0, whichIndex[0]);
                                string elementOfArray1 = elementOfArray.Remove(0, whichIndex[0]);
                                if (p[0] == t[0] && elementOfArray1.Contains(p[1]) && elementOfArray != " ")
                                {
                                    Console.WriteLine(elementOfArray);
                                }
                            }
                            else
                            {
                                string[] p = new string[1];
                                p[0] = pattern.Substring(whichIndex[0] + 1, pattern.Length - 2);
                                if (elementOfArray.Contains(p[0]) && elementOfArray != " ")
                                {
                                    Console.WriteLine(elementOfArray);
                                }
                            }
                        }
                        else if(elementOfArray.Length + 2 >= pattern.Length && whichIndex[0] + 1 == whichIndex[1]&&whichIndex[0] !=0 &&whichIndex[1]!=pattern.Length-1)//Controls two-star states when the stars are next to each other and neither is at the beginning or the end.
                        {
                            string[] p = new string[2];
                            p[0] = pattern.Substring(0, whichIndex[0]);
                            p[1] = pattern.Substring(whichIndex[1] + 1);
                            string[] t = new string[2];
                            t[0] = elementOfArray.Substring(0, whichIndex[0]);
                            t[1]= elementOfArray.Substring(elementOfArray.Length - (pattern.Length - 1 - whichIndex[1]), pattern.Length - 1 - whichIndex[1]);
                            if (p[0] == t[0]&&t[1] == p[1] && elementOfArray != " ")
                            {
                                Console.WriteLine( elementOfArray);
                            }

                        }
                        else if (elementOfArray.Length + 2 >= pattern.Length && whichIndex[0] + 1 == whichIndex[1] && whichIndex[0] == 0 && whichIndex[1] != pattern.Length - 1)//checks for two-star states when the stars are next to each other and one is at the beginning and the other is not at the end.
                        {
                            string[] p = new string[1];                            
                            p[0] = pattern.Substring(whichIndex[1] + 1);
                            string[] t = new string[1];                            
                            t[0] = elementOfArray.Substring(elementOfArray.Length - (pattern.Length - 1 - whichIndex[1]), pattern.Length - 1 - whichIndex[1]);
                            if (p[0] == t[0] && elementOfArray != " ")
                            {
                                Console.WriteLine(elementOfArray);
                            }

                        }
                        else if (elementOfArray.Length + 2 >= pattern.Length && whichIndex[0] + 1 == whichIndex[1] && whichIndex[0] != 0 && whichIndex[1] == pattern.Length - 1)//Controls two-star states when the stars are next to each other and one is not at the beginning and the other is at the end.
                        {
                            string[] p = new string[1];
                            p[0] = pattern.Substring(0, whichIndex[0]);
                            string[] t = new string[1];
                            t[0] = elementOfArray.Substring(0, whichIndex[0]);
                            if (p[0] == t[0] && elementOfArray != " ")
                            {
                                Console.WriteLine(elementOfArray);
                            }
                        }
                        
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;            
                Console.ResetColor();                
                
            }
                       
           
        }
    }
}
