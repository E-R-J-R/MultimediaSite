import { Component, Input, OnInit } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IMovie } from './movie';
import { IMovieLink } from './movieLink';

@Component({
    moduleId: module.id,
    templateUrl: 'movies.modal.component.html'
})
export class MoviesModalComponent {

    @Input() movie: IMovie;

    constructor(public activeModal: NgbActiveModal) {}

    ngOnInit(): void {
        
    } 


}
