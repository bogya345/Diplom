
export { Teacher, GroupTeacher }

// interface Teacher {
//     fsh_id: number,
//     fh_id: number,
//     emp_id: number,
//     firstName: string,
//     lastName: string,
//     middleName: string,
//     fullName: string,

//     workT_name: string,
//     post_name: string,
//     dep_id: number,
//     staffCount: number,
//     dateBegin: Date,
// }
class Teacher {
    public fsh_id: number;
    public fh_id: number;
    public emp_id: number;
    public firstName: string;
    public lastName: string;
    public middleName: string;
    public fullName: string;

    public workT_name: string;
    public post_name: string;
    public dep_id: number;
    public staffCount: number;
    public dateBegin: Date;

    // public toString = (): string => {
    //     return `${this.fullName}`;
    // }
    // public toLowerCase(): string {
    //     return `${this.fullName.toLowerCase()}`;
    // }
}
interface GroupTeacher {
    letter: string,
    teachers: Teacher[]
}

// class GroupTeacher {
//     public letter: string;
//     public teachers: Teacher[];

//     public toString = () : string => {
//         return `${this.id}`;
//     }
// }

