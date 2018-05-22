import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BetService } from '../../services/bet.service';


@Component({
    selector: 'event',
    templateUrl: './event.component.html'
})
export class EventComponent implements OnInit {
    eventForm: FormGroup;

    constructor(private service: BetService) { }

    ngOnInit() {
        this.eventForm = new FormGroup({
            'kickOffTime': new FormControl(''),
            'homeTeam': new FormControl(''),
            'awayTeam': new FormControl(''),
            'homeOdds': new FormControl(''),
            'awayOdds': new FormControl(''),
            'drawOdds': new FormControl('')
        });
    }

    onAddEvent() {
        this.service.addEvent(this.eventForm.value);
    }

}
