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
}

