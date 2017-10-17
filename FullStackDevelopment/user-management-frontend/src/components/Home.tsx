import * as React from "react";
import {UserInfo, UserService} from "../services/UserService";

export class Home extends React.Component {
    constructor(private userService: UserService){
        super();
    }

    private static getUserItem(userInfo: UserInfo){
        return <label>{userInfo}</label>
    }

    render() {
        let users = this.userService.getAllUsers();
        return users.map(Home.getUserItem);
    }
}