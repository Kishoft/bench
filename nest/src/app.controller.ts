import { Body, Controller, Get, Post } from '@nestjs/common';
import { User } from './user/user.entity';
import { CreateUserDTO } from './user/create-user.dto';
import { UserService } from './user/user.service';

@Controller()
export class AppController {
  constructor(
    private readonly userService: UserService
  ) { }
  @Post("users")
  createUser(@Body() createUserDto: CreateUserDTO): Promise<User> {
    return this.userService.createUser(createUserDto);
  }

  @Post("users-raw")
  createUserRaw(@Body() createUserDto: CreateUserDTO): Promise<User> {
    return this.userService.createUserRaw(createUserDto);
  }
}
