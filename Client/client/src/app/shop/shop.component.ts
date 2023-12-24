import { Component, OnInit } from '@angular/core';
import { Plant } from '../shared/models/plant';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  plants: Plant[] = [];

  constructor(private shopService: ShopService) {}
  
  
  ngOnInit(): void {
    this.shopService.getPlants().subscribe({
      next: response => this.plants = response.data,
      error: error => console.log(error)     
    })
  }
}
