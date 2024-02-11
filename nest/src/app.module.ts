import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { User } from './user/user.entity';
import { Post } from './user/post.entity';
import { UserModule } from './user/user.module';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'postgres',
      host: 'postgresql',
      port: 5432,
      username: 'ezequiel',
      password: 'chichito',
      database: 'ezequiel',
      entities: [User, Post],
      synchronize: true,
      autoLoadEntities: true,
      connectTimeoutMS: 0,
      poolSize: 20,
      maxQueryExecutionTime: 10000000
    }),
    UserModule,
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
