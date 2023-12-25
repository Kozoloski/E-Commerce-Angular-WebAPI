import { Component, OnInit } from '@angular/core';
import { Plant } from '../shared/models/plant';
import { ShopService } from './shop.service';
import { Category } from '../shared/models/category';
import { Type } from '../shared/models/type';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  plants: Plant[] = [];
  categories: Category[] = [];
  types: Type[] = [];
  categoryIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = 'name';
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'},
  ]

  constructor(private shopService: ShopService) {}
  
  
  ngOnInit(): void {
    this.getPlants();
    this.getCategories();
    this.getTypes();
  }

  getPlants() {
    this.shopService.getPlants(this.categoryIdSelected, this.typeIdSelected, this.sortSelected).subscribe({
      next: response => this.plants = response.data,
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
  this.categoryIdSelected = categoryId;
  this.getPlants();
}

onTypeSelected(typeId: number) {
  this.typeIdSelected = typeId;
  this.getPlants();
}

onSortSelected(event: any) {
  this.sortSelected = event.target.value;
  this.getPlants();
}

}
