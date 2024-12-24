# gRPC 

Есть много способ общения по сети.ю я перечислю всего 3.
- REST
- SOAP(XML)
- gRPC

Мы знаем что REST, это не протокол а архитектурный стиль. Но все
же он работает с помощью передачи HTTP запросов с помощью 
JSON. 

SOAP в свою очередь уже полноценный протокол базирующийся на XML.
Под капотом он работает с помощью HTTP, но в отличии от REST,
SOAP использует XML для передачи данных.

gRPC - это RPC(Remote procedure call) протокол от Google который работает уже поверх
HTTP/2, и если мы вспомним предмет сетевое программирование, то
вы поймете что в отличии от HTTP/1.1, HTTP/2 работает и с TCP
и с UDP. Таким образов вы можете посылать мульти канальные запросы.

у него есть свой интерфейс работы который назыается `Protocol Buffers`.
В этом файле мы описыавем запрос, ответ и методы которые мы хотим. Вот пример
`.proto` файла из нашего проекта. 

```proto
syntax = "proto3";

option csharp_namespace = "CommunicationService.Protos.GrpcUserService";

service UserService{
  rpc GetIdByUsername (UserRequest) returns (UserResponse);
}


message UserRequest {
  string username = 1;
}


message UserResponse {
  string id = 1;
}
```
