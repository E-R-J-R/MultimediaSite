import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { INews } from './news';
import { URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class NewsService {

    private _getConfigUrl = 'api/configuration/getconfig';
    private _getNewsListUrl = 'api/news/getnews';
    private _insertNewsUrl = 'api/news/insertnews?newsList=';

    constructor(private _http: Http) {}

    getConfiguration(key: string): Observable<string> {
        return this._http.get(this._getConfigUrl + '/' + key)
                         .map((response: Response) => <string> response.json())
                         .do(data => console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    getNewsList(page: number): Observable<INews[]> {
        
        let params: URLSearchParams = new URLSearchParams();
        params.set('page', page.toString());

        return this._http.get(this._getNewsListUrl, {search: params})
                         .map((response: Response) => <INews[]> response.json())
                         .do(data => console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
        
    }

    insertNews(newsList: INews[]) : Observable<number>  {
        
        let postHeaders: Headers = new Headers();
        postHeaders.append('Content-Type', 'application/json');  
        let options = new RequestOptions({ headers: postHeaders }); 

        return this._http.post(this._insertNewsUrl, JSON.stringify(newsList),  options)
                         .map((response: Response) => <number> parseInt(JSON.stringify(response)))
                         .do(data => console.log(JSON.stringify(data)))
                         .catch(this.handleError); 

    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}