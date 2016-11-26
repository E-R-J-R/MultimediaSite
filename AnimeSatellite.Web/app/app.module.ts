import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppComponent }  from './app.component';
import { NewsComponent } from './news/news.component';
import { GroupByPipe } from './shared/groupby.pipe';

@NgModule({
  imports:      [ BrowserModule, HttpModule ],
  declarations: [ AppComponent, 
                  NewsComponent,
                  GroupByPipe
                ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
