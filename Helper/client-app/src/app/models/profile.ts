import { siteLanguage } from './enums/siteLanguage'
import { IUser } from './user'


//................................... RESPONSE....................................

//Response and request of  get Profile
export interface IProfileRE {
  id: string;
  userName: string;
  email: string;
  nickname: string;
  descriptions: string;
  birthdate: string;
  LanguageKnowing: string;
  IsMarid: boolean;
  phone: string;
  city:string;
  currentUser: IUser | null;
}

























public UserVM CurrentUser { get; set; }
























//................................... REQUEST....................................