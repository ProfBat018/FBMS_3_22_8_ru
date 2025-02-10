import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import { PrismaClient } from "@prisma/client/edge";
import type { RegisterDTOType } from "../dtos/authDTOs";

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
};


