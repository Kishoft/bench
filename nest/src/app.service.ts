import { Injectable } from '@nestjs/common';

@Injectable()
export class AppService {
  getHello(): string {
    return 'Hello World!';
  }

  async getSarasa(){
    return [
      { nombre : "Sarasa", email: "email"},
      { nombre : "Sarasa", email: "email"},
      { nombre : "Sarasa", email: "email"},
      { nombre : "Sarasa", email: "email"},
      { nombre : "Sarasa", email: "email"}
    ]
  }
}
