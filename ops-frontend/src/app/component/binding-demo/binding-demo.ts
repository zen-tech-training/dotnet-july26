import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-binding-demo',
  standalone:true,
  imports: [FormsModule],
  templateUrl: './binding-demo.html',
  styleUrl: './binding-demo.scss',
})
export class BindingDemo {
  // const title: string = "C";
  title = "OPS";
  isDisabled = false;  //Property Binding

  imgHeight = "50%"; //Units - em, rem, cm, %, px

  quantity = 0;
  
  incrementCounter(){
    this.quantity = this.quantity + 1;

    this.secondCounter.update(cur => cur + 1);

    console.log(this.quantity);
  }
  decrementCounter(){
    if(this.quantity>1){
      this.quantity = this.quantity - 1;
      this.secondCounter.update(cur => cur - 1);
    }
  }

  msgPost = "ppppppppppppppp";

  secondCounter = signal(0);




}
