## Technical Test for Jeff Ward

Code has been written with TDD and is a console app, written as a dotnetcore 2.2 console application, within the timeframe of 3 hours.

The scenarios mentioned in the spec are implemented as unit tests named Scenario1, Scenario2, Scenario3

The other tests in the solution were written as I was building components of the test, during the test.

I have implemented best practices such as SOLID principles and composition over inheritance.


Although this test was written on a mac, using rider, it should work fine in visial studio on Windows.



I have included two scripts to be able to run and test this outside of the IDE

```
build.sh 
```

and 

```
test.sh
```

Again these have only been tested on macos, but should work on windows


### using the web host

You can query the test project as an api. You can send a request (when the service is running) to http://localhost:5000/ passing params, such as:

```
http://localhost:5000/?deliveryPartner=iTunes&effectiveDate=2012-01-01
```

e.g. 

```
curl http://localhost:5000/\?deliveryPartner\=iTunes\&effectiveDate\=2012-01-01
```