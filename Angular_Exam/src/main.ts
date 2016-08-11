import {bootstrap} from '@angular/platform-browser-dynamic';
import {enableProdMode} from '@angular/core';
import {HTTP_PROVIDERS} from '@angular/http';
import {provideForms, disableDeprecatedForms} from '@angular/forms';

import {AppComponent, environment} from './app/';


import {APP_ROUTER_PROVIDERS} from './app/app.routes';
import {ClustersService} from "./app/services/Services/ClustersService";
import {HostsService} from "./app/services/Services/HostsService";
import {VirtualMachineService} from "./app/services/Services/VirtualMachineService";

if (environment.production) {
    enableProdMode();
}

bootstrap(AppComponent,
    [
        HTTP_PROVIDERS,
        APP_ROUTER_PROVIDERS,
        ClustersService,
        HostsService,
        VirtualMachineService,
        disableDeprecatedForms(),
        provideForms()
    ]);