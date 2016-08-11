/**
 * Created by Rokas on 2016.08.11.
 */
import {Injectable} from '@angular/core';

import {Http} from '@angular/http';

import {ReadOnlyServiceBase} from '../ReadOnlyService';
import {IVirtualMachine} from "../../dtos/VirtualMachine";



@Injectable()
export class VirtualMachineService
extends ReadOnlyServiceBase<IVirtualMachine> {

    constructor(http: Http) {
        super(http, "http://192.168.10.106/api/virtualmachines/");

    }
}