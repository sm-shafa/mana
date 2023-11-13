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
  public productList: any = [];
  public filters = new GetPage();
  public showHeaders = true;
  public categoryHeaders = [
    'Id',
    'Name'
  ];

  public productHeaders = [
    'Id',
    'Name',
    'categoryId'
  ];
  @ViewChildren('categoryCol') public categoryCols!: QueryList<TemplateRef<any>>
  @ViewChildren('productCol') public productCols!: QueryList<TemplateRef<any>>

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

    this.manaService.getProducts(this.filters).toPromise().then((res) => {
      this.productList = res;
    }, err => console.log(err.errors));
  }

}
