import { HttpClient } from '@angular/common/http';
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

  getPlants() {
    return this.http.get<Pagination<Plant[]>>(this.baseUrl + 'plants?pageSize=50');
  }

  getPlant(id: number) {
    return this.http.get<Plant>(this.baseUrl + 'products/'+ id);
  }

  getCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<Type[]>(this.baseUrl + 'products/types');
  }
}


