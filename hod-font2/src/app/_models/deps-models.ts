
import { AcPlan, Group } from './groups-models';

export {
    DepInfo, DepsDto, Direction
}

interface DepInfo {
    Dep_id: number,
    Dep_name: string,
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

interface DirRequir {
    Fgos_num: string,
    SettedValue: number,
    // unit_id: number,
    Unit_name: string,
}

interface Direction {
    Dir_id: number,
    Dir_name: string,
    StartYear: number,
    AcPl_id: number,
    Requirs: DirRequir[]
    Groups: Group[],
}
