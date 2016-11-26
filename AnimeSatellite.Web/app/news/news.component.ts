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

    ngOnInit(): void {
        this._newsService.getConfiguration('NewsImageUrl')
                            .subscribe(config => this.newsImageUrl = config,
                                       error => this.errorMessage = <any>error);
                             
    }

    newsList: INews[] = [
                          {
                            "newsId": 1,
                            "headline": "Dragonball Super",
                            "details": "GDN-0011",
                            "date": "March 20, 2016",
                            "publishedDate": 'November 19, 2016',
                            "source": "Leaf rake with 48-inch wooden handle.",
                            "imageFileName": "dragonballsuper.jpg"
                          },
                          {
                            "newsId": 2,
                            "headline": "Gotenks",
                            "details": "Super Dragonball",
                            "date": "March 20, 2016",
                            "publishedDate": 'November 19, 2016',
                            "source": "Test Source",
                            "imageFileName": "gotenks.jpg"
                          },
                          {
                            "newsId": 3,
                            "headline": "Initial D Zero",
                            "details": "Super Dragonball",
                            "date": "March 20, 2016",
                            "publishedDate": 'November 19, 2016',
                            "source": "Test Source",
                            "imageFileName": "initialdzero.jpg"
                          },
                          {
                            "newsId": 4,
                            "headline": "Initial D FD",
                            "details": "Super Dragonball",
                            "date": "March 20, 2016",
                            "publishedDate": 'November 20, 2016',
                            "source": "Test Source",
                            "imageFileName": "mazda.jpg"
                          },
                          {
                            "newsId": 5,
                            "headline": "Gundam 00",
                            "details": "Super Dragonball",
                            "date": "March 19, 2016",
                            "publishedDate": 'November 20, 2016',
                            "source": "Test Source",
                            "imageFileName": "gundam00.jpg"
                          },
                          {
                            "newsId": 6,
                            "headline": "00 Raiser",
                            "details": "Super Dragonball",
                            "date": "March 19, 2016",
                            "publishedDate": 'November 20, 2016',
                            "source": "Test Source",
                            "imageFileName": "00Raiser.jpg"
                          }
                       ];

    
}