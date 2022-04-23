import { Component, OnInit } from '@angular/core';
import { statlineModel } from 'src/app/Models/statlineModel';
import { StatlineService } from 'src/app/Services/statline.service';

@Component({
  selector: 'app-reg-statline',
  templateUrl: './reg-statline.component.html',
  styleUrls: ['./reg-statline.component.css']
})
export class RegStatlineComponent implements OnInit {

  statlineMdl = new statlineModel();

  constructor(private statLineService: StatlineService) { }

  ngOnInit() {
  }


  registerStatline()
  {
    this.statLineService.registerStatline(this.statlineMdl).subscribe(data => {
      console.log(this.statlineMdl)
      if(data == "ReggadBok")
      {
        alert("Grattis! Du har nu registrerat en ny statline!")
      }
      else{
        alert("Det gick inte att registrera din statline")
      }
    })
  }
}
