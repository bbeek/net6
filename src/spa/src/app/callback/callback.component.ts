import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { map, Observable } from 'rxjs';
import { ApiConfiguration } from '../api/api-configuration';
import { ConsentApiService } from '../api/services';
import { ConfigurationService } from '../modules/shared/services/configuration.service';
import { NotificationService } from '../modules/shared/services/notification.service';

@Component({
    selector: 'app-callback',
    templateUrl: './callback.component.html',
    styleUrls: ['./callback.component.scss'],
})
export class CallbackComponent implements OnInit {
    private consentCollectionObservable: Observable<string | null> | undefined;
    private requestIdObservable: Observable<string | null> | undefined;
    private consentCountObservable: Observable<string | null> | undefined;

    public constructor(
        private route: ActivatedRoute,
        private consentApiService: ConsentApiService,
        private notificationService: NotificationService,
        private router: Router,
        private apiConfiguration: ApiConfiguration,
        private configurationService: ConfigurationService
    ) {}

    public ngOnInit(): void {
        this.consentCollectionObservable = this.route.queryParamMap.pipe(
            map((params: ParamMap) => params.get('ConsentCollectionId'))
        );
        this.requestIdObservable = this.route.queryParamMap.pipe(map((params: ParamMap) => params.get('RequestId')));
        this.consentCountObservable = this.route.queryParamMap.pipe(
            map((params: ParamMap) => params.get('ConsentCount'))
        );
        this.consentCollectionObservable.subscribe((param) => {
            this.configurationService.config.subscribe((configuration) => {
                this.apiConfiguration.rootUrl = configuration.paymentInformationServicesUrl;
                const consentCollectionId = param ?? '';

                const params = {
                    body: {
                        externalId: consentCollectionId,
                        requestorId: '359927e7-5679-46ea-b09d-4886da1494de',
                    },
                };

                this.consentApiService.apiV1ConsentPut(params).subscribe({
                    next: () => this.navigateToThankYou(),
                    error: (e) => this.notificationService.add(`${e.message}`),
                });
            });
        });

        // this.requestIdObservable.subscribe((param) => {
        //     this.requestId = param ?? '';
        // });

        // this.consentCountObservable.subscribe((param) => {
        //     this.consentCount = Number(param);
        // });
    }
    private navigateToThankYou(): void {
        this.router.navigate(['thankyou']);
    }
}
