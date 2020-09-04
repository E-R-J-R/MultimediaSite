import { Component, Input, OnInit } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { INews } from './news';

@Component({
    moduleId: module.id,
    selector: 'news-modal',
    templateUrl: 'news.modal.component.html',
    styleUrls: ['news.component.css']
    //styles: ['.red {color: red;}']
})
export class NewsModalComponent {

    @Input() newsItem: INews;
    standardStyle: string;

    constructor(public activeModal: NgbActiveModal) {}

    ngOnInit(): void {
        this.standardStyle = Math.random() < 0.5 ? "pull-left" : "pull-right";
    } 

    goToSource(): void {
        window.location.href = this.newsItem.SourceUrl;
    }

}
