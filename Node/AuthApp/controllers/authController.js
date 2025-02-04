const { validationResult } = require("express-validator");
const userService = require("../services/userService");
const { UserDTO } = require("../dtos/userDTO");
const { plainToInstance } = require("class-transformer");

const getUsers = async (req, res) => {
  try {
    const users = await userService.getAllUsers();
    res.json(users);
  } catch (err) {
    res.status(500).json({ message: err.message });
  }
};

const registerUser = async (req, res) => {
  const errors = validationResult(req);
  if (!errors.isEmpty()) {
    return res.status(400).json({ errors: errors.array() });
  }

  try {
    const { user } = await userService.createUser(
      req.body
    );

    const userObject = user.toObject ? user.toObject() : user;

    const userDto = plainToInstance(UserDTO, userObject, {
      excludeExtraneousValues: true,
    });

    res.status(201).json({ user: userDto, refreshToken });
  } catch (err) {
    res.status(400).json({ message: err.message });
  }
};

const loginUser = async (req, res) => {
  const errors = validationResult(req);
  if (!errors.isEmpty()) {
    return res.status(400).json({ errors: errors.array() });
  }

  try {
    const { user, accessToken, refreshToken } = await userService.loginUser(
      req.body
    );
    res.json({ user, accessToken, refreshToken });
  } catch (err) {
    res.status(400).json({ message: err.message });
  }
};

const refreshToken = async (req, res) => {
  try {
    const { refreshToken } = req.body;
    const result = await userService.refreshToken(refreshToken);
    res.json(result);
  } catch (err) {
    res.status(403).json({ message: err.message });
  }
};

module.exports = { getUsers, registerUser, loginUser, refreshToken };
