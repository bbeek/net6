/* tslint:disable */
/* eslint-disable */
import { ConsentAccountInfo } from './consent-account-info';
export interface ConsentInfoModel {
  accounts?: null | Array<ConsentAccountInfo>;
  bankName?: null | string;
  consentedOn?: null | string;
  expiresOn?: null | string;
  status?: null | string;
}
