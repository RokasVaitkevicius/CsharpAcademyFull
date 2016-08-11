import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute} from "@angular/router";
import {HostsService} from "../services/Services/HostsService";
import {Observable} from "rxjs";
import {IVirtualMachine} from "../dtos/VirtualMachine";
import {IHost} from "../dtos/Host";
import {VirtualMachineService} from "../services/Services/VirtualMachineService";

@Component({
  moduleId: module.id,
  selector: 'app-virtual-machines',
  templateUrl: 'virtual-machines.component.html',
  styleUrls: ['virtual-machines.component.css']
})
export class VirtualMachinesComponent implements OnInit {

  private _hostsService: HostsService;
  private _virtualMachineService: VirtualMachineService;
  private _router: Router;
  private _virtualM$: Observable<IVirtualMachine[]>;
  private _route: ActivatedRoute;

  hostId: number;
  host: IHost;


  constructor(router: Router, hostsService: HostsService, route: ActivatedRoute, virtualMachineService: VirtualMachineService) {
    this._router = router;
    this._hostsService = hostsService;
    this._route = route;
    this._virtualMachineService = virtualMachineService;
  }

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.hostId = params['hostId'];

      this.retrieveVirtualMachines();
    });
  }

  private retrieveVirtualMachines(): void {
    this._hostsService.getItemById(this.hostId.toString()).subscribe(host => {
      this.host = host;
      this._virtualM$ = this._virtualMachineService.getItemsById(this.host.virtualMachineIds.map(String));
    } );
  }

  onNavigate(virtualMachine: number) {

    this._router.navigateByUrl(`virtualmachines/${virtualMachine}`);
  }

}
