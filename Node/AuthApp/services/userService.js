const bcrypt = require("bcryptjs");
const User = require("../models/userModel");
const { UserDTO } = require("../dtos/userDTO");
const { generateAccessToken, generateRefreshToken } = require("../config/jwt");
const { plainToInstance } = require("class-transformer");

const createUser = async (userData) => {
  const { username, email, password } = userData;

  const existingUser = await User.findOne({ email });
  if (existingUser) throw new Error("Пользователь уже зарегистрирован");

  const salt = await bcrypt.genSalt(10);
  const hashedPassword = await bcrypt.hash(password, salt);

  const newUser = new User({ username, email, password: hashedPassword });
  await newUser.save(); // Обязательно сохраняем пользователя в БД

  console.log(newUser.toObject());

  return {
    user: plainToInstance(UserDTO, newUser.toObject()),
  };
};

const loginUser = async (userData) => {
  const { email, password } = userData;

  const user = await User.findOne({ email });
  if (!user) throw new Error("Неверный email или пароль");

  const isMatch = await bcrypt.compare(password, user.password);
  if (!isMatch) throw new Error("Неверный email или пароль");

  const accessToken = generateAccessToken(user._id);
  const refreshToken = generateRefreshToken(user._id);

  user.refreshToken = refreshToken;
  await user.save();

  return { user: mapper.map(user, UserDTO, User), accessToken, refreshToken };
};

const refreshToken = async (refreshToken) => {
  if (!refreshToken) throw new Error("Refresh token отсутствует");

  const user = await User.findOne({ refreshToken });
  if (!user) throw new Error("Неверный refresh token");

  try {
    const decoded = jwt.verify(refreshToken, process.env.JWT_REFRESH_SECRET);
    const newAccessToken = generateAccessToken(decoded.userId);
    return { accessToken: newAccessToken };
  } catch (err) {
    throw new Error("Недействительный refresh token");
  }
};

module.exports = { createUser, loginUser, refreshToken };
