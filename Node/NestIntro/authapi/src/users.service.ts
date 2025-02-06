import { Injectable } from '@nestjs/common';
import * as bcrypt from 'bcrypt';

@Injectable()
export class UsersService {
  private users = [
    { id: 1, username: 'test', password: '$2b$10$ABC123hashedpassword' }, // Пример хешированного пароля
  ];

  async findByUsername(username: string) {
    return this.users.find((user) => user.username === username);
  }

  async createUser(username: string, password: string) {
    const hashedPassword = await bcrypt.hash(password, 10);
    const newUser = { id: Date.now(), username, password: hashedPassword };
    this.users.push(newUser);
    return newUser;
  }
}
