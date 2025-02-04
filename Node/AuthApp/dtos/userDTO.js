const { Expose } = require("class-transformer");

// @Expose - это декоратор, который позволяет указать,
// что свойство должно быть включено в процесс сериализации/десериализации.

class UserDTO {
  @Expose()
  username;

  @Expose()
  email;
}

module.exports = { UserDTO };
