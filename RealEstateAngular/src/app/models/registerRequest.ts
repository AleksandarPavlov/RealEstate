export class RegisterRequest {
  constructor(
    public username: string,
    public password: string,
    public fullName: string,
    public contactNumber: string,
    public emailAddress: string,
    public socialMediaLink: string
  ) {}
}
