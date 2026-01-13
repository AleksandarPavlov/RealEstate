import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const isLoggedIn = authService.isLoggedIn();
  const allowedRoles = route.data?.['roles'] as string[] | undefined;

  if (!isLoggedIn) {
    router.navigate(['/login']);
    return false;
  }

  if (!allowedRoles || allowedRoles.length === 0) {
    return true;
  }

  const userRole = authService.getRole();

  if (userRole && allowedRoles.includes(userRole)) {
    return true;
  }

  router.navigate(['/login']);
  return false;
};
