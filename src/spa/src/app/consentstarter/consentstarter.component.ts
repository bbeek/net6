/* eslint-disable @typescript-eslint/unbound-method */
import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ApiConfiguration } from '../api/api-configuration';
import { ConsentModel } from '../api/models';
import { ConsentApiService } from '../api/services';
import { ConfigurationService } from '../modules/shared/services/configuration.service';
import { MessageService } from '../modules/shared/services/message.service';
import { NotificationService } from '../modules/shared/services/notification.service';

@Component({
    selector: 'app-consentstarter',
    templateUrl: './consentstarter.component.html',
    styleUrls: ['./consentstarter.component.scss'],
})
export class ConsentstarterComponent implements OnInit {
    public consentWizard = '';
    public consentForm: FormGroup;

    private _step = 1;
    private _complete = false;

    private Id = '';

    public constructor(
        private route: ActivatedRoute,
        private messageService: MessageService,
        private formBuilder: FormBuilder,
        private consentApiService: ConsentApiService,
        private notificationService: NotificationService,
        private apiConfiguration: ApiConfiguration,
        private configurationService: ConfigurationService,
        @Inject(DOCUMENT) private document: Document
    ) {
        this.consentForm = this.formBuilder.group({
            firstname: ['', Validators.required],
            email: ['', Validators.email],
            telephone: '',
            profession: '',
        });
    }

    public get step(): number {
        return this._step;
    }

    public get complete(): boolean {
        return this._complete;
    }
    public get progress(): number {
        return (this._step / 3) * 100;
    }
    public ngOnInit(): void {
        this.Id = this.route.snapshot.paramMap.get('id') ?? '';
        this.log(this.Id);
    }

    public dec(): void {
        this._step--;
    }
    public inc(): void {
        this._step++;
    }

    public submit(): void {
        const form = this.consentForm;
        if (form.valid) {
            const params = {
                body: { requestId: this.Id, email: this.consentForm.controls['email'].value },
            };

            this.configurationService.config.subscribe((configuration) => {
                this.apiConfiguration.rootUrl = configuration.paymentInformationServicesUrl;
                this.consentApiService.apiV1ConsentPost(params).subscribe({
                    next: (registrationStateModel) => this.navigateToConsentWizard(registrationStateModel),
                    error: (e) => this.notificationService.add(`${e.message}`),
                });
            });
        }
    }

    private navigateToConsentWizard(consentModel: ConsentModel): void {
        this.log(`Process state: ${consentModel.urlForCustomer}`);
        const stringUrl = consentModel.urlForCustomer ?? '';
        const url = new URL(stringUrl);

        this.consentForm.reset();
        this._complete = true;

        // Go to Invers consent wizard
        this.document.location.href = url.href;
    }

    private log(message: string | any): void {
        this.messageService.add(`Consentstarter component: ${message}`);
    }
}
