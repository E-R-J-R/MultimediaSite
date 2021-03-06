import { Component, OnInit } from '@angular/core';
import { NewsService } from './news/news.service';
import { MoviesService } from './movies/movies.service';
import { AdminService } from './admin/admin.service';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'as-app',
    moduleId: module.id,
    templateUrl: 'app.component.html',
    providers: [ NewsService, MoviesService, AdminService ]
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
