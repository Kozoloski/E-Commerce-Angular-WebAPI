import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Plant } from '../shared/models/plant';
import { Category } from '../shared/models/category';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
 baseUrl = 'http://localhost:5210/api/';

  constructor(private http: HttpClient) { }

  getPlants(shopParams: ShopParams) {
    let params = new HttpParams();

    if(shopParams.categoryId > 0) params = params.append('categoryId', shopParams.categoryId);
    if(shopParams.typeId) params = params.append('typeId', shopParams.typeId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if (shopParams.search) params = params.append('search', shopParams.search);

    return this.http.get<Pagination<Plant[]>>(this.baseUrl + 'plants', {params});
  }


  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'plants/categories');
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + 'plants/types');
  }
}


