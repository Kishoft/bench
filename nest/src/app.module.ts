import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { User } from './user/user.entity';
import { Post } from './user/post.entity';
import { UserModule } from './user/user.module';
import { ClusterService } from './cluster.service';

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
      poolSize: 20
    }),
    UserModule,
  ],
  controllers: [AppController],
  providers: [AppService, ClusterService],
})
export class AppModule {}
