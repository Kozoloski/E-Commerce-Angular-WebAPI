import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Plant } from '../shared/models/plant';
import { Category } from '../shared/models/category';
import { Type } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
 baseUrl = 'http://localhost:5210/api/';

  constructor(private http: HttpClient) { }

  getPlants(categoryId?: number, typeId?: number, sort?: string) {
    let params = new HttpParams();

    if(categoryId) params = params.append('categoryId', categoryId);
    if(typeId) params = params.append('typeId', typeId);
    if(sort) params = params.append('sort', sort);

    return this.http.get<Pagination<Plant[]>>(this.baseUrl + 'plants', {params});
  }


  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'plants/categories');
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + 'plants/types');
  }
}


