import { NgFor, NgIf, NgTemplateOutlet } from '@angular/common';
import { Component, OnDestroy, TemplateRef } from '@angular/core';
import { NgbToastModule, NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from 'src/app/services/toast.service';
import { ToastComponent } from '../toast/toast.component';

@Component({
	selector: 'app-toast-global',
	standalone: true,
	imports: [NgbTooltipModule, ToastComponent],
	templateUrl: './toast-global.component.html',
})
export class ToastGlobalComponent implements OnDestroy {
	constructor(public toastService: ToastService) {}

	ngOnDestroy(): void {
		this.toastService.clear();
	}
}
