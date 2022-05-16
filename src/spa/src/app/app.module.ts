import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ApiModule } from './api/api.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CallbackComponent } from './callback/callback.component';
import { ConsentstarterComponent } from './consentstarter/consentstarter.component';
import { LandingComponent } from './landing/landing.component';
import { MessagesComponent } from './messages/messages.component';
import { SharedModule } from './modules/shared/shared.module';
import { NotificationComponent } from './notification/notification.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SafePipe } from './safe.pipe';
import { ThankYouComponent } from './thank-you/thank-you.component';

@NgModule({
    declarations: [
        AppComponent,
        MessagesComponent,
        LandingComponent,
        ConsentstarterComponent,
        SafePipe,
        NotificationComponent,
        CallbackComponent,
        PageNotFoundComponent,
        ThankYouComponent,
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        SharedModule.forRoot(),
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        ApiModule,
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
