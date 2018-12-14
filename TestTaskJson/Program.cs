using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace TestTaskJson
{
    class Program 
    {
        private static int binarySearch(int[] arr, int key)
        {
            int result = -1;

            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {

                int mid = left + (right - left) / 2;

                if (arr[mid] == key)
                {
                    result = arr[mid];
                    break;
                }
                else if (key < arr[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return result;
        }

        public static List<int> FindUnique(int[] ArrayForFind, int[] ArrayForElement)
        {
            List<int> UniqueNumbers = new List<int>();

            int resultBinarySearch;
            for (int i = 0; i < ArrayForElement.Length; i++)
            {
                resultBinarySearch = binarySearch(ArrayForFind, ArrayForElement[i]);
                if ((resultBinarySearch == -1) || (ArrayForElement[i] == UniqueNumbers.FirstOrDefault(number => number == ArrayForElement[i])))
                {
                    continue;
                }
                else
                {
                    UniqueNumbers.Add(ArrayForElement[i]);
                }
            }

            return UniqueNumbers;
        }

        public static List<int> FindUniqueNotEven(int[] ArrayForFind, int [] ArrayForElement)
        {
            List<int> UniqueNumbers = new List<int>();

            int resultBinarySearch;
            for (int i = 0; i < ArrayForElement.Length; i++)
            {
                if(ArrayForElement[i] % 2 != 0){
                    resultBinarySearch = binarySearch(ArrayForFind, ArrayForElement[i]);
                    if ((resultBinarySearch == -1) || (ArrayForElement[i] == UniqueNumbers.FirstOrDefault(number => number == ArrayForElement[i])))
                    {
                        continue;
                    }
                    else
                    {
                        UniqueNumbers.Add(ArrayForElement[i]);
                    }
                }
                else
                {
                    continue;
                }
               
            }
            return UniqueNumbers;
        }
        public static int SumEvenNumber(int[] ArrayForFind, int[] ArrayForElement)
        {
            List<int> RepeatNumbers = new List<int>();
            int resultBinarySearch;
            for (int i = 0; i < ArrayForElement.Length; i++)
            {
                if (ArrayForElement[i] % 2 == 0)
                {
                    resultBinarySearch = binarySearch(ArrayForFind, ArrayForElement[i]);
                    if (!((resultBinarySearch == -1) || (ArrayForElement[i] == RepeatNumbers.FirstOrDefault(number => number == ArrayForElement[i]))))
                    {
                        continue;
                    }
                    else
                    {
                        RepeatNumbers.Add(ArrayForElement[i]);
                    }
                }
                else
                {
                    continue;
                }

            }
            return RepeatNumbers.Sum();
        }

        public static void Display(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Array[{0}] = {1}",i,arr[i]);
            }
        }

        static void Main(string[] args)
        {
            var readJson = JsonConvert.DeserializeObject<MyClass>(File.ReadAllText("document.json"));

            Console.WriteLine();
            Console.WriteLine("Числа первого массива");
            Display(readJson.firstArray);
            Console.WriteLine();
            Console.WriteLine("Числа второго массива");
            Display(readJson.secondArray);
            Console.WriteLine("-----------------------------------------");

            Array.Sort(readJson.firstArray);
            Array.Sort(readJson.secondArray);
            
            List<int> firstUnique =  FindUnique(readJson.firstArray,readJson.secondArray);
            for(int i = 0; i < firstUnique.Count; i++)
            {
                Console.WriteLine("Уникальные числа с обох массивов => {0}", firstUnique[i]);
            }
           
            List<int> UniqueNotEven = FindUniqueNotEven(readJson.firstArray, readJson.secondArray);
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < UniqueNotEven.Count; i++)
            {
                Console.WriteLine("Уникальное нечетное число с первого массива => {0}", UniqueNotEven[i]);
            }
            Console.WriteLine("-----------------------------------------");
            int count = 0;
            for (int i = 0; i < UniqueNotEven.Count; i++)
            {
                for(int j = 0; j < readJson.secondArray.Length; j++)
                {
                    if (UniqueNotEven[i] == readJson.secondArray[j])
                    {
                        count++;
                    }
                }
                Console.WriteLine("Число {0} встречается {1} раз", UniqueNotEven[i], count);
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Сумма = {0}", SumEvenNumber(readJson.secondArray, readJson.firstArray));
            Console.ReadKey();
        }
    }
}
