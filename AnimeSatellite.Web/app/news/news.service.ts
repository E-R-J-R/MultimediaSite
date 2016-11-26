import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class NewsService {

    private _getConfigUrl = 'api/configuration/getconfig';

    constructor(private _http: Http) {}

    getConfiguration(key: string): Observable<string> {
        return this._http.get(this._getConfigUrl + '/' + key)
                         .map((response: Response) => <string> response.json())
                         .do(data => console.log('All: ' + JSON.stringify(data)))
                         .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}