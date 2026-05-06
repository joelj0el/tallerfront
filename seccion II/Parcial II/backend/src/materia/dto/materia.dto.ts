import { IsDate, IsEmail, IsNotEmpty, IsNumber, IsOptional, IsString, MaxLength, MinLength } from "class-validator";

export class MateriaDto {
    @IsOptional()
    @IsNumber()
    id?: number;

    @IsNotEmpty({message: 'El nombre es obligatorio'})
    @IsString()
    @MinLength(3, {message: 'El nombre debe tener al menos 3 caracteres'})
    @MaxLength(50, {message: 'El nombre no debe exceder los 50 caracteres'})
    nombre: string;

    @IsNumber()
    credito: number;

    @IsNumber()
    precio: number;

    @IsDate()
    created_at: Date;
}