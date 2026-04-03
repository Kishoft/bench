import { IsBoolean, IsString } from "class-validator";


export class CreateUserDTO {
    @IsString()
    firstName: string;
    @IsString()
    lastName: string;
    @IsBoolean()
    isActive: boolean;
}