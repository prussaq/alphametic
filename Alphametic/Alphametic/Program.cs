#define TEST

using System;
using System.IO;

namespace Temp
{
    class Temp
    {
        static void Main(string[] args)
        {
            string path = @"D:\OneDrive\Projects\Alphametic\Alphametic\Dic\";
            string file = "sorted_dic8000en_stringNotation.txt";

            string[] dic = File.ReadAllLines(path + file);

#if TEST
            test_Word.Run(dic);
#endif

            Console.ReadKey();
        }
    }

    public class Word
    {
        //*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*//
        //* Sergey A. Lazarev  Kaliningrad, 2017 *//
        //+-+-+-+-+-+-+-+-+-+-++-+-+-+-+-+-+-+-+-//

        public const int NUM_SYS = 27;
        public const int MAX_WORD_LEN = 19;
        //---------------------------------
        //

        // ALPHABETIC PART
        //-----------------------------------
        public static decimal ToNum(char chr)
        {
            switch (chr)
            {
                case '\0':
                    return 0;
                case 'a':
                    return 1;
                case 'b':
                    return 2;
                case 'c':
                    return 3;
                case 'd':
                    return 4;
                case 'e':
                    return 5;
                case 'f':
                    return 6;
                case 'g':
                    return 7;
                case 'h':
                    return 8;
                case 'i':
                    return 9;
                case 'j':
                    return 10;
                case 'k':
                    return 11;
                case 'l':
                    return 12;
                case 'm':
                    return 13;
                case 'n':
                    return 14;
                case 'o':
                    return 15;
                case 'p':
                    return 16;
                case 'q':
                    return 17;
                case 'r':
                    return 18;
                case 's':
                    return 19;
                case 't':
                    return 20;
                case 'u':
                    return 21;
                case 'v':
                    return 22;
                case 'w':
                    return 23;
                case 'x':
                    return 24;
                case 'y':
                    return 25;
                case 'z':
                    return 26;
                default:
                    return 0;
            }
        }

        public static char ToChar(decimal num)
        {
            switch ((int)num)
            {
                case 0:
                    return '\0';
                case 1:
                    return 'a';
                case 2:
                    return 'b';
                case 3:
                    return 'c';
                case 4:
                    return 'd';
                case 5:
                    return 'e';
                case 6:
                    return 'f';
                case 7:
                    return 'g';
                case 8:
                    return 'h';
                case 9:
                    return 'i';
                case 10:
                    return 'j';
                case 11:
                    return 'k';
                case 12:
                    return 'l';
                case 13:
                    return 'm';
                case 14:
                    return 'n';
                case 15:
                    return 'o';
                case 16:
                    return 'p';
                case 17:
                    return 'q';
                case 18:
                    return 'r';
                case 19:
                    return 's';
                case 20:
                    return 't';
                case 21:
                    return 'u';
                case 22:
                    return 'v';
                case 23:
                    return 'w';
                case 24:
                    return 'x';
                case 25:
                    return 'y';
                case 26:
                    return 'z';
                default:
                    return '\0';
            }
        }
        //------------------------------------

        // CONVERSION
        //------------------------------------------------------------------
        public static decimal ToWord(string str)
        {
            if (str.Length == 0 || str.Length > MAX_WORD_LEN) return -1;
            //
            //-----------------------------

            decimal word = 0, k = 1;
            //---------------------
            //
            for (int i = 0; i < str.Length; i++, k *= NUM_SYS)
            {
                word += ToNum(str[i]) * k;
            }
            return word;
        }

        public static string ToString(decimal word)
        {
            int len = GetLen(word);
            char[] chrs = new char[len];

            for (int i = 0; i < len; i++)
            {
                chrs[i] = ToChar(word % NUM_SYS);
                word = Math.Truncate(word / NUM_SYS);
            }
            return new string(chrs);
        }
        //---------------------------------------------------------------------

