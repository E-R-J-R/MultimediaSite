import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ITag } from './tag';
import { URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class TagService {

    private _getTagListUrl = 'api/tag/gettaglist';

    constructor(private _http: Http) {}

    getTagList(): Observable<ITag[]> {

        return this._http.get(this._getTagListUrl)
                         .map((response: Response) => <ITag[]> response.json())
                         .do(data => console.log('Tag List: ' + JSON.stringify(data)))
                         .catch(this.handleError);
       
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}