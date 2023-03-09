import { NgFor, NgIf, NgTemplateOutlet } from '@angular/common';
import { Component, TemplateRef } from '@angular/core';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from 'src/app/services/toast.service';

@Component({
	selector: 'app-toasts',
	standalone: true,
	imports: [NgbToastModule, NgIf, NgTemplateOutlet, NgFor],
	templateUrl: './toast.component.html',
	host: { class: 'toast-container position-fixed top-0 text-center mt-2 start-50 translate-middle-x', style: 'z-index: 1200' },
})
export class ToastComponent {
	constructor(public toastService: ToastService) {}

	isTemplate(toast:any) {
		return toast.textOrTpl instanceof TemplateRef;
	}
}