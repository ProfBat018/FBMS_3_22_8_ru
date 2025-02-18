import { z } from "zod";

export const RegisterDTO = z
  .object({
    name: z
      .string()
      .min(2)
      .refine(
        (data) => /^[a-zA-Z]+$/.test(data ?? ""),
        "Name must be alphabetic"
      ),
    email: z.string().email(),
    password: z
      .string()
      .min(8)
      .refine(
        (data) =>
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/.test(
            data ?? ""
          ),
        "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character"
      ),
    confirm: z.string().min(8),
  })
  .refine((data) => data.password === data.confirm);

export const LoginDTO = z.object({
  email: z.string().email(),
  password: z.string().min(8),
});

export type RegisterDTOType = z.infer<typeof RegisterDTO>;
export type LoginDTOType = z.infer<typeof LoginDTO>;
