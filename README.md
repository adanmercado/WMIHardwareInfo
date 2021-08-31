# WMIHardwareInfo

Get hardware information easily with C#.

# Unit Testing rules
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


# Assert
Verification functions differ according to the type of data you will be comparing
1. Assert
2. StringAssert
3. CollectionAssert


For more  information about the tests in this project, see [https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing.git](https://github.com/MohammadYAmmar/WMIHardwareInfo-with-Unit-Testing.git)