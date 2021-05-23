
export { GroupAnalysDto, DirAnalysDto, Marks }

class GroupAnalysDto {
    public Group_id: number;

    public NumberAll: number;
    public NumberSubmitted: number;

    constructor() { }

    public getStatus(): number {
        let x = (this.NumberSubmitted * 100) / this.NumberAll;
        return x;
    }
}

class DirAnalysDto {
    public Dir_id: number;

    public Full: Marks;
    public Partial: Marks;

    public Message: string;

    constructor() { }


}

class Marks {
    public NumberAll722: number;
    public NumberSubmitted722: number;
    public Mark722: string;

    public NumberAll723: number;
    public NumberSubmitted723: number;
    public Mark723: string;

    public NumberAll724: number;
    public NumberSubmitted724: number;
    public Mark724: string;
}