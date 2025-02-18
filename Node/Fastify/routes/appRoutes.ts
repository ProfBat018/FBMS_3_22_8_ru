import type { FastifyInstance, FastifyReply, FastifyRequest } from "fastify";
import { authController } from "../controllers/authController.ts";
import { movieController } from "../controllers/movieController.ts";
import "@fastify/jwt";

export async function movieRoutes(fastify: FastifyInstance) {
  fastify.decorate(
    "authenticate",
    async (request: FastifyRequest, reply: FastifyReply) => {
      try {
        await request.jwtVerify();
      } catch (err) {
        reply.code(401).send({ message: "Unauthorized" });
      }
    }
  );

  fastify.get(
    "/Movie/All",
    { preHandler: [fastify.authenticate] },
    movieController.getMovies
  );
}

export async function authRoutes(fastify: FastifyInstance) {
  fastify.post("/register", authController.register);
  fastify.post("/login", authController.login);
}
