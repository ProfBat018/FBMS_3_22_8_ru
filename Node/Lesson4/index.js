const express = require("express");
const currencySchema = require("./models/currencyModel");
const db = require("./db");

const app = express();

app.use(express.json());

app.get("/", (req, res) => {
  res.send("Hello World");
});

app.get("/currency", async (req, res) => {
  await db();

  const employees = await currencySchema.find();

  console.log("Найденные данные:", employees);
  
  res.json(employees);
});

app.listen(3000, () => {
  console.log("Server is listening on port 3000");
});
