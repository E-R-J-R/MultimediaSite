import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'as-app',
    moduleId: module.id,
    templateUrl: 'app.component.html'
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
