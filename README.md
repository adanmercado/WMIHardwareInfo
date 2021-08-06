
# WMIHardwareInfo
Get hardware information easily with C#

This project is my desire to experience developing my skills and supporting open source projects, #todo

Project fork from:  [https://github.com/adanmercado/WMIHardwareInfo(https://github.com/adanmercado/WMIHardwareInfo)

# Table of contents

# Unit Testing rules 
After watching one of the courses on YouTube, there are two main rules:
1. Given_When_Then
It is a way to write the name of the test method, for example there is a method in the project that is its name
 `GetPropertiesForWMIClass `

After apply rule the test method is `GetPropertiesForWMIClass_When_ClassWin32_Processor_Return_name_CPU`

Another example of a method
 `GetPropertyValuesForWMIClass`
The name of test method name is 
`GetPropertyValuesForWMIClass_With_Win32_Processor_name_Return_i7_8550U` 
Because this result is supposed to be obtained, from reading the name of the test function we know the objection of it, the input and the expected result

2. AAA

AAA: Arrange , Act, Assert
Which are the steps to write the test where with Arrange we know the inputs and declare the variables, then in Act we prepare the method to be tested, and finally Assert to check between the expected values for the test to be true and the actual value that returned.
It has been implemented in the project's test methods.



# Unit Testing in C#

#todo
1. Select solution in project and > `Add > New project`
2. Add tests to name like `wmi-hardwareTests`



# My experience of learning in a practical way with my first project, which is this
#todo add pic 

# C# library: Fluent Assertions
🔜

# Code Coverage 
🔜

# Problems with first run 
When I first run the project before adding anything I encountered a problem as in the picture:

![alt text](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing/blob/master/Screenshot%201%20first%20run%20problem.png "Picture of first problem")

The solution on the first run did not show all the results and seemed incomplete

![alt text](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing/blob/master/Screenshot%202%20Program%20output.png "Picture of inital solve of first problem")

The solution was to modify the code to be smarter and become


`if (item[property] == null)`
`                            {`
`                                //To get out of the for each loop`
`                                //without going through the problem that stopped the program`
`                                //break;`
`                                continue;`
`                            }`
`                            device.Add(property, item[property].ToString());`
`                        }`

where put (continue) is true to complement what's inside the WMI class

# Shortcuts while typing tests 

Write (testm) + Tab = to create test method
Write (prop) + Tab = to create property by fast shortcut
Write (cw) + Tab = to create statement of Console for Write Line

sut : System under test

---
My GitHub:  
[https://github.com/MohammadYAmmar](https://github.com/MohammadYAmmar)  
My LinkedIn:  
[https://www.linkedin.com/in/mohammad-y-ammar/](https://www.linkedin.com/in/mohammad-y-ammar/)

This site is nice for writing description [stackedit](https://stackedit.io/)

Thank you for reading all of this to benefit you instead of just copying and pasting ✂!
