const mongoose = require("mongoose");

const db = async () => {
  try {
    await mongoose.connect("mongodb://localhost:27017/foodmart");

    console.log("Connected to the database");
  } catch (error) {
    console.log("Error connecting to the database");
  }
};

module.exports = db;
