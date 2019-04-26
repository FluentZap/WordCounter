# WordCounter

WordCounter is an application to practice tests in C#.
It searches a sentence or paragraph and returns how often the word is used.

## Installation

Clone the repository and compile with a c# compiler.
It is based on the .NET 2.2 framework

## Usage

```C#
function syntax

int WordCounter.CountWords(string keyWord, string wordsToCheck, bool strict = false);
// returns count of keyWord in wordsToCheck
// defaults as case sensitive, can be set to case insensitive with an optional arguement
```

## Program Specifications 
|Description|Input|Output|
|-|-|-|
|Match a single letter and return count|("f", "f")|1|
|Ignore case and return count|("f", "F")|1|
|Become case sensitive if the strict option is set|("f", "F", true)|0|
|Match multiple letters and return count|("apple", "apple")|1|
|Do not match only part of a word|("app", "apple")|0|
|Treat words as separate if a space is detected|("apple", "apple juice apple pie")|2|
|Ignore keyWord special characters|("!apple!", "apple juice apple pie")|2|
|Special character '*' can be used as a wild card but it will not return partial words and it will not match with spaces|("**ple", "apple people ple maple")|2|
|Check for keyWord special characters if the strict option is set, still treat '*' as a wild card|("ap*le!", "apple! apple apile!", true)|2|
|Ignore wordsToCheck special characters when evaluating words|("apple", "a'pple, juice! !appl'e! pie!")|2|
|Treat special characters as word dividers |("apple", "apple,juice.apple!pie!", true)|2|
|Do not include hyphenated or underscored words|("apple", "apple-juice apple_pie")|0|


## Support
If there are any issues or errors contact me

## License
[MIT](https://choosealicense.com/licenses/mit/)
