import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { authgurdGurdGuard } from './authgurd-gurd-guard';

describe('authgurdGurdGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) =>
    TestBed.runInInjectionContext(() => authgurdGurdGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
