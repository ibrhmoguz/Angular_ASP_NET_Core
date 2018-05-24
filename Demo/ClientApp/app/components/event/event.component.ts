import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BetService } from '../../services/bet.service';


@Component({
    selector: 'event',
    templateUrl: './event.component.html'
})
export class EventComponent implements OnInit {
    eventForm: FormGroup;

    constructor(private service: BetService) {
    }

    ngOnInit() {
        this.eventForm = new FormGroup({
            'EventId': new FormControl(''),
            'KickOffTime': new FormControl(''),
            'HomeTeam': new FormControl(''),
            'AwayTeam': new FormControl(''),
            'HomeOdds': new FormControl(''),
            'AwayOdds': new FormControl(''),
            'DrawOdds': new FormControl('')
        });
    }

    onAddEvent() {
        this.service.addEvent(this.eventForm.value);
    }

}
