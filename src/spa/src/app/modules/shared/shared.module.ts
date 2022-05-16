/* eslint-disable @typescript-eslint/explicit-member-accessibility */
import { ModuleWithProviders, NgModule } from '@angular/core';
// Services
import { ConfigurationService } from './services/configuration.service';
import { MessageService } from './services/message.service';

@NgModule({
    imports: [],
    declarations: [],
    exports: [],
})
export class SharedModule {
    static forRoot(): ModuleWithProviders<SharedModule> {
        return {
            ngModule: SharedModule,
            providers: [
                // Providers
                ConfigurationService,
                //                StorageService,
                MessageService,
            ],
        };
    }
}
