export interface ICategory {
  id: number;
  name: string;
}

export interface IPage {
  pageIndex?: number;
  pageSize?: number;
  filter?: string | undefined;
  sorting?: string | undefined;
}

export class GetPage implements IPage {
  pageIndex?: number;
  pageSize?: number;
  filter?: string | undefined;
  sorting?: string | undefined;


  constructor(data?: IPage) {
    if (data) {
      for (var property in data) {
        if (data.hasOwnProperty(property))
          (<any>this)[property] = (<any>data)[property];
      }
    }
  }
}
