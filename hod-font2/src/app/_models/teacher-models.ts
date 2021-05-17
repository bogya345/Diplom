
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
    public Fsh_id: number;
    public Fh_id: number;
    public emp_id: number;
    public FirstName: string;
    public LastName: string;
    public MiddleName: string;
    public FullName: string;

    public WorkT_name: string;
    public Post_name: string;
    public Dep_id: number;
    public StaffCount: number;
    public DateBegin: Date;

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

