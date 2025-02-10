import { z } from "zod";

export const RegisterDTO = z.object({
  email: z.string().email(),
  password: z.string().min(6),
  name: z.string().min(2),
});

export const LoginDTO = z.object({
  email: z.string().email(),
  password: z.string().min(6),
});

export type RegisterDTOType = z.infer<typeof RegisterDTO>;
