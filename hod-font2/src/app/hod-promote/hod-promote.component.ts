import { Component, OnInit, Inject, Input, Output } from '@angular/core';

import { EventEmitter } from '@angular/core';

import {
  Load
} from '../_models/groups-models';


export interface StateGroup {
  letter: string;
  names: string[];
}
export const _filter = (opt: string[], value: string): string[] => {
  const filterValue = value.toLowerCase();

  return opt.filter(item => item.toLowerCase().indexOf(filterValue) === 0);
};

@Component({
  selector: 'app-hod-promote',
  templateUrl: './hod-promote.component.html',
  styleUrls: ['./hod-promote.component.css']
})
export class HodPromoteComponent implements OnInit {

  @Input('load') load: Load;

  @Output("onPromote") onPromote: EventEmitter<any> = new EventEmitter();


  constructor(
  ) { }

  ngOnInit(): void {
    console.log(this.load);
    console.log('init');
  }

  ngOnChange(): void {
    console.log(this.load);
    console.log('changed');
  }

  /// закрытие формы и отправка полученных данных
  closeform() {
    // console.log('selectedRec', this.selectedRec);
    // console.log('promotionData', this.promotionData);

    // //console.log('to push - 0', this.mappedPromotionData[0].control.value);
    // //console.log('to push - 1', this.mappedPromotionData[1].control.value);

    // let body_ = [];
    // for (var i in this.mappedPromotionData) {

    //   let result = this.search(this.mappedPromotionData[i].control.value, this.options);
    //   console.log(`${this.mappedPromotionData[i]} -- ${result}`);

    //   body_.push(
    //     {
    //       blockRec: this.mappedPromotionData[i].data.blockrecs_id_blockRec,
    //       typeSubject: this.mappedPromotionData[i].data.typeSubject,
    //       id_employee: result
    //     }
    //   );

    // }

    // // 1 step - done
    // //if (this.mappedPromotionData[0].control.value != null) {
    // //  let result0 = this.search(this.mappedPromotionData[0].control.value, this.options);
    // //  console.log('res0-', result0);
    // //  body_.push(
    // //    {
    // //      blockRec: this.mappedPromotionData[0].data.blockrecs_id_blockRec,
    // //      typeSubject: this.mappedPromotionData[0].data.typeSubject,
    // //      id_teacherCath: result0
    // //    }
    // //  );
    // //}
    // //if (this.mappedPromotionData[1].control.value != null) {
    // //  let result1 = this.search(this.mappedPromotionData[1].control.value, this.options);
    // //  console.log('res1-', result1);
    // //  body_.push(
    // //    {
    // //      blockRec: this.mappedPromotionData[1].data.blockrecs_id_blockRec,
    // //      typeSubject: this.mappedPromotionData[1].data.typeSubject,
    // //      id_teacherCath: result1
    // //    }
    // //  );
    // //}

    // this.http.postUpdateTeacherLoad(body_)
    //   .subscribe(event => {
    //     console.log(event);
    //   });

    // document.getElementById('popup-selector').hidden = true;
    // // this.numberOfInput = -1;

    // console.log('output body_', body_);
    // this.onPromote.emit(body_);

  }

  /// простое скрытие компонента (без отправки данных)
  justcloseform() {
    document.getElementById('popup-selector').hidden = true;
    // this.numberOfInput = -1;
  }

}
