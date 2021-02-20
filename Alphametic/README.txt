# Alphametic
S.A. Lazarev, Kaliningrad, 2017
prussaq@gmail.com
https://www.codeproject.com/Articles/1174033/Alphabet-Arithmetic-and-Fuzzy-Binary-Search-Words


#Alphabet arithmetic and fuzzy binary search words-numbers

Alphabet arithmetic means any to convert of any alphabets in an number system equals number of characters plus one and application operations: addition, subtraction, attaching, deletion, insertion, substitution, separation and as a consequence, the possibility of a binary search.

As an example, take the Latin alphabet a - z, 26 characters and as Zero \0 - a null character, replace the '\0' = 0, 'a' = 1 ... 'z' = 26. It will turn a 28 number system. Now any letter or word is unique to the set of all possible combinations of letters in a given system. What allows us to compare on more or less and equal. Sort and use binary search. As well as producing the increment and decrement of words.

If have not Zero. Then there won't be situations such as: abc\0 == abc. But there are other problems, the operations based on the separation of the formulas do not work if the last character in the place of separation, the result will be an extra unit, the problem of the number system. You can enter a factor, but it is necessary to count, this long Float and still works unstably. In general, I was not able to achieve normal results, but to subdivide a subtraction residue. And this is essentially character-oriented analysis of the word, save the results, work operations on them and build that are not so nice.

And if you have zero, all simply as with numbers. And the operations based on the division of work according to the formulas for any number system. As in other any other. But there are some features: conversion word is left to save a string index notation. Consequently all the right null characters are removed, as is the case with numbers, just the opposite:
1 == 0001, respectively, for the letters: a == a\0\0. Also, if these characters in the word will lead to their loss during surgery.
Possible operations: addition and subtraction are trivial:
a + a = b; z + a = \0a; a - a = \0; b - a = a;
Of course, the mathematical multiplication or division with respect to the words does not make sense, you need to split into right and left part of or attach to this or that part.

We get the following algorithmic formulas:
Over the number of operations are mirrored, to preserve the visual indexing left.

The division of the index (taking the left-hand side):         
L = W % N^i+1
where L = the result, W = word number, N = number system, i = index

The division with the remainder of the index (taking the right-hand side):
R = W / N^i
where R = result, W = word number, N = number system, i = index

Multiplication of words in part (inset right):
NW = W + P * N^Wl
where NW = result, W = word number, N = number system, P = the added part

Multiplication of the word for (insert left):
NW = W * N^Pl+P
where NW = result, W = word number, N = number system, P = the added part,
Pl = length of the added part, Wl = word length

Further components of the operation:

Replacing part of the index:
Wt = (W / N^i) % N^Pl
O = W + (P - Wt) * N^i
where NW = result, W = word number, N = number system, P = replacement part,
Pl = length of the replacement part, i = index

Insert part of the index:
L = W % N^i
NW = (R * N ^ Pl + P) * N^Ll+L
where NW = result, W = word number, N = number system, P = paste parts,
Pl = length of the inserted part, Ll = length L of the part, i = index

Removal of the number of the index:
L = W % N^i
NM = (W / N^i+c) * N^Ll+L
where NW = result, W = word number, N = number system, Ll = length L of the part,
i = index number of symbols = a

Taking part on the index:
NW = W % N^i+c / N^i
where the NW = result, the W = word number, N = number system, c = number, i = index
 
The division of an integer, if used fractional types, it is necessary to cut off the fractional part.
If there is a word or a part of the zero symbol, the results may be incorrect.

Of course the code necessary to check the length of the part, the index values and other checks.

Conversion

Translation string to a number:

      i=0, k=1
i < Sl  FOR   O += tonum(S[i]) * k
     i++, k*=N

Use the cycle where, O = output, N = number system, S = line, l = length, i = index,
tonum returns a number corresponding to the letter.

Translation of the following:

        i=0
i < len FOR char [i] = tochr (W % N); W / = N;
        i++
                 
To reverse the convert, create an array of char [len], where len = length of the word-number, W = word number, N = number system,
tochr = returns the character corresponding to the number.

Class with a set of methods and a small test on GitHub page
Alphametic

Fuzzy binary search words-numbers in a sorted array.

The sorting algorithm can be any naturally which sorted in order of numbers.
We translate text to a number and move it to the desired index.   

An example of the part of the array

scorn
adorn
thorn
mourn
begun
drawn
shown
blown
brown
crown
drown
frown
grown
marco
bingo
cargo
radio
hello
piano
photo
cheap
scrap
strap
sheep
sleep
creep
steep

Since the highest figure is on the right at the end of sorting can be, and vice versa, but then we must remember that the search term should be the same notation.

Word search returns the index or the index of one of the neighbor closest to the desired numerical way. Is it left or right, indeterminate result.
For example: looking for "pea" returns its index, change the word to "rea" return "sea" or "pea", as this section of the dictionary is:

oz
pea
sea
tea
aha

And the word "rea" does not contain, but numerically it is between pea - sea. You can check if the "sea" == dic [index] to return the value of the key, otherwise you can continue the search. Since they are ordered numerically, it turns on the length and the characters in them alphabetically. All possible combinations of the latest letter, lie above to \0\0a and following down zza.

But the words do not usually lie firmly, that is, in this case, the words in their range
Only eight:

pea
sea
tea
aha
via
ana
era
asa

You can write a loop that will go up to a certain word and return the available indexes and down. Of course all the words will be different amount, depending on the popularity of the letter. And if you add the letter, front, rear, or remove, the ranges will be very different. In this case, probably better to perform repetitive searches. And the search for a fixed number of possible errors.
In general, you need to experiment.
Average number of steps to search for a word in the dictionary to 8,000 words, was 12.

Disadvantages

The big problem - the limited word length because of the large numbers.
In C #, the size of decimal (128-bit), you can contain words not exceeding 19 characters, it is the boundary beyond which will overflow on this size of the alphabet, the translation in the numbers.
If you enter a full alphabet and other characters will be even less. The file is the longest word consists of 16 characters, of course it is not the longest in principle, but there are still components, and there are none. For the dictionary, you can take the highest figure to the flag of the word begins with a capital letter, which is slightly expand the range.

The file contains 8000 English words in lowercase and sorted.
