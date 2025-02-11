import type { FastifyInstance } from "fastify";
import { authController } from "../controllers/authController.ts";

export async function authRoutes(fastify: FastifyInstance) {
  fastify.post("/register", authController.register);
  fastify.get("/test", async (req, res) => {
    return { hello: "world" };
  });
  // fastify.post("/login", authController.login);
  // fastify.post("/logout", authController.logout);
}
