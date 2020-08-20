export interface IService {
  title: string;
  description: string;
  skills: string[];

  price: number;

  /// سرويس گيرنده يادهنده
  // public ServiceType ServiceType { get; set; }

  /// ایا با ایمیل به خدمت دهتده فرستاده شود
  isSendByEmail: boolean;

  /// ایا با نوتیفیکیشن به خدمت دهتده فرستاده شود
  isSendByNOtification: boolean;

  /// ایا با اس ام اس به خدمت دهتده فرستاده شود
  isSendBySms: boolean;

  /// آيا توافقيست
  isAgreement: boolean;

  // public string UserId { get; set; }

  cityId?: number;

  categoryId?: number;
}

export interface ISelectInfo {
  cities: { id: string; name: string }[];
  categories: { id: string; name: string }[];
  monyUnits: { id: string; name: string }[];
}