        //  WORD OPERATIONS
        //-----------------------------------------------------
        public static decimal GetRight(decimal word, int index)
        {
            if (index < 0 || index >= GetLen(word)) return -1;
            //
            // Throw: IndexOutOfRangeException

            return Math.Truncate(word / pow(index));
            //
            // W = word(number), N = number system
            // O = output, i = index
            //------------------------------------
            // O = W / N^i
        }

        public static decimal GetLeft(decimal word, int index)
        {
            if (index < 0 || index >= GetLen(word)) return -1;
            //
            // Throw: IndexOutOfRangeException

            return word % pow(index + 1);
            //
            // W = word(number), N = number system
            // O = output, i = index
            //------------------------------------
            // O = W % N^i+1
        }

        public static decimal GetByIndex(decimal word, int index, int count)
        {
            if (index < 0 || index >= GetLen(word)) return -1;
            if (count < 1 || count > GetLen(word) - index) return -1;
            //
            // Throw: ArgumentOutOfRangeException

            return Math.Truncate(word % pow(index + count)) / pow(index);
            //
            // W = word(number), N = number system
            // O = output, i = index, c = count
            //------------------------------------
            // O = W % N^i+c / N^i
        }
        //
        //
        public static decimal InsertRight(decimal word, decimal part)
        {
            if (GetLen(word) + GetLen(part) > MAX_WORD_LEN) return -1;
            //
            // Throw: OverflowException

            word += part * pow(GetLen(word));

            return word;
            //
            // W = word(number), P = part(number), N = number system
            // O = output, l = length
            //------------------------------------------------------
            // O = W + P * N^Wl
        }

        public static decimal InsertLeft(decimal word, decimal part)
        {
            if (GetLen(word) + GetLen(part) > MAX_WORD_LEN) return -1;
            //
            // Throw: OverflowException

            word = word * pow(GetLen(part)) + part;

            return word;
            //
            // W = word(number), P = part(number), N = number system
            // O = output, l = length
            //------------------------------------------------------
            // O = W * N^Pl + P
        }

        public static decimal Insert(decimal word, decimal part, int index)
        {
            if (index < 0 || index >= GetLen(word) || GetLen(word) + GetLen(part) > MAX_WORD_LEN) return -1;
            //
            // Throw: IndexOutOfRangeException, OverflowException

            decimal L = word % pow(index);

            return (Math.Truncate(word / pow(index)) * pow(GetLen(part)) + part) * pow(GetLen(L)) + L;
            //
            // W = word(number), P = part(number), N = number system
            // O = output, l = length, i = index,
            //-------------------------------------------------------
            // R = W / N^i
            // L = W % N^i
            // O = (R * N^Pl + P) * N^Ll + L
        }
        //
        //
        public static decimal Replace(decimal word, decimal part, int index)
        {
            if (index < 0 || index >= GetLen(word) || GetLen(part) > GetLen(word) - index) return -1;
            //
            // Throw: ArgumentOutOfRangeException

            word += (part - Math.Truncate(word / pow(index)) % pow(GetLen(part))) * pow(index);

            return word;
            //
            // W = word(number), P = part(number), N = number system
            // O = output, l = length, i = index
            //------------------------------------------------------
            // Wt = (W / N^i) % N^Pl
            // O = W + (P - Wt) * N^i
        }

        public static decimal Remove(decimal word, int index, int count)
        {
            if (index < 0 || index >= GetLen(word)) return -1;
            if (count < 0 || count > GetLen(word) - index) return -1;
            //
            // Throw: ArgumentOutOfRangeException

            decimal L = word % pow(index);

            return Math.Truncate(word / pow(index + count)) * pow(GetLen(L)) + L;
            //
            // W = word(number), P = part(number), N = number system
            // O = output, l = length, i = index, c = count
            //-------------------------------------------------------
            // L = W % N^i
            // O = (W / N^i+c) * N^Ll + L
        }
        //--------------------------------------------------------------

        // OUTER TOOLS
        //------------------------------------
        public static int GetLen(decimal word)
        {
            int len = 0;
            //----------
            //
            while (word >= 1)
            {
                len++;
                word = Math.Truncate(word / NUM_SYS);
            }

            return len;
        }
        //------------------------------------

