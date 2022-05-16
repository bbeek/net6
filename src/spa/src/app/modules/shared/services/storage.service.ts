// import { Injectable } from '@angular/core';
// import { MessageService } from './message.service';

// @Injectable()
// export class StorageService {
//     private storage: any;

//     public constructor(private messageService: MessageService) {
//         this.storage = sessionStorage; // localStorage;
//     }

//     public retrieve(key: string): any {
//         const item = this.storage.getItem(key);
//         this.log(`Retreiving ${key} from storage.`);
//         if (item && item !== 'undefined') {
//             const itemFromStorage = this.storage.getItem(key) as string;

//             return JSON.parse(itemFromStorage);
//         }

//         return;
//     }

//     public store(key: string, value: any): void {
//         this.storage.setItem(key, JSON.stringify(value));
//         this.log(`Stored ${key} in storage`);
//     }

//     private log(message: string): void {
//         this.messageService.add(`Storage service : ${message}`);
//     }
// }
