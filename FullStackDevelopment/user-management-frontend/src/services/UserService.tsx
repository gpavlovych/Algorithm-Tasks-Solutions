export interface UserInfo {
    id: number;
    photoUrl: string;
    firstName: string;
    lastName: string;
    position: string;
}

export class UserService {

    public getUser(id: number): UserInfo{
        return {
            id: id,
            photoUrl: "somePh",
            firstName: "John",
            lastName: "Doe",
            position: "Lead .NET Developer"
        };
    }
    public getAllUsers(): UserInfo[] {
        //todo: REST API http call should be invoked instead
        return [{id: 1, photoUrl: "somePh", firstName: "John", lastName: "Doe", position: "Lead .NET Developer"}];
    }
}