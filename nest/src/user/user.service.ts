import { Injectable } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { randomUUID } from 'node:crypto';
import { User } from 'src/user/user.entity';
import { Repository } from 'typeorm';

@Injectable()
export class UserService {
    constructor(
        @InjectRepository(User)
        private usersRepository: Repository<User>,
    ) { }

    findAll(): Promise<User[]> {
        return this.usersRepository.find();
    }

    findOne(id: string): Promise<User | null> {
        return this.usersRepository.findOneBy({ id });
    }

    createUser(user: User): Promise<User> {
        return this.usersRepository.save(user);
    }

    createUserRaw(user: User): Promise<User> {
        return this.usersRepository.query(
            `INSERT INTO "user" (id, "firstName", "lastName", "isActive") VALUES ($1, $2, $3, $4) RETURNING *`,
            [randomUUID(), user.firstName, user.lastName, user.isActive],
        ).then((result) => result[0] as User);
    }

    async remove(id: string): Promise<void> {
        await this.usersRepository.delete(id);
    }
}
