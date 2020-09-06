import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NewsService } from '../news/news.service';
import { TagService } from '../shared/tag.service';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { INews } from '../news/news';
import { ITag } from '../shared/tag';
import * as _ from 'underscore';

@Component({
    moduleId: module.id,
    selector: 'news-insert-modal',
    templateUrl: 'news.insert.modal.component.html',
    providers: [ NewsService, TagService ] 
})
export class NewsInsertModalComponent {

    @Input() newsItem: INews;
    @Input() transaction: string;

    newsList: INews[] = [];
    tagList: ITag[] = [];
    selectedTags: ITag[] = [];
    selectedTagsDisplay: string = "";
    isSuccess: number = 0;
    errorMessage: string = "";
    transactionDisplay: string = "";
    
    constructor(private _newsService: NewsService, private _tagService: TagService, public activeModal: NgbActiveModal) {}

    ngOnInit(): void {
               
        //get tag list on load
        this._tagService.getTagList().subscribe(data => this.tagList = data, error => this.errorMessage = <any>error);
        
        //default value
        this.newsItem.ContentType = "article";

        //fill tags
        if (this.newsItem.Tags.length > 0)
        {
            this.newsItem.Tags.forEach(function(tag) {
                this.selectedTags.push(tag);
            }, this);
            this.selectedTagsDisplay = _.pluck(this.selectedTags, 'TagName').join(', ');
        }

        this.transaction === "insert" ? this.transactionDisplay = "Upload" : this.transactionDisplay = "Update";
        
    } 

    selectContentTypeChange(event: any) {
        this.newsItem.ContentType = event.target.value;
    }

    tagSelected(tag: ITag) {
        
        var tagCount = _.where(this.selectedTags, { TagId: tag.TagId });
 
        if (tagCount.length <= 0) {
            this.selectedTags.push(tag); 
        } else {
            this.selectedTags = _.filter(this.selectedTags, function(item) {
                                    return item.TagId !== tag.TagId
                                });
        }

        this.selectedTagsDisplay = _.pluck(this.selectedTags, 'TagName').join(', ');

        this.newsItem.Tags = this.selectedTags;
         
    }

    submit(): void {

        this.newsList.push(this.newsItem);

        if (this.transaction === "insert") {
             this._newsService.insertNews(this.newsList)
                         .subscribe(success => { this.isSuccess = success; this.activeModal.close('close'); },
                                    error => this.errorMessage = <any>error);
        } else {
              this._newsService.updateNews(this.newsItem)
                         .subscribe(success => { this.isSuccess = success; this.activeModal.close('close'); },
                                    error => this.errorMessage = <any>error);

        }

    }

}