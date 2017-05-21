# Lancy
AWS Lambda with Nancy sample project.

Uses [AwsLambdaOwin](https://github.com/damianh/AwsLambdaOwin) to proxy an AWS API Gateway request to an OWIN AppFunc. 

The main file of interest is [`LancyProxyFunction`](https://github.com/damianh/Lancy/blob/master/src/Lancy/LancyProxyFunction.cs) where the AppFunc is created in the `Init()` method.

### Building the function

```
 cd .\Lancy\src\Lancy\
 dotnet restore
 dotnet lambda package -c Release -f netcoreapp1.0 -o Lancy.zip
```
Upload `Lancy.zip` to AWS Lambda and set the function handler to `Lancy::Lancy.LancyProxyFunction::FunctionHandler`.

[Here is a tutorial](http://www.philliphaydon.com/2017/03/15/part1-creating-a-good-old-hello-world-aws-csharp-lambda/) on creating your first HelloWorld Lambda Function in .NET
