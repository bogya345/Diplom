
export { User }

class User {
    // username: string,
    public username: string;
    public access_role_id: number;
    public access_role: string;
    public dep_id: number;
    public dep: string;
    public dateExpired: Date;

    /**
     *
     */
    constructor() {
        
    }
}

