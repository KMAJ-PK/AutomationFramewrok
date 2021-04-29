The Solution has two projects:
1. TestFramework
2. WebFramework

1. TestFramework

This project holds all the specifications and the bindings for the steps. Each and every step definition is written is clear text so that navigating through the solution is easy.

2. WebFramework

This project holds all the support and the units which makes the webpage insteraction using the webdriver. It holds all the asserts and the control definitions.

To run the tests, you needed to have Specflow account registered so that the host machine can be recognised. 
Just navigate to the test explorer using VS and all the tests will be displayed there. 
All the tests run on Chrome browser by default, but the framework does support Firefox and Safari browsers. 
To run the tests against any of the other browsers instead of Chrome, simply put a tag '@BrowserFirefox' or '@BrowserSafari' on each of the feature files, the framework will run the tests on them browsers.


NOTE:

This peace of code is the property of the candidate and it's submitted only for the use of Test and Interview. The recipent is not allowed to use the code and structure of the framework for their future or current projects should the candidate not get selected for the post for any reason.