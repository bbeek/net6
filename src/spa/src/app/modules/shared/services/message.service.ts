import { Injectable } from '@angular/core';
import { Message } from './Message';

@Injectable({
    providedIn: 'root',
})
export class MessageService {
    public messages: Message[] = [];

    public add(message: string): void {
        const m = new Message(message);
        this.messages.push(m);
    }

    public clear(): void {
        this.messages = [];
    }
}
