import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { PlantItemComponent } from './plant-item/plant-item.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    ShopComponent,
    PlantItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
