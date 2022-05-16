/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { ConsentInfoModel } from '../models/consent-info-model';
import { ConsentModel } from '../models/consent-model';
import { ConsumerConsentGivenCommand } from '../models/consumer-consent-given-command';
import { CreateUrlForCustomerCommand } from '../models/create-url-for-customer-command';

@Injectable({
  providedIn: 'root',
})
export class ConsentApiService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiV1ConsentIdGet
   */
  static readonly ApiV1ConsentIdGetPath = '/api/v1/consent/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1ConsentIdGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1ConsentIdGet$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<ConsentInfoModel>> {

    const rb = new RequestBuilder(this.rootUrl, ConsentApiService.ApiV1ConsentIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConsentInfoModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1ConsentIdGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1ConsentIdGet(params: {
    id: string;
  }): Observable<ConsentInfoModel> {

    return this.apiV1ConsentIdGet$Response(params).pipe(
      map((r: StrictHttpResponse<ConsentInfoModel>) => r.body as ConsentInfoModel)
    );
  }

  /**
   * Path part for operation apiV1ConsentIdDelete
   */
  static readonly ApiV1ConsentIdDeletePath = '/api/v1/consent/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1ConsentIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1ConsentIdDelete$Response(params: {
    id: string;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ConsentApiService.ApiV1ConsentIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1ConsentIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiV1ConsentIdDelete(params: {
    id: string;
  }): Observable<void> {

    return this.apiV1ConsentIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiV1ConsentPut
   */
  static readonly ApiV1ConsentPutPath = '/api/v1/consent/';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1ConsentPut()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  apiV1ConsentPut$Response(params: {
    body: ConsumerConsentGivenCommand
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, ConsentApiService.ApiV1ConsentPutPath, 'put');
    if (params) {
      rb.body(params.body, 'application/json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1ConsentPut$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  apiV1ConsentPut(params: {
    body: ConsumerConsentGivenCommand
  }): Observable<void> {

    return this.apiV1ConsentPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiV1ConsentPost
   */
  static readonly ApiV1ConsentPostPath = '/api/v1/consent/';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiV1ConsentPost()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  apiV1ConsentPost$Response(params: {
    body: CreateUrlForCustomerCommand
  }): Observable<StrictHttpResponse<ConsentModel>> {

    const rb = new RequestBuilder(this.rootUrl, ConsentApiService.ApiV1ConsentPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ConsentModel>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiV1ConsentPost$Response()` instead.
   *
   * This method sends `application/json` and handles request body of type `application/json`.
   */
  apiV1ConsentPost(params: {
    body: CreateUrlForCustomerCommand
  }): Observable<ConsentModel> {

    return this.apiV1ConsentPost$Response(params).pipe(
      map((r: StrictHttpResponse<ConsentModel>) => r.body as ConsentModel)
    );
  }

}
