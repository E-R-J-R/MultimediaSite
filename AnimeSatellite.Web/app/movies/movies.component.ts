import { Component, OnInit } from '@angular/core';
import { IMovie } from './movie';
import { IMovieLink } from './movieLink';
import { MoviesService } from './movies.service';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { MoviesModalComponent } from './movies.modal.component';

@Component({
    selector: 'as-movies',
    templateUrl: 'app/movies/movies.component.html'
})
export class MoviesComponent {
    
    constructor(private _moviesService: MoviesService, private modalService: NgbModal) { }

    moviesCtr: number = 1;
    errorMessage: string;
    moviesList: IMovie[];

    ngOnInit(): void {
        this._moviesService.getMoviesList(this.moviesCtr)
                         .subscribe(data => this.moviesList = data,
                                    error => this.errorMessage = <any>error);
    } 

     moviesLoadMore(): void {
        this.moviesCtr += 1;
        this._moviesService.getMoviesList(this.moviesCtr)
                         .subscribe(data => this.moviesList = this.moviesList.concat(data),
                                    error => this.errorMessage = <any>error)    
     }

     openMovie(item: IMovie): void {
        const modalRef = this.modalService.open(MoviesModalComponent, {backdrop: 'static', keyboard: true, windowClass: 'movie-modal'});
        modalRef.componentInstance.movie = item;
     }
} 