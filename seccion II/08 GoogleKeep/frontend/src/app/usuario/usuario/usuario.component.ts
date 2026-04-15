import { CommonModule } from "@angular/common";
import { Component, EventEmitter, inject, Output, signal } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { DatePickerModule } from "primeng/datepicker";
import { TableModule } from "primeng/table";
import { ButtonModule } from "primeng/button";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { BasicService } from "@/app/service/basic.service";
import { DialogModule } from "primeng/dialog";
import { InputTextModule } from "primeng/inputtext";
import { UsuarioModel } from "../shared/usuario.model";

@Component({
    selector: 'app-usuario',
    standalone: true,
    imports: [
        CommonModule,
        DatePickerModule,
        FormsModule,
        TableModule,
        ButtonModule,
        ConfirmDialogModule,
        // ToastModule
        DialogModule,
        InputTextModule
    ],
    providers: [
        BasicService
    ],
    templateUrl: './usuario.component.html',
})
export class UsuarioComponent {
    http = inject(BasicService);
    visible = signal<boolean>(false);
    entity = signal<UsuarioModel>(new UsuarioModel());
    @Output() messageEvent = new EventEmitter<boolean>();

    load(entityId: number){
        this.onDialogVisibleChange(true);
    }

    saveMethod() {
        // console.warn('Entity to save', this.entity());
        // this.closeDialog();
        this.http.basePost('usuariocontroller/save', this.entity()).subscribe(
            response => {
                console.warn('Save response', response);
                this.closeDialog();
                this.messageEvent.emit();
            },
            error => console.error(error)
        );
    }

    onDialogVisibleChange(value: boolean): void {
        this.visible.set(value);
    }

    closeDialog(): void {
        this.visible.set(false);
    }
}