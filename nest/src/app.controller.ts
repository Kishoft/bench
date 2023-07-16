import { Controller, Get, HttpCode, Post } from '@nestjs/common';
import { AppService } from './app.service';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}
//sebd 294
  @Get()
  @HttpCode(204)
  getHello(): void {
    
  }

  @Post()
  postHello(): string {
    return 'Hello World!';
  }
}
