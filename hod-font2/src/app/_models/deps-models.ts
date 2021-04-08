
import { AcPlan, Group } from './groups-models';

export {
    DepInfo, DepsDto, Direction
}

interface DepInfo {
    dep_id: number,
    dep_name: string,
    //dateCreated: Date,
    //dateEnd: Date
    headTeach_id: number,
    headTeach_name: number,
    count_groups: number,
}

interface DepsDto {
    dep_id: number,
    dep_name: string,
    dep_shortName: string,
    //dateCreated: Date,
    //dateEnd: Date
    // headTeach_id: number,
    // headTeach_name: string,

    dirs: Direction[],
    // link to order requirs?
}

interface DirRequir {
    fgos_num: string,
    settedValue: number,
    // unit_id: number,
    unit_name: string,
}

interface Direction {
    dir_id: number,
    dir_name: string,
    startYear: number,
    acPlan_id: number,
    requirs: DirRequir[]
    groups: Group[],
}
