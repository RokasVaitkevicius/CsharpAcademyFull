/**
 * Created by Rokas on 2016.08.11.
 */
import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import {ReadOnlyServiceBase} from '../ReadOnlyService';
import {IHost} from "../../dtos/Host";

@Injectable()
export class HostsService
extends ReadOnlyServiceBase<IHost> {

    constructor(http: Http) {
        super(http, "http://192.168.10.106/api/hosts/");
    }
}