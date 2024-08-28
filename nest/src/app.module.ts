import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { UserModule } from './user/user.module';
import { ClusterService } from './cluster/cluster.service';
import { TypeOrmModule } from '@nestjs/typeorm';

@Module({
  imports: [
    TypeOrmModule.forRoot({
      type: 'postgres',
      host: 'postgresql',
      port: 5432,
      username: 'ezequiel',
      password: 'chichito',
      database: 'ezequiel',
      synchronize: true,
      autoLoadEntities: true,
      connectTimeoutMS: 0,
      poolSize: 100,
      maxQueryExecutionTime: 10000000
    }),
    UserModule
  ],
  controllers: [AppController],
  providers: [AppService, ClusterService],
})
export class AppModule {}
