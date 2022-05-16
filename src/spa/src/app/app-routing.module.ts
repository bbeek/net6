import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CallbackComponent } from './callback/callback.component';
import { ConsentstarterComponent } from './consentstarter/consentstarter.component';
import { LandingComponent } from './landing/landing.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ThankYouComponent } from './thank-you/thank-you.component';

const routes: Routes = [
    { path: '', redirectTo: '/landing', pathMatch: 'full' },
    { path: 'callback', component: CallbackComponent },
    { path: 'thankyou', component: ThankYouComponent },
    { path: 'startConsent/:id', component: ConsentstarterComponent },
    { path: 'landing', component: LandingComponent },
    { path: '**', component: PageNotFoundComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {}
