import { Routes } from '@angular/router';
import { AppLayout } from './app/layout/component/app.layout';
import { MateriaListComponent } from './app/materia/materia-list/materia-list.component';

export const appRoutes: Routes = [
    {
        path: '',
        component: AppLayout,
        children: [
            { path: '', component: MateriaListComponent}
        ]
    },
    { path: '**', redirectTo: '' }
];
