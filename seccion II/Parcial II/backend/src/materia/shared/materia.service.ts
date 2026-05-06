import { Injectable, NotFoundException } from "@nestjs/common";
import { Repository } from "typeorm";
import { Materia } from "../model/materia.model";
import { InjectRepository } from "@nestjs/typeorm";
import { MateriaDto } from "../dto/materia.dto";

@Injectable()
export class MateriaService {
    constructor(
        @InjectRepository(Materia)
        private readonly repository: Repository<Materia>
    ) {}

    getAll() {
        return this.repository.find();
    }

    getById(id: number) {
        var data = this.repository.findOneBy({id: id});
        return data;
    }

    async save(data: MateriaDto) {
        if(data.id != undefined && data.id != null && data.id != 0) {
            const materia = await this.repository.findOneBy({id: data.id});
            if(!materia) throw new Error(`Registro con id ${data.id} no encontrado`);

            await this.repository.update({id: data.id}, data);
            return 'Se actualizo correctamente!!!';
        } else {
            await this.repository.save(data);
            return 'Se guardo correctamente!!!';
        }
    }

    async delete(id: number) {
        var data = await this.findById(id);
        if (!data) throw new NotFoundException(`Registro con id ${id} no encontrado`);
        await this.repository.delete({id});
        return 'Se elimino correctamente!!!';
    }

    async findById(id: number) {
        const entity = await this.repository.findOne({
            where: { id }
        });

        if(!entity) throw new NotFoundException(`Registro con id ${id} no encontrado`);

        return entity;
    }
}