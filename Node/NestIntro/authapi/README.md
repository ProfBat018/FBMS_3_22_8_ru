# Тема урока

- AuthApi на `Nest.js`

## Структура проекта

```bash
.
├── README.md
├── eslint.config.mjs
├── nest-cli.json
├── package-lock.json
├── package.json
├── src
│   ├── app.module.ts
│   ├── auth
│   │   └── jwt-auth.guard.ts
│   ├── auth.controller.ts
│   ├── auth.module.ts
│   ├── auth.service.ts
│   ├── dto
│   │   ├── login.dto.ts
│   │   └── register.dto.ts
│   ├── jwt.strategy.ts
│   ├── main.ts
│   ├── users.module.ts
│   └── users.service.ts
├── tsconfig.build.json
└── tsconfig.json
```

В `Nest.js` для того чтобы реализовать `api` ваш проект должен состоять из модулей, сервисов, контроллеров. 

### Модуль 

`Модуль` - это класс с декоратором `@Module`, который группирует `контроллеры`, `провайдеры` и другие `модули`. Он нужен чтобы собирать вашу логику сущностей в одном месте и делить ваше приложение на отдельные части.

По структуре есть главный модуль `app.module.ts` и дополнительные модули, которые вы создаете для разделения логики. Внутри этого модуля мы храним `auth.module.ts` и `users.module.ts`.

Вот пример `auth.module.ts`:

```typescript

import { Module } from '@nestjs/common';
import { AuthService } from './auth.service';
import { AuthController } from './auth.controller';
import { UsersModule } from './users.module';
import { PassportModule } from '@nestjs/passport';
import { JwtModule } from '@nestjs/jwt';
import { JwtStrategy } from './jwt.strategy';

@Module({
  imports: [
    UsersModule,
    PassportModule,
    JwtModule.register({
      secret: process.env.JWT_SECRET || 'your-secret-key',
      signOptions: { expiresIn: '1h' },
    }),
  ],
  controllers: [AuthController],
  providers: [AuthService, JwtStrategy],
  exports: [AuthService],
})
export class AuthModule {}

```

По факту модуль - это пустой класс, с декоратором перед ним. Этот декоратор описывает какие зависимости есть у модуля, какие контроллеры и сервисы в нем используются. В нашем случае мы импортируем `UsersModule`, `PassportModule`, `JwtModule` и `JwtStrategy`.



