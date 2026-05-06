import { Body, Controller, Get, Param, ParseIntPipe, Post } from '@nestjs/common';

@Controller('materia')
export class MateriaController {
  constructor() {}

  @Get()
  getAll() {
    return 'Hello World!';
  }
}