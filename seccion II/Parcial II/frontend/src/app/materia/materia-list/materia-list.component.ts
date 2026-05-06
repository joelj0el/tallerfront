import { CommonModule } from "@angular/common";
import { Component, OnInit} from "@angular/core";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { ConfirmationService } from "primeng/api";
import { BasicService } from "@/app/service/basic.service";

@Component({
    standalone: true,
    imports: [
        CommonModule,
        ConfirmDialogModule
    ],
    providers: [
        ConfirmationService, 
        BasicService
    ],
    templateUrl: './materia-list.component.html',
})
export class MateriaListComponent implements OnInit {

    constructor() {
    }

    ngOnInit(): void {
    }
}