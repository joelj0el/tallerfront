import { registerAs } from "@nestjs/config";
import { TypeOrmModuleOptions } from "@nestjs/typeorm";
import { Materia } from "src/materia/model/materia.model";

export default registerAs(
    'orm.config',
    (): TypeOrmModuleOptions => ({
        type: 'postgres',
        host: '127.0.0.1',
        port: 5222,
        username: 'postgres',
        password: '1844',
        database: 'impocruz-db',
        entities: [Materia],
        synchronize: true,
    }),
);