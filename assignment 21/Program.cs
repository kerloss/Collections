using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System;

namespace assignment_21
{
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ID : {Id} , Title : {Title} , Price : {Price}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Title.GetHashCode() ^ Price.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            Movie? movie = obj as Movie;
            if (movie == null)
                return false;
            else
                return (this.Id.Equals(movie.Id)) && (this.Title.Equals(movie.Title)) && (this.Price.Equals(movie.Price));
        }
    }

    internal class Program
    {
        public static int SumArrayList(ArrayList arrayList)
        {
            int sum = 0;
            if (arrayList != null)
            {
                for (int i = 0; i < arrayList.Count; i++)
                {
                    sum += (int?)arrayList[i] ?? 0;
                    //casting from object [ref type] to int [value type] => unboxing
                }
            }
            return sum;
        }

        public static void Reverse(ArrayList arrayList)
        {
            int left = 0;
            int right = arrayList.Count - 1;

            while (left < right)
            {
                //swap elements at left and right indices
                object temp = arrayList[left];
                arrayList[left] = arrayList[right];
                arrayList[right] = temp;

                //move left index to the right by one
                left++;

                //move roght to the left by one
                right--;
            }
        }

        public static List<int> findEvenNumber(List<int> inputList)
        {
            List<int> evenNumber = new List<int>();
            foreach (int number in inputList)
            {
                if (number % 2 == 0)
                {
                    evenNumber.Add(number);
                }
            }
            return evenNumber;
        }

        public static int FirstNonRepeatedCharacter(string input)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            //count the frequantly of each character in the string
            foreach (char item in input)
            {
                if (result.ContainsKey(item))
                    result[item]++;
                else 
                    result[item] = 1;
            }

            // Find the index of the first non-repeated character
            for (int i = 0; i < input.Length; i++)
            {
                if (result[input[i]] == 1)
                {
                    return i;
                }
            }
            return -1; // Return -1 if no non-repeated character is found
        }

        static void Main(string[] args)
        {
            #region Part 1

            #region Non-Generic ArrayList
            //    ArrayList arrayList = new ArrayList() { 1 };

            //    //Count number of elements that already found in arraylist
            //    //Capacity total size of arraylist
            //    Console.WriteLine($"Count : {arrayList.Count} , Capicity : {arrayList.Capacity}");  //Count : 0 , Capicity : 0

            //    arrayList.Add(2);   //Boxing  //from int => object

            //    //when adding first value in arraylist CLI by default create size of arraylist = 4
            //    //default capacity = 4
            //    Console.WriteLine($"Count : {arrayList.Count} , Capicity : {arrayList.Capacity}");  //Count : 1 , Capicity : 4

            //    arrayList.AddRange(new int[] { 3, 4 });  //AddRange take array or list of object
            //    Console.WriteLine($"Count : {arrayList.Count} , Capicity : {arrayList.Capacity}");  //Count : 4 , Capicity : 4

            //    arrayList.Add(5);
            //    Console.WriteLine($"Count : {arrayList.Count} , Capicity : {arrayList.Capacity}");  //Count : 5 , Capicity : 8

            //    //unused byte => 3 capacity * 4 byte of object = 12 bytes
            //    //Release | Deallocate | Free | Delete for unused bytes
            //    //arrayList.TrimToSize();
            //    Console.WriteLine($"Count : {arrayList.Count} , Capicity : {arrayList.Capacity}");  //Count : 5 , Capicity : 5

            //    //when your capacity increase 4 and 8 and 16 or make TrimToSize that mean you create new array
            //    //that mean u have many of unreachable arrays then the heap will full then carbage collector will run

            //    //ArrayList arrayList1 = new ArrayList(5);
            //    //Console.WriteLine($"Count : {arrayList.Count} , Capicity : {arrayList.Capacity}");  //Count : 5 , Capicity : 8

            //    //compiler cant enforce type safety 
            //    arrayList.Add("hamada");

            //    foreach (var numbers in arrayList) //unBoxing  //object => int
            //    {
            //        Console.WriteLine(numbers);
            //    }

            //    int result = SumArrayList(arrayList);
            //    Console.WriteLine(result); 
            #endregion

            #region Generic List
            ////its similar to ArrayList in functianality
            //List<int> numbers = new List<int>(8) { 1 };
            //numbers.Add(2);
            //numbers.AddRange(new int[] { 3, 4 });
            //numbers.Add(5);
            //Console.WriteLine($"Count : {numbers.Count} , Capicity : {numbers.Capacity}");
            ////CLR will allocate new array with the size double size = 8

            ////numbers.TrimExcess();
            //numbers.Add(6);
            //Console.WriteLine($"Count : {numbers.Count} , Capicity : {numbers.Capacity}");  //Count :6 , Capicity : 10

            //foreach (var number in numbers)
            //    Console.WriteLine(number);

            ////numbers.Add("hanadaaa");    //invalid
            //////compiler can enforce type safety

            //numbers[2] = 100;   //use indexer as setter/update
            //Console.WriteLine(numbers[2]);  //100 use indexer as getter

            #endregion

            #region Lists Methods

            //List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //numbers = Enumerable.Range(1, 10).ToList();   //that incialize range of numbers and put it in list
            //numbers.Insert(0, 100);

            //int index = numbers.BinarySearch(4);
            //Console.WriteLine(index);   //4

            //int index1 = numbers.BinarySearch(11);
            //Console.WriteLine(index1);  //-12

            //numbers.Clear();    //clear all values in count but left capacity as it is
            //Console.WriteLine($"Count : {numbers.Count} , Capicity : {numbers.Capacity}");  //Count : 0 , Capicity : 16

            //int[] arr = new int[10];
            //numbers.CopyTo(arr);    //copy list inside array and it must be similar in size

            //int[] arr2 = new int[15];   //0 0 1 2 3 4 5 6 7 8 9 10 0 0 0
            //numbers.CopyTo(arr2, 2);    //that mean it will start from index 2 and put value and cont with zero

            //int[] arr3 = new int[15];   //2 means it will start from index 2 of list and 3 mean it will start from arr3 number 3
            //numbers.CopyTo(2, arr3, 3, 8);  // 0 0 0 3 4 5 6 7 8 9 10 0 0 0 0

            //numbers.EnsureCapacity(20); //it double capacity if ensurecapacity number is more than real capacity
            //Console.WriteLine($"Count : {numbers.Count} , Capicity : {numbers.Capacity}");  //Count : 10 , Capicity : 32

            //Console.WriteLine(numbers.IndexOf(2)); //search about value 2 and return number of index if found else return -1

            //Console.WriteLine(numbers.IndexOf(6, 0, 3));    //return -1 due to range from 0 and 3 not contain 6

            //Console.WriteLine(numbers.LastIndexOf(3)); //search from last

            //List<string> names = new List<string>() { "ahmed", "aya", "omar", "heba" };
            //names.Sort();
            //int index2 = names.BinarySearch("heba");
            //Console.WriteLine(index2); 
            #endregion

            #region LinkedList

            //LinkedList<int> linkedlist = new LinkedList<int>();
            //Console.WriteLine($"Count : {linkedlist.Count}");  //Count : 0

            //linkedlist.AddFirst(1);
            //linkedlist.AddLast(3);
            //LinkedListNode<int> node = linkedlist.Find(1); //return node that have value 1
            //linkedlist.AddAfter(node, 2);
            //linkedlist.AddBefore(linkedlist.Last, 4);
            //Console.WriteLine($"Count : {linkedlist.Count}");

            #endregion

            #region Array VS List VS LinkedList VS ArrayList
            //if Heterogeneous then we will use ArrayList
            //if Homogeneous then we will see if this Fixed lenght or Dynamic Length
            //if Fixed Length then we will use Array
            //if Dynamic Length List OR LinkedList
            //if you want to Retrive data then you will used List
            //if you want to Add Data then you will used LinkedList
            #endregion

            #region Stack
            ////First in Last out || Last in First out
            //Stack<int> stack = new Stack<int>();

            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //Console.WriteLine(stack.Peek()); //3   //return element in top wihtout removing

            //stack.Pop();    //remove from peek or remove last value enter
            //Console.WriteLine(stack.Peek()); //2

            //Console.WriteLine(stack.TryPeek(out int lastpeek));
            //stack.TryPop(out int lastNumber); //try to pop if list is empty then return 0 else remove last value
            #endregion

            #region Queue
            ////First in first out || First out first In
            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);

            //queue.Dequeue(); //return element at start then remove it
            //queue.TryDequeue(out int firstnumber);
            //queue.Peek();   //return elemetn at start without remove it
            //queue.TryPeek(out int secondnumber);
            #endregion

            #region Non-Generic HashTable

            //Hashtable phonebook = new Hashtable();
            //phonebook.Add("Ahmed", 123);
            ////key is unquie

            ////string overide on getHashCode and generate hashcode based on content not address
            //string name01 = "Ahmed";
            //Console.WriteLine(name01.GetHashCode());
            //string name02 = "Ahmed";
            //Console.WriteLine(name02.GetHashCode());

            //Console.WriteLine(name01.Equals(name02)); //compare address with address if class 

            //int x = 10; //int overide in hashcode based on value not address
            //int y = 10;
            //Console.WriteLine(x.GetHashCode());
            //Console.WriteLine(y.GetHashCode());
            //Console.WriteLine(x.Equals(y));
            #endregion

            #region Generic HashTable[Dictonary]

            //Dictionary<string, int> phoneBook = new Dictionary<string, int>();
            //phoneBook.Add("Ahmed", 123);
            //Add O(1)
            //Retrieve Data O(1)
            //phoneBook.Add("Ahmed", 123);    //invalid

            //if (!phoneBook.ContainsKey("Ahmed"))
            //    phoneBook.Add("Ahmed", 456);
            //else
            //    phoneBook["Ahmed"] = 456;   //update

            ////phoneBook.TryAdd();

            //if (!phoneBook.TryAdd("Ahmed", 123))
            //    phoneBook["Ahmed"] = 456;

            //phoneBook.TryGetValue("Ahmed", out int number);
            //phoneBook.TryAdd("Maha", 999);
            //phoneBook.TryAdd("omar", 555);
            //foreach (KeyValuePair<string,int> item in phoneBook)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value);
            //}

            //Dictionary<int, int[]> keyValuePairs = new Dictionary<int, int[]>();
            #endregion

            #region SortedDictionary - SortedList
            ////by default sorted assending order
            //SortedDictionary<string, int> sortedPhoneBook = new SortedDictionary<string, int>();
            //sortedPhoneBook.TryAdd("Ahmed", 123);
            //sortedPhoneBook.TryAdd("Zyad", 123);
            //sortedPhoneBook.TryAdd("Mona", 123);
            //sortedPhoneBook.TryAdd("Aya", 123);

            //foreach (var phone in sortedPhoneBook)
            //{
            //    Console.WriteLine($"{phone.Key} :: {phone.Value}");
            //}

            //sortedDictionary take O(log n) time to insert and remove items,
            //while sortedList take O(n) for the same operation, then sortedDictionary is better here

            //but in reterive data sortedList is better o(1)

            //sortedList better from sortedDictionary from memory
            //cause sortedDictionary based in binarytree
            #endregion

            #region HashSet

            //HashSet<int> numbers = new HashSet<int>();
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);

            //numbers.Add(1);
            //foreach (int item in numbers)
            //{
            //    Console.WriteLine(item);
            //}

            ////every object here have diffirent HashCode then it will add all to solve it we need to override to getHashCode
            ////after edit and make override to gethashCode and Equal then he compare with data not address
            //HashSet<Movie> movies = new HashSet<Movie>();
            //movies.Add(new Movie() { Id = 100, Title = "Bank Elhaz", Price = 120 });
            //movies.Add(new Movie() { Id = 120, Title = "Avatar", Price = 130 });
            //movies.Add(new Movie() { Id = 140, Title = "1000 mbrouk", Price = 110 });
            //movies.Add(new Movie() { Id = 140, Title = "1000 mbrouk", Price = 110 });

            //foreach (var item in movies)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #endregion

            #region Part 2

            #region question 1
            //1.You are given an ArrayList containing a sequence of elements. try to reverse the order of elements
            //in the ArrayList in-place(in the same arrayList) without using the built-in Reverse.Implement
            //a function that takes the ArrayList as input and modifies it to have the reversed order of elements.

            //ArrayList arrayList = new ArrayList() { 1, 2, 3, 4, 5, 6 };
            //Console.WriteLine("Orginal List");
            //foreach (var list in arrayList)
            //{
            //    Console.Write($"{list} ");
            //}

            //Reverse(arrayList);
            //Console.WriteLine("\nList after Reverced");
            //foreach (var list in arrayList)
            //{
            //    Console.Write($"{list} ");
            //}
            #endregion

            #region question 2
            //2.You are given a list of integers. Your task is to find and return a new list containing only
            //the even numbers from the given list.

            //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            //List<int> EvenList = findEvenNumber(list);
            //Console.WriteLine("Even Number List :");
            //foreach (var number in EvenList)
            //{
            //    Console.Write($"{number}  ");
            //}
            #endregion

            #region question 3
            //implement a custom list called FixedSizeList<T> with a predetermined capacity.This list should not allow
            //more elements than its capacity and should provide clear messages if one tries to exceed it or access
            //invalid indices.Requirements:
            //1.Create a generic class named FixedSizeList<T>
            //2.Implement a constructor that takes the fixed capacity of the list as a parameter.
            //3.Implement an Add method that adds an element to the list, but throws an exception if the list is already full.
            //4.Implement a Get method that retrieves an element at a specific index in the list but
            //throws an exception for invalid indices.

            //FixedSizeList<int> fixedSizeList = new FixedSizeList<int>(5);

            //try
            //{
            //    fixedSizeList.Add(1);
            //    fixedSizeList.Add(2);
            //    fixedSizeList.Add(3);
            //    fixedSizeList.Add(4);
            //    fixedSizeList.Add(5);

            //    //fixedSizeList.Add(6);

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine($"Index : {i} : {fixedSizeList.Get(i)}");
            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}
            #endregion

            #region question 4
            //4.Given a string, find the first non - repeated character in it and return its index.
            //If there is no such character, return -1.Hint you can use dictionary

            //Console.Write("Please Enter string: ");
            //string? input = Console.ReadLine();
            //int index = FirstNonRepeatedCharacter(input);

            //if (index != -1)
            //    Console.WriteLine($"The index of the first non-repeated character in \"{input}\" is: {index}");
            //else
            //    Console.WriteLine("No non-repeated character found in the string.");
            #endregion
            #endregion
        }
    }
}
