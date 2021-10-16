using System;
using System.Text;
using System.Collections.Generic;
//Создать консольное приложение, используя тип string (StringBuilder).Программа принимает строку. 
//По нажатию произвольной клавиши поочередно выделяет в тексте заданное слово.
//Ищет в ней глаголы и возвращает в консоль строку без глаголов.
//Найти во входной строке слова с одинаковым основанием
//(совпадающие части двух и более слов, 3 буквы и более) и разбить эти слова на 3 части


namespace TuskStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                StringBuilder Text = new StringBuilder("Вам не стоит доверять и одалживать деньги не знакомым" +
                    " и не проверенным людям, ведь они могут обманывать и не отдавать их обратно"); // Строка для поиска
                Console.WriteLine("Исходная строка:");
                Console.WriteLine(Text); // Вывод строки
                Console.WriteLine("Для поиска слова введите 1");
                Console.WriteLine("Для поиска и удаления глаголов введите 2:");
                Console.WriteLine("Исходная строка:");
                Console.WriteLine("Для выхода нажмите 9:");
                string check = Console.ReadLine();
                switch (check)
                {
                    case "1":
                        Console.WriteLine("Введите искомое слово");
                        string word = Console.ReadLine();
                        Search(Text, word);
                        Console.Clear();
                        break;
                    case "2":
                        Verb(Text);
                        Console.Clear();
                        break;
                    case "3":
                        Separation(Text);
                        Console.Clear();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Повторите попытку воода");
                        break;
                }
            }
            static void Search(StringBuilder TmpText, string word) // Метод для выделения веденного слова
            {
                int index = 0;
                while (TmpText.ToString().Contains(" " + word + " "))
                {
                    Console.SetCursorPosition(0, 1);
                    var a = TmpText.ToString().IndexOf(" " + word + " ", index) + 1; // Определение начала искомого слова
                    var b = TmpText.ToString().IndexOf(" " + word + " ", index) + (" " + word + " ").Length - 1; // Определения конца искомого слова
                    for (int i = 0; i < a; i++)
                        Console.Write(TmpText[i]); // Вывод текста до искомого слова
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    for (int i = a; i < b; i++) // Выведелние искомого слова
                        Console.Write(TmpText[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    index = b;
                    Console.ReadKey();
                    if (a == TmpText.ToString().LastIndexOf(" " + word + " ") + 1)
                        return;
                }
            }
            static void Verb(StringBuilder TmpText) // Метод для поиска глаголов
            {
                var verbs = new string[] { "ать ", "ять ", "ют " }; // Массив окончания
                var words = TmpText.ToString().Split(' '); // Разделение на массив слов
                for (int i = 0; i < words.Length; i++) // Проверка слова на глагол и удаление глаголов
                {
                    words[i] += " ";
                    for (int j = 0; j < verbs.Length; j++)
                        if (words[i].Contains(verbs[j]))
                            words[i] = words[i].Remove(0);
                }
                TmpText.Clear();
                foreach (var word in words) // Заполнение стрингбилдера
                {
                    TmpText.Append(word);
                }
                Console.WriteLine("Строка без глаголов: ");
                Console.WriteLine(TmpText);
                Console.ReadKey();
            }
            static void Separation(StringBuilder TmpText) // Метод для поиска глаголов
            {
                var words = TmpText.ToString().Split(' '); // Разделение на массив слов
                string found;
                for (int i = 0; i < words.Length; i++)
                    if (words[i].Length >= 3)
                    {
                        char[] symbol = words[i].ToCharArray(); // Разделение слова на символы
                        for (int j = 0; j < symbol.Length - 2; j++)
                        {
                            found = symbol[j].ToString() + symbol[j + 1].ToString() + symbol[j + 2].ToString(); // Добавление основания в список оснований
                            var count = 0;
                            for (int z = 0; z < words.Length; z++)
                            {
                                if (words[z].Contains(found))
                                    count++;
                                if (count >= 2)
                                    TmpText.Replace(found, "-" + found + "-");
                            }
                        }
                    }
                for (int i = 0; i < TmpText.Length - 1; i++)
                    TmpText.Replace("--", "-");
                Console.WriteLine(TmpText);
                Console.ReadKey();
            }
        }
    }
}
