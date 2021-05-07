import { Component, OnInit } from '@angular/core';
import { TimetablePartComponent } from '../timetable-part/timetable-part.component';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']

})

export class TimetableComponent implements OnInit {

  constructor() { }

  public ClassesTest: Array<TimeTableExactClass> =
    [
      {
        idEC: 1,
        SubjectName: "Математика",
        CabNumber: "405л"
      },
      {
        idEC: 2,
        SubjectName: "Физика",
        CabNumber: "215л"
      },
      {
        idEC: 3,
        SubjectName: "История",
        CabNumber: "314л"
      },
      {
        idEC: 4,
        SubjectName: "Алгоритмы",
        CabNumber: "410к"
      }
    ];
  public Days1: Array<TimeTableDay> =
    [
      {
        idDay: 1,
        DayName: 'Понедельник',
        Date: "25.03.20",
        Classes: this.ClassesTest

      },
      {
        idDay: 2,
        DayName: 'Вторник',
        Date: "26.03.20",
        Classes: this.ClassesTest

      },
      {
        idDay: 3,
        DayName: 'Среда',
        Date: "27.03.20",
        Classes: this.ClassesTest

      }

    ];
  public Days2: Array<TimeTableDay> =
    [

      {
        idDay: 4,
        DayName: 'Четерг',
        Date: "28.03.20",
        Classes: this.ClassesTest

      },
      {
        idDay: 5,
        DayName: 'Пятница',
        Date: "29.03.20",
        Classes: this.ClassesTest

      },
      {
        idDay: 6,
        DayName: 'Суббота',
        Date: "30.03.20",
        Classes: this.ClassesTest

      }

    ];
  public StatusTest: StatusHW =
    {
      idStatus: 2,
      StatusName: "невыполнено"
    };
  public StatusTest2: StatusHW =
    {
      idStatus: 1,
      StatusName: "проверено"
    };
  public HWActual: Array<HomeWorkTimeTable> =
    [

      {
        idHW: 658,
        Lecturer: {
          IdLecturer: 1,
          PersonFIO: "Григорьевых А."
        },
        DateTimeGiven: "28.03.20",
        StatusHW: this.StatusTest,

        HWText: "Задание тест1",
      },
      {
        idHW: 175,
        Lecturer: {
          IdLecturer: 1,
          PersonFIO: "Кунцев В."
        },
        DateTimeGiven: "18.03.20",
        StatusHW: this.StatusTest2,

        HWText: "Задание тест2"

      }

    ];
  ngOnInit() {
  }

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
