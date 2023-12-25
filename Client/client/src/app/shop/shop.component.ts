import { Component, OnInit } from '@angular/core';
import { Plant } from '../shared/models/plant';
import { ShopService } from './shop.service';
import { Category } from '../shared/models/category';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  plants: Plant[] = [];
  categories: Category[] = [];
  types: Type[] = [];
  shopParams = new ShopParams();
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ];
  totalCount = 0;

  constructor(private shopService: ShopService) {}
  
  
  ngOnInit(): void {
    this.getPlants();
    this.getCategories();
    this.getTypes();
  }

  getPlants() {
    this.shopService.getPlants(this.shopParams).subscribe({
      next: response => {
        this.plants = response.data
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)     
    })
  }

  getCategories() {
    this.shopService.getCategories().subscribe({
      next: response => this.categories = [{id: 0, name: 'All'}, ...response],
      error: error => console.log(error)     
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: response => this.types = [{id: 0, name: 'All'}, ...response],
      error: error => console.log(error)     
    })
  }

onCategorySelected(categoryId: number) {
  this.shopParams.categoryId = categoryId;
  this.getPlants();
}

onTypeSelected(typeId: number) {
  this.shopParams.typeId = typeId;
  this.getPlants();
}

onSortSelected(event: any) {
  this.shopParams.sort = event.target.value;
  this.getPlants();
}

onPageChanged(event: any) {
  if(this.shopParams.pageNumber !== event.page) {
    this.shopParams.pageNumber = event.page;
    this.getPlants();
  }
}

}
