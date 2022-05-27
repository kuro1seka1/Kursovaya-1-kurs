
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class ArrayClass2D
{
    const int MAX = 1000;
    const string path = "/home/kura1/codeprojects/Test1/CharArray/SaveResult.txt";
    const string path2 = "/home/kura1/codeprojects/Test1/CharArray/FromFile.txt";
    static string readingFromFile(string path2)
    {
            string text = "";
        try
            {
        using( StreamReader sr = new StreamReader(path2))
        {
           while (true)
           {
               string? temp = sr.ReadLine();
               if (temp == null) break;
               text += temp;
           }
        }
        
            }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return text;
    } 

    static bool cheakingIsPrime(string trimed)
    {
        int x = trimed.Length;
                bool  is_prime = true;
                    for ( int divisor = 2;divisor * divisor <= x;++divisor)
                        if (x%divisor==0)
                            is_prime = false;
                             if (is_prime)
                                {
                                return true;
                                }
                             else
                            {
                             return false;
                            }
    }
      static void outputArray2(string path,int n, int m, char[,]a){
        try{
             using  StreamWriter sw = new StreamWriter (path);{
                for (int i = 0; i < m; i++) 
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write( "{0,3}",a[i,j]);
                    }
                    sw.Write("\n");
                }
            
            }
        } 
        catch(Exception ex)
        {
            Console.WriteLine ("Expet"  + ex.Message);
        }
    }
    static void outputArray(string path,int n, int m, char[,]a){
        try{
             using  StreamWriter sw = new StreamWriter (path);{
                for (int i = 0; i < m; i++) 
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write( "{0,3}",a[i,j]);
                    }
                    sw.Write("\n");
                }
            
            }
        } 
        catch(Exception ex)
        {
            Console.WriteLine ("Exepet"  + ex.Message);
        }
    }

    
    static void Print2DArray(int m, int n,char[] arr,char[,] a)
    {
        int count  = 0;
        int k = 0, l = 0;
        while (k < m && l < n) {
            
            for (int i = l; i < n; ++i) {
                a[k,i] = arr [count++];
            }
            k++;
            
            for (int i = k; i < m; ++i) {
                a[i,n - 1] = arr [count++];
            }
            n--;
            
            if (k < m) {
                for (int i = n - 1; i >= l; --i) {
                    a[m - 1,i] = arr [count++];
                }
                m--;
            }
            
            if (l < n) {
                for (int i = m - 1; i >= k; --i) {
                    a[i,l] = arr [count++];
                }
                l++;
            }
            
        }
    }
        static void Main()
        {
        Console.WriteLine("Выберите вариант:");
            string? line = Console.ReadLine() ;
            Console.Clear();
            int m = 0;
            int n = 0;
            if (line == "1")
            {  
                string text = readingFromFile(path2); 
                string? trimed = String.Concat(text.Where (c=> !Char.IsWhiteSpace(c)));
                char [] arr = trimed.ToCharArray();
                char [,] a = new char [MAX,MAX];
                if (cheakingIsPrime(trimed) == false)
                {
                    for( int i  = 10; i > 1; i--)
                        {
                            if(trimed.Length%i!=0)
                            continue;
                                if (trimed.Length%i == 0)
                                    n = trimed.Length / i;
                                    m = i;
                                    break;
                        }     
                    Print2DArray(m,n,arr,a);
                    outputArray2(path,n,m,a);
                    Console.WriteLine($"File saved in {path}");
                    Console.ReadKey();
                    
                }
            else if(cheakingIsPrime(trimed) == true)
                {
                Console.WriteLine("Число символов к сожалению равно простому числу ,рекомендуем либо добавить один символ , либо убрать");
                }
            }
            // ветвление - чтение из файла или ввод теста
            if(line == "2"){
            
            Console.WriteLine ("Введите текст сообщения,которое хотете зашифровать");
            string? s  = Console.ReadLine();
            Console.Clear();
            string? trimed = String.Concat(s.Where (c=> !Char.IsWhiteSpace(c)));
            char [] arr = trimed.ToCharArray();
            char [,] a = new char [MAX,MAX];

            if (cheakingIsPrime(trimed) == false)
            {
                for( int i  = 10; i > 1; i--)
                    {
                        if(trimed.Length%i!=0)
                        continue;
                            if (trimed.Length%i == 0)
                                n = trimed.Length / i;
                                m = i;
                                break;
                    }     
                    Print2DArray(m,n,arr,a);
                    outputArray(path,n,m,a);
                    Console.WriteLine($"File saved in {path}");
                    Console.ReadKey();
                    
            }
            else if(cheakingIsPrime(trimed) == true)
            {
            Console.WriteLine("Число символов к сожалению равно простому числу ,рекомендуем либо добавить один символ , либо убрать");
            }
        }
            
    }   
}