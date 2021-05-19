import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-yes-no-modal',
  templateUrl: './yes-no-modal.component.html',
  styleUrls: ['./yes-no-modal.component.css']
})
export class YesNoModalComponent implements OnInit {

  @ViewChild('yesNoModal', { static: false }) public yesNoModal: ModalDirective;

  @Input() private type = 'info';
  @Input() private title = '';
  @Input() private body = '';
  @Input() private yesBtnText = 'Да';
  @Input() private noBtnText = 'Нет';

  constructor() { }

  ngOnInit(): void {
  }

  public showAsync(data = null): Promise<any> {
    return new Promise<any>((resolve, reject) => {
      this.yesNoModal.show();
      this.onYesClick = () => {
        this.yesNoModal.hide();
        resolve(data);
      };
      this.onNoClick = () => {
        this.yesNoModal.hide();
        reject(data);
      };
    });
  }

  private onYesClick(): any { }
  private onNoClick(): any { }

}
