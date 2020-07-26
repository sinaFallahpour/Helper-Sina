import { ProjectStatus } from './enums/projectStatus'

export interface IProjectList {
    /// ایدی پروژه
    Id: number;
    /// عنوان پروژه 
    Name: string;
    ///  وضعیت پروژه 
    Status: ProjectStatus;
    /// قیمت پروژه 
    cost: number;
    ///  سهم شرکت 
    CompanyShare: number;
    ///مالیات 
    Tax: number;
    ///  آیا تسکی ای بهش اساین شده؟ 
    HasTask: boolean;
    /// تعداد  آیتمهای موجود
    Count: number
}
      