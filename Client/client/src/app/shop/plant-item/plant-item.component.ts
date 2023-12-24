import { Component, Input } from '@angular/core';
import { Plant } from 'src/app/shared/models/plant';

@Component({
  selector: 'app-plant-item',
  templateUrl: './plant-item.component.html',
  styleUrls: ['./plant-item.component.scss']
})
export class PlantItemComponent {
  @Input() plant?: Plant;
}
