import { Component, OnInit } from '@angular/core';
import {HostsService} from "../services/Services/HostsService";
import {Router, ActivatedRoute} from "@angular/router";
import {IHost} from "../dtos/Host";
import {Observable} from "rxjs";
import {ClustersService} from "../services/Services/ClustersService";
import {IClusters} from "../dtos/Clusters";

@Component({
  moduleId: module.id,
  selector: 'app-hosts',
  templateUrl: 'hosts.component.html',
  styleUrls: ['hosts.component.css']
})
export class HostsComponent implements OnInit {

    private _router: Router;
    private _hostsService: HostsService;
    private _hosts$: Observable<IHost[]>;
    private _route: ActivatedRoute;
    private _clusterService: ClustersService;

    clusterId: number;
    cluster: IClusters;

  constructor(router: Router, hostsService: HostsService, route: ActivatedRoute, clustersService: ClustersService) {
      this._router = router;
      this._hostsService = hostsService;
      this._route = route;
      this._clusterService = clustersService;
  }

  ngOnInit() {
      this._route.params.subscribe(params => {
          this.clusterId = params['clusterId'];

          this.retrieveCluster();
      });
  }

    private retrieveCluster(): void {
        this._clusterService.getItemById(this.clusterId.toString()).subscribe(cluster => {
            this.cluster = cluster;
            this._hosts$ = this._hostsService.getItemsById(this.cluster.hostIds.map(String));
        } );
    }

  onNavigate(hostId: number) {
      this._router.navigateByUrl(`hosts/${hostId}`);
  }

}
