
export { GroupAnalysDto, DirAnalysDto }

class GroupAnalysDto {
    public group_id: number;

    public numberAll: number;
    public numberSubmitted: number;

    constructor() { }

    public getStatus(): number {
        let x = (this.numberSubmitted * 100) / this.numberAll;
        return x;
    }
}

class DirAnalysDto {
    public dir_id: number;

    public numberAll722: number;
    public numberSubmitted722: number;
    public mark722: string;

    public numberAll723: number;
    public numberSubmitted723: number;
    public mark723: string;

    public numberAll724: number;
    public numberSubmitted724: number;
    public mark724: string;

    public message: string;
    
    constructor() { }

    
}