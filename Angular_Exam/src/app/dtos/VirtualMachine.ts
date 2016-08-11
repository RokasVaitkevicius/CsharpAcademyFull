/**
 * Created by Rokas on 2016.08.11.
 */
export interface IVirtualMachine {
    hostId: number;
    name: string;
    state: number;
    virtualProcessorCount: number;
    virtualMemory: {
        value: number;
        unit: number;
    };
}