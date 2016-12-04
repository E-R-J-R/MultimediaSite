import { Component, OnInit } from '@angular/core';
import { INews } from './news';
import { NewsService } from './news.service';
import { NewsModalComponent } from './news.modal.component';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
    selector: 'as-news',
    templateUrl: 'app/news/news.component.html',
    styleUrls: ['app/news/news.component.css']
})
export class NewsComponent { 

    constructor(private _newsService: NewsService, private modalService: NgbModal) { }

    newsImageUrl: string;
    errorMessage: string;
    newsList: INews[];

    ngOnInit(): void {
        this._newsService.getNewsList(1)
                         .subscribe(newsItems => this.newsList = newsItems,
                                    error => this.errorMessage = <any>error);
    } 

    openNews(item: INews): void {
        const modalRef = this.modalService.open(NewsModalComponent, {backdrop: 'static', keyboard: true, size: 'lg'});
        modalRef.componentInstance.newsItem = item;
    }

    

    
}