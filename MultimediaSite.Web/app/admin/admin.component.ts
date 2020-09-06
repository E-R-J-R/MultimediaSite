import { Component, OnInit } from '@angular/core';
import { AdminService } from './admin.service';
import { NewsService } from '../news/news.service';
import { INews } from '../news/news';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NewsInsertModalComponent } from './news.insert.modal.component';
import { ConfirmModalComponent } from '../shared/confirm.modal.component'
import * as _ from 'underscore';

@Component({
    selector: 'as-admin',
    templateUrl: 'app/admin/admin.component.html'
})
export class AdminComponent { 

    newsList: INews[] = [];
    newsCtr: number = 1;
    errorMessage: string = "";
    showReview: boolean = false;
    newsItem: INews = { NewsId: 0,
                              Headline: "",
                              Content: "",
                              ContentType: "",
                              EmbedCode: "",
                              NewsDate: null,
                              PublishedDate: null,
                              SourceName: "",
                              SourceUrl: "",
                              ImageFileName: "", 
                              Tags: []
                            };

    constructor(private _adminService: AdminService, private _newsService: NewsService, private modalService: NgbModal) { }

    ngOnInit(): void { } 

    insertNews(): void { 
        const modalRef = this.modalService.open(NewsInsertModalComponent, {backdrop: 'static', keyboard: true, size: 'lg'});
        modalRef.componentInstance.newsItem = this.newsItem;
        modalRef.componentInstance.transaction = "insert";
    }

    review(): void {
        this.showReview = true;
        if (this.newsCtr === 1) { //Do nothing if page > 1 
            this._newsService.getNewsList(this.newsCtr)
                             .subscribe(newsItems => this.newsList = newsItems,
                                        error => this.errorMessage = <any>error);
        }
    }

    newsLoadMore(): void {
        this.newsCtr += 1;
        this._newsService.getNewsList(this.newsCtr)
                         .subscribe(data => this.newsList = this.newsList.concat(data),
                                    error => this.errorMessage = <any>error);
    }

    refreshReviewGrid(): void {
           //refresh review grid
           this.newsCtr = 1;
           this.newsList = [];
           this.review();
    }

    updateNews(newsId: number): void { 
        const modalRef = this.modalService.open(NewsInsertModalComponent, {backdrop: 'static', keyboard: true, size: 'lg'});
        var updateItem = _.findWhere(this.newsList, { NewsId: newsId });
        modalRef.componentInstance.newsItem = updateItem;
        modalRef.componentInstance.transaction = "update";
    }

    deleteNews(newsId: number): void {
         const modalRef = this.modalService.open(ConfirmModalComponent, {backdrop: 'static', keyboard: true, size: 'sm'});
         modalRef.componentInstance.modalHeader = "Delete News";
         modalRef.componentInstance.modalBody = "Are you sure you want to delete?";
         modalRef.componentInstance.action.subscribe((action) => {
            if (action === "confirm") {
                this._newsService.deleteNews(newsId)
                             .subscribe(success => { this.refreshReviewGrid(); }, error => this.errorMessage = <any>error);
                            
            }
         })

    }
     
    
}