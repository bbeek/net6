import { IConfiguration } from './configuration.model';

export class Configuration implements IConfiguration {
    public constructor(private rootUrl: string) {}

    public get paymentInformationServicesUrl(): string {
        return `${this.rootUrl}/c`;
    }
}
