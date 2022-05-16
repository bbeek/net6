import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Configuration } from '../models/Configuration';
import { MessageService } from './message.service';

@Injectable()
export class ConfigurationService {
    public config: BehaviorSubject<Configuration>;

    public constructor(private messageService: MessageService) {
        this.config = new BehaviorSubject<Configuration>(new Configuration(''));
        this.load();
    }

    private load(): void {
        this.config?.next(new Configuration(environment.apiUrl));
    }
    /**
     * Handle Http operation that failed.
     * Let the app continue.
     * @param operation - name of the operation that failed
     * @param result - optional value to return as the observable result
     */
    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead

            // TODO: better job of transforming error for user consumption
            this.log(`${operation} failed: ${error.message}`);

            // Let the app keep running by returning an empty result.
            return of(result as T);
        };
    }

    /** Log a HeroService message with the MessageService */
    private log(message: string): void {
        this.messageService.add(`Configuration Service: ${message}`);
    }
}
