import { Component, OnInit } from '@angular/core';
import { INews } from './news';
import { NewsService } from './news.service';


@Component({
    selector: 'as-news',
    templateUrl: 'app/news/news.component.html',
    styleUrls: ['app/news/news.component.css']
})
export class NewsComponent { 

    constructor(private _newsService: NewsService) { }

    newsImageUrl: string;
    errorMessage: string;
    newsList: INews[];

    ngOnInit(): void {
        this._newsService.getNewsList(1)
                         .subscribe(newsItems => this.newsList = newsItems,
                                    error => this.errorMessage = <any>error);
    } 

    

    
}