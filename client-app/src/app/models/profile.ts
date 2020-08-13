import { siteLanguage } from './enums/siteLanguage'
import { userGender } from './enums/userGender'
import { userMarriedType } from './enums/userMarriedType'

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
  gender: userGender;
  marriedType: userMarriedType;
  phone: string;
  city: string;
  educationHistryDTO: IEducationHistry;
  workExperienceDTO: IWorkExperienceDTO;
  currentUser: IUser | null;
}


export interface IEducationHistry {
  maghTa: string;
  univercityName: string;
  enterDate: string;
  exitDate: string;

}

export interface IWorkExperienceDTO {
  companyName: string;
  semat: string;
  enterDate: string;
  exitDate: string;
  descriptions: string;
}

//................................... REQUEST....................................