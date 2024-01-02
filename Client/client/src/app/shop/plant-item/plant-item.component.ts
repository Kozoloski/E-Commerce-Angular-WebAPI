import { Component, Input } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { Plant } from 'src/app/shared/models/plant';

@Component({
  selector: 'app-plant-item',
  templateUrl: './plant-item.component.html',
  styleUrls: ['./plant-item.component.scss']
})
export class PlantItemComponent {
  @Input() plant?: Plant;

  constructor(private basketService: BasketService) { }

  addItemToBasket() {
    this.plant && this.basketService.addItemToBasket(this.plant);
  }
}
