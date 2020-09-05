import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NewsService } from '../news/news.service';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { INews } from '../news/news';
import * as _ from 'underscore';

@Component({
    moduleId: module.id,
    selector: 'news-insert-modal',
    templateUrl: 'news.insert.modal.component.html',
    providers: [ NewsService ] 
})
export class NewsInsertModalComponent {

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
        Tags: null
    };
    newsList: INews[] = [];
    isSuccess: number;
    errorMessage: string;
    
    constructor(private _newsService: NewsService, public activeModal: NgbActiveModal) {}

    ngOnInit(): void {
        //default
        this.newsItem.ContentType = "article";
        
    } 

    selectContentTypeChange(event: any) {
        this.newsItem.ContentType = event.target.value;
    }

    submit(): void {

        this.newsList.push(this.newsItem);

        this._newsService.insertNews(this.newsList)
                         .subscribe(success => this.isSuccess = success,
                                    error => this.errorMessage = <any>error);
    }

}