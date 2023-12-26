import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
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
  @ViewChild('search') searchTerm?: ElementRef;
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
  this.shopParams.pageNumber = 1;
  this.getPlants();
}

onTypeSelected(typeId: number) {
  this.shopParams.typeId = typeId;
  this.shopParams.pageNumber = 1;
  this.getPlants();
}

onSortSelected(event: any) {
  this.shopParams.sort = event.target.value;
  this.getPlants();
}

onPageChanged(event: any) {
  if(this.shopParams.pageNumber !== event) {
    this.shopParams.pageNumber = event;
    this.getPlants();
  }
}

onSearch() {
  this.shopParams.search = this.searchTerm?.nativeElement.value;
  this.shopParams.pageNumber = 1;
  this.getPlants();
}

onReset() {
  if(this.searchTerm) this.searchTerm.nativeElement.value = '';
  this.shopParams = new ShopParams();
  this.getPlants();
}

}
