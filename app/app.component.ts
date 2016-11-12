import { Component } from '@angular/core';

@Component({
    selector: 'as-app',
    //moduleId: module.id,
    //templateUrl: 'app.component.html',
    template: `<p>hello world<p>`
})
export class AppComponent { 
    pageTitle: string = 'Anime Satellite';
}