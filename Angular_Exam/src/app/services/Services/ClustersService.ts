import {Injectable} from '@angular/core';

import {Http} from '@angular/http';

import {ReadOnlyServiceBase} from '../ReadOnlyService';
import {IClusters} from "../../dtos/Clusters";


@Injectable()
export class ClustersService
    extends ReadOnlyServiceBase<IClusters> {

    constructor(http: Http) {
        super(http, "http://192.168.10.106/api/clusters/");

    }
}