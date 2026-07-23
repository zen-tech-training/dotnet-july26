import { Component } from '@angular/core';

@Component({
  selector: 'app-binding-demo',
  standalone:true,
  imports: [],
  templateUrl: './binding-demo.html',
  styleUrl: './binding-demo.scss',
})
export class BindingDemo {
  // const title: string = "C";
  title = "OPS";
  isDisabled = false;  //Property Binding

  imgHeight = "50%"; //Units - em, rem, cm, %, px

}
