# Lancy
AWS Lambda with Nancy sample project.

### Building the function

```
 cd .\Lancy\src\Lancy\
 dotnet restore
 dotnet lambda package -c Release -f netcoreapp1.0 -o Lancy.zip
```
Upload `Lancy.zip` to AWS Lambda and set the function handler to `Lancy::Lancy.LancyFunctionHandler::FunctionHandler`.
