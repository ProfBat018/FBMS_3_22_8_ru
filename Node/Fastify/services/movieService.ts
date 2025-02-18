import bcrypt from "bcrypt";
import jwt from "jsonwebtoken";
import { PrismaClient } from "@prisma/client";
import { config } from "dotenv";

config();

const prisma = new PrismaClient();

export const movieService = {
  async getMovies() {
    const movies = {
      movies: [
        {
          id: 1,
          title: "The Shawshank Redemption",
          year: 1994,
          rating: 9.3,
          director: "Frank Darabont",
          genre: "Drama",
        },
        {
          id: 2,
          title: "The Godfather",
          year: 1972,
          rating: 9.2,
          director: "Francis Ford Coppola",
          genre: "Crime",
        },
        {
          id: 3,
          title: "The Dark Knight",
          year: 2008,
          rating: 9.0,
          director: "Christopher Nolan",
          genre: "Action",
        },
      ],
    };

    return { status: 200, body: movies };
  },
};
