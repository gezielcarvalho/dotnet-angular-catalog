import { Component, OnInit } from '@angular/core';
import { Filter } from '../../models/Filter';
import { StoreService } from '../../services/store.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
    standalone: true,
    imports: [FormsModule, CommonModule],
    selector: 'app-filter',
    templateUrl: './filter.component.html',
})
export class FilterComponent implements OnInit {
    categories = [
        { name: 'Shoes', selected: false },
        { name: 'Clothes', selected: false },
        { name: 'Gear', selected: false },
    ];
    tempFilter: Filter = { name: '', categories: [] };
    constructor(public storeService: StoreService) {}
    ngOnInit(): void {
        this.tempFilter = this.storeService.filter;
        this.categories = this.categories.map(cat => ({
            name: cat.name,
            selected: this.tempFilter.categories.includes(cat.name),
        }));
    }
    onChange(): void {
        this.tempFilter.categories = this.categories
            .filter(c => c.selected)
            .map(cc => cc.name);
    }
    onFilterChanged(): void {
        this.storeService.filter = this.tempFilter;
    }
}
