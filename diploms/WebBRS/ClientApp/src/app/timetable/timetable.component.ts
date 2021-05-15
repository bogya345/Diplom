import { TimetablePartComponent } from '../timetable-part/timetable-part.component';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { Component, OnInit, Inject } from '@angular/core';
import { serviceTimeTable } from './http.serviceTimeTable';
import { HttpClient, HttpRequest, HttpResponse, HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']

})

export class TimetableComponent implements OnInit {


  public http: serviceTimeTable;
  public baseUrl: string;
  public TimeTable: TimeTable;
  public TimeTable2: TimeTable2;
  public ClassWorks: ClassWorkVMUnion;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = new serviceTimeTable(http);
    this.baseUrl = baseUrl;

  }
  //public ClassesTest: Array<TimeTableExactClass> =
  //  [
  //    {
  //      idEC: 1,
  //      SubjectName: "Математика",
  //      CabNumber: "405л"
  //    },
  //    {
  //      idEC: 2,
  //      SubjectName: "Физика",
  //      CabNumber: "215л"
  //    },
  //    {
  //      idEC: 3,
  //      SubjectName: "История",
  //      CabNumber: "314л"
  //    },
  //    {
  //      idEC: 4,
  //      SubjectName: "Алгоритмы",
  //      CabNumber: "410к"
  //    }
  //  ];
  //public Days1: Array<TimeTableDay> =
  //  [
  //    {
  //      idDay: 1,
  //      DayName: 'Понедельник',
  //      Date: "25.03.20",
  //      Classes: this.ClassesTest

  //    },
  //    {
  //      idDay: 2,
  //      DayName: 'Вторник',
  //      Date: "26.03.20",
  //      Classes: this.ClassesTest

  //    },
  //    {
  //      idDay: 3,
  //      DayName: 'Среда',
  //      Date: "27.03.20",
  //      Classes: this.ClassesTest

  //    }

  //  ];
  //public Days2: Array<TimeTableDay> =
  //  [

  //    {
  //      idDay: 4,
  //      DayName: 'Четерг',
  //      Date: "28.03.20",
  //      Classes: this.ClassesTest

  //    },
  //    {
  //      idDay: 5,
  //      DayName: 'Пятница',
  //      Date: "29.03.20",
  //      Classes: this.ClassesTest

  //    },
  //    {
  //      idDay: 6,
  //      DayName: 'Суббота',
  //      Date: "30.03.20",
  //      Classes: this.ClassesTest

  //    }

  //  ];
  //public StatusTest: StatusHW =
  //  {
  //    idStatus: 2,
  //    StatusName: "невыполнено"
  //  };
  //public StatusTest2: StatusHW =
  //  {
  //    idStatus: 1,
  //    StatusName: "проверено"
  //  };
  //public HWActual: Array<HomeWorkTimeTable> =
  //  [

  //    {
  //      idHW: 658,
  //      Lecturer: {
  //        IdLecturer: 1,
  //        PersonFIO: "Григорьевых А."
  //      },
  //      DateTimeGiven: "28.03.20",
  //      StatusHW: this.StatusTest,

  //      HWText: "Задание тест1",
  //    },
  //    {
  //      idHW: 175,
  //      Lecturer: {
  //        IdLecturer: 1,
  //        PersonFIO: "Кунцев В."
  //      },
  //      DateTimeGiven: "18.03.20",
  //      StatusHW: this.StatusTest2,

  //      HWText: "Задание тест2"

  //    }

  //  ];
  selectChangeHandler(event: any) {
    //update the ui
    this.TimeTable2.IdSelectedDraft = event.target.value;
    console.log(this.TimeTable2.IdSelectedDraft);
    this.http.getStudentClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.DaysStudent = result.DaysStudent;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
    );

    this.http.getStudentWorksList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.ClassWorks = result;
        //this.TimeTable2.DaysStudent = result.DaysStudent;

        console.log('keksCW', this.ClassWorks);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

  selectChangeHandler2(event: any) {
    //update the ui
    this.TimeTable2.IdSelectedDraftType = event.target.value;
    console.log(this.TimeTable2.IdSelectedDraft);
    this.http.getStudentClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.DaysStudent = result.DaysStudent;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
    );

    this.http.getStudentWorksList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.ClassWorks = result;
        //this.TimeTable2.DaysStudent = result.DaysStudent;

        console.log('keks', this.ClassWorks);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  selectChangeHandler3(event: any) {
    //update the ui
    this.TimeTable2.IdDateSelected = event.target.value;
    console.log('Дата',this.TimeTable2.IdDateSelected);
    this.http.getStudentClassList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.DaysStudent = result.DaysStudent;
        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);
      }, error => {
        console.log('error/constructor', error);
      }
    );

    this.http.getStudentWorksList(this.TimeTable2.IdSelectedDraft, this.TimeTable2.IdSelectedDraftType, this.TimeTable2.IdDateSelected)
      .subscribe(result => {
        this.ClassWorks = result;
        //this.TimeTable2.DaysStudent = result.DaysStudent;

        console.log('keks', this.ClassWorks);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }
  
  ngOnInit() {
    this.http.getStudentClassList(-1096224834, 2007228761, '2001-01-08T00:00:00')
      .subscribe(result => {
        this.TimeTable2 = result;
        this.TimeTable2.DaysStudent = result.DaysStudent;

        console.log('keks', this.TimeTable2);
        console.log('result/constructor', result);

      }, error => {
        console.log('error/constructor', error);
      }
    );
    this.http.getStudentWorksList(-1096224834, 2007228761, '2001-01-08T00:00:00')
      .subscribe(result => {
        this.ClassWorks = result;
        //this.TimeTable2.DaysStudent = result.DaysStudent;

        console.log('keksCW', this.ClassWorks);
        console.log('result/constructorCW', result);

      }, error => {
        console.log('error/constructor', error);
      }
      );
  }

}

