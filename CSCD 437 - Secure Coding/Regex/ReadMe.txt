// Hung Auduong
// CSCD 437
// Professor Capual

How To Run:
Toms Spec:
    The program will run normally with Intellij as the user test inputs. To run with a redirect, it will take the input
    file and test each case as a "User" then output to a specified output file.
    tester file must end in a q. What I did to run the program in powershell was
    javac Regex.java
    Get-Content test.txt | java Regex > output.txt
Easier To read:
    For a reader friendly output, (like below @ line starting at 75), uncomment line 20, 21.
    method:
          //initializeInputText(input);
          //testFromFile(input);
    Those two will able the program to read through an user input file and test each case, then outputting
    it to result.txt
    no cmd line for this method.

Included Files:
test.txt: my own default test
StateAbbreviations.txt
result.txt: output file for testing my default file
/src
    output.txt: ambiguous output file
    test.txt: ambiguous  test file

Pattern for the input is:
a
123-45-6789
a
123456789

Results:
Result will be formatted as such
1. Social Security
Passed Tests:
	123456789
	123-45-6789
	123 45 6789
Failed Tests:
	12345678910
	1234-123-456

Regular Expression Explanation:
a.	Social Security Number
    must be 9 digit. if delimited, must be XXX XX XXXX
    will only be delimited by spaces or dash.

b.	US Phone number
    must be 10 digits. if theres parentheses to start, there will be at the end i.e. (509) will passed, (509 wont.
    can be delimited by -

c.	E-mail address
    This one I tried my best to get everything I could figure out. On my regular tester file, are all the different
    cases I've tried. The only thing I couldnt figure out was having consecutive .. wont passed even if the address is
    inside a quotation. i.e. "abc..ab"c@gmail.com should passed according to Wikipedia.

d.	Name on a class roster, assuming one or more middle initials - Last name, First name, MI
    first and last name will only accept 1 word each unless delimited by ' or -. If there's more than 1 middle initials,
    there should be delimited by a space. i.e. "t." or "t. t."

e.	Date in MM-DD-YYYY format
    This test against the Georgian Calender to make sure if it's a valid date after testing the regex format.

f.	House address - Street number, street name, abbreviation for road, street, boulevard or avenue
    house address format will be "street number street name road". it'll be only delimited by spaces.
    I couldnt find any delimited by commas so I did not accept comma as a valid input

g.	City followed by state followed by zip as it should appear on a letter
    Format of this will be "City, state 12345" with optional - 1234

h.	Military time, including seconds
    Military time also accepts 00:00:00 and 24:00:00 because its considered the same from what I found

i.	US Currency down to the penny
    (ex: $123,456,789.23)

j.	URL, including http:// (upper and lower case should be accepted)
    This one was tricky because I couldn't find whats the exact formatting required so on my test cases below,
    are all the ones I thought should be passed and what I shouldn't passed

k.  Password
    Wasnt sure what was considered punctuations or not so I did a \W and ignore \s. and accepted those symbols.

l.	All words containing an odd number of alphabetic characters, ending in "ion"
    Was able to do

Original Test Cases found in result.txt with my own test.txt:
Regular Expressions

1. Social Security
Passed Tests:
	123456789
	123-45-6789
	123 45 6789
Failed Tests:
	12345678910
	1234-123-456

2. US Phone Number
Passed Tests:
	(509)0001111
	(509)000-2222
	(509)-000-3333
	(509)-0003333
	5090004444
	509-000-5555
Failed Tests:
	(123-999-0000
	1239990000000
	123)-99995555
	(123)

3. E-Mail Address
Passed Tests:
	simple@example.com
	abc1@ewu.edu
	a.bc2@ewu.edu
	a-bc3@ewu.edu
	a_bc4@ewu.edu
	test.123_abc@eagles.ewu.edu
Failed Tests:
	5@ewu...edu
	abc @gmail.com
	abc@gmail*com
	abc.gmail.com
	abc&gmail.com
	abc@gmail&net
	John..Doe@example.com

4. Name on Class Roster
Passed Tests:
	auduong, hung, t
	auduong, hung, t.
	auduong, hung
	auduong, hung, t. t.
Failed Tests:
	auduong auduong, hung, t.
	auduong, hung, t.t.
	auduong, hung, abc bac abc
	auduong-auduong, hung, bac
	lastname-la; first
	lastname, firstname$
	abc, $$$$
	abc
	bac,
	bac t.

5. Date in MM-DD-YYYY
Passed Tests:
	11/11/2000
	11-11-2000
	12-12-1000
	02-29-2000
	02-28-2001
Failed Tests:
	02-29-2001
	33-333-222
	333*333^11
	12-34-56

6. House address
Passed Tests:
	999 abc ave.
	999 abc street
	999 e fair oaks ave
	999 abc cba street
	999 47th ave
Failed Tests:
	123 doesntwork no no no
	123 $abc weirdground
	123, 123, 123

7. City, State, Zip
Passed Tests:
	spokane, wa 12345
	spokane, wa 12345
	spokane, wa 12345-1234
Failed Tests:
	spk-wa
	spokane wa 123
	spokane abc 12345
	spokane wa 123-123
	spokane, wa 12345!-#$%^&

8. Military Time
Passed Tests:
	12:34:52
	24:00:00
	23:59:59
	15:15:15
	00:00:00
Failed Tests:
	23:59:60
	23:60:59
	24:01:01
	25:1:1
	-1:00:00
	11:22:3
	99:59:59

9. US Currency
Passed Tests:
	$123.98
	$1,123.99
	$22,123.99
	$333,123.99
	$123,123,123,123.00
Failed Tests:
	$1,12.00
	1,123.00
	$123
	$22,12,00
	$123,77,123.00

10. URL
Passed Tests:
	http://google.tv
	https://google.net
	https://www.google.com/
	https://www.google.com
	http://hungaud.com/rentaboo/ItemPage.aspx?ID=1002
	http://goo-gle.com
	https://google.co.uk/
	https://google.video
Failed Tests:
	abc://bing.com
	http:/bing.com
	https//bing.com
	http://bing.
	http://bing

11. Password
Passed Tests:
	aBcDeFgH1!
	aBcDeFgH987!#$@%^%^$%&)*()*&()_#$@%
	abCDefGHij.123
Failed Tests:
	Dogcatrat'.?!"-():;8
	aa
	aaaBcDeFgH1!
	ABCDEFGHIJKLMNOPQRSTUVWXYZ!!!123
	abCDef GHij.123
	abcdefghijk!!!123

12. Odd Numbers of Characters Ending in "ion"
Passed Tests:
	ion
	sealion
	abion
Failed Tests:
	abcdeion
	lions
	ions
	-ion
	00ion