
export {
    Group, BlockRec, AcPlan,
    BlocNum, Subject, Semester, Load
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
    BlockNums: BlocNum[]
}
interface BlocNum {
    BlockName: string,
    Subjects: Subject[],
}
interface Subject {
    SubjectName: string,
    Loads: Load[],
}
interface Semester {
    
}
interface Load {
    atAcPlId: number,
    FshId: number,
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