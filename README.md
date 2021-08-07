# WMIHardwareInfo with Unit Testing 🧪

Get hardware information easily with C#, I have added unit tests to it to test the original project
---
This project is my desire to experience developing my skills and supporting open source projects, As I'm learning unit tests I've thought of using a project that I didn't implement and test to take on the role of tester while programming projects. Based on that, I share this experience with you :)

Project fork from: [https://github.com/adanmercado/WMIHardwareInfo(https://github.com/adanmercado/WMIHardwareInfo)

# Table of contents
<!--ts-->
   * [Unit Testing rules](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#unit-testing-rules)
      * Given_When_Then
      * AAA
   * [Unit Testing in C#](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#unit-testing-in-c)
   * [My experience with my first project](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#my-experience-with-my-first-project)
   * [Assert](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#assert)
   * [C# library: Fluent Assertions](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#c-library-fluent-assertions)
   * [Code Coverage](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#code-coverage)
   * [Test Driven Development (TDD)](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#Test-Driven-Development-TDD)
   * [Problems with the first run](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#problems-with-the-first-run)
   * [Shortcuts while typing tests](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing#shortcuts-while-typing-tests)
<!--te-->

# Unit Testing rules
After watching one of the courses on YouTube, there are two main rules:
1. Given_When_Then
It is a way to write the name of the test method, for example, there is a method in the project that is its name
 `GetPropertiesForWMIClass `

After apply rule the test method is 
`GetPropertiesForWMIClass_When_ClassWin32_Processor_Return_name_CPU`

Another example of a method
 `GetPropertyValuesForWMIClass`
The name of the test method name is
`GetPropertyValuesForWMIClass_With_Win32_Processor_name_Return_i7_8550U`
Because this result is supposed to be obtained, from reading the name of the test function we know the objection of it, the input, and the expected result

2. AAA

AAA: Arrange , Act, Assert
Which are the steps to write the test wherewith Arrange we know the inputs and declare the variables, then in Act we prepare the method to be tested, and finally Assert to check between the expected values ​​for the test to be true and the actual value that returned.
It has been implemented in the project's test methods.



# Unit Testing in C#

To add a test project to the solution 
1. Select solution in a project and > `Add > New project`
2. The option is `MSTest Test Project`
3. Add test project with name like `wmi-hardwareTests`



# My experience with my first project

After fixing the problem of the project to run it, I wrote a paragraph about it 📝
I've created a test project inside Solution 🧪, which contains three test classes that direct each file to the main project.

I had socket programming experience and know about WMI, so I started making generic tests or depending on my hardware model. For the record, some method was not able to use Assert in the comparison, so I just run the method through the test and it does not return an Exception error.
For the record, you can make the method work if you define this before the method, and I will explain this in the next paragraphs.

In this picture, we can see the result of the test that you took

![alt text](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing/blob/master/Screenshot%203%20result%20of%20Test%20Explorer.png "Result of Test explore")

# Assert
Verification functions differ according to the type of data you will be comparing
1. Assert
2. StringAssert
3. CollectionAssert

# C# library: Fluent Assertions

In order to know what is the benefit of adding a library to the test when it already exists?
It is simplicity, which is what we will notice now in this example

```
[TestMethod]
        //Given_When_Then rule
        public void GetPropertyValuesForWMIClass_With_Win32_Processor_name_Return_i7_8550U()
        {
            ///AAA rule 
            
            //Arrange
            WMIConnection connection = new WMIConnection();
            //Get all devices of wmi class
            string actual = "";
            foreach (var device in WMIResult.GetPropertyValuesForWMIClass(connection, "SELECT * FROM Win32_Processor", "Win32_Processor"))
            {
                foreach (var property in device)
                {
                    actual = actual + property.Key + ": " + property.Value;
                }
            }

            //Act
             string expected = "i7-8550U";//Of course, it varies according to the type of processor that will be tested

            //Assert
            StringAssert.Contains(actual, expected);
        }
```
If we focus on the verification and comparison part, which is Assert.
After using the Fluent Assertions library, you will become
```
            //Assert
            StringAssert.Contains(actual, expected);

            //FluentAssertions
            actual.Should().Contain(expected);
```

We notice the difference in clarity between the two methods, as with the Fluent library, it is closer to the English language without going into the finer details as in the Assert types.


The way to add it is by going to a store, then searching for nuget as in the picture

![alt text](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing/blob/master/Screenshot%203%20Fluent.png "Picture of nuget") 


One of the benefits of this library for me is the ease of verification which ensures greater accuracy in the examination where the greater focus of the exam is. This example in the project didn't work for me checking in multiple ways with Assert! But it simply worked with FluentAssertions!

```
 [TestMethod]
        public void GetPropertiesForWMIClass_When_ClassWin32_Processor_Return_name_CPU()
        {

            List<string> actualList = WMIClasses.GetPropertiesForWMIClass("Win32_Processor");

            string expected = "Name";
            List<string> expectedList = new List<string> { "Name", "NumberOfCores", "NumberOfLogicalProcessors" };

            //Assert
            CollectionAssert.Contains(actualList, expected);

            //Filled with Assert
            //CollectionAssert.Contains(actualList, expectedList);

            //But succeeded with FluentAssertions
            actualList.Should().Contain(expectedList);
        }
```

# Code Coverage
In (Visual Studio 2019) this feature is considered paid and not in the community version.

#todo test free tools 🔜

# Test Driven Development (TDD)
With this approach, we focus on writing the test first before the feature is present in the original project of course it will fail the first time.
Then we go and write the code in the method to match the unit test solution.
It allows us to write test-oriented code. This is a picture from the internet showing the process:

![alt text](https://marsner.com/wp-content/uploads/test-driven-development-TDD.png "TDD")


# Problems with the first run
When I first run the project before adding anything I encountered a problem as in the picture:

![alt text](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing/blob/master/Screenshot%201%20first%20run%20problem.png "Picture of first problem")

The solution on the first run did not show all the results and seemed incomplete

![alt text](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing/blob/master/Screenshot%202%20Program%20output.png "Picture of initial solve of first problem")

The solution was to modify the code to be smarter and become

```
if (item[property] == null)
                            {
                                //To get out of the for each loop
                                //without going through the problem that stopped the program
                                //break;
                                continue;
                            }
                            device.Add(property, item[property].ToString());
                        }
```
where put (continue) is true to complement what's inside the WMI class


# Shortcuts while typing tests

Write (testm) + Tab = to create test method

Write (prop) + Tab = to create property by fast shortcut

Write (cw) + Tab = to create statement of Console for Write Line

sut: System under test
---

This project took the time: 12 Hours to 8-7-2021 (720M to 6)

Everything I wrote is from my writing and understanding at this time about unit tests without copying text from sources where I tried to explain the method as I like to read it for myself later when reviewing it 🧐

There is a part of the course on YouTube that is not covered here, I may add it at a later time or in another project as appropriate.

The course that I watched in Al-Arabi on YouTube to learn the tests, and then I made this test project: https://www.youtube.com/playlist?list=PLwj1YcMhLRN28xijrXMO255JHsO3csus-
---
My GitHub:
[https://github.com/MohammadYAmmar](https://github.com/MohammadYAmmar)
My LinkedIn:
[https://www.linkedin.com/in/mohammad-y-ammar/](https://www.linkedin.com/in/mohammad-y-ammar/)
If you have seen the description and test codes, may can you recommend my programming skills or unit tests on LinkedIn? :)

If you liked it, do not forget to give the project a star ⭐🌟 to encourage us to continue.

Thank you for reading all of this to benefit you instead of just copying and pasting ✂!