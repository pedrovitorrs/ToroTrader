import { createAction, props } from '@ngrx/store';

export const login = createAction(
  '[Auth] Login',
  props<{ accountId: string; clientId: string }>()
);

export const loginSuccess = createAction(
  '[Auth] Login Success',
  props<{ token: string; expiresIn: string }>()
);

export const loginFailure = createAction(
  '[Auth] Login Failure',
  props<{ error: any }>()
);

export const logout = createAction('[Auth] Logout');