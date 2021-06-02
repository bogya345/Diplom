import { DepsDto } from "./deps-models";

export {
    Group, BlockRec, AcPlan,
    BlockNum, Subject, Semester, Load
}
interface Group {
    Group_id: number,
    Group_name: string,
    Group_acPlan_id: number,
    CreatedDate: string,
    ExitDate: string
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
    BlockNums: BlockNum[]
}
interface BlockNum {
    BlockName: string,
    Subjects: Subject[],
}
interface Subject {
    SubjectName: string,
    CorrespDep: DepsDto,
    SemestrNum: number,
    Loads: Load[],
    Mark: string
}
interface Semester {
    
}
interface Load {
    AtAcPlId: number,
    FshId: number,
    TeachName: string,
    BlocRecId: number,
    SemNum: number,
    SubTypeId: number,
    SubTypeName: string,
    LoadValue: number,
}
interface Rec {
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