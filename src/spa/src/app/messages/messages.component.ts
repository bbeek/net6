import { Component } from '@angular/core';
import { MessageService } from '../modules/shared/services/message.service';

@Component({
    selector: 'app-messages',
    templateUrl: './messages.component.html',
    styleUrls: ['./messages.component.scss'],
})
export class MessagesComponent {
    public constructor(public messageService: MessageService) {}
}
