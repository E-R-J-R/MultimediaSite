import { Component, Input, OnInit } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IMovie } from './movie';
import { IMovieLink } from './movieLink';
import * as _ from 'underscore';

@Component({
    moduleId: module.id,
    selector: 'movies-modal',
    templateUrl: 'movies.modal.component.html',
    styleUrls: ['movies.modal.component.css']
})
export class MoviesModalComponent {

    @Input() movie: IMovie;
    
    movieLink: IMovieLink;
    altLinks: IMovieLink[];
    
    constructor(public activeModal: NgbActiveModal) {}

    ngOnInit(): void {
        this.movieLink = _.first(this.movie.Links);

        if (this.movie.Links.length > 0)
        {
            this.altLinks = this.movie.Links;
        }        
    } 

    getAltVideo(link: IMovieLink): void {
        this.movieLink = link;
        
    }

    


}
