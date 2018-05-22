import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/Rx';

@Injectable()
export class BetService {
    constructor(private http: Http) {
    }

    getPlayerList() {
        return this.http.get('/api/bet/playerList').map(res => res.json());
    }

    addEvent(event: Event) {
        console.log(event);
        this.http.post('api/bet/createEvent', event).map(res => res.json());
    }
}

export interface Event {
    kickOffTime: string;
    homeTeam: string;
    awayTeam: string;
    homeOdds: number;
    awayOdds: number;
    drawOdds: number;
}

