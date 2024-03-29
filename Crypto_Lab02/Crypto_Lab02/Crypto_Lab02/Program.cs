﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace Crypto_Lab02
{ 
    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            Shannon shannon = new Shannon();
            string pathBytes = "bytes.txt";
           // string path = "text.txt";
            string path = "text1.txt";//ru

            string text;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            { text = sr.ReadToEnd(); }
            //Console.WriteLine(text);
            string patternRU = @"[A-Za-z0-9\s+\W_]";
            string patternEN = @"[А-Яа-я0-9\s+\W_]";
            string patternBIN = @"\s+";
            string target = "";

            Regex regexRU = new Regex(patternRU, RegexOptions.IgnoreCase);
            Regex regexEN = new Regex(patternEN);
            Regex regexBIN = new Regex(patternBIN);

            string resultRU = regexRU.Replace(text, target);
            string resultEN = regexEN.Replace(text, target);
            string resultBIN = regexBIN.Replace(text, target);

            Console.WriteLine("RUS Энтропия по Шеннону фразы = " + shannon.ShannonEntropy(resultRU.ToLower()));
           // Console.WriteLine("ENG Энтропия по Шеннону фразы = " + shannon.ShannonEntropy(resultEN.ToLower()));

            //task 2
            StringBuilder builder = new StringBuilder();
            foreach(char a in resultBIN)            
                builder.Append(Convert.ToString(a, 2));

            using (StreamWriter sw = new StreamWriter(pathBytes, false, Encoding.Default))
            { sw.Write(builder); }
            Console.WriteLine("Binary Энторопия по Шенону = " + shannon.ShannonEntropy(builder.ToString()));

            //Console.WriteLine(text);
            //Console.WriteLine(builder.ToString());
            //Console.WriteLine(resultBIN.ToString());

            //task 3
            String myName = "Ermakov Kiril Alexandrovich";
            string patternName = @"\s+";
            Regex regexName = new Regex(patternName);
            string resulName = regexName.Replace(myName, target);
            double shann = shannon.ShannonEntropy(resultEN.ToLower());
            Console.WriteLine($"Количество информации в ФИО {shannon.AmountOfInformation(resulName, shann)}");
            Console.WriteLine(resulName);
            byte[] bytes = Encoding.ASCII.GetBytes(resulName);
            String ASCII = "";
            foreach (var b in bytes)
                ASCII += b;

            Console.WriteLine("ASCII: Кол-во инф-ции в ФИО " + shannon.AmountOfInformation(ASCII, shann));


            //task4
            //Эффективная энтропия = Шеннон - Условная энтропия
            Console.WriteLine("С условной вероятностью ошибки 0,1 " + shannon.AmountOfInformationWithMistake(shann, resulName, 0.9));
            Console.WriteLine("С условной вероятностью ошибки 0,5 " + shannon.AmountOfInformationWithMistake(shann, resulName, 0.5));
            Console.WriteLine("С условной вероятностью ошибки 1 " + shannon.AmountOfInformationWithMistake(shann, resulName, 1));

            Console.ReadLine();
        }
    }
}
