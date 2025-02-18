import fastify from "fastify";
import { authRoutes, movieRoutes } from "./routes/appRoutes.ts";
import "dotenv";
import jwt from "@fastify/jwt";
import { config } from "dotenv";

config();



const app = fastify({ logger: true });

const appListenOptions = {
  port: 3000,
};

app.register(jwt, {
  secret: process.env.JWT_SECRET || "defaultSecret", // Вынеси в .env
});

app.register(authRoutes);
app.register(movieRoutes);

const start = async () => {
  try {
    await app.listen(appListenOptions);
    console.log("Server listening on http://localhost:3000");
  } catch (err) {
    app.log.error(err);
    process.exit(1);
  }
};

start();
