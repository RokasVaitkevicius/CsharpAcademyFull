import {provideRouter, Route} from '@angular/router';
import {WelcomeComponent} from "./welcome/welcome.component";
import {ClustersComponent} from "./clusters/clusters.component";
import {HostsComponent} from "./hosts/hosts.component";
import {VirtualMachinesComponent} from "./virtual-machines/virtual-machines.component";
import {VirtualMachinesDetailsComponent} from "./virtual-machines-details/virtual-machines-details.component";



export const routes: Route[] = [
    { path: '',   component: WelcomeComponent },
    { path: 'clusters', component: ClustersComponent },
    { path: 'clusters/:clusterId', component: HostsComponent},
    { path: 'hosts/:hostId', component: VirtualMachinesComponent},
    { path: 'virtualmachines/:vmId', component: VirtualMachinesDetailsComponent}



];

export const APP_ROUTER_PROVIDERS = [
    provideRouter(routes)
];