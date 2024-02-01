import { Body, Controller, Get, Post } from '@nestjs/common';
import { User } from './user.entity';
import { UserService } from './user.service';
import { UserDto } from './user.dto';

@Controller('user')
export class UserController {
    constructor(private userService: UserService) { }

    @Get()
    async getUsers(): Promise<User[]> {
        return this.userService.findAll();
    }

    @Post()
    async createUser(@Body()userDto : UserDto) {
        await this.userService.create(userDto as User)
    }
}
