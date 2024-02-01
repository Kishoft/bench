import { Injectable } from '@nestjs/common';

const cluster = require('cluster'); 
import * as process from 'node:process';
import * as os from 'os';

const numCPUs = parseInt(os.cpus().length.toString());

@Injectable()
export class ClusterService {
  static clusterize(callback: Function): void {
    if (cluster.isMaster) {
      console.log(`MASTER SERVER (${process.pid}) IS RUNNING `);

      for (let i = 0; i < numCPUs; i++) {
        cluster.fork();
      }

      cluster.on('exit', (worker, code, signal) => {
        console.log(`worker ${worker.process.pid} died`);
      });
    } else {
      callback();
    }
  }
}