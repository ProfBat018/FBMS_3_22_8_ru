import { z } from 'zod';

export const userSchema = z.object({
  id: z.string().optional(),
  email: z.string().email(),
  password: z.string().min(6),
  name: z.string().min(2),
  confirmed: z.boolean().default(false),
  createdAt: z.date().optional(),
  updatedAt: z.date().optional()
});


