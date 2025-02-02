const express = require("express");
const {
  registerUser,
  loginUser,
  getUsers,
  refreshToken,
} = require("../controllers/authController");

const {
  registerValidation,
  loginValidation,
} = require("../validators/authValidator");

const { protect } = require("../middleware/authMiddleware");

const router = express.Router();

router.post("/register", registerValidation, registerUser);
router.post("/login", loginValidation, loginUser);
router.post("/refresh", refreshToken);
router.get("/", protect, getUsers); // Только для авторизованных

module.exports = router;
