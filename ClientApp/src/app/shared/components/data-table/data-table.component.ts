import {Component, EventEmitter, Input, Output, QueryList, SimpleChanges, TemplateRef} from '@angular/core';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent {
  @Input() dataSource!: any[];
  @Input() colsTemplate!: QueryList<TemplateRef<any>>;
  @Input() headers!: string[];
  @Input() showHeaders: boolean;
  @Input() showNumbers: boolean = false;
  @Input() styleType: string = 'one';

  @Input() count: number;
  @Input() itemsPerPage: any;
  @Input() resetPaging = false;
  @Output() pageChanged = new EventEmitter<any>();
  page = 1;
  changePage(pageNumber: number): void {
    window.scroll({ top: 0, behavior: "smooth" });
    this.page = pageNumber;
    this.pageChanged.emit(pageNumber);
    // let url = this.router.url.includes('?') ? this.router.url.substring(0, this.router.url.indexOf('?')) : this.router.url;
    // this.router.navigateByUrl(`${url}?pageIndex=${pageNumber}`);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes) {
      if (changes.resetPaging && changes.resetPaging.currentValue === true) {
        this.page = 1;
      }
    }
  }
}
