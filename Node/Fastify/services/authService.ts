import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import { PrismaClient } from "@prisma/client";
import type { RegisterDTOType, LoginDTOType } from "../dtos/authDTOs";
import { config } from "dotenv";

config();

const prisma = new PrismaClient();

export const authService = {
  async register(data: RegisterDTOType) {
    const { email, password, name } = data;

    const existingUser = await prisma.user.findUnique({ where: { email } });
    if (existingUser) {
      return { status: 400, body: { error: "User already exists" } };
    }

    const hashedPassword = await bcrypt.hash(password, 10);
    const user = await prisma.user.create({
      data: {
        email,
        password: hashedPassword,
        name,
        confirmed: false,
      },
    });

    const confirmToken = jwt.sign({ userId: user.id }, "secret", {
      expiresIn: "1d",
    });
    return { status: 201, body: { message: "User registered", confirmToken } };
  },

  async login(data: LoginDTOType) {
    const { email, password } = data;

    const user = await prisma.user.findUnique({ where: { email } });
    if (!user) {
      return { status: 400, body: { error: "Invalid credentials" } };
    }

    const valid = await bcrypt.compare(password, user.password);
    if (!valid) {
      return { status: 400, body: { error: "Invalid credentials" } };
    }

    var secret = process.env.JWT_SECRET;

    if (!secret) {
      return { status: 500, body: { error: "Internal server error" } };
    }

    const token = jwt.sign({ userId: user.id }, secret, {
      expiresIn: "10s",
    });
    return { status: 200, body: { token } };
  },
};
