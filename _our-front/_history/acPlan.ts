  private blockNums_data: Subject[] = [
    { SubjectName: 'Subject #2', Semestrs: [{ SemNum: 1, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #3', Semestrs: [{ SemNum: 2, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #4', Semestrs: [{ SemNum: 2, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #5', Semestrs: [{ SemNum: 2, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #6', Semestrs: [{ SemNum: 3, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #7', Semestrs: [{ SemNum: 3, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #8', Semestrs: [{ SemNum: 3, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #9', Semestrs: [{ SemNum: 4, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #10', Semestrs: [{ SemNum: 5, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
  ];

  private ELEMENT_DATA2: Subject[] = [
    { SubjectName: 'Subject #1', Semestrs: [{ SemNum: 1, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #2', Semestrs: [{ SemNum: 1, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #3', Semestrs: [{ SemNum: 2, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #4', Semestrs: [{ SemNum: 2, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #5', Semestrs: [{ SemNum: 2, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #6', Semestrs: [{ SemNum: 3, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #7', Semestrs: [{ SemNum: 3, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #8', Semestrs: [{ SemNum: 3, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #9', Semestrs: [{ SemNum: 4, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
    { SubjectName: 'Subject #10', Semestrs: [{ SemNum: 5, Loads: { Ze: 0, Total: 100, Les: 10, Lab: 3, Pr: 1, Iz: 0, Ak: 0, Kpr: 1, Sr: 4, Controll: 1 } }] },
  ];

  private ELEMENT_DATA: PeriodicElement[] = [
    { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
    { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
    { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
    { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
    { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
    { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
    { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
    { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
    { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
    { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
  ];