import { PropertyStatus } from './propertyStatus.enum';

export class ChangePropertyStatusRequest {
  constructor(public status: PropertyStatus) {}
}