interface ClassWorkVMUnion {
  classWorkVM: ClassWork[],
  classWorkVMAll: ClassWork[]
}
interface TimeTableExactClass {
  idEC: number,
  SubjectName: string,
  CabNumber: string,

}

interface HomeWorkTimeTable {
  idHW: number,
  Lecturer: Lecturer,
  DateTimeGiven: string,
  HWText: string,
  StatusHW: StatusHW

}
interface TimeTableDay {
  idDay: number,
  DayName: string,
  Date: string,
  Classes: TimeTableExactClass[]
}
interface StatusHW {
  idStatus: number,
  StatusName: string
}
interface Lecturer {
  IdLecturer: number,
  PersonFIO: string

}

interface SubjectVM {
  //sfgs: SubjectForGroup[];
  IdSubject: number,
  SubjectName: string
}
interface TeacherClass {
  IdSFG: number,
  IdSubject: number,
  IdPerson: number,
  IdCourse: number,
  PersonFIO: number,
  StudyYearIdStudyYear: number
}
interface TimeTable {
  StudyYears: StudyYear[],
  selectedSY: StudyYear,
  SubjectVMs: SubjectVM[];
  idLect: number,
  LecturerFIO: string
}
interface StudyYear {
  IdStudyYear: number,
  _Description: string,
  DateTimeStart: string,
  DateTimeEnd: string
}
interface SubjectForGroup {

  IdSFG: number,
  IdGroup: number,
  IdCourse: number,
  DepartmentID: number,
  TypeStudy: TypeStudy
}
interface TypeStudy {
  IdTS: number,
  TypeStudyName: string,
  ShortTypeStudyName: string
}
interface EXTCforTimeTable {
  IdClass: number,
  Auditory: string,
  IdECFLCT: number,
  SubjectName: string,
  DateTime: string,
  DayOfWeek: string
}
interface ClassWork {
  IdClassWork: number,
  IdClasss: number,
  TextWork: string,
  LecturerFIO: string,
  SubjectName: string,
  FilePathWork: string,
  MaxBall: number,
  DatePass: Date
}
interface SubjectVM {
  //public List<SubjectForGroup> sfgs = new List<SubjectForGroup>();
  IdSubject: number,
  SubjectName: string
}
interface DraftTimeTable {
  IdDFTT: number,
  _Description: string
}
interface TypeTimeTable {
  IdDTTT: number,
  _Description: string
}
interface TimeTable2 {
  Drafts: DraftTimeTable[],
  IdSelectedDraft: number,
  DraftTypes: TypeTimeTable[],
  IdSelectedDraftType: number,
  DaysStudent: DayStudent[],
  IdDateSelected: string

}
interface DayStudent {
  DayOfWeek: string,
  EXTCforTimeTablesStudent: EXTCforTimeTable[];
}

