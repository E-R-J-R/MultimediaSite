//Angular
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

//Components
import { AppComponent }  from './app.component';
import { NewsComponent } from './news/news.component';
import { NewsModalComponent } from './news/news.modal.component';
import { MoviesComponent } from './movies/movies.component';
import { MoviesModalComponent } from './movies/movies.modal.component';
import { AdminComponent } from './admin/admin.component';
import { NewsInsertModalComponent } from './admin/news.insert.modal.component'

//Services
import { NewsService } from './news/news.service';
import { MoviesService } from './movies/movies.service';
import { AdminService } from './admin/admin.service';

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
                  FormsModule,
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
                  TruncatePipe,
                  AdminComponent,
                  NewsInsertModalComponent
                ],
  providers: [ NewsService,
               MoviesService,
               AdminService
             ],
  entryComponents: [ NewsComponent, NewsModalComponent, MoviesModalComponent, AdminComponent, NewsInsertModalComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
