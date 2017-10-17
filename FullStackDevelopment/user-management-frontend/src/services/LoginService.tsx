export interface AccountInfo{
    id: number;
    userId: number;
    login: string;
}

export class LoginService {
    private currentUser: AccountInfo = null;

    public getCurrentUser(){

    }

    public login(userName: string, password: string){
        this.currentUser = {id: 1, userId: 10, login: userName};
    }
}