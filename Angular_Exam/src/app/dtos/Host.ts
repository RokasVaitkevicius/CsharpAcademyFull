/**
 * Created by Rokas on 2016.08.11.
 */
export interface IHost {
    name: string;
    state: number;
    ProcessorCount: number;
    PhysicalMemory: number;
    virtualMachineIds: number[];
}