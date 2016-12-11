import { IMovieLink } from './movieLink';

export interface IMovie {
        MovieId: number;
        Title: string;
        Synopsis: string;
        Length: string;
        ReleaseDate: string;
        Producer: string;
        ImageFileName: string;
        Links: IMovieLink[];
}