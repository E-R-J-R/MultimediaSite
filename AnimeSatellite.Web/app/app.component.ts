import { Component, OnInit } from '@angular/core';
import { NewsService } from './news/news.service';

@Component({
    selector: 'as-app',
    moduleId: module.id,
    templateUrl: 'app.component.html',
    providers: [ NewsService ]
})
export class AppComponent { 

    selected: string;

    menuSelect(menu: string): void {
        this.selected = menu;
    }
    
     ngOnInit(): void {
        this.selected = "News";
                             
    }
}
