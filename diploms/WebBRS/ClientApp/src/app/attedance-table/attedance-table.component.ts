import { Component, OnInit, Inject } from '@angular/core';

import { attedanceTable_HttpService } from './http.serviceAttedanceTable';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';
//import moment = require('moment');
@Component({
  selector: 'app-attedance-table',
  templateUrl: './attedance-table.component.html',
  styleUrls: ['./attedance-table.component.css']
})
export class AttedanceTableComponent implements OnInit {
  public http: attedanceTable_HttpService;
  public AttedanceTest: Array<string> =
    [
      'н',
      'б','н',
      'б','н',
      'б','н',
      'б','н',
      'б','н',
      'б','н',
      'б',

    ]
  public AttedanceTest2: Array<string> =
    [
      '/',
      '/','н',
      'б','н',
      'б','н',
      'б','н',
      'б','н',
      'б','н',
      '/',

    ]
  public studentsTest: Array<StudentTable> =

    [
      {
        IdStudent: 1,
        PersonFIO: 'Student1',
        Attedanced: this.AttedanceTest
      },
      {
        IdStudent: 2,
        PersonFIO: 'Student2',
        Attedanced: this.AttedanceTest2
      },
      {
        IdStudent: 3,
        PersonFIO: 'Student3',
        Attedanced: this.AttedanceTest
      },
      {
        IdStudent: 4,
        PersonFIO: 'Student4',
        Attedanced: this.AttedanceTest2
      },
      {
        IdStudent: 5,
        PersonFIO: 'Student5',
        Attedanced: this.AttedanceTest
      },
      {
        IdStudent: 6,
        PersonFIO: 'Student6',
        Attedanced: this.AttedanceTest2
      },
      {
        IdStudent: 7,
        PersonFIO: 'Student7',
        Attedanced: this.AttedanceTest
      },
      {
        IdStudent: 8,
        PersonFIO: 'Student8',
        Attedanced: this.AttedanceTest
      },
      {
        IdStudent: 9,
        PersonFIO: 'Student9',
        Attedanced: this.AttedanceTest
      }
    ];
  public selectedGroup: GroupAttedanceTable;
  public groupsTest: Array<GroupAttedanceTable> =
    [
      {
        idGroup: 1, GroupName: 'ИСТ-17', Specialty: 'ИСТ', Students: this.studentsTest
      },
      {
        idGroup: 2, GroupName: 'РиСО-17', Specialty: 'РиСО', Students: this.studentsTest
      }
    ];
  public now: Date;
 

  public lecturer: Lecturer =
    {
      IdLecturer: 1,
      PersonFIO:'Lecturer1'
    }
  public exactClassesTest: Array<ExactClass> =
    [
      {
        IdClass: 1,
        DateExactClass: '06-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 2,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 3,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 4,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 5,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      },
      {
        IdClass: 6,
        DateExactClass: '08-03-21',
        numberClass: 1,
        Group: this.groupsTest[1]
      }
    ];
  public exactClassForLecturerClass: ExactClassForLecturerClassTable =
    {
      IdECFLCT: 1,
      ExactClasses: this.exactClassesTest,
      Lecturer: this.lecturer,
      Groups: this.groupsTest,
      SubjectName: "subject"
  };
  selectChangeHandler(event: any) {
    //update the ui
    this.selectedGroup = event.target.value;
  }
  constructor() { }

  ngOnInit() {
    //this.http.getAttedanceForLecturerClasses()
    //  .subscribe(result => {
    //    this.exactClassForLecturerClass = result;
    //    console.log('result/constructor', result);
    console.log(this.exactClassForLecturerClass)
    console.log(this.selectedGroup);
    //  }, error => {
    //    console.log('error/constructor', error);
    //  }
    //  );

  }



}
interface GroupAttedanceTable {
  idGroup: number,
  GroupName: string,
  Specialty: string,
  Students: StudentTable[]
}
interface ExactClassForLecturerClassTable {
  IdECFLCT: number,
  Lecturer: Lecturer,
  ExactClasses: ExactClass[],
  Groups: GroupAttedanceTable[],
  SubjectName: string
}
interface StudentTable {
  IdStudent: number,
  PersonFIO: string,
  Attedanced: string[]
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}

interface ExactClass {
  IdClass: number,
  DateExactClass: string,
  numberClass: number,
  Group: GroupAttedanceTable
}
