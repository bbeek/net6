import { Component, OnInit } from '@angular/core';
import { MessageService } from './modules/shared/services/message.service';

/*
 * App Component
 * Top Level Component
 */
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
    public title = 'psdtweesite';

    private observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            const foreground = document.querySelector('.foreground');
            const background = document.querySelector('.background');

            if (entry.isIntersecting) {
                foreground?.classList.add('fade-in-from-top-animation');
                background?.classList.add('appear-animation');

                return; // if we added the class, exit the function
            }

            foreground?.classList.remove('fade-in-from-top-animation');
            background?.classList.remove('appear-animation');
        });
    });

    public constructor(private messageService: MessageService) {}
    /*
     */
    public ngOnInit(): void {
        this.setTheme();

        this.log('on init');

        // Tell the observer which elements to track
        const sectionElement = document.querySelector('main') as HTMLElement;
        this.observer.observe(sectionElement);
    }

    private setTheme(): void {
        // On page load or when changing themes, best to add inline in `head` to avoid FOUC
        const themeKey = 'theme';
        if (
            localStorage[themeKey] === 'dark' ||
            (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches)
        ) {
            document.documentElement.classList.add('dark');
        } else {
            document.documentElement.classList.remove('dark');
        }

        // // Whenever the user explicitly chooses light mode
        // localStorage[themeKey] = 'light';

        // // Whenever the user explicitly chooses dark mode
        // localStorage[themeKey] = 'dark';

        // // Whenever the user explicitly chooses to respect the OS preference
        // localStorage.removeItem('theme');
    }

    private log(message: string): void {
        this.messageService.add(`App component: ${message}`);
    }
}
