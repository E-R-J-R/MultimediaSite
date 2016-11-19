import { Component } from '@angular/core';
import { INews } from './news';


@Component({
    selector: 'as-news',
    templateUrl: 'app/news/news.component.html',
    styleUrls: ['app/news/news.component.css']
})
export class NewsComponent { 
    newsList: INews[] = [
                          {
                            "newsId": 1,
                            "headline": "Dragonball Super",
                            "details": "GDN-0011",
                            "date": "March 19, 2016",
                            "publishedDate": 'November 19, 2016',
                            "source": "Leaf rake with 48-inch wooden handle.",
                            "imageFileName": "/Images/news/dragonballsuper.jpg"
                          },
                          {
                            "newsId": 2,
                            "headline": "Gotenks",
                            "details": "Super Dragonball",
                            "date": "March 19, 2016",
                            "publishedDate": 'November 19, 2016',
                            "source": "Test Source",
                            "imageFileName": "/Images/news/gotenks.jpg"
                          },
                          {
                            "newsId": 3,
                            "headline": "Initial D Zero",
                            "details": "Super Dragonball",
                            "date": "March 19, 2016",
                            "publishedDate": 'November 19, 2016',
                            "source": "Test Source",
                            "imageFileName": "/Images/news/initialdzero.jpg"
                          },
                          {
                            "newsId": 4,
                            "headline": "Initial D FD",
                            "details": "Super Dragonball",
                            "date": "March 19, 2016",
                            "publishedDate": 'November 20, 2016',
                            "source": "Test Source",
                            "imageFileName": "/Images/news/mazda.jpg"
                          },
                          {
                            "newsId": 5,
                            "headline": "Gundam 00",
                            "details": "Super Dragonball",
                            "date": "March 20, 2016",
                            "publishedDate": 'November 20, 2016',
                            "source": "Test Source",
                            "imageFileName": "/Images/news/gundam00.jpg"
                          },
                          {
                            "newsId": 6,
                            "headline": "00 Raiser",
                            "details": "Super Dragonball",
                            "date": "March 20, 2016",
                            "publishedDate": 'November 20, 2016',
                            "source": "Test Source",
                            "imageFileName": "/Images/news/00Raiser.jpg"
                          }
                       ];

    
}