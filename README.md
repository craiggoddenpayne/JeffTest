Full Stack/Back-End
Time to complete: 3 hours
Description:
A music label called Recklass Rekkids (aka RR) wants to build a Global Rights Management
(aka GRM) platform to allow them to best utilise their collection of music assets.
There are legal limitations in the ways in which RR can use the assets based on the contract
signed with the artist. For example Monkey Claw agreed with RR to distribute his new song
'Motor Mouth' as a digital download starting 1st of feb 2012, and as a streaming product starting
from the 1st of march.
Agreements with distribution partners also have limitations. For example iTunes will only sell
assets as digital downloads, while YouTube will only sell them as streaming products.
Task:
First priority is to create a back-end console application for this. If you can create a UI to
accompany it, even better!
Create a console application that determines products available for a given partner on a given
date.
The application should accept the reference data supplied below as text file inputs.
The user will then supply a delivery partner name and an effective date as command line inputs.
The output should describe the current active music contracts as applicable to the partner.
Submission Checklist
● Visual Studio solution
○ with executable
● *Minimum* Console application
○ UI with backend is better
● Passing tests for each of the system design requirements
● Written in backend language of your choice (C# preferred)
Delivery Requirements:
● Send link to repo with code to: jeff@dittomusic.com
● Passing Tests
● Add documentation to your code repo so that a user such as myself can follow
instructions to:
- Download your code
- Compile your code
- Run your code as a user
Text File Input #1
Music Contracts
Artist|Title|Usages|StartDate|EndDate
Tinie Tempah|Frisky (Live from SoHo)|digital download, streaming|1st Feb 2012|
Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|
Tinie Tempah|Till I'm Gone|digital download|1st Aug 2012|
Monkey Claw|Black Mountain|digital download|1st Feb 2012|
Monkey Claw|Iron Horse|digital download, streaming|1st June 2012|
Monkey Claw|Motor Mouth|digital download, streaming|1st Mar 2011|
Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012
Text File Input #2
Distribution Partner Contracts
Partner|Usage
ITunes|digital download
YouTube|streaming
Test Scenarios
1.
Given the supplied above reference data
When user enters 'ITunes 1st March 2012'
Then the output is:
Artist|Title|Usage|StartDate|EndDate
Monkey Claw|Black Mountain|digital download|1st Feb 2012|
Monkey Claw|Motor Mouth|digital download|1st Mar 2011|
Tinie Tempah|Frisky (Live from SoHo)|digital download|1st Feb 2012|
Tinie Tempah|Miami 2 Ibiza|digital download|1st Feb 2012|
2.
Given the supplied above reference data
When user enters 'YouTube 1st April 2012'
Then the output is:
Artist|Title|Usage|StartDate|EndDate
Monkey Claw|Motor Mouth|streaming|1st Mar 2011|
Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|
3.
Given the supplied above reference data
When user enters 'YouTube 27th Dec 2012'
Then the output is:
Artist|Title|Usage|StartDate|EndDate
Monkey Claw|Christmas Special|streaming|25st Dec 2012|31st Dec 2012
Monkey Claw|Iron Horse|streaming|1st June 2012|
Monkey Claw|Motor Mouth|streaming|1st Mar 2011|
Tinie Tempah|Frisky (Live from SoHo)|streaming|1st Feb 2012|