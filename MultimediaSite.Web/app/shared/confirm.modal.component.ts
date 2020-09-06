import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'confirm-modal-component',
    templateUrl: 'app/shared/confirm.modal.component.html'
})
export class ConfirmModalComponent { 

    @Input() modalHeader: string;
    @Input() modalBody: string;
    @Output() action: EventEmitter<any> = new EventEmitter();;

    constructor(public activeModal: NgbActiveModal) { }

    confirm(): void {
        this.action.emit('confirm');
        this.activeModal.close('close');
    }

    cancel(): void {
        this.action.emit('cancel');
        this.activeModal.close('close');
    }
    
}