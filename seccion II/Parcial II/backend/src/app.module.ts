import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import ormConfig from './config/orm.config';
import { TypeOrmModule } from '@nestjs/typeorm';
import { ConfigModule } from '@nestjs/config';
import { MateriaService } from './materia/shared/materia.service';
import { Materia } from './materia/model/materia.model';
import { MateriaController } from './materia/shared/materia.controller';

@Module({
  imports: [
    ConfigModule.forRoot({
      isGlobal: true,
      load: [ormConfig],
      expandVariables: true,
    }),
    TypeOrmModule.forRootAsync({
      useFactory: ormConfig
    }),
    TypeOrmModule.forFeature([Materia])
  ],
  controllers: [
    AppController, 
    MateriaController
  ],
  providers: [
    MateriaService
  ],
})
export class AppModule {}
