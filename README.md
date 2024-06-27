# Solutions of the popular algorithm tasks

In this repository, possible solutions for whiteboard tasks which are likely to be asked on software development interviews:

- Given an array containing both positive and negative integers and required to find the sub-array
with the largest sum (O(N)).
- Given an array of size N in which every number is between 1 and N, determine if there are any
duplicates in it and what kind. You are allowed to destroy or modify the array if you like.
- Write a routine to draw a circle (x ** 2 + y ** 2 = r ** 2) without making use of any floating point
computations at all.
- Given only putchar (no sprintf, itoa, etc.) write a routine putlong that prints out an unsigned long
in decimal.
- Give a one-line expression to test whether a number is a power of 2 [No loops allowed - it's a
simple test.]
- Given an array of characters which form a sentence of words, give an efficient algorithm to reverse
the order of the words (not characters) in it.
- Reverse a linked list.
- Insert in a sorted list.
- Give a fast way to multiply a number by 7.
- Linked list manipulation: AddLast, AddAtIndex, Delete elements.
- First some definitions for this problem: a) An ASCII character is one byte long and the most
significant bit in the byte is always '0'. b) A Kanji character is two bytes long. The only characteristic of a
Kanji character is that in its first byte the most significant bit is '1'. Now you are given an array of the
characters (both ASCII and Kanji) and, an index into the array. The index points to the start of some
character. Now you need to write a function to do a backspace (i.e. delete the character before the given
index).
- Delete an element from a doubly linked list.
- Write a function to find the depth of a binary tree.
- Given two strings S1 and S2. Delete from S2 all those characters which occur in S1 also and finally
create a clean S2 with the relevant characters deleted.
- Write a small lexical analyzer - interviewer gave tokens. Expressions like "a*b" etc.
- Write a routine that prints out a 2-D array in spiral order.
- Write an efficient algorithm to shuffle a pack of cards this one was a feedback process until we
came up with one with no extra storage.
- Given a sequence of characters. How will you convert the lower case characters to upper case
characters. (Try using bit vector).
- Write, efficient code for extracting unique elements from a sorted list of array. e.g. (1, 1, 3, 3, 3, 5,
5, 5, 9, 9, 9, 9) -> (1, 3, 5, 9).
- Sort an array of size n containing integers between 1 and K, given a temporary scratch integer
array of size K.
- Given an array of length N containing integers between 1 and N, determine if it contains any
duplicates.
- An array of integers. The sum of the array is known not to overflow an integer. Compute the sum.
What if we know that integers are in 2's complement form?
- An array of integers of size n. Generate a random permutation of the array, given a function
rand_n() that returns an integer between 1 and n, both inclusive, with equal probability. What is the
expected time of your algorithm?
- An array of pointers to (very long) strings. Find pointers to the (lexicographically) smallest and
largest strings.
- Write a program to remove duplicates from a sorted array.
- Given a list of numbers (fixed list). Now given any other list, how can you efficiently find out if
there is any element in the second list that is an element of the first list (fixed list).
- Given a singly linked list, determine whether it contains a loop or not.
- Given a singly linked list, print out its contents in reverse order. Can you do it without using any
extra space?
- Given a binary tree with nodes, print out the values in pre-order/in-order/post-order without
using any extra space.
- Given a singly linked list, find the middle of the list.
- Reverse the bits of an unsigned integer.
- Compute the discrete log of an unsigned integer.
- Set the highest significant bit of an unsigned integer to zero.
- Let f(k) = y where k is the y-th number in the increasing sequence of non-negative integers with
the same number of ones in its binary representation as y, e.g. f(1) = 1, f(2) = 2, f(3) = 1, f(4) = 3, f(5) = 2,
f(6) = 3 and so on. Given k >= 0, compute f(k).
- Given a 2-D array, which consists of words. Write, efficient code for generation of permutations
using an iterative and recursive algorithms. e.g. {{white, red, green},{black, grey, blue},{pink, yellow,
navy}} -> {{ white, black, pink},{ white, black, yellow}, etc.
- Check string for palindrome. Palindrome is: mam, toyot, mm, a and so on. The string you can read
in both directions.
- In given array find the element that occurred more the half times.
- Convert a binary search tree to a sorted double-linked list. We can only change the target of pointers, but cannot create any new nodes.
- Please implement a function which returns mirror of a binary tree.
- Write a program that prints the numbers from 1 to 100. But for multiples of three prints “Fizz”
instead of the number and for the multiples of five prints “Buzz”. For numbers, which are, multiples of
both three and five prints “FizzBuzz”. How would you test it!
- Write a program that prints Fibonacci series up to N number.
- In 2-D array, find a zero and replace the entire row and column with zeros.
- Given a linked list find the N-th element from the end of the list.
- Write a function to calculate x in the power of y.
- Write an efficient function to find this missing number in array with integers from 1 till 100.
- Calculate the count of 1's in a number 11^N (the range of N is 0 to 1000) without using pow function. For example: if n is 5, it should return 3, if n is 10, it should return 1.
- A group contains other groups and users. Implement classes to represent this model and a method for adding a group to another group. What potential problems do you see with adding a group? (a cycle). Implement a check to prevent the cycle.
- Find the number of occurrences of a regular expression in a string. Regular expression type like  A*cd*.
- Counting the number of elements in the binary tree.
- Implement dictionary insert method from scratch.
- Implement function which takes parameters (string, char, char, int) and returns True or False. Example: doCompare ("Tadas s sf ksffdf   g ts", 't', 's', 2).
