import type { FastifyRequest, FastifyReply } from "fastify";
import { movieService } from "../services/movieService";

export const movieController = {
  async getMovies(request: FastifyRequest, reply: FastifyReply) {
    const response = await movieService.getMovies();

    return reply.status(response.status).send(response.body);
  },
};
