# Темы важные для понимания этого проекта
- Global Exceptions Middleware


# Global Exceptions Middleware

Вы уже знаете что такое Middleware и как мы их используем. 
Очень часто при разработке веб приложений нам приходится самим разрабатывать Middleware для обработки ошибок.

Одним из таких Middleware является Global Exceptions Middleware. По названию
можно понять что он нужен дл обработки всех исключений. 

Как я уже вам говорил, наш контроллер не должен содержать какую-либо 
логику, неважно это обработка ошибок или что-то другое. Даже этот 
участок кода лучше видоизменить. 

```csharp
 [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        await _accountService.RegisterAsync(request);

        return Ok(new Result<string>(true, request.Username, "Successfully registered"));
    }

```

Здесь, я использую валидатор напрямую, по хорошему к нему надо обращаться через встроенноке свойство `ModelState`. 

`Modelstate` уже встроен в `ApiController` и он содержит все ошибки валидации. 
Эту ошибку мы утсроним позже, а пока надо задуматься над тем, что будет если выйдет какое-то исключение во время выполнения метода.

Для этого мы создадим Middleware, который будет обрабатывать все исключения. 

