import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { PlantItemComponent } from './plant-item/plant-item.component';



@NgModule({
  declarations: [
    ShopComponent,
    PlantItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
