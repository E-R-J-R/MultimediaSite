import { Component, OnInit } from '@angular/core';
import { AdminService } from './admin.service';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NewsInsertModalComponent } from './news.insert.modal.component';

@Component({
    selector: 'as-admin',
    templateUrl: 'app/admin/admin.component.html'
})
export class AdminComponent { 

    constructor(private _adminService: AdminService, private modalService: NgbModal) { }

    ngOnInit(): void { } 

    insertNews(): void { 
        const modalRef = this.modalService.open(NewsInsertModalComponent, {backdrop: 'static', keyboard: true, size: 'lg'});
    }
    
}