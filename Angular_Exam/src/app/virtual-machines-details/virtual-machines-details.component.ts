import { Component, OnInit } from '@angular/core';
import {IVirtualMachine} from "../dtos/VirtualMachine";
import {Router, ActivatedRoute} from "@angular/router";
import {VirtualMachineService} from "../services/Services/VirtualMachineService";

@Component({
  moduleId: module.id,
  selector: 'app-virtual-machines-details',
  templateUrl: 'virtual-machines-details.component.html',
  styleUrls: ['virtual-machines-details.component.css']
})
export class VirtualMachinesDetailsComponent implements OnInit {

  vmId: number;
  private _router: Router;
  private _virtualM$: IVirtualMachine;
  private _route: ActivatedRoute;
  private _service: VirtualMachineService;

  constructor(router: Router, service: VirtualMachineService, route: ActivatedRoute) {
    this._router = router;
    this._service = service;
    this._route = route;
  }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.vmId = params['vmId'];

      this.retrieveVirtualMachine();
    });
  }

  private retrieveVirtualMachine(): void {
    this._service.getItemById(this.vmId.toString()).subscribe(vm => {
      this._virtualM$ = vm;
    } );
  }

}