        // INNER TOOLS
        //---------------------------------
        private static decimal pow(int exp)
        {
            decimal pwr = 1;
            //--------------
            //
            while (exp-- > 0)
            {
                pwr *= NUM_SYS;
            }

            return pwr;
        }
        //---------------------------------

        // SEARCH TOOLS
        //-------------------------------------------------------
        public static int FuzBinSearch(decimal val, string[] dic)
        {
            if (dic.Length == 0) return -1;
            if (dic.Length == 1) return 0;
            //
            //----------------------------

            int idx = 0, f = 0, t = dic.Length - 1;
            //-------------------------------------
            //
            while (true)
            {
                idx = f + (t - f) / 2;
                if (val < ToWord(dic[idx]))
                {
                    t = idx;
                    if (1 + f == t) return --idx;
                }
                else if (val > ToWord(dic[idx]))
                {
                    f = idx;
                    if (1 + f == t) return ++idx;
                }
                else return idx;
            }
            //
            // ---FUZZY BINARY SEARCH---
            // Return a right value if an array contains the right value
            // Otherwise return whether left or right closest neighbour
            //
        }
        //-------------------------------------------------------
    }

    class test_Word
    {
        static string[] dic = { };
        //------------------------
        //
        public static void Run(string[] sortedDic)
        {
            dic = sortedDic;

            testMaxWordLength();
            testStringWordString();
            testBinSearch();
            testGetLength();
            testGetByIndex();
            testGetRight();
            testGetLeft();
            testInsertRight();
            testInsertLeft();
            testInsert();
            testReplace();
            testRemove();
        }

