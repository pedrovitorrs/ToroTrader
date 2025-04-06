import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import * as AuthActions from '../store/auth.actions';
import { CommonModule } from '@angular/common';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule,
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private store: Store) {
    this.loginForm = this.fb.group({
      accountId: ['', Validators.required],
      clientId: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const { accountId, clientId } = this.loginForm.value;
      this.store.dispatch(AuthActions.login({ accountId, clientId }));
    }
  }
}
