import { siteLanguage } from './enums/siteLanguage'
import { IUser } from './user'


//................................... RESPONSE....................................

//Response of  get Profile
export interface IProfile {
  id: string
  userName: string
  email: string
  phone: string
  /// زبان سایت
  siteLanguage: siteLanguage
  ///نام بانک
  bankName: string
  /// نام صاحب حساب بانک
  accountOwner: string
  /// شماره کارت
  cardNumber: string
  /// شماره شبا
  shabaNumber: string
  /// شماره ویزا یا مسترکارد
  visaNumber: string
}


//Response of changeProfile
export interface IChangePersonalInfoRE {
  Id: string;
  userName: string;
  email: string;
  phone: string;
  /// زبان سایت
  siteLanguage: siteLanguage;
  currentUser: IUser;

}


//Response of ChangeBank
export interface IChangeBankRE {
  Id: string
  ///نام بانک
  bankName: string
  /// نام صاحب حساب بانک
  accountOwner: string
  /// شماره کارت
  cardNumber: string
  /// شماره شبا
  shabaNumber: string
  /// شماره ویزا یا مسترکارد
  visaNumber: string
  currentUser: IUser
}




//................................... REQUEST....................................

//Request of changeProfile
export interface IChangePasswordRQ {
  oldPassword: string
  newPassword: string
}

//Request of changeProfile
export interface IChangePrsonalInfoRQ {
  userName: string;
  email: string;
  phone: string;
  /// زبان سایت
  siteLanguage: siteLanguage;
  currentUser: IUser;

}


//Request of changeProfile
export interface IChangeBankRQ {

  ///نام بانک
  bankName: string

  /// نام صاحب حساب بانک
  accountOwner: string

  /// شماره کارت
  cardNumber: string

  /// شماره شبا
  shabaNumber: string


  /// شماره ویزا یا مسترکارد
  visaNumber: string

}



