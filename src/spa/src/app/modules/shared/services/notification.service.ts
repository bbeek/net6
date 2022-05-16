import { Injectable } from '@angular/core';
import { Notification } from './Notification';

@Injectable({
    providedIn: 'root',
})
export class NotificationService {
    public notifications: Notification[] = [];

    public add(message: string): void {
        const m = new Notification(message);
        this.notifications.push(m);
    }

    public clear(): void {
        this.notifications = [];
    }
}
