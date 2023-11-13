import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DataTableComponent} from "./components/data-table/data-table.component";
import {NgxPaginationModule} from "ngx-pagination";



@NgModule({
    declarations: [DataTableComponent],
    exports: [
        DataTableComponent
    ],
    imports: [
        CommonModule,
        NgxPaginationModule
    ]
})
export class SharedModule { }
