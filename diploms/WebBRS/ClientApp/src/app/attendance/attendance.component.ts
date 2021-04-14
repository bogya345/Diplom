import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {
  public hw: HomeWorkStudent = {
    IdHWS: 1,
    ShortTextHW: 'Выполненное задание в прикрепленном файле',
    StringFilePath: 'files/hws/1'
  };
  public cw: ClassWork = {
    IdCW: 1,
    TextWork: 'Конспект выполнить',
    FilePathWork: 'files/cw/1',
    MaxBall: 5
  };
  public fileToUpload: File = null;
  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
  }
  public attedanced: Array<string> = ['н', 'б', 'оу'];
  public studentsTest: Array<StudentEXC> =

    [
      {
        IdStudent: 1,
        PersonFIO: 'Student1',
        Attedanced: this.attedanced,
        Ball: 4,
        HW: this.hw
      },
      {
        IdStudent: 2,
        PersonFIO: 'Student2',
        Attedanced: this.attedanced,
        Ball: 0,
        HW: this.hw
      },
      {
        IdStudent: 3,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      },
      {
        IdStudent: 4,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      },
      {
        IdStudent: 5,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      },
      {
        IdStudent: 6,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      },
      {
        IdStudent: 7,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      },
      {
        IdStudent: 8,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      },
      {
        IdStudent: 9,
        PersonFIO: 'Student3',
        Attedanced: this.attedanced,
        Ball: 1,
        HW: this.hw
      }
    ];
  public groupsTest: Array<Group> =
    [
      {
        idGroup: 1, GroupName: 'ИСТ-17', Specialty: 'ИСТ', Students: this.studentsTest
      },
      {
        idGroup: 2, GroupName: 'РиСО-17', Specialty: 'РиСО', Students: this.studentsTest
      }
    ];

  public lecturer: Lecturer =
    {
      IdLecturer: 1,
      PersonFIO: 'Lecturer1'
    }
  public exactClassesTest: Array<ExactClass> =
    [
      {
        IdClass: 1,
        DateExactClass: '06-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 2,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 3,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 4,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 5,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-2021',
        numberClass: 1,
        Group: this.groupsTest[1]
      }
    ];

  constructor() { }
  public ECFLC: ExactClassForLecturerClass = {
    IdECFLC: 1,
    Lecturer: this.lecturer,
    Students: this.studentsTest,
    Groups: this.groupsTest,
    SubjectName: 'Subject1',
    DateTime: '08-03-21'
  }
  ngOnInit() {
  }

}

interface ClassWork {
  IdCW: number,
  TextWork: string,
  FilePathWork: string,
  MaxBall: number
}
interface Group {
  idGroup: number,
  GroupName: string,
  Specialty: string,
  Students: StudentEXC[]
}
interface ExactClassForLecturerClass {
  IdECFLC: number,
  Lecturer: Lecturer,
  Students: StudentEXC[],
  Groups: Group[],
  SubjectName: string
  DateTime: string
}
interface StudentEXC {
  IdStudent: number,
  PersonFIO: string,
  Attedanced: string[],
  Ball: number,
  HW: HomeWorkStudent
}
interface HomeWorkStudent {
  IdHWS: number,
  ShortTextHW: string,
  StringFilePath: string
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number,
  Group: Group
}
