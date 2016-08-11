import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {Router} from "@angular/router";
import {ClustersService} from "../services/Services/ClustersService";
import {IClusters} from "../dtos/Clusters";

@Component({
  moduleId: module.id,
  selector: 'app-clusters',
  templateUrl: 'clusters.component.html',
  styleUrls: ['clusters.component.css']
})
export class ClustersComponent implements OnInit {

  private _router: Router;
  private _service: ClustersService;
  private _clusters$: Observable<IClusters[]>;

  constructor(router: Router, service: ClustersService) {
    this._router = router;
    this._service = service;
    this._clusters$ = service.getAllItems();
  }

  ngOnInit() {
  }

  onNavigate(clusterId: number): void {
    this._router.navigateByUrl(`clusters/${clusterId}`);
  }

}