        // TEST MAX WORD LENGTH
        //
        private static void testMaxWordLength()
        {
            decimal type = 1;
            // Type container for words
            //
            int len = 0;
            //---------------
            //
            while (true)
            {
                try
                {
                    checked
                    {
                        type *= Word.NUM_SYS;
                        len++;
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }

            Console.WriteLine("TEST: MAX WORD LENGTH IS [ {0} ]\n", len);
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST STRING -> WORD -> STRING
        //
        private static void testStringWordString()
        {
            for (int i = 0; i < dic.Length; i++)
            {
                decimal word = Word.ToWord(dic[i]);
                string stringFromWord = Word.ToString(word);
                if (stringFromWord != dic[i])
                {
                    Console.WriteLine("[ FAILED ] - TEST: STRING -> WORD -> STRING");
                    Console.WriteLine("\t-> [{0}] != [{1}] - [{2}] <-\n", dic[i], stringFromWord, word);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: STRING -> WORD -> STRING\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST BINSEARCH DIC[I] == DIC[FOUND IDX]
        //
        private static void testBinSearch()
        {
            for (int i = 0; i < dic.Length; i++)
            {
                if (dic[i] != dic[Word.FuzBinSearch(Word.ToWord(dic[i]), dic)])
                {
                    Console.WriteLine("[ FAILED ] - TEST: BINSEARCH");
                    Console.WriteLine("{0} != {1}\n", dic[i], dic[Word.FuzBinSearch(Word.ToWord(dic[i]), dic)]);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: BINSEARCH\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST GET_LENGTH
        //
        private static void testGetLength()
        {
            string test = "";
            for (int i = 0; i <= Word.MAX_WORD_LEN; i++)
            {
                if (test.Length != Word.GetLen(Word.ToWord(test)))
                {
                    Console.WriteLine("[ FAILED ] - TEST: GET_LENGTH");
                    Console.WriteLine("-> {0}.Length = [{1}] == [{2}] = getLen({0}) <-\n", test, test.Length, Word.GetLen(Word.ToWord(test)));
                }
                test += "z";
            }
            Console.WriteLine("[ PASSED ] - TEST: GET_LENGTH\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST GET_BY_INDEX
        //
        private static void testGetByIndex()
        {
            for (int i = 0; i < dic.Length; i++)
            {
                decimal word = Word.ToWord(dic[i]);
                string str = dic[i];

                int lenFromWord = Word.GetLen(word);

                for (int k = 0; k < lenFromWord; k++)
                {
                    int idx = k;
                    char charFromString = str[idx];
                    char charFromWord = Word.ToChar(Word.GetByIndex(word, idx, 1));

                    if (charFromString != charFromWord)
                    {
                        Console.WriteLine("[ FAILED ] - TEST: GET_BY_INDEX");
                        Console.WriteLine("\t-> string[{0}]=[{1}] != [{2}]=word[{0}] - string: \"{3}\"  word: \"{4}\" <-\n",
                            idx, charFromString, charFromWord, str, Word.ToString(word));
                    }
                }
            }

            for (int i = 0; i < dic.Length; i++)
            {
                var rnd = new Random();
                decimal word = Word.ToWord(dic[i]);
                string str = dic[i];

                int lenFromWord = Word.GetLen(word);

                for (int k = 0; k < lenFromWord; k++)
                {
                    int idx = k;
                    int count = rnd.Next(lenFromWord - idx);
                    string SubFromString = str.Substring(idx, count);
                    string SubFromWord = Word.ToString(Word.GetByIndex(word, idx, count));

                    if (SubFromString != SubFromWord)
                    {
                        Console.WriteLine("[ FAILED ] - TEST: GET_BY_INDEX");
                        Console.WriteLine("\t-> string[{0}]=[{1}] != [{2}]=word[{0}] - string: \"{3}\"  word: \"{4}\" <-\n",
                            idx, SubFromString, SubFromWord, str, Word.ToString(word));
                    }
                }
            }

            Console.WriteLine("[ PASSED ] - TEST: GET_BY_INDEX\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST GET_RIGHT
        //
        private static void testGetRight()
        {
            var rnd = new Random();
            //---------------------
            //
            for (int i = 0; i < dic.Length; i++)
            {
                decimal word = Word.ToWord(dic[i]);
                int len = Word.GetLen(word);
                int idx = rnd.Next(len);

                decimal word_rhs = Word.GetRight(word, idx);
                string string_rhs = dic[i].Substring(idx);

                if (string_rhs != Word.ToString(word_rhs))
                {
                    Console.WriteLine("[ FAILED ] - TEST: GET_RIGHT");
                    Console.WriteLine("\t-> {0} != {1} - {2} <-\n", string_rhs, Word.ToString(word_rhs), dic[i]);
                }
            }

            Console.WriteLine("[ PASSED ] - TEST: GET_RIGHT\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST GET_LEFT
        //
        private static void testGetLeft()
        {
            var rnd = new Random();
            //---------------------
            //
            for (int i = 0; i < dic.Length; i++)
            {
                decimal word = Word.ToWord(dic[i]);
                int len = Word.GetLen(word);
                int idx = rnd.Next(len);

                decimal word_lhs = Word.GetLeft(word, idx);
                string string_lhs = dic[i].Substring(0, idx + 1);

                if (string_lhs != Word.ToString(word_lhs))
                {
                    Console.WriteLine("[ FAILED ] - TEST: GET_LEFT");
                    Console.WriteLine("\t-> {0} != {1} - {2} <-\n", string_lhs, Word.ToString(word_lhs), dic[i]);
                }
            }

            Console.WriteLine("[ PASSED ] - TEST: GET_LEFT\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST INSERT_RIGHT
        //
        private static void testInsertRight()
        {
            for (int i = 0; dic[i].Length < 8; i++)
            {
                string str = dic[i] + dic[i + 1];
                decimal word = Word.ToWord(dic[i]);
                decimal part = Word.ToWord(dic[i + 1]);
                decimal res = Word.InsertRight(word, part);

                if (str != Word.ToString(res))
                {
                    Console.WriteLine("[ FAILED ] - TEST: INSERT_RIGHT");
                    Console.WriteLine("\t-> [{0}] != [{1}] -  [{2}] + [{3}] <-\n", str, Word.ToString(res), dic[i], dic[i + 1]);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: INSERT_RIGHT\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST INSERT_LEFT
        //
        private static void testInsertLeft()
        {
            for (int i = 0; dic[i].Length < 8; i++)
            {
                string str = dic[i + 1] + dic[i];
                decimal word = Word.ToWord(dic[i]);
                decimal part = Word.ToWord(dic[i + 1]);
                decimal res = Word.InsertLeft(word, part);

                if (str != Word.ToString(res))
                {
                    Console.WriteLine("[ FAILED ] - TEST: INSERT_LEFT");
                    Console.WriteLine("\t-> [{0}] != [{1}] -  [{2}] + [{3}] <-\n", str, Word.ToString(res), dic[i + 1], dic[i]);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: INSERT_LEFT\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST INSERT
        //
        private static void testInsert()
        {
            string str = "abc";
            string spart = "zz";
            decimal word = Word.ToWord(str);
            decimal npart = Word.ToWord(spart);

            for (int i = 0; i < str.Length; i++)
            {
                string temp = str.Insert(i, spart);
                decimal ntemp = Word.Insert(word, npart, i);

                if (temp != Word.ToString(ntemp))
                {
                    Console.WriteLine("[ FAILED ] - TEST: INSERT");
                    Console.WriteLine("\t-> [{0}] != [{1}] - index [{2}], part: [{3}] <-\n", temp, Word.ToString(word), i, spart);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: INSERT\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST REPLACE
        //
        private static void testReplace()
        {
            string[] strings =
            {
                "aaaa", "zzaa", "abaa", "abab", "cloak", "zzoak", "trifle", "trifzz", "sergeant",
                "seabcdnt", "distrib", "zzzzzzz", "characteristic", "charaateristic"
            };
            string[] replacers =
            {
                "0", "zz", "3", "b", "0", "zz", "4", "zz", "2", "abcd", "0", "zzzzzzz", "5", "a"
            };
            //---------------------------------------------------------------------------------
            //
            for (int i = 0; i < strings.Length - 1; i += 2)
            {
                string input = strings[i];
                string output = strings[i + 1];
                string replacer = replacers[i + 1];
                int index = int.Parse(replacers[i]);

                decimal nword = Word.ToWord(input);
                decimal nreplcr = Word.ToWord(replacer);
                decimal res = Word.Replace(nword, nreplcr, index);
                string sres = Word.ToString(res);

                if (output != Word.ToString(res))
                {
                    Console.WriteLine("[ FAILED ] - TEST: REPLACE");
                    Console.WriteLine("{0} != {1} - {2}\n", output, Word.ToString(res), input);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: REPLACE\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }

        // TEST REMOVE
        //
        private static void testRemove()
        {
            string[] strings =
            {
                "abc", "ac", "abaa", "aaa", "cloak", "oak", "trifle", "trle", "sergeant",
                "se", "distrib", "distrib", "characteristic", "charateristic", "abc", "abc"
            };
            string[] removers =
            {
                "1", "1", "1", "1", "0", "2", "2", "2", "2", "6", "6", "0", "5", "1", "1", "0"
            };
            //--------------------------------------------------------------------
            //
            for (int i = 0; i < strings.Length - 1; i += 2)
            {
                string input = strings[i];
                string output = strings[i + 1];
                int count = int.Parse(removers[i + 1]);
                int index = int.Parse(removers[i]);

                decimal nword = Word.ToWord(input);
                decimal res = Word.Remove(nword, index, count);

                if (output != Word.ToString(res))
                {
                    Console.WriteLine("[ FAILED ] - TEST: REMOVE");
                    Console.WriteLine("{0} != {1} - {2}\n", output, Word.ToString(res), input);
                }
            }
            Console.WriteLine("[ PASSED ] - TEST: REMOVE\n");
            Console.WriteLine(new string('-', 60) + "\n");
        }
    }
}
