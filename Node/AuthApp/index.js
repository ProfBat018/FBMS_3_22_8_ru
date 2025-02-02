require("dotenv").config();
const express = require("express");
const cors = require("cors");
const connectDB = require("./config/dbContext");

const authRoutes = require("./routes/authRoutes");
// const accountRoutes = require("./routes/accountRoutes");

const app = express();

app.use(express.json()); // middleware для парсинга JSON

app.use(
  cors({
    origin: "http://localhost:3000",
    credentials: true,
  })
);

connectDB();

app.use("/api/auth", authRoutes); // использую маршруты
// app.use("/api/auth", accountRoutes);

const PORT = process.env.PORT;
app.listen(PORT, () => {
  console.log(`🚀 Сервер запущен на порту ${PORT}`);
  console.log(`http://localhost:${PORT}`);
});

// module.exports = app;
