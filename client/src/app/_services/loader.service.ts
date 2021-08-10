import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {
  requestCount = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  loading(){
    this.requestCount++;
    this.spinnerService.show(undefined, {
      type: 'fire',
      bdColor: 'rgba(255,255,255,0.8)',
      color: '#00008b',
      size: "large",
    })
  }

  idle(){
    this.requestCount--;
    if(this.requestCount <= 0){
      this.requestCount = 0;
      this.spinnerService.hide();
    }
  }

}
