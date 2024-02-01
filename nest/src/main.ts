import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { ValidationPipe } from '@nestjs/common';

const cluster = require('cluster'); 
import * as process from 'node:process';
import * as os from 'os';

const numCPUs = parseInt(os.cpus().length.toString());

async function bootstrap() {
  const app = await NestFactory.create(AppModule);
  app.useGlobalPipes(new ValidationPipe());
  await app.listen(3000);
}
if (cluster.isMaster) {
  console.log(`MASTER SERVER (${process.pid}) IS RUNNING `);

  for (let i = 0; i < numCPUs; i++) {
    cluster.fork();
  }

  cluster.on('exit', (worker, code, signal) => {
    console.log(`worker ${worker.process.pid} died`);
  });
} else {
  bootstrap();
}
