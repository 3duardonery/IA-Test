import { Disk } from './disk';

export interface Device {
  name: string;
  osVersion: string;
  ipAddress: string;
  connectionId: string;
  antivirusName: string;
  hasAntivirus: boolean;
  freeHardDisk: number;
  hardDisk: number;
  disk: Disk;
}
