const mongoose = require("mongoose");

const currencySchema = new mongoose.Schema({
  _id: mongoose.Schema.Types.ObjectId, // MongoDB автоматически использует ObjectId
  currency_id: { type: Number, required: true }, // $numberLong - это просто Number
  date: { type: Date, required: true }, // $date - это формат даты
  currency: { type: String, required: true },
  conversion_ratio: { type: Number, required: true },
});

const Currency = mongoose.model("currency", currencySchema, "currency");

module.exports = Currency;
