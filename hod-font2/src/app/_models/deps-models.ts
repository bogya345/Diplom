
import { AcPlan, Group } from './groups-models';

export {
    DepInfo, DepsDto, Direction,
    DirRequir, RequirInfo, PackageRequirs
}

interface DepInfo {
    Dep_id: number,
    Dep_name: string,
    Dep_shortName: string,
    //dateCreated: Date,
    //dateEnd: Date
    HeadTeach_id: number,
    HeadTeach_name: number,
    Count_groups: number,
}

interface DepsDto {
    Dep_id: number,
    Dep_name: string,
    Dep_shortName: string,
    //dateCreated: Date,
    //dateEnd: Date
    // headTeach_id: number,
    // headTeach_name: string,

    Dirs: Direction[],
    // link to order requirs?
}

interface RequirInfo {
    Fgos_num: string,
    Fgos_content: string,
    SettedValue: number,
    // unit_id: number,
    Unit_name: string,
}

interface PackageRequirs {
    Done: boolean,
    Msg_text: string,
    Requirs: DirRequir[],
    NumA722: number,
    NumS722: number,
    NumA723: number,
    NumS723: number,
    NumA724: number,
    NumS724: number,
    Mark722: string,
    Mark723: string,
    Mark724: string
}
interface DirRequir {
    Fgos_num: string,
    SettedValue: number,
    // unit_id: number,
    Unit_name: string,
}

interface Direction {
    Dep_id: number,
    Dir_id: number,
    Dir_name: string,
    Highlight: number,
    Status_pps: StatusDto,
    Status_pps_mgs: string,
    Status: StatusDto,
    Status_mgs: string,
    StartYear: number,
    AcPl_id: number,
    Requirs: DirRequir[]
    Groups: Group[],
}
interface StatusDto {
    Status_up: number,
    Status_down: number
}
