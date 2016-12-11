import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IMovie } from './movie';
import { IMovieLink } from './movieLink';
import { URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class MoviesService {
    
    private _getMoviesListUrl = 'api/movies/getmovies'

    constructor(private _http: Http) {}

    getMoviesList(page: number): Observable<IMovie[]> {
        
        let params: URLSearchParams = new URLSearchParams();
        params.set('page', page.toString());

        return this._http.get(this._getMoviesListUrl, {search: params})
                         .map((response: Response) => <IMovie[]> response.json())
                         .do(data => console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
        
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    } 

}
