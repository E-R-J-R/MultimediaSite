//Angular
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

//Components
import { AppComponent }  from './app.component';
import { NewsComponent } from './news/news.component';
import { NewsModalComponent } from './news/news.modal.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviesModalComponent } from './movies/movies.modal.component';

//Pipes
import { GroupByPipe } from './shared/groupby.pipe';
import { SafeUrlPipe } from './shared/safeurl.pipe';
import { TruncatePipe } from './shared/truncate.pipe';

//Libraries
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports:      [ BrowserModule, 
                  HttpModule, 
                  RouterModule, 
                  InfiniteScrollModule,
                  NgbModule.forRoot()
                ],
  declarations: [ AppComponent, 
                  NewsComponent,
                  NewsModalComponent,
                  MoviesComponent,
                  MoviesModalComponent,
                  GroupByPipe,
                  SafeUrlPipe,
                  TruncatePipe
                ],
  entryComponents: [ NewsComponent, NewsModalComponent, MoviesModalComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
