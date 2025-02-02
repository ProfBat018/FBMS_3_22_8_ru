const { UserDTO } = require("../dtos/userDTO");
const { User } = require("../models/userModel"); // Твоя модель пользователя

const AutoMapper = require("automapper-js");

AutoMapper.createMap(UserDTO, User)
  .forMember("username", (opts) => opts.mapFrom("username"))
  .forMember("email", (opts) => opts.mapFrom("email"))
  .forMember("password", (opts) => opts.mapFrom("password"))
  .forMember("createdAt", (opts) => opts.mapFrom("createdAt"))
  .forMember("updatedAt", (opts) => opts.mapFrom("updatedAt"));

module.exports = AutoMapper;
