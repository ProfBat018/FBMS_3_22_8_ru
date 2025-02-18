import type { FastifyRequest, FastifyReply } from "fastify";
import { authService } from "../services/authService.ts";
import { LoginDTO, RegisterDTO } from "../dtos/authDTOs.ts";

export const authController = {
  async register(request: FastifyRequest, reply: FastifyReply) {
    const result = RegisterDTO.safeParse(request.body);
    if (!result.success) {
      return reply.status(400).send({ error: result.error });
    }

    const response = await authService.register(result.data);
    return reply.status(response.status).send(response.body);
  },

  async login(request: FastifyRequest, reply: FastifyReply) {
    const result = LoginDTO.safeParse(request.body);
    if (!result.success) {
      return reply.status(400).send({ error: result.error });
    }

    const response = await authService.login(result.data);

    return reply.status(response.status).send(response.body);
  },
};
