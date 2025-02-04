const { UserDTO } = require("../dtos/userDTO");

// Валидация регистрации
const registerValidation = (req, res, next) => {
  const { username, email, password, confirmPassword } = req.body;

  if (!username || !email || !password || !confirmPassword) {
    return res.status(400).json({ message: "Все поля обязательны" });
  }

  const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  if (!emailRegex.test(email)) {
    return res.status(400).json({ message: "Некорректный email" });
  }

  if (password.length < 6) {
    return res
      .status(400)
      .json({ message: "Пароль должен содержать хотя бы 6 символов" });
  }

  if (password !== confirmPassword) {
    return res.status(400).json({ message: "Пароли не совпадают" });
  }

  next();
};

// Валидация логина
const loginValidation = (req, res, next) => {
  const { email, password } = req.body;

  if (!email || !password) {
    return res.status(400).json({ message: "Email и пароль обязательны" });
  }

  const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
  if (!emailRegex.test(email)) {
    return res.status(400).json({ message: "Некорректный email" });
  }

  if (password.length < 6) {
    return res
      .status(400)
      .json({ message: "Пароль должен содержать хотя бы 6 символов" });
  }

  next();
};

// Экспортируем функции
module.exports = { registerValidation, loginValidation };
