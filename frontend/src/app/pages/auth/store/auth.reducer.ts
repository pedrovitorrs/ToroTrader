import { createReducer, on } from '@ngrx/store';
import * as AuthActions from './auth.actions';

export interface AuthState {
  token: string | null;
  expiresIn: string | null;
  error: any;
}

export const initialState: AuthState = {
  token: null,
  expiresIn: null,
  error: null,
};

export const authReducer = createReducer(
  initialState,
  on(AuthActions.loginSuccess, (state, { token, expiresIn }) => ({
    ...state,
    token,
    expiresIn,
    error: null,
  })),
  on(AuthActions.loginFailure, (state, { error }) => ({
    ...state,
    error,
  })),
  on(AuthActions.logout, () => initialState)
);