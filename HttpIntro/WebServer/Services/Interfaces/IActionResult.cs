using System.Net;

namespace WebServer.Services.Interfaces;

#region Docs



/*
 IActionResult - это интерфейс, который прдеставляет
 собой ответ на какой-либо Http запрос в ASP.NET
 
 Я создал этот интрефейс чтобы показать вам как он реализован 
 под капотом. Он хранит в себе метод ExecuteResult, который 
 принимает HttpListenerContext.
 
 HtppListenerContext - это класс, который хранит в себе данные 
 запроса пользователя. Например при запросе: 
 
 https://google.com/search?q=cars 
 
 Запрос будет типа: GET 
 Сырая ссылка будет: https://google.com
 Путь будет: /search?q=cars
 
 В общем и целом в этом классе хранится вся информация о запросе 
 
 Сам этот интерфейс нужен для того, чтобы мой веб-сервер мог возвращать разные резульятаты
 
 Например, я создам классы JsonResult, ViewResult, ErrorResult 
 и буду имплементировать их от этого интерфейса, Таким образом он 
 будет многофункциональным. 
 */

#endregion

public interface IActionResult
{
    void ExecuteResult(HttpListenerContext context);
}