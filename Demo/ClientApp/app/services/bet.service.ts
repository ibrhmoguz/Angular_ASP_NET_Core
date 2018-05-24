import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
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
        this.http.post('api/bet/createEvent', event).subscribe();
    }
}

export interface Event {
    EventId: number,
    KickOffTime: string;
    HomeTeam: string;
    AwayTeam: string;
    homeOdds: number;
    awayOdds: number;
    drawOdds: number;
}

