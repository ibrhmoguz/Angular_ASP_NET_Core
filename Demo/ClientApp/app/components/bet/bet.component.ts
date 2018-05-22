import { Component } from '@angular/core';
import { BetService } from '../../services/bet.service';

@Component({
    selector: 'bet',
    templateUrl: './bet.component.html'
})
export class BetComponent {
    playerList: any[] = [];

    constructor(private service: BetService) { }

    ngOnInit() {
        this.service.getPlayerList().subscribe(players => this.playerList = players);
    }
}
