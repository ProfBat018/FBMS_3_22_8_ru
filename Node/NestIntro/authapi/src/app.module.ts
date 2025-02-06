import { Module } from '@nestjs/common';
import { AuthModule } from './auth.module';
import { UsersModule } from './users.module';

@Module({
  imports: [AuthModule, UsersModule],
})
export class AppModule {}
