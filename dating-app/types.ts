export interface User {
  id: number;
  username: string;
  email: string;
  knownAs: string;
  birthday: Date;
  gender: string;
  city: string;
  avatar : string;
}

export interface LoginInfor{
  username: string;
  password: string;
}