import { DepsDto } from "./deps-models";

export {
    Group, BlockRec, AcPlan,
    BlockNum, Subject, Semester, Load
}
interface Group {
    group_id: number,
    group_name: string,
    group_acPlan_id: number
}
interface BlockRec {
    BlockRec_id: number,
    AcPlanId: number,
    SemesterNum: number,
    InPlan: boolean,
    SubId: number,
    SubName: string,
    // BlockNumId: number, // but it just planned
    BlockNum: string,
    Ze: number,
    Total: number,
    Les: number,
    Lab: number,
    Pr: number,
    Iz: number,
    Ak: number,
    Kpr: number,
    Sr: number,
    Controll: number
}

interface AcPlan {
    blockNums: BlockNum[]
}
interface BlockNum {
    blockName: string,
    subjects: Subject[],
}
interface Subject {
    subjectName: string,
    depsDto: DepsDto,
    semestrNum: number,
    loads: Load[],
}
interface Semester {
    
}
interface Load {
    atAcPlId: number,
    fshId: number,
    blocRecId: number,
    semNum: number,
    subTypeId: number,
    subTypeName: string,
    loadValue: number,
}
interface Rec {
    ze: number,
    total: number,
    les: number,
    lab: number,
    pr: number,
    iz: number,
    ak: number,
    kpr: number,
    sr: number,
    controll: number
}