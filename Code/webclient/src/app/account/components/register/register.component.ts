import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() registerCanceled = new EventEmitter();
  model: any = {};

  constructor(private accountService: AccountService)
  { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model)
    .subscribe(response => {
      this.cancel();
    })
  }

  cancel() {
    this.registerCanceled.emit(false);
  }
}
