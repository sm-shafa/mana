import {Component, OnInit, QueryList, TemplateRef, ViewChildren} from '@angular/core';
import {ManaService} from "../shared/services/mana.service";
import {GetPage, IPage} from "../shared/Model/mana-model";

@Component({
  selector: 'app-mana',
  templateUrl: './mana.component.html',
  styleUrls: ['./mana.component.css']
})
export class ManaComponent implements OnInit {
  public categoryList: any = [];
  public filters = new GetPage();
  public showHeaders = true;
  public headers = [
    'Id',
    'Name'
  ];
  @ViewChildren('col') public cols!: QueryList<TemplateRef<any>>

  constructor(
    private manaService: ManaService,
  ) {
    this.filters.pageSize = 5;
    this.filters.pageIndex = 1;
  }

  public ngOnInit(): void {
    this.getData();
  }

  public getData(): void {


    this.manaService.getCategories(this.filters).toPromise().then((res) => {
      this.categoryList = res;
    }, err => console.log(err.errors));
  }

}
