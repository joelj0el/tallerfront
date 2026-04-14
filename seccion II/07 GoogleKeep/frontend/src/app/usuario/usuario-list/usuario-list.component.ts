import { CommonModule } from "@angular/common";
import { Component, inject, OnInit } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { DatePickerModule } from "primeng/datepicker";
import { TableModule } from "primeng/table";
import { UsuarioModel } from "../shared/usuario.model";
import { ButtonModule } from "primeng/button";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { ConfirmationService } from "primeng/api";
import { ToastModule } from "primeng/toast";

@Component({
    selector: 'app-usuario-list',
    imports: [
        CommonModule,
        DatePickerModule,
        FormsModule,
        TableModule,
        ButtonModule,
        ConfirmDialogModule,
        // ToastModule
    ],
    providers: [ConfirmationService],
    templateUrl: './usuario-list.component.html',
})
export class UsuarioListComponent implements OnInit {
    date: Date = new Date();
    dataUsuarios: UsuarioModel[] = [];

    private confirmationService = inject(ConfirmationService);

    ngOnInit(): void {
        // throw new Error("Method not implemented.");
        this.dataUsuarios = [
            {
                id: 1,
                name: 'John Doe',
                email: 'john.doe@example.com',
                updated_at: new Date()
            },
            {
                id: 2,
                name: 'Jane Smith',
                email: 'jane.smith@example.com',
                updated_at: new Date()
            }

        ];        
    }

    updateUsuario(data: UsuarioModel) {
        console.log('Update usuario', data);
    }

    deleteUsuario(data: UsuarioModel, event: Event) {
        console.log('Delete usuario', data);
        this.confirmationService.confirm({
            target: event.target as EventTarget,
            message: `Esta seguro de eliminar este registro? ${data.name}`,
            header: 'Eliminar Usuario!',
            icon: 'pi pi-info-circle',
            rejectLabel: 'Cancel',
            rejectButtonProps: {
                label: 'Cancel',
                severity: 'secondary',
                outlined: true
            },
            acceptButtonProps: {
                label: 'Delete',
                severity: 'danger'
            },
        
            accept: () => {
                // this.messageService.add({ severity: 'info', summary: 'Confirmed', detail: 'Record deleted' });
            },
            reject: () => {
                // this.messageService.add({ severity: 'error', summary: 'Rejected', detail: 'You have rejected' });
            }
        });
    }

    confirm2(event: Event) {
        
    }
}