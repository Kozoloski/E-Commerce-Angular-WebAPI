import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { Plant } from 'src/app/shared/models/plant';

@Component({
  selector: 'app-plant-details',
  templateUrl: './plant-details.component.html',
  styleUrls: ['./plant-details.component.scss']
})
export class PlantDetailsComponent implements OnInit {
  plant?: Plant;
  
  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.loadPlant();
  }

  loadPlant() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
     if (id) this.shopService.getPlant(+id).subscribe({
      next: plant => this.plant = plant,
      error: error => console.log(error)
     });
  }

}
